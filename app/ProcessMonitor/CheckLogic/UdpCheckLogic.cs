using System;
using System.Collections.Generic;
using System.Text;
using System.Diagnostics;

namespace ProcessMonitor
{
    class UdpCheckLogic : CheckLogic
    {
        public override CheckLogicType LogicType { get { return CheckLogicType.Udp; } }

        public override void CheckTrigger(ProcessTarget target)
        {
            try
            {
                Process p = Process.GetProcessById(target.Target.Id);
                if (p.MainModule.FileName != target.ExePath) throw new ArgumentException("No process with id " + p.Id + " exists.");

                TimeSpan elapsed = target.GetElapsedCheckTime();
                if (elapsed > new TimeSpan(0, 0, 3)) target.ChangeState(ProcessState.NotResponding);

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
