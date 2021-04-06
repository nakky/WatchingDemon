using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

using ProcessMonitor;

namespace PacketTrigger
{
    class PCShutdownTriggerPlugin : Plugin
    {
        public override string PluginName { get { return "PCShutdown"; } }

        public override short Id { get { return (short)DefaultTriggerId.ShutDown; } }

        public override string Description 
        {
            get
            {
                return "Shutdown PC.";
            }
        }

        public override void Process(string ip, byte[] param)
        {
            try
            {
                ProcessStartInfo psi = new ProcessStartInfo();
                psi.FileName = "shutdown.exe";
                psi.Arguments = "-s -hybrid -t 0";   // shutdown
                psi.CreateNoWindow = true;
                Process p = System.Diagnostics.Process.Start(psi);
            }
            catch (Exception ex)
            {
                ProcessManager.Instance.Log("PCShutdownTriggerPlugin:" + ex.Message);
            }
        }

      
    }
}
