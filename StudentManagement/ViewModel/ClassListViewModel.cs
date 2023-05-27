using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
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
        }

        [ObservableProperty]
        private ObservableCollection<Class> classes = new ObservableCollection<Class>()
        {
            new Class("1","10A1", "Phan Văn Minh", 30, 40),
            new Class("2","10A2", "Nguyễn Nhật Hào", 40, 45),
            new Class("3","10A3", "Nguyễn Tiến Anh", 35, 40),
            new Class("4","10A4", "Lê Phan Hiển", 35, 45),
            new Class("5","10A5", "Nguyễn Trung Kiên", 45, 45),
            new Class("6","10A6", "Phan Văn Minh", 35, 40),
        };
        [ObservableProperty]
        private ObservableCollection<Student> students = new ObservableCollection<Student>()
        {
            new Student("1", "Phan Văn Minh", "/Resource/images/student.png"),
            new Student("2", "Nguyễn Nhật Hào", "/Resource/images/student1.png"),
            new Student("3", "Nguyễn Tiến Anh", "/Resource/images/student.png"),
            new Student("4", "Lê Phan Hiển", "/Resource/images/student1.png"),
            new Student("5", "Nguyễn Trung Kiên", "/Resource/images/student.png"),
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
        }

    }
}
