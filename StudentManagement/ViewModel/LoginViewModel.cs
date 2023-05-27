using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using StudentManagement.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace StudentManagement.ViewModel;

public partial class LoginViewModel: ObservableObject
{
    public LoginViewModel() 
    {
        Init();
    }
    [ObservableProperty]
    private String userName;
    [ObservableProperty]
    private String password;
    public ICommand goToMainWindowCM { get; set; }
    private void Init()
    {
        goToMainWindowCM = new RelayCommand(goToMainWindow);
    }
    
    private void goToMainWindow()
    {
        if (LoginServices.Instance.IsUserAuthentic(userName, password))
        {
            MainWindow window = new MainWindow();
            LoginWindow loginWindow = Application.Current.MainWindow as LoginWindow;

            Application.Current.MainWindow = window;
            window.Show();
            loginWindow.Close();
        }
        else
        {
            MessageBox.Show(UserName + Password + "  jfjf");
        }
    }
}
