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

        List<Khananggiangday> kngds = DataProvider.ins.context.Khananggiangdays.ToList();
        List<Monhoc> monhs = DataProvider.ins.context.Monhocs.ToList();
        List<Phanconggiangday> pcgds = DataProvider.ins.context.Phanconggiangdays.ToList();
        private void InitDanhSachMonHoc()
        {
            kngds = DataProvider.ins.context.Khananggiangdays.ToList();
            monhs = DataProvider.ins.context.Monhocs.ToList();
            pcgds = DataProvider.ins.context.Phanconggiangdays.ToList();
            subjectTeacherList.Clear();
            foreach (var mh in monhs)
            {
                SubjectTeacher subjectTeacher = new SubjectTeacher(mh);
                foreach(var kn in kngds)
                {
                    // them giao vien tu kha nang giang day
                    if (kn.Mamh == mh.Mamh)
                    {
                        subjectTeacher.AddTeacher(kn.MagvNavigation);
                    }
                }

                foreach(var pc in pcgds)
                {
                    if(pc.ManhNavigation == Snamhoc && pc.Mamh == mh.Mamh && pc.MalhttNavigation == lophocthucte)
                    {
                        // neu co san trong phan cong giang day
                        subjectTeacher.SetSGiaoVien(pc.MagvNavigation);
                        subjectTeacher.Phanconggiangday = pc;
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
            Lophocthucte.MalopNavigation.Tenlop = TenLop;
            Lophocthucte.MalopNavigation.Khoi = Skhoi;
            Lophocthucte.ManhNavigation = Snamhoc;
            Lophocthucte.MagvcnNavigation = Sgiaovien;

            // luu phan cong giang day
            // neu co roi thi update
            // neu chua thi tao moi
            foreach(SubjectTeacher subjectTeacher in SubjectTeacherList)
            {
                // check da chon
                if(subjectTeacher.Sgiaovien != null)
                {
                    // check da co trong bang chua
                    if(subjectTeacher.Phanconggiangday != null)
                    {
                        // trong bang co roi => update
                        //DataProvider.ins.context.Phanconggiangdays.de(subjectTeacher.Phanconggiangday);
                        //Phanconggiangday phanconggiangday = new Phanconggiangday();
                        //phanconggiangday.Manh = Snamhoc.Manh;
                        //phanconggiangday.Malhtt = lophocthucte.Malhtt;
                        //phanconggiangday.Magv = subjectTeacher.Sgiaovien.Magv;
                        //phanconggiangday.Mamh = subjectTeacher.Monhoc.Mamh;
                        DataProvider.ins.context.Phanconggiangdays.Remove(subjectTeacher.Phanconggiangday);
                    }
                        // chua co trong bang => tao moi va them vao
                        Phanconggiangday phanconggiangday = new Phanconggiangday();
                        phanconggiangday.Manh = Snamhoc.Manh;
                        phanconggiangday.Malhtt = lophocthucte.Malhtt;
                        phanconggiangday.Magv = subjectTeacher.Sgiaovien.Magv;
                        phanconggiangday.Mamh = subjectTeacher.Monhoc.Mamh;
                        DataProvider.ins.context.Phanconggiangdays.Add(phanconggiangday);
                }
            }
            DataProvider.ins.context.Lophocthuctes.Update(Lophocthucte);
            DataProvider.ins.context.SaveChanges();

            ClassManagementViewModel.Instance.Refresh(Lophocthucte);
            MessageBox.Show("Cập nhập thành công");
        }

        [RelayCommand]
        private void BackToPrevScreen()
        {
            ClassManagementViewModel.Instance.NavigateClassList();
        }
    }
}
