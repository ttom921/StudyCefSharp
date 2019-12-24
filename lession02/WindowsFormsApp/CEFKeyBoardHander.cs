using CefSharp;
using System;
using System.Windows.Forms;

namespace WindowsFormsApp
{
    public class CEFKeyBoardHander : IKeyboardHandler
    {
        public bool OnKeyEvent(IWebBrowser chromiumWebBrowser, IBrowser browser, KeyType type, int windowsKeyCode, int nativeKeyCode, CefEventFlags modifiers, bool isSystemKey)
        {
            if(type== KeyType.KeyUp && Enum.IsDefined(typeof(Keys), windowsKeyCode))
            {
                var key = (Keys)windowsKeyCode;
                switch (key)
                {
                    case Keys.F5:
                        if(modifiers == CefEventFlags.ControlDown)
                        {
                            //MessageBox.Show("ctrl+f5");
                            browser.Reload(true);//強制忽略緩存
                        }
                        else
                        {
                            //MessageBox.Show("f5");
                            browser.Reload();
                        }
                        break;
#if DEBUG
                    case Keys.F12:
                        browser.ShowDevTools();
                        break;
#endif
                }
            }
            return false;
        }

        public bool OnPreKeyEvent(IWebBrowser chromiumWebBrowser, IBrowser browser, KeyType type, int windowsKeyCode, int nativeKeyCode, CefEventFlags modifiers, bool isSystemKey, ref bool isKeyboardShortcut)
        {
            return false;
        }
    }
}
