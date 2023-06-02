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
        }
        [ObservableProperty]
        private Lophocthucte lophocthucte;

        public void SetCurrentClass(Lophocthucte mclass)
        {
            Lophocthucte = mclass;
            SoHocSinh = lophocthucte.Mahs.ToList().Count().ToString();
        }

        [ObservableProperty]
        ObservableCollection<SubjectTeacher> subjectTeacherList = new ObservableCollection<SubjectTeacher> {
        };

        private void InitDanhSachMonHoc()
        {
            ObservableCollection<string> gvs = new ObservableCollection<string>(){ };
            List<Khananggiangday> kngds = new List<Khananggiangday>();
            foreach (var kngd in DataProvider.ins.context.Khananggiangdays)
            {
                kngds.Add(kngd);
            }
            foreach (var mh in DataProvider.ins.context.Monhocs)
            {
                SubjectTeacher subjectTeacher = new SubjectTeacher(mh.Tenmh);
                foreach(var kn in kngds)
                {
                    if (kn.Mamh == mh.Mamh)
                    {
                        //gvs.Add(kn.MagvNavigation.UsernameNavigation.Hoten);
                        subjectTeacher.AddTeacher(kn.MagvNavigation.UsernameNavigation.Hoten);
                        //MessageBox.Show(kn.MagvNavigation.UsernameNavigation.Hoten);
                    }
                }
                subjectTeacherList.Add(subjectTeacher);
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
