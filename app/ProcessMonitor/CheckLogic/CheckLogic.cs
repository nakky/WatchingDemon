using System;
using System.Collections.Generic;
using System.Text;

namespace ProcessMonitor
{
    public enum CheckLogicType
    {
        Process,
        WindowMessage,
        Udp,
    }

    public abstract class CheckLogic
    {
        public abstract CheckLogicType LogicType { get; }

        public abstract void CheckTrigger(ProcessTarget target);
    }
}
