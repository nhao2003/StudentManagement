using CommunityToolkit.Mvvm.ComponentModel;
using StudentManagement.Object;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagement.ViewModel
{
    public partial class TranscriptViewModel : ObservableObject
    {
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
            new TranscriptConfig("001", "John Doe", "7", "8", "9", "10"),
            new TranscriptConfig("002", "Jane Smith", "4", "6", "7", "8"),
            new TranscriptConfig("003", "Bob Johnson", "9", "10", "10", "9"),
            new TranscriptConfig("004", "Samantha Lee", "2", "3", "5", "6"),
            new TranscriptConfig("005", "James Smith", "3", "5", "2", "7"),
            new TranscriptConfig("006", "Emily Nguyen", "1", "9", "8", "3"),
            new TranscriptConfig("007", "Michael Brown", "6", "8", "7", "9"),
            new TranscriptConfig("008", "Avery Martinez", "4", "4", "1", "6"),
            new TranscriptConfig("009", "Ella Davis", "9", "10", "10", "9"),
            new TranscriptConfig("010", "William Johnson", "3", "2", "4", "7"),
            new TranscriptConfig("011", "Olivia Jones", "5", "6", "7", "8"),
            new TranscriptConfig("012", "Benjamin Lee", "8", "9", "7", "10"),
            new TranscriptConfig("013", "Sophia Wilson", "9", "9", "10", "8"),
            new TranscriptConfig("014", "Ethan Kim", "6", "4", "2", "9")
        };

    }
}
