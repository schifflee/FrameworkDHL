using System.Collections.Generic;

namespace SOW.Automation.Interface.DLx.Excel.Models
{
    public class CoordenadasExcelWriterDetalhes
    {
        public CoordenadasExcelWriterDetalhes()
        {
            Colunas = new List<int>();
        }
        public int PolicaoLinha { get; set; }
        public List<int> Colunas { get; set; }
        public int QtdPalets { get; set; }
        public bool Pula { get; set; }
        public string Ms { get; set; }

    }
}
