using System;
using System.IO;
using System.Collections.Generic;
using System.Text;
using System.Diagnostics;

namespace ProcessMonitor
{
    public enum ProcessState
    {
        Disabled,
        Stoped,
        NotResponding,
        Running,
    }

    public class ProcessTarget
    {
        public short Id { get; set; }

        string exePath;

        public string ExePath
        {
            get { return exePath; }
            set
            {
                Name = Path.GetFileNameWithoutExtension(value);
                exePath = value;
            } 
        }

        public string Name { get; private set; }

        public string Arguments { get; set; }

        public CheckLogicType LogicType { get { return CheckLogic.LogicType; }  }
        public CheckLogic CheckLogic { get; set; }

        public short Period { get; set; }

        public short Interval { get; set; }

        public ProcessState State { get; set; }

        public bool Activate { get; set; }
        public bool NoWindow { get; set; }

        public bool Enable { get; set; }

        public DateTime StateChangedTime { get; private set; }

        public DateTime CheckTime { get; private set; }


        public Process Target { get; private set; }

        public ProcessTarget(CheckLogicType type = CheckLogicType.Process)
        {
            Period = 10;
            Interval = 3;
            GenerateLogic(type);
            Activate = false;
            NoWindow = false;

            State = ProcessState.Disabled;
        }

        public void GenerateLogic(CheckLogicType type)
        {
            switch(type)
            {
                case CheckLogicType.Process:
                    CheckLogic = new ProcessCheckLogic();
                    break;
                case CheckLogicType.WindowMessage:
                    CheckLogic = new WindowMessageCheckLogic();
                    break;
                case CheckLogicType.Udp:
                    CheckLogic = new UdpCheckLogic();
                    break;

            }
        }

        public void ChangeState(ProcessState state)
        {
            if (State == state) return;

            ProcessManager.Instance.Log("Process:" + Id + ":" + Name  +":" + State + "->" + state);

            StateChangedTime = DateTime.Now;
            CheckTime = DateTime.Now;
            State = state;
        }

        public void Reset()
        {
            ChangeState(ProcessState.Disabled);
            Target = null;
        }

        public bool Check()
        {
            switch (State)
            {
                case ProcessState.Disabled:
                    {
                        //Init
                        Target = null;

                        FindProcessId();
                        if (Target == null)
                        {
                            LaunchProcess();
                        }

                        if (Target != null) ChangeState(ProcessState.Running);
                        else ChangeState(ProcessState.Stoped);
                    }
                    break;
                case ProcessState.Stoped:
                    {
                        if (GetElapsedTime() > new TimeSpan(0, 0, Interval))
                        {
                            Target = null;

                            FindProcessId();
                            if (Target == null)
                            {
                                LaunchProcess();
                            }

                            if (Target != null) ChangeState(ProcessState.Running);
                            else ChangeState(ProcessState.Stoped);
                        }
                    }
                    break;
                case ProcessState.NotResponding:
                    {
                        if (GetElapsedTime() > new TimeSpan(0, 0, Period))
                        {
                            KillProcess();
                        }
                    }
                    break;
                case ProcessState.Running:
                    {
                        if (!NoWindow && Activate)
                        {
                            if(ProcessManager.Instance.OnActivateSignal != null) ProcessManager.Instance.OnActivateSignal(this);
                        }
                        
                        CheckLogic.CheckTrigger(this);
                    }
                    break;
            }

            //Console.WriteLine("Check" + ExePath);
            return true;
        }

        public void FindProcessId()
        {
            string name = Path.GetFileNameWithoutExtension(ExePath);
            Process[] ps = Process.GetProcessesByName(name);

            foreach (Process p in ps)
            {
                if(p.MainModule.FileName == ExePath)
                {
                    Target = p;
                    break;
                }
            }
        }

        public void LaunchProcess()
        {
            ProcessManager.Instance.Log("Launch:" + Name);

            try
            {
                using (Process p = new Process
                {
                    StartInfo = new ProcessStartInfo
                    {
                        FileName = this.ExePath,
                        Arguments = this.Arguments,
                        CreateNoWindow = this.NoWindow,
                        UseShellExecute = !this.NoWindow,
                    }
                })
                {
                    p.Start();
                    Target = p;
                }
            }
            catch(Exception e)
            {
                ProcessManager.Instance.Log("Exception:" + Name + ":" + e.Message);
                Target = null;
            }

            FindProcessId();
        }

        public void KillProcess()
        {
            if (Target == null) return;

            ProcessManager.Instance.Log("Kill:" + Name);

            try
            {
                Target.Kill();
            }
            catch(Exception e)
            {
                ProcessManager.Instance.Log("Exception:" + Name + ":" + e.Message);
            }

            Target = null;
            ChangeState(ProcessState.Stoped);
        }
 
        public TimeSpan GetElapsedTime()
        {
            if (State == ProcessState.Disabled) return TimeSpan.Zero;
            return DateTime.Now.Subtract(StateChangedTime);
        }

        public void ResetCheckTime()
        {
            CheckTime = DateTime.Now;
        }

        public TimeSpan GetElapsedCheckTime()
        {
            if (State == ProcessState.Disabled) return TimeSpan.Zero;
            return DateTime.Now.Subtract(CheckTime);
        }

        public void Serialize(StreamWriter writer)
        {
            writer.WriteLine(
                Id + "::" + ExePath + "::" + Arguments 
                + "::" + (int)LogicType + "::" + Period + "::" + Interval 
                + "::" + NoWindow + "::" + Activate + "::" + Enable
                );
        }

        public void Deserialize(StreamReader reader)
        {
            string line = reader.ReadLine();
            //Console.WriteLine(line);
            string[] del = { "::" };
            string[] token = line.Split(del, StringSplitOptions.None);
            Id = short.Parse(token[0]);
            ExePath = token[1];
            Arguments = token[2];
            CheckLogicType type = (CheckLogicType)int.Parse(token[3]);
            GenerateLogic(type);
            Period = short.Parse(token[4]);
            Interval = short.Parse(token[5]);
            NoWindow = bool.Parse(token[6]);
            Activate = bool.Parse(token[7]);
            
            Enable = bool.Parse(token[8]);
        }
    }
}
