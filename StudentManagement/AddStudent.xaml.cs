using StudentManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace StudentManagement
{
    /// <summary>
    /// Interaction logic for AddStudent.xaml
    /// </summary>
    public partial class AddStudent : Window
    {
        public Hocsinh Hocsinh { get; set; }
        public AddStudent()
        {
            InitializeComponent();
        }
        private void Border_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }
        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {
            // Get the current window
            Window currentWindow = Window.GetWindow(this);

            // Close the window
            currentWindow?.Close();
        }

        private void Finish_Button_Click(object sender, RoutedEventArgs e)
        {
            Hocsinh hocsinh = new Hocsinh();
            hocsinh.Cccd = cmnd.Text;
            hocsinh.Hotenhs = hoten.Text;
            hocsinh.Ngsinh = DateTime.Parse(ngsinh.Text);
            hocsinh.Email = email.Text;
            hocsinh.Dchi = dchi.Text;
            bool GT;
            if(gt.Text == "Nam") GT = true;
            else GT = false;
            hocsinh.Gioitinh = GT;
            hocsinh.Mahs = mahs.Text;
            hocsinh.Dantoc = dantoc.Text;
            hocsinh.Mahs = mahs.Text;
            hocsinh.Tongiao = tongiao.Text;
            // Close the window
            Close();
        }
    }
}
