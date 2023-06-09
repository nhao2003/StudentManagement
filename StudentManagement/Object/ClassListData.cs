using CommunityToolkit.Mvvm.ComponentModel;
using StudentManagement.Models;
using System;

namespace StudentManagement.Object
{
    public partial class ClassListData : ObservableObject
    {
        [ObservableProperty]
        private int stt;
        [ObservableProperty]
        private int khoi;
        [ObservableProperty]
        private String tenLop;
        [ObservableProperty]
        private String? giaoVien;
        [ObservableProperty]
        private int siSo;
        private Lophocthucte lophocthucte;

        public Lophocthucte Lophtt
        {
            get { return lophocthucte; }
            set { lophocthucte = value; }
        }


        public ClassListData(int STT, int Khoi, String TenLop, String? GiaoVien, int SiSo, Lophocthucte lophocthucte)
        {
            this.Lophtt = lophocthucte;
            this.Stt = STT;
            this.Khoi = Khoi;
            this.TenLop = TenLop;
            this.GiaoVien = GiaoVien;
            this.SiSo = SiSo;
        }
    }
}
