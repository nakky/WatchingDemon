using System;
using System.IO;
using System.Reflection;
using System.Text;
using System.Linq;
using System.Collections.Generic;
using ProcessMonitor;

using Snowball;

namespace PacketTrigger
{
    public class PacketTriggerManager
    {
        #region Singleton
        static PacketTriggerManager instance = null;

        public static PacketTriggerManager Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new PacketTriggerManager();
                }
                return instance;
            }
        }
        #endregion

        Dictionary<short, Plugin> pluginMap = new Dictionary<short, Plugin>();
        ComTerminal recvCom = new ComTerminal();
        ComTerminal sendCom = new ComTerminal();

        AllowList allowList = new AllowList();

        public AllowList AllowList {
            get { return allowList;}
            set { allowList = value; }
        }

        private PacketTriggerManager()
        {
        }

        public void SearchPacketTriggers(Assembly asm)
        {
            var types = asm.GetTypes().Where(t => 
            {
                return t.IsSubclassOf(typeof(PacketTrigger.Plugin)) && !t.IsAbstract;
            });

            foreach (var pc in types)
            {
                Plugin plugin = (Plugin)Activator.CreateInstance(pc);

                Console.WriteLine(plugin.PluginName + ":" + plugin.Id);

                AddPlugin(plugin);
            }
        }

        public void AddPlugin(Plugin plugin)
        {
            pluginMap.Add(plugin.Id, plugin);

            recvCom.AddChannel(
                new DataChannel<byte[]>(plugin.Id, QosType.Unreliable, Compression.None, (node, data) => {
                    Process(node, plugin.Id, data);
                }));
        }

        public IOrderedEnumerable<KeyValuePair<short, Plugin>> GetOrderdPluginMap()
        {
            return pluginMap.OrderBy(pair => pair.Key);
        }

        public Plugin GetPlugin(short id)
        {
            if (pluginMap.ContainsKey(id)) return pluginMap[id];
            else return null;
        }

        public void OpenReceiveChannel(int port)
        {
            recvCom.ListenPortNumber = port;
            recvCom.SendPortNumber = 0;

            recvCom.AddChannel(
                new DataChannel<byte[]>(0, QosType.Unreliable, Compression.None, (node, data) => {
                    if (ProcessManager.Instance.IsMonitoring)
                    {
                        short id = (short)data[0];
                        ProcessTarget p = ProcessManager.Instance.GetProcess(id);
                        if (p.Enable 
                        && (p.State == ProcessState.NotResponding || p.State == ProcessState.Running))
                        {
                            p.ResetCheckTime();
                            p.ChangeState(ProcessState.Running);
                        }
                    }
                }, CheckMode.Speedy));

            var list = allowList.List;
            foreach (var item in list)
            {
                recvCom.AddAcceptList(item);
            }

            recvCom.Open();
        }

        public void OpenSendChannel(int port)
        {
            sendCom.ListenPortNumber = 0;
            sendCom.SendPortNumber = port;

            var list = allowList.List;
            foreach (var item in list)
            {
                sendCom.AddAcceptList(item);
            }

            sendCom.Open();
        }

        public void Close()
        {
            recvCom.Close();
            sendCom.Close();
        }

        public void RegisterSendChannel(short channdlId)
        {
            sendCom.AddChannel(
                new DataChannel<byte[]>(channdlId, QosType.Unreliable, Compression.None, (node, data) => { })
                );
        }

        public void Send(string ip, short channelId, byte[] data)
        {
            sendCom.Send(new ComNode(ip), channelId, data);
        }

        public bool Process(ComNode node, short id, byte[] data)
        {
            if (pluginMap.ContainsKey(id))
            {
                if (pluginMap[id].Enable)
                {
                    pluginMap[id].Process(node.IP, data);
                    return true;
                }
                else return false;
            }
            else return false;
        }

        public void Serialize(string path)
        {
            using (StreamWriter writer = new StreamWriter(path, false, Encoding.UTF8))
            {
                IOrderedEnumerable<KeyValuePair<short, Plugin>> sorted = pluginMap.OrderBy(pair => pair.Key);

                foreach (var p in sorted)
                {
                    writer.WriteLine(p.Value.Id + "::" + p.Value.PluginName + "::" + p.Value.Enable);
                }
                writer.Close();
            }
               
        }

        public void Deserialize(string path)
        {
            foreach (var p in pluginMap)
            {
                p.Value.Enable = false;
            }

            try
            {
                using (StreamReader reader = new StreamReader(path, Encoding.UTF8))
                {
                    while (reader.Peek() != -1)
                    {
                        string line = reader.ReadLine();
                        //Console.WriteLine(line);

                        string[] del = { "::" };
                        string[] token = line.Split(del, StringSplitOptions.None);
                        short id = short.Parse(token[0]);
                        if (pluginMap.ContainsKey(id))
                        {
                            Plugin p = pluginMap[id];
                            if (p.PluginName == token[1])
                            {
                                bool enable = bool.Parse(token[2]);
                                p.Enable = enable;
                            }
                        }
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
