using System;
using System.Collections.Generic;
using System.Text;

namespace OpenBrowserFromConsole.Intefrface
{
    public interface IUsefulChromeFlags
    {
        void NewWindow(string url,bool isNewWindow=false);
        
    }
}
