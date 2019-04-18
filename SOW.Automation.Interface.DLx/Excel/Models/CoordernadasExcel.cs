using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOW.Automation.Interface.DLx.Excel.Models
{
    public class CoordernadasExcel
    {
        public IList<CoordernadasExcel> CoordenadasExcel { get; set; }
        public string DescricaoCoordenada { get; set; }
        public int LinhaInicio { get; set; }
        public int LinhaFim { get; set; }
        public int ColunaInicio { get; set; }
        public int ColunaFim { get; set; }

        protected void PopulaCoordenadas()
        {
            CoordernadasExcel coord = new CoordernadasExcel
            {
                LinhaInicio = 8,
                LinhaFim = 84,
                ColunaInicio = 2,
                ColunaFim = 8,
                DescricaoCoordenada = "AMBIENTE"
            };
            CoordernadasExcel coord2 = new CoordernadasExcel
            {
                LinhaInicio = 8,
                LinhaFim = 82,
                ColunaInicio = 10,
                ColunaFim = 16,
                DescricaoCoordenada = "REVERSÍVEL"
            };
            CoordernadasExcel coord3 = new CoordernadasExcel
            {
                LinhaInicio = 8,
                LinhaFim = 82,
                ColunaInicio = 18,
                ColunaFim = 24,
                DescricaoCoordenada = "CLIMATIZADA"
            };
            CoordenadasExcel.Add(coord);
            CoordenadasExcel.Add(coord2);
            CoordenadasExcel.Add(coord3);
        }

    }
}
