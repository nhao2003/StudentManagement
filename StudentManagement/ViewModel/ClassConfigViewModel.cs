using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using StudentManagement.Models;
using StudentManagement.Object;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace StudentManagement.ViewModel
{
    public partial class ClassConfigViewModel : ObservableObject
    {
        public ClassConfigViewModel()
        {
            InitNienKhoas();
            InitGiaoVien();
            InitDanhSachMonHoc();
            SoHocSinh = DataProvider.ins.context.Thamsos.Where(e => e.Id == "TS005").ToList()[0].Giatri;
        }
        [ObservableProperty]
        private Lophocthucte lophocthucte;

        public void SetCurrentClass(Lophocthucte mclass)
        {
            Lophocthucte = mclass;
        }

        [ObservableProperty]
        ObservableCollection<SubjectTeacher> subjectTeacherList = new ObservableCollection<SubjectTeacher> {
        };

        private void InitDanhSachMonHoc()
        {
            foreach(var mh in DataProvider.ins.context.Monhocs)
            {
                subjectTeacherList.Add(new SubjectTeacher(mh.Tenmh, danhSachGiaoViens));
            }
        }
        // khoi
        [ObservableProperty]
        private ObservableCollection<int> khois = new ObservableCollection<int>()
        {
            10,11,12
        };
        // nien khoa
        [ObservableProperty]
        private ObservableCollection<string> nienKhoas = new ObservableCollection<string>()
        {
        };

        private void InitNienKhoas()
        {
            List<Namhoc> namhocs = DataProvider.ins.context.Namhocs.ToList();
            nienKhoas.Clear();
            foreach(var namhoc in namhocs)
            {
                nienKhoas.Add(namhoc.Tennamhoc);
            }
        }
        // ten lop
        [ObservableProperty]
        private string tenLop;
        // so hoc sinh
        [ObservableProperty]
        private string soHocSinh;
        // giao vien chu nhiem
        [ObservableProperty]
        private ObservableCollection<string> giaoviens = new ObservableCollection<string>()
        {
        };
        private List<String> danhSachGiaoViens = new List<String>();
        private void InitGiaoVien()
        {
            List<Giaovien> gvs = DataProvider.ins.context.Giaoviens.ToList();
            giaoviens.Clear();
            danhSachGiaoViens.Clear();
            foreach (Giaovien g in gvs)
            {
                giaoviens.Add(g.UsernameNavigation.Hoten);
                danhSachGiaoViens.Add(g.UsernameNavigation.Hoten);
            }
        }
    }
}
