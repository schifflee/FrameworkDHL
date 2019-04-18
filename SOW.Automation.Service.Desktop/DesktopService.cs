using SOW.Automation.Common;
using SOW.Automation.Common.Desktop;
using SOW.Automation.Driver.TestStack;
using TestStack.White.UIItems;

namespace SOW.Automation.Service.Desktop
{
    public class DesktopService
    {
        private DesktopDriverContextInfo _driverContextInfo;

        public DesktopDriverContextInfo DriverContextInfo
        {
            get { return _driverContextInfo; }
            set { _driverContextInfo = value; }
        }

        public IDesktopBaseElement<IUIItem> BaseElement;

        public DesktopService(DesktopDriverContextInfo driverContextInfo)
        {
            this.DriverContextInfo = driverContextInfo;

            InitializeDriver();
        }

        private void InitializeDriver()
        {
            try
            {
                switch (this.DriverContextInfo.Driver)
                {
                    case DriverEnum.TestStack:
                        BaseElement = new TestStackAutomate<IUIItem>(this.DriverContextInfo);
                        break;
                        //TODO
                        //case DriverEnum.UIAutomation:
                        //    BaseWebElement = new TestStackAutomate<IUIItem>(this.DriverContextInfo);
                        //break;
                }
            }
            catch (System.Exception)
            {
                throw;
            }
        }

        private void UpdateDriver(IDesktopBaseElement<object> desktopExtendElement)
        {
            try
            {
                //switch (this.DriverContextInfo.Driver)
                //{
                //    //case DriverEnum.TestStack:
                //    //    BaseElement = (T)desktopExtendElement;
                //    //break;
                //        //TODO
                //        //case DriverEnum.UIAutomation:
                //        //    BaseWebElement = new TestStackAutomate<IUIItem>(this.DriverContextInfo);
                //        //break;
                //}
            }
            catch (System.Exception)
            {
                throw;
            }
        }
    }
}
