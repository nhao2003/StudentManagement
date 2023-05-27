using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagement.Service
{
    class LoginServices
    {
        private static LoginServices s_instance;

        public static LoginServices Instance => s_instance ?? (s_instance = new LoginServices());
        private QUANLYHOCSINHContext _context = DataProvider.ins.Context;
        private static Taikhoan _currentUser;
        public static Taikhoan CurrentUser { get => _currentUser; set => _currentUser = value; }
        public void Login(String name, String password)
        {
            CurrentUser = _context.Taikhoans.Where(user => user.Username == name && user.Passwrd == password).FirstOrDefault();
        }
        public bool IsUserAuthentic(string username, string password)
        {

            int accCount = _context.Taikhoans.Where(user => user.Username == username && user.Passwrd== password).Count();

            if (accCount > 0)
            {
                return true;
            }
            return false;
        }
    }
}
