using SOW.Automation.Service.Desktop;
using SOW.Automation.Service.OCR;
using SOW.Automation.Service.Web;
using System;
namespace SOW.Automation.Interface.DLx.Windows.Login
{
	public class Login1920x1080 : WindowBase
	{
		public Login1920x1080(WebService webService, DesktopService desktopService, OCRService ocrService) : base(webService, desktopService, ocrService) { }
		
		public void ClicarBotaoCancel()
		{
			this.PointAndClick(1100, 700);
			this.Wait(1000);
		}
		
		public void ClicarBotaoOk()
		{
			this.PointAndClick(1000, 700);
			this.Wait(1000);
		}
		
		public void PreencherCampoPassword()
		{
			this.PointAndClick(1000, 585);
			this.Wait(1000);
			this.InsertText("dhl123");
			this.Wait(1000);
		}
		
		public void PreencherCampoUserID()
		{
			this.PointAndClick(1000, 550);
			this.Wait(1000);
			this.InsertText("RPA01");
			this.Wait(1000);
		}
	}
}
