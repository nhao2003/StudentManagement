using System.Collections.Generic;

namespace StudentManagement.Model
{
    public partial class Namhoc
    {
        public Namhoc()
        {
            Kqhockymonhocs = new HashSet<Kqhockymonhoc>();
            Kqhockytonghops = new HashSet<Kqhockytonghop>();
            Kqnamhocs = new HashSet<Kqnamhoc>();
            Lophocthuctes = new HashSet<Lophocthucte>();
            Phanconggiangdays = new HashSet<Phanconggiangday>();
        }

        public string Manh { get; set; } = null!;
        public string? Tennamhoc { get; set; }
        public bool? Isdeleted { get; set; }

        public virtual ICollection<Kqhockymonhoc> Kqhockymonhocs { get; set; }
        public virtual ICollection<Kqhockytonghop> Kqhockytonghops { get; set; }
        public virtual ICollection<Kqnamhoc> Kqnamhocs { get; set; }
        public virtual ICollection<Lophocthucte> Lophocthuctes { get; set; }
        public virtual ICollection<Phanconggiangday> Phanconggiangdays { get; set; }
    }
}
