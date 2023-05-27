using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace StudentManagement.ViewModel
{
    public partial class TermSummaryViewModel : ObservableObject
    {
        [ObservableProperty]
        private ObservableCollection<string> yearList;
        [ObservableProperty]
        private string test;
        public TermSummaryViewModel()
        {
            var lophtt = DataProvider.ins.context.Lophocthuctes.Where(x => x.Manh == "NH001").ToList();
            List<List<Hocsinh>> resultList = lophtt.Select(x => x.Mahs.ToList()).ToList();
            Hocsinh hocsinh;
            foreach(var result in resultList)
            {
                int kqdat = result.Select(x => x.Kqhockymonhocs.Where(x => (x.Mamh == "MH001" && x.Mahk == "HK001")).First().DtbmonHocKy > 5).ToList().Count();
                MessageBox.Show(lophtt[resultList.IndexOf(result)].MalopNavigation.Tenlop + " " + kqdat.ToString());
            }
            List<Namhoc> namhocList = DataProvider.ins.context.Namhocs.ToList();
            YearList = new ObservableCollection<string>(namhocList.Select(n => n.Tennamhoc));
        }
    }
}
