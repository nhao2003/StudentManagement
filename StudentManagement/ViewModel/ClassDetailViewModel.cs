using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using StudentManagement.Object;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagement.ViewModel
{
    public partial class ClassDetailViewModel : ObservableObject
    {
        public ClassDetailViewModel() 
        {
            Init();
            Instance = this;
        }

        private static ClassDetailViewModel _instance;
        public static ClassDetailViewModel Instance
        {
            get => _instance == null ? (_instance = new ClassDetailViewModel()) : _instance;
            private set => _instance = value;
        }

        private object _transcriptViewModel;
        private object _classconfigViewModel;

        [ObservableProperty]
        private object contentViewModel;
        private void Init()
        {
            _transcriptViewModel = new TranscriptViewModel();
            _classconfigViewModel = new ClassConfigViewModel();
            ContentViewModel = _transcriptViewModel;
        }

        public void setViewModel(object viewModel)
        {
            ContentViewModel = viewModel;
        }

        [RelayCommand]
        public void NavigateClassConfig()
        {
            setViewModel(_classconfigViewModel);
        }

        [RelayCommand]
        public void NavigateTranscript()
        {
            setViewModel(_transcriptViewModel);
        }

        [ObservableProperty]
        private Class currentClass;

        public void SetCurrentClass(Class mclass)
        {
            currentClass = mclass;
        }
    }
}
