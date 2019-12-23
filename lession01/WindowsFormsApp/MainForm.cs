using CefSharp.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp
{
    public partial class MainForm : Form
    {
        private ChromiumWebBrowser webBrowser;
        public MainForm()
        {
            InitializeComponent();
            this.Load += Form1_Load;
            this.FormClosing += MainForm_FormClosing;

        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (webBrowser != null)
            {
                webBrowser.GetBrowser().CloseBrowser(true);
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            webBrowser = new ChromiumWebBrowser("http://localhost:4200/");
            webBrowser.Dock = DockStyle.Fill;
            this.bwpanel.Controls.Add(webBrowser);
            webBrowser.Load("http://localhost:4200/");
        }
    }
}
