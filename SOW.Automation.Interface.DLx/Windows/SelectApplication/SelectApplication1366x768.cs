using SOW.Automation.Service.Desktop;
using SOW.Automation.Service.OCR;
using SOW.Automation.Service.Web;
using System;
namespace SOW.Automation.Interface.DLx.Windows.SelectApplication
{
	public class SelectApplication1366x768 : WindowBase
	{
		public SelectApplication1366x768(WebService webService, DesktopService desktopService, OCRService ocrService)
			: base(webService, desktopService, ocrService)
		{
		}
		
		public void ClicarBotaoCancel()
		{
			try {
				this.PointAndClick(820, 540);
			} catch {
				throw;
			}
		}
		
		public void ClicarBotaoOk()
		{
			try {
				this.PointAndClick(720, 540);
			} catch {
				throw;
			}
		}
		
		public void ClicarCitrixLogon()
		{
			try {
				this.PointAndClick(860, 610);
			} catch {
				throw;
			}
		}
		
		public void ClicarCampoConnectionName()
		{
			try {
				this.PointAndClick(720, 325);
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
				//this.PointAndClick(1050, 525);
				this.WindowSelect();
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
		
		public void PreencherConnectionName()
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
