using System.Linq;

namespace SOW.Automation.Workflow.DHL
{
	public static class Short
	{
		public static void Automatizar(Services Services)
		{
////			var loginpage = new Interface.DLx.Pages.LoginPageHml(Services.WebService, Services.DesktopService);
////			var mainpage = new Interface.DLx.Pages.MainPageHml(Services.WebService, Services.DesktopService);
////			var selectApplication = new Interface.DLx.Windows.SelectApplication(Services.WebService, Services.DesktopService, Services.OCRService);
////			var loginRedPrairie = new Interface.DLx.Windows.LoginRedPrairie(Services.WebService, Services.DesktopService, Services.OCRService);
////			var main = new Interface.DLx.Windows.Main(Services.WebService, Services.DesktopService, Services.OCRService);
////			var taskManagement = new Interface.DLx.Windows.TaskManagement(Services.WebService, Services.DesktopService, Services.OCRService);
////			var taskManagementDetailed = new Interface.DLx.Windows.TaskManagementDetailed(Services.WebService, Services.DesktopService, Services.OCRService);
////			var shipmentAllocationOperations = new Interface.DLx.Windows.ShipmentAllocationOperations(Services.WebService, Services.DesktopService, Services.OCRService);
////			var orderInformation = new Interface.DLx.Windows.OrderInformation(Services.WebService, Services.DesktopService, Services.OCRService);
////			var processOrderBatch = new Interface.DLx.Windows.ProcessOrderBatch(Services.WebService, Services.DesktopService, Services.OCRService);
////
////			loginpage.OpenURL("https://citrixtest.br.phx-dc.dhl.com/Citrix/storefWeb/", 10);
////			loginpage.EfetuarLogin("andre.l.dasilva@dhl.com", "Dhl@122018", 10);
////			mainpage.AcessarMondelezAraucaria();
////			
////			selectApplication.Inicializar();
////			if (selectApplication.ChecarJanela(@"\OCR\WindowCitrixLogon.png", 15))
////				selectApplication.PreencherCitrixLogon();
////			if (!selectApplication.ChecarJanela(@"\OCR\SelectApplicationLogo.png"))
////				selectApplication.ClicarBotaoCancel();
////			else {
////				selectApplication.PreencherConnectionName();
////				selectApplication.ClicarBotaoOk();
////				
////				loginRedPrairie.InitializeWindow();
////				if (!loginRedPrairie.ChecarJanela(@"\OCR\LoginRedPrairieLogo.png"))
////					loginRedPrairie.ClicarBotaoCancel();
////				else {
////					loginRedPrairie.Wait(10000);
////					loginRedPrairie.SelecionarJanela();
////					loginRedPrairie.PreencherCampoUserID();
////					loginRedPrairie.PreencherCampoPassword();
////					loginRedPrairie.ClicarBotaoOk();
////				}
////				
////				//while (!this.DeskAutomationService.BaseElement.WindowExists("E²e™ - Consumer Driven Optimization - \\\\Remote", 0)) {
////				main.Inicializar();
////				System.Console.WriteLine(System.Environment.CurrentDirectory + @"\OCR\MainLeftPanelFindButton.PNG");
////				if (!main.ChecarJanela(@"\OCR\MainLeftPanelFindButton.PNG"))
////					main.FecharAplicacao();
////				else {
////					main.SelecionarJanela();
////					main.ClicarCabecalho();
////					main.MaximizarJanela();
////					main.ClicarBotaoLocate();
////					main.ClicarCampoFiltro();
////					main.PreencherCampoFiltro("tarefas");
////					main.ClicarBotaoFiltroGo();
////					main.ClicarRotuloResultadoFiltro(1);
////					main.ClicarBotaoFiltroOk();
////					
////					
////					
////					
////					
////					if (!taskManagement.ChecarJanela(@"\OCR\TaskManagementTitle.png"))
////						taskManagement.FecharAplicacao();
////					else {
////						taskManagement.ClicarBotaoFind();
////						if (!taskManagement.ChecarJanela(@"\OCR\TaskManagementTableStatusMS.png"))
////							taskManagement.FecharJanela();
////						else {
////							//FiltrarResultadosTabela();
////							taskManagement.ClicarTabelaListagemAgendamentos();
////							taskManagement.SelecionarTodosItensTabelaListagemAgendamentos();
////							taskManagement.ClicarBotaoLocate();
////							taskManagement.PreencherCampoFiltro("tarefas detalhado");
////							taskManagement.ClicarBotaoFiltroGo();
////							taskManagement.ClicarRotuloResultadoFiltro(1);
////							taskManagement.ClicarBotaoFiltroOk();
////							
////							
////							
////							
////							
////							if (!taskManagementDetailed.ChecarJanela(@"\OCR\TaskManagementDetailedTitle.png"))
////								taskManagementDetailed.FecharJanela();
////							else {
////								taskManagementDetailed.ClicarBotaoFind();
////								if (!taskManagementDetailed.ChecarJanela(@"\OCR\TaskManagementTableMS.png"))
////									taskManagementDetailed.FecharJanela();
////								else {
////									taskManagementDetailed.ClicarTabelaListagemAgendamentos();
////									taskManagementDetailed.SelecionarTodosItensTabelaListagemAgendamentos();
////									taskManagementDetailed.ClicarBotaoLocate();
////									taskManagementDetailed.PreencherCampoFiltro(" de Embarques");
////									taskManagementDetailed.ClicarBotaoFiltroGo();
////									taskManagementDetailed.ClicarRotuloResultadoFiltro(2);
////									taskManagementDetailed.ClicarBotaoFiltroOk();
////									
////									System.Collections.Generic.IList<Interface.DLx.Models.ShipmentDetailed> ShipmentDetaileds = taskManagementDetailed.ModelarItensSelecionados();
////									
////									var workSheet = new Interface.DLx.Excel.ExcelHandler();
////									string path = System.String.Concat(System.Environment.CurrentDirectory, @"\Files", @"\");
////									string file = @"Planilha de Testes.xlsm";
////
////									foreach (var shipment in ShipmentDetaileds.Where(x => x != null && x.StatusMS != null && x.StatusMS.ToLower().Contains("ready")).ToList()) {
////										double boxes = ((shipment.TotalCaixas != null && !System.String.IsNullOrWhiteSpace(shipment.TotalCaixas)) ? int.Parse(shipment.TotalCaixas) : 0);
////										double pallets = ((shipment.TotalPallets != null && !System.String.IsNullOrWhiteSpace(shipment.TotalPallets)) ? int.Parse(shipment.TotalPallets) : 0);
////										double special = ((!System.String.IsNullOrWhiteSpace(shipment.PadraoEspecial)) ? 1.3 : 1);
////										var rpa = new Interface.DLx.Excel.Models.RpaDadosStageInfo {
////											Ms = shipment.MS,
////											Sid = shipment.ShipmentID,
////											Status = Interface.DLx.Excel.Enums.EStatusStage.Ready,
////											FamiliaDlx = Interface.DLx.Helpers.TemperatureHelper.GetTemperature(shipment.Temperatura),
////											QtdPalets = (int)System.Math.Round((boxes / Interface.DLx.Helpers.FamilyHelper.BoxesToPallets(shipment.Familia) + pallets) * special)
////												//QtdPalets = Convert.ToInt32(int.Parse(((shipment.TotalCaixas != null && !String.IsNullOrWhiteSpace(shipment.TotalCaixas)) ? shipment.TotalCaixas : "0")) / Family.ConvertBoxesToPallets(shipment.Familia) + int.Parse(((shipment.TotalPallets != null && !String.IsNullOrWhiteSpace(shipment.TotalPallets)) ? shipment.TotalPallets : "0")) * int.Parse(((!String.IsNullOrWhiteSpace(shipment.PadraoEspecial)) ? "1.3" : "1")))
////										};
////										var response = workSheet.AlocarObjeto(path, file, rpa);
////										if (response.Alocado) {
////											shipment.StatusMS = "In-Process";
////											shipment.ShipmentID = shipment.ShipmentID.Replace("\n", "").Replace("\r", "").Replace(" ", "");
////											shipment.MS = shipment.MS.Replace("\n", "").Replace("\r", "").Replace(" ", "");
////											shipment.Temperatura = Interface.DLx.Helpers.TemperatureHelper.GetTemperature(response.RpaDadosStageInfo.FamiliaDlx);
////											
////											if (!shipmentAllocationOperations.ChecarJanela(@"\OCR\ShipmentAllocationOperationsTitle.png"))
////												shipmentAllocationOperations.FecharJanela();
////											else {
////												shipmentAllocationOperations.Wait(2000);
////												shipmentAllocationOperations.ClicarBotaoClear();
////												shipmentAllocationOperations.ClicarCampoCarrierMoveID();
////												shipmentAllocationOperations.PreencherCampoCarrierMoveID(shipment.MS);
////												shipmentAllocationOperations.ClicarBotaoFind();
////												if (!orderInformation.ChecarJanela(@"\OCR\OrderInformationTitle.png"))
////													orderInformation.FecharAplicacao();
////												else {
////													orderInformation.SelecionarTodosItensTabelaListagemAgendamentos();
////													orderInformation.ClicarBotaoFerramentaDeSelecao();
////													orderInformation.ClicarJanelaFerramentaDeSelecao();
////													orderInformation.PreencherCampoCarrierMoveID(shipment.MS);
////													orderInformation.ClicarJanelaFerramentaDeSelecaoBotaoOK();
////													orderInformation.ClicarBotaoAllocate();
////													if (!processOrderBatch.ChecarJanela(@"\OCR\ProcessOrderBatchTitle.png"))
////														processOrderBatch.FecharAplicacao();
////													else {
////														processOrderBatch.ClicarCampoDestinationArea();
////														//processOrderBatch.PreencherCampoDestinationArea(System.String.Concat("1STGO", shipment.Temperatura));
////														//processOrderBatch.PressionarTecla(SOW.Automation.Common.KeyboardEnum.RETURN);
////														switch (response.RpaDadosStageInfo.FamiliaDlx) {
////															case SOW.Automation.Interface.DLx.Excel.Enums.EStatusStageDlx.AMB:
////																processOrderBatch.PreencherCampoDestinationArea(1);
////																break;
////															case SOW.Automation.Interface.DLx.Excel.Enums.EStatusStageDlx.CLI:
////																processOrderBatch.PreencherCampoDestinationArea(2);
////																break;
////															case SOW.Automation.Interface.DLx.Excel.Enums.EStatusStageDlx.PAS:
////																processOrderBatch.PreencherCampoDestinationArea(3);
////																break;
////															case SOW.Automation.Interface.DLx.Excel.Enums.EStatusStageDlx.SEM:
////																processOrderBatch.PreencherCampoDestinationArea(1);
////																break;
////															default:
////																processOrderBatch.PreencherCampoDestinationArea(1);
////																break;
////														}
////														processOrderBatch.ClicarCampoDestinationLocation();
////														processOrderBatch.PreencherCampoDestinationLocation(response.Stage);
////														processOrderBatch.ClicarCampoDestinationLocationOption(1);
////														//if (processOrderBatch.ChecarJanela(@"\OCR\ProcessOrderBatchDestinationLocationEmpty.png")) {
////														//	processOrderBatch.ClicarCampoDestinationLocation();
////														//	processOrderBatch.ClicarCampoDestinationLocationOption(2);
////														//}
////														processOrderBatch.ClicarBotaoHome();
////														//processOrderBatch.ClicarBotaoAllocate();
////														if (true)
////															//!processOrderBatch.ChecarJanela(@"\OCR\ProcessOrderBatchAllocationSummary.png"))
////															//processOrderBatch.FecharAplicacao();
////														{															//else
////															//processOrderBatch.ClicarJanelaAllocationSummaryBotaoOk();
////															
////															processOrderBatch.ClicarBotaoHome();
////															if (orderInformation.ChecarJanela(@"\OCR\OrderInformationTitle.png"))
////																orderInformation.ClicarBotaoHome();
////														}
////													}
////												}
////											}
////										}
////									}
////
////									Interface.DLx.Excel.Services.ExcelService.InsertData(path, file, ShipmentDetaileds);
////
////									main.AbrirJanela("DigitaLogistix - \\\\Remote");
////									main.FecharAplicacao();
////									
////								}
////							}
////						}
////					}
////				}
//			}
		}
	}
}
