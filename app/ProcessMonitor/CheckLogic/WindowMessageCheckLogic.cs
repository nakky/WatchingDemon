using System;
using System.Collections.Generic;
using System.Text;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace ProcessMonitor
{
    class WindowMessageCheckLogic : CheckLogic
    {
        public override CheckLogicType LogicType { get { return CheckLogicType.WindowMessage; } }

        public override void CheckTrigger(ProcessTarget target)
        {
            try
            {
                Process p = Process.GetProcessById(target.Target.Id);
                if (p.MainModule.FileName != target.ExePath) throw new ArgumentException("No process with id " + p.Id + " exists.");

                if (p.Responding) target.ChangeState(ProcessState.Running);
                else target.ChangeState(ProcessState.NotResponding);

                return;
               
            }
            catch (ArgumentException ae)
            {
                target.ChangeState(ProcessState.Stoped);
            }
            catch
            {
                target.ChangeState(ProcessState.NotResponding);
                return;
            }

        }
    }
}
