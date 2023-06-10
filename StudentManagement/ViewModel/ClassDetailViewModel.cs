using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.VisualBasic;
using StudentManagement.Model;
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
            Instance = this;
        }

        private TranscriptViewModel _transcriptViewModel;
        private ClassConfigViewModel _classconfigViewModel;
        private TranscriptRightViewModel _transcriptRightViewModel;
        private EmptyRightViewModel _emptyRightViewModel;
        private static ClassDetailViewModel _instance;
        public static ClassDetailViewModel Instance
        {
            get => _instance == null ? (_instance = new ClassDetailViewModel()) : _instance;
            private set => _instance = value;
        }
        [ObservableProperty]
        private object contentViewModel;
        [ObservableProperty]
        private object rightViewModel;
        private void Init()
        {
            
            _transcriptViewModel = new TranscriptViewModel();
            _classconfigViewModel = new ClassConfigViewModel();
            _emptyRightViewModel = new EmptyRightViewModel();
            //_transcriptRightViewModel = new TranscriptRightViewModel();
            ContentViewModel = _transcriptViewModel;
            rightViewModel = _emptyRightViewModel;

        }
        public void setRightViewModel(object viewmodel)
        {
            RightViewModel = viewmodel;
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
            Lophocthucte = mclass;
            //MessageBox.Show(Lophocthucte.MalopNavigation.Tenlop);
            OnPropertyChanged();
            _transcriptViewModel.SetCurrentClass(lophocthucte);
            _classconfigViewModel.SetCurrentClass(lophocthucte);
        }

        public void Refresh(Lophocthucte lhtt)
        {
            SetCurrentClass(lhtt);
        }

        // set button
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
