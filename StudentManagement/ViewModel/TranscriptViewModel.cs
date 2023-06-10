using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using StudentManagement.Models;
using StudentManagement.Object;
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
            InitMonHocs();
            InitHocKis();
            
            selectedSubject = subjectList[0];
            selectedSemeter = termList[0];
            DataGridColumns = new ObservableCollection<DataGridColumn>();
            //GenerateColumns(DataObjects);

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
            DataGridColumns = new ObservableCollection<DataGridColumn>();
            if(transcripts.FirstOrDefault() != null)
            {
                var diems = transcripts.First().Diemmonhocs;
                DataGridTextColumn nameColumn = new DataGridTextColumn();
                nameColumn.Header = "Tên học sinh";
                nameColumn.Binding = new Binding("Student.Hotenhs");
                DataGridColumns.Add(nameColumn);

                foreach (var diem in diems)
                {
                    DataGridTextColumn column = new DataGridTextColumn();
                    column.Header = diem.MalktNavigation.Tenloaikiemtra;
                    column.Binding = new Binding(string.Format("Diemmonhocs[{0}].Diem", diems.IndexOf(diem)));
                    DataGridColumns.Add(column);
                }
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
