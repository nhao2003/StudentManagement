using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.EntityFrameworkCore.ChangeTracking.Internal;
using StudentManagement.Models;
using StudentManagement.Object.SchoolYear;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagement.ViewModel;

public sealed partial class AddStudentToClassViewModel : ObservableObject
{
    public AddStudentToClassViewModel(int soKhoi, int minKhoi, int currentIndex)
    {
        this.minKhoi = minKhoi;
        this.currentIndex = currentIndex;
        this.currentNamhoc = DataProvider.ins.context.Namhocs.ToList().OrderByDescending(x=>x.Manh).FirstOrDefault();
        this.StudentEmptyDisplay = new ObservableCollection<StudentWithClassItem>();
        ClassCardList = new List<ClassCard>();
        for (int i = 0; i < soKhoi; i++)
        {
            khoiList.Add((i + minKhoi));
        }
        selectedKhoi = khoiList[currentIndex];
        InitClass();
        CurrentClass = ClassCardList[0];
        selectedIndexTab = 1;
        String giatri = DataProvider.ins.context.Thamsos.Where(x => x.Tents.Equals ("Sỉ số tối đa của lớp")).FirstOrDefault().Giatri;
        maxStudentInClass = int.Parse(giatri) != null ? int.Parse(giatri) : 0;
    }
    [ObservableProperty]
    private int maxStudentInClass;
    private ClassCard currentClass;
    public ClassCard CurrentClass
    {
        get { return currentClass; }
        set { currentClass = value; OnPropertyChanged(); }
    }
    public ObservableCollection<StudentWithClassItem> StudentEmptyDisplay { get; set; }
    public List<ClassCard> ClassCardList { get; set; }
    private Namhoc currentNamhoc;
    private int minKhoi;
    private int selectedKhoi;
    private int currentIndex;
    [ObservableProperty]
    private int selectedIndexTab;
    private ObservableCollection<int> khoiList = new ObservableCollection<int>();
    private void InitClass()
    {
        try
        {
                StudentEmptyDisplay.Clear();
                if (selectedKhoi == minKhoi)
                {
                    //lay hoc sinh moi
                    var emptyStudent = DataProvider.ins.context.Hocsinhs.Where(x => x.Malhtts.Count == 0).ToList();
                    foreach (var hs in emptyStudent)
                    {
                        StudentEmptyDisplay.Add(new StudentWithClassItem(hs, currentNamhoc));
                    }
                    var lopList = DataProvider.ins.context.Lops.Where(x => x.Khoi == selectedKhoi).ToList();
                    foreach (var lop in lopList)
                    {
                        ObservableCollection<StudentWithClassItem> studentInClass = new ObservableCollection<StudentWithClassItem>();
                        //lay hoc sinh o lai lop
                        var lhtt = DataProvider.ins.context.Lophocthuctes.Where(x => x.Manh == currentNamhoc.Manh && x.Malop == lop.Malop).FirstOrDefault();
                        if (lhtt != null)
                        {
                            var hocsinh = lhtt.Mahs.Where(x => x.Kqnamhocs.Where(x => x.Manh == currentNamhoc.Manh).FirstOrDefault() != null && x.Kqnamhocs.Where(x => x.Manh == currentNamhoc.Manh).First().MaKetQua == "KQ002");
                            foreach (var hs in hocsinh)
                            {
                                studentInClass.Add(new StudentWithClassItem(hs, currentNamhoc, false));
                            }
                        }
                        ClassCard classCard = new ClassCard(lop, studentInClass, this);
                        ClassCardList.Add(classCard);
                    }
                }
                else
                {
                    // hoc sinh o lop da xoa va len lop
                    var lhtt3 = DataProvider.ins.context.Lophocthuctes.Where(x => x.Manh == currentNamhoc.Manh && x.MalopNavigation.Isdeleted == true && x.MalopNavigation.Khoi == selectedKhoi - 1).ToList();
                    if (lhtt3 != null)
                    {
                        foreach (var lop in lhtt3)
                        {
                            var hss = lop.Mahs.Where(x => x.Kqnamhocs.Where(x => x.Manh == currentNamhoc.Manh).FirstOrDefault() != null && x.Kqnamhocs.Where(x => x.Manh == currentNamhoc.Manh).First().MaKetQua == "KQ001");
                            foreach (var hs in hss)
                            {
                                StudentEmptyDisplay.Add(new StudentWithClassItem(hs, currentNamhoc, false));
                            }
                        }
                    }
                    //hoc sinh o lop da xoa va o lai lop
                    var lhtt4 = DataProvider.ins.context.Lophocthuctes.Where(x => x.Manh == currentNamhoc.Manh && x.MalopNavigation.Isdeleted == true && x.MalopNavigation.Khoi == selectedKhoi).ToList();
                    if (lhtt4 != null)
                    {
                        foreach (var lop in lhtt4)
                        {
                            var hss = lop.Mahs.Where(x => x.Kqnamhocs.Where(x => x.Manh == currentNamhoc.Manh).FirstOrDefault() != null && x.Kqnamhocs.Where(x => x.Manh == currentNamhoc.Manh).First().MaKetQua == "KQ002");
                            foreach (var hs in hss)
                            {
                                StudentEmptyDisplay.Add(new StudentWithClassItem(hs, currentNamhoc, false));
                            }
                        }
                    }
                    // hoc sinh o lop chua xoa
                    var lopList = DataProvider.ins.context.Lops.Where(x => x.Khoi == selectedKhoi && x.Isdeleted == false).ToList();
                    foreach (var lop in lopList)
                    {
                        ObservableCollection<StudentWithClassItem> studentInClass = new ObservableCollection<StudentWithClassItem>();
                        //lay hoc sinh cu
                        var lhtt = DataProvider.ins.context.Lophocthuctes.Where(x => x.Manh == currentNamhoc.Manh && x.MalopNavigation.Khoi == selectedKhoi - 1 && x.MalopNavigation.Tenlop == lop.Tenlop).FirstOrDefault();
                        if (lhtt != null)
                        {
                            var hss = lhtt.Mahs.Where(x => x.Kqnamhocs.Where(x => x.Manh == currentNamhoc.Manh).FirstOrDefault() != null && x.Kqnamhocs.Where(x => x.Manh == currentNamhoc.Manh).First().MaKetQua == "KQ001");
                            foreach (var hs in hss)
                            {
                                studentInClass.Add(new StudentWithClassItem(hs, currentNamhoc, false));
                            }
                        }
                        //lay hoc sinh o lai lop
                        var lhtt2 = DataProvider.ins.context.Lophocthuctes.Where(x => x.Manh == currentNamhoc.Manh && x.Malop == lop.Malop).FirstOrDefault();
                        if (lhtt2 != null)
                        {
                            var hocsinh2 = lhtt2.Mahs.Where(x => x.Kqnamhocs.Where(x => x.Manh == currentNamhoc.Manh).First().MaKetQua == "KQ002");
                            foreach (var hs in hocsinh2)
                            {
                                studentInClass.Add(new StudentWithClassItem(hs, currentNamhoc, false));
                            }
                        }

                        ClassCard classCard = new ClassCard(lop, studentInClass, this);
                        ClassCardList.Add(classCard);
                    }
                }
        }
        catch (Exception ex)
        {
            return;
        }
    }
    [RelayCommand]
    private void checkedAll()
    {
        foreach (var student in CurrentClass.StudentInClassDisplay)
        {
            student.IsSelected = true;
        }
    }
    [RelayCommand]
    private void addStudentToCurrentClass()
    {
        
        ObservableCollection<StudentWithClassItem> studentInClassDisplayTemp = new ObservableCollection<StudentWithClassItem>(StudentEmptyDisplay);
        foreach (var student in StudentEmptyDisplay)
        {
            if (student.getSelected() == true)
            {
                if(CurrentClass.StudentInClassDisplay.Count < maxStudentInClass)
                {
                    student.setSelected();
                    CurrentClass.AddStudent(student);
                    studentInClassDisplayTemp.Remove(student);
                }
                else
                {
                    student.setSelected();
                }
            }
        }
        //StudentEmptyDisplay = new ObservableCollection<StudentWithClassItem>();
        StudentEmptyDisplay = new ObservableCollection<StudentWithClassItem>(studentInClassDisplayTemp);
        OnPropertyChanged(nameof(CurrentClass));
        OnPropertyChanged(nameof(StudentEmptyDisplay));

    }
    public void addStudentToEmptyClass(StudentWithClassItem student)
    {
        StudentEmptyDisplay.Add(student);
    }
    public void setCurrentClass(ClassCard classCard)
    {
        CurrentClass = classCard;
        SelectedIndexTab = 0;
    }
    [RelayCommand]
    private void goNext()
    {
        SchoolYearViewModel.Ins.goToClassList(currentIndex);
    }
    [RelayCommand]
    private void goBack()
    {
        SchoolYearViewModel.Ins.goBackToClassList(currentIndex);
    }
}