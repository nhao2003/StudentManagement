using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using StudentManagement.Models;
using StudentManagement.Object;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace StudentManagement.ViewModel
{
    public partial class ClassListDetailsViewModel : ObservableObject
    {
        [ObservableProperty]
        private ObservableCollection<ClassListData> classListDatas = new ObservableCollection<ClassListData>();

        [ObservableProperty]
        private ClassDetailsViewModel classDetails = new ClassDetailsViewModel();

        [ObservableProperty]
        ClassListData selectedItem;


        public ClassListDetailsViewModel()
        {
            DataProvider data = DataProvider.ins;
            int stt = 1;
            List<Lophocthucte> lophocthuctes = data.context.Lophocthuctes.ToList();
            foreach (var lophoctt in lophocthuctes)
            {
                String gvcn = data.context.Giaoviens.Where(x => x.Magv == lophoctt.Magvcn).FirstOrDefault().UsernameNavigation.Hoten;
                ClassListData classListData = new ClassListData(stt, lophoctt.MalopNavigation.Khoi.Value, lophoctt.MalopNavigation.Tenlop, gvcn, lophoctt.Mahs.Count(), lophoctt);
                classListDatas.Add(classListData);
                stt++;
            }
        }
        [RelayCommand]
        private void ShowClassDetails()
        {
            ClassDetails = new ClassDetailsViewModel(selectedItem.lophocthucte);
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
