using System.Collections.Generic;
using SOW.Automation.Interface.DLx.Models;
using SOW.Automation.Service.Desktop;
using SOW.Automation.Service.OCR;
using SOW.Automation.Service.Web;
namespace SOW.Automation.Interface.DLx.Windows.TaskManagementDetailed
{
	public class TaskManagementDetailed1920x1080 : WindowBase
	{
		public TaskManagementDetailed1920x1080(WebService webService, DesktopService desktopService, OCRService ocrService)
			: base(webService, desktopService, ocrService)
		{
		}
		
		public void ClicarBotaoExit()
		{
			this.PointAndClick(1420, 120);
			this.Wait(1000);
		}
		
		public void ClicarBotaoFind()
		{
			this.PointAndClick(1480, 120);
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
					shipment.Temperatura = item[0].Replace('\n', ' ').TrimStart().Replace('\r', ' ').TrimStart();
					shipment.Familia = item[1].Replace('\n', ' ').TrimStart().Replace('\r', ' ').TrimStart();
					shipment.MS = item[2].Replace('\n', ' ').TrimStart().Replace('\r', ' ').TrimStart();
					shipment.Shipment = item[3].Replace('\n', ' ').TrimStart().Replace('\r', ' ').TrimStart();
					shipment.Delivery = item[4].Replace('\n', ' ').TrimStart().Replace('\r', ' ').TrimStart();
					shipment.Parada = item[5].Replace('\n', ' ').TrimStart().Replace('\r', ' ').TrimStart();
					shipment.TipoPedido = item[6].Replace('\n', ' ').TrimStart().Replace('\r', ' ').TrimStart();
					shipment.DataCriacao = item[7].Replace('\n', ' ').TrimStart().Replace('\r', ' ').TrimStart();
					shipment.DataAgendamento = item[8].Replace('\n', ' ').TrimStart().Replace('\r', ' ').TrimStart();
					shipment.Cliente = item[9].Replace('\n', ' ').TrimStart().Replace('\r', ' ').TrimStart();
					shipment.Cidade = item[10].Replace('\n', ' ').TrimStart().Replace('\r', ' ').TrimStart();
					shipment.Estado = item[11].Replace('\n', ' ').TrimStart().Replace('\r', ' ').TrimStart();
					shipment.PadraoEspecial = item[12].Replace('\n', ' ').TrimStart().Replace('\r', ' ').TrimStart();
					shipment.FefoEspecial = item[13].Replace('\n', ' ').TrimStart().Replace('\r', ' ').TrimStart();
					shipment.Transportadora = item[14].Replace('\n', ' ').TrimStart().Replace('\r', ' ').TrimStart();
					shipment.Placa = item[15].Replace('\n', ' ').TrimStart().Replace('\r', ' ').TrimStart();
					shipment.TipoVeiculo = item[16].Replace('\n', ' ').TrimStart().Replace('\r', ' ').TrimStart();
					shipment.TipoCarregamento = item[17].Replace('\n', ' ').TrimStart().Replace('\r', ' ').TrimStart();
					shipment.StatusMS = item[18].Replace('\n', ' ').TrimStart().Replace('\r', ' ').TrimStart();
					shipment.StageDepositado = item[19].Replace('\n', ' ').TrimStart().Replace('\r', ' ').TrimStart();
					shipment.CheckIn = item[20].Replace('\n', ' ').TrimStart().Replace('\r', ' ').TrimStart();
					shipment.DataDoca = item[21].Replace('\n', ' ').TrimStart().Replace('\r', ' ').TrimStart();
					shipment.DataPatioInterno = item[22].Replace('\n', ' ').TrimStart().Replace('\r', ' ').TrimStart();
					shipment.DataLiberacaoVeiculo = item[24].Replace('\n', ' ').TrimStart().Replace('\r', ' ').TrimStart();
					shipment.DataNF = item[24].Replace('\n', ' ').TrimStart().Replace('\r', ' ').TrimStart();
					shipment.TempoPermanencia = item[25].Replace('\n', ' ').TrimStart().Replace('\r', ' ').TrimStart();
					shipment.LocalVeiculo = item[26].Replace('\n', ' ').TrimStart().Replace('\r', ' ').TrimStart();
					shipment.Peso = item[27].Replace('\n', ' ').TrimStart().Replace('\r', ' ').TrimStart();
					shipment.TotalCaixas = item[28].Replace('\n', ' ').TrimStart().Replace('\r', ' ').TrimStart();
					shipment.SeparacaoParcial = item[29].Replace('\n', ' ').TrimStart().Replace('\r', ' ').TrimStart();
					shipment.Observacoes = item[30].Replace('\n', ' ').TrimStart().Replace('\r', ' ').TrimStart();
					shipment.ShipmentID = item[31].Replace('\n', ' ').TrimStart().Replace('\r', ' ').TrimStart();
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
