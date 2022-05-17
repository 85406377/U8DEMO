
namespace Yonyou.OpenApi.Util
{
    #region Imports

    using System;
    using System.IO;
    using System.Xml;

    #endregion

    /// <summary>
    /// Log 的摘要说明。
    /// </summary>
    public class Log
    {
        private bool infolog = true;//是否写信息日志
        private bool errorlog = false;//是否写出错日志
        private bool debuglog = false;//是否写调试日志
        private int maxlength = 9999;//每条信息的最大长度
        private string logFile = ""; //日志文件

        public Log()
        {
            try
            {
                ReadSettings();
            }
            catch { }
        }

        /// <summary>
        /// 读取日志配置信息
        /// </summary>
        private void ReadSettings()
        {
            //读取配置文件
            try
            {
                XmlDocument tempDom = new XmlDocument();
                tempDom.Load(ConfigPath.File);
                XmlElement tempNode = (XmlElement)tempDom.DocumentElement.SelectSingleNode("/config/log");

                //取出日志开关
                if (tempNode.Attributes.GetNamedItem("info").Value.Trim() == "true")
                {
                    infolog = true;
                }
                else
                {
                    infolog = false;
                }
                if (tempNode.Attributes.GetNamedItem("error").Value.Trim() == "true")
                {
                    errorlog = true;
                }
                else
                {
                    errorlog = false;
                }
                if (tempNode.Attributes.GetNamedItem("debug").Value.Trim() == "true")
                {
                    debuglog = true;
                }
                else
                {
                    debuglog = false;
                }

                //取出每条日志信息的最大长度
                string maxLengthString = (tempNode.GetAttribute("max_length") + "").Trim();
                if (maxLengthString.Length == 0)
                {
                    maxLengthString = "200";
                }

                maxlength = Int32.Parse(maxLengthString);
                maxlength = (maxlength <= 0 ? 200 : maxlength);

                //取日志文件
                logFile = System.Convert.ToString(tempNode.Attributes.GetNamedItem("file").Value.Trim());

                if (String.IsNullOrEmpty(logFile) || logFile == "")
                {
                    string parentPath = ConfigPath.DefaultLogPath;
                    if (parentPath != "")
                    {
                        if (!Directory.Exists(parentPath))
                        {
                            Directory.CreateDirectory(parentPath);
                        }

                        logFile = Path.Combine(parentPath, @"openapi_sdk.log");
                    }
                }
            }
            catch
            {

            }

        }

        /// <summary>
        /// 写入普通日志 
        /// </summary>
        /// <param name="message">日志信息</param>

        public void Info(string message)
        {
            if (infolog)
            {
                WriteLog("|INFO|" + message);
            }
        }

        /// <summary>
        /// 写入错误日志
        /// </summary>
        /// <param name="ex">异常对象</param>
        /// <param name="trace">是否记录堆栈信息</param>
        public void Error(Exception ex, bool trace = true)
        {
            if (errorlog)
            {
                string msg;
                if (trace)
                {
                    msg = ex.Message + ex.StackTrace;
                }
                else
                {
                    msg = ex.Message;
                }
                WriteLog("|ERROR|Exception:" + msg);
            }
        }

        /// <summary>
        /// 写入错误日志，附带哪个程序抛出
        /// </summary>
        /// <param name="program">抛出错误日志的程序</param>
        /// <param name="ex">异常对象</param>
        public void Error(string program, Exception ex)
        {
            if (errorlog)
            {
                WriteLog("|ERROR|[" + program + "]Exception:" + ex.Message);
            }
        }

        /// <summary>
        /// 写入调试信息
        /// </summary>
        /// <param name="source">调试位置所在的代码文件和函数</param>
        /// <param name="message">信息内容</param>
        public void Debug(string source, string message)
        {
            if (debuglog)
            {
                WriteLog("|DEBUG|[" + source + "]" + message);
            }
        }


        /// <summary> 
        ///写日志，出错了不处理
        /// </summary> 
        /// <param name="message">log message</param> 
        //Write Log 
        private void WriteLog(string message)
        {
            try
            {
                if (maxlength > 0)
                {
                    if (message.Length > maxlength)
                    {
                        message = message.Substring(0, maxlength);
                    }
                }

                string context = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss:ffff") + message;
                System.Console.Out.WriteLine(context);
                if (File.Exists(logFile))
                {
                    StreamWriter sw = File.AppendText(logFile);
                    sw.WriteLine(context);
                    sw.Close();
                }
                else
                {
                    StreamWriter sw = File.CreateText(logFile);
                    sw.WriteLine(context);
                    sw.Close();
                }
            }
            catch
            {
            }
        }

    }
}
