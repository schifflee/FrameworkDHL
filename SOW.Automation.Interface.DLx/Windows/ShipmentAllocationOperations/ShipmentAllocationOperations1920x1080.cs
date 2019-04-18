using SOW.Automation.Service.Desktop;
using SOW.Automation.Service.OCR;
using SOW.Automation.Service.Web;
using System;
namespace SOW.Automation.Interface.DLx.Windows.ShipmentAllocationOperations
{
	public class ShipmentAllocationOperations1920x1080 : WindowBase
	{
		public ShipmentAllocationOperations1920x1080(WebService webService, DesktopService desktopService, OCRService ocrService)
			: base(webService, desktopService, ocrService)
		{
		}
		
		public void ClicarBotaoClear()
		{
			this.PointAndClick(1760, 120);
			this.Wait(1000);
		}
		
		public void ClicarBotaoExit()
		{
			this.PointAndClick(1710, 120);
			this.Wait(1000);
		}
		
		public void ClicarBotaoFind()
		{
			this.PointAndClick(1820, 120);
			this.Wait(1000);
		}
		
		public void ClicarBotaoLocate()
		{
			this.PointAndClick(220, 60);
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
		
		public void ClicarCampoCarrierMoveID()
		{
			this.PointAndClick(1222, 222);
			this.Wait(1000);
		}
		
		public void ClicarRotuloResultadoFiltro(int option)
		{
			int positionY = 120 + (20 * option);
			this.PointAndClick(240, positionY);
			this.Wait(1000);
		}
		
		public void InitializeWindow(string msValue, bool click)
		{
			
		}

		public void PreencherCampoCarrierMoveID(string value)
		{
			this.KeyboardPress(SOW.Automation.Common.KeyboardEnum.BACKSPACE);
			this.InsertText(value);
			this.Wait(1000);
		}
		
		public void PreencherCampoFiltro(string value)
		{
			this.InsertText(value);
			this.Wait(500);
		}
	}
}
