using System;
using System.Collections.Generic;

namespace StudentManagement.Models
{
    public partial class Nhanvienphongdaotao
    {
        public string Manv { get; set; } = null!;
        public string Username { get; set; } = null!;
        public string? Chucvu { get; set; }

        public virtual Taikhoan UsernameNavigation { get; set; } = null!;
    }
}
