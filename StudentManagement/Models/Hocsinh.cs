using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using StudentManagement.Object;
using StudentManagement.ViewModel;
using System;
using System.Collections.Generic;

namespace StudentManagement.Models
{
    public partial class Hocsinh:ObservableObject
    {
        public Hocsinh()
        {
            Diemmonhocs = new HashSet<Diemmonhoc>();
            Diemtrungbinhmonhocnamhocs = new HashSet<Diemtrungbinhmonhocnamhoc>();
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
        public bool Gioitinh { get; set; }
        public string? GioitinhDisplay
        {
            get { return Gioitinh ? "Nam" : "Nữ"; }
        }
        public string? Tongiao { get; set; }
        public string? Dantoc { get; set; }
        public bool? Isdeleted { get; set; }

        public virtual ICollection<Diemmonhoc> Diemmonhocs { get; set; }
        public virtual ICollection<Diemtrungbinhmonhocnamhoc> Diemtrungbinhmonhocnamhocs { get; set; }
        public virtual ICollection<Kqhockymonhoc> Kqhockymonhocs { get; set; }
        public virtual ICollection<Kqhockytonghop> Kqhockytonghops { get; set; }
        public virtual ICollection<Kqnamhoc> Kqnamhocs { get; set; }
        public virtual ICollection<Phh> Phhs { get; set; }

        public virtual ICollection<Lophocthucte> Malhtts { get; set; }

        //public TranscriptConfig toTranscript()
        //{
        //    double diemMieng = -1;
        //    double diem15 = -1;
        //    double diem45 = -1;
        //    double diemCK = -1;

        //    foreach (Diemmonhoc diem in Diemmonhocs)
        //    {
        //        if (diem.Malkt == "LKT001")
        //        {
        //            diemMieng = diem.Diem;
        //        }
        //        else if (diem.Malkt == "LKT002")
        //        {
        //            diem15 = diem.Diem;
        //        }
        //        else if (diem.Malkt == "LKT003")
        //        {
        //            diem45 = diem.Diem;
        //        }
        //        else if (diem.Malkt == "LKT004")
        //        {
        //            diemCK = diem.Diem;
        //        }
        //    }
        //}
        [RelayCommand]
        private void removeStudentFromClass()
        {
            ClassListViewModel.Instance.removeStudent(this);
        }
    }
}
