using System;
using System.Collections.Generic;

namespace StudentManagement.Models
{
    public partial class Khananggiangday
    {
        public Khananggiangday()
        {
            Phanconggiangdays = new HashSet<Phanconggiangday>();
        }

        public string Magv { get; set; } = null!;
        public string Mamh { get; set; } = null!;

        public virtual ICollection<Phanconggiangday> Phanconggiangdays { get; set; }
    }
}
