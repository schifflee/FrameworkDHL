using System.Collections.Generic;
using System.Linq;
using SOW.Automation.Interface.DLx.Models;
using SOW.Automation.Service.Desktop;
using SOW.Automation.Service.OCR;
using SOW.Automation.Service.Web;
using System;
namespace SOW.Automation.Interface.DLx.Windows.TaskManagement
{
	public class TaskManagement1920x1080 : WindowBase
	{
		public TaskManagement1920x1080(WebService webService, DesktopService desktopService, OCRService ocrService)
			: base(webService, desktopService, ocrService)
		{
		}
		
		public void ClicarBotaoExit()
		{
			this.PointAndClick(1370, 120);
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

		public void CopiarItensSelecionados()
		{
			this.KeyboardHold(SOW.Automation.Common.KeyboardEnum.ALT);
			this.KeyboardPress(SOW.Automation.Common.KeyboardEnum.TAB);
			this.KeyboardLeave(SOW.Automation.Common.KeyboardEnum.ALT);
			this.KeyboardHold(SOW.Automation.Common.KeyboardEnum.ALT);
			this.KeyboardPress(SOW.Automation.Common.KeyboardEnum.TAB);
			this.KeyboardLeave(SOW.Automation.Common.KeyboardEnum.ALT);
			this.KeyboardHold(SOW.Automation.Common.KeyboardEnum.CONTROL);
			this.InsertText("a");
			this.KeyboardLeave(SOW.Automation.Common.KeyboardEnum.CONTROL);
			this.KeyboardHold(SOW.Automation.Common.KeyboardEnum.CONTROL);
			this.InsertText("c");
			this.KeyboardLeave(SOW.Automation.Common.KeyboardEnum.CONTROL);
		}
		
		public IList<Shipment> FiltrarItensSelecionadosPorData(IList<Shipment> Shipments, DateTime dataMinima, DateTime dataMaxima)
		{
			this.Wait(500);
			
			return Shipments.Where(x => dataMinima < DateTime.Parse(x.DataAgendamento) && DateTime.Parse(x.DataAgendamento) < dataMaxima).ToList();
		}
		
		public void FiltrarResultadosTabela()
		{
			this.PointAndClick(360, 180);
			this.Wait(500);
			this.InsertText("ready");
			this.Wait(1000);
			this.PointAndClick(360, 180);
			this.Wait(1000);
		}
		
		public void InitializeWindow()
		{
			if (!this.WindowCheck(@"\OCR\TaskManagementTitle.png"))
				this.WindowClose();
			else {
				ClicarBotaoFind();
				if (!this.WindowCheck(@"\OCR\TaskManagementTableStatusMS.png"))
					this.WindowClose();
				else {
					//FiltrarResultadosTabela();
					ClicarTabelaListagemAgendamentos();
					SelecionarTodosItensTabelaListagemAgendamentos();
					ClicarBotaoLocate();
					PreencherCampoFiltro("tarefas detalhado");
					ClicarBotaoFiltroGo();
					ClicarRotuloResultadoFiltro(1);
					ClicarBotaoFiltroOk();
				}
			}
			//TODO
		}
		
		public IList<Shipment> ModelarItensSelecionados()
		{
			string content = this.DeskAutomationService.BaseElement.GetClipboardText(this.DeskAutomationService.DriverContextInfo.Timeout);
			var table = content.Replace("\r", "|").Split('|');
			this.DeskAutomationService.BaseElement.SetClipboardText(content.Replace("	", "|"), this.DeskAutomationService.DriverContextInfo.Timeout);
			
			IList<Shipment> Shipments = new List<Shipment>();
			foreach (var element in table) {
				var item = element.Split('	');
				var shipment = new Shipment();
				if (item.Length.Equals(34)) {
					shipment.StatusMS = item[0];
					shipment.Temperatura = item[1];
					shipment.Familia = item[2];
					shipment.MS = item[3];
					shipment.DataCriacao = item[4];
					shipment.DataAgendamento = item[5];
					shipment.Placa = item[6];
					shipment.Transportadora = item[7];
					shipment.TipoVeiculo = item[8];
					shipment.TipoCarregamento = item[9];
					shipment.StageDepositado = item[10];
					shipment.CheckIn = item[11];
					shipment.DataDoca = item[12];
					shipment.DataPatioInterno = item[13];
					shipment.DataLiberacaoVeiculo = item[14];
					shipment.DataNF = item[15];
					shipment.TempoPermanencia = item[16];
					shipment.LocalVeiculo = item[17];
					shipment.Peso = item[18];
					shipment.TotalCaixas = item[19];
					shipment.TotalCases = item[20];
					shipment.TotalPallets = item[21];
					shipment.Perfil = item[22];
					shipment.TotalSeparado = item[23];
					shipment.PercentualSeparado = item[24];
					shipment.CaixasShort = item[25];
					shipment.CaixasASeparar = item[26];
					shipment.PrioridadeCaixas = item[27];
					shipment.PalletsASeparar = item [28];
					shipment.PrioridadePallets = item[29];
					shipment.UnidadesASeparar = item[30];
					shipment.PrioridadeUnidades = item[31];
					shipment.SeparacaoParcial = item[32];
					
					/*
					Console.WriteLine(""
						+ shipment.StatusMS
						+ " | "
						+ shipment.Temperatura
						+ " | "
						+ shipment.Familia
						+ " | "
						+ shipment.MS
						+ " | "
						+ shipment.DataCriacao
						+ " | "
						+ shipment.DataAgendamento
						+ " | "
						+ shipment.Placa
						+ " | "
						+ shipment.Transportadora
						+ " | "
						+ shipment.TipoVeiculo
						+ " | "
						+ shipment.TipoCarregamento
						+ " | "
						+ shipment.StageDepositado
						+ " | "
						+ shipment.CheckIn
						+ " | "
						+ shipment.DataDoca
						+ " | "
						+ shipment.DataPatioInterno
						+ " | "
						+ shipment.DataLiberacaoVeiculo
						+ " | "
						+ shipment.DataNF
						+ " | "
						+ shipment.TempoPermanencia
						+ " | "
						+ shipment.LocalVeiculo
						+ " | "
						+ shipment.Peso
						+ " | "
						+ shipment.TotalCaixas
						+ " | "
						+ shipment.TotalCases
						+ " | "
						+ shipment.TotalPallets
						+ " | "
						+ shipment.Perfil
						+ " | "
						+ shipment.TotalSeparado
						+ " | "
						+ shipment.PercentualSeparado
						+ " | "
						+ shipment.CaixasShort
						+ " | "
						+ shipment.CaixasASeparar
						+ " | "
						+ shipment.PrioridadeCaixas
						+ " | "
						+ shipment.PrioridadePallets
						+ " | "
						+ shipment.UnidadesASeparar
						+ " | "
						+ shipment.PrioridadeUnidades
						+ " | "
						+ shipment.SeparacaoParcial
						+ " | "
						+ item[32]
						+ " | "
						+ item[33]);
					*/
				}
				Shipments.Add(shipment);
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
			this.PointAndClick(400, 260);
			this.Wait(1000);
			/*this.SegurarTecla(SOW.Automation.Common.KeyboardEnum.CONTROL);
			this.InserirTexto("a");
			this.LiberarTecla(SOW.Automation.Common.KeyboardEnum.CONTROL);*/
		}
	}
}
