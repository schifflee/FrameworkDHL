using OpenQA.Selenium;
using SOW.Automation.Common;
using SOW.Automation.Common.Web;
using SOW.Automation.Driver.Selenium;

namespace SOW.Automation.Service.Web
{
    public class WebService
    {
        public WebDriverContextInfo DriverContextInfo { get;  set; }

        public IWebBaseElement<IWebElement> BaseElement { get; private set; }

        public WebService(WebDriverContextInfo context)
        {
            this.DriverContextInfo = context;

            InitializeDriver();
        }

        private void InitializeDriver()
        {
            switch (this.DriverContextInfo.Driver)
            {
                case DriverEnum.Selenium:
                    BaseElement = new SeleniumAutomate<IWebElement>(this.DriverContextInfo);
                    break;
            }
        }
    }
}
