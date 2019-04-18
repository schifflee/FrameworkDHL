using SOW.Automation.Service.Desktop;
using SOW.Automation.Service.OCR;
using SOW.Automation.Service.Web;
using System;
namespace SOW.Automation.Interface.DLx.Windows.SelectApplication
{
	public class SelectApplication1920x1080 : WindowBase
	{
		public SelectApplication1920x1080(WebService webService, DesktopService desktopService, OCRService ocrService) : base(webService, desktopService, ocrService) { }
		
		public void ClicarBotaoCancel() 
		{
			this.PointAndClick(1100, 700);
		}
		
		public void ClicarBotaoOk() 
		{
			this.PointAndClick(1000, 700);
		}
		
		public void Inicializar ()
		{
			while (!this.DeskAutomationService.BaseElement.WindowExists("E²e™ - Consumer Driven Optimization - \\\\Remote", 0)) this.Wait(1000);
			this.WindowOpen("E²e™ - Consumer Driven Optimization - \\\\Remote");
			this.PointAndClick(1050, 525);
			this.WindowSelect();
		}
		
		public void Inicializar (string value)
		{
			this.WindowOpen(value);
			this.PointAndClick(1050, 525);
			this.WindowSelect();
		}
		
		public void PreencherConnectionName() 
		{
			this.PointAndClick(1050, 525);
			this.Wait(1000);
			this.InsertText("MMMMMMM");
			this.Wait(1000);
			this.KeyboardPress(SOW.Automation.Common.KeyboardEnum.RETURN);
			this.Wait(1000);
		}
		
		public void PreencherCitrixLogon()
		{
			this.PointAndClick(860, 610);
			this.Wait(1000);
			this.InsertText("Dhl@122018");
			this.KeyboardPress(SOW.Automation.Common.KeyboardEnum.RETURN);
			this.Wait(1000);
		}
		
		public void SelecionarConnectionName() 
		{
			this.PointAndClick(1050, 525);
			this.Wait(1000);
		}
		
		public void SelecionarHostName() 
		{
		
		}
		
		public void SelecionarPortNumber() 
		{
			
		}
	}
}
