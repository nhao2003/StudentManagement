﻿using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagement.ViewModel
{
    public partial class ClassListNewStudentRightViewModel: ObservableObject
    {
        [ObservableProperty]
        private ClassListViewModel parent;
        public ClassListNewStudentRightViewModel(ClassListViewModel parent) {
            this.parent = parent;        
        }
    }
}
