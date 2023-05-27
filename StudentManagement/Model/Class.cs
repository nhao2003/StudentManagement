using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
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

        public Class(string id, string name, string teacherName, int numOfPresent, int numOfStudent)
        {
            this.id = id;
            this.name = name;
            this.teacherName = teacherName;
            this.numOfStudent = numOfStudent;
            this.numOfPresent = numOfPresent;

            ratio = Convert.ToInt32((numOfPresent / Convert.ToDouble(numOfStudent)) * 100);
        }

        [RelayCommand]
        public void SetDetailClass()
        {
            ClassManagementViewModel.Instance.NavigateClassDetail(this);
        }

        [RelayCommand]
        public void SetChoosenClass()
        {
            ClassListViewModel.Instance.SetChooseClass(this);
        }
    }
}
