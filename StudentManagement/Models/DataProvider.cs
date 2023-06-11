using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagement.Models
{
    public class DataProvider

    {
        public QUANLYHOCSINHContext context;
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
            context = new QUANLYHOCSINHContext();
        }
    }

}
