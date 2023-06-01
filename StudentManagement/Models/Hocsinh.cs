using StudentManagement.Object;
using System;
using System.Collections.Generic;

namespace StudentManagement.Models
{
    public partial class Hocsinh
    {
        public Hocsinh()
        {
            Diemmonhocs = new HashSet<Diemmonhoc>();
            Kqhockymonhocs = new HashSet<Kqhockymonhoc>();
            Kqhockytonghops = new HashSet<Kqhockytonghop>();
            Kqnamhocs = new HashSet<Kqnamhoc>();
            Phhs = new HashSet<Phh>();
            Malhtts = new HashSet<Lophocthucte>();
        }

        public string Mahs { get; set; } = null!;
        public string? Cccd { get; set; }
        public string? Hotenhs { get; set; }
        public DateTime? Ngsinh { get; set; }
        public string? Email { get; set; }
        public string? Sdt { get; set; }
        public string? Dchi { get; set; }
        public bool? Gioitinh { get; set; }
        public string? Tongiao { get; set; }
        public string? Dantoc { get; set; }
        public bool? Isdeleted { get; set; }

        public virtual ICollection<Diemmonhoc> Diemmonhocs { get; set; }
        public virtual ICollection<Kqhockymonhoc> Kqhockymonhocs { get; set; }
        public virtual ICollection<Kqhockytonghop> Kqhockytonghops { get; set; }
        public virtual ICollection<Kqnamhoc> Kqnamhocs { get; set; }
        public virtual ICollection<Phh> Phhs { get; set; }

        public virtual ICollection<Lophocthucte> Malhtts { get; set; }

        public TranscriptConfig toTranscript()
        {
            double diemMieng = 0.0;
            double diem15 = 0.0;
            double diem45 = 0.0;
            double diemCK = 0.0;

            foreach (Diemmonhoc diem in Diemmonhocs)
            {
                if (diem.Malkt == "LKT001")
                {
                    diemMieng = diem.Diem;
                }
                else if (diem.Malkt == "LKT002")
                {
                    diem15 = diem.Diem;
                }
                else if (diem.Malkt == "LKT003")
                {
                    diem45 = diem.Diem;
                }
                else if (diem.Malkt == "LKT004")
                {
                    diemCK = diem.Diem;
                }
            }
            return new TranscriptConfig(Mahs, Hotenhs, diemMieng.ToString(), diem15.ToString(), diem45.ToString(), diemCK.ToString());
        }
    }
}
