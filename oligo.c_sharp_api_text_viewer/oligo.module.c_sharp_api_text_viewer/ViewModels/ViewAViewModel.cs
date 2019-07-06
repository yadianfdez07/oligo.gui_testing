using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using oligo.domain.infrastructure;
using Prism.Mvvm;
using System.Linq;
using oligo.module.c_sharp_api_text_viewer.Models;

namespace oligo.module.c_sharp_api_text_viewer.ViewModels
{
    public class ViewAViewModel : BindableBase
    {
        private readonly IConstantTextViewer _constantTextViewer;
        private readonly IDllImportTextViewer _dllImportTextViewer;
        private readonly IStructTextViewer _structTextViewer;

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
    }
}
