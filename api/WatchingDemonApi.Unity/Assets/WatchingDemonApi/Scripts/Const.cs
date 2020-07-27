using System;
using System.Collections.Generic;
using System.Text;

namespace WatchingDemonApi
{
    public enum DefaultTriggerId
    {
        Health = 0,
        
        //System
        ShutDown = 101,
        Reboot = 102,

        //App
        MonitoringSwitch = 201,
        KillProcess = 202,
    }
}
