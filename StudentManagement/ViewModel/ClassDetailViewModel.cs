using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using StudentManagement.Object;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace StudentManagement.ViewModel
{
    public partial class ClassDetailViewModel : ObservableObject
    {
        public ClassDetailViewModel() 
        {
            Init();
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
            setBangDiemGray();
            setCauHinhBlue();
        }

        [RelayCommand]
        public void NavigateTranscript()
        {
            setViewModel(_transcriptViewModel);
            setBangDiemBlue();
            setCauHinhGray();
        }

        [ObservableProperty]
        private Class currentClass;

        public void SetCurrentClass(Class mclass)
        {
            CurrentClass = mclass;
        }


        [ObservableProperty]
        private object backgroundBangDiem = "#7CA7FF";
        [ObservableProperty]
        private object foregroundBangDiem = "White";
        [ObservableProperty]
        private object backgroundCauHinh = "White";
        [ObservableProperty]
        private object foregroundCauHinh = "Gray";

        void setBangDiemBlue()
        {
            BackgroundBangDiem = "#7CA7FF";
            ForegroundBangDiem = "White";
        }

        void setBangDiemGray()
        {
            BackgroundBangDiem = "White";
            ForegroundBangDiem = "Gray";
        }

        void setCauHinhBlue()
        {
            BackgroundCauHinh = "#7CA7FF";
            ForegroundCauHinh = "White";
        }

        void setCauHinhGray()
        {
            BackgroundCauHinh = "White";
            ForegroundCauHinh = "Gray";
        }
    }
}
