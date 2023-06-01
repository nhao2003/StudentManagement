using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
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
            lops = DataProvider.ins.context.Lophocthuctes.ToList();
            hocsinhs = DataProvider.ins.context.Hocsinhs.ToList();

            foreach (var lop in lops)
            {
                classes.Add(new Class(lop));
            }
            foreach (var hs in hocsinhs)
            {
                newStudents.Add(new Student(hs));
            }
        }

        List<Lophocthucte> lops = new List<Lophocthucte>();

        List<Hocsinh> hocsinhs = new List<Hocsinh>();
        [ObservableProperty]
        private ObservableCollection<Class> classes = new ObservableCollection<Class>()
        {
        };

        [ObservableProperty]
        private ObservableCollection<Student> students = new ObservableCollection<Student>()
        {
        };

        [ObservableProperty]
        private ObservableCollection<Student> newStudents = new ObservableCollection<Student>()
        {
        };

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

    }
}
