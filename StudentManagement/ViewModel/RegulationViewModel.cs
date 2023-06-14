using Castle.Core.Internal;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;
using CommunityToolkit.Mvvm.Messaging.Messages;
using StudentManagement.Component.CustomTextBox;
using StudentManagement.Component.Regulation;
using StudentManagement.Component.Regulation.ValidationRules;
using StudentManagement.Models;
using StudentManagement.Object;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;

namespace StudentManagement.ViewModel
{
    public enum RegulationInputState
    {
        AddingMonHoc,
        ModifyMonHoc,
        AddingLopHoc,
        ModifyLopHoc,
    }
    public partial class RegulationViewModel : ObservableRecipient, IRecipient<PropertyChangedMessage<bool>>
    {
        [ObservableProperty]
        private String titleAddSubject = "";
        [ObservableProperty]
        private bool isAddSubject = true;
        [ObservableProperty]
        private String title1 = "123";
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
        Visibility customTextBoxVis = Visibility.Visible;
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
        CustomTextBox[] regInputs = new CustomTextBox[6];

        [ObservableProperty]
        private bool isCheckAllMonHoc = false;
        [ObservableProperty]
        private bool isCheckAllLopHoc = false;

        [RelayCommand]
        private void AllMonHocsSelected()
        {
            foreach (MonHocItemDataGrid monHocItemDataGrid in MonHocItems)
            {
                monHocItemDataGrid.IsCheckedMonHoc = IsCheckAllMonHoc;
            }
        }
        [RelayCommand]
        private void AllLopHocsSelected()
        {
            foreach (LopHocItemDataGrid lopHocItemDataGrid in LopHocItemDataGrids)
            {
                lopHocItemDataGrid.IsSelectedLopHoc = IsCheckAllLopHoc;
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
                    int count = DataProvider.ins.context.Lops.Count() + 1;
                    Input1 = "LH" + count;
                    Input2 = "";
                    KhoiIndex = 0;
                    TitleAddSubject = "Thêm lớp học";
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
                    int count = DataProvider.ins.context.Lops.Count() + 1;
                    Input1 = "MH" + count;
                    Input2 = "";
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
                    KhoiVisible = Visibility.Hidden;
                }
            }
        }

        public RegulationViewModel()
        {
            WeakReferenceMessenger.Default.Register<PropertyChangedMessage<bool>>(this);
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

        }

        [RelayCommand]
        public void CapNhatThamSo()
        {
            try
            {
                DataProvider.ins.context.UpdateRange(Thamsos);
                DataProvider.ins.context.SaveChanges();
                MessageBox.Show("Cập nhật tham số thành công.", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            catch (FormatException ex)
            {
                MessageBox.Show($"{ex.Message}", "Định dạng không hợp lệ", MessageBoxButton.OK, MessageBoxImage.Error);
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
                    foreach (var mh in DataProvider.ins.context.Monhocs)
                    {
                        if (mh.Mamh.ToLower().Trim() == Input1.ToLower().Trim())
                            throw new Exception("Mã môn học đã tồn tại trong cơ sở dữ liệu. Vui lòng chọn mã môn học khác");
                    }

                    SelectedMonHoc = null;
                    Monhoc monhoc = new Monhoc
                    {
                        Mamh = Input1.Trim(),
                        Tenmh = Input2.Trim(),
                    };
                    DataProvider.ins.context.Monhocs.Add(monhoc);
                    DataProvider.ins.context.SaveChanges();
                    MonHocItems.Add(new MonHocItemDataGrid(monhoc));
                    MessageBox.Show("Đã thêm thành công", "Thành công", MessageBoxButton.OK, MessageBoxImage.Information);
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
                    foreach (var lh in DataProvider.ins.context.Lops)
                    {
                        if (lh.Malop.ToLower().Trim() == Input1.ToLower().Trim())
                            throw new Exception("Mã lớp học đã tồn tại trong cơ sở dữ liệu. Vui lòng chọn mã lớp học khác");
                    }
                    Lop lop = new Lop
                    {
                        Malop = Input1.Trim(),
                        Tenlop = Input2.Trim(),
                        Khoi = KhoiIndex + 9,
                    };
                    DataProvider.ins.context.Lops.Add(lop);
                    DataProvider.ins.context.SaveChanges();
                    LopHocItemDataGrids.Add(new LopHocItemDataGrid(lop));
                    MessageBox.Show("Đã thêm thành công", "Thành công", MessageBoxButton.OK, MessageBoxImage.Information);
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
                    MessageBox.Show("Chỉnh sửa thành công", "Thành công", MessageBoxButton.OK, MessageBoxImage.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Lỗi", MessageBoxButton.OK, MessageBoxImage.Error);
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

                if (Input1.IsNullOrEmpty())
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

        public void Receive(PropertyChangedMessage<bool> message)
        {
            if (message.PropertyName == "IsCheckedMonHoc")
            {
                if (message.NewValue == false)
                {
                    IsCheckAllMonHoc = false;
                }
                else
                {
                    var items = MonHocItems.Where(x => x.IsCheckedMonHoc == true);
                    if (items.Count() == MonHocItems.Count())
                    {
                        IsCheckAllMonHoc = true;
                    }
                }

            }
            else if (message.PropertyName == "IsSelectedLopHoc")
            {
                if (message.NewValue == false)
                {
                    IsCheckAllLopHoc = false;
                }
                else
                {
                    var items = LopHocItemDataGrids.Where(x => x.IsSelectedLopHoc == true);
                    if (items.Count() == LopHocItemDataGrids.Count())
                    {
                        IsCheckAllLopHoc = true;
                    }
                }
            }
        }
    }
}
