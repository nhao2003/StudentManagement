using CommunityToolkit.Mvvm.ComponentModel;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagement.Object.SchoolYear
{
    public partial class StudentWithClassItem: ObservableObject
    {
        public StudentWithClassItem(Hocsinh hocsinh, Namhoc? namhoc, bool isSelected = false) 
        {
            using(var context = new QUANLYHOCSINHContext())
            {
                student = hocsinh;
                var malhtt = hocsinh.Malhtts.ToArray();
                //var malhtt = context.Lops.Include(x => x.Lophocthuctes).ThenInclude(x => x.Manh == namhoc.Manh);
               
                //className = currentClass.MalopNavigation.Tenlop;
                //var kqNamhoc = student.Kqnamhocs.Where(x => x.Manh == namhoc.Manh).First();
                //hocLuc = kqNamhoc.MaHocLucNavigation.TenHocLuc;
                //hanhKiem = kqNamhoc.MaHanhKiemNavigation.TenHanhKiem;
                //ketqua = kqNamhoc.MaKetQuaNavigation.TenKetQua;
                //isSelected = false;
                //selectedClass = currentClass.MalopNavigation;
            }
        }
        [ObservableProperty]
        private bool isSelected;
        [ObservableProperty]
        private Lophocthucte lophoc;
        [ObservableProperty]
        private Hocsinh student;
        [ObservableProperty]
        private String className;
        [ObservableProperty]
        private String diemTB;
        [ObservableProperty]
        private string hocLuc;
        [ObservableProperty]
        private string hanhKiem;
        [ObservableProperty]
        private string ketqua;
        [ObservableProperty]
        private Lop? selectedClass;
    }
}
