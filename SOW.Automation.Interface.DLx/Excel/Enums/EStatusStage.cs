using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOW.Automation.Interface.DLx.Excel.Enums
{
    public enum EStatusStage
    {
        Ready = 0,
        Load_Complete = 1,
        Loading = 2,
        In_Process = 3,
        Staged = 4
    }

    public enum EStatusStageDlx
    {
        AMB = 0,
        CLI = 1,
        PAS = 2,
        SEM = 3,
        AMBCLI = 4,
        AMBPAS = 5,
        CLIPAS = 6
    }
}
