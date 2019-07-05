using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace oligo.module.c_sharp_api_text_viewer.ViewModels
{
    public class ViewAViewModel : BindableBase
    {
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

        public ViewAViewModel()
        {
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
