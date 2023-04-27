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
        private string fifteenMin1;
        [ObservableProperty]
        private string fifteenMin2;
        [ObservableProperty]
        private string fortyMin;
        [ObservableProperty]
        private string finalExam;

        public TranscriptConfig(string Id, string Name, string FifteenMin1, string FifteenMin2, string FortyMin, string FinalExam)
        {
            this.Id = Id;
            this.Name = Name;
            this.FifteenMin1 = FifteenMin1;
            this.FifteenMin2 = FifteenMin2;
            this.FortyMin = FortyMin;
            this.FinalExam = FinalExam;
        }
    }
}
