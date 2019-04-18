using SOW.Automation.Interface.DLx.Excel.Commands;
using SOW.Automation.Interface.DLx.Excel.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SOW.Automation.Interface.DLx.Excel.Services
{
    public class BlocosGeraisAlocacoesService
    {
        List<CoordenadasExcelWriter> _coordenadasExcel;
        ExcelWriterHandlerService _exl;

        public BlocosGeraisAlocacoesService(List<CoordenadasExcelWriter> coordenadasExcel, ExcelWriterHandlerService exl)
        {
            _coordenadasExcel = coordenadasExcel;
            _exl = exl;
        }

        public  List<CoordenadasCommandResponse> AlocaEspacosStage()
        {
            List<CoordenadasCommandResponse> responses = new List<CoordenadasCommandResponse>();
            foreach (var coordenadaExcel in _coordenadasExcel)
            {
                if (coordenadaExcel.CoordenadaDisponivel)
                {
                    string stage = _exl.PopulaPlanilhaExcel(coordenadaExcel);
                    responses.Add(new CoordenadasCommandResponse() { CoordenadaDisponivel = true, Alocado = true, RpaDadosStageInfo = coordenadaExcel.DadosRpa, Stage = stage });
                }
                else
                {
                    responses.Add(new CoordenadasCommandResponse() { CoordenadaDisponivel = false, Alocado = false, RpaDadosStageInfo = coordenadaExcel.DadosRpa, Stage = "" });
                }
            }

            return responses;
           
        }

    }
}
