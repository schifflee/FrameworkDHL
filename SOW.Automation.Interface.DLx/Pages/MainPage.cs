/*
 * Created by SharpDevelop.
 * User: managsow
 * Date: 22/11/2018
 * Time: 15:43
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using SOW.Automation.Common.Desktop;
using SOW.Automation.Interface.DLx.Pages;
using SOW.Automation.Common.Web;
using SOW.Automation.Service.Desktop;
using SOW.Automation.Service.Web;

namespace SOW.Automation.Interface.DLx.Pages
{
	/// <summary>
	/// Description of MainPage.
	/// </summary>
	public class MainPage : PageBase
	{
        public MainPage(WebDriverContextInfo driverContextInfo, 
            DesktopDriverContextInfo desktopDriverContextInfo) 
            : base(driverContextInfo, desktopDriverContextInfo){}

        public MainPage(WebService webservice, DesktopService desktopService) 
            : base(webservice, desktopService) { }
		
		
		private void ClicarPastaDlx()
		{
			this.WebAutomationService.BaseElement.SearchAndClickByID("folderLink_0",this.WebAutomationService.DriverContextInfo.Timeout);
		}
		
		private void ClicarIconeDlxMondelez()
		{
			this.WebAutomationService.BaseElement.SearchAndClickByID("idCitrix.MPS.App.BR-XENAPP-FARM.DLx2009-FULL-PRD-CSM-MONDELEZ-ARAUCARI",this.WebAutomationService.DriverContextInfo.Timeout);
		}
		
		public void AcessarMondelezAraucari()
		{
			ClicarPastaDlx();
			ClicarIconeDlxMondelez();
		}
	}
}
