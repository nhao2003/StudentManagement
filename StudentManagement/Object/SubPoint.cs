using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using StudentManagement.Models;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagement.Object
{
    public partial class SubPoint: ObservableObject
    {
        [ObservableProperty]
        private Diemmonhoc diem;
        [ObservableProperty]
        private int cot;
        private PointType parent;
        public SubPoint(Diemmonhoc diem, PointType parent) { this.diem = diem; this.cot = diem.Lankt + 1; this.parent = parent; }

        [RelayCommand]
        private void deleteDiem()
        {
            parent.DeleteDiem(this);
        }

    }
}
