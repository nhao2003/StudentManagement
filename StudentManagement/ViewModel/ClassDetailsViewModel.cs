using CommunityToolkit.Mvvm.ComponentModel;
using StudentManagement.Object;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace StudentManagement.ViewModel
{
    public partial class ClassDetailsViewModel : ObservableObject
    {
        [ObservableProperty]
        Visibility content = Visibility.Visible;
        [ObservableProperty]
        Visibility noContent = Visibility.Hidden;
        [ObservableProperty]
        private String tenLop;
        [ObservableProperty]
        private String giaoVien;
        [ObservableProperty]
        private String nienKhoa;
        [ObservableProperty]
        private ObservableCollection<SubjectTeacher> subjectTeachers = new ObservableCollection<SubjectTeacher>();

        public ClassDetailsViewModel()
        {
            noContent = Visibility.Visible;
            content = Visibility.Hidden;
        }
        public ClassDetailsViewModel(Lophocthucte lophocthucte)
        {
            noContent = Visibility.Hidden;
            content = Visibility.Visible;
            TenLop = lophocthucte.MalopNavigation.Tenlop;
            GiaoVien = DataProvider.ins.context.Giaoviens.Where(x => x.Magv == lophocthucte.Magvcn).FirstOrDefault().UsernameNavigation.Hoten;
            NienKhoa = lophocthucte.ManhNavigation.Tennamhoc;
            List<Phanconggiangday> phanconggiangdays = lophocthucte.Phanconggiangdays.ToList();
            foreach(var phancong in phanconggiangdays)
            {
                String subject = $"{phancong.MamhNavigation.Tenmh}: ";
                String teacher = phancong.MagvNavigation.UsernameNavigation.Hoten;
                SubjectTeachers.Add(new SubjectTeacher(subject,teacher));
            }    
        }
    }
}
