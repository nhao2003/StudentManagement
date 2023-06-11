using System;
using System.Collections.Generic;

namespace StudentManagement.Models
{
    public partial class Taikhoan
    {
        public Taikhoan()
        {
            Giaoviens = new HashSet<Giaovien>();
            Nhanvienphongdaotaos = new HashSet<Nhanvienphongdaotao>();
        }

        public string Username { get; set; } = null!;
        public string Passwrd { get; set; } = null!;
        public string? Vaitro { get; set; }
        public string Hoten { get; set; } = null!;
        public DateTime Ngsinh { get; set; }
        public string? Email { get; set; }
        public string? Dchi { get; set; }
        public bool Gioitinh { get; set; }
        public string? GioitinhDisplay
        {
            get { return Gioitinh ? "Nam" : "Nữ"; }
        }
        public bool? Isdeleted { get; set; }

        public virtual ICollection<Giaovien> Giaoviens { get; set; }
        public virtual ICollection<Nhanvienphongdaotao> Nhanvienphongdaotaos { get; set; }
    }
}
