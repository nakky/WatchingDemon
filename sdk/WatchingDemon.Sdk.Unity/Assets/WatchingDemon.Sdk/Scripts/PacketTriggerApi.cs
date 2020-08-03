using System;
using System.Net;
using System.Threading.Tasks;
using Snowball;

namespace WatchingDemon.Sdk
{
    public class PacketTriggerApi : IDisposable
    {
        ComTerminal com = new ComTerminal();

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

        public void Dispose()
        {
            com.Close();
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

        public async void Send(string targetIp, short triggerId, byte[] data, int sendTime = 4, int intervalMillisec = 100)
        {
            var node = new ComNode(targetIp);
            for (int i = 0; i < sendTime; i++)
            {
                await com.Send(node, triggerId, data).ConfigureAwait(false);
                await Task.Delay(intervalMillisec);
            }
        }

        public void ShutdownRequest(string targetIp)
        {
            byte[] dummy = new byte[1] { 0 };
            Send(targetIp, (short)DefaultTriggerId.ShutDown, dummy);
        }

        public void RebootRequest(string targetIp)
        {
            byte[] dummy = new byte[1] { 0 };
            Send(targetIp, (short)DefaultTriggerId.Reboot, dummy);
        }

        public void MonitoringStart(string targetIp)
        {
            byte[] data = new byte[1] { 1 };
            Send(targetIp, (short)DefaultTriggerId.MonitoringSwitch, data);
        }

        public void MonitoringStop(string targetIp)
        {
            byte[] data = new byte[1] { 0 };
            Send(targetIp, (short)DefaultTriggerId.MonitoringSwitch, data);
        }

        public void KillProcess(string targetIp, byte processId)
        {
            byte[] data = new byte[1] { processId };
            Send(targetIp, (short)DefaultTriggerId.KillProcess, data);
        }
    }
}
