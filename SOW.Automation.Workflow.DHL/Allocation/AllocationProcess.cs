using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SOW.Automation.Interface.DLx.Windows.TaskManagementDetailed;
using SOW.Automation.Interface.DLx.Excel;
using SOW.Automation.Interface.DLx.Excel.Models;
using SOW.Automation.Interface.DLx.Excel.Services;
using SOW.Automation.Interface.DLx.Models;

namespace SOW.Automation.Workflow.DHL.Allocation
{
	public static class AllocationProcess
	{
		public static int Run(Services services)
		{
			try {
				AllocationProcessEnum currentStep = AllocationProcessEnum.Waiting;
				while (!currentStep.Equals(AllocationProcessEnum.Finish)) {
					switch (currentStep) {
						case AllocationProcessEnum.InitializeContext:
							currentStep = InitializeContext();
							break;
						case AllocationProcessEnum.InitializeServices:
							currentStep = InitializeServices();
							break;
						case AllocationProcessEnum.WebProcess:
							currentStep = WebProcess(services);
							break;
						case AllocationProcessEnum.DesktopProcess:
							currentStep = DesktopProcess(services);
							break;
						case AllocationProcessEnum.Close:
							currentStep = CloseProcess(services);
							break;
						case AllocationProcessEnum.Exception:
							currentStep = AllocationProcessEnum.Close;
							break;
						case AllocationProcessEnum.Waiting:
							currentStep = AllocationProcessEnum.InitializeContext;
							break;
					}
				}
				return 1;
			} catch {
				//return AllocationProcessEnum.Exception;
				return 0;
			}
		}
		
		public static AllocationProcessEnum InitializeContext()
		{
			try {
				return AllocationProcessEnum.InitializeServices;
			} catch {
				return AllocationProcessEnum.Exception;
			}
		}
		
		public static AllocationProcessEnum InitializeServices()
		{
			try {
				return AllocationProcessEnum.WebProcess;
			} catch {
				return AllocationProcessEnum.Exception;
			}
		}
		
		public static AllocationProcessEnum WebProcess(Services services)
		{
			try {
				WebProcessEnum flow = WebProcessEnum.Waiting;
				while (!flow.Equals(WebProcessEnum.Close) && services.WebService.DriverContextInfo.Attempts > 0) {
					switch (flow) {
						case WebProcessEnum.Login:
							flow = Allocation.WebProcess.Login(services);
							break;
						case WebProcessEnum.AccessMondelezAraucaria:
							flow = Allocation.WebProcess.AccessMondelezAraucaria(services);
							break;
						case WebProcessEnum.Exception:
							services.WebService.DriverContextInfo.Attempts--;
							break;
						case WebProcessEnum.Waiting:
							flow = WebProcessEnum.Login;
							break;
					}
				}
				return  services.WebService.DriverContextInfo.Attempts <= 0 ? AllocationProcessEnum.Exception : AllocationProcessEnum.DesktopProcess;
			} catch {
				return AllocationProcessEnum.Exception;
			}
		}
		
