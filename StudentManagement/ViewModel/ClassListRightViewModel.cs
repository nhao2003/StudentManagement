using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagement.ViewModel
{
    public partial class ClassListRightViewModel: ObservableObject
    {
        [ObservableProperty]
        private ClassListViewModel parent;
        public ClassListRightViewModel(ClassListViewModel parent) {
            this.parent = parent;
        }
    }
}
