using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using StudentManagement.Models;
using StudentManagement.Object;
using StudentManagement.Service;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;

namespace StudentManagement.ViewModel
{
    public partial class TranscriptViewModel : ObservableObject
    {
        public TranscriptViewModel()
        {
            //InitMonHocs();
            InitHocKis();
            selectedSemeter = termList[0];
            DataGridColumns = new ObservableCollection<DataGridColumn>();

        }
        private ObservableCollection<DataGridColumn> _dataGridColumns;
        public ObservableCollection<DataGridColumn> DataGridColumns
        {
            get => _dataGridColumns;
            set
            {
                _dataGridColumns = value;
                OnPropertyChanged();
            }
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
            if (selectedSubject != null && selectedSemeter != null)
            {
                InitStudents();
                SelectedConfig = null;
                ClassDetailViewModel.Instance.setRightViewModel(new EmptyRightViewModel());
            }
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
        [RelayCommand]
        private void saveChange()
        {
            foreach(var tran in transcripts)
            {
                tran.saveData();
            }
            MessageBox.Show("Lưu thành công");
            ClassDetailViewModel.Instance.setRightViewModel(new EmptyRightViewModel());
        }

        // lay hoc sinh
        private Lophocthucte lophocthucte;

        public void SetCurrentClass(Lophocthucte mclass)
        {
            lophocthucte = mclass;
            InitMonHocs();
            

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
            //DataGridColumns = new ObservableCollection<DataGridColumn>();
            //if (transcripts.FirstOrDefault() != null)
            //{
            //    var diems = transcripts.First().DiemDisplays;
            //    DataGridTextColumn nameColumn = new DataGridTextColumn();
            //    nameColumn.Header = "Tên học sinh";
            //    nameColumn.Binding = new Binding("Student.Hotenhs");
            //    nameColumn.IsReadOnly = true;
            //    DataGridColumns.Add(nameColumn);

            //    foreach (var diem in diems)
            //    {
            //        DataGridTextColumn column = new DataGridTextColumn();
            //        column.Header = diem.Diem.MalktNavigation.Tenloaikiemtra;
            //        column.Binding = new Binding(string.Format("DiemDisplays[{0}].Diemdisplay", diems.IndexOf(diem)));
            //        DataGridColumns.Add(column);
            //    }
            //}
        }
        private void InitMonHocs()
        {
            if (LoginServices.Instance.IsAdmin == true)
            {
                foreach (var mh in DataProvider.ins.context.Monhocs)
                {
                    SubjectList.Add(mh);
                }
            }
            else
            {
                var giaovien = DataProvider.ins.context.Giaoviens.Where(x => x.Username == LoginServices.CurrentUser.Username).FirstOrDefault();
                if (giaovien != null && lophocthucte != null)
                {
                    var phanconglist = DataProvider.ins.context.Phanconggiangdays.Where(x => x.Malhtt == lophocthucte.Malhtt && x.Magv == giaovien.Magv).ToList();
                    foreach (var ph in phanconglist)
                    {
                        SubjectList.Add(ph.MamhNavigation);
                    }
                }
            }
            if(SubjectList!=null && subjectList.Count > 0) {
                SelectedSubject = SubjectList[0];
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
