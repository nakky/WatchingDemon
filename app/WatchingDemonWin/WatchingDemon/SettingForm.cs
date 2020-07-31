using System;
using System.Collections.Generic;
using System.Windows.Forms;
using PacketTrigger;
using ProcessMonitor;
using System.IO;
using System.Runtime.InteropServices;
using System.Reflection;

namespace WatchingDemon
{
    public enum TabId
    {
        ProcessMonitor = 0,
        PacketTrigger = 1,
        Setting = 2
    }

    public partial class SettingForm : Form
    {
        bool canClose = true;

        Config Config { get; set; }

        Logger logger;

        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool SetForegroundWindow(IntPtr hWnd);

        public SettingForm()
        {
            InitializeComponent();

            string LogPathFile = AppDomain.CurrentDomain.BaseDirectory;
            LogPathFile += "Log/";
            logger = new Logger(LogPathFile);

            logger.Log("#########Launch Daemon#########");

            InitUI();

            //Config
            Config = new Config();
            Config.Deserialize(Const.ConfigPath);

            //ProcessManager
            ProcessManager.Instance.SynchronizeObject = this;
            ProcessManager.Instance.Deserialize(Const.ProcessPath);

            ProcessManager.Instance.OnLog += (log) => 
            {
                string l = DateTime.Now.ToString(@"hh\:mm\:ss") + " : " + log;
                Console.WriteLine(l);
                logger.Log(l);
            };

            //AllowList
            AllowList alist = new AllowList();
            alist.Deserialize(Const.AllowListPath);

            //PacketTrigger
            LoadPlugins();
            PacketTriggerManager.Instance.Deserialize(Const.PacketTriggerPath);
            PacketTriggerManager.Instance.AllowList = alist;
            PacketTriggerManager.Instance.OpenReceiveChannel(Config.ListenPortNumber);
            PacketTriggerManager.Instance.OpenSendChannel(Config.SendPortNumber);


#if !DEBUG
            ExecuteBackgroundProcess();
#else
            Visible = true;
#endif

            ProcessManager.Instance.OnMonitoring += () => 
            {
                UpdateProcessList();
                UpdateUI();
            };

            ProcessManager.Instance.OnActivateSignal += (target) => 
            {
                try
                {
                    SetForegroundWindow(target.Target.MainWindowHandle);
                }
                catch(Exception e)
                {

                }
                
            };

            TabChanged(TabId.ProcessMonitor);

            if (Config.AutoStart)
            {
                Monitoring(true);
                UpdateUI();
            }
        }

        void ExitApp(bool killRegularProcess = true)
        {
            notifyIconMain.Visible = false;

            PacketTriggerManager.Instance.Close();

            ProcessManager.Instance.StopMonitoring();
            ProcessManager.Instance.StopRegularMonitoring();

            if (killRegularProcess)
            {
                ProcessManager.Instance.KillAllRegularProcesses();
            }
           
            canClose = false;
            Close();

            Application.Exit();
        }

        void RestartApp(bool killRegularProcess = true)
        {
            notifyIconMain.Visible = false;

            PacketTriggerManager.Instance.Close();

            ProcessManager.Instance.StopMonitoring();
            ProcessManager.Instance.StopRegularMonitoring();

            if (killRegularProcess)
            {
                ProcessManager.Instance.KillAllRegularProcesses();
            }

            canClose = false;
            Close();

            Application.Restart();
        }

        void ExecuteBackgroundProcess()
        {
            string TargetExePath = AppDomain.CurrentDomain.BaseDirectory;
            TargetExePath += "IntelligentDemon.exe";

            ProcessTarget process = new ProcessTarget(CheckLogicType.WindowMessage);
            process.ExePath = TargetExePath;

            process.Interval = 2;
            process.Period = 2;

            process.NoWindow = false;
            process.Activate = false;
            process.Enable = true;

            ProcessManager.Instance.AddRegularProcess(process);
            ProcessManager.Instance.StartRegularMonitoring();
        }

