using System;
using System.Collections.Generic;
using System.Text;

namespace PacketTrigger
{
    public enum DefaultTriggerId
    {
        Health = 0,

        //System
        OuterHealthCheck = 100,
        ShutDown = 101,
        Reboot = 102,

        //App
        MonitoringSwitch = 201,
        KillProcess = 202,
    }
}
