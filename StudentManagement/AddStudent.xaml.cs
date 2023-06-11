using CommunityToolkit.Mvvm.ComponentModel;
using StudentManagement.Model;
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
        public bool isEdited = false;
        private void AddValidation()
        {
            //hoten.Text
        }
        public AddStudent()
        {
            InitializeComponent();
        }
        public AddStudent(Hocsinh input)
        {
            InitializeComponent();
            Hocsinh = input;
            isEdited = true;
            hoten.Text = input.Hotenhs;
            gt.Text = input.GioitinhDisplay;
            ngsinh.Text = input.Ngsinh.ToString();
            email.Text = input.Email;
            dchi.Text = input.Dchi;
            dantoc.Text = input.Dantoc;
            mahs.Text = input.Mahs;
            cmnd.Text = input.Cccd;
            mahs.IsEnabled = false;
            tongiao.Text = input.Tongiao;
            Title.Text = "Chỉnh sửa học sinh";
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
            if (!isEdited) //
            {
                Hocsinh hocsinh = new Hocsinh();
                hocsinh.Cccd = cmnd.Text;
                hocsinh.Hotenhs = hoten.Text;
                hocsinh.Ngsinh = DateTime.Parse(ngsinh.Text);
                hocsinh.Email = email.Text;
                hocsinh.Dchi = dchi.Text;
                bool GT;
                if (gt.Text == "Nam") GT = true;
                else GT = false;
                hocsinh.Gioitinh = GT;
                hocsinh.Mahs = mahs.Text;
                hocsinh.Dantoc = dantoc.Text;
                hocsinh.Mahs = mahs.Text;
                hocsinh.Tongiao = tongiao.Text;
                Hocsinh = hocsinh;
                DialogResult = true;
                //MessageBox.Show("okela");
                Close();
            }
            else
            {
                Hocsinh.Cccd = cmnd.Text;
                Hocsinh.Hotenhs = hoten.Text;
                Hocsinh.Ngsinh = DateTime.Parse(ngsinh.Text);
                Hocsinh.Email = email.Text;
                Hocsinh.Dchi = dchi.Text;
                bool GT;
                if (gt.Text == "Nam") GT = true;
                else GT = false;
                Hocsinh.Gioitinh = GT;
                //Hocsinh.Mahs = mahs.Text;
                Hocsinh.Dantoc = dantoc.Text;
                //Hocsinh.Mahs = mahs.Text;
                Hocsinh.Tongiao = tongiao.Text;
                DialogResult = true;
                //MessageBox.Show("okela");
                Close();
            }
        }
    }
}
