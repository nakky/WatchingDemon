using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

using ProcessMonitor;

namespace PacketTrigger
{
    class PCRebootTriggerPlugin : Plugin
    {
        public override string PluginName { get { return "PCRboot"; } }

        public override short Id { get { return (short)DefaultTriggerId.Reboot; } }

        public override string Description
        {
            get
            {
                return "Reboot PC.";
            }
        }

        public override void Process(string ip, byte[] param)
        {
            try
            {
                ProcessStartInfo psi = new ProcessStartInfo();
                psi.FileName = "shutdown.exe";
                psi.Arguments = "-r -t 0";   // reboot
                psi.CreateNoWindow = true;
                Process p = System.Diagnostics.Process.Start(psi);
            }
            catch (Exception ex)
            {
                ProcessManager.Instance.Log("PCRebootTriggerPlugin:" + ex.Message);
            }
        }
    }
}
