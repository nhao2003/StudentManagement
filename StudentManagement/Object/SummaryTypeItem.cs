using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagement.Object
{
    public enum SummaryType
    {
        SubjectSummary,
        TermSummary,
        YearSummary
    }

    public partial class SummaryTypeItem : ObservableObject
    {
        [ObservableProperty]
        private SummaryType type;
        [ObservableProperty]
        private string summaryName;
        public SummaryTypeItem(SummaryType Type, string SummaryName)
        {
            this.Type = Type;
            this.SummaryName = SummaryName;
        }
    }
}
