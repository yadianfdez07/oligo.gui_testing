using System;
using System.Collections.ObjectModel;
using System.Linq;
using oligo.domain.infrastructure;
using Prism.Mvvm;
using System.Windows;
using oligo.module.c_sharp_api_text_viewer.Models;
using Prism.Commands;

namespace oligo.module.c_sharp_api_text_viewer.ViewModels
{
    public class ViewAViewModel : BindableBase
    {
        private readonly IConstantTextViewer _constantTextViewer;
        private readonly IDllImportTextViewer _dllImportTextViewer;
        private readonly IStructTextViewer _structTextViewer;

        #region UI-Content

        private string _message;
        public string Message
        {
            get { return _message; }
            set { SetProperty(ref _message, value); }
        }

        private string _apiTypeText;
        public string ApiTypeText
        {
            get { return _apiTypeText; }
            set { SetProperty(ref _apiTypeText, value); }
        }

        private string _searchMessageText;
        public string SearchMessageText
        {
            get { return _searchMessageText; }
            set { SetProperty(ref _searchMessageText, value); }
        }

        private string _availableFunctionsText;
        public string AvailableFunctionsText
        {
            get { return _availableFunctionsText; }
            set { SetProperty(ref _availableFunctionsText, value); }
        }

        private string _selectedFunctionsText;
        public string SelectedFunctionsText
        {
            get { return _selectedFunctionsText; }
            set { SetProperty(ref _selectedFunctionsText, value); }
        }

        private string _addBtnText;
        public string AddBtnText
        {
            get { return _addBtnText; }
            set { SetProperty(ref _addBtnText, value); }
        }

        private string _removeBtnText;
        public string RemoveBtnText
        {
            get { return _removeBtnText; }
            set { SetProperty(ref _removeBtnText, value); }
        }

        private string _clearBtnText;
        public string ClearBtnText
        {
            get { return _clearBtnText; }
            set { SetProperty(ref _clearBtnText, value); }
        }

        private string _copyBtnText;
        public string CopyBtnText
        {
            get { return _copyBtnText; }
            set { SetProperty(ref _copyBtnText, value); }
        }

        #endregion

        private ApiTypes _selectedItem;
        public ApiTypes SelectedItem
        {
            get { return _selectedItem; }
            set
            {
                UpdateCurrentKeys(value);
                SetProperty(ref _selectedItem, value);
            }
        }

        private ObservableCollection<string> _constantKeys;
        public ObservableCollection<string> ConstantKeys
        {
            get { return _constantKeys; }
            set { SetProperty(ref _constantKeys, value); }
        }

        private ObservableCollection<string> _dllImportKeys;
        public ObservableCollection<string> DllImportKeys
        {
            get { return _dllImportKeys; }
            set { SetProperty(ref _dllImportKeys, value); }
        }

        private ObservableCollection<string> _structKeys;
        public ObservableCollection<string> StructKeys
        {
            get { return _structKeys; }
            set { SetProperty(ref _structKeys, value); }
        }

        private ObservableCollection<string> _currentKeys;
        public ObservableCollection<string> CurrentKeys
        {
            get { return _currentKeys; }
            set { SetProperty(ref _currentKeys, value); }
        }

        private string _selectedFunction;
        public string SelectedFunction
        {
            get { return _selectedFunction; }
            set { SetProperty(ref _selectedFunction, value); }
        }

        private string _cSharpSyntax;
        public string CSharpSyntax
        {
            get { return _cSharpSyntax; }
            set { SetProperty(ref _cSharpSyntax, value); }
        }

        private string _searchTerm;
        public string SearchTerm
        {
            get { return _searchTerm; }
            set
            {
                SetProperty(ref _searchTerm, value);
            }
        }

        private DelegateCommand _addSelectedFunctionCommand;
        public DelegateCommand AddSelectedFunctionCommand =>
            _addSelectedFunctionCommand ?? (_addSelectedFunctionCommand = new DelegateCommand(ExecuteCommandName, CanExecuteMethod).ObservesProperty(() => SelectedFunction));

        private DelegateCommand _clearCommand;
        public DelegateCommand ClearCommand =>
            _clearCommand ?? (_clearCommand = new DelegateCommand(ExecuteClearCommand, CanExecuteClear).ObservesProperty(() => CSharpSyntax));

        private DelegateCommand _copyCommand;
        public DelegateCommand CopyCommand =>
            _copyCommand ?? (_copyCommand = new DelegateCommand(ExecuteCopyCommand, CanExecuteClear).ObservesProperty(()=> CSharpSyntax));

        void ExecuteCopyCommand()
        {
            Clipboard.SetText(CSharpSyntax);
            CSharpSyntax = string.Empty;
        }

        private bool CanExecuteClear()
        {
            return !string.IsNullOrEmpty(CSharpSyntax);
        }

        void ExecuteClearCommand()
        {
            CSharpSyntax = string.Empty;
        }

        private bool CanExecuteMethod()
        {
            return SelectedFunction != null;
        }

        void ExecuteCommandName()
        {
            switch (SelectedItem)
            {
                case ApiTypes.Constant:
                    CSharpSyntax += _constantTextViewer.GetCSharpSyntax(CurrentKeys.IndexOf(SelectedFunction)).Replace(ApiUtility.CSHP_SCOPE, "public");
                    break;
                case ApiTypes.Declares:
                    CSharpSyntax += _dllImportTextViewer.GetCSharpSyntax(CurrentKeys.IndexOf(SelectedFunction)).Replace(ApiUtility.CSHP_SCOPE, "public");
                    break;
                case ApiTypes.Types:
                    CSharpSyntax += _structTextViewer.GetCSharpSyntax(CurrentKeys.IndexOf(SelectedFunction)).Replace(ApiUtility.CSHP_SCOPE, "public");
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
            CSharpSyntax += System.Environment.NewLine;
        }

        public ViewAViewModel(IConstantTextViewer constantTextViewer, IDllImportTextViewer dllImportTextViewer, IStructTextViewer structTextViewer)
        {
            _constantTextViewer = constantTextViewer;
            _constantTextViewer.ParseText();
            ConstantKeys = new ObservableCollection<string>(_constantTextViewer.DefinitionList.Keys);
            _dllImportTextViewer = dllImportTextViewer;
            _dllImportTextViewer.ParseText();
            DllImportKeys = new ObservableCollection<string>(_dllImportTextViewer.DefinitionList.Keys);
            _structTextViewer = structTextViewer;
            _structTextViewer.ParseText();
            StructKeys = new ObservableCollection<string>(_structTextViewer.DefinitionList.Keys);

            SelectedItem = ApiTypes.Constant;

            Message = "View A from your Prism Module";

            ApiTypeText = "API type: ";
            SearchMessageText = "Type the first few letters of the function name you look for: ";
            AvailableFunctionsText = "Available functions: ";
            SelectedFunctionsText = "Selected functions: ";
            AddBtnText = "Add";
            RemoveBtnText = "Remove";
            ClearBtnText = "Clear";
            CopyBtnText = "Copy";
        }

        private void UpdateCurrentKeys(ApiTypes value)
        {
            switch (value)
            {
                case ApiTypes.Constant:
                    CurrentKeys = ConstantKeys;
                    break;
                case ApiTypes.Declares:
                    CurrentKeys = DllImportKeys;
                    break;
                case ApiTypes.Types:
                    CurrentKeys = StructKeys;
                    break;
                default:
                    CurrentKeys = ConstantKeys;
                    break;
            }
        }

    }
}
