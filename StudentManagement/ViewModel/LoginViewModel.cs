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

public partial class LoginViewModel : ObservableObject
{
    public LoginViewModel()
    {
        Init();
    }
    [ObservableProperty]
    private String userName;
    [ObservableProperty]
    private String password;
    
    public IAsyncRelayCommand goToMainWindowCM { get; set; }
    private void Init()
    {
        goToMainWindowCM = new AsyncRelayCommand(goToMainWindowAsync);
    }

    private async Task goToMainWindowAsync()
    {
        bool isAuthenticated = await Task.Run(() => LoginServices.Instance.IsUserAuthentic(userName, password));

        if (isAuthenticated)
        {   
            MainWindow window = new MainWindow();
            LoginWindow loginWindow = Application.Current.MainWindow as LoginWindow;
            Application.Current.MainWindow = window;
            MainViewModel.Instance.Refresh();
            window.Show();
            loginWindow.Close();
        }
        else
        {
            MessageBox.Show("Tên đăng nhập hoặc mật khẩu sai");
        }
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