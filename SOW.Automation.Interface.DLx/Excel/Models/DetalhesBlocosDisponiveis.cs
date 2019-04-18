using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOW.Automation.Interface.DLx.Excel.Models
{
    public class DetalhesBlocosDisponiveis
    {
        public DetalhesBlocosDisponiveis()
        {

        }
        public Enums.EFamiliaStages Familia { get; set; }
        public int TamanhoBloco { get; set; }
        public int QtdBlocoLivre { get; set; }
    }
}
