using System;
using System.IO;

namespace TencentCloudMPSample.Utilities
{
    public static class Server
    {
        private static string _appDomainAppPath;
        public static string AppDomainAppPath
        {
            get
            {
                if (_appDomainAppPath == null)
                {
                    _appDomainAppPath = AppContext.BaseDirectory; //dll所在目录：;
                }
                return _appDomainAppPath;
            }
            set
            {
                _appDomainAppPath = value;
                if (!_appDomainAppPath.EndsWith("/"))
                {
                    _appDomainAppPath += "/";
                }
            }
        }

        private static string _webRootPath;
        /// <summary>
        /// wwwroot文件夹目录（专供ASP.NET Core MVC使用）
        /// </summary>
        public static string WebRootPath
        {
            get
            {
                if (_webRootPath == null)
                {
                    _webRootPath = AppDomainAppPath + "wwwroot/";//asp.net core的wwwroot文件目录结构不一样
                }
                return _webRootPath;
            }
            set { _webRootPath = value; }
        }

        public static string GetMapPath(string virtualPath)
        {
            if (virtualPath == null)
            {
                return "";
            }
            else if (virtualPath.StartsWith("~/"))
            {
                return virtualPath.Replace("~/", AppDomainAppPath);
            }
            else
            {
                return Path.Combine(AppDomainAppPath, virtualPath);
            }
        }

    }
}
