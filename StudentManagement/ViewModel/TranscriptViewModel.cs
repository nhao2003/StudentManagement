using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
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
    public partial class TranscriptViewModel : ObservableObject
    {
        [ObservableProperty]
        private bool isReadOnly = true;
        [ObservableProperty]
        private ObservableCollection<string> subjectList = new ObservableCollection<string>()
        {
            "Toán", "Lý", "Hóa", "Sinh", "Sử"
        };
        [ObservableProperty]
        private ObservableCollection<string> termList = new ObservableCollection<string>()
        {
            "Học kỳ 1", "Học kỳ 2"
        };

        [ObservableProperty]
        ObservableCollection<TranscriptConfig> transcripts = new ObservableCollection<TranscriptConfig>
        {
            new TranscriptConfig("001", "John Doe", "7", "7", "8", "10"),
            new TranscriptConfig("002", "Jane Smith", "7", "4", "6",  "8"),
            new TranscriptConfig("003", "Bob Johnson", "7", "9", "10", "9"),
            new TranscriptConfig("004", "Samantha Lee", "7", "3", "5", "6"),
            new TranscriptConfig("005", "James Smith", "7", "5", "2", "7"),
            new TranscriptConfig("006", "Emily Nguyen", "7", "9", "8", "3"),
            new TranscriptConfig("007", "Michael Brown",  "7", "8", "7", "9"),
            new TranscriptConfig("008", "Avery Martinez",  "7", "4", "1", "6"),
            new TranscriptConfig("009", "Ella Davis", "7", "9", "10", "10"),
            new TranscriptConfig("010", "William Johnson", "7", "3","4", "7"),
            new TranscriptConfig("011", "Olivia Jones", "7", "5", "7", "8"),
            new TranscriptConfig("012", "Benjamin Lee", "7", "8", "7", "10"),
            new TranscriptConfig("013", "Sophia Wilson", "7", "9", "10", "8"),
            new TranscriptConfig("014", "Ethan Kim", "7", "6", "4", "9")
        };
        [ObservableProperty]
        private Visibility editBtnVisibility = Visibility.Visible;
        [ObservableProperty]
        private Visibility cancelBtnVisibility = Visibility.Hidden;

        [RelayCommand]
        private void CancelEditting()
        {
            IsReadOnly = true;
            EditBtnVisibility = Visibility.Visible;

            CancelBtnVisibility = Visibility.Hidden;
        }

        [RelayCommand]
        private void EnableEditting()
        {
            IsReadOnly = false;
            EditBtnVisibility = Visibility.Hidden;
            CancelBtnVisibility = Visibility.Visible;
        }

        [RelayCommand]
        private void BackToPrevScreen()
        {
            ClassManagementViewModel.Instance.NavigateClassList();
        }
    }
}
