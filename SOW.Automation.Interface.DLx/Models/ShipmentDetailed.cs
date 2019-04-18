namespace SOW.Automation.Interface.DLx.Models
{
	public class ShipmentDetailed : Shipment
	{
		public string PadraoEspecial { get; set; }
		public string Shipment { get; set; }
		public string Delivery { get; set; }
		public string Parada { get; set; }
		public string TipoPedido { get; set; }
		public string Cliente { get; set; }
		public string Cidade { get; set; }
		public string Estado { get; set; }
		public string FefoEspecial { get; set; }
		public string Observacoes { get; set; }
		public string ShipmentID { get; set; }
	}
}
