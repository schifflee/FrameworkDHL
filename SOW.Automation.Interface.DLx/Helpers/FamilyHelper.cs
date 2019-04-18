using System;
using System.Collections.Generic;
namespace SOW.Automation.Interface.DLx.Helpers
{
	public static class FamilyHelper
	{
		public static int BoxesToPallets(string description)
		{
			switch (description) {
				case "35-BALA GOMA":
					return 57;
				case "35-BALA GOMA PESADOS":
					return 33;
				case "50-BISCOITOS":
					return 54;
				case "CHOCOLATES EXPORTAÇAO":
					return 79;
				case "30-CHOCOLATES":
					return 56;
				case "20-FERMENTOS":
					return 54;
				case "80-MATERIA PRIMA":
					return 10;
				case "90-PASCOA":
					return 47;
				case "70-SEMI ACABADO":
					return 10;
				case "75-SEMI ACABADO PESADOS":
					return 10;
				case "10-SOBREMESAS E FERMENTOS":
					return 10;
				case "20-SOBREMESAS":
					return 142;
				case "10-SUCOS":
					return 120;
				default:
					return 10;
			}
		}
	}
}
