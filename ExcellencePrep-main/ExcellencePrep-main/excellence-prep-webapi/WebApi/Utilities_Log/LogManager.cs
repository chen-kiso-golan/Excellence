using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Utilities_Log
{
    public class LogManager
    {
        public enum providerType
        {
            File, DB, Console, none
        }

        public static ILogger MyLog { get; set; }

        public LogManager(providerType aProvider) 
        {
            if (aProvider == providerType.File)
            {
                MyLog = new LogFile();
            }
            else if (aProvider == providerType.DB)
            {
                MyLog = new LogDB();
            }
            else if (aProvider == providerType.Console)
            {
                MyLog = new LogConsole();
            }
            else
            {
                MyLog = new LogNone();
            }

            MyLog.Init();
            LogQueue = new Queue<SingleLogData>();
            DequeueMyLog();
            CheckHouseKeeping();
            
        }

        //log queue
        private static System.Collections.Generic.Queue<SingleLogData> LogQueue;

        //thread for dequeue
        private void DequeueMyLog()
        {
            try
            {

                bool stop = false;

                Task.Run(() =>
                {
                    while (!stop)
                    {
                        if (LogManager.LogQueue.Count > 0)
                        {
                            SingleLogData item = LogManager.LogQueue.Dequeue();
                            if (item.LogType == "Event")
                            {
                                MyLog.LogEvent(item.msg);
                            }
                            else if (item.LogType == "Error")
                            {
                                MyLog.LogError(item.msg);
                            }
                            else if (item.LogType == "Exception")
                            {
                                MyLog.LogException(item.msg, item.exce);
                            }
                        }
                        Thread.Sleep(1000);
                    }

                });
            }
            catch (Exception ex)
            {
                LogException($@"An Exception occurred while initializing the {ex.StackTrace} : {ex.Message}", ex);
            }
        }

        private void CheckHouseKeeping()
        {
            try
            {

                bool stop = false;

                Task.Run(() =>
                {
                    while (!stop)
                    {
                        MyLog.LogCheckHouseKeeping();
                        Thread.Sleep(1000 * 60 * 60); //MiliSecond * Second * minute
                    }

                });
            }
            catch (Exception ex)
            {
                LogException($@"An Exception occurred while initializing the {ex.StackTrace} : {ex.Message}", ex);
            }
        }

        public void LogEvent(string msg)
        {
            try
            {
                if (MyLog != null)
                {
                    SingleLogData item = new SingleLogData("Event", msg);
                    LogManager.LogQueue.Enqueue(item);
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
                if (MyLog != null)
                {
                    SingleLogData item = new SingleLogData("Error", msg);
                    LogManager.LogQueue.Enqueue(item);
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
                if (MyLog != null)
                {
                    SingleLogData item = new SingleLogData("Error", msg, exce);
                    LogManager.LogQueue.Enqueue(item);
                }
            }
            catch (Exception ex)
            {
                LogException($@"An Exception occurred while initializing the {ex.StackTrace} : {ex.Message}", ex);
            }
        }

    }

}
