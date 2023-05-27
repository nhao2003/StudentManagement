using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace StudentManagement.ViewModel;

public partial class SchoolYearViewModel : ObservableObject
{
    public SchoolYearViewModel() {
        Ins = this;
        Init();
    }
    private static SchoolYearViewModel _ins;
    public static SchoolYearViewModel Ins
    {
        get => _ins == null ? (_ins = new SchoolYearViewModel()) : _ins;
        private set => _ins = value;

    }
    private object _addSchoolYearInfoViewModel;
    private object _addStudentToClassViewModel;
    private object contentViewModel;
    public object ContentViewModel
    {
        get { return contentViewModel; }
        private set
        {
            contentViewModel = value;
            OnPropertyChanged();
        }
    }

    private void Init()
    {
        _addSchoolYearInfoViewModel = new AddSchoolYearInfomationViewModel();
        _addStudentToClassViewModel = new AddStudentToClassViewModel();
        ContentViewModel = _addSchoolYearInfoViewModel;

    }
    public void setViewModel(object viewModel)
    {
        ContentViewModel = viewModel;
    }
    public void goToClassList()
    {
        setViewModel(_addStudentToClassViewModel);    
    }
}