using CefSharp;
using CefSharp.WinForms;
using System;
using System.IO;
using System.Windows.Forms;

namespace WindowsFormsApp
{
    static class Program
    {
        /// <summary>
        /// 應用程式的主要進入點。
        /// </summary>
        [STAThread]
        static void Main()
        {
            //基本設置
            var settings = new CefSettings()
            {
                //是否使用cache
                //By default CefSharp will use an in-memory cache, you need to specify a Cache Folder to persist data
                CachePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "CefSharp\\Cache")
            };
            //設置是否使用GPU
            //settings.CefCommandLineArgs.Add("disable-gpu", "1");
            //設定是否使用代理服務
            //settings.CefCommandLineArgs.Add("no-proxy-server", "1");
            //設定是否啟動js交互，假如需要原生與js方法互調，則需要設置為true
            CefSharpSettings.LegacyJavascriptBindingEnabled = true;
            //初始化
            Cef.Initialize(settings, performDependencyCheck: true, browserProcessHandler: null);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainForm());
        }
    }
}
