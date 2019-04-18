using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SOW.Automation.Interface.DLx.Excel;
using SOW.Automation.Interface.DLx.Excel.Models;
using SOW.Automation.Interface.DLx.Excel.Services;
namespace SOW.Automation.Workflow.DHL.Exception
{
	public static class ExceptionProcess
	{
		public static int Run(Services services)
		{
			try {
				ExceptionProcessEnum currentStep = ExceptionProcessEnum.Waiting;
				while (!currentStep.Equals(ExceptionProcessEnum.Finish)) {
					switch (currentStep) {
						case ExceptionProcessEnum.InitializeContext:
							currentStep = InitializeContext();
							break;
						case ExceptionProcessEnum.InitializeServices:
							currentStep = InitializeServices();
							break;
						case ExceptionProcessEnum.WebProcess:
							currentStep = WebProcess(services);
							break;
						case ExceptionProcessEnum.DesktopProcess:
							currentStep = DesktopProcess(services);
							break;
						case ExceptionProcessEnum.Close:
							currentStep = CloseProcess(services);
							break;
						case ExceptionProcessEnum.Exception:
							currentStep = ExceptionProcessEnum.Close;
							break;
						case ExceptionProcessEnum.Waiting:
							currentStep = ExceptionProcessEnum.InitializeContext;
							break;
					}
				}
				return 1;
			} catch {
				//return ExceptionProcessEnum.Exception;
				return 0;
			}
		}
		
		public static ExceptionProcessEnum InitializeContext()
		{
			try {
				return ExceptionProcessEnum.InitializeServices;
			} catch {
				return ExceptionProcessEnum.Exception;
			}
		}
		
		public static ExceptionProcessEnum InitializeServices()
		{
			try {
				return ExceptionProcessEnum.WebProcess;
			} catch {
				return ExceptionProcessEnum.Exception;
			}
		}
		
		public static ExceptionProcessEnum WebProcess(Services services)
		{
			try {
				WebProcessEnum flow = WebProcessEnum.Waiting;
				while (!flow.Equals(WebProcessEnum.Close) && services.WebService.DriverContextInfo.Attempts > 0) {
					switch (flow) {
						case WebProcessEnum.Login:
							flow = Exception.WebProcess.Login(services);
							break;
						case WebProcessEnum.AccessMondelezAraucaria:
							flow = Exception.WebProcess.AccessMondelezAraucaria(services);
							break;
						case WebProcessEnum.Exception:
							services.WebService.DriverContextInfo.Attempts--;
							break;
						case WebProcessEnum.Waiting:
							flow = WebProcessEnum.Login;
							break;
					}
				}
				return  services.WebService.DriverContextInfo.Attempts <= 0 ? ExceptionProcessEnum.Exception : ExceptionProcessEnum.DesktopProcess;
			} catch {
				return ExceptionProcessEnum.Exception;
			}
		}
		
