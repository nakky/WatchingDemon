using System;
using System.Timers;
using System.IO;
using System.Text;
using System.Linq;
using System.Collections.Generic;

using System.ComponentModel;

namespace ProcessMonitor
{
    public class ProcessManager
    {
        #region Singleton
        static ProcessManager instance = null;

        public static ProcessManager Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new ProcessManager();
                }
                return instance;
            }
        }
        #endregion

        Dictionary<short, ProcessTarget> processMap = new Dictionary<short, ProcessTarget>();

        Dictionary<short, ProcessTarget> regularProcessMap = new Dictionary<short, ProcessTarget>();

        public delegate void MonitoringHandler();
        public MonitoringHandler OnMonitoring;

        public delegate void ActivateSignalHandler(ProcessTarget target);
        public ActivateSignalHandler OnActivateSignal;

        public delegate void LogHandler(string log);
        public LogHandler OnLog;

        Timer timer;

        Timer regularTimer;

        public ISynchronizeInvoke SynchronizeObject { get; set; }

        public bool IsMonitoring 
        { 
            get { return timer != null; } 
        }

        public bool IsRegularMonitoring
        {
            get { return regularTimer != null; }
        }

        public void Log(string log)
        {
            if(OnLog != null) OnLog(log);
        }

        public void StartMonitoring()
        {
            if (IsMonitoring) return;

            ResetAllProcesses();

            timer = new Timer(1000.0);
            timer.SynchronizingObject = SynchronizeObject;
            timer.Elapsed += OnTimer;
            timer.Start();

            if(OnMonitoring != null) OnMonitoring();

            Log("Start Monitoring");
        }

        public void StopMonitoring()
        {
            if (!IsMonitoring) return;
            timer.Stop();
            timer = null;

            ResetAllProcesses();

            if (OnMonitoring != null) OnMonitoring();

            Log("Stop Monitoring");
        }

        public void OnTimer(object sender, ElapsedEventArgs args)
        {
            foreach(var process in processMap)
            {
                if (process.Value.Enable)
                {
                    process.Value.Check();
                }
            }

            if (OnMonitoring != null) OnMonitoring();
        }

        public void AddProcess(ProcessTarget process)
        {
            processMap.Add(process.Id, process);
        }

        public void RemoveProcess(short id)
        {
            processMap.Remove(id);
        }

        public ProcessTarget GetProcess(short id)
        {
            if (processMap.ContainsKey(id)) return processMap[id];
            else return null;
        }

        public void ResetAllProcesses()
        {
            foreach (var process in processMap)
            {
                process.Value.Reset();
            }
        }

        public IOrderedEnumerable<KeyValuePair<short, ProcessTarget>> GetOrderdProcessMap()
        {
            return processMap.OrderBy(pair => pair.Key);
        }

        public void StartRegularMonitoring()
        {
            if (IsRegularMonitoring) return;

            regularTimer = new Timer(1000.0);
            regularTimer.SynchronizingObject = SynchronizeObject;
            regularTimer.Elapsed += OnRegularTimer;
            regularTimer.Start();
        }

        public void StopRegularMonitoring()
        {
            if (!IsRegularMonitoring) return;
            regularTimer.Stop();
            regularTimer = null;
        }

        public void OnRegularTimer(object sender, ElapsedEventArgs args)
        {
            foreach (var process in regularProcessMap)
            {
                if (process.Value.Enable)
                {
                    process.Value.Check();
                }
            }
        }

        public void KillAllRegularProcesses()
        {
            foreach (var process in regularProcessMap)
            {
                if (process.Value.Enable)
                {
                    process.Value.KillProcess();
                }
            }
        }

        public void AddRegularProcess(ProcessTarget process)
        {
            regularProcessMap.Add(process.Id, process);
        }

        public void RemoveRegularProcess(short id)
        {
            regularProcessMap.Remove(id);
        }


        public void Serialize(string path)
        {
            using (StreamWriter writer = new StreamWriter(path, false, Encoding.UTF8))
            {
                IOrderedEnumerable<KeyValuePair<short, ProcessTarget>> sorted = processMap.OrderBy(pair => pair.Key);

                foreach (var p in sorted)
                {
                    p.Value.Serialize(writer);
                }
                writer.Close();
            }
                
        }

        public void Deserialize(string path)
        {
            foreach (var p in processMap)
            {
                p.Value.Enable = false;
            }

            try
            {
                using (StreamReader reader = new StreamReader(path, Encoding.UTF8))
                {
                    while (reader.Peek() != -1)
                    {
                        ProcessTarget process = new ProcessTarget();
                        process.Deserialize(reader);
                        AddProcess(process);
                    }
                    reader.Close();
                }
            }
            catch
            {
                Serialize(path);
            }

        }
    }
}
