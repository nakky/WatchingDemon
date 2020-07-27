using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

using ProcessMonitor;

namespace PacketTrigger
{
    class AppKillProcessTrigger : Plugin
    {
        public override string PluginName { get { return "AppKillProcessTrigger"; } }

        public override short Id { get { return (short)DefaultTriggerId.KillProcess; } }

        public override string Description
        {
            get
            {
                return "Kill Process.";
            }
        }

        public override void Process(byte[] param)
        {
            try
            {
                if (ProcessManager.Instance.IsMonitoring)
                {
                    short id = (short)param[0];
                    ProcessTarget p = ProcessManager.Instance.GetProcess(id);
                    if (p.Enable
                    && (p.State == ProcessState.NotResponding || p.State == ProcessState.Running))
                    {
                        p.KillProcess();
                    }
                }
            }
            catch (Exception ex)
            {
                ProcessManager.Instance.Log("AppKillProcessTrigger:" + ex.Message);
            }
        }


    }
}
