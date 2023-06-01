using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using StudentManagement.Models;
using StudentManagement.ViewModel;
using System;
using System.Collections.Generic;
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

        private Lophocthucte lophtt;
        private List<Hocsinh> hocsinhs;
        public Class(Lophocthucte lopth)
        {
            id = lopth.Malop;
            name = lopth.MalopNavigation.Khoi + lopth.MalopNavigation.Tenlop;
            teacherName = lopth.MagvcnNavigation.Username;

            hocsinhs = lopth.Mahs.ToList();

            numOfStudent = int.Parse(DataProvider.ins.context.Thamsos.Where(e => e.Id == "TS005").ToList()[0].Giatri);
            numOfPresent = hocsinhs.Count;

            lophtt = lopth;

            ratio = Convert.ToInt32((numOfPresent / Convert.ToDouble(numOfStudent)) * 100);
        }


        public List<Hocsinh> GetHocSinhs()
        {
            return hocsinhs;
        }

        [RelayCommand]
        public void SetDetailClass()
        {
            ClassManagementViewModel.Instance.NavigateClassDetail(lophtt);
        }

        [RelayCommand]
        public void SetChoosenClass()
        {
            ClassListViewModel.Instance.SetChooseClass(this);
        }
    }
}
