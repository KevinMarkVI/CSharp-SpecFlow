using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium.Remote;

namespace UnitTestProject1
{
    class CustomRemoteWebDriver : RemoteWebDriver
    {
        public CustomRemoteWebDriver(Uri uri, DesiredCapabilities capabilities, TimeSpan commandTimeout) : base(uri, capabilities, commandTimeout) { }

        public SessionId getSessionId()
        {
            return this.SessionId;
        }
    }
}
