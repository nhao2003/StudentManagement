using System.Collections.Generic;

namespace StudentManagement.Model
{
    public partial class Khananggiangday
    {
        public Khananggiangday()
        {
            Phanconggiangdays = new HashSet<Phanconggiangday>();
        }

        public string Magv { get; set; } = null!;
        public string Mamh { get; set; } = null!;
        public bool? Isdeleted { get; set; }

        public virtual Giaovien MagvNavigation { get; set; } = null!;
        public virtual Monhoc MamhNavigation { get; set; } = null!;
        public virtual ICollection<Phanconggiangday> Phanconggiangdays { get; set; }
    }
}