		public static AllocationProcessEnum DesktopProcess(Services services)
		{
			try {
				DesktopProcessEnum flow = DesktopProcessEnum.Waiting;
				while (!flow.Equals(DesktopProcessEnum.Close) && services.DesktopService.DriverContextInfo.Attempts > 0) {
					switch (flow) {
						case DesktopProcessEnum.SelectApplication:
							flow = Allocation.DesktopProcess.SelectApplication(services);
							break;
						case DesktopProcessEnum.Login:
							flow = Allocation.DesktopProcess.Login(services);
							break;
						case DesktopProcessEnum.Main:
							flow = Allocation.DesktopProcess.Main(services);
							break;
						case DesktopProcessEnum.TaskManagement:
							flow = Allocation.DesktopProcess.TaskManagement(services);
							break;
						case DesktopProcessEnum.TaskManagementDetailed:
							flow = Allocation.DesktopProcess.TaskManagementDetailed(services);
							break;
						case DesktopProcessEnum.ShipmentAllocationOperations:
							
							var rpas = new List<RpaDadosStageInfo>();
							
							string path = System.String.Concat(System.Environment.CurrentDirectory, @"\Files", @"\");
							string file = @"Planilha de Testes.xlsm";
							
							var taskManagementDetailed = new TaskManagementDetailed1920x1080(services.WebService, services.DesktopService, services.OCRService);
							IList<ShipmentDetailed> ShipmentDetaileds = taskManagementDetailed.ModelarItensSelecionados().Where(x => x != null && x.StatusMS != null && x.StatusMS.ToLower().Contains("ready")).ToList();
							foreach (var shipment in ShipmentDetaileds.Take(5)) {
								double boxes = ((shipment.TotalCaixas != null && !System.String.IsNullOrWhiteSpace(shipment.TotalCaixas)) ? int.Parse(shipment.TotalCaixas) : 1);
								double pallets = ((shipment.TotalPallets != null && !System.String.IsNullOrWhiteSpace(shipment.TotalPallets)) ? int.Parse(shipment.TotalPallets) : 1);
								double special = ((!System.String.IsNullOrWhiteSpace(shipment.PadraoEspecial)) ? 1.3 : 1);
								var rpa = new RpaDadosStageInfo {
									Ms = shipment.MS,
									Sid = shipment.ShipmentID,
									Status = Interface.DLx.Excel.Enums.EStatusStage.Ready,
									FamiliaDlx = Interface.DLx.Helpers.TemperatureHelper.GetTemperature(shipment.Temperatura),
									QtdPalets = (int)System.Math.Round((boxes / Interface.DLx.Helpers.FamilyHelper.BoxesToPallets(shipment.Familia) + pallets) * special)
									//QtdPalets = Convert.ToInt32(int.Parse(((shipment.TotalCaixas != null && !String.IsNullOrWhiteSpace(shipment.TotalCaixas)) ? shipment.TotalCaixas : "0")) / Family.ConvertBoxesToPallets(shipment.Familia) + int.Parse(((shipment.TotalPallets != null && !String.IsNullOrWhiteSpace(shipment.TotalPallets)) ? shipment.TotalPallets : "0")) * int.Parse(((!String.IsNullOrWhiteSpace(shipment.PadraoEspecial)) ? "1.3" : "1")))
								};
								rpas.Add(rpa);
							}
							
							var workSheet = new ExcelHandler(path, file, new JsonServices(), rpas);
							var responses = workSheet.AlocarObjeto();
							
							foreach (var response in responses.Where(x=>x.Alocado)) {
								ShipmentDetaileds.ToList().Where(x => x.MS.Equals(response.RpaDadosStageInfo.Ms)).FirstOrDefault().StatusMS = "In-Progress";
								ShipmentDetaileds.ToList().Where(x => x.MS.Equals(response.RpaDadosStageInfo.Ms)).FirstOrDefault().Temperatura = Interface.DLx.Helpers.TemperatureHelper.GetTemperature(response.RpaDadosStageInfo.FamiliaDlx);
								Allocation.DesktopProcess.ShipmentAllocationOperations(services, response);
								Allocation.DesktopProcess.OrderInformation(services, response);
								Allocation.DesktopProcess.ProcessOrderBatch(services, response);
							}
							
							Interface.DLx.Excel.Services.ExcelService.InsertData(path, file, ShipmentDetaileds);
							flow = DesktopProcessEnum.Close;
							break;
						case DesktopProcessEnum.Exception:
							//flow = DesktopProcessEnum.Close;
							services.DesktopService.DriverContextInfo.Attempts--;
							break;
						case DesktopProcessEnum.Waiting:
							flow = DesktopProcessEnum.SelectApplication;
							break;
					}
				}
				//while (!this.DeskAutomationService.BaseElement.WindowExists("E²e™ - Consumer Driven Optimization - \\\\Remote", 0)) {
				return services.DesktopService.DriverContextInfo.Attempts <= 0 ? AllocationProcessEnum.Exception : AllocationProcessEnum.Close;
			} catch (System.Exception e) {
				System.Console.WriteLine(e.StackTrace);
				return AllocationProcessEnum.Exception;
			}
		}
		
		public static AllocationProcessEnum CloseProcess(Services services)
		{
			try {
				var main = new SOW.Automation.Interface.DLx.Windows.Main.Main1920x1080(services.WebService, services.DesktopService, services.OCRService);
				main.ApplicationClose();
				return AllocationProcessEnum.Finish;
			} catch {
				return AllocationProcessEnum.Exception;
			}
		}
	}
}
