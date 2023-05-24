using StudentManagement.Object;
using System.Linq;
using System.Runtime.CompilerServices;

namespace StudentManagement.Models;

public class DataProvider

{
    public QUANLYHOCSINHContext Context { get; set; }
    private static DataProvider? _ins;
    public static DataProvider ins
    {
        get
        {
            if (_ins == null)
            {
                _ins = new DataProvider();
            }
            return _ins;
        }

    }
    private DataProvider()
    {
        //call DB
       Context = new QUANLYHOCSINHContext();
        
    }
}
