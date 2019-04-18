using System.Collections.Generic;
using SOW.Automation.Interface.DLx.Models;
using SOW.Automation.Service.Desktop;
using SOW.Automation.Service.OCR;
using SOW.Automation.Service.Web;
namespace SOW.Automation.Interface.DLx.Windows.TaskManagementDetailed
{
	public class TaskManagementDetailed1366x768 : WindowBase
	{
		public TaskManagementDetailed1366x768(WebService webService, DesktopService desktopService, OCRService ocrService)
			: base(webService, desktopService, ocrService)
		{
		}
		
		public void ClicarBotaoExit()
		{
			this.PointAndClick(1420, 120);
			this.Wait(500);
		}
		
		public void ClicarBotaoFind()
		{
			this.PointAndClick(1480, 120);
			this.Wait(500);
		}
		
		public void ClicarBotaoLocate()
		{
			this.PointAndClick(220, 60);
			this.Wait(500);
		}
		
		public void ClicarCampoFiltro()
		{
			this.PointAndClick(300, 105);
			this.Wait(500);
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

		public void ClicarTabelaListagemAgendamentos()
		{
			this.PointAndClick(330, 200);
			this.Wait(1000);
		}
		
		public IList<Shipment> VerificarPadraoEspecial(IList<Shipment> Shipments, IList<ShipmentDetailed> ShipmentDetaileds)
		{
			return null;
		}

		public void CopiarItensSelecionados()
		{
			this.KeyboardHold(SOW.Automation.Common.KeyboardEnum.CONTROL);
			this.InsertText("c");
			this.KeyboardLeave(SOW.Automation.Common.KeyboardEnum.CONTROL);
		}
		
		public void InitializeWindow()
		{
			
			//TODO
		}
		
		public IList<ShipmentDetailed> ModelarItensSelecionados()
		{
			string content = this.DeskAutomationService.BaseElement.GetClipboardText(this.DeskAutomationService.DriverContextInfo.Timeout);
			var table = content.Replace("\r", "|").Split('|');
			
			IList<ShipmentDetailed> Shipments = new List<ShipmentDetailed>();
			foreach (var element in table) {
				var item = element.Split('	');
				if (item.Length.Equals(34)) {
					var shipment = new ShipmentDetailed();
					shipment.MS = item[0];
					shipment.PadraoEspecial = item[1];
					shipment.Temperatura = item[2];
					shipment.Familia = item[3];
					shipment.Shipment = item[4];
					shipment.Delivery = item[5];
					shipment.Parada = item[6];
					shipment.TipoPedido = item[7];
					shipment.DataCriacao = item[8];
					shipment.DataAgendamento = item[9];
					shipment.Cliente = item[10];
					shipment.Cidade = item[11];
					shipment.Estado = item[12];
					shipment.FefoEspecial = item[13];
					shipment.Transportadora = item[14];
					shipment.Placa = item[15];
					shipment.TipoVeiculo = item[16];
					shipment.TipoCarregamento = item[17];
					shipment.StatusMS = item[18];
					shipment.StageDepositado = item[19];
					shipment.CheckIn = item[20];
					shipment.DataDoca = item[21];
					shipment.DataPatioInterno = item[22];
					shipment.DataLiberacaoVeiculo = item[24];
					shipment.DataNF = item[24];
					shipment.TempoPermanencia = item[25];
					shipment.LocalVeiculo = item[26];
					shipment.Peso = item[27];
					shipment.TotalCaixas = item[28];
					shipment.SeparacaoParcial = item[29];
					shipment.Observacoes = item[30];
					shipment.ShipmentID = item[31];
					Shipments.Add(shipment);
				}
			}
			
			this.Wait(500);
			
			return Shipments;
		}
		
		public void PreencherCampoFiltro(string value)
		{
			this.InsertText(value);
			this.Wait(1000);
		}

		public void SelecionarTodosItensTabelaListagemAgendamentos()
		{
			this.MouseRightClick();
			this.Wait(1000);
			this.PointAndClick(400, 260);
			this.Wait(1000);
		}
	}
}
