using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Market.Dal
{
    public class BaseDAL
    {
        public static LogManager Log;
        public BaseDAL(LogManager log) { Log = log; }
        public BaseDAL() { }
    }
}
