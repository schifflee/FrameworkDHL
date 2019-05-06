using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SOW.Automation.Interface.DLx.Excel;
using SOW.Automation.Interface.DLx.Excel.Models;
using SOW.Automation.Interface.DLx.Excel.Services;

using System.Linq;

namespace SOW.Automation.Workflow.Omni
{
    public static class Test
    {
        public static void Run(Services services)
        {
            try
            {
                var rpas = new List<RpaDadosStageInfo>();

                string path = System.String.Concat(System.Environment.CurrentDirectory, @"\Files", @"\");
                string file = @"Planilha de Testes.xlsm";
                var taskManagementDetailed = new SOW.Automation.Interface.DLx.Windows.TaskManagementDetailed.TaskManagementDetailed1920x1080(services.WebService, services.DesktopService, services.OCRService);
                System.Collections.Generic.IList<Interface.DLx.Models.ShipmentDetailed> ShipmentDetaileds = taskManagementDetailed.ModelarItensSelecionados().Where(x => x != null && x.StatusMS != null && x.StatusMS.ToLower().Contains("ready")).ToList().Take(2).ToList();

                foreach (var shipment in ShipmentDetaileds.Take(5))
                {
                    double boxes = ((shipment.TotalCaixas != null && !System.String.IsNullOrWhiteSpace(shipment.TotalCaixas)) ? int.Parse(shipment.TotalCaixas) : 0);
                    double pallets = ((shipment.TotalPallets != null && !System.String.IsNullOrWhiteSpace(shipment.TotalPallets)) ? int.Parse(shipment.TotalPallets) : 0);
                    double special = ((!System.String.IsNullOrWhiteSpace(shipment.PadraoEspecial)) ? 1.3 : 1);

                    var rpa = new Interface.DLx.Excel.Models.RpaDadosStageInfo
                    {
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
            }
            catch (System.Exception e)
            {
                System.Console.WriteLine(e.Message);
            }
        }
    }
}