        void InitUI()
        {
            ColumnHeader column0, column1, column2, column3, column4,
                column5, column6, column7, column8, column9, column10,
                column11;
            ColumnHeader[] colHeaderRegValue;

            //ListView Porcesses
            listViewProcesses.FullRowSelect = true;
            listViewProcesses.GridLines = true;
            listViewProcesses.Sorting = SortOrder.None;
            listViewProcesses.View = View.Details;
            listViewProcesses.CheckBoxes = true;

            column0 = new ColumnHeader();
            column0.Text = "";
            column0.Width = 20;

            column1 = new ColumnHeader();
            column1.Text = "Id";
            column1.Width = 35;
            column1.TextAlign = HorizontalAlignment.Right;

            column2 = new ColumnHeader();
            column2.Text = "Name";
            column2.Width = 100;

            column3 = new ColumnHeader();
            column3.Text = "Path";
            column3.Width = 280;

            column4 = new ColumnHeader();
            column4.Text = "Arguments";
            column4.Width = 80;

            column5 = new ColumnHeader();
            column5.Text = "Logic";
            column5.Width = 100;

            column6 = new ColumnHeader();
            column6.Text = "Period";
            column6.Width = 50;
            column6.TextAlign = HorizontalAlignment.Right;

            column7 = new ColumnHeader();
            column7.Text = "Interval";
            column7.Width = 50;
            column7.TextAlign = HorizontalAlignment.Right;

            column8 = new ColumnHeader();
            column8.Text = "NoWindow";
            column8.Width = 70;

            column9 = new ColumnHeader();
            column9.Text = "Activate";
            column9.Width = 60;

            column10 = new ColumnHeader();
            column10.Text = "Status";
            column10.Width = 100;

            column11 = new ColumnHeader();
            column11.Text = "Time";
            column11.Width = 70;
            column11.TextAlign = HorizontalAlignment.Right;

            colHeaderRegValue = new ColumnHeader[] { 
                column0, column1, column2, column3, column4, column5,
                column6, column7, column8, column9, column10, column11
            };
            listViewProcesses.Columns.AddRange(colHeaderRegValue);

            //ListView Triggers
            listViewTriggers.FullRowSelect = true;
            listViewTriggers.GridLines = true;
            listViewTriggers.Sorting = SortOrder.None;
            listViewTriggers.View = View.Details;
            listViewTriggers.CheckBoxes = true;

            column0 = new ColumnHeader();
            column0.Text = "";
            column0.Width = 20;

            column1 = new ColumnHeader();
            column1.Text = "ID";
            column1.Width = 40;
            column1.TextAlign = HorizontalAlignment.Right;

            column2 = new ColumnHeader();
            column2.Text = "Name";
            column2.Width = 130;

            column3 = new ColumnHeader();
            column3.Text = "Description";
            column3.Width = 400;


            colHeaderRegValue = new ColumnHeader[] { column0, column1, column2, column3 };
            listViewTriggers.Columns.AddRange(colHeaderRegValue);

            listViewAllowList.FullRowSelect = true;
            listViewAllowList.GridLines = true;
            listViewAllowList.Sorting = SortOrder.None;
            listViewAllowList.View = View.Details;

            column0 = new ColumnHeader();
            column0.Text = "IP Address";
            column0.Width = 270;

            colHeaderRegValue = new ColumnHeader[] { column0 };
            listViewAllowList.Columns.AddRange(colHeaderRegValue);

        }

        void LoadPlugins()
        {
            string PluginFolderPath = AppDomain.CurrentDomain.BaseDirectory;
            PluginFolderPath += "Plugin";

            string[] files = Directory.GetFiles(PluginFolderPath, "*.dll");

            foreach (string file in files)
            {
                Assembly asm = Assembly.LoadFrom(file); 
                PacketTriggerManager.Instance.SearchPacketTriggers(asm);
            }
        }

        void UpdatePacketTriggerList()
        {
            listViewTriggers.Items.Clear();
            var sorted = PacketTriggerManager.Instance.GetOrderdPluginMap();

            foreach (var p in sorted)
            {
                Plugin pt = p.Value;

                string[] item = { "", pt.Id.ToString(), pt.PluginName, pt.Description };
                ListViewItem listItem = new ListViewItem(item);
                listItem.Checked = p.Value.Enable;
                listViewTriggers.Items.Add(listItem);
            }
        }

