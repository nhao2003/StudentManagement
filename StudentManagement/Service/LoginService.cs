using CommunityToolkit.Mvvm.ComponentModel;
using Microsoft.EntityFrameworkCore;
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
        public async Task Login(string name, string password)
        {
            CurrentUser = await _context.Taikhoans
                .Where(user => user.Username == name && user.Passwrd == password)
                .FirstOrDefaultAsync();

            if (CurrentUser.Vaitro.Equals("NV"))
            {
                isAdmin = true;
            }
            else
            {
                isAdmin = false;
            }
        }

        public async Task<bool> IsUserAuthentic(string username, string password) 
        {

            int accCount = await _context.Taikhoans.Where(user => user.Username == username && user.Passwrd == password).CountAsync();

            if (accCount > 0)
            {
                await Login(username, password);
                return true;
                
            }
            return false;
        }
    }
}