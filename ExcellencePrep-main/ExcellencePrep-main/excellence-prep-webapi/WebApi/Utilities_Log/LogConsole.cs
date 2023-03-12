using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utilities_Log
{
    public class LogConsole: ILogger
    {
        public void Init()
        {
        }

        public void LogEvent(string message)
        {
            Console.WriteLine("[EVENT][" + DateTime.Now + "] " + message);
        }


        public void LogError(string message)
        {
            Console.WriteLine("[ERROR][" + DateTime.Now + "] " + message);
        }

        public void LogException(string message, Exception ex)
        {
            Console.WriteLine("[EXCEPTION][" + DateTime.Now + "] " + ex.Message);
        }

        public void LogCheckHouseKeeping()
        {
        }
    }
}