        void UpdateProcessList()
        {
            listViewProcesses.Items.Clear();
            var sorted = ProcessManager.Instance.GetOrderdProcessMap();

            foreach (var p in sorted)
            {
                ProcessTarget pt = p.Value;

                string name = Path.GetFileNameWithoutExtension(pt.ExePath);

                string elapsed = p.Value.GetElapsedTime().ToString(@"hh\:mm\:ss");

                string[] item = { 
                    "",  pt.Id.ToString(), name, pt.ExePath,  pt.Arguments, pt.LogicType.ToString(),
                    pt.Period.ToString(), pt.Interval.ToString(), pt.NoWindow.ToString(), pt.Activate.ToString(),
                    pt.State.ToString(), elapsed 
                };
                ListViewItem listItem = new ListViewItem(item);
                listItem.Checked = p.Value.Enable;
                listViewProcesses.Items.Add(listItem);
            }

        }

        void UpdateUI()
        {
            if (ProcessManager.Instance.IsMonitoring)
            {
                labelMonitoring.Text = "Monitoring : ON";
                buttonMonitoring.Image = Properties.Resources.stop;
                listViewProcesses.Enabled = false;
                buttonAddProcess.Enabled = false;
                buttonRemoveProcess.Enabled = false;
                buttonProcessEdit.Enabled = false;

                monitoringToolStripMenuItem.Text = "Stop Monitoring";
            }
            else
            {
                labelMonitoring.Text = "Monitoring : OFF";
                buttonMonitoring.Image = Properties.Resources.play;
                listViewProcesses.Enabled = true;
                buttonAddProcess.Enabled = true;
                buttonRemoveProcess.Enabled = true;
                buttonProcessEdit.Enabled = true;

                monitoringToolStripMenuItem.Text = "Start Monitoring";
            }
        }

        void UpdateConfig()
        {
            textBoxConfigSendPort.Text = Config.SendPortNumber.ToString();
            textBoxConfigListenPort.Text = Config.ListenPortNumber.ToString();
            checkBoxConfigStartMonitor.Checked = Config.AutoStart;

            listViewAllowList.Items.Clear();
            foreach(var item in PacketTriggerManager.Instance.AllowList.List)
            {
                listViewAllowList.Items.Add(item);
            }
        }

#region EventHandler

        private void OnMonitoringToolStripMenuItemClick(object sender, EventArgs e)
        {
            bool isMonitoring = ProcessManager.Instance.IsMonitoring;

            Monitoring(!isMonitoring);
        }

        private void OnSettingToolStripMenuItemClick(object sender, EventArgs e)
        {
            Visible = true;
        }

        private void OnRestartToolStripMenuItemClick(object sender, EventArgs e)
        {
            RestartApp();
        }

        private void OnExitAppToolStripMenuItemClick(object sender, EventArgs e)
        {
            ExitApp();
        }


        private void OnClosing(object sender, FormClosingEventArgs e)
        {
            if (canClose)
            {
                e.Cancel = true;
                Visible = false;
            }
        }

        private void OnSelectedIndexChange(object sender, EventArgs e)
        {
            TabChanged((TabId)tabControlMain.SelectedIndex);
        }

        private void OnAddProcessClick(object sender, EventArgs e)
        {
            var dialog = new ProcessForm();
            dialog.ShowDialog();

            UpdateProcessList();
        }

        private void OnRemoveProcessClick(object sender, EventArgs e)
        {
            for (int i = 0; i < listViewProcesses.SelectedItems.Count; i++)
            {
                var item = listViewProcesses.SelectedItems[i];
                short id = short.Parse(item.SubItems[1].Text);
                ProcessManager.Instance.RemoveProcess(id);
            }
            UpdateProcessList();
            ProcessManager.Instance.Serialize(Const.ProcessPath);
        }

        private void OnProcessEditClick(object sender, EventArgs e)
        {
            if(listViewProcesses.SelectedItems.Count > 0)
            {
                var item = listViewProcesses.SelectedItems[0];
                short id = short.Parse(item.SubItems[1].Text);
                var dialog = new ProcessForm(id);
                dialog.ShowDialog();

                UpdateProcessList();
            }
           
        }

