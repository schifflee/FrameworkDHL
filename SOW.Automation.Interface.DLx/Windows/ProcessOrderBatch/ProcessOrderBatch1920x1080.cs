using System.Collections.Generic;
using SOW.Automation.Interface.DLx.Models;
using SOW.Automation.Service.Desktop;
using SOW.Automation.Service.OCR;
using SOW.Automation.Service.Web;
using System;
namespace SOW.Automation.Interface.DLx.Windows.ProcessOrderBatch
{
	public class ProcessOrderBatch1920x1080 : WindowBase
	{
		public ProcessOrderBatch1920x1080(WebService webService, DesktopService desktopService, OCRService ocrService)
			: base(webService, desktopService, ocrService) { }
		
		public void ClicarBotaoAllocate()
		{
			this.PointAndClick(330, 990);
			this.Wait(1000);
		}
		
		public void ClicarBotaoExit()
		{
			this.PointAndClick(1785, 115);
			this.Wait(1000);
		}
		
		public void ClicarBotaoHome()
		{
			this.Wait(1000);
			this.PointAndClick(1835, 115);
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
		
		public void ClicarCampoDestinationArea()
		{
			this.PointAndClick(710, 285);
			this.Wait(1000);
		}
		
		public void ClicarCampoDestinationLocation()
		{
			this.PointAndClick(620, 315);
			this.Wait(1000);
		}
		
		public void ClicarCampoDestinationLocationOption(int option)
		{
			int positionY = 318 + (15 * option);
			this.PointAndClick(500, positionY);
			this.Wait(1000);
		}
		
		public void ClicarJanelaAllocationSummaryBotaoOk()
		{
			this.PointAndClick(1200, 790);
			this.Wait(1000);
		}
		
		public void ClicarRotuloResultadoFiltro(int option)
		{
			int positionY = 120 + (20 * option);
			this.PointAndClick(240, positionY);
			this.Wait(1000);
		}
		
		public void InitializeWindow(string destinationArea, string destinationLocation)
		{
			
		}

		public void PreencherCampoDestinationArea(int option)
		{
			int positionY = 380 + (15 * option);
			this.PointAndClick(565, positionY);
			this.Wait(1000);
		}

		public void PreencherCampoDestinationArea(string value)
		{
			this.InsertText(value);
			this.Wait(1000);
		}

		public void PreencherCampoDestinationLocation(string value)
		{
			this.InsertText(value);
			this.Wait(1000);
		}

		public void PreencherCampoDestinationLocationByOCR(string imagePath)
		{
			this.WindowClick(imagePath);
			this.Wait(1000);
		}
		
		public void PreencherCampoFiltro(string value)
		{
			this.InsertText(value);
			this.Wait(500);
		}
	}
}
