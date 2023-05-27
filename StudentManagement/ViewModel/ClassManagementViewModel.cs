using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagement.ViewModel
{
    public partial class ClassManagementViewModel : ObservableObject
    {
        public ClassManagementViewModel()
        {
            Init();
            Instance = this;
        }

        private static ClassManagementViewModel _instance;
        public static ClassManagementViewModel Instance
        {
            get => _instance == null ? (_instance = new ClassManagementViewModel()) : _instance;
            private set => _instance = value;
        }

        private object _classListViewModel;
        private ClassDetailViewModel _classDetailViewModel;

        [ObservableProperty]
        private object contentViewModel;
        private void Init()
        {
            _classListViewModel = new ClassListViewModel();
            _classDetailViewModel = new ClassDetailViewModel();
            ContentViewModel = _classListViewModel;
        }


        public void setViewModel(object viewModel)
        {
            ContentViewModel = viewModel;
        }

        [RelayCommand]
        public void NavigateClassList()
        {
            setViewModel(_classListViewModel);
        }

        [RelayCommand]
        public void NavigateClassDetail(Class mclass)
        {
            SetDetailClass(mclass);
            setViewModel(_classDetailViewModel);
        }

        public void SetDetailClass(Class mclass)
        {
            _classDetailViewModel.SetCurrentClass(mclass);
        }
    }
}
