using System;
using System.Collections.Generic;
using System.Text;
using System.Timers;
using Snowball;

namespace WatchingDemonSdk
{
    public enum RemoteStatus
    {
        NoError = 0,
        NotResponding = 255
    };

    public class RemoteNode
    {
        public string Ip { get; private set; }

        public ComNode ComNode { get; set; }

        RemoteStatus status = RemoteStatus.NotResponding;
        public RemoteStatus Status {
            get { return status; }
            set {
                lock (this)
                {
                    status = value;
                    timeStamp = DateTime.Now;
                }
                
            }
        }

        DateTime timeStamp;

        public RemoteNode(string ip)
        {
            Ip = ip;
            ComNode = new ComNode(ip);
        }

        public TimeSpan GetElapsedTime() {
            lock (this)
            {
                return DateTime.Now - timeStamp;
            }
           
        }
    }

    public class RemoteMonitor : IDisposable
    {
        ComTerminal com = new ComTerminal();

        Dictionary<string, RemoteNode> nodeMap = new Dictionary<string, RemoteNode>();

        Timer timer = new Timer();

        public RemoteMonitor(
            string[] targetIpList,
            int sendPortNumber = 12300,
            int listenPortNumber = 12301,
            int interval = 1000
            )
        {
            foreach(var target in targetIpList)
            {
                nodeMap.Add(target, new RemoteNode(target));
                com.AddAcceptList(target);
            }

            com.SendPortNumber = sendPortNumber;
            com.ListenPortNumber = listenPortNumber;

            com.AddChannel(new DataChannel<byte[]>((short)DefaultTriggerId.OuterHealth, QosType.Unreliable, Compression.None, (node, data) =>
            {
                if (nodeMap.ContainsKey(node.IP))
                {
                    RemoteNode n = nodeMap[node.IP];
                    n.Status = (RemoteStatus)data[0];
                }
                
            }));
            com.Open();

            timer.Interval = (double)interval;
            timer.Elapsed += OnTimer;
            timer.Start();
        }

        public void Dispose()
        {
            timer.Stop();
            com.Close();
        }

        public RemoteNode GetNode(string ip)
        {
            if (nodeMap.ContainsKey(ip)) return nodeMap[ip];
            return null;
        }

        private void OnTimer(object sender, ElapsedEventArgs e)
        {
            byte[] dummy = new byte[1] { 0 };
            TimeSpan ts = new TimeSpan(0, 0, 3);

            foreach(var node in nodeMap)
            {
                com.Send(node.Value.ComNode, (short)DefaultTriggerId.OuterHealth, dummy);

                TimeSpan elapsed = node.Value.GetElapsedTime();
                if (elapsed > ts) node.Value.Status = RemoteStatus.NotResponding;
            }
        }
    }
}
