using SOW.Automation.Service.Desktop;
using SOW.Automation.Service.OCR;
using SOW.Automation.Service.Web;
using System;
namespace SOW.Automation.Interface.DLx.Windows.Main
{
	public class MainOCR : WindowBase
	{
		public MainOCR(WebService webService, DesktopService desktopService, OCRService ocrService)
			: base(webService, desktopService, ocrService)
		{
			try {
				this.OCRHelper = new SOW.Automation.Interface.DLx.Helpers.OCRHelper(root: Environment.CurrentDirectory, windowPath: "Main");
			} catch (Exception) {
				throw;
			}
		}
		
		public void Inicializar()
		{
			try {
				while (!this.DeskAutomationService.BaseElement.WindowExists("DigitaLogistix - \\\\Remote", 0)) this.Wait(1000);
				this.WindowOpen("DigitaLogistix - \\\\Remote");
				this.WindowSelect();
			} catch (Exception) {
				throw;
			}
		}
	}
}
