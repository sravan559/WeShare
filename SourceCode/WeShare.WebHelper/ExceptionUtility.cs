using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace WeShare.WebHelper
{
    public sealed class ExceptionUtility
    {
        public static void LogException(Exception exception, string sourceMethodName)
        {
            StreamWriter swErrorWriter = null;
            try
            {
                //naming the log file by appending current date
                string logFile = AppDomain.CurrentDomain.BaseDirectory + "\\App_Data\\" + "LogFile_" + DateTime.Today.ToString("MMddyyyy") + ".txt";

                FileInfo objFile = new FileInfo(logFile);
                //Check of the file with the given name already exists at the given location
                if (!objFile.Exists)
                {
                    //Creating the file with the above mentioned name since no file is found with the given name
                    FileStream objFileStream = objFile.Create();
                    objFileStream.Close();
                }

                swErrorWriter = objFile.AppendText();
                swErrorWriter.WriteLine("********** {0} **********", DateTime.Now);
                if (exception.InnerException != null)
                {
                    swErrorWriter.Write("Inner Exception Type: ");
                    swErrorWriter.WriteLine(exception.InnerException.GetType().ToString());
                    swErrorWriter.Write("Inner Exception: ");
                    swErrorWriter.WriteLine(exception.InnerException.Message);
                    swErrorWriter.Write("Exception Source: ");
                    swErrorWriter.WriteLine(exception.InnerException.Source);
                    if (exception.InnerException.StackTrace != null)
                    {
                        swErrorWriter.Write("Inner Stack Trace: ");
                        swErrorWriter.WriteLine(exception.InnerException.StackTrace);
                    }
                }
                swErrorWriter.Write("Exception Type: ");
                swErrorWriter.WriteLine(exception.GetType().ToString());
                swErrorWriter.WriteLine("Exception Message: " + exception.Message);
                if (!string.IsNullOrEmpty(sourceMethodName))
                    swErrorWriter.WriteLine("Source: " + sourceMethodName);
                swErrorWriter.WriteLine("Stack Trace: ");
                if (exception.StackTrace != null)
                {
                    swErrorWriter.WriteLine(exception.StackTrace);
                    swErrorWriter.WriteLine();
                }
            }
            finally
            {
                swErrorWriter.Close();
            }
        }
    }
}
