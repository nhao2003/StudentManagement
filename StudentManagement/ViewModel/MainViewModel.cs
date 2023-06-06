using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using StudentManagement.Models;
using StudentManagement.Object;
using System.Collections.ObjectModel;
using System.Windows;

namespace StudentManagement.ViewModel;

public sealed partial class MainViewModel : ObservableObject
{

    public MainViewModel()
    {
        Init();
        ContentViewModel = _programViewModel;
        Instance = this;
    }

    #region property

    private object _programViewModel;
    private object _studentViewModel;
    private object _teacherViewModel;
    private object _classListViewModel;
    private object _transcriptViewModel;
    private object _classconfigViewModel;
    private object _classDetailViewModel;
    private object _classManaViewModel;

    private object _subjectViewModel;
    private object _schoolyearViewModel;
    private object _classListDetailsViewModel;
    [ObservableProperty]
    public ObservableCollection<Navigation> leftNavigations;
    private static MainViewModel s_instance;
    public static MainViewModel Instance
    {
        get => s_instance == null ? (s_instance = new MainViewModel()) : s_instance;
        private set => s_instance = value;
    }

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
    #endregion
    private void Init()
    {

        _programViewModel = new ProgramViewModel();
        _studentViewModel = new StudentViewModel();
        _teacherViewModel = new TeacherViewModel();
        _classListViewModel = new ClassListViewModel();
        _classManaViewModel = new ClassManagementViewModel();
        leftNavigations = new ObservableCollection<Navigation>()
    {
        new Navigation("Trang chủ", "home", _programViewModel),
        new Navigation("Thông tin", "infomation", _classListDetailsViewModel),
        new Navigation("Môn học", "subject", _classListViewModel),
        new Navigation("Thông tin", "infomation", _classListViewModel),
        new Navigation("Môn học", "subject", _classManaViewModel),
    };
        leftNavigations[0].IsPress = true;
    }

    public void setViewModel(object viewModel)
    {
        ContentViewModel = viewModel;
    }

    [RelayCommand]
    private void CloseWindow()
    {
        Application.Current.Shutdown();
    }
    [RelayCommand]
    private void HideWindow()
    {
        Window window = Application.Current.MainWindow as Window;
        window.WindowState = WindowState.Minimized;
    }
}

