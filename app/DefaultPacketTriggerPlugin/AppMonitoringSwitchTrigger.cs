using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

using ProcessMonitor;

namespace PacketTrigger
{
    class AppMonitoringSwitchTrigger : Plugin
    {
        public override string PluginName { get { return "AppMonitoringSwitch"; } }

        public override short Id { get { return (short)DefaultTriggerId.MonitoringSwitch; } }

        public override string Description
        {
            get
            {
                return "Switch Monitoring On/Off.";
            }
        }

        public override void Process(string ip, byte[] param)
        {
            
            try
            {
                bool isOn = param[0] == 1;
                if (isOn)
                {
                    ProcessManager.Instance.StartMonitoring();
                }
                else
                {
                    ProcessManager.Instance.StopMonitoring();
                }

            }
            catch (Exception ex)
            {
                ProcessManager.Instance.Log("AppMonitoringSwitchTrigger:" + ex.Message);
            }
        }


    }
}
