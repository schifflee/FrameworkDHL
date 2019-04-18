using SOW.Automation.Interface.DLx.Excel.Enums;
namespace SOW.Automation.Interface.DLx.Helpers
{
	public static class TemperatureHelper
	{
		public static EStatusStageDlx GetTemperature(string temperature) {
			switch (temperature) {
				case "AMB":
					return EStatusStageDlx.AMB;
				case "CLI":
					return EStatusStageDlx.CLI;
				case "PAS":
					return EStatusStageDlx.PAS;
				case "SEM":
					return EStatusStageDlx.SEM;
				case "AMBCLI":
					return EStatusStageDlx.AMBCLI;
				case "AMBPAS":
					return EStatusStageDlx.AMBPAS;
				case "CLIPAS":
					return EStatusStageDlx.CLIPAS;
				default:
					return EStatusStageDlx.AMBCLI;
			}
		}
		
		public static string GetTemperature(EStatusStageDlx temperature) {
			switch (temperature) {
				case EStatusStageDlx.AMB:
					return "AMB";
				case EStatusStageDlx.CLI:
					return "CLI";
				case EStatusStageDlx.PAS:
					return "PAS";
				case EStatusStageDlx.SEM:
					return "SEM";
				case EStatusStageDlx.AMBCLI:
					return "AMBCLI";
				case EStatusStageDlx.AMBPAS:
					return "AMBPAS";
				case EStatusStageDlx.CLIPAS:
					return "CLIPAS";
				default:
					return "AMBCLI";
			}
		}
	}
}
