using SOW.Automation.Common.Desktop;
using SOW.Automation.Common.Web;
using SOW.Automation.Service.Desktop;
using SOW.Automation.Service.Web;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOW.Automation.Interface.DLx.Pages
{
	public  class PageBase
	{
		public WebService WebAutomationService { get; set; }
		public DesktopService DeskAutomationService { get; set; }

		public PageBase(WebDriverContextInfo driverContextInfo, DesktopDriverContextInfo desktopDriverContextInfo)
		{
			this.WebAutomationService = new WebService(driverContextInfo);
			this.DeskAutomationService = new DesktopService(desktopDriverContextInfo);
		}
		public PageBase(WebService webService, DesktopService desktopService)
		{
			this.WebAutomationService = webService;
			this.DeskAutomationService = desktopService;
		}
        
		public void OpenURL(string url, int timeout)
		{
			this.WebAutomationService.BaseElement.OpenURL(url, timeout);
		}

		public void Close(int timeout)
		{
			this.WebAutomationService.BaseElement.CloseProcess(timeout);
		}
	}
}
