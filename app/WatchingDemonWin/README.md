# WatchingDemon App User Manual

## Launch App

WatchingDemon is simply run by double-clicking the WatchingDemon.exe file in Root Folder.

WatchingDemon run in the background and you can operate from the context menu that appears when you right-click the task tray icon, or from the settings panel that can be displayed from the context menu item "Setting".

## Monitor Applications

You can register an app to monitor from the "Motnirs" tab. You can register and unregister the app with the +/- buttons at the bottom.
The information required for registration is as follows.
 - Path: The path of the exe file. 
 - Arguments : Arguments for launching.
 - ID : Id of application. (1 - 255)
 - Logic : How to monitor the application.
   - Process : Whether the process exists.
   - WindowMessage : Whether the GUI is responsive.
   - UDP : Whether UDP packets are being sent. (App support required)
 - Period : Period of time (Sec.) when it is judged to have crashed.
 - Interval : Period (Sec.) from process termination request to restart.
 - No Window : Command app or Window app.
 - Active window : Whether to activate the window on a regular basis.

The registered apps are displayed in the list. Check the checkbox on the left to enable monitoring of registered apps.

You can switch monitoring on/off with the button on the top.

## Packet Trigger Setting

In WatchingDemon, the PacketTrigger function can be extended with a plug-in. Plugins already installed will be listed in the "Packets" tab.

Check the checkbox on the left for the plugins you want to activate.

The plugins installed from the beginning are as follows.
 - RemoteHealthCheck : Check if this app is running remotely.
 - PCShutdown : Shut down the PC remotely.
 - PCReboot : Restart the PC remotely.
 - AppMonitoringSwitch : Switching monitoring on/off remotely.
 - AppKillProcess : Close app remotely.

## Configuration

Various config parameters can be set in the "Settings" tab. 

AllowList allows you to set an ip address that accepts packets.
In addition, you can set the port number related to PacketTrigger.

**The parameters set on this tab will be applied after restarting app.**

## Terminate App

WatchingDemon does not end even if the setting window is closed. The process keeps running in the background. If the process crashes, another process will restart WatchingDemon. To terminate WD process completely, select the "Exit" item from the context menu that appears when you right-click the task tray icon.

## Operation tips
 - WatchingDemon can also crash, but in that case, it will be restarted by another background process. If you turn on automatic monitoring start at that time, Registered apps are permanently monitored.

 - It may take some time to forcefully terminate unresponsive apps, and because it may not be possible to operate WatchingDemon due to apps such as full-screen apps, you should allow some time to restart (Interval Sec.).

 - Put the plugin DLL in the "Plugin" folder and it will be recognized automatically when the application is launched.

