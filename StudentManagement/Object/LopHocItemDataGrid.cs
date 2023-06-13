using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Messaging;
using CommunityToolkit.Mvvm.Messaging.Messages;
using StudentManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagement.Object
{
    public partial class LopHocItemDataGrid : ObservableObject
    {
        [ObservableProperty]
        private bool isSelectedLopHoc;
        [ObservableProperty]
        private String maLopHoc;
        [ObservableProperty]
        private int khoi;
        [ObservableProperty]
        private String tenLopHoc;

        partial void OnIsSelectedLopHocChanged(bool oldValue, bool newValue)
        {
            WeakReferenceMessenger.Default.Send(new PropertyChangedMessage<bool>(this, "IsSelectedLopHoc", oldValue, newValue));
        }

        private Lop lopHoc;
        public Lop LopHoc { set { lopHoc = value; } get { return lopHoc; } }

        public LopHocItemDataGrid(Lop lop) {
            isSelectedLopHoc = false;
            this.lopHoc = lop;
            maLopHoc = lop.Malop;
            tenLopHoc = lop.Tenlop;
            khoi = (int) lop.Khoi;
        }
    }
}
