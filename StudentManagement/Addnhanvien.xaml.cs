using MaterialDesignThemes.Wpf;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using StudentManagement.Model;
using StudentManagement.Models;
using StudentManagement.ViewModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Globalization;
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
    /// Interaction logic for Addnhanvien.xaml
    /// </summary>
    public partial class Addnhanvien : Window
    {
        public Taikhoan Taikhoan { get; set; }
        public bool isEdited = false;
        public Addnhanvien()
        {
            InitializeComponent();
        }
        public Addnhanvien(AddNhanVienViewModel addNhanVienViewModel)
        {
            InitializeComponent();
            DataContext = addNhanVienViewModel;
        }
        //public Addnhanvien(Taikhoan input)
        //{
        //    InitializeComponent();
        //    Taikhoan = input;
        //    isEdited = true;
        //    _hoten.Text = input.Hoten;
        //    GT.Text = input.GioitinhDisplay;
        //    _ngsinh.Text = input.Ngsinh.ToString();
        //    _email.Text = input.Email;
        //    _pw.Text = input.Passwrd;
        //    if (input.Vaitro == "NV") VT.SelectedIndex = 0;
        //    else VT.SelectedIndex = 1;
        //    _username.Text = input.Username;
        //    _username.IsEnabled = false;
        //    _dchi.Text = input.Dchi;
        //    Title.Text = "Chỉnh sửa nhân viên";
        //}
        private void Border_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }
        private void Close_Button_Click(object sender, RoutedEventArgs e)
        {
            // Get the current window
            Window currentWindow = Window.GetWindow(this);
            // Close the window
            currentWindow?.Close();
        }

        private void Finish_Button_Click(object sender, RoutedEventArgs e)
        {
            //string username = _username.Text, hoten = _hoten.Text, ngsinh = _ngsinh.Text, email = _email.Text, dchi = _dchi.Text
            //    , pw = _pw.Text, vt, md = "";
            //bool gt;
            //if (GT.Text == "Nam") gt = true;
            //else gt = false;
            //if (VT.Text == "Nhân viên") vt = "NV";
            //else vt = "GV";
            //if(!isEdited)//add nv
            //{
            //    Taikhoan taikhoan = new Taikhoan();
            //    taikhoan.Email = _email.Text;
            //    taikhoan.Dchi = _dchi.Text;
            //    taikhoan.Gioitinh = gt;
            //    taikhoan.Hoten = _hoten.Text;
            //    taikhoan.Username = _username.Text;
            //    taikhoan.Passwrd = pw;
            //    taikhoan.Vaitro = vt;
            //    // string format = "dd/MM/yyyy";
            //    taikhoan.Ngsinh = DateTime.Parse(ngsinh);
            //    Taikhoan = taikhoan;
            //    DialogResult = true;
            //}
            //else
            //{
            //    Taikhoan.Email = _email.Text;
            //    Taikhoan.Dchi = _dchi.Text;
            //    Taikhoan.Gioitinh = gt;
            //    Taikhoan.Hoten = _hoten.Text;
            //    //Taikhoan.Username = _username.Text;
            //    Taikhoan.Passwrd = pw;
            //    Taikhoan.Vaitro = vt;
            //    // string format = "dd/MM/yyyy";
            //    Taikhoan.Ngsinh = DateTime.Parse(ngsinh);
            //    //Taikhoan = taikhoan;
            //    DialogResult = true;
            //}    
            //Close();
        }

        private void MD_SelectionChanged(object sender, MouseEventArgs e)
        {
            //MouseEventArgs me = (MouseEventArgs)e;
            //string connectionString = "Data Source=DESKTOP-85LGGH4\\SQLEXPRESS;Initial Catalog=QUANLYHOCSINH;Integrated Security=True;";
            //SqlConnection connection = new SqlConnection(connectionString);
            //string query = "SELECT TENMH FROM MONHOC";
            //SqlCommand command = new SqlCommand(query, connection);
            //// public ObservableCollection<string> SelectedMonHoc;
            //connection.Open();
            //MD.Items.Clear();
            //SqlDataReader reader = command.ExecuteReader();
            //if (reader.HasRows)
            //{
            //    while (reader.Read())
            //    {
            //        for (int i = 0; i < reader.FieldCount; i++)
            //            MD.Items.Add(reader.GetString(i));
            //    }
            //}
            //reader.Close();
            //connection.Close();
        }
    }
}
