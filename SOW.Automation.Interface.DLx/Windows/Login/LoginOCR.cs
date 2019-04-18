using System.Threading;
using SOW.Automation.Common.Desktop;
using SOW.Automation.Common.Web;
using SOW.Automation.Service.Desktop;
using SOW.Automation.Service.OCR;
using SOW.Automation.Service.Web;
using System;
namespace SOW.Automation.Interface.DLx.Windows.Login
{
	public class LoginOCR : WindowBase
	{
		public LoginOCR(WebService webService, DesktopService desktopService, OCRService ocrService)
			: base(webService, desktopService, ocrService)
		{
			try {
				this.OCRHelper = new SOW.Automation.Interface.DLx.Helpers.OCRHelper(root: Environment.CurrentDirectory, windowPath: "Login");
			} catch (Exception) {
				throw;
			}
		}
		
		public void ClicarBotaoCancel()
		{
			try {
				this.WindowClick("Cancel");
			} catch (Exception) {
				throw;
			}
		}
		
		public void ClicarBotaoOk()
		{
			try {
				this.WindowClick("OK");
			} catch (Exception) {
				throw;
			}
		}
		
		public void ClicarCampoUserID()
		{
			try {
				this.WindowClick("UserID");
			} catch (Exception) {
				throw;
			}
		}
		
		public void ClicarCampoPassword()
		{
			try {
				this.WindowClick("Password");
			} catch (Exception) {
				throw;
			}
		}
		
		public void PreencherCampoPassword()
		{
			try {
				this.InsertText("dhl123");
			} catch (Exception) {
				throw;
			}
		}
		
		public void PreencherCampoUserID()
		{
			try {
				this.InsertText("RPA01");
			} catch (Exception) {
				throw;
			}
		}
	}
}
