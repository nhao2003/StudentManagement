namespace StudentManagement.Model
{
    public partial class Phanconggiangday
    {
        public string Manh { get; set; } = null!;
        public string Malhtt { get; set; } = null!;
        public string Magv { get; set; } = null!;
        public string Mamh { get; set; } = null!;
        public bool? Isdeleted { get; set; }

        public virtual Khananggiangday Ma { get; set; } = null!;
        public virtual Giaovien MagvNavigation { get; set; } = null!;
        public virtual Lophocthucte MalhttNavigation { get; set; } = null!;
        public virtual Monhoc MamhNavigation { get; set; } = null!;
        public virtual Namhoc ManhNavigation { get; set; } = null!;
    }
}
