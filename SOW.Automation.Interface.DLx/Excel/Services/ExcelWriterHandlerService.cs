using Microsoft.Office.Interop.Excel;
using SOW.Automation.Interface.DLx.Excel.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SOW.Automation.Interface.DLx.Excel.Services
{
	public class ExcelWriterHandlerService : CoordernadasExcel
	{
		string _caminho;
		string _nomeArquivo;
		Application excel;
		Workbook workbook;
		Worksheet worksheet;

		public ExcelWriterHandlerService(string caminho, string nomeArquivo)
		{
			excel = new Application();
			_caminho = caminho;
			_nomeArquivo = nomeArquivo;
		}





        public string PopulaPlanilhaExcel(CoordenadasExcelWriter coordenadasExcel)
        {
            string stage = "";
            var lista = coordenadasExcel.Detalhes.FindAll(a => a.Pula == false);
            try
            {


                workbook = excel.Workbooks.Open(_caminho + _nomeArquivo, ReadOnly: false, Editable: true);
                worksheet = workbook.Worksheets.Item[1] as Worksheet;
                if (worksheet != null)
                    foreach (var linha in lista)
                    {
                        int cont = 0;
                        foreach (var coluna in linha.Colunas)
                        {
                            if (cont == 0)
                            {
                                ((Range)worksheet.Rows.Cells[linha.PolicaoLinha, coluna + 1]).Value = coordenadasExcel.DadosRpa.Ms;
                                stage = ((Range)worksheet.Rows.Cells[linha.PolicaoLinha, coluna - 1]).Value.ToString();
                            }
                            else if (cont == 1)
                            {
                                ((Range)worksheet.Rows.Cells[linha.PolicaoLinha, coluna + 1]).Value = coordenadasExcel.DadosRpa.Sid;
                                stage = ((Range)worksheet.Rows.Cells[linha.PolicaoLinha, coluna - 3]).Value.ToString();
                                cont = 0;
                            }
                            cont++;
                        }
                    }
                excel.Application.ActiveWorkbook.Save();
                excel.Application.Quit();
                excel.Quit();
                return stage;
            }
            catch
            {
                var desistoDestaMerda = false;
                for (int i = 9; i > 0; i--)
                {
                    Console.Write("\r A Planilha Está Em Uso, nova tentativa em :  " + i);
                    Thread.Sleep(1000);
                    if (i == 1)
                        desistoDestaMerda = true;
                }

                if (!desistoDestaMerda)
                    PopulaPlanilhaExcel(coordenadasExcel);
                return stage;
            }
        }
    }
}
