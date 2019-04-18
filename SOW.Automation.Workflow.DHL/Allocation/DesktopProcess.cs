using System.Linq;
using System.Threading.Tasks;

namespace SOW.Automation.Workflow.DHL.Allocation
{
	public static class DesktopProcess
	{
		public static DesktopProcessEnum SelectApplication(Services services)
		{
			try {
				DesktopProcessEnum nextStep = DesktopProcessEnum.Waiting;
				var selectApplication = new SOW.Automation.Interface.DLx.Windows.SelectApplication.SelectApplication1920x1080(services.WebService, services.DesktopService, services.OCRService);
				selectApplication.Inicializar();
				if (!selectApplication.WindowCheck(@"\OCR\SelectApplicationLogo.png")) {
					if (selectApplication.WindowCheck(@"\OCR\WindowCitrixLogon.png"))
						selectApplication.PreencherCitrixLogon();
					services.DesktopService.DriverContextInfo.Attempts--;
					return DesktopProcessEnum.SelectApplication;
				} else {
					selectApplication.PreencherConnectionName();
					selectApplication.ClicarBotaoOk();
					nextStep = DesktopProcessEnum.Login;
					services.DesktopService.DriverContextInfo.Attempts = services.DesktopService.DriverContextInfo.Restore();
				}
				return nextStep;
			} catch (System.Exception e) {
				System.Console.WriteLine(e.Message);
				services.DesktopService.DriverContextInfo.Attempts--;
				return DesktopProcessEnum.SelectApplication;
			}
		}
		
		public static DesktopProcessEnum Login(Services services)
		{
			try {
				DesktopProcessEnum nextStep = DesktopProcessEnum.Waiting;
				var login = new SOW.Automation.Interface.DLx.Windows.Login.Login1920x1080(services.WebService, services.DesktopService, services.OCRService);
				if (!login.WindowCheck(@"\OCR\LoginRedPrairieLogo.png")) {
					services.DesktopService.DriverContextInfo.Attempts--;
					return DesktopProcessEnum.Login;
				} else {
					login.WindowSelect();
					login.PreencherCampoUserID();
					login.PreencherCampoPassword();
					login.ClicarBotaoOk();
					nextStep = DesktopProcessEnum.Main;
					services.DesktopService.DriverContextInfo.Attempts = services.DesktopService.DriverContextInfo.Restore();
				}
				return nextStep;
			} catch (System.Exception e) {
				System.Console.WriteLine(e.Message);
				services.DesktopService.DriverContextInfo.Attempts--;
				return DesktopProcessEnum.Login;
			}
		}
		
		public static DesktopProcessEnum Main(Services services)
		{
			try {
				DesktopProcessEnum nextStep = DesktopProcessEnum.Waiting;
				var main = new SOW.Automation.Interface.DLx.Windows.Main.Main1920x1080(services.WebService, services.DesktopService, services.OCRService);
				if (!main.WindowCheck(@"\OCR\MainLeftPanelFindButton.PNG")) {
					services.DesktopService.DriverContextInfo.Attempts--;
					nextStep = DesktopProcessEnum.Exception;
				} else {
					main.WindowSelect();
					main.ClicarCabecalho();
					main.MaximizeWindow();
					main.ClicarBotaoLocate();
					main.ClicarCampoFiltro();
					main.PreencherCampoFiltro("tarefas");
					main.ClicarBotaoFiltroGo();
					main.ClicarRotuloResultadoFiltro(1);
					main.ClicarBotaoFiltroOk();
					nextStep = DesktopProcessEnum.TaskManagement;
					services.DesktopService.DriverContextInfo.Attempts = services.DesktopService.DriverContextInfo.Restore();
				}
				return nextStep;
			} catch {
				services.DesktopService.DriverContextInfo.Attempts--;
				return DesktopProcessEnum.Main;
			}
		}
		
		public static DesktopProcessEnum TaskManagement(Services services)
		{
			try {
				DesktopProcessEnum nextStep = DesktopProcessEnum.Waiting;
				var taskManagement = new SOW.Automation.Interface.DLx.Windows.TaskManagement.TaskManagement1920x1080(services.WebService, services.DesktopService, services.OCRService);
				
				if (!taskManagement.WindowCheck(@"\OCR\TaskManagementTitle.png")) {
					services.DesktopService.DriverContextInfo.Attempts--;
					return DesktopProcessEnum.TaskManagement;
				} else {
					taskManagement.ClicarBotaoFind();
					if (!taskManagement.WindowCheck(@"\OCR\TaskManagementTableStatusMS.png")) {
						services.DesktopService.DriverContextInfo.Attempts--;
						return DesktopProcessEnum.TaskManagement;
					} else {
						//FiltrarResultadosTabela();
						taskManagement.ClicarTabelaListagemAgendamentos();
						taskManagement.SelecionarTodosItensTabelaListagemAgendamentos();
						taskManagement.ClicarBotaoLocate();
						taskManagement.PreencherCampoFiltro("tarefas detalhado");
						taskManagement.ClicarBotaoFiltroGo();
						taskManagement.ClicarRotuloResultadoFiltro(1);
						taskManagement.ClicarBotaoFiltroOk();
						nextStep = DesktopProcessEnum.TaskManagementDetailed;
						services.DesktopService.DriverContextInfo.Attempts = services.DesktopService.DriverContextInfo.Restore();
					}
				}
				return nextStep;
			} catch {
				services.DesktopService.DriverContextInfo.Attempts--;
				return DesktopProcessEnum.TaskManagement;
			}
		}
		
