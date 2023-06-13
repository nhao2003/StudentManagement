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
        [ObservableProperty]
        private String numHocSinh;
        [ObservableProperty]
        private ObservableCollection<Hocsinh> hocsinhs;
        [ObservableProperty]
        private String numGiaoVien;
        [ObservableProperty]
        private ObservableCollection<Giaovien> giaoviens;
        [ObservableProperty]
        private String numLopHoc;
        [ObservableProperty]
        private ObservableCollection<Lophocthucte> lophocthuctes;
        [ObservableProperty]
        private String numMonHoc;
        [ObservableProperty]
        private ObservableCollection<Monhoc> monhocs;
        [ObservableProperty]
        private String nameChuongTrinh;

        public OverviewListViewModel()
        {
            SelectedItem = GetNamhoc;
            namHocs = new ObservableCollection<Namhoc>(DataProvider.ins.context.Namhocs);

            hocsinhs = new ObservableCollection<Hocsinh>(DataProvider.ins.context.Hocsinhs);
            NumHocSinh = hocsinhs.Count().ToString();

            giaoviens = new ObservableCollection<Giaovien>(DataProvider.ins.context.Giaoviens);
            NumGiaoVien = giaoviens.Count().ToString();

            lophocthuctes = new ObservableCollection<Lophocthucte>(DataProvider.ins.context.Lophocthuctes);
            NumLopHoc = lophocthuctes.Count().ToString();

            monhocs = new ObservableCollection<Monhoc>(DataProvider.ins.context.Monhocs);
            NumMonHoc = monhocs.Count().ToString();

            NameChuongTrinh = "Trung học";
        }

        partial void OnSelectedItemChanged(Namhoc value)
        {
            GetNamhoc = value;
        }

        public static Namhoc GetNamhoc;

    }
}