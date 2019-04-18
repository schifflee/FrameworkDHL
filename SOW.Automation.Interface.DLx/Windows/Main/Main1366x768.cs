using SOW.Automation.Service.Desktop;
using SOW.Automation.Service.OCR;
using SOW.Automation.Service.Web;
using System;
namespace SOW.Automation.Interface.DLx.Windows.Main
{
	public class Main1366x768 : WindowBase
	{
		public Main1366x768(WebService webService, DesktopService desktopService, OCRService ocrService)
			: base(webService, desktopService, ocrService)
		{
		}
		
		public void ClicarBotaoLocate()
		{
			this.PointAndClick(220, 60);
			this.Wait(1000);
		}
		
		public void ClicarCabecalho()
		{
			this.PointAndClick(750, 190);
			this.Wait(1000);
		}
		
		public void ClicarCampoFiltro()
		{
			this.PointAndClick(300, 105);
			this.Wait(1000);
		}
		
		public void ClicarBotaoFiltroGo()
		{
			this.PointAndClick(390, 105);
			this.Wait(1000);
		}
		
		public void ClicarBotaoFiltroOk()
		{
			this.PointAndClick(330, 280);
			this.Wait(1000);
		}
		
		public void ClicarRotuloResultadoFiltro(int option)
		{
			int positionY = 120 + (20 * option);
			this.PointAndClick(240, positionY);
			this.Wait(1000);
		}
		
		public void Inicializar() {
			while (!this.DeskAutomationService.BaseElement.WindowExists("DigitaLogistix - \\\\Remote", 0)) {
				this.Wait(1000);
			}
			this.WindowOpen("DigitaLogistix - \\\\Remote");
			this.WindowSelect();
		}
		
		public void InitializeWindow()
		{
			
		}
		
		public void PreencherCampoFiltro(string value)
		{
			this.InsertText(value);
			this.Wait(1000);
		}
	}
}
