﻿using CommunityToolkit.Mvvm.ComponentModel;
using System;

namespace StudentManagement.Model
{
    public partial class Class : ObservableObject
    {
        [ObservableProperty]
        private String id;
        [ObservableProperty]
        private String name;
        [ObservableProperty]
        private String teacherName;
        [ObservableProperty]
        private int numOfStudent;
        [ObservableProperty]
        private int numOfPresent;
        [ObservableProperty]
        private int ratio;

        public Class(string id, string name, string teacherName, int numOfPresent, int numOfStudent)
        {
            this.id = id;
            this.name = name;
            this.teacherName = teacherName;
            this.numOfStudent = numOfStudent;
            this.numOfPresent = numOfPresent;

            ratio = Convert.ToInt32((numOfPresent / Convert.ToDouble(numOfStudent)) * 100);
        }
    }
}