		public static ExceptionProcessEnum DesktopProcess(Services services)
		{
			try {
				DesktopProcessEnum flow = DesktopProcessEnum.Waiting;
				while (!flow.Equals(DesktopProcessEnum.Close) && services.DesktopService.DriverContextInfo.Attempts > 0) {
					switch (flow) {
						case DesktopProcessEnum.SelectApplication:
							flow = Exception.DesktopProcess.SelectApplication(services);
							break;
						case DesktopProcessEnum.Login:
							flow = Exception.DesktopProcess.Login(services);
							break;
						case DesktopProcessEnum.Main:
							flow = Exception.DesktopProcess.Main(services);
							break;
//						case DesktopProcessEnum.TaskManagement:
//							flow = Exception.DesktopProcess.TaskManagement(services);
//							break;
//						case DesktopProcessEnum.TaskManagementDetailed:
//							flow = Exception.DesktopProcess.TaskManagementDetailed(services);
//							break;
//						case DesktopProcessEnum.ShipmentExceptionOperations:
//							
//							var rpas = new List<RpaDadosStageInfo>();
//							
//							string path = System.String.Concat(System.Environment.CurrentDirectory, @"\Files", @"\");
//							string file = @"Planilha de Testes.xlsm";
//							
//							var taskManagementDetailed = new SOW.Automation.Interface.DLx.Windows.TaskManagementDetailed.TaskManagementDetailed1920x1080(services.WebService, services.DesktopService, services.OCRService);
//							System.Collections.Generic.IList<Interface.DLx.Models.ShipmentDetailed> ShipmentDetaileds = taskManagementDetailed.ModelarItensSelecionados().Where(x => x != null && x.StatusMS != null && x.StatusMS.ToLower().Contains("ready")).ToList();
//							foreach (var shipment in ShipmentDetaileds.Take(5)) {
//								double boxes = ((shipment.TotalCaixas != null && !System.String.IsNullOrWhiteSpace(shipment.TotalCaixas)) ? int.Parse(shipment.TotalCaixas) : 1);
//								double pallets = ((shipment.TotalPallets != null && !System.String.IsNullOrWhiteSpace(shipment.TotalPallets)) ? int.Parse(shipment.TotalPallets) : 1);
//								double special = ((!System.String.IsNullOrWhiteSpace(shipment.PadraoEspecial)) ? 1.3 : 1);
//								var rpa = new Interface.DLx.Excel.Models.RpaDadosStageInfo {
//									Ms = shipment.MS,
//									Sid = shipment.ShipmentID,
//									Status = Interface.DLx.Excel.Enums.EStatusStage.Ready,
//									FamiliaDlx = Interface.DLx.Helpers.TemperatureHelper.GetTemperature(shipment.Temperatura),
//									QtdPalets = (int)System.Math.Round((boxes / Interface.DLx.Helpers.FamilyHelper.BoxesToPallets(shipment.Familia) + pallets) * special)
//									//QtdPalets = Convert.ToInt32(int.Parse(((shipment.TotalCaixas != null && !String.IsNullOrWhiteSpace(shipment.TotalCaixas)) ? shipment.TotalCaixas : "0")) / Family.ConvertBoxesToPallets(shipment.Familia) + int.Parse(((shipment.TotalPallets != null && !String.IsNullOrWhiteSpace(shipment.TotalPallets)) ? shipment.TotalPallets : "0")) * int.Parse(((!String.IsNullOrWhiteSpace(shipment.PadraoEspecial)) ? "1.3" : "1")))
//								};
//								rpas.Add(rpa);
//							}
//							
//							var workSheet = new ExcelHandler(path, file, new JsonServices(), rpas);
//							var responses = workSheet.AlocarObjeto();
//							
//							foreach (var response in responses.Where(x=>x.Alocado)) {
//								ShipmentDetaileds.ToList().Where(x => x.MS.Equals(response.RpaDadosStageInfo.Ms)).FirstOrDefault().StatusMS = "In-Progress";
//								ShipmentDetaileds.ToList().Where(x => x.MS.Equals(response.RpaDadosStageInfo.Ms)).FirstOrDefault().Temperatura = Interface.DLx.Helpers.TemperatureHelper.GetTemperature(response.RpaDadosStageInfo.FamiliaDlx);
//								Exception.DesktopProcess.ShipmentExceptionOperations(services, response);
//								Exception.DesktopProcess.OrderInformation(services, response);
//								Exception.DesktopProcess.ProcessOrderBatch(services, response);
//							}
//							
//							Interface.DLx.Excel.Services.ExcelService.InsertData(path, file, ShipmentDetaileds);
//							flow = DesktopProcessEnum.Close;
//							break;
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
				return services.DesktopService.DriverContextInfo.Attempts <= 0 ? ExceptionProcessEnum.Exception : ExceptionProcessEnum.Close;
			} catch (System.Exception e) {
				System.Console.WriteLine(e.StackTrace);
				return ExceptionProcessEnum.Exception;
			}
		}
		
		public static ExceptionProcessEnum CloseProcess(Services services)
		{
			try {
				var main = new SOW.Automation.Interface.DLx.Windows.Main.MainOCR(services.WebService, services.DesktopService, services.OCRService);
				Interface.DLx.Helpers.WindowHelper.ButtonCloseClick(main);
				Interface.DLx.Helpers.WindowHelper.ButtonYesClick(main);
				main.ApplicationClose();
				return ExceptionProcessEnum.Finish;
			} catch {
				return ExceptionProcessEnum.Exception;
			}
		}
	}
}
