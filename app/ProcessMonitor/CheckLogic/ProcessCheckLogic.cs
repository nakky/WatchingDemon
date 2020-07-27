using System;
using System.Collections.Generic;
using System.Text;
using System.Diagnostics;

namespace ProcessMonitor
{
    public class ProcessCheckLogic : CheckLogic
    {

        public override CheckLogicType LogicType { get { return CheckLogicType.Process; } }

        public override void CheckTrigger(ProcessTarget target)
        {
            try
            {
                Process p = Process.GetProcessById(target.Target.Id);
                if (p.MainModule.FileName != target.ExePath) throw new ArgumentException("No process with id " + p.Id + " exists.");

                target.ChangeState(ProcessState.Running);
            }
            catch(ArgumentException ae)
            {
                target.ChangeState(ProcessState.Stoped);
            }
            catch
            {
                target.ChangeState(ProcessState.NotResponding);
            }
           
        }

    }
}
