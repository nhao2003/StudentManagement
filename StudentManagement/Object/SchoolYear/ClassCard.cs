using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using StudentManagement.Model;
using StudentManagement.Models;
using StudentManagement.ViewModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace StudentManagement.Object.SchoolYear
{
    public partial class ClassCard : ObservableObject
    {
        public ClassCard(Lop lop, ObservableCollection<StudentWithClassItem> studentWithClassItems, AddStudentToClassViewModel parent)
        {
            this.lop = lop;
            this.StudentInClassDisplay = studentWithClassItems;
            this.parent = parent;
        }


        private AddStudentToClassViewModel parent;
        [ObservableProperty]
        private Lop lop;
        public ObservableCollection<StudentWithClassItem> StudentInClassDisplay { get; set; }
        [RelayCommand]
        private void onClick()
        {
            parent.setCurrentClass(this);
        }
        public void AddStudent(StudentWithClassItem student)
        {
            StudentInClassDisplay.Add(student);
            OnPropertyChanged(nameof(StudentInClassDisplay));
        }
        [RelayCommand]
        private void deleteStudent()
        {
            ObservableCollection<StudentWithClassItem> studentInClassDisplayTemp = new ObservableCollection<StudentWithClassItem>(StudentInClassDisplay);
            foreach (var student in StudentInClassDisplay)
            {
                if (student.getSelected() == true)
                {
                    student.setSelected();
                    studentInClassDisplayTemp.Remove(student);
                    parent.addStudentToEmptyClass(student);
                }
            }
            StudentInClassDisplay = new ObservableCollection<StudentWithClassItem>(studentInClassDisplayTemp);
            OnPropertyChanged($"{nameof(StudentInClassDisplay)}");
        }
        // lh212211a1
        Random ran = new Random(10000000);
      
        public Lophocthucte getLopHocThucTe(Namhoc namhoc)
        {
            Lophocthucte lophocthucte = new Lophocthucte();
            lophocthucte.Malop = lop.Malop;
            List<Hocsinh> hocsinh = new List<Hocsinh>();
            foreach (var student in StudentInClassDisplay)
            {
                hocsinh.Add(student.GetHocsinh());
            }
            lophocthucte.Manh = namhoc.Manh;
            lophocthucte.Isdeleted = false;
            lophocthucte.Malhtt = namhoc.Manh + lop.Malop;
            lophocthucte.Mahs = hocsinh;
            return lophocthucte;
        }

    }

}
