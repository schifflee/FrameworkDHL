using NPOI.SS.UserModel;
using SOW.Automation.Interface.DLx.Excel.Enums;
using SOW.Automation.Interface.DLx.Excel.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

using System.Threading;


namespace SOW.Automation.Interface.DLx.Excel.Services
{
    public class ExcelReaderHandlerService : CoordernadasExcel
    {
        IWorkbook Documento;
        ISheet Planilha;
        IList<FamiliaStages> MassaDados;
        string _caminho;
        string _nomeArquivo;

        public ExcelReaderHandlerService(string caminho, string nomeArquivo)
        {
            _caminho = caminho;
            _nomeArquivo = nomeArquivo;
           
            CoordenadasExcel = new List<CoordernadasExcel>();
            PopulaCoordenadas();

        }

        public IList<FamiliaStages> CarregaPlanilhaExcel()
        {
            MassaDados = new List<FamiliaStages>();
            try
            {
                if (File.Exists(_caminho + _nomeArquivo))
                {
                    using (FileStream file = new FileStream(_caminho + _nomeArquivo, FileMode.Open, FileAccess.ReadWrite))
                    {
                        Documento = WorkbookFactory.Create(file);
                        Planilha = Documento.GetSheet("Base Controle de Stages");
                    }

                    foreach (var coordenada in CoordenadasExcel)
                    {
                        for (int linhas = coordenada.LinhaInicio; linhas < coordenada.LinhaFim; linhas++) 
                        {
                          
                            FamiliaStages familia = new FamiliaStages();
                           

                            for (int coluna = coordenada.ColunaInicio; coluna < coordenada.ColunaFim; coluna++)
                                CarregaValoresDasCelulas(Planilha, familia, linhas, coluna, coordenada);


                            MassaDados.Add(familia);
                        }
                    }
                }
                return MassaDados.ToList();
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

                if(!desistoDestaMerda)
                CarregaPlanilhaExcel();

                return MassaDados.ToList();
            }
        }


        private void CarregaValoresDasCelulas(ISheet Planilha, FamiliaStages dados, int linhaAtual, int colunaAtual, CoordernadasExcel coordenada)
        {
           
            ICell cell = Planilha.GetRow(linhaAtual).GetCell(colunaAtual);
            if (cell != null)
            {
                if (colunaAtual == coordenada.ColunaInicio)
                {
                    if (Planilha.GetRow(linhaAtual).GetCell(colunaAtual - 1) != null)
                    {
                        var auxStr = Planilha.GetRow(linhaAtual).GetCell(colunaAtual - 1).StringCellValue.ToUpper();
                        dados.StageColuna = auxStr.Contains("COLUNA");
                    }
                    else
                    {
                        var auxStr = Planilha.GetRow(linhaAtual).GetCell(colunaAtual + 1).StringCellValue.ToUpper();
                        dados.StageColuna = auxStr.Contains("COLUNA");
                    }
                    dados.LinhaColuna = cell.RowIndex;
                    dados.Familia = (EFamiliaStages)Enum.Parse(typeof(EFamiliaStages), coordenada.DescricaoCoordenada);
                };

                switch (cell.CellType)
                {
                    case CellType.Unknown:
                        if (colunaAtual == coordenada.ColunaInicio + 4)
                        {

                        }
                        break;
                    case CellType.Numeric:
                        if (colunaAtual == coordenada.ColunaInicio + 4)
                        {

                        }
                            var auxNum = Planilha.GetRow(linhaAtual).GetCell(colunaAtual).NumericCellValue;                       
                        if (colunaAtual == coordenada.ColunaInicio + 2)
                        {
                            dados.CapacidadeStage = Convert.ToInt32(auxNum);
                
                        }
                        break;
                    case CellType.String:
                        var auxStr = Planilha.GetRow(linhaAtual).GetCell(colunaAtual).StringCellValue;
                        if (colunaAtual == coordenada.ColunaInicio)
                        {
                            if (string.IsNullOrWhiteSpace(auxStr))
                            {
                                dados.StatusVazio = true;
                            }
                            else
                            {
                                dados.Status = (EStatusStage)Enum.Parse(typeof(EStatusStage), auxStr.Replace("-", "_").Replace(" ", "_"));
                            }
                  
                        }
                        else if (colunaAtual == coordenada.ColunaInicio + 2)
                        {
                            dados.CapacidadeStage = Convert.ToInt32(auxStr);
                        }
                        else if (colunaAtual == coordenada.ColunaInicio + 3)
                        {
                            dados.Stage = auxStr;
                        }
                        else if (colunaAtual == coordenada.ColunaInicio + 4)
                        {
                            dados.Ms = auxStr;
                            if (string.IsNullOrWhiteSpace(auxStr))
                            {
                                dados.MsVazio = true;
                            }
                          

                            dados.Colunas.Add(cell.ColumnIndex);
                        }
                        else if (colunaAtual == coordenada.ColunaInicio + 5)
                        {
                            dados.Sid = auxStr;
                           

                            dados.Colunas.Add(cell.ColumnIndex);
                        }
                        break;
                    case CellType.Formula:
                        var auxFrm = Planilha.GetRow(linhaAtual).GetCell(colunaAtual).StringCellValue;
                        if (colunaAtual == coordenada.ColunaInicio)
                        {
                            if (string.IsNullOrWhiteSpace(auxFrm))
                            {
                                dados.StatusVazio = true;
                            }
                            else
                            {
                                dados.Status = (EStatusStage)Enum.Parse(typeof(EStatusStage), auxFrm.Replace("-", "_").Replace(" ", "_"));
                            }
                         
                        }
                        else if (colunaAtual == coordenada.ColunaInicio + 4)
                        {
                            dados.Ms = auxFrm;
                            if (string.IsNullOrWhiteSpace(auxFrm))
                            {
                                dados.MsVazio = true;
                            }
                           
             
                            dados.Colunas.Add(cell.ColumnIndex);
                        }
                        else if (colunaAtual == coordenada.ColunaInicio + 5)
                        {
                            dados.Sid = auxFrm;
                         
              
                            dados.Colunas.Add(cell.ColumnIndex);
                        }
                        break;
                    case CellType.Blank:
                        auxStr = Planilha.GetRow(linhaAtual).GetCell(colunaAtual).StringCellValue;
                        if (colunaAtual == coordenada.ColunaInicio)
                        {
                            dados.StatusVazio = true;
                            dados.Status = null;
                        }
                        else if (colunaAtual == coordenada.ColunaInicio + 4)
                        {
                            dados.Ms = auxStr;
                            dados.MsVazio = true;
                            
                   
                            dados.Colunas.Add(cell.ColumnIndex);
                        }
                        else if (colunaAtual == coordenada.ColunaInicio + 5)
                        {
                            dados.Sid = auxStr;
                            

                            dados.Colunas.Add(cell.ColumnIndex);
                        }
                        break;
                    case CellType.Boolean:
                        break;
                    case CellType.Error:
                        break;
                    default:
                        break;
                }
            }
        }
    }
}
