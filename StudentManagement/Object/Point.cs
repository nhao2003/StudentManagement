using CommunityToolkit.Mvvm.ComponentModel;
using StudentManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagement.Object
{
    public partial class Point: ObservableObject
    {
        [ObservableProperty]
        private Diemmonhoc diem;
        private string diemDisplay;
        public string Diemdisplay
        {
            get
            {
                return diemDisplay;
            }
            set
            {
                //diemDisplay = value;
                //OnPropertyChanged();
                double diemdouble;
                if (double.TryParse(value, out diemdouble))
                {
                    diemdouble = Math.Round(diemdouble, 1);
                     diemdouble = Math.Round(diemdouble * 2, MidpointRounding.AwayFromZero) / 2;
                    if (diemdouble >= 0 && diemdouble <= 10)
                    {

                        diem.Diem = diemdouble;
                        diemDisplay = diemdouble.ToString();
                        OnPropertyChanged();
                    }
                    else
                    {
                        return;
                    }

                }
                else
                {
                    // Conversion failed, handle the error
                }

            }

        }

        public Point(Diemmonhoc diem)
        {
            this.diem = diem;
            Diemdisplay = diem.Diem.ToString();
        }
    }
}
