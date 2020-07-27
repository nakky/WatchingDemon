using System;
using System.Net;
using System.Threading.Tasks;
using Snowball;

namespace WatchingDemonApi
{
    public class PacketTriggerApi
    {
        ComTerminal com = new ComTerminal();
        ComNode node = new ComNode(IPAddress.Loopback.ToString());

        public PacketTriggerApi(int sendPort = 12300)
        {
            com.SendPortNumber = sendPort;
            com.ListenPortNumber = 0;

            RegisterTriggerId((short)DefaultTriggerId.Reboot);
            RegisterTriggerId((short)DefaultTriggerId.ShutDown);
            RegisterTriggerId((short)DefaultTriggerId.MonitoringSwitch);
            RegisterTriggerId((short)DefaultTriggerId.KillProcess);

            com.Open();
        }

        public bool RegisterTriggerId(short id)
        {
            try
            {
                com.AddChannel(new DataChannel<byte[]>(id, QosType.Unreliable, Compression.None, (node, data) => { }, CheckMode.Speedy));
            }
            catch
            {
                return false;
            }
            return true;
        }

        public async void Send(short triggerId, byte[] data, int sendTime = 4, int intervalMillisec = 100)
        {
            for(int i = 0; i < sendTime; i++)
            {
                await com.Send(node, triggerId, data).ConfigureAwait(false);
                await Task.Delay(intervalMillisec);
            }
        }

        public void ShutdownRequest()
        {
            byte[] dummy = new byte[1] { 0 };
            Send((short)DefaultTriggerId.ShutDown, dummy);
        }

        public void RebootRequest()
        {
            byte[] dummy = new byte[1] { 0 };
            Send((short)DefaultTriggerId.Reboot, dummy);
        }

        public void MonitoringStart()
        {
            byte[] data = new byte[1] { 1 };
            Send((short)DefaultTriggerId.MonitoringSwitch, data);
        }

        public void MonitoringStop()
        {
            byte[] data = new byte[1] { 0 };
            Send((short)DefaultTriggerId.MonitoringSwitch, data);
        }

        public void KillProcess(byte processId)
        {
            byte[] data = new byte[1] { processId };
            Send((short)DefaultTriggerId.KillProcess, data);
        }
    }
}
