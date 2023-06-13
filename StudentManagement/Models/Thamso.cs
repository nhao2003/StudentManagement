using System;
using System.Collections.Generic;

namespace StudentManagement.Models
{
    public partial class Thamso
    {
        public Thamso()
        {
            Quydinhnams = new HashSet<Quydinhnam>();
        }

        public string Id { get; set; } = null!;
        public string? Tents { get; set; }
        public string? Typets { get; set; }
        public string? Ghichu { get; set; }
        public bool? Isdeleted { get; set; }

        public virtual ICollection<Quydinhnam> Quydinhnams { get; set; }
    }
}
