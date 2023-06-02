using CommunityToolkit.Mvvm.ComponentModel;
using StudentManagement.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagement.ViewModel
{
    public partial class OverviewListViewModel : ObservableObject
    {
        [ObservableProperty]
        private Namhoc selectedItem;
        [ObservableProperty]
        private ObservableCollection<Namhoc> namHocs;

        public OverviewListViewModel()
        {
            SelectedItem = GetNamhoc; 
            namHocs = new ObservableCollection<Namhoc>(DataProvider.ins.context.Namhocs);
        }

        partial void OnSelectedItemChanged(Namhoc value)
        {
            GetNamhoc = value;
        }

        public static Namhoc GetNamhoc;
    }
}
