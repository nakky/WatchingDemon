# WatchingDemon SDK

WatchingDemon has a function called PacketTrigger that performs various operations according to UDP commands. This project includes functions that allow you to send UDP commands from another app.
In the UDP check logic, the monitored application must support it. Functions for that are also included in this project



## Installation

WatchingDemon's communication protocol follows [Snowball](https://github.com/nakky/Snowball), so this SDK project depends on Snowball. 

For .NET projects, .nuget automatically adds the library.

For Unity projects, you need to add the Snowball unitypackage. Download from the [Release page](https://github.com/nakky/Snowball/releases) on the Snowball site.

## API

 - UdpHealthPulse : Class sends UDP packets of UDP check logic.
```csharp
using WatchingDemon.Sdk;
...
//This class works only by instantiating and holding
UdpHealthPulse udpHealthPulse = new UdpHealthPulse();
```

 - RemoteMonitor : Class that monitors the status of other terminals.
```csharp
using WatchingDemon.Sdk;
...
RemoteMonitor monitor;
RemoteNode node;
...
string[] ipList = new string[1] { "127.0.0.1" };
monitor = new RemoteMonitor(ipList);
node = monitor.GetNode(ipList[0]);
...
Console.WriteLine("Status:" + node.Status);
```

 - PacketTriggerApi : Class that contains APIs that send UDP of PacketTrigger.

```csharp
using WatchingDemon.Sdk;
...
PacketTriggerApi triggerApi = new PacketTriggerApi();
...
triggerApi.MonitoringStart(targetIp);
...
triggerApi.KillProcess(targetIp, 1);
...
triggerApi.MonitoringStop(targetIp);
...
triggerApi.ShutdownRequest(targetIp);
...
//triggerApi.RebootRequest(targetIp);
```