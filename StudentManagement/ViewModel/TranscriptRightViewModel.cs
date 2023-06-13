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
    public partial class TranscriptRightViewModel: ObservableObject
    {
        [ObservableProperty]
        TranscriptConfig config;
        public TranscriptRightViewModel(TranscriptConfig config) 
        {
            this.config = config;
        }
        [RelayCommand]
        private void updateData()
        {
            config.saveData();
        }
    }
}
