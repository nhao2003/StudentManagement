using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
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
        this.currentNamhoc = DataProvider.ins.context.Namhocs.ToList().First();
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
    }
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
        if (selectedKhoi == minKhoi)
        {
            //lay hoc sinh trong
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
                if(lhtt != null)
                {

                    var hocsinh = lhtt.Mahs. Where(x => x.Kqnamhocs.Where(x => x.Manh == currentNamhoc.Manh).FirstOrDefault() != null && x.Kqnamhocs.Where(x => x.Manh == currentNamhoc.Manh).First().MaKetQua == "KQ002");
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
            var lopList = DataProvider.ins.context.Lops.Where(x => x.Khoi == selectedKhoi).ToList();
            foreach (var lop in lopList)
            {
                ObservableCollection<StudentWithClassItem> studentInClass = new ObservableCollection<StudentWithClassItem>();
                //lay hoc sinh cu
                var lhtt = DataProvider.ins.context.Lophocthuctes.Where(x => x.Manh == currentNamhoc.Manh && x.MalopNavigation.Khoi == selectedKhoi - 1 && x.MalopNavigation.Tenlop == lop.Tenlop).FirstOrDefault();
                if(lhtt != null)
                {
                    var hss = lhtt.Mahs.Where(x => x.Kqnamhocs.Where(x => x.Manh == currentNamhoc.Manh).FirstOrDefault() != null && x.Kqnamhocs.Where(x => x.Manh == currentNamhoc.Manh).First().MaKetQua == "KQ001");
                    foreach (var hs in hss)
                    {
                        studentInClass.Add(new StudentWithClassItem(hs, currentNamhoc, false));
                    }
                }
                //lay hoc sinh o lai lop
                var lhtt2 = DataProvider.ins.context.Lophocthuctes.Where(x => x.Manh == currentNamhoc.Manh && x.Malop == lop.Malop).FirstOrDefault();
                if(lhtt2 != null)
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
                student.setSelected();
                currentClass.AddStudent(student);
                studentInClassDisplayTemp.Remove(student);
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