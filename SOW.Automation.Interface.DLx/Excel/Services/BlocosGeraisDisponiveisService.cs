using SOW.Automation.Interface.DLx.Excel.Models;
using SOW.Automation.Interface.DLx.Excel.Services;
using SOW.Automation.Interface.DLx.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SOW.Automation.Interface.DLx.Excel.Services
{
    public class BlocosGeraisDisponiveisService
    {
        private static ExcelHelper _helper;
        public BlocosGeraisDisponiveisService(ExcelHelper helper)
        {
            _helper = helper;
        }
        #region Metodos Privados
        private static bool EstaNoPula(FamiliaStages fam) { return _helper.dicionario.ContainsValue(fam.LinhaColuna.ToString() + fam.Colunas.FirstOrDefault()); }
        private  List<FamiliaStages> AplicaRegrasDePrioridade(Enums.EStatusStageDlx familiaDlx, IList<FamiliaStages> familaStages)
        {
            var Opcao1 = new List<FamiliaStages>();
            var Lista = familaStages.ToList();
            switch (familiaDlx)
            {
                case Enums.EStatusStageDlx.AMB:
                    Opcao1.AddRange(Lista
                            .FindAll(a => a.Familia == Enums.EFamiliaStages.AMBIENTE));
                    Opcao1.AddRange(Lista
                            .FindAll(a => a.Familia == Enums.EFamiliaStages.REVERSÍVEL));
                    return Opcao1.ToList();
                case Enums.EStatusStageDlx.CLI:
                    Opcao1.AddRange(Lista
                            .FindAll(a => a.Familia == Enums.EFamiliaStages.REVERSÍVEL));
                    Opcao1.AddRange(Lista
                            .FindAll(a => a.Familia == Enums.EFamiliaStages.CLIMATIZADA));
                    return Opcao1.ToList();
                case Enums.EStatusStageDlx.PAS:
                    Opcao1.AddRange(Lista
                            .FindAll(a => a.Familia == Enums.EFamiliaStages.REVERSÍVEL));
                    Opcao1.AddRange(Lista
                            .FindAll(a => a.Familia == Enums.EFamiliaStages.CLIMATIZADA));
                    return Opcao1.ToList();
                case Enums.EStatusStageDlx.SEM:
                    Opcao1 = Lista
                            .FindAll(a => a.Familia == Enums.EFamiliaStages.CLIMATIZADA);
                    return Opcao1;
                case Enums.EStatusStageDlx.AMBCLI:
                    Opcao1.AddRange(Lista
                            .FindAll(a => a.Familia == Enums.EFamiliaStages.CLIMATIZADA));
                    Opcao1.AddRange(Lista
                            .FindAll(a => a.Familia == Enums.EFamiliaStages.REVERSÍVEL));
                    return Opcao1.ToList();
                case Enums.EStatusStageDlx.AMBPAS:
                    Opcao1.AddRange(Lista
                            .FindAll(a => a.Familia == Enums.EFamiliaStages.CLIMATIZADA));
                    Opcao1.AddRange(Lista
                            .FindAll(a => a.Familia == Enums.EFamiliaStages.REVERSÍVEL));       
                    return Opcao1.ToList();
                case Enums.EStatusStageDlx.CLIPAS:
                    Opcao1.AddRange(Lista
                             .FindAll(a => a.Familia == Enums.EFamiliaStages.REVERSÍVEL));
                    Opcao1.AddRange(Lista
                            .FindAll(a => a.Familia == Enums.EFamiliaStages.CLIMATIZADA));
                    return Opcao1.ToList();
                default:
                    return Opcao1;
            }
        }
        private  Predicate<FamiliaStages> Comparacao = (fam) => (fam.MsVazio && fam.StatusVazio && EstaNoPula(fam) == false || fam.Status == Enums.EStatusStage.Load_Complete || fam.MsVazio && !fam.StatusVazio) && !fam.StageColuna;
        #endregion

        #region Metodos Publicos
        public  CoordenadasExcelWriter DetalhesStagesDisponiveis(List<FamiliaStages> familaStages, RpaDadosStageInfo rpaDados)
        {
            var ListaComRegraOpcoes  = AplicaRegrasDePrioridade(rpaDados.FamiliaDlx,familaStages.ToList());

            List<CoordenadasExcelWriterDetalhes> ListaCoordenadas = new List<CoordenadasExcelWriterDetalhes>();
            int cont = 0;
            var qtdPaletsGeral = rpaDados.QtdPalets;
            int conlist = 0;
            foreach (var fam in ListaComRegraOpcoes)
            {
               
                if (Comparacao(fam))
                {
                   
                    if (!(rpaDados.QtdPalets <= 0))
                    {
                        ListaCoordenadas.Add(new CoordenadasExcelWriterDetalhes
                        {
                            PolicaoLinha = fam.LinhaColuna + 1,
                            Colunas = fam.Colunas,
                            QtdPalets = fam.CapacidadeStage,
                            Ms = rpaDados.Ms,
                            Pula = false
                        });
                       
                    }
                       
            
                    rpaDados.QtdPalets -= fam.CapacidadeStage;

                    if (rpaDados.QtdPalets <= 0)
                    {
                        var index = ListaComRegraOpcoes.IndexOf(fam);
                        if (ListaComRegraOpcoes.Count >= index + 1)
                        {
                            var next = ListaComRegraOpcoes[index + 1];
                            if (Comparacao(next))
                            {
                                ListaCoordenadas.Add(new CoordenadasExcelWriterDetalhes
                                {
                                    PolicaoLinha = next.LinhaColuna + 1,
                                    Colunas = next.Colunas,
                                    QtdPalets = next.CapacidadeStage,
                                    Ms = rpaDados.Ms,
                                    Pula = true
                                });
                                break;
                            }
                        }
   
                        rpaDados.QtdPalets = qtdPaletsGeral;
                        ListaCoordenadas = new List<CoordenadasExcelWriterDetalhes>();

                    }
                    cont++;

                    if (conlist == ListaComRegraOpcoes.Count - 1)
                    {
                        if (!(rpaDados.QtdPalets <= 0))
                        {
                            rpaDados.QtdPalets = qtdPaletsGeral;
                            ListaCoordenadas = new List<CoordenadasExcelWriterDetalhes>();
                        }
                    }
                }
                else
                {
                    if(!(rpaDados.QtdPalets <=0 ))
                    {
                        rpaDados.QtdPalets = qtdPaletsGeral;
                        ListaCoordenadas = new List<CoordenadasExcelWriterDetalhes>();
                    }
                }

                conlist++;
            }

            rpaDados.QtdPalets = qtdPaletsGeral;

            CoordenadasExcelWriter Coordenada = new CoordenadasExcelWriter
            {
                Detalhes = ListaCoordenadas,
                DadosRpa = rpaDados
            };


            if (ListaCoordenadas.Count > 0)
                Coordenada.CoordenadaDisponivel = true;
            else
                Coordenada.CoordenadaDisponivel = false;

            return Coordenada;
        }
        #endregion

       

       

    }
}
