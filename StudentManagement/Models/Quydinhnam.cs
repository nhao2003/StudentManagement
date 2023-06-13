using System;
using System.Collections.Generic;

namespace StudentManagement.Models
{
    public partial class Quydinhnam
    {
        public string Id { get; set; } = null!;
        public string Manh { get; set; } = null!;
        public string? Giatri { get; set; }

        public virtual Thamso IdNavigation { get; set; } = null!;
        public virtual Namhoc ManhNavigation { get; set; } = null!;
    }
}
