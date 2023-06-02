using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using StudentManagement.Models;
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

        private TranscriptViewModel _transcriptViewModel;
        private ClassConfigViewModel _classconfigViewModel;

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
        private Lophocthucte lophocthucte;

        public void SetCurrentClass(Lophocthucte mclass)
        {
            lophocthucte = mclass;
            _transcriptViewModel.SetCurrentClass(lophocthucte);
            _classconfigViewModel.SetCurrentClass(lophocthucte);
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
