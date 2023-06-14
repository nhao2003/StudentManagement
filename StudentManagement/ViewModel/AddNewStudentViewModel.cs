using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using StudentManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace StudentManagement.ViewModel
{
    public partial class AddNewStudentViewModel : ObservableObject
    {
        [ObservableProperty]
        String cccd = "";
        [ObservableProperty]
        private String hoTen;
        [ObservableProperty]
        private String ngSinh;
        [ObservableProperty]
        private String email;
        [ObservableProperty]
        private String dchi;
        [ObservableProperty]
        private int gioiTinhIndex;
        [ObservableProperty]
        private String maHs;
        [ObservableProperty]
        private String danToc;
        [ObservableProperty]
        private String tonGiao;
        [ObservableProperty]
        private String title;
        [ObservableProperty]
        public bool isEdit = false;
        [ObservableProperty]
        public bool enabled = true;
        public bool Result = false;
        public Hocsinh hocsinh;
        [ObservableProperty]
        string[] danTocVietNam = new string[]
{
    "Kinh", "Tày", "Thái", "Mường", "Hoa", "Khơ Mú", "Nùng", "Hmông",
    "Dao", "Gia Rai", "Ê Đê", "Ba Na", "Xơ Đăng", "Sán Chay", "Cơ Ho",
    "Chăm", "Sán Dìu", "Bru-Vân Kiều", "Giáy", "Cơ Tu", "Giẻ Triêng", "Tà Ôi",
    "Mạ", "Co", "Chơ Ro", "Xinh Mun", "Hà Nhì", "Chu Ru", "Lào", "La Chí",
    "La Hủ", "Phù Lá", "La Ha", "Pà Thẻn", "Lự", "Ngái", "Lô Lô", "Chứt",
    "Mảng", "Cờ Lao", "Bố Y", "Cống", "Si La", "Pu Péo", "Rơ Măm", "Brâu",
    "Ơ Đu", "Rục", "Cống", "Cống", "Thổ", "Xin", "Kanai", "Khác"
};
        [ObservableProperty]
        string[] tonGiaos = new string[]
{
    "Không",
    "Phật giáo",
    "Thiên Chúa giáo",
    "Hòa hảo",
    "Cao Đài",
    "Hồi giáo",
    "Tin lành",
    "Bà-la-môn",
    "Minh Lý đạo",
    "Đạo Cao Đài",
    "Đạo Bửu Sơn Kỳ Hương",
    "Khác"
};
        public AddNewStudentViewModel() {
            title = "Thêm học sinh";
            int countHS = DataProvider.ins.context.Hocsinhs.Count()+1;
            MaHs = $"HS{countHS}";
        }
        public AddNewStudentViewModel(Hocsinh hs) 
        {
            title = "Chỉnh sửa học sinh";
            isEdit = true;
            enabled = false;
            hocsinh = hs;
            hoTen = hocsinh.Hotenhs;
            cccd = hocsinh.Cccd;
            ngSinh = hocsinh.Ngsinh.ToString();
            email = hocsinh.Email;
            dchi = hocsinh.Dchi;
            gioiTinhIndex = hocsinh.Gioitinh ? 0 : 1;
            maHs = hocsinh.Mahs;
            danToc = hocsinh.Dantoc;
            tonGiao = hocsinh.Tongiao;
        }

        [RelayCommand]
        private void ThemHoacCapNhatHocSinh(Window window)
        {
            string errorMessage = ValidateStrings();
            if (!string.IsNullOrEmpty(errorMessage))
            {
                // Hiển thị thông báo lỗi cho người dùng, ví dụ:
                MessageBox.Show(errorMessage);
                return;
            }
            Result = true;
            if(isEdit)
            {
                enabled = false;
                hocsinh.Hotenhs = hoTen;
                hocsinh.Cccd = cccd;
                hocsinh.Ngsinh = DateTime.Parse(ngSinh);
                hocsinh.Email = email;
                hocsinh.Dchi = dchi;
                hocsinh.Gioitinh = (gioiTinhIndex == 0);
                hocsinh.Dantoc = danToc;
                hocsinh.Tongiao = tonGiao;
            }
            else
            {
                enabled = true;
                hocsinh = new Hocsinh();
                hocsinh.Hotenhs = hoTen;
                hocsinh.Cccd = cccd;
                hocsinh.Ngsinh = DateTime.Parse(ngSinh);
                hocsinh.Email = email;
                hocsinh.Dchi = dchi;
                hocsinh.Gioitinh = (gioiTinhIndex == 0);
                hocsinh.Dantoc = danToc;
                hocsinh.Tongiao = tonGiao;
                hocsinh.Mahs = maHs;
            }
            window.Close();
        }

        public string ValidateStrings()
        {
            if (string.IsNullOrEmpty(Cccd))
            {
                return "CCCD không được rỗng";
            }
            if (string.IsNullOrEmpty(HoTen))
            {
                return "Họ tên không được rỗng";
            }

            if (string.IsNullOrEmpty(NgSinh))
            {
                return "Ngày sinh không được rỗng";
            }

            if (string.IsNullOrEmpty(Email))
            {
                return "Email không được rỗng";
            }

            if (string.IsNullOrEmpty(Dchi))
            {
                return "Địa chỉ không được rỗng";
            }
            if (string.IsNullOrEmpty(MaHs))
            {
                return "Mã học sinh không được rỗng";
            }

            if (string.IsNullOrEmpty(DanToc))
            {
                return "Dân tộc không được rỗng";
            }

            if (string.IsNullOrEmpty(TonGiao))
            {
                return "Tôn giáo không được rỗng";
            }

            return ""; // Trả về chuỗi rỗng nếu không có lỗi
        }
    }
}
