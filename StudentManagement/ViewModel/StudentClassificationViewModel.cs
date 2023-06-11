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

namespace StudentManagement.ViewModel
{
    public partial class StudentClassificationViewModel : ObservableObject
    {
        [ObservableProperty]
        private SummaryTypeItem selectedType;
        [ObservableProperty]
        private StudentClassificationItem selectedStudent;
        [ObservableProperty]
        private ObservableCollection<StudentClassificationItem> classificationItems = new ObservableCollection<StudentClassificationItem>();
        [ObservableProperty]
        private ObservableCollection<AvgSubject> avgSubjects = new ObservableCollection<AvgSubject>();

        private string Manh;
        private string Mahk;
        public StudentClassificationViewModel()
        {

        }
        public StudentClassificationViewModel(SummaryTypeItem type, String Manh, String Mahk, String Malhtt)
        {
            this.Manh = Manh;
            this.Mahk = Mahk;
            SelectedType = type;
            List<Hocsinh> hocsinhs = DataProvider.ins.context.Lophocthuctes.Where(x => x.Malhtt == Malhtt).FirstOrDefault().Mahs.ToList();
            int stt = 1;
            foreach(Hocsinh hocsinh in hocsinhs)
            {
                ClassificationItems.Add(new StudentClassificationItem(stt,hocsinh,Manh,Mahk));
                stt++;
            }
        }
        [RelayCommand]
        private void ShowStudenDetails()
        {
            AvgSubjects.Clear();
            if(SelectedStudent != null)
            {
                List<Monhoc> monhocs = DataProvider.ins.context.Monhocs.ToList();
                foreach(Monhoc monhoc in monhocs)
                {
                    AvgSubjects.Add(new AvgSubject(SelectedStudent.Hs, Manh, Mahk, monhoc.Mamh));
                }
            }
        }
    }
}
