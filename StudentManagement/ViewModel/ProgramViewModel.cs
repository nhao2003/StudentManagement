using CommunityToolkit.Mvvm.ComponentModel;
using StudentManagement.Object;
using System.Collections.ObjectModel;

namespace StudentManagement.ViewModel
{
    public partial class ProgramViewModel : ObservableObject
    {
        [ObservableProperty]
        private ObservableCollection<ProgramConfig> programConfigs = new ObservableCollection<ProgramConfig>()
    {
        new ProgramConfig("1","Cơ bản","4","5"),
        new ProgramConfig("2","Nâng cao","4","5"),
        new ProgramConfig("3","Năng khiếu","4","5"),
    };
    }
}
