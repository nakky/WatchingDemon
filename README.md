# WatchingDemon

## Overview  

WatchingDemon(WaD) performs like a Unix daemon, and monitors registered processes and restarts them in case of a crash. WaD has another process which monitor WaD itself, so works stably for a long time.
WaD can be operated remotely via UDP, and you can extend that functionality with plugins.

## Documentation
[Application User Manual](https://github.com/nakky/WatchingDemon/blob/master/app/WatchingDemonWin/README.md)


## Process Monitor

WaD monitors registerd program execution, and analyses its lifecycle. If a process crashed or hanged, WaD kill the process and launch a new process.

To check process health, the following logics are implemented.

 - Process : Whether the process exists.
 - WindowMessage : Whether the GUI is responsive.
 - UDP : Whether UDP packets are being sent.

When the running process (Running) does not respond for a certain period (NotResponding), it is determined that it is not running(Stoped), and WaD terminate the process completely.

You can also set some parameters.

 - Period : Period of time when it is judged to have crashed.
 - Interval : Period from process termination request to restart.

and can set some GUI related parameters.

## Packet Trigger

Some functions can be operated remotely via UDP. Other application send a UDP packet which include ID and Parameter, then WaD triggers the function according to them.  
You can add triggers with plugins, and can enable/disable them. Some Triggers are implemented in default (Shutodown/Reboot PC, and so on).

If you copy a plugin DLL into "Plugin" folder, WaD automatically analyzes the DLL and gets Triggers from the plugin.

## Intelligent Demon

WaD is paired up with another process : Intelligent Demon (InD). WaD and InD monitor each other. If one process crashes, other process terminates crashed process completely, and launches a new proecss.

InD is simple so is hard to crash. Due to such a mechanism, WaD is durable.

## Configuration

WaD can be set to start monitoring at launching, and you can also set a listen port number of PacketTrigger.

## Repository

This repo includes WaD project, InD project, WaD API and so on. The folder structure is as follows.

 - app : includes Application projects.
   - app/WatchingDemonWin/WatchingDemon : includes WaD exe project.  
   - app/WatchingDemonWin/IntelligentDemon : includes InD exe project.  
   - app/ProcessMonitor : includes DLL project related to process monitoring.
   - app/PacketTrigger : includes DLL project related to PacketTrigger.
   - app/DefaultPacketTriggerPlugin : includes PacketTrigger plugin project.
 - sdk : includes SDK projects.
   - sdk/WatchingDemon.Sdk : includes SDK project for .NET.
   - sdk/WatchingDemon.Sdk.Unity : includes SDK project for Unity.
