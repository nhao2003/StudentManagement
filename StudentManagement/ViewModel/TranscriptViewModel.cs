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
        }

        [ObservableProperty]
        private bool isReadOnly = true;
        [ObservableProperty]
        private ObservableCollection<string> subjectList = new ObservableCollection<string>()
        {
            
        };
        [ObservableProperty]
        private ObservableCollection<string> termList = new ObservableCollection<string>()
        {
        };

        [ObservableProperty]
        ObservableCollection<TranscriptConfig> transcripts = new ObservableCollection<TranscriptConfig>()
        {
        };

        [ObservableProperty]
        private Visibility editBtnVisibility = Visibility.Visible;
        [ObservableProperty]
        private Visibility cancelBtnVisibility = Visibility.Hidden;

        [RelayCommand]
        private void CancelEditting()
        {
            IsReadOnly = true;
            EditBtnVisibility = Visibility.Visible;

            CancelBtnVisibility = Visibility.Hidden;
        }

        [RelayCommand]
        private void EnableEditting()
        {
            IsReadOnly = false;
            EditBtnVisibility = Visibility.Hidden;
            CancelBtnVisibility = Visibility.Visible;
        }

        [RelayCommand]
        private void BackToPrevScreen()
        {
            ClassManagementViewModel.Instance.NavigateClassList();
        }

        // lay hoc sinh
        private Lophocthucte lophocthucte;

        public void SetCurrentClass(Lophocthucte mclass)
        {
            lophocthucte = null;
            lophocthucte = mclass;
            InitStudents();
        }

        List<Hocsinh> hocsinhs = new List<Hocsinh>();

        private void InitStudents()
        {
            hocsinhs.Clear();
            transcripts.Clear();
            hocsinhs = lophocthucte.Mahs.ToList();
            foreach(var hocsinh in hocsinhs)
            {
                transcripts.Add(hocsinh.toTranscript());
            }
        }

        private void InitMonHocs()
        {
            foreach (var mh in DataProvider.ins.context.Monhocs)
            {
                subjectList.Add(mh.Tenmh);
            }
        }

        private void InitHocKis()
        {
            foreach (var hk in DataProvider.ins.context.Hockies)
            {
                termList.Add(hk.Tenhk);
            }
        }
    }
}
