using CefSharp;
using CefSharp.WinForms;
using Newtonsoft.Json;
using System;
using System.Diagnostics;
using System.Windows.Forms;
using System.Collections.Generic;
using Newtonsoft.Json.Linq;
using System.Web;

namespace WindowsFormsApp
{
    public class CefCustomObject
    {
        static ChromiumWebBrowser _instanceBrowser = null;
        static MainForm _instanceMainForm = null;
        public CefCustomObject(ChromiumWebBrowser originalBrowser, MainForm mainForm)
        {
            _instanceBrowser = originalBrowser;
            _instanceMainForm = mainForm;
        }
        public void showDevTools()
        {
            _instanceBrowser.ShowDevTools();
        }
        public void opencmd()
        {
            ProcessStartInfo start = new ProcessStartInfo("cmd.exe", "/c pause");
            Process.Start(start);
        }
        public void showJsArg(string arg1,string arg2)
        {
            string msg= $"arg1={arg1} arg2={arg2}";
            Console.WriteLine(msg);
            MessageBox.Show(msg);
        }
        public void showJsObj(string JsonStr)
        {
            JObject jo = JObject.Parse(JsonStr);
            dynamic dyna = new JObject();
            dyna.name = jo["name"];
            dyna.price = jo["price"];
            Console.Write(dyna.name + ":" + dyna.price + "\r\n");
            Console.WriteLine(jo);
        }
        public void showJsListObj(string JsonStr)
        {

            JArray ja = JArray.Parse(JsonStr);
            var dlist = new List<dynamic>();
            foreach (JObject jo in ja)
            {
                dynamic dyna = new JObject();
                dyna.name = jo["name"];
                dyna.price = jo["price"];
                //Console.WriteLine(jo);
                dlist.Add(dyna);
            }
            foreach (var item in dlist)
            {
                Console.Write(item.name + ":" + item.price + "\r\n");
            }
            //Console.WriteLine(dlist);
        }
    }

}
