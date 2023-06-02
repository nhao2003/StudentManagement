using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;
using CommunityToolkit.Mvvm.Messaging.Messages;
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
    public partial class TermSummaryViewModel : ObservableRecipient, IRecipient<PropertyChangedMessage<bool>>
    {
        [ObservableProperty]
        private ObservableCollection<Namhoc> yearList;
        [ObservableProperty]
        private OverviewListViewModel overview;
        [ObservableProperty]
        private ObservableCollection<Hocky> termList;
        [ObservableProperty]
        private ObservableCollection<Monhoc> subjectList;
        [ObservableProperty]
        private Namhoc selectedYear;
        [ObservableProperty]
        private Hocky selectedTerm;
        [ObservableProperty]
        private Monhoc selectedSubject;
        [ObservableProperty]
        private string summaryString;
        [ObservableProperty]
        private string classString;
        [ObservableProperty]
        private TermSubjectSummaryData selectedClass;
        [ObservableProperty]
        private ObservableCollection<TermSubjectSummaryData> termSubjectSummaryDatas = new ObservableCollection<TermSubjectSummaryData>();
        [ObservableProperty]
        private ObservableCollection<ClassSubjectSummaryData> classSubjectSummaries = new ObservableCollection<ClassSubjectSummaryData>();
        QUANLYHOCSINHContext data = DataProvider.ins.context;
        [ObservableProperty]
        private bool isAllItemsSelected;

        [RelayCommand]
        private void AllItemsSelected()
        {
            foreach(var item in TermSubjectSummaryDatas)
            {
                item.Selected = IsAllItemsSelected;
            }
        }

        public TermSummaryViewModel()
        {
            WeakReferenceMessenger.Default.Register<PropertyChangedMessage<bool>>(this);
            TermList = new ObservableCollection<Hocky>(data.Hockies);
            YearList = new ObservableCollection<Namhoc>(data.Namhocs);
            SubjectList = new ObservableCollection<Monhoc>(data.Monhocs);
            Overview = new OverviewListViewModel();
        }
        [RelayCommand]
        private void ShowClassDetails()
        {
            ClassSubjectSummaries.Clear();
            if (SelectedClass != null)
            {
                ClassString = $"Lớp: {SelectedClass.TenLop} - {SummaryString}";
                List<Hocsinh> hocsinhs = SelectedClass.Lophtt.Mahs.ToList();
                int stt = 1;
                foreach(var hocsinh in hocsinhs)
                {
                    ClassSubjectSummaries.Add(new ClassSubjectSummaryData(stt,hocsinh,SelectedYear.Manh,selectedTerm.Mahk,SelectedSubject.Mamh));
                    stt++;
                }

                var sortedList = ClassSubjectSummaries.OrderByDescending(s => s.DiemTB).ToList();

                for (int i = 0; i < sortedList.Count; i++)
                {
                    sortedList[i].Hang = i + 1;
                }

                ClassSubjectSummaries = new ObservableCollection<ClassSubjectSummaryData>(sortedList.OrderBy(s => s.Stt));

            }
            else
            { 
                ClassString = "";
            }
        }

        [RelayCommand]
        private void Summary()
        {
            if(SelectedTerm != null && SelectedSubject != null && SelectedYear != null)
            {
                TermSubjectSummaryDatas.Clear();
                MessageBox.Show(SelectedTerm.Tenhk + " " + SelectedYear.Tennamhoc + " " + SelectedSubject.Tenmh);
                SummaryString = $"{SelectedTerm.Tenhk} - Môn học: {SelectedSubject.Tenmh}";
                List<Lophocthucte> lophocthuctes = data.Lophocthuctes.Where(x => x.Manh == SelectedYear.Manh).ToList();
                int i = 1;
                foreach(var lophoc in lophocthuctes)
                {   
                    TermSubjectSummaryDatas.Add(new TermSubjectSummaryData(i, lophoc,SelectedYear.Manh,selectedTerm.Mahk,selectedSubject.Mamh));
                    i++;
                }
            }
        }

        public void Receive(PropertyChangedMessage<bool> message)
        {
            if(message.NewValue == false)
            {
                IsAllItemsSelected = false;
            }
            else
            {
                var items = TermSubjectSummaryDatas.Where(x => x.Selected == true);
                if(items.Count() == TermSubjectSummaryDatas.Count())
                {
                    IsAllItemsSelected=true;
                }
            }
        }
    }
}
