using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utilities
{
    public class SingleLogData
    {
        public string LogType ;
        public string msg;
        public Exception exce;
        public SingleLogData(string LogType, string msg, Exception exce) 
        {
            this.LogType = LogType;
            this.msg = msg;
            this.exce = exce;
        }
        public SingleLogData(string LogType, string msg) 
        {
            this.LogType = LogType;
            this.msg = msg;
        }
    }
}
