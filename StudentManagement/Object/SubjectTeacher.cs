using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagement.Object
{
    public partial class SubjectTeacher : ObservableObject
    {
        [ObservableProperty]
        private String subject;
        [ObservableProperty]
        private ObservableCollection<String> teachers;

        public SubjectTeacher(String Subject, List<String> Teachers)
        {
            this.Subject = Subject;
            this.Teachers = new ObservableCollection<String>(Teachers);
        }
    }
}
