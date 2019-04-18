namespace SOW.Automation.Workflow.DHL
{
	public class Services
	{
		public SOW.Automation.Service.Desktop.DesktopService DesktopService;
		public SOW.Automation.Service.OCR.OCRService OCRService;
		public SOW.Automation.Service.Web.WebService WebService;
		public Services()
		{
			WebService = new Service.Web.WebService(
				new SOW.Automation.Common.Web.WebDriverContextInfo() {
					Path = System.String.Concat(System.Environment.CurrentDirectory, @"\Drivers", @"\Chrome", @"\2.4.6", @"\"),
					MaximizeWindow = false,
					Browser = Common.Web.BrowserEnum.Chrome,
					Driver = Common.DriverEnum.Selenium,
					Timeout = 60,
					Attempts = 10,
					MaxAttempts = 10
				}
			);
			OCRService = new Service.OCR.OCRService(
				new SOW.Automation.Common.OCR.OCRDriverContextInfo() {
					Driver = Common.DriverEnum.Sikuli,
					Matching = 0.9,
					Timeout = 60,
					Attempts = 10,
					MaxAttempts = 10
				}
			);
			DesktopService = new Service.Desktop.DesktopService(
				new SOW.Automation.Common.Desktop.DesktopDriverContextInfo() {
					Driver = Common.DriverEnum.TestStack,
					Timeout = 30,
					Attempts = 10,
					MaxAttempts = 10
				}
			);
		}
	}
}
