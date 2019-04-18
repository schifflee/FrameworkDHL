using System;
using System.Collections.Generic;
using System.Linq;
using SOW.Automation.Interface.DLx.Excel.Commands;
using SOW.Automation.Interface.DLx.Excel.Enums;
using SOW.Automation.Interface.DLx.Excel.Models;
using SOW.Automation.Interface.DLx.Excel.Services;
using SOW.Automation.Interface.DLx.Excel.Services;
using SOW.Automation.Interface.DLx.Helpers;

namespace SOW.Automation.Interface.DLx.Excel
{
    public class ExcelHandler
    {
        #region Variaveis
        private ExcelHelper _helper;
        private ExcelReaderHandlerService excel;
        private ExcelWriterHandlerService rexcel;
        private List<CoordenadasExcelWriter> coordenadas;
        #endregion

        public ExcelHandler(string path,
            string file,
            JsonServices service,
            List<RpaDadosStageInfo> lrpa)
        {
            _helper = new ExcelHelper(path, file, service, lrpa);
            excel = new ExcelReaderHandlerService(_helper._path, _helper._file);
            rexcel = new ExcelWriterHandlerService(_helper._path, _helper._file);
            coordenadas = new List<CoordenadasExcelWriter>();
        }


        public List<CoordenadasCommandResponse> AlocarObjeto()
        {
            List<CoordenadasCommandResponse> listaCoord = new List<CoordenadasCommandResponse>();

            try
            {
                int cont = 0;
                BlocosGeraisDisponiveisService aloc = new BlocosGeraisDisponiveisService(_helper);
                foreach (var rpa in _helper._lrpa)
                {
                    var lista = excel.CarregaPlanilhaExcel();
                    _helper.RemoveBlklPula(lista.ToList());

                    var detalhe = aloc.DetalhesStagesDisponiveis(lista.ToList(), rpa);
                    _helper.AdicionaBlklPula(detalhe.Detalhes);

                    coordenadas.Add(detalhe);
                    _helper.AtualizaDadosDicionario();
                    BlocosGeraisAlocacoesService b = new BlocosGeraisAlocacoesService(coordenadas, rexcel);
                    listaCoord.Add(b.AlocaEspacosStage().FirstOrDefault());
                    cont++;

                    Console.WriteLine(String.Concat("Alocando... ", cont.ToString("000")));
                }

                return listaCoord;

            }
            catch (Exception ex)
            {
                throw;
            }
        }





    }
}
