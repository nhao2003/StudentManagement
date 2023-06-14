using Castle.Core.Internal;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.IdentityModel.Tokens;
using StudentManagement.Component.ListClass;
using StudentManagement.Model;
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
            //InitStudents();
            emptyRightViewmodel = new EmptyRightViewModel();
            RightViewModel = emptyRightViewmodel;
            String giatri = DataProvider.ins.context.Thamsos.Where(x => x.Tents.Equals("Sỉ số tối đa của lớp")).FirstOrDefault().Giatri;
            maxStudentInClass = int.Parse(giatri) != null ? int.Parse(giatri) : 0;

        }
        [ObservableProperty]
        private int maxStudentInClass;

        private object emptyRightViewmodel;
        [ObservableProperty]
        private object rightViewModel;

        // lop
        [ObservableProperty]
        ObservableCollection<Lophocthucte> lops = new ObservableCollection<Lophocthucte>();

        [ObservableProperty]
        private ObservableCollection<Class> classes = new ObservableCollection<Class>()
        {
        };
        public void setRightViewModel(object rightViewModel)
        {
            RightViewModel = rightViewModel;
        }

        public void InitClasses()
        {
            var ls = DataProvider.ins.context.Lophocthuctes.Where(x=>x.Isdeleted == false).ToList();
            lops = new ObservableCollection<Lophocthucte>(ls);
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

        //public void InitStudents()
        //{
        //    hocsinhs = DataProvider.ins.context.Hocsinhs.ToList();
        //    foreach (var hs in hocsinhs)
        //    {
        //        newStudents.Add(new Student(hs));
        //    }
        //}
        [RelayCommand]
        private void deleteClass()
        {
            ChoosenClass.Lophtt.Isdeleted = true;
            DataProvider.ins.context.Lophocthuctes.Update(ChoosenClass.Lophtt);
            DataProvider.ins.context.SaveChanges();
            InitClasses();
            setRightViewModel(new EmptyRightViewModel());
        }

        [ObservableProperty]
        private Class choosenClass;        
        public void SetChooseClass(Class mclass)
        {
            RightViewModel = new ClassListRightViewModel(this);
            ChoosenClass = mclass;
            NewStudents.Clear();
            if(ChoosenClass.Lophtt.MalopNavigation.Khoi == 10)
            {
                var students  = DataProvider.ins.context.Hocsinhs.Where(x => x.Malhtts.Count == 0 && x.Isdeleted == false).OrderByDescending(x=>x.Hotenhs).ToList();
                foreach (var st in students)
                {
                    NewStudents.Add(new Student(st));   
                }
            }
            else if(ChoosenClass.Lophtt.MalopNavigation.Khoi == 11)
            {
                var students = DataProvider.ins.context.Hocsinhs.Where(x => x.Malhtts.Count > 0 && x.Isdeleted == false).OrderByDescending(x => x.Hotenhs).ToList();
                foreach(var student in students)
                {
                    var sl = DataProvider.ins.context.Kqnamhocs.Where(x => x.MaKetQua == "KQ001" && x.Mahs == student.Mahs).ToList();
                    if(sl != null && sl.Count == 1)
                    {
                        NewStudents.Add(new Student(student));
                    }
                }
                //var students = DataProvider.ins.context.Hocsinhs.Where(x => x.Malhtts.Count > 0 && x.Malhtts.Where(x => x.Malop ==  )).
            }
            else if(ChoosenClass.Lophtt.MalopNavigation.Khoi == 12)
            {
                var students = DataProvider.ins.context.Hocsinhs.Where(x => x.Malhtts.Count > 0 && x.Isdeleted == false).OrderByDescending(x => x.Hotenhs).ToList();
                foreach (var student in students)
                {
                    var sl = DataProvider.ins.context.Kqnamhocs.Where(x => x.MaKetQua == "KQ001" && x.Mahs == student.Mahs).ToList();
                    if (sl != null && sl.Count == 2)
                    {
                        NewStudents.Add(new Student(student));
                    }
                }
            }
        }
        [RelayCommand]
        public void ShowNewStudents()
        {
            RightViewModel = new ClassListNewStudentRightViewModel(this);
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
            //ClassManagementViewModel.Instance.SetDetailClass(choosenClass.GetLopHocThuTe());
        }
        public void removeStudent(Hocsinh hocsinh)
        {
            ChoosenClass.removeStudent(hocsinh);
            NewStudents.Add(new Student(hocsinh));
        }
        [RelayCommand]
        private void addStudentToClass()
        {
            List<Student> selectedStudents = new List<Student>();
            if (ChoosenClass == null && NewStudents.IsNullOrEmpty() == true) return;
            foreach (var student in NewStudents)
            {
                if (student.IsSelected == true)
                {
                    if (selectedStudents.Count + ChoosenClass.Hocsinhs.Count < MaxStudentInClass )
                    {
                        selectedStudents.Add(student);
                    }
                    else student.IsSelected = false;

                }

            }
            if (selectedStudents.Count > 0) {
                ChoosenClass.saveAddStudent(selectedStudents);
                foreach(var st in selectedStudents)
                {
                    NewStudents.Remove(st);
                }
            }
            RightViewModel = new ClassListRightViewModel(this);
        }
    }
}
