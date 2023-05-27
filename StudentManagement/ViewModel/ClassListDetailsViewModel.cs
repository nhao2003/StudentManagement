using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace StudentManagement.ViewModel
{
    public partial class ClassListDetailsViewModel : ObservableObject
    {
        [RelayCommand]
        private void AddClass()
        {
            AddNewClass addNewClass = new AddNewClass();
            addNewClass.ShowDialog();
        }
    }
}
