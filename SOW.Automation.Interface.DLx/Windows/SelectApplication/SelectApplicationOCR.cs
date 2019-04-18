using SOW.Automation.Interface.DLx.Helpers;
using SOW.Automation.Service.Desktop;
using SOW.Automation.Service.OCR;
using SOW.Automation.Service.Web;
using System;
namespace SOW.Automation.Interface.DLx.Windows.SelectApplication
{
	public class SelectApplicationOCR : WindowBase
	{
		public SelectApplicationOCR(WebService webService, DesktopService desktopService, OCRService ocrService)
			: base(webService, desktopService, ocrService)
		{
			try {
				this.OCRHelper = new SOW.Automation.Interface.DLx.Helpers.OCRHelper(root: Environment.CurrentDirectory, windowPath: "SelectApplication");
			} catch (Exception) {
				throw;
			}
		}
		
		public void ClicarBotaoCancel()
		{
			try {
				this.WindowClick("Cancel");
			} catch {
				throw;
			}
		}
		
		public void ClicarBotaoOk()
		{
			try {
				this.WindowClick("OK");
			} catch {
				throw;
			}
		}
		
		public void ClicarCitrixLogon()
		{
			try {
				//this.OCRAutomationService.BaseElement.ClickPattern(this.OCRHelper.GetPattern("OK"), this.OCRAutomationService.DriverContextInfo.Matching, this.OCRAutomationService.DriverContextInfo.Timeout);
				this.PointAndClick(860, 610);
			} catch {
				throw;
			}
		}
		
		public void ClicarCampoConnectionName()
		{
			try {
				this.WindowClick("ConnectionName");
			} catch {
				throw;
			}
		}
		
		public void Inicializar()
		{
			try {
				while (!this.DeskAutomationService.BaseElement.WindowExists("E²e™ - Consumer Driven Optimization - \\\\Remote", 0))
					this.Wait(1000);
				this.WindowOpen("E²e™ - Consumer Driven Optimization - \\\\Remote");
				this.KeyboardHold(SOW.Automation.Common.KeyboardEnum.LWIN);
				this.InsertText("D");
				this.KeyboardLeave(SOW.Automation.Common.KeyboardEnum.LWIN);
				this.WindowClick("Pattern01");
				this.WindowClick("Pattern02");
				//this.PointAndClick(1050, 525);
			} catch {
				throw;
			}
		}
		
		public void Inicializar(string value)
		{
			try {
				this.WindowOpen(value);
				//this.PointAndClick(1050, 525);
				this.WindowSelect();
			} catch {
				throw;
			}
		}
		
		public void PreencherCampoConnectionName()
		{
			try {
				this.InsertText("MMMMMMM");
			} catch {
				throw;
			}
		}
		
		public void PreencherCitrixLogon()
		{
			try {
				this.InsertText("Dhl@122018");
			} catch {
				throw;
			}
		}
	}
}
