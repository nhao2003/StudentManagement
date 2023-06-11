using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using StudentManagement.Models;
using StudentManagement.Object;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace StudentManagement.ViewModel
{
    public partial class ClassListDetailsViewModel : ObservableObject
    {
        [ObservableProperty]
        private OverviewListViewModel overview;

        [ObservableProperty]
        private ObservableCollection<ClassListData> classListDatas = new ObservableCollection<ClassListData>();

        [ObservableProperty]
        private ClassDetailsViewModel classDetails = new ClassDetailsViewModel();

        [ObservableProperty]
        ClassListData selectedItem;


        public ClassListDetailsViewModel()
        {
            Overview = new OverviewListViewModel();
            DataProvider data = DataProvider.ins;
            int stt = 1;
            List<Lophocthucte> lophocthuctes = data.context.Lophocthuctes.ToList();
            foreach (var lophoctt in lophocthuctes)
            {
                Giaovien? gv = data.context.Giaoviens.Where(x => x.Magv == lophoctt.Magvcn).FirstOrDefault();
                String gvcn = "";
                if(gv!= null)
                {
                    gvcn = gv.UsernameNavigation.Hoten;
                }
                ClassListData classListData = new ClassListData(stt, lophoctt.MalopNavigation.Khoi.Value, lophoctt.MalopNavigation.Tenlop, gvcn, lophoctt.Mahs.Count(), lophoctt);
                classListDatas.Add(classListData);
                stt++;
            }
        }
        [RelayCommand]
        private void ShowClassDetails()
        {
            ClassDetails = new ClassDetailsViewModel(selectedItem.Lophtt);
        }
        [RelayCommand]
        private void ChangeVisi()
        {
        }
        [RelayCommand]
        private void AddClass()
        {
            AddNewClass addNewClass = new AddNewClass();
            addNewClass.ShowDialog();
        }
    }
}
