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
        }
        [ObservableProperty]
        private Lophocthucte lophocthucte;

        public void SetCurrentClass(Lophocthucte mclass)
        {
            Lophocthucte = mclass;
            SoHocSinh = Lophocthucte.Mahs.ToList().Count().ToString();
            Skhoi = (int)Lophocthucte.MalopNavigation.Khoi;
            Snamhoc = (Namhoc)Lophocthucte.ManhNavigation;
            TenLop = Lophocthucte.MalopNavigation.Tenlop;
            Sgiaovien = Lophocthucte.MagvcnNavigation;
            InitDanhSachMonHoc();
        }

        [ObservableProperty]
        ObservableCollection<SubjectTeacher> subjectTeacherList = new ObservableCollection<SubjectTeacher> {
        };

        private void InitDanhSachMonHoc()
        {
            List<Khananggiangday> kngds = DataProvider.ins.context.Khananggiangdays.ToList();
            List<Monhoc> monhs = DataProvider.ins.context.Monhocs.ToList();
            List<Phanconggiangday> pcgds = DataProvider.ins.context.Phanconggiangdays.ToList();
            subjectTeacherList.Clear();
            foreach (var mh in monhs)
            {
                SubjectTeacher subjectTeacher = new SubjectTeacher(mh.Tenmh);
                foreach(var kn in kngds)
                {
                    if (kn.Mamh == mh.Mamh)
                    {
                        subjectTeacher.AddTeacher(kn.MagvNavigation);
                    }
                }

                foreach(var pc in pcgds)
                {
                    if(pc.ManhNavigation == Snamhoc && pc.Mamh == mh.Mamh && pc.MalhttNavigation == lophocthucte)
                    {
                        subjectTeacher.SetGiaoVienPhanCong(pc.MagvNavigation);
                        break;
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
        [ObservableProperty]
        private int skhoi;
        // nien khoa
        [ObservableProperty]
        private ObservableCollection<Namhoc> nienKhoas = new ObservableCollection<Namhoc>()
        {
        };
        [ObservableProperty]
        private Namhoc snamhoc;
        private void InitNienKhoas()
        {
            List<Namhoc> namhocs = DataProvider.ins.context.Namhocs.ToList();
            nienKhoas.Clear();
            foreach(var namhoc in namhocs)
            {
                nienKhoas.Add(namhoc);
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
        private ObservableCollection<Giaovien> giaoviens = new ObservableCollection<Giaovien>()
        {
        };
        [ObservableProperty]
        private Giaovien sgiaovien;
        private void InitGiaoVien()
        {
            List<Giaovien> gvs = DataProvider.ins.context.Giaoviens.ToList();
            giaoviens.Clear();
            foreach (Giaovien g in gvs)
            {
                giaoviens.Add(g);
            }
        }

        // luu
        [RelayCommand]
        private void SaveChange()
        {
            Lophocthucte.MalopNavigation.Khoi = Skhoi;
            Lophocthucte.ManhNavigation = Snamhoc;
            Lophocthucte.MalopNavigation.Tenlop = TenLop;
            Lophocthucte.MagvcnNavigation = Sgiaovien;
            DataProvider.ins.context.Lophocthuctes.Update(Lophocthucte);
            DataProvider.ins.context.SaveChanges();
        }

        [RelayCommand]
        private void BackToPrevScreen()
        {
            ClassManagementViewModel.Instance.NavigateClassList();
        }
    }
}
