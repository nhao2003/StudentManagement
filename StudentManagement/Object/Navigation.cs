using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using StudentManagement.ViewModel;
using System.Collections.ObjectModel;

namespace StudentManagement.Object;

public partial class Navigation : ObservableObject
{
    public string NavigationHeader { get; set; }
    public string Icon { get; set; }
    private object NavigationItemViewModel { get; set; }
    public MainViewModel MainViewModel { get; set; }
    private bool isPress;
    public bool IsPress
    {
        get { return isPress; }
        set { isPress = value; OnPropertyChanged(); }
    }
    public Navigation(string navigationheader, string icon, object navigationItemViewModel)
    {
        NavigationHeader = navigationheader;
        Icon = icon;
        NavigationItemViewModel = navigationItemViewModel;
    }
    [RelayCommand]
    private void CreateView()
    {
        ObservableCollection<Navigation> navigationItems = MainViewModel.Instance.leftNavigations;
        foreach (var item in navigationItems)
        {
            item.IsPress = false;
        }
        IsPress = true;
        MainViewModel.Instance.setViewModel(NavigationItemViewModel);
    }
}
