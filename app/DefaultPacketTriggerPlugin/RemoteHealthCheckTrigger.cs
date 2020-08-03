using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

using ProcessMonitor;

namespace PacketTrigger
{
    class RemoteHealthCheckTrigger : Plugin
    {
        public override string PluginName { get { return "RemoteHealthCheck"; } }

        public override short Id { get { return (short)DefaultTriggerId.OuterHealthCheck; } }

        public override string Description
        {
            get
            {
                return "Remote Health Check : Responding Module.";
            }
        }

        public RemoteHealthCheckTrigger()
        {
            PacketTriggerManager.Instance.RegisterSendChannel((short)DefaultTriggerId.OuterHealthCheck);
        }

        public override void Process(string ip, byte[] param)
        {
            bool isMonitoring = ProcessManager.Instance.IsMonitoring;
            byte[] data = new byte[1] { 0 };
            if (isMonitoring) data[0] = 1;
            PacketTriggerManager.Instance.Send(ip, (short)DefaultTriggerId.OuterHealthCheck, data);
        }
    }
}
