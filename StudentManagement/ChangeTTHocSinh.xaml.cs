using Microsoft.Data.SqlClient;
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
    /// Interaction logic for ChangeTTHocSinh.xaml
    /// </summary>
    public partial class ChangeTTHocSinh : Window
    {
        public ChangeTTHocSinh()
        {
            InitializeComponent();
        }
        private void Close_Button_Click(object sender, RoutedEventArgs e)
        {
            Window currentWindow = Window.GetWindow(this);
            // Close the window
            currentWindow?.Close();
        }
        private void Finish_Button_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
        private void MD_SelectionChanged(object sender, MouseEventArgs e)
        {
            MouseEventArgs me = (MouseEventArgs)e;
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
