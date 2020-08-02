using System;
using System.Net;
using System.Timers;
using Snowball;

namespace WatchingDemon.Sdk
{
    public class UdpHealthPulse : IDisposable
    {

        ComTerminal com = new ComTerminal();
        ComNode node = new ComNode(IPAddress.Loopback.ToString());

        Timer timer = new Timer();

        public byte ProcessId { get; private set; }

        public UdpHealthPulse(byte processId, int interval = 500, int sendPort = 12300)
        {
            ProcessId = processId;

            com.SendPortNumber = sendPort;
            com.ListenPortNumber = 0;

            com.AddChannel(new DataChannel<byte[]>(
                (short)DefaultTriggerId.Health, QosType.Unreliable, Compression.None, (node, data) => { }, CheckMode.Speedy
                ));

            com.Open();

            timer.Interval = interval;

            timer.Elapsed += OnTimer;
            timer.Start();
        }

        public void Dispose()
        {
            timer.Stop();
            com.Close();
        }

        private void OnTimer(object sender, ElapsedEventArgs e)
        {
            byte[] data = new byte[1] { ProcessId };
            com.Send(node, 0, data);
        }

    }
}
