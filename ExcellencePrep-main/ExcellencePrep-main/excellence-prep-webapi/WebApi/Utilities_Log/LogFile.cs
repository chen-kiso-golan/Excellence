using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace Utilities_Log
{
    public class LogFile: ILogger
    {
        private string fileName;
        public string FileName
        {
            get { return fileName; }
            set { fileName = value; }
        }

        private static int count = 0;
        private static int MaxFileSize = 1024*1024*5;

        public void Init() 
        {
            FileName = $"Log{count}.txt";
            using (File.Create(FileName)) { }
        }
        public void LogEvent(string msg)
        {
            try
            {
                using (StreamWriter sw = new StreamWriter(FileName, true))
                {
                    sw.WriteLine(msg + DateTime.Now);
                }
                
            }
            catch (Exception ex)
            {
                LogException($@"An Exception occurred while initializing the {ex.StackTrace} : {ex.Message}", ex);
            }
        }
        public void LogError(string msg)
        {
            try
            {
                using (StreamWriter sw = new StreamWriter(FileName, true))
                {
                    sw.WriteLine(msg + DateTime.Now);
                }

            }
            catch (Exception ex)
            {
                LogException($@"An Exception occurred while initializing the {ex.StackTrace} : {ex.Message}", ex);
            }
        }
        public void LogException(string msg, Exception exce)
        {
            try
            {
                using (StreamWriter sw = new StreamWriter(FileName, true))
                {
                    sw.WriteLine(msg + DateTime.Now);
                    sw.WriteLine(exce.ToString() + DateTime.Now);
                }

            }
            catch (Exception ex)
            {
                LogException($@"An Exception occurred while initializing the {ex.StackTrace} : {ex.Message}", ex);
            }
        }
        public void LogCheckHouseKeeping()
        {
            FileInfo file = new FileInfo(FileName);
            try
            {
                if (file.Length > MaxFileSize) // check size in bytes
                {
                    count++;
                    Init();
                }
            }
            catch (Exception ex)
            {
                LogException($@"An Exception occurred while initializing the {ex.StackTrace} : {ex.Message}", ex);
            }

        }
    }
}
