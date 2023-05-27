using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace StudentManagement.ViewModel;

public sealed partial class AddSchoolYearInfomationViewModel : ObservableObject
{
    public AddSchoolYearInfomationViewModel()
    {

        goToClassListCM = new RelayCommand(SchoolYearViewModel.Ins.goToClassList);
    }

    public ICommand goToClassListCM { get; set; }
    
}