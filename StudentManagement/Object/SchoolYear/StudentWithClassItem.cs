using CommunityToolkit.Mvvm.ComponentModel;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query.Internal;
using StudentManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagement.Object.SchoolYear
{
    public partial class StudentWithClassItem : ObservableObject
    {
        public StudentWithClassItem(Hocsinh hocsinh, Namhoc? namhoc, bool isSelected = false)
        {
            using (var context = new QUANLYHOCSINHContext())
            {
                student = hocsinh;

                var currentClass = hocsinh.Malhtts.Where(x => x.Manh == namhoc.Manh).FirstOrDefault();
                if (currentClass != null)
                {
                    className = currentClass.MalopNavigation.Khoi + currentClass.MalopNavigation.Tenlop;
                    var kqNamhoc = student.Kqnamhocs.Where(x => x.Manh == namhoc.Manh).FirstOrDefault();
                    if (kqNamhoc != null)
                    {
                        hocLuc = kqNamhoc.MaHocLucNavigation.TenHocLuc;
                        hanhKiem = kqNamhoc.MaHanhKiemNavigation.TenHanhKiem;
                        ketQua = kqNamhoc.MaKetQuaNavigation.TenKetQua;
                    }
                    this.isSelected = isSelected;
                    lophoc = currentClass.MalopNavigation;
                }
            }
        }
        [ObservableProperty]
        private bool isSelected;
        [ObservableProperty]
        private Lop? lophoc;
        [ObservableProperty]
        private Hocsinh student;
        [ObservableProperty]
        private String? className;
        [ObservableProperty]
        private String? diemTB;
        [ObservableProperty]
        private string? hocLuc;
        [ObservableProperty]
        private string? hanhKiem;
        [ObservableProperty]
        private string? ketQua;
        public bool getSelected()
        {
            return isSelected;
        }
        public void setSelected()
        {
            isSelected = false;
        }
        public void setTrue()
        {
            isSelected = true;
        }
        public Hocsinh GetHocsinh()
        {
            return student;
        }
    }
}
