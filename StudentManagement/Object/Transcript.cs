using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagement.Object
{
    public partial class TranscriptConfig : ObservableObject
    {
        [ObservableProperty]
        private string id;
        [ObservableProperty]
        private string name;
        [ObservableProperty]
        private string fifteenMin;
        [ObservableProperty]
        private string fortyMin;
        [ObservableProperty]
        private string finalExam;

        public TranscriptConfig(string Id, string Name, string FifteenMin, string FortyMin, string FinalExam)
        {
            this.Id = Id;
            this.Name = Name;
            this.FifteenMin = FifteenMin;
            this.FortyMin = FortyMin;
            this.FinalExam = FinalExam;
        }
    }
}
