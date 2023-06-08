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
    public partial class TranscriptViewModel : ObservableObject
    {
        public TranscriptViewModel()
        {
            InitMonHocs();
            InitHocKis();
            selectedSubject = subjectList[0];
            selectedSemeter = termList[0];
        }
        private TranscriptConfig selectedConfig;
        public TranscriptConfig SelectedConfig { get { return selectedConfig; } 
            set { selectedConfig = value;
                if(selectedConfig != null) {
                    ClassDetailViewModel.Instance.setRightViewModel(new TranscriptRightViewModel(selectedConfig));

                }
                OnPropertyChanged(); } }

        private void Refresh()
        {
            InitStudents();
            SelectedConfig = null;
            ClassDetailViewModel.Instance.setRightViewModel(new EmptyRightViewModel());

        }
        private Monhoc selectedSubject;
        public Monhoc SelectedSubject { get { return selectedSubject; } set {  selectedSubject = value;
                OnPropertyChanged();
                Refresh();
            }
        }
        private Hocky selectedSemeter;
        public Hocky SelectedSemeter { get {  return selectedSemeter; } set { selectedSemeter = value;
                OnPropertyChanged();
                Refresh();
            } }
        [ObservableProperty]
        private ObservableCollection<Monhoc> subjectList = new ObservableCollection<Monhoc>()
        {
        };
        [ObservableProperty]
        private ObservableCollection<Hocky> termList = new ObservableCollection<Hocky>()
        {
        };

        [ObservableProperty]
        ObservableCollection<TranscriptConfig> transcripts = new ObservableCollection<TranscriptConfig>()
        {
        };

        [RelayCommand]
        private void BackToPrevScreen()
        {
            ClassManagementViewModel.Instance.NavigateClassList();
        }

        // lay hoc sinh
        private Lophocthucte lophocthucte;

        public void SetCurrentClass(Lophocthucte mclass)
        {
            lophocthucte = mclass;
            InitStudents();
        }

        List<Hocsinh> hocsinhs = new List<Hocsinh>();

        private void InitStudents()
        {
            hocsinhs.Clear();
            transcripts.Clear();
            hocsinhs = lophocthucte.Mahs.ToList();
            Namhoc namhoc = lophocthucte.ManhNavigation;
            foreach (var hocsinh in hocsinhs)
            {
                transcripts.Add(new TranscriptConfig(hocsinh, SelectedSemeter, SelectedSubject,namhoc)) ;
            }
        }

        private void InitMonHocs()
        {
            foreach (var mh in DataProvider.ins.context.Monhocs)
            {
                subjectList.Add(mh);
            }
        }

        private void InitHocKis()
        {
            foreach (var hk in DataProvider.ins.context.Hockies)
            {
                termList.Add(hk);
            }
        }
    }
}
