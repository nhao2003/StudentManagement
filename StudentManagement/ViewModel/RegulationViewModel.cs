using Castle.Core.Internal;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using StudentManagement.Component.Regulation;
using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace StudentManagement.ViewModel
{
    public partial class RegulationViewModel : ObservableObject
    {
        [ObservableProperty]
        private String titleAddSubject = "";
        [ObservableProperty]
        private bool isAddSubject = true;
        [ObservableProperty]
        private String maMonHoc = "";
        [ObservableProperty]
        private String tenMonHoc = "";
        [ObservableProperty]
        private ObservableCollection<Monhoc> monhocs;
        [ObservableProperty]
        private Thamso[] thamsos = Array.Empty<Thamso>();
        [ObservableProperty]
        ContentControl contentControl = new();

        [ObservableProperty]
        private Monhoc selectedMonHoc = new Monhoc();

        public RegulationViewModel()
        {
            contentControl.Content = new EmptyView();
            thamsos = DataProvider.ins.context.Thamsos.ToArray();
            Monhocs = new ObservableCollection<Monhoc>(DataProvider.ins.context.Monhocs.Where(e => e.Isdeleted != null && !e.Isdeleted.Value));
        }
        [RelayCommand]
        public void ShowDiaLog()
        {
            try
            {
                foreach (Thamso ts in thamsos)
                {
                    if (!ValidDataType(ts.Giatri, ts.Typets))
                    {
                        throw new FormatException($"{ts.Tents} có kiểu dữ liệu là {ts.Typets}. Vui lòng nhập giá trị hợp lệ");
                    }
                }
                DataProvider.ins.context.UpdateRange(thamsos);
                DataProvider.ins.context.SaveChanges();
                MessageBox.Show("Cập nhật tham số thành công.", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            catch (FormatException ex)
            {
                MessageBox.Show($"{ex.Message}", "Đinh dạng không hợp lệ", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"{ex.Message}", "Lỗi", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        [RelayCommand]
        public void ThemMonHoc()
        {

            try
            {

                if (MaMonHoc.IsNullOrEmpty() || TenMonHoc.IsNullOrEmpty())
                {
                    throw new Exception("Tên môn học hoặc mã môn học rỗng");
                }
                if (IsAddSubject)
                {
                    Monhoc monhoc = new Monhoc
                    {
                        Mamh = MaMonHoc,
                        Tenmh = TenMonHoc
                    };
                    DataProvider.ins.context.Monhocs.Add(monhoc);
                    DataProvider.ins.context.SaveChanges();
                    MessageBox.Show("Đã thêm thành công");
                    MaMonHoc = "";
                    TenMonHoc = "";
                }
                else
                {
                    SelectedMonHoc.Tenmh = TenMonHoc;
                    DataProvider.ins.context.Monhocs.Update(SelectedMonHoc);
                    DataProvider.ins.context.SaveChanges();
                    MessageBox.Show("Chỉnh sửa thành công");
                }
                Monhocs = new ObservableCollection<Monhoc>(DataProvider.ins.context.Monhocs.Where(e => e.Isdeleted != null && !e.Isdeleted.Value));
            }
            catch (Exception ex)
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
        [RelayCommand]
        private void showModifySubjectView()
        {
            ContentControl.Content = new AddSubject();
            IsAddSubject = false;
            TitleAddSubject = "Chỉnh sửa môn học";
            MaMonHoc = SelectedMonHoc.Mamh;
            TenMonHoc = SelectedMonHoc.Tenmh;
        }
        [RelayCommand]
        private void showAddSubjectView()
        {
            ContentControl.Content = new AddSubject();
            IsAddSubject = true;
            TitleAddSubject = "Thêm môn học";
            MaMonHoc = "";
            TenMonHoc = "";
        }

    }
}
