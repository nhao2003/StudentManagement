using MaterialDesignThemes.Wpf;
using StudentManagement.ViewModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace StudentManagement.Component.NhanVienList
{
    /// <summary>
    /// Interaction logic for NhanViensListUC.xaml
    /// </summary>
    public partial class NhanViensListUC : UserControl
    {
        public ObservableCollection<Taikhoan> TaikhoanList { get; set; }
        public Taikhoan Taikhoan { get; set; }
        public NhanViensListUC()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void SearchValue_TextChanged(object sender, KeyEventArgs e)
        {

            
        }
    }
}
