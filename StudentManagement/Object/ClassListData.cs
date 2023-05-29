using CommunityToolkit.Mvvm.ComponentModel;
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
        private String giaoVien;
        [ObservableProperty]
        private int siSo;
        public Lophocthucte lophocthucte;

        public ClassListData(int STT, int Khoi, String TenLop, String GiaoVien, int SiSo, Lophocthucte lophocthucte)
        {
            this.lophocthucte = lophocthucte;
            this.Stt = STT;
            this.Khoi = Khoi;
            this.TenLop = TenLop;
            this.GiaoVien = GiaoVien;
            this.SiSo = SiSo;
        }
    }
}
