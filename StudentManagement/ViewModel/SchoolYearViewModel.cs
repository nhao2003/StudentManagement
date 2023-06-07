using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using StudentManagement.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace StudentManagement.ViewModel;

public partial class SchoolYearViewModel : ObservableObject
{
    public SchoolYearViewModel()
    {
        Ins = this;
        _addSchoolYearInfoViewModel = new AddSchoolYearInfomationViewModel();
        _addStudentToClassViewModel = new List<AddStudentToClassViewModel>();
        for (int i = 0; i < soKhoi; i++)
        {
            khoiList.Add((i + minKhoi));
            _addStudentToClassViewModel.Add(new AddStudentToClassViewModel(3, 10, i));
        }
        Init();
    }
    private int soKhoi = 3;
    private int minKhoi = 10;
    [ObservableProperty]
    private String tenNamHoc;
    private static SchoolYearViewModel _ins;
    public static SchoolYearViewModel Ins
    {
        get => _ins == null ? (_ins = new SchoolYearViewModel()) : _ins;
        private set => _ins = value;

    }
    private object _addSchoolYearInfoViewModel;
    private List<AddStudentToClassViewModel> _addStudentToClassViewModel;
    private ObservableCollection<int> khoiList = new ObservableCollection<int>();
    private object contentViewModel;
    public object ContentViewModel
    {
        get { return contentViewModel; }
        private set
        {
            contentViewModel = value;
            OnPropertyChanged();
        }
    }

    private void Init()
    {
        //_addStudentToClassViewModel = new AddStudentToClassViewModel(3,10);
        ContentViewModel = _addStudentToClassViewModel[0];
        //ContentViewModel = _addSchoolYearInfoViewModel;

    }
    public void setViewModel(object viewModel)
    {
        ContentViewModel = viewModel;
    }
    public void goToClassList(int i)
    {
        if (i == soKhoi - 1)
        {
            if(tenNamHoc == null  || tenNamHoc.Trim().Length == 0)
            {
                MessageBox.Show("Chưa nhập tên năm học");
                return;
            }
            Namhoc namhoc = new Namhoc();
            namhoc.Manh = "N" + TenNamHoc.Substring(0,4);
            namhoc.Tennamhoc = TenNamHoc;
            namhoc.Isdeleted = false;
            var listClass = new List<Lophocthucte>();
            foreach (var studentwithclass in _addStudentToClassViewModel)
            {
                studentwithclass.ClassCardList.ForEach(x =>
                {
                    listClass.Add(x.getLopHocThucTe(namhoc));
                });
            }
            namhoc.Lophocthuctes = listClass;
            DataProvider.ins.context.Namhocs.Add(namhoc);

            DataProvider.ins.context.SaveChanges();
            ContentViewModel = new AddSchoolYearInfomationViewModel();
        }
        else
        {
            setViewModel(_addStudentToClassViewModel[i + 1]);
        }
    }
    public void goBackToClassList(int i)
    {
        if (i == 0)
        {
        }
        else
        {
            setViewModel(_addStudentToClassViewModel[i - 1]);
        }
    }
}