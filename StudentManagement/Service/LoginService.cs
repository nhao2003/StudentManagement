using CommunityToolkit.Mvvm.ComponentModel;
using StudentManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagement.Service
{
    public partial class LoginServices: ObservableObject
    {
        private static LoginServices s_instance;

        public static LoginServices Instance => s_instance ?? (s_instance = new LoginServices());
        private QUANLYHOCSINHContext _context = DataProvider.ins.context;
        private static Taikhoan _currentUser;
        public static Taikhoan CurrentUser { get => _currentUser; set => _currentUser = value; }
        [ObservableProperty]
        private bool isAdmin;
        public void Login(String name, String password)
        {
            CurrentUser = _context.Taikhoans.Where(user => user.Username == name && user.Passwrd == password).FirstOrDefault();
            if(CurrentUser.Vaitro.Equals("NV"))
            {
                isAdmin = true;
            }
            else
            {
                isAdmin = false;
            }
        }
        public bool IsUserAuthentic(string username, string password)
        {

            int accCount = _context.Taikhoans.Where(user => user.Username == username && user.Passwrd == password).Count();

            if (accCount > 0)
            {
                Login(username, password);
                return true;
                
            }
            return false;
        }
    }
}