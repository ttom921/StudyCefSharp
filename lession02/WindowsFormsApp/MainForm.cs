using CefSharp;
using CefSharp.WinForms;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApp.Controls;

namespace WindowsFormsApp
{

    public partial class MainForm : Form
    {
        private ChromiumWebBrowser chromeBrowser;
        public MainForm()
        {
            InitializeComponent();
            //初始化cefSharp
            InitializeChromium();
            //註冊物件在JavaScript叫cefCustomObject,在js函數里面只能駝峰寫法
            chromeBrowser.RegisterJsObject("cefCustomObject", new CefCustomObject(chromeBrowser, this));
            this.Load += Form1_Load;
            this.FormClosing += MainForm_FormClosing;
        }

        private void InitializeChromium()
        {
            CefSettings settings = new CefSettings()
            {
                //是否使用cache
                //By default CefSharp will use an in-memory cache, you need to specify a Cache Folder to persist data
                CachePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "CefSharp\\Cache"),
                //LogSeverity = LogSeverity.Verbose,
            };
            ////設置是否使用GPU
            ////settings.CefCommandLineArgs.Add("disable-gpu", "1");
            ////設定是否使用代理服務
            ////settings.CefCommandLineArgs.Add("no-proxy-server", "1");

            ////設定是否啟動js交互，假如需要原生與js方法互調，則需要設置為true
            CefSharpSettings.LegacyJavascriptBindingEnabled = true;
            //初始化
            Cef.Initialize(settings, performDependencyCheck: true, browserProcessHandler: null);
            chromeBrowser = new ChromiumWebBrowser("http://localhost:4200/");
            this.bwpanel.Controls.Add(chromeBrowser);
            chromeBrowser.Dock = DockStyle.Fill;
            chromeBrowser.KeyboardHandler = new CEFKeyBoardHander();
        }
        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Cef.Shutdown();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            chromeBrowser.ExecuteScriptAsync("callByNet('參數1','參數2')");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //dynamic MyDynamic = new System.Dynamic.ExpandoObject();
            //MyDynamic.name = "orange";
            //MyDynamic.price = 100;
            dynamic MyDynamic = new
            {
                name = "orange",
                price = 100
            };
            string output = JsonConvert.SerializeObject(MyDynamic);
            object[] args = { output };
            //string strjs = $"callbyNetobj({output})";
            chromeBrowser.ExecuteScriptAsync("callbyNetobj", args);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            var dlist = new List<dynamic>();
            for (int i = 0; i < 3; i++)
            {
                dynamic dyna = new
                {
                    name = $"cnetname={i}",
                    price = 100 + i * 10
                };
                dlist.Add(dyna);
            }
            string output = JsonConvert.SerializeObject(dlist);
            //Console.WriteLine(output);
            object[] args = { output };
            chromeBrowser.ExecuteScriptAsync("callbyNetobj", args);
        }
    }
}
