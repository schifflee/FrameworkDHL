using System.Linq;
using System.Threading.Tasks;

namespace SOW.Automation.Workflow.Omni.Exception
{
	public static class WebProcess
	{
		public static WebProcessEnum Login(Services services)
		{
			try {
				var login = new SOW.Automation.Interface.DLx.Pages.LoginPageHml(services.WebService, services.DesktopService);
				//SOW.Orchestration.Workflow.IWorkflow webProcessFlow = new SOW.Orchestration.Workflow.Workflow();
				login.OpenURL("http://jcpvipexecutivo.com/sitecondo/index.html", services.WebService.DriverContextInfo.Timeout);
				//login.EfetuarLogin("andre.l.dasilva@Omni.com", "Omni@122018", services.WebService.DriverContextInfo.Timeout);
				login.EfetuarLogin("admin", "admin", services.WebService.DriverContextInfo.Timeout);
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
