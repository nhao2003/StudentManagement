using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using StudentManagement.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace StudentManagement.ViewModel
{
    public partial class TermSummaryViewModel : ObservableObject
    {
        [ObservableProperty]
        private ObservableCollection<Namhoc> yearList;
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
        private string selectedString;

        public TermSummaryViewModel()
        {
            QUANLYHOCSINHContext data = DataProvider.ins.context;
            TermList = new ObservableCollection<Hocky>(data.Hockies);
            YearList = new ObservableCollection<Namhoc>(data.Namhocs);
            SubjectList = new ObservableCollection<Monhoc>(data.Monhocs);
        }

        [RelayCommand]
        private void Summary()
        {
            if(SelectedTerm != null && SelectedSubject != null && SelectedYear != null)
            {
                MessageBox.Show(SelectedTerm.Tenhk + " " + SelectedYear.Tennamhoc + " " + SelectedSubject.Tenmh);
                SelectedString = $"{SelectedTerm.Tenhk} - Môn học: {SelectedSubject.Tenmh}";
            }
        }
    }
}