        private void OnProcessItemChecked(object sender, ItemCheckedEventArgs e)
        {
            short id = short.Parse(e.Item.SubItems[1].Text);
            //Console.WriteLine("Change:" + id);

            ProcessTarget p = ProcessManager.Instance.GetProcess(id);
            p.Enable = e.Item.Checked;

            ProcessManager.Instance.Serialize(Const.ProcessPath);
        }

        private void OnPacketTriggerItemChecked(object sender, ItemCheckedEventArgs e)
        {
            short id = short.Parse(e.Item.SubItems[1].Text);
            //Console.WriteLine("Change:" + id);

            Plugin p = PacketTriggerManager.Instance.GetPlugin(id);
            p.Enable = e.Item.Checked;

            PacketTriggerManager.Instance.Serialize(Const.PacketTriggerPath);
        }

        private void OnAddAllowListClick(object sender, EventArgs e)
        {
            ListViewItem item = new ListViewItem();
            item.Text = "";
            listViewAllowList.Items.Add(item);
            listViewAllowList.Focus();
            item.BeginEdit();
        }

        private void OnRemoveAllowListClick(object sender, EventArgs e)
        {
            AllowList alist = PacketTriggerManager.Instance.AllowList;
            foreach (ListViewItem item in listViewAllowList.SelectedItems)
            {
                alist.List.Remove(item.SubItems[0].Text);
            }
            alist.Serialize(Const.AllowListPath);
            UpdateConfig();

            labelConfigApply.Visible = true;
        }

        private void OnAllowListAfterLabelEdit(object sender, LabelEditEventArgs e)
        {
            AllowList alist = new AllowList();
            List<string> list = new List<string>();

            foreach (ListViewItem item in listViewAllowList.Items)
            {
                string data = item.SubItems[0].Text;
                if (item.Index == e.Item) data = e.Label;
                //Console.WriteLine(data);
                list.Add(data);
            }
            alist.List = list;
            alist.Serialize(Const.AllowListPath);
            PacketTriggerManager.Instance.AllowList = alist;
            UpdateConfig();

            labelConfigApply.Visible = true;
        }

        private void OnAutoPlayCheckedChanged(object sender, EventArgs e)
        {
            Config.AutoStart = checkBoxConfigStartMonitor.Checked;
            Config.Serialize(Const.ConfigPath);

            labelConfigApply.Visible = true;
        }

        private void OnListenPortTextChanged(object sender, EventArgs e)
        {
            try
            {
                int number = int.Parse(textBoxConfigListenPort.Text);
                if (Config.ListenPortNumber != number) labelConfigApply.Visible = true;
                Config.ListenPortNumber = number;
                Config.Serialize(Const.ConfigPath);
            }
            catch
            {
                UpdateConfig();
            }
        }

        private void OnSendPortTextChanged(object sender, EventArgs e)
        {
            try
            {
                int number = int.Parse(textBoxConfigSendPort.Text);
                if (Config.SendPortNumber != number) labelConfigApply.Visible = true;
                Config.SendPortNumber = number;
                Config.Serialize(Const.ConfigPath);
            }
            catch
            {
                UpdateConfig();
            }
        }

        private void OnRestartClick(object sender, EventArgs e)
        {
            RestartApp();
        }

        private void OnMonitoringClick(object sender, EventArgs e)
        {
            bool start = !ProcessManager.Instance.IsMonitoring;
            Monitoring(start);
        }

#endregion

        void TabChanged(TabId tabId)
        {
            //Console.WriteLine("Change:" + tabId);

            switch (tabId)
            {
                case TabId.ProcessMonitor:
                    UpdateProcessList();
                    break;
                case TabId.PacketTrigger:
                    UpdatePacketTriggerList();
                    break;
                case TabId.Setting:
                    UpdateConfig();
                    break;
            }
            UpdateUI();
        }


        public void Monitoring(bool start)
        {
            if (start)
            {
                ProcessManager.Instance.StartMonitoring();
            }
            else
            {
                ProcessManager.Instance.StopMonitoring();
            }

        }

       
    }
}
