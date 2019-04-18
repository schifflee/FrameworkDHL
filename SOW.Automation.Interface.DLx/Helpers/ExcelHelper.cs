using SOW.Automation.Interface.DLx.Excel.Models;
using SOW.Automation.Interface.DLx.Excel.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOW.Automation.Interface.DLx.Helpers
{
  public class ExcelHelper
    {
        #region Variaveis
        public string _path;
        public string _file;
        public Dictionary<string, string> dicionario;
        public readonly JsonServices _service;
        public List<RpaDadosStageInfo> _lrpa;
        #endregion
        public ExcelHelper(string path,
            string file,
            JsonServices service,
            List<RpaDadosStageInfo> lrpa)
        {
            _path = path;
            _file = file;         
            _service = service;           
            _lrpa = lrpa;
            this.dicionario = _service.DeserializarUniqueNewtonsoft<Dictionary<string, string>>(_file.Replace(".xlsm", ".json"), _path);
        }

        public void AdicionaBlklPula(List<CoordenadasExcelWriterDetalhes> Detalhes)
        {          
            var dados = Detalhes.Find(a=> a.Pula == true);

            if (dados != null)
            {
                if (!dicionario.ContainsKey(dados.Ms))
                	dicionario.Add(dados.Ms, dados.PolicaoLinha.ToString() + dados.Colunas.FirstOrDefault());
            }
          
        }
        public void RemoveBlklPula(List<FamiliaStages> stages)
        {
            for (int i = 0; i < dicionario.Count; i++)
            {
                var item = dicionario.ElementAt(i).Key;
                if (!stages.Exists(a => a.Ms == item))
                     dicionario.Remove(item);
            }
            AtualizaDadosDicionario();
        }
        public void AtualizaDadosDicionario()
        {
            _service.SerializarUniqueNewtonsoft(dicionario, _file.Replace(".xlsm", ".json"), _path);
        }

    }
}
