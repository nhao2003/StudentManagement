using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using StudentManagement.Object;
using StudentManagement.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace StudentManagement.ViewModel
{
    public partial class ClassListViewModel : ObservableObject
    {
        private static ClassListViewModel _instance;
        public static ClassListViewModel Instance
        {
            get => _instance == null ? (_instance = new ClassListViewModel()) : _instance;
            private set => _instance = value;
        }

        public ClassListViewModel()
        {
            Instance = this;
            InitNienKhoas();
            InitClasses();
            InitStudents();
        }

        // lop
        [ObservableProperty]
        List<Lophocthucte> lops = new List<Lophocthucte>();

        [ObservableProperty]
        private ObservableCollection<Class> classes = new ObservableCollection<Class>()
        {
        };

        public void InitClasses()
        {
            lops = DataProvider.ins.context.Lophocthuctes.ToList();
            classes.Clear();
            foreach (var lop in lops)
            {
                if(lop.ManhNavigation == sNamhoc)
                    classes.Add(new Class(lop));
            }
        }
        // hoc sinh
        List<Hocsinh> hocsinhs = new List<Hocsinh>();
        [ObservableProperty]
        private ObservableCollection<Student> students = new ObservableCollection<Student>()
        {
        };

        [ObservableProperty]
        private ObservableCollection<Student> newStudents = new ObservableCollection<Student>()
        {
        };

        public void InitStudents()
        {
            hocsinhs = DataProvider.ins.context.Hocsinhs.ToList();
            foreach (var hs in hocsinhs)
            {
                newStudents.Add(new Student(hs));
            }
        }
        [ObservableProperty]
        private Class choosenClass;

        [ObservableProperty]
        private Visibility classStudentsVisibility = Visibility.Hidden;
        [ObservableProperty]
        private Visibility newStudentsVisibility = Visibility.Visible;
        
        public void SetChooseClass(Class mclass)
        {
            ChoosenClass = mclass;
            ClassStudentsVisibility = Visibility.Visible;
            NewStudentsVisibility = Visibility.Hidden;

            students.Clear();
            foreach(var hs in mclass.GetHocSinhs())
            {
                students.Add(new Student(hs));
            }
        }

        [RelayCommand]
        public void ShowNewStudents()
        {
            ClassStudentsVisibility = Visibility.Hidden;
            NewStudentsVisibility = Visibility.Visible;
        }

        // nien khoa
        [ObservableProperty]
        private ObservableCollection<Namhoc> nienKhoas = new ObservableCollection<Namhoc>()
        {
        };

        private Namhoc sNamhoc;

        public Namhoc SNamhoc
        {
            get { return sNamhoc; }
            set 
            { 
                sNamhoc = value;
                InitClasses();
                OnPropertyChanged();
            }
        }

        private void InitNienKhoas()
        {
            foreach(var nh in DataProvider.ins.context.Namhocs.ToList())
            {
                nienKhoas.Add(nh);
            }
            SNamhoc = nienKhoas[0];
        }

        public void Refresh()
        {
            InitClasses();
            InitStudents();

            ClassManagementViewModel.Instance.SetDetailClass(choosenClass.GetLopHocThuTe());
            ClassStudentsVisibility = Visibility.Visible;
            NewStudentsVisibility = Visibility.Hidden;
        }
    }
}