		public static DesktopProcessEnum TaskManagementDetailed(Services services)
		{
			try {
				DesktopProcessEnum nextStep = DesktopProcessEnum.Waiting;
				var taskManagementDetailed = new SOW.Automation.Interface.DLx.Windows.TaskManagementDetailed.TaskManagementDetailed1920x1080(services.WebService, services.DesktopService, services.OCRService);
				
				if (!taskManagementDetailed.WindowCheck(@"\OCR\TaskManagementDetailedTitle.png")) {
					services.DesktopService.DriverContextInfo.Attempts--;
					return DesktopProcessEnum.TaskManagementDetailed;
				} else {
					taskManagementDetailed.ClicarBotaoFind();
					if (!taskManagementDetailed.WindowCheck(@"\OCR\TaskManagementTableMS.png")) {
						services.DesktopService.DriverContextInfo.Attempts--;
						return DesktopProcessEnum.TaskManagementDetailed;
					} else {
						taskManagementDetailed.ClicarTabelaListagemAgendamentos();
						taskManagementDetailed.SelecionarTodosItensTabelaListagemAgendamentos();
						taskManagementDetailed.Wait(2000);
						taskManagementDetailed.ClicarBotaoLocate();
						taskManagementDetailed.PreencherCampoFiltro(" de Embarques");
						taskManagementDetailed.Wait(2000);
						taskManagementDetailed.ClicarBotaoFiltroGo();
						taskManagementDetailed.ClicarRotuloResultadoFiltro(2);
						taskManagementDetailed.ClicarBotaoFiltroOk();
						nextStep = DesktopProcessEnum.ShipmentAllocationOperations;
						services.DesktopService.DriverContextInfo.Attempts = services.DesktopService.DriverContextInfo.Restore();
					}
				}
				return nextStep;
			} catch {
				services.DesktopService.DriverContextInfo.Attempts--;
				return DesktopProcessEnum.TaskManagementDetailed;
			}
		}
		
		public static DesktopProcessEnum ShipmentAllocationOperations(Services services, Interface.DLx.Excel.Commands.CoordenadasCommandResponse response)
		{
			try {
				DesktopProcessEnum nextStep = DesktopProcessEnum.Waiting;
				var shipmentAllocationOperations = new SOW.Automation.Interface.DLx.Windows.ShipmentAllocationOperations.ShipmentAllocationOperations1920x1080(services.WebService, services.DesktopService, services.OCRService);
				
				if (!shipmentAllocationOperations.WindowCheck(@"\OCR\ShipmentAllocationOperationsTitle.png")) {
					services.DesktopService.DriverContextInfo.Attempts--;
					return DesktopProcessEnum.ShipmentAllocationOperations;
				} else {
					shipmentAllocationOperations.Wait(1000);
					shipmentAllocationOperations.ClicarBotaoClear();
					shipmentAllocationOperations.Wait(1000);
					shipmentAllocationOperations.ClicarCampoCarrierMoveID();
					shipmentAllocationOperations.Wait(1000);
					shipmentAllocationOperations.PreencherCampoCarrierMoveID(response.RpaDadosStageInfo.Ms);
					shipmentAllocationOperations.Wait(1000);
					shipmentAllocationOperations.ClicarBotaoFind();
					nextStep = DesktopProcessEnum.OrderInformation;
					services.DesktopService.DriverContextInfo.Attempts = services.DesktopService.DriverContextInfo.Restore();
				}
				return nextStep;
			} catch {
				services.DesktopService.DriverContextInfo.Attempts--;
				return DesktopProcessEnum.ShipmentAllocationOperations;
			}
		}
		
