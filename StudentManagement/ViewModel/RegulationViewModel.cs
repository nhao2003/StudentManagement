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
    public enum RegulationInputState
    {
        AddingMonHoc,
        ModifyMonHoc,
        AddingLopHoc,
        ModifyLopHoc,
    }
    public partial class RegulationViewModel : ObservableObject
    {
        [ObservableProperty]
        private String titleAddSubject = "";
        [ObservableProperty]
        private bool isAddSubject = true;
        [ObservableProperty]
        private String title1 = "";
        [ObservableProperty]
        private String title2 = "";
        [ObservableProperty]
        private String title3 = "";
        [ObservableProperty]
        private String input1 = "";
        [ObservableProperty]
        private String input2 = "";
        [ObservableProperty]
        private String input3 = "";
        [ObservableProperty]
        private int khoiIndex = 0;
        [ObservableProperty]
        private bool input1Enabled = true;
        [ObservableProperty]
        private ObservableCollection<MonHocItemDataGrid> monHocItems;
        [ObservableProperty]
        private Thamso[] thamsos = Array.Empty<Thamso>();
        [ObservableProperty]
        ContentControl contentControl = new();
        [ObservableProperty]
        private ObservableCollection<LopHocItemDataGrid> lopHocItemDataGrids;
        [ObservableProperty]
        private MonHocItemDataGrid? selectedMonHoc = null;
        [ObservableProperty]
        private LopHocItemDataGrid? selectedLopHoc = null;
        
        [ObservableProperty]
        Visibility customTextBoxVis;
        [ObservableProperty]
        private Visibility khoiVisible = Visibility.Visible;
        private int tabIndex = 0;
        public int TabIndex
        {
            set
            {
                ContentControl.Content = new EmptyView();
                tabIndex = value;
                OnPropertyChanged(nameof(tabIndex));
            }
            get { return tabIndex; }
        }
        [ObservableProperty]
        private bool isCheckAllMonHoc = false;
        [ObservableProperty]
        private bool isCheckAllLopHoc = false;

        partial void OnIsCheckAllMonHocChanged(bool value)
        {
            foreach (MonHocItemDataGrid monHocItemDataGrid in MonHocItems)
            {
                monHocItemDataGrid.IsCheckedMonHoc = value;
            }
        }
        partial void OnIsCheckAllLopHocChanged(bool value)
        {
            foreach (LopHocItemDataGrid lopHocItemDataGrid in LopHocItemDataGrids)
            {
                lopHocItemDataGrid.IsSelectedLopHoc = value;
            }
        }

        private RegulationInputState state;
        public RegulationInputState State
        {
            get
            {
                return state;
            }
            set
            {
                state = value;
                if (state == RegulationInputState.AddingLopHoc)
                {
                    ContentControl.Content = new AddSubject();
                    CustomTextBoxVis = Visibility.Visible;
                    Title1 = "Mã lớp học";
                    Title2 = "Tên lớp học";
                    Input1 = "";
                    Input2 = "";
                    KhoiIndex = 0;
                    TitleAddSubject = "Thêm lớp học";
                    Input1Enabled = true;
                    KhoiVisible = Visibility.Visible;
                }
                else if (state == RegulationInputState.ModifyLopHoc)
                {
                    ContentControl.Content = new AddSubject();
                    CustomTextBoxVis = Visibility.Visible;
                    Title1 = "Mã lớp học";
                    Title2 = "Tên lớp học";
                    TitleAddSubject = "Chỉnh sửa lớp học";
                    Input1 = SelectedLopHoc.MaLopHoc;
                    Input2 = SelectedLopHoc.TenLopHoc;
                    if (SelectedLopHoc.Khoi == 10)
                        KhoiIndex = 1;
                    else if (SelectedLopHoc.Khoi == 11)
                        KhoiIndex = 2;
                    else
                        KhoiIndex = 3;
                    Input1Enabled = false;
                    KhoiVisible = Visibility.Visible;
                }
                else if (state == RegulationInputState.AddingMonHoc)
                {
                    ContentControl.Content = new AddSubject();
                    CustomTextBoxVis = Visibility.Hidden;
                    Title1 = "Mã môn học";
                    Title2 = "Tên môn học";
                    IsAddSubject = true;
                    TitleAddSubject = "Thêm môn học";
                    Input1 = "";
                    Input2 = "";
                    Input1Enabled = true;
                    KhoiVisible = Visibility.Hidden;
                }
                else if (state == RegulationInputState.ModifyMonHoc)
                {
                    CustomTextBoxVis = Visibility.Hidden;
                    Title1 = "Mã môn học";
                    Title2 = "Tên môn học";
                    ContentControl.Content = new AddSubject();
                    IsAddSubject = false;
                    TitleAddSubject = "Chỉnh sửa môn học";
                    Input1 = SelectedMonHoc.MaMonHoc;
                    Input2 = SelectedMonHoc.TenMonHoc;
                    Input1Enabled = false;
                    KhoiVisible = Visibility.Hidden;
                }
            }
        }

        public RegulationViewModel()
        {
            ContentControl.Content = new EmptyView();
            thamsos = DataProvider.ins.context.Thamsos.ToArray();
            MonHocItems = new();
            lopHocItemDataGrids = new();
            customTextBoxVis = Visibility.Visible;
            foreach (Monhoc item in DataProvider.ins.context.Monhocs.Where(e => e.Isdeleted != null && !e.Isdeleted.Value))
            {
                MonHocItems.Add(new MonHocItemDataGrid(item));
            }
            foreach (Lop lop in DataProvider.ins.context.Lops.Where(e => e.Isdeleted != null && !e.Isdeleted.Value))
            {
                LopHocItemDataGrids.Add(new LopHocItemDataGrid(lop));
            }
            IsCheckAllLopHoc = true;

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
        public void LuuThayDoi()
        {
            try
            {
                ValidInput();
                if (State == RegulationInputState.AddingMonHoc)
                {
                    SelectedMonHoc = null;
                    Monhoc monhoc = new Monhoc
                    {
                        Mamh = Input1,
                        Tenmh = Input2,
                    };
                    DataProvider.ins.context.Monhocs.Add(monhoc);
                    DataProvider.ins.context.SaveChanges();
                    MonHocItems.Add(new MonHocItemDataGrid(monhoc));
                    MessageBox.Show("Đã thêm thành công");
                    Input1 = "";
                    Input2 = "";
                }
                else if (State == RegulationInputState.ModifyMonHoc)
                {
                    SelectedMonHoc.TenMonHoc = Input2;
                    SelectedMonHoc.Monhoc.Tenmh = Input2;
                    DataProvider.ins.context.Monhocs.Update(SelectedMonHoc.Monhoc);
                    DataProvider.ins.context.SaveChanges();
                    MessageBox.Show("Chỉnh sửa thành công");
                }
                else if (State == RegulationInputState.AddingLopHoc)
                {
                    SelectedLopHoc = null;
                    Lop lop = new Lop
                    {
                        Malop = Input1,
                        Tenlop = Input2,
                        Khoi = KhoiIndex + 9,
                    };
                    DataProvider.ins.context.Lops.Add(lop);
                    DataProvider.ins.context.SaveChanges();
                    LopHocItemDataGrids.Add(new LopHocItemDataGrid(lop));
                    MessageBox.Show("Đã thêm thành công");
                    Input1 = "";
                    Input2 = "";
                    KhoiIndex = 0;
                }
                else if (State == RegulationInputState.ModifyLopHoc)
                {
                    SelectedLopHoc.TenLopHoc = Input2;
                    SelectedLopHoc.LopHoc.Tenlop = Input2;
                    DataProvider.ins.context.Lops.Update(SelectedLopHoc.LopHoc);
                    DataProvider.ins.context.SaveChanges();
                    MessageBox.Show("Chỉnh sửa thành công");
                }
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
        private void HienThiChinhSuaThongTinMonHoc()
        {
            if (SelectedMonHoc != null)
            {
                State = RegulationInputState.ModifyMonHoc;

            }
        }
        [RelayCommand]
        private void HienThiThemThongTinMonHoc()
        {
            State = RegulationInputState.AddingMonHoc;

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

        [RelayCommand]
        private void ThemLopHoc()
        {
            if (State == RegulationInputState.AddingLopHoc)
            {
                try
                {
                    Lop lop = new Lop();
                    lop.Malop = Input1;
                    lop.Khoi = int.Parse(Input2);
                    lop.Tenlop = Input3;
                    DataProvider.ins.context.Lops.Add(lop);
                    DataProvider.ins.context.SaveChanges();
                    LopHocItemDataGrids.Add(new LopHocItemDataGrid(lop));
                    MessageBox.Show("Đã thêm thành công");
                    Input1 = "";
                    Input2 = "";
                }
                catch (Exception e)
                {
                    MessageBox.Show($"Đã xảy ra lỗi: {e.Message}", "Lỗi", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            else if (State == RegulationInputState.ModifyMonHoc)
            {
                MessageBox.Show($"Sửa lớp học", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        [RelayCommand]
        private void XoaLopHoc()
        {
            MessageBoxResult result = MessageBox.Show("Bạn có chắc chắn muốn xóa những lớp học này?", "Xác nhận xóa", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (result == MessageBoxResult.Yes)
            {
                List<LopHocItemDataGrid> lopHocToRemoves = new List<LopHocItemDataGrid>();

                foreach (LopHocItemDataGrid lopHoc in LopHocItemDataGrids)
                {
                    if (lopHoc.IsSelectedLopHoc)
                    {
                        lopHocToRemoves.Add(lopHoc);
                        lopHoc.LopHoc.Isdeleted = true;
                        DataProvider.ins.context.Lops.Update(lopHoc.LopHoc);
                    }
                }
                DataProvider.ins.context.SaveChanges();
                foreach (LopHocItemDataGrid lopHoc in lopHocToRemoves)
                {
                    LopHocItemDataGrids.Remove(lopHoc);
                }

                MessageBox.Show("Xóa thành công!", "Thành công", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }
        [RelayCommand]
        private void HienThiThemThongTinLopHoc()
        {

            State = RegulationInputState.AddingLopHoc;
        }
        [RelayCommand]
        private void HienThiChinhSuaThongTinLopHoc()
        {
            if (SelectedLopHoc != null)
            {

                State = RegulationInputState.ModifyLopHoc;
            }
        }
        private void ValidInput()
        {
            if (State == RegulationInputState.AddingMonHoc || State == RegulationInputState.ModifyMonHoc)
            {

                if (Input1.IsNullOrEmpty() || Input2.IsNullOrEmpty())
                {
                    throw new Exception("Mã môn học không được rỗng");
                }
                if (Input2.IsNullOrEmpty())
                {
                    throw new Exception("Tên môn học không được rỗng");
                }
            }
            else if (State == RegulationInputState.AddingLopHoc || State == RegulationInputState.ModifyLopHoc)
            {
                if (Input1.IsNullOrEmpty())
                {
                    throw new Exception("Mã lớp học không được rỗng");
                }
                if (Input2.IsNullOrEmpty())
                {
                    throw new Exception("Tên lớp học không được rỗng");
                }
                if (KhoiIndex == 0)
                {
                    throw new Exception("Vui lòng chọn khối");
                }

            }
        }
    }
}
