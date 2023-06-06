using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Messaging;
using CommunityToolkit.Mvvm.Messaging.Messages;
using StudentManagement.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagement.Object
{
    public partial class MonHocItemDataGrid : ObservableObject
    {
        [ObservableProperty]
        private bool isCheckedMonHoc;
        [ObservableProperty]
        private string maMonHoc;
        [ObservableProperty]
        private string tenMonHoc;

        private Monhoc monhoc;

        partial void OnIsCheckedMonHocChanged(bool oldValue, bool newValue)
        {
            WeakReferenceMessenger.Default.Send(new PropertyChangedMessage<bool>(this, "IsCheckedMonHoc", oldValue, newValue));
        }

        [NotNull]
        public Monhoc Monhoc
        {
            set { monhoc = value; }
            get { return monhoc; }
        }
        public MonHocItemDataGrid(Monhoc monhoc)
        {
            isCheckedMonHoc = false;
            maMonHoc = monhoc.Mamh;
            tenMonHoc = monhoc.Tenmh;
            Monhoc = monhoc;
        }
    }
}
