using CommunityToolkit.Mvvm.ComponentModel;
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
