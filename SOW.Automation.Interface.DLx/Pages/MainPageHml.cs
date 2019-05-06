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
	public class MainPageHml : PageBase
	{
		
        public MainPageHml(WebDriverContextInfo driverContextInfo, DesktopDriverContextInfo desktopDriverContextInfo) : base(driverContextInfo, desktopDriverContextInfo) { }

		public MainPageHml(WebService webservice, DesktopService desktopService) : base(webservice, desktopService) { }
		
		private void SelecionarAplicativos()
		{
			this.WebAutomationService.BaseElement.SearchAndClickByID("allAppsBtn",this.WebAutomationService.DriverContextInfo.Timeout);
		}
		
		private void ClicarIconeDlxMondelez()
		{
			this.WebAutomationService.BaseElement.SearchAndClickByCss("img[alt='DLx2009-FULL-PRJ&TST-CSM-MONDELEZ-ARAUCARIA']", this.WebAutomationService.DriverContextInfo.Timeout);
		}
		
		public void AcessarMondelezAraucaria()
		{
			SelecionarAplicativos();
			ClicarIconeDlxMondelez();
		}
	}
}
