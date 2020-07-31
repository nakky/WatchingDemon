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
            byte[] dummy = new byte[1] { 0 };
            PacketTriggerManager.Instance.Send(ip, (short)DefaultTriggerId.OuterHealthCheck, dummy);
        }
    }
}
