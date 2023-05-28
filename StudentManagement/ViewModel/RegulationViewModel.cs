using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using StudentManagement.Object;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace StudentManagement.ViewModel
{
    public partial class RegulationViewModel : ObservableObject
    {
        [ObservableProperty]
        private String tuoiToiThieu = "";
        [ObservableProperty]
        private String tuoiToiDa = "";
        [ObservableProperty]
        private String diemToiThieu = "";
        [ObservableProperty]
        private String diemToiDa = "";
        [ObservableProperty]
        private String siSoCuaLop = "";
        [ObservableProperty]
        private String diemSoDatToiThieu = "";
        [ObservableProperty]
        private String maMonHoc = "";
        [ObservableProperty]
        private String tenMonHoc = "";
        [ObservableProperty]
        private ObservableCollection<Monhoc> monhocs;
        [ObservableProperty]
        Thamso[] thamsos = new Thamso[] {
          
        };
        public RegulationViewModel() {
            thamsos = DataProvider.ins.context.Thamsos.ToArray();
            monhocs = new ObservableCollection<Monhoc>(DataProvider.ins.context.Monhocs.Where(e => e.Isdeleted != null && !e.Isdeleted.Value));
         }
        [RelayCommand]
        public void ShowDiaLog()
        {
            try
            {
                foreach(Thamso ts in thamsos)
                {
                    if (!ValidDataType(ts.Giatri, ts.Typets))
                    {
                        throw new FormatException($"{ts.Tents} có kiểu dữ liệu là {ts.Typets}. Vui lòng nhập giá trị hợp lệ");
                    }
                }
                DataProvider.ins.context.UpdateRange(thamsos);
                DataProvider.ins.context.SaveChanges();
                MessageBox.Show("Cập nhật tham số thành công.", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Information);
            } catch (FormatException ex)
            {
                MessageBox.Show($"{ex.Message}", "Đinh dạng không hợp lệ", MessageBoxButton.OK, MessageBoxImage.Error);
            } catch (Exception ex)
            {
                MessageBox.Show($"{ex.Message}", "Lỗi", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        [RelayCommand]
        public void ThemMonHoc()
        {
            try
            {
                Monhoc monhoc = new Monhoc();
                monhoc.Mamh = MaMonHoc;
                monhoc.Tenmh = TenMonHoc;
                DataProvider.ins.context.Monhocs.Add(monhoc);
                DataProvider.ins.context.SaveChanges();
                monhocs.Add(monhoc);
                MessageBox.Show("Đã thêm thành công");
            } catch (Exception ex)
            {
                MessageBox.Show($"Đã xảy ra lỗi: {ex.Message}");
            }

        }
        private bool ValidDataType(string input, string dataType)
        {
            if (string.IsNullOrEmpty(input))
            {
                return false; // Chuỗi không được rỗng.
            }

            switch (dataType.ToLower())
            {
                case "int":
                    int intValue;
                    return int.TryParse(input, out intValue);

                case "double":
                    double doubleValue;
                    return double.TryParse(input, out doubleValue);

                case "string":
                    return true; // Không cần kiểm tra kiểu dữ liệu, chuỗi luôn hợp lệ.

                default:
                    return false; // Kiểu dữ liệu không hợp lệ.
            }
        }

    }
}
