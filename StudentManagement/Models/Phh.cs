using System;
using System.Collections.Generic;

namespace StudentManagement.Models
{
    public partial class Phh
    {
        public string Maphhs { get; set; } = null!;
        public string? Mahs { get; set; }
        public string? Hotenphhs { get; set; }
        public string? Sdt { get; set; }

        public virtual Hocsinh? MahsNavigation { get; set; }
    }
}
