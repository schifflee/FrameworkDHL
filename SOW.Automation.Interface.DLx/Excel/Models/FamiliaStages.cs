using SOW.Automation.Interface.DLx.Excel.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOW.Automation.Interface.DLx.Excel.Models
{
    public class FamiliaStages
    {
        public FamiliaStages()
        {
            Colunas = new List<int>();
        }
        public int LinhaColuna { get; set; }
     //   public string Coluna { get; set; }
        public List<int> Colunas { get; set; }
        public EStatusStage? Status { get; set; }
        public string Ms { get; set; }
        public string Stage { get; set; }
        public int CapacidadeStage { get; set; }
        public bool Pula { get; set; }
        public string Sid { get; set; }
        public EFamiliaStages Familia { get; set; }
        public bool MsVazio { get; set; }
        public bool StatusVazio { get; set; }
        public bool StageColuna { get; set; }
    }
}
