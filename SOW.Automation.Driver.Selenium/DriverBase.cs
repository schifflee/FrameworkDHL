using OpenQA.Selenium.Support.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOW.Automation.Driver.Selenium
{
    public abstract class DriverBase
    {
        public delegate void MessageHandler(string message);
        public event MessageHandler MessageHandleEvent;
        public EventFiringWebDriver EventWebDriver;
    }
}
