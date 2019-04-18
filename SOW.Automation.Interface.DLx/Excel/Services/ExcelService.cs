using System.Collections.Generic;
using Microsoft.Office.Interop.Excel;
using System;
using SOW.Automation.Interface.DLx.Models;
namespace SOW.Automation.Interface.DLx.Excel.Services
{
	public static class ExcelService
	{
		public static void InsertData(string path, string file, IList<ShipmentDetailed> shipmentDetaileds)
		{
			var Excel = new Application();
			try {
				var Workbook = Excel.Workbooks.Open(
                    String.Concat(path, file),
                    ReadOnly: false,
                    Editable: true
                );
				var Worksheet = Workbook.Worksheets.Item[3] as Worksheet;
				for (int i = 0; i < shipmentDetaileds.Count; i++) {
					((Range)Worksheet.Rows.Cells[i + 2, 1]).Value = shipmentDetaileds[i].Temperatura;
					((Range)Worksheet.Rows.Cells[i + 2, 2]).Value = shipmentDetaileds[i].Familia;
					((Range)Worksheet.Rows.Cells[i + 2, 3]).Value = shipmentDetaileds[i].MS;
					((Range)Worksheet.Rows.Cells[i + 2, 4]).Value = shipmentDetaileds[i].Shipment;
					((Range)Worksheet.Rows.Cells[i + 2, 5]).Value = shipmentDetaileds[i].Delivery;
					((Range)Worksheet.Rows.Cells[i + 2, 6]).Value = shipmentDetaileds[i].Parada;
					((Range)Worksheet.Rows.Cells[i + 2, 7]).Value = shipmentDetaileds[i].TipoPedido;
					((Range)Worksheet.Rows.Cells[i + 2, 8]).Value = shipmentDetaileds[i].DataCriacao;
					((Range)Worksheet.Rows.Cells[i + 2, 9]).Value = shipmentDetaileds[i].DataAgendamento;
					((Range)Worksheet.Rows.Cells[i + 2, 10]).Value = shipmentDetaileds[i].Cliente;
					((Range)Worksheet.Rows.Cells[i + 2, 11]).Value = shipmentDetaileds[i].Cidade;
					((Range)Worksheet.Rows.Cells[i + 2, 12]).Value = shipmentDetaileds[i].Estado;
					((Range)Worksheet.Rows.Cells[i + 2, 13]).Value = shipmentDetaileds[i].FefoEspecial;
					((Range)Worksheet.Rows.Cells[i + 2, 14]).Value = shipmentDetaileds[i].Transportadora;
					((Range)Worksheet.Rows.Cells[i + 2, 15]).Value = shipmentDetaileds[i].Placa;
					((Range)Worksheet.Rows.Cells[i + 2, 16]).Value = shipmentDetaileds[i].TipoVeiculo;
					((Range)Worksheet.Rows.Cells[i + 2, 17]).Value = shipmentDetaileds[i].TipoCarregamento;
					((Range)Worksheet.Rows.Cells[i + 2, 18]).Value = shipmentDetaileds[i].StatusMS;
					((Range)Worksheet.Rows.Cells[i + 2, 19]).Value = shipmentDetaileds[i].StageDepositado;
					((Range)Worksheet.Rows.Cells[i + 2, 20]).Value = shipmentDetaileds[i].CheckIn;
					((Range)Worksheet.Rows.Cells[i + 2, 21]).Value = shipmentDetaileds[i].DataDoca;
					((Range)Worksheet.Rows.Cells[i + 2, 22]).Value = shipmentDetaileds[i].DataPatioInterno;
					((Range)Worksheet.Rows.Cells[i + 2, 23]).Value = shipmentDetaileds[i].DataLiberacaoVeiculo;
					((Range)Worksheet.Rows.Cells[i + 2, 24]).Value = shipmentDetaileds[i].DataNF;
					((Range)Worksheet.Rows.Cells[i + 2, 25]).Value = shipmentDetaileds[i].TempoPermanencia;
					((Range)Worksheet.Rows.Cells[i + 2, 26]).Value = shipmentDetaileds[i].LocalVeiculo;
					((Range)Worksheet.Rows.Cells[i + 2, 27]).Value = shipmentDetaileds[i].Peso;
					((Range)Worksheet.Rows.Cells[i + 2, 28]).Value = shipmentDetaileds[i].TotalCaixas;
					((Range)Worksheet.Rows.Cells[i + 2, 29]).Value = shipmentDetaileds[i].SeparacaoParcial;
					((Range)Worksheet.Rows.Cells[i + 2, 30]).Value = shipmentDetaileds[i].Observacoes;
					((Range)Worksheet.Rows.Cells[i + 2, 31]).Value = shipmentDetaileds[i].PadraoEspecial;
					((Range)Worksheet.Rows.Cells[i + 2, 32]).Value = shipmentDetaileds[i].ShipmentID;
					((Range)Worksheet.Rows.Cells[i + 2, 33]).Value = shipmentDetaileds[i].ShipmentID;
				}
			} catch (Exception) {
				throw;
			} finally {
				if (Excel != null && Excel.Application != null) {
					if (Excel.Application.ActiveWorkbook != null)
						Excel.Application.ActiveWorkbook.Save();
					Excel.Application.Quit();
					Excel.Quit();
				}
			}
		}
	}
}
