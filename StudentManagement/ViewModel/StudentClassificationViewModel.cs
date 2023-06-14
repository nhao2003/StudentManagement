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
        [ObservableProperty]
        private string summaryString;

        private string Manh;
        private string Mahk;
        private string Malhtt;
        public StudentClassificationViewModel()
        {

        }
        public StudentClassificationViewModel(SummaryTypeItem type, Namhoc nh, Hocky hk, Lophocthucte lhtt)
        {
            this.Manh = nh.Manh;
            this.Mahk = hk.Mahk;
            this.Malhtt = lhtt.Malhtt;
            SelectedType = type;
            List<Hocsinh> hocsinhs = DataProvider.ins.context.Lophocthuctes.Where(x => x.Malhtt == Malhtt).FirstOrDefault().Mahs.ToList();
            int stt = 1;
            foreach(Hocsinh hocsinh in hocsinhs)
            {
                StudentClassificationItem item = new StudentClassificationItem(stt, hocsinh, Manh, Mahk);
                if(item.Stt != 0)
                {
                    ClassificationItems.Add(item);
                    stt++;
                }
            }
            SummaryString = $"{nh.Tennamhoc} - {hk.Tenhk} - {lhtt.MalopNavigation.Khoi}{lhtt.MalopNavigation.Tenlop}, {ClassificationItems.Count}/{hocsinhs.Count}";
        }
        public StudentClassificationViewModel(SummaryTypeItem type, Namhoc nh, Lophocthucte lhtt)
        {
            this.Manh = nh.Manh;
            this.Malhtt = lhtt.Malhtt;
            SelectedType = type;
            List<Hocsinh> hocsinhs = DataProvider.ins.context.Lophocthuctes.Where(x => x.Malhtt == Malhtt).FirstOrDefault().Mahs.ToList();
            int stt = 1;

            foreach (Hocsinh hocsinh in hocsinhs)
            {
                StudentClassificationItem item = new StudentClassificationItem(stt, hocsinh, Manh);
                if (item.Stt != 0)
                {
                    ClassificationItems.Add(item);
                    stt++;
                }
            }
            SummaryString = $"{nh.Tennamhoc} - {lhtt.MalopNavigation.Khoi}{lhtt.MalopNavigation.Tenlop}, {ClassificationItems.Count}/{hocsinhs.Count}";
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
                    if(SelectedType.Type == SummaryType.TermClassification)
                        AvgSubjects.Add(new AvgSubject(SelectedStudent.Hs, Manh, Mahk, monhoc.Mamh));
                    else
                        AvgSubjects.Add(new AvgSubject(SelectedStudent.Hs, Manh, monhoc.Mamh));

                }
            }
        }
    }
}
