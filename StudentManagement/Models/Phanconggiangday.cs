using System;
using System.Collections.Generic;

namespace StudentManagement.Models
{
    public partial class Phanconggiangday
    {
        public string Manh { get; set; } = null!;
        public string Malhtt { get; set; } = null!;
        public string Mamh { get; set; } = null!;
        public string Magv { get; set; } = null!;

        public virtual Khananggiangday Ma { get; set; } = null!;
        public virtual Lophocthucte MalhttNavigation { get; set; } = null!;
        public virtual Namhoc ManhNavigation { get; set; } = null!;
    }
}
