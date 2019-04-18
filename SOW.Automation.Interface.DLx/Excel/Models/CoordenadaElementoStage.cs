using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOW.Automation.Interface.DLx.Excel.Models
{
    public class CoordenadaElementoStage
    {
        public CoordenadaElementoStage()
        {
            LinhaExcel = new List<ExceLinhaColuna>();
        }
        public int PolicaoLinha { get; set; }
        public int QtdPalets { get; set; }
        public string PosicaoColunas { get; set; }
        public List<ExceLinhaColuna> LinhaExcel { get; set; }
        public RpaDadosStageInfo DadosRpa { get; set; }
        public bool CoordenadaDisponivel { get; set; }

    }
}
