﻿using CommunityToolkit.Mvvm.ComponentModel;

namespace StudentManagement.Object
{
    public partial class ProgramConfig : ObservableObject
    {
        [ObservableProperty]
        private string id;
        [ObservableProperty]
        private string name;
        [ObservableProperty]
        private string number;
        [ObservableProperty]
        private string point;

        public ProgramConfig(string id, string name, string number, string point)
        {
            this.id = id;
            this.name = name;
            this.number = number;
            this.point = point;
        }
    }
}
