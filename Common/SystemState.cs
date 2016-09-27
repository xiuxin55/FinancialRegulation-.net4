using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Common
{
    public class SystemState
    {
        
    }
    public enum FormState
    {
        CRE = 0,
        MOD = 1,
        DEL = 2,
        VIE = 3
    }
    public enum CollectState
    {
        Success,
        Failure
    }

    public enum ActionState
    {
        Success,
        Failure
    }
    public enum ViewState
    {
        ApplyView,
        HouseView,
        ArcView
    }
}
