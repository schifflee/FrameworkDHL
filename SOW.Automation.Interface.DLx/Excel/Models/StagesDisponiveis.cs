using SOW.Automation.Interface.DLx.Excel.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOW.Automation.Interface.DLx.Excel.Models
{
    public class StagesDisponiveis
    {
        public int LinhaColuna { get; set; }
        public string Coluna { get; set; }
        public EFamiliaStages Familia { get; set; }
        public int QtdStageDisponivel { get; set; }
        public int QtdPalets { get; set; }
    }
}