		public static DesktopProcessEnum OrderInformation(Services services, Interface.DLx.Excel.Commands.CoordenadasCommandResponse response)
		{
			try {
				DesktopProcessEnum nextStep = DesktopProcessEnum.Waiting;
				var orderInformation = new SOW.Automation.Interface.DLx.Windows.OrderInformation.OrderInformation1920x1080(services.WebService, services.DesktopService, services.OCRService);
				
				if (!orderInformation.WindowCheck(@"\OCR\OrderInformationTitle.png")) {
					services.DesktopService.DriverContextInfo.Attempts--;
					return DesktopProcessEnum.OrderInformation;
				} else {
					orderInformation.Wait(1000);
					orderInformation.SelecionarTodosItensTabelaListagemAgendamentos();
					orderInformation.Wait(1000);
					orderInformation.ClicarBotaoFerramentaDeSelecao();
					orderInformation.Wait(1000);
					orderInformation.ClicarJanelaFerramentaDeSelecao();
					orderInformation.Wait(1000);
					orderInformation.PreencherCampoCarrierMoveID(response.RpaDadosStageInfo.Ms);
					orderInformation.Wait(1000);
					orderInformation.ClicarJanelaFerramentaDeSelecaoBotaoOK();
					orderInformation.Wait(1000);
					orderInformation.ClicarBotaoAllocate();
					nextStep = DesktopProcessEnum.ProcessOrderBatch;
					services.DesktopService.DriverContextInfo.Attempts = services.DesktopService.DriverContextInfo.Restore();
				}
				return nextStep;
			} catch {
				services.DesktopService.DriverContextInfo.Attempts--;
				return DesktopProcessEnum.OrderInformation;
			}
		}
		
		public static DesktopProcessEnum ProcessOrderBatch(Services services, Interface.DLx.Excel.Commands.CoordenadasCommandResponse response)
		{
			try {
				DesktopProcessEnum nextStep = DesktopProcessEnum.Waiting;
				var processOrderBatch = new SOW.Automation.Interface.DLx.Windows.ProcessOrderBatch.ProcessOrderBatch1920x1080(services.WebService, services.DesktopService, services.OCRService);
				var orderInformation = new SOW.Automation.Interface.DLx.Windows.ProcessOrderBatch.ProcessOrderBatch1920x1080(services.WebService, services.DesktopService, services.OCRService);
				
				if (!processOrderBatch.WindowCheck(@"\OCR\ProcessOrderBatchTitle.png")) {
					services.DesktopService.DriverContextInfo.Attempts--;
					return DesktopProcessEnum.ProcessOrderBatch;
				} else {
					processOrderBatch.ClicarCampoDestinationArea();
					//processOrderBatch.PreencherCampoDestinationArea(System.String.Concat("1STGO", shipment.Temperatura));
					switch (response.RpaDadosStageInfo.FamiliaDlx) {
						case SOW.Automation.Interface.DLx.Excel.Enums.EStatusStageDlx.AMB:
							processOrderBatch.PreencherCampoDestinationArea(1);
							break;
						case SOW.Automation.Interface.DLx.Excel.Enums.EStatusStageDlx.CLI:
							processOrderBatch.PreencherCampoDestinationArea(2);
							break;
						case SOW.Automation.Interface.DLx.Excel.Enums.EStatusStageDlx.AMBCLI:
							processOrderBatch.PreencherCampoDestinationArea(3);
							break;
						default:
							processOrderBatch.PreencherCampoDestinationArea(1);
							break;
					}
					processOrderBatch.Wait(1000);
					processOrderBatch.ClicarCampoDestinationLocation();
					processOrderBatch.ClicarCampoDestinationLocation();
					processOrderBatch.PreencherCampoDestinationLocation(response.Stage);
					processOrderBatch.KeyboardPress(SOW.Automation.Common.KeyboardEnum.DOWN);
					processOrderBatch.KeyboardPress(SOW.Automation.Common.KeyboardEnum.UP);
					processOrderBatch.Wait(1000);
					processOrderBatch.ClicarBotaoAllocate();
					processOrderBatch.Wait(1000);
					processOrderBatch.ClicarBotaoAllocate();
					processOrderBatch.Wait(3000);
					if (!processOrderBatch.WindowCheck(@"\OCR\ProcessOrderBatchAllocationSummaryWindowTitle.png")
					    && !processOrderBatch.WindowCheck(@"\OCR\ProcessOrderBatchAllocationSummaryWindowPanelTitle.png")) {
						services.DesktopService.DriverContextInfo.Attempts--;
						return DesktopProcessEnum.ProcessOrderBatch;
					} else {
						processOrderBatch.Wait(1000);
						processOrderBatch.ClicarJanelaAllocationSummaryBotaoOk();
						if (orderInformation.WindowCheck(@"\OCR\OrderInformationTitle.png")) {
							processOrderBatch.Wait(1000);
							orderInformation.ClicarBotaoHome();
						}
						nextStep = DesktopProcessEnum.ShipmentAllocationOperations;
						services.DesktopService.DriverContextInfo.Attempts = services.DesktopService.DriverContextInfo.Restore();
					}
				}
				return nextStep;
			} catch {
				services.DesktopService.DriverContextInfo.Attempts--;
				return DesktopProcessEnum.ProcessOrderBatch;
			}
		}
		
		public static DesktopProcessEnum CloseApplication(Services services)
		{
			try {
				var main = new SOW.Automation.Interface.DLx.Windows.Main.Main1920x1080(services.WebService, services.DesktopService, services.OCRService);
				main.WindowOpen("DigitaLogistix - \\\\Remote");
				main.ApplicationClose();
				return DesktopProcessEnum.Finish;
			} catch {
				return DesktopProcessEnum.Exception;
			}
		}
	}
}
