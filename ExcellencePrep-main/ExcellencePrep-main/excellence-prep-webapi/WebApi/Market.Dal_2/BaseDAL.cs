using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utilities_Log;

namespace Market.Dal_2
{
    public class BaseDAL
    {
        public static LogManager Log;
        public BaseDAL(LogManager log) { Log = log; }
        public BaseDAL() { }
    }
}
