using Castle.Core.Internal;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using StudentManagement.Component.Regulation;
using StudentManagement.Models;
using StudentManagement.Object;
using System;
using System.Collections.Generic;
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
        private ObservableCollection<MonHocItemDataGrid> monHocItems;
        [ObservableProperty]
        private Thamso[] thamsos = Array.Empty<Thamso>();
        [ObservableProperty]
        ContentControl contentControl = new();

        [ObservableProperty]
        private MonHocItemDataGrid? selectedMonHoc = null;
        [ObservableProperty]
        private bool isCheckAllItem = true;

        public RegulationViewModel()
        {
            contentControl.Content = new EmptyView();
            thamsos = DataProvider.ins.context.Thamsos.ToArray();
            MonHocItems = new ObservableCollection<MonHocItemDataGrid>();
            foreach(Monhoc item in DataProvider.ins.context.Monhocs.Where(e => e.Isdeleted != null && !e.Isdeleted.Value))
            {
                MonHocItems.Add(new MonHocItemDataGrid(item));
            }
        }

        [RelayCommand]
        private void isCheckedAllChanged()
        {
            MessageBox.Show("Click");
            foreach (MonHocItemDataGrid item in MonHocItems)
            {
                item.IsCheckedMonHoc = IsCheckAllItem;
            }
        }

        [RelayCommand]
        public void CapNhatThamSo()
        {
            try
            {
                foreach (Thamso ts in Thamsos)
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
            MessageBox.Show(IsCheckAllItem.ToString());
            return;
            try
            {
                if (MaMonHoc.IsNullOrEmpty() || TenMonHoc.IsNullOrEmpty())
                {
                    throw new Exception("Tên môn học hoặc mã môn học rỗng");
                }
                if (IsAddSubject)
                {
                    SelectedMonHoc = null;
                    Monhoc monhoc = new Monhoc
                    {
                        Mamh = MaMonHoc,
                        Tenmh = TenMonHoc
                    };
                    DataProvider.ins.context.Monhocs.Add(monhoc);
                    DataProvider.ins.context.SaveChanges();
                    MonHocItems.Add(new MonHocItemDataGrid(monhoc));
                    MessageBox.Show("Đã thêm thành công");
                    MaMonHoc = "";
                    TenMonHoc = "";
                }
                else
                {
                    SelectedMonHoc.TenMonHoc = TenMonHoc;
                    SelectedMonHoc.Monhoc.Tenmh = TenMonHoc;
                    DataProvider.ins.context.Monhocs.Update(SelectedMonHoc.Monhoc);
                    DataProvider.ins.context.SaveChanges();
                    MessageBox.Show("Chỉnh sửa thành công");
                }
                //TODO: Update gridview
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
            if(SelectedMonHoc != null)
            {
                ContentControl.Content = new AddSubject();
                IsAddSubject = false;
                TitleAddSubject = "Chỉnh sửa môn học";
                MaMonHoc = SelectedMonHoc.MaMonHoc;
                TenMonHoc = SelectedMonHoc.TenMonHoc;
            }
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
        [RelayCommand]
        private void XoaMonHoc()
        {
            MessageBoxResult result = MessageBox.Show("Bạn có chắc chắn muốn xóa những môn học này?", "Xác nhận xóa", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (result == MessageBoxResult.Yes)
            {
                List<MonHocItemDataGrid> monHocToRemove = new List<MonHocItemDataGrid>();

                foreach (MonHocItemDataGrid monHoc in MonHocItems)
                {
                    if (monHoc.IsCheckedMonHoc)
                    {
                        monHocToRemove.Add(monHoc);
                        monHoc.Monhoc.Isdeleted = true;
                        DataProvider.ins.context.Update(monHoc.Monhoc);
                    }
                }
                DataProvider.ins.context.SaveChanges();
                foreach (MonHocItemDataGrid monHoc in monHocToRemove)
                {
                    MonHocItems.Remove(monHoc);
                }

                MessageBox.Show("Xóa thành công!", "Thành công", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }
    }
}
