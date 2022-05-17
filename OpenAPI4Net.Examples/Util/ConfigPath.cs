using System.IO;

namespace OpenAPI4Net.Examples
{
    /// <summary>
    /// 用以记录配置文件位置
    /// </summary>
    public static class ConfigPath
    {

        private static string _path;
        private static string _defaultLogPath;
        private static string _appPath;

        public static string AppPath
        {
            get
            {
                if (System.String.IsNullOrEmpty(ConfigPath._appPath))
                {
                    ConfigPath._appPath = new DirectoryInfo(
                        System.AppDomain.CurrentDomain.SetupInformation.ApplicationBase).FullName;
                }
                return ConfigPath._appPath;
            }
        }

        /// <summary>
        /// 日志文件所在默认文件夹
        /// </summary>
        public static string DefaultLogPath
        {
            get
            {
                //配置文件目录为：安装目录\Log
                if (_defaultLogPath == null)
                {
                    _defaultLogPath = System.IO.Path.Combine(ConfigPath.AppPath, @"Log");
                }
                return _defaultLogPath;
            }
        }

        /// <summary>
        /// 配置文件所在文件夹
        /// </summary>
        public static string Path
        {
            get
            {
                //配置文件目录为：安装目录\config
                if (_path == null)
                {
                    _path = System.IO.Path.Combine(ConfigPath.AppPath, @"Config\");

                }
                return _path;
            }
            set
            {
                _path = value;
            }
        }
        
        /// <summary>
        /// 获取配置文件全路经
        /// </summary>
        public static string File
        {
            get { return GetFullName("Globals.xml"); }
        }

        /// <summary>
        /// 获取配置文件全路经
        /// </summary>
        /// <param name="fileName"></param>
        /// <returns></returns>
        private static string GetFullName(string fileName)
        {
            return System.IO.Path.Combine(Path, fileName);
        }
    }
}
