using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

using ProcessMonitor;
using System.Threading;

namespace IntelligentDemon
{
    class Program
    {
        static bool IsActive = true;

        static void Main(string[] args)
        {
            Mutex dupulicateMutex = new Mutex(false, "IntelligentDemonDupulicate");

            if (dupulicateMutex.WaitOne(0, false) == false)
            {
                return;
            }

            string TargetExePath = AppDomain.CurrentDomain.BaseDirectory;
            TargetExePath += "WatchingDemon.exe";

            ProcessTarget process = new ProcessTarget(CheckLogicType.WindowMessage);
            process.ExePath = TargetExePath;
            
            process.Interval = 2;
            process.Period = 2;

            process.NoWindow = false;
            process.Activate = false;

            process.Enable = true;

            ProcessManager.Instance.AddRegularProcess(process);
            ProcessManager.Instance.StartRegularMonitoring();


            //Console.WriteLine(TargetExePath + ":" + File.Exists(TargetExePath));

            while(IsActive)
            {
                Thread.Sleep(100);
            }

            ProcessManager.Instance.StopRegularMonitoring();

        }
    }
}
