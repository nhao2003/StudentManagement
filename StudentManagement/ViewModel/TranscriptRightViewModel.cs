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
        private PointType selectedPointType; 
        [ObservableProperty]
        TranscriptConfig config;
        public TranscriptRightViewModel(TranscriptConfig config) 
        {
            this.config = config;
            selectedPointType = config.PointTypes[0];
        }
        [RelayCommand]
        private void updateData()
        {
            config.saveData2();
        }
        
        [RelayCommand]
        private void addNewSubPoint()
        {
            SelectedPointType.addSubPoint();
        }
    }
}
