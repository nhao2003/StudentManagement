using System.Runtime.CompilerServices;

namespace StudentManagement.Model;

public class DataProvider
  
{
    public QUANLYHOCSINH2Context context;
    private static DataProvider? _ins;
    public static DataProvider ins { 
        get {
            if (_ins == null)
            {
                _ins = new DataProvider();
            }
            return _ins;
        }
    }
    private DataProvider() {
        //call DB
        context = new QUANLYHOCSINH2Context();
    }
}
