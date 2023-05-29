using System.Collections.Generic;

namespace StudentManagement.Models
{
    public partial class Hanhkiem
    {
        public Hanhkiem()
        {
            Kqhockytonghops = new HashSet<Kqhockytonghop>();
            Kqnamhocs = new HashSet<Kqnamhoc>();
        }

        public string MaHanhKiem { get; set; } = null!;
        public string TenHanhKiem { get; set; } = null!;
        public bool? Isdeleted { get; set; }

        public virtual ICollection<Kqhockytonghop> Kqhockytonghops { get; set; }
        public virtual ICollection<Kqnamhoc> Kqnamhocs { get; set; }
    }
}
