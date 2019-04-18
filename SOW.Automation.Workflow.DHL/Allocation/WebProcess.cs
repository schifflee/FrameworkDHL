using System.Linq;
using System.Threading.Tasks;

namespace SOW.Automation.Workflow.DHL.Allocation
{
	public static class WebProcess
	{
		public static WebProcessEnum Login(Services services)
		{
			try {
				var loginPage = new SOW.Automation.Interface.DLx.Pages.LoginPageHml(services.WebService, services.DesktopService);
				
				SOW.Orchestration.Workflow.IWorkflow webProcessFlow = new SOW.Orchestration.Workflow.Workflow();
				
				loginPage.OpenURL("https://citrixtest.br.phx-dc.dhl.com/Citrix/storefWeb/", services.WebService.DriverContextInfo.Timeout);
				loginPage.EfetuarLogin("andre.l.dasilva@dhl.com", "Dhl@122018", services.WebService.DriverContextInfo.Timeout);
				services.WebService.DriverContextInfo.Attempts = services.WebService.DriverContextInfo.Restore();
				return WebProcessEnum.AccessMondelezAraucaria;
			} catch {
				services.WebService.DriverContextInfo.Attempts--;
				return WebProcessEnum.Login;
			}
		}
		
		public static WebProcessEnum AccessMondelezAraucaria(Services services)
		{
			try {
				var mainPage = new SOW.Automation.Interface.DLx.Pages.MainPageHml(services.WebService, services.DesktopService);
				mainPage.AcessarMondelezAraucaria();
				services.WebService.DriverContextInfo.Attempts = services.WebService.DriverContextInfo.Restore();
				return WebProcessEnum.Close;
			} catch {
				services.WebService.DriverContextInfo.Attempts--;
				return WebProcessEnum.AccessMondelezAraucaria;
			}
		}
	}
}
