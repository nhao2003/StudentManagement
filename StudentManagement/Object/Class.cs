using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using StudentManagement.Models;
using StudentManagement.Service;
using StudentManagement.ViewModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagement.Model
{
    public partial class Class : ObservableObject
    {
        [ObservableProperty]
        private String id;
        [ObservableProperty]
        private String name;
        [ObservableProperty]
        private String teacherName;
        [ObservableProperty]
        private int numOfStudent;
        [ObservableProperty]
        private int numOfPresent;
        [ObservableProperty]
        private int ratio;
        [ObservableProperty]
        private Lophocthucte lophtt;
        [ObservableProperty]
        private bool isCanDelete;
        [ObservableProperty]
        private ObservableCollection<Hocsinh> hocsinhs;
        public Class(Lophocthucte lopth)
        {
            id = lopth.Malop;
            name = lopth.MalopNavigation.Khoi + lopth.MalopNavigation.Tenlop;
            var teacher = lopth.MagvcnNavigation;
            if (teacher != null)
            {
                teacherName = teacher.UsernameNavigation.Hoten;
            }
            lophtt = lopth;
            var hocsinhList = lopth.Mahs.ToList();
            hocsinhs = new ObservableCollection<Hocsinh>(hocsinhList);
            var thamso = DataProvider.ins.context.Thamsos.Where(e => e.Id == "TS005").FirstOrDefault();
            if (thamso != null)
            {
                numOfStudent = int.Parse(thamso.Giatri);

            }
            else numOfStudent = 0;
            setRatio();
            CheckIsDelete();
        }
        private void setRatio()
        {
            NumOfPresent = Hocsinhs.Count;
            Ratio = Convert.ToInt32((NumOfPresent / Convert.ToDouble(NumOfStudent)) * 100);

        }

        //public ObservableCollection<Hocsinh> GetHocSinhs()
        //{
        //    return Hocsinhs;
        //}

        [RelayCommand]
        public void SetDetailClass()
        {
            ClassListViewModel.Instance.SetChooseClass(this);
            ClassManagementViewModel.Instance.NavigateClassDetail(lophtt);
        }

        [RelayCommand]
        public void SetChoosenClass()
        {
            ClassListViewModel.Instance.SetChooseClass(this);
        }
        public void saveAddStudent(List<Student> newStudentList)
        {
            foreach (var h in newStudentList)
            {
                Hocsinhs.Add(h.Hocsinh);
            }
            setRatio();
            Lophtt.Mahs = Hocsinhs;
            DataProvider.ins.context.Lophocthuctes.Update(Lophtt);
            DataProvider.ins.context.SaveChanges();
        }
        public Lophocthucte GetLopHocThuTe()
        {
            return lophtt;
        }
        private void CheckIsDelete()
        {
            if (Lophtt.Mahs != null && Lophtt.Mahs.Count > 0)
            {
                isCanDelete = false;
                return;
            }
            if (LoginServices.Instance.IsAdmin == false)
            {
                isCanDelete = false;
                return;
            }
            isCanDelete = true;
        }

        private void saveChanges()
        {
            Lophtt.Mahs = Hocsinhs;
            DataProvider.ins.context.Lophocthuctes.Update(Lophtt);
        }
        public void removeStudent(Hocsinh hocsinh)
        {
            if (Hocsinhs.Contains(hocsinh))
            {
                Hocsinhs.Remove(hocsinh);
                Lophtt.Mahs = Hocsinhs;
                DataProvider.ins.context.Lophocthuctes.Update(Lophtt);
                DataProvider.ins.context.SaveChanges();
            }
            setRatio();
            CheckIsDelete();
        }

    }
}