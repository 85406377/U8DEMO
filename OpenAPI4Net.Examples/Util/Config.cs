
namespace OpenAPI4Net.Examples
{
    #region imports

    using System;
    using System.Xml;
    using System.IO;

    #endregion

    public class Config
    {
        private static readonly Config instance = new Config();

        private static XmlDocument _configDocument;
        private static DateTime _lastModifiedTime;
        private string appKey;
        private string appSecret;
        private string fromAccount;
        private string toAccount;
        private string baseUrl;

        private static bool Dirty
        {
            get
            {
                FileInfo fi = new FileInfo(ConfigPath.File);
                if (!_lastModifiedTime.Equals(fi.LastWriteTime))
                {
                    return true;
                }
                return false;
            }
        }

        private Config(){}

        public static Config GetInstance()
        {
            return instance;
        }

        private static XmlDocument ConfigDocument
        {
            get
            {
                if (_configDocument == null || Config.Dirty)
                {
                    _configDocument = new XmlDocument();
                    _configDocument.Load(ConfigPath.File);
                    FileInfo fi = new FileInfo(ConfigPath.File);
                    _lastModifiedTime = fi.LastWriteTime;
                }
                return _configDocument;
            }
        }


        private static void Load()
        {
            Config.instance.appKey = "";
            Config.instance.appSecret = "";
            Config.instance.fromAccount = "";
            Config.instance.toAccount = "";
            Config.instance.baseUrl = "";

            XmlNode e = Config.ConfigDocument.SelectSingleNode("/config/sdk");
            if (e != null)
            {
                XmlNode e2 = e.SelectSingleNode("app_key");
                if (e2 != null)
                    Config.instance.appKey = e2.InnerText;

                e2 = e.SelectSingleNode("app_secret");
                if (e2 != null)
                    Config.instance.appSecret = e2.InnerText;

                e2 = e.SelectSingleNode("from_account");
                if (e2 != null)
                    Config.instance.fromAccount = e2.InnerText;

                e2 = e.SelectSingleNode("to_account");
                if (e2 != null)
                    Config.instance.toAccount = e2.InnerText;

                e2 = e.SelectSingleNode("base_url");
                if (e2 != null)
                    Config.instance.baseUrl = e2.InnerText;
                
            }
        }

        public string AppKey
        {
            get
            {
                if (_configDocument == null || Config.Dirty)
                    Load();
                return Config.instance.appKey;
            }
        }

        public string AppSecret
        {
            get 
            {
                if (_configDocument == null || Config.Dirty)
                    Load(); return Config.instance.appSecret;
            }
        }

        public string FromAccount
        {
            get 
            {
                if (_configDocument == null || Config.Dirty)
                    Load();
                return Config.instance.fromAccount; 
            }
        }

        public string ToAccount
        {
            get 
            {
                if (_configDocument == null || Config.Dirty)
                    Load();
                return Config.instance.toAccount; 
            }
        }

        public string BaseUrl
        {
            get 
            {
                if (_configDocument == null || Config.Dirty)
                    Load();
                return Config.instance.baseUrl; 
            }
        }
    }
}
