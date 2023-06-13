using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using StudentManagement.Models;
using StudentManagement.Object;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace StudentManagement.ViewModel
{
    public partial class TermSummaryViewModel : ObservableObject
    {
        [ObservableProperty]
        private Visibility termVisibility = Visibility.Visible;
        [ObservableProperty]
        private Visibility subjectVisibility = Visibility.Visible;
        [ObservableProperty]
        private Visibility classVisibility = Visibility.Visible;
        [ObservableProperty]
        private ObservableCollection<SummaryTypeItem> summaryTypeItems;
        [ObservableProperty]
        private Lophocthucte selectedLhtt;
        [ObservableProperty]
        private ObservableCollection<Lophocthucte> classList;
        [ObservableProperty]
        private SummaryTypeItem selectedType;
        [ObservableProperty]
        private ObservableCollection<Namhoc> yearList;
        [ObservableProperty]
        private OverviewListViewModel overview;
        [ObservableProperty]
        private ObservableCollection<Hocky> termList;
        [ObservableProperty]
        private ObservableCollection<Monhoc> subjectList;
        private Namhoc SelectedYear;
        [ObservableProperty]
        private Hocky selectedTerm;
        [ObservableProperty]
        private Monhoc selectedSubject;
        [ObservableProperty]
        private string summaryString;
        [ObservableProperty]
        private string classString;
        [ObservableProperty]
        private TermSummaryItem selectedClass;
        [ObservableProperty]
        private ObservableCollection<TermSummaryItem> termSummaryItems = new ObservableCollection<TermSummaryItem>();
        [ObservableProperty]
        private ObservableCollection<ClassDetailsSummaryItem> classDetailsSummaryItems = new ObservableCollection<ClassDetailsSummaryItem>();
        QUANLYHOCSINHContext data = DataProvider.ins.context;
        [ObservableProperty]
        object content;

        public TermSummaryViewModel()
        {
            TermList = new ObservableCollection<Hocky>(data.Hockies);
            YearList = new ObservableCollection<Namhoc>(data.Namhocs);
            SubjectList = new ObservableCollection<Monhoc>(data.Monhocs);
            Overview = new OverviewListViewModel();
            SummaryTypeItems = new ObservableCollection<SummaryTypeItem>()
            {
                new SummaryTypeItem(SummaryType.SubjectSummary, "Báo cáo tổng kết môn"),
                new SummaryTypeItem(SummaryType.TermSummary, "Báo cáo tổng kết học kỳ"),
                new SummaryTypeItem(SummaryType.TermClassification, "Báo cáo xếp loại học sinh học kỳ"),
                new SummaryTypeItem(SummaryType.YearClassification, "Báo cáo xếp loại học sinh năm học"),
            };
            Content = this;
        }
        [RelayCommand]
        private void SelectedTypeChanged()
        {
            if (SelectedType == null)
                return;
            switch (SelectedType.Type)
            {
                case SummaryType.SubjectSummary:
                    Content = this;
                    TermVisibility = Visibility.Visible;
                    SubjectVisibility = Visibility.Visible;
                    ClassVisibility = Visibility.Collapsed;
                    break;
                case SummaryType.TermSummary:
                    Content = this;
                    TermVisibility = Visibility.Visible;
                    ClassVisibility = Visibility.Collapsed;
                    SubjectVisibility = Visibility.Collapsed;
                    break;
                case SummaryType.TermClassification:
                    SelectedYear = OverviewListViewModel.GetNamhoc;
                    if (SelectedYear == null)
                    {
                        MessageBox.Show("Vui lòng chọn năm học");
                        SelectedType = null;
                        return;
                    }
                    else
                    {
                        ClassList = new ObservableCollection<Lophocthucte>(DataProvider.ins.context.Lophocthuctes.ToList());
                    }
                    SubjectVisibility = Visibility.Collapsed;
                    ClassVisibility = Visibility.Visible;
                    TermVisibility = Visibility.Visible;
                    break;
                case SummaryType.YearClassification:
                    SelectedYear = OverviewListViewModel.GetNamhoc;
                    if (SelectedYear == null)
                    {
                        MessageBox.Show("Vui lòng chọn năm học");
                        SelectedType = null;
                        return;
                    }
                    else
                    {
                        ClassList = new ObservableCollection<Lophocthucte>(DataProvider.ins.context.Lophocthuctes.ToList());
                    }
                    SubjectVisibility = Visibility.Collapsed;
                    ClassVisibility = Visibility.Visible;
                    TermVisibility = Visibility.Collapsed;
                    break;

            }
        }
        [RelayCommand]
        private void ShowClassDetails()
        {
            ClassDetailsSummaryItems.Clear();
            if (SelectedClass != null)
            {
                ClassString = $"Lớp: {SelectedClass.TenLop} - {SummaryString}";
                List<Hocsinh> hocsinhs = SelectedClass.Lophtt.Mahs.ToList();
                int stt = 1;
                foreach (var hocsinh in hocsinhs)
                {
                    ClassDetailsSummaryItem item = new ClassDetailsSummaryItem();
                    if (SelectedType.Type == SummaryType.SubjectSummary)
                    {
                        item = new ClassDetailsSummaryItem(stt, hocsinh, SelectedYear.Manh, selectedTerm.Mahk, SelectedSubject.Mamh);
                    }
                    else if (SelectedType.Type == SummaryType.TermSummary)
                    {
                        item = new ClassDetailsSummaryItem(stt, hocsinh, SelectedYear.Manh, selectedTerm.Mahk);
                    }
                    ClassDetailsSummaryItems.Add(item);
                    stt++;
                }

                var sortedList = ClassDetailsSummaryItems.OrderByDescending(s => s.DiemTB).ToList();

                for (int i = 0; i < sortedList.Count; i++)
                {
                    sortedList[i].Hang = i + 1;
                }

                ClassDetailsSummaryItems = new ObservableCollection<ClassDetailsSummaryItem>(sortedList.OrderBy(s => s.Stt));

            }
            else
            {
                ClassString = "";
            }
        }

        [RelayCommand]
        private void Summary()
        {
            SelectedYear = OverviewListViewModel.GetNamhoc;
            if (SelectedType == null)
            {
                MessageBox.Show("Vui lòng chọn loại tổng kết");
            }
            else
            {
                switch (SelectedType.Type)
                {
                    case SummaryType.SubjectSummary:
                        SubjectSummary();
                        break;
                    case SummaryType.TermSummary:
                        TermSummary();
                        break;
                    case SummaryType.TermClassification:
                        TermClassification();
                        break;
                    case SummaryType.YearClassification:
                        YearClassification();
                        break;
                }
            }
        }
        private void TermClassification()
        {
            if (SelectedYear == null)
            {
                MessageBox.Show("Vui lòng chọn năm học");
                return;
            }
            if (SelectedTerm == null)
            {
                MessageBox.Show("Vui lòng chọn kỳ học");
                return;
            }
            if (SelectedLhtt == null)
            {
                MessageBox.Show("Vui lòng chọn lớp");
                return;
            }
            Content = new StudentClassificationViewModel(SelectedType, SelectedYear, SelectedTerm, SelectedLhtt);

        }
        private void YearClassification()
        {
            if (SelectedYear == null)
            {
                MessageBox.Show("Vui lòng chọn năm học");
                return;
            }

            if (SelectedLhtt == null)
            {
                MessageBox.Show("Vui lòng chọn lớp");
                return;
            }
            Content = new StudentClassificationViewModel(SelectedType, SelectedYear, SelectedLhtt);

        }
        private void TermSummary()
        {
            if (SelectedYear == null)
            {
                MessageBox.Show("Vui lòng chọn năm học");
                return;
            }
            if (SelectedTerm == null)
            {
                MessageBox.Show("Vui lòng chọn kỳ học");
                return;
            }

            TermSummaryItems.Clear();
            MessageBox.Show(SelectedTerm.Tenhk + " " + SelectedYear.Tennamhoc);
            SummaryString = $"{SelectedTerm.Tenhk}";
            List<Lophocthucte> lophocthuctes = data.Lophocthuctes.Where(x => x.Manh == SelectedYear.Manh).ToList();
            int i = 1;
            foreach (var lophoc in lophocthuctes)
            {
                TermSummaryItems.Add(new TermSummaryItem(i, lophoc, SelectedYear.Manh, selectedTerm.Mahk));
                i++;
            }
        }
        private void SubjectSummary()
        {
            if (SelectedYear == null)
            {
                MessageBox.Show("Vui lòng chọn năm học");
                return;
            }
            if (SelectedTerm == null)
            {
                MessageBox.Show("Vui lòng chọn kỳ học");
                return;
            }
            if (SelectedSubject == null)
            {
                MessageBox.Show("Vui lòng chọn môn học");
                return;
            }

            TermSummaryItems.Clear();
            MessageBox.Show(SelectedTerm.Tenhk + " " + SelectedYear.Tennamhoc + " " + SelectedSubject.Tenmh);
            SummaryString = $"{SelectedTerm.Tenhk} - Môn học: {SelectedSubject.Tenmh}";
            List<Lophocthucte> lophocthuctes = data.Lophocthuctes.Where(x => x.Manh == SelectedYear.Manh).ToList();
            int i = 1;
            foreach (var lophoc in lophocthuctes)
            {
                TermSummaryItems.Add(new TermSummaryItem(i, lophoc, SelectedYear.Manh, selectedTerm.Mahk, selectedSubject.Mamh));
                i++;
            }
        }
    }
}