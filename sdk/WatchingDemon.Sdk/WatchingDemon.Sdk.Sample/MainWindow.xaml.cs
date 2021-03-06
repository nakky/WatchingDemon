﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;

using WatchingDemon.Sdk;

namespace WatchingDemon.Sdk.Sample
{
    /// <summary>
    /// MainWindow.xam
    /// </summary>
    public partial class MainWindow : Window
    {
        UdpHealthPulse udpHealthPulse = new UdpHealthPulse(1);

        PacketTriggerApi triggerApi = new PacketTriggerApi();

        string targetIp = IPAddress.Loopback.ToString();

        RemoteMonitor monitor;
        RemoteNode node;
        DispatcherTimer eventTimer;

        public MainWindow()
        {
            InitializeComponent();

            string[] ipList = new string[1] { "127.0.0.1" };
            monitor = new RemoteMonitor(ipList);

            node = monitor.GetNode(ipList[0]);

            eventTimer = new DispatcherTimer(DispatcherPriority.Normal, this.Dispatcher);
            eventTimer.Interval = TimeSpan.FromSeconds(1);
            eventTimer.Tick += new EventHandler(OnTimer);
            eventTimer.Start();
        }

        private void OnTimer(object sender, EventArgs e)
        {
            //Console.WriteLine(node.Ip + ":" + node.Status);
            labelStatus.Content = "Status:" + node.Status;
        }

        private void OnButtonShutdownClick(object sender, RoutedEventArgs e)
        {
            var result = MessageBox.Show("Are you sure you want to shutdown?", "Warning", MessageBoxButton.OKCancel);
            if(result == MessageBoxResult.OK)
            {
                triggerApi.ShutdownRequest(targetIp);
            }
        }

        private void OnButtonRebootClick(object sender, RoutedEventArgs e)
        {
            var result = MessageBox.Show("Are you sure you want to reboot?", "Warning", MessageBoxButton.OKCancel);
            if (result == MessageBoxResult.OK)
            {
                triggerApi.RebootRequest(targetIp);
            }
        }

        private void OnButtonKillAppClick(object sender, RoutedEventArgs e)
        {
            try
            {
                byte id = byte.Parse(textBoxKillApp.Text);
                triggerApi.KillProcess(targetIp, id);
            }
            catch
            {
                textBoxKillApp.Text = "";
            }
            
        }

        private void OnButtonStartMonitoringClick(object sender, RoutedEventArgs e)
        {
            triggerApi.MonitoringStart(targetIp);
        }

        private void OnButtonStopMonitoringClick(object sender, RoutedEventArgs e)
        {
            triggerApi.MonitoringStop(targetIp);
        }
    }
}
