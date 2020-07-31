namespace WatchingDemon
{
    partial class SettingForm
    {
        /// <summary>
        /// 必要なデザイナー変数です。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 使用中のリソースをすべてクリーンアップします。
        /// </summary>
        /// <param name="disposing">マネージド リソースを破棄する場合は true を指定し、その他の場合は false を指定します。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows フォーム デザイナーで生成されたコード

        /// <summary>
        /// デザイナー サポートに必要なメソッドです。このメソッドの内容を
        /// コード エディターで変更しないでください。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SettingForm));
            this.contextMenuStripMain = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.monitoringToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.settingToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.restartToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitAppToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.notifyIconMain = new System.Windows.Forms.NotifyIcon(this.components);
            this.tabControlMain = new System.Windows.Forms.TabControl();
            this.tabPageMonitor = new System.Windows.Forms.TabPage();
            this.buttonProcessEdit = new System.Windows.Forms.Button();
            this.labelMonitoring = new System.Windows.Forms.Label();
            this.buttonMonitoring = new System.Windows.Forms.Button();
            this.buttonRemoveProcess = new System.Windows.Forms.Button();
            this.buttonAddProcess = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.listViewProcesses = new System.Windows.Forms.ListView();
            this.tabPagePacket = new System.Windows.Forms.TabPage();
            this.label2 = new System.Windows.Forms.Label();
            this.listViewTriggers = new System.Windows.Forms.ListView();
            this.tabPageSetting = new System.Windows.Forms.TabPage();
            this.textBoxConfigSendPort = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.labelConfigApply = new System.Windows.Forms.Label();
            this.buttonRestart = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.textBoxConfigListenPort = new System.Windows.Forms.TextBox();
            this.checkBoxConfigStartMonitor = new System.Windows.Forms.CheckBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.buttonRemoveAllowList = new System.Windows.Forms.Button();
            this.buttonAddAllowList = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.listViewAllowList = new System.Windows.Forms.ListView();
            this.contextMenuStripMain.SuspendLayout();
            this.tabControlMain.SuspendLayout();
            this.tabPageMonitor.SuspendLayout();
            this.tabPagePacket.SuspendLayout();
            this.tabPageSetting.SuspendLayout();
            this.SuspendLayout();
            // 
            // contextMenuStripMain
            // 
            this.contextMenuStripMain.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.contextMenuStripMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.monitoringToolStripMenuItem,
            this.toolStripSeparator1,
            this.settingToolStripMenuItem,
            this.toolStripSeparator2,
            this.restartToolStripMenuItem,
            this.exitAppToolStripMenuItem});
            this.contextMenuStripMain.Name = "contextMenuStripMain";
            this.contextMenuStripMain.Size = new System.Drawing.Size(162, 104);
            // 
            // monitoringToolStripMenuItem
            // 
            this.monitoringToolStripMenuItem.Name = "monitoringToolStripMenuItem";
            this.monitoringToolStripMenuItem.Size = new System.Drawing.Size(161, 22);
            this.monitoringToolStripMenuItem.Text = "Start Monitoring";
            this.monitoringToolStripMenuItem.Click += new System.EventHandler(this.OnMonitoringToolStripMenuItemClick);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(158, 6);
            // 
            // settingToolStripMenuItem
            // 
            this.settingToolStripMenuItem.Name = "settingToolStripMenuItem";
            this.settingToolStripMenuItem.Size = new System.Drawing.Size(161, 22);
            this.settingToolStripMenuItem.Text = "Setting";
            this.settingToolStripMenuItem.Click += new System.EventHandler(this.OnSettingToolStripMenuItemClick);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(158, 6);
            // 
            // restartToolStripMenuItem
            // 
            this.restartToolStripMenuItem.Name = "restartToolStripMenuItem";
            this.restartToolStripMenuItem.Size = new System.Drawing.Size(161, 22);
            this.restartToolStripMenuItem.Text = "Restart";
            this.restartToolStripMenuItem.Click += new System.EventHandler(this.OnRestartToolStripMenuItemClick);
            // 
            // exitAppToolStripMenuItem
            // 
            this.exitAppToolStripMenuItem.Name = "exitAppToolStripMenuItem";
            this.exitAppToolStripMenuItem.Size = new System.Drawing.Size(161, 22);
            this.exitAppToolStripMenuItem.Text = "Exit";
            this.exitAppToolStripMenuItem.Click += new System.EventHandler(this.OnExitAppToolStripMenuItemClick);
            // 
            // notifyIconMain
            // 
            this.notifyIconMain.ContextMenuStrip = this.contextMenuStripMain;
            this.notifyIconMain.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIconMain.Icon")));
            this.notifyIconMain.Text = "WatchingDemon";
            this.notifyIconMain.Visible = true;
            // 
            // tabControlMain
            // 
            this.tabControlMain.Controls.Add(this.tabPageMonitor);
            this.tabControlMain.Controls.Add(this.tabPagePacket);
            this.tabControlMain.Controls.Add(this.tabPageSetting);
            this.tabControlMain.Location = new System.Drawing.Point(0, 0);
            this.tabControlMain.Name = "tabControlMain";
            this.tabControlMain.SelectedIndex = 0;
            this.tabControlMain.Size = new System.Drawing.Size(1048, 507);
            this.tabControlMain.TabIndex = 1;
            this.tabControlMain.SelectedIndexChanged += new System.EventHandler(this.OnSelectedIndexChange);
            // 
            // tabPageMonitor
            // 
            this.tabPageMonitor.Controls.Add(this.buttonProcessEdit);
            this.tabPageMonitor.Controls.Add(this.labelMonitoring);
            this.tabPageMonitor.Controls.Add(this.buttonMonitoring);
            this.tabPageMonitor.Controls.Add(this.buttonRemoveProcess);
            this.tabPageMonitor.Controls.Add(this.buttonAddProcess);
            this.tabPageMonitor.Controls.Add(this.label1);
            this.tabPageMonitor.Controls.Add(this.listViewProcesses);
            this.tabPageMonitor.Location = new System.Drawing.Point(4, 22);
            this.tabPageMonitor.Name = "tabPageMonitor";
            this.tabPageMonitor.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageMonitor.Size = new System.Drawing.Size(1040, 481);
            this.tabPageMonitor.TabIndex = 0;
            this.tabPageMonitor.Text = "Monitors";
            this.tabPageMonitor.UseVisualStyleBackColor = true;
            // 
            // buttonProcessEdit
            // 
            this.buttonProcessEdit.Image = global::WatchingDemon.Properties.Resources.edit;
            this.buttonProcessEdit.Location = new System.Drawing.Point(73, 450);
            this.buttonProcessEdit.Name = "buttonProcessEdit";
            this.buttonProcessEdit.Size = new System.Drawing.Size(25, 25);
            this.buttonProcessEdit.TabIndex = 6;
            this.buttonProcessEdit.UseVisualStyleBackColor = true;
            this.buttonProcessEdit.Click += new System.EventHandler(this.OnProcessEditClick);
            // 
            // labelMonitoring
            // 
            this.labelMonitoring.AutoSize = true;
            this.labelMonitoring.Location = new System.Drawing.Point(71, 21);
            this.labelMonitoring.Name = "labelMonitoring";
            this.labelMonitoring.Size = new System.Drawing.Size(90, 12);
            this.labelMonitoring.TabIndex = 5;
            this.labelMonitoring.Text = "Monitoring : OFF";
            // 
            // buttonMonitoring
            // 
            this.buttonMonitoring.Image = global::WatchingDemon.Properties.Resources.stop;
            this.buttonMonitoring.Location = new System.Drawing.Point(8, 6);
            this.buttonMonitoring.Name = "buttonMonitoring";
            this.buttonMonitoring.Size = new System.Drawing.Size(57, 41);
            this.buttonMonitoring.TabIndex = 4;
            this.buttonMonitoring.UseVisualStyleBackColor = true;
            this.buttonMonitoring.Click += new System.EventHandler(this.OnMonitoringClick);
            // 
            // buttonRemoveProcess
            // 
            this.buttonRemoveProcess.Image = global::WatchingDemon.Properties.Resources.minus;
            this.buttonRemoveProcess.Location = new System.Drawing.Point(40, 450);
            this.buttonRemoveProcess.Name = "buttonRemoveProcess";
            this.buttonRemoveProcess.Size = new System.Drawing.Size(25, 25);
            this.buttonRemoveProcess.TabIndex = 3;
            this.buttonRemoveProcess.UseVisualStyleBackColor = true;
            this.buttonRemoveProcess.Click += new System.EventHandler(this.OnRemoveProcessClick);
            // 
            // buttonAddProcess
            // 
            this.buttonAddProcess.Image = global::WatchingDemon.Properties.Resources.plus;
            this.buttonAddProcess.Location = new System.Drawing.Point(11, 450);
            this.buttonAddProcess.Name = "buttonAddProcess";
            this.buttonAddProcess.Size = new System.Drawing.Size(25, 25);
            this.buttonAddProcess.TabIndex = 2;
            this.buttonAddProcess.UseVisualStyleBackColor = true;
            this.buttonAddProcess.Click += new System.EventHandler(this.OnAddProcessClick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 55);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(58, 12);
            this.label1.TabIndex = 1;
            this.label1.Text = "Processes";
            // 
            // listViewProcesses
            // 
            this.listViewProcesses.HideSelection = false;
            this.listViewProcesses.Location = new System.Drawing.Point(6, 73);
            this.listViewProcesses.Name = "listViewProcesses";
            this.listViewProcesses.Size = new System.Drawing.Size(1028, 371);
            this.listViewProcesses.TabIndex = 0;
            this.listViewProcesses.UseCompatibleStateImageBehavior = false;
            this.listViewProcesses.ItemChecked += new System.Windows.Forms.ItemCheckedEventHandler(this.OnProcessItemChecked);
            // 
            // tabPagePacket
            // 
            this.tabPagePacket.Controls.Add(this.label2);
            this.tabPagePacket.Controls.Add(this.listViewTriggers);
            this.tabPagePacket.Location = new System.Drawing.Point(4, 22);
            this.tabPagePacket.Name = "tabPagePacket";
            this.tabPagePacket.Size = new System.Drawing.Size(1040, 481);
            this.tabPagePacket.TabIndex = 2;
            this.tabPagePacket.Text = "Packets";
            this.tabPagePacket.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(8, 7);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(47, 12);
            this.label2.TabIndex = 1;
            this.label2.Text = "Triggers";
            // 
            // listViewTriggers
            // 
            this.listViewTriggers.HideSelection = false;
            this.listViewTriggers.Location = new System.Drawing.Point(8, 26);
            this.listViewTriggers.Name = "listViewTriggers";
            this.listViewTriggers.Size = new System.Drawing.Size(740, 450);
            this.listViewTriggers.TabIndex = 0;
            this.listViewTriggers.UseCompatibleStateImageBehavior = false;
            this.listViewTriggers.ItemChecked += new System.Windows.Forms.ItemCheckedEventHandler(this.OnPacketTriggerItemChecked);
            // 
            // tabPageSetting
            // 
            this.tabPageSetting.Controls.Add(this.buttonRemoveAllowList);
            this.tabPageSetting.Controls.Add(this.buttonAddAllowList);
            this.tabPageSetting.Controls.Add(this.label8);
            this.tabPageSetting.Controls.Add(this.listViewAllowList);
            this.tabPageSetting.Controls.Add(this.textBoxConfigSendPort);
            this.tabPageSetting.Controls.Add(this.label3);
            this.tabPageSetting.Controls.Add(this.labelConfigApply);
            this.tabPageSetting.Controls.Add(this.buttonRestart);
            this.tabPageSetting.Controls.Add(this.label6);
            this.tabPageSetting.Controls.Add(this.textBoxConfigListenPort);
            this.tabPageSetting.Controls.Add(this.checkBoxConfigStartMonitor);
            this.tabPageSetting.Controls.Add(this.label5);
            this.tabPageSetting.Controls.Add(this.label4);
            this.tabPageSetting.Location = new System.Drawing.Point(4, 22);
            this.tabPageSetting.Name = "tabPageSetting";
            this.tabPageSetting.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageSetting.Size = new System.Drawing.Size(1040, 481);
            this.tabPageSetting.TabIndex = 1;
            this.tabPageSetting.Text = "Settings";
            this.tabPageSetting.UseVisualStyleBackColor = true;
            // 
            // textBoxConfigSendPort
            // 
            this.textBoxConfigSendPort.Location = new System.Drawing.Point(154, 149);
            this.textBoxConfigSendPort.Name = "textBoxConfigSendPort";
            this.textBoxConfigSendPort.Size = new System.Drawing.Size(100, 19);
            this.textBoxConfigSendPort.TabIndex = 8;
            this.textBoxConfigSendPort.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.textBoxConfigSendPort.TextChanged += new System.EventHandler(this.OnSendPortTextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(44, 152);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(95, 12);
            this.label3.TabIndex = 7;
            this.label3.Text = "Send port number";
            // 
            // labelConfigApply
            // 
            this.labelConfigApply.AutoSize = true;
            this.labelConfigApply.ForeColor = System.Drawing.Color.Red;
            this.labelConfigApply.Location = new System.Drawing.Point(730, 438);
            this.labelConfigApply.Name = "labelConfigApply";
            this.labelConfigApply.Size = new System.Drawing.Size(280, 12);
            this.labelConfigApply.TabIndex = 6;
            this.labelConfigApply.Text = "(Config parameters are applied when restart daemon.)";
            this.labelConfigApply.Visible = false;
            // 
            // buttonRestart
            // 
            this.buttonRestart.Location = new System.Drawing.Point(928, 407);
            this.buttonRestart.Name = "buttonRestart";
            this.buttonRestart.Size = new System.Drawing.Size(75, 23);
            this.buttonRestart.TabIndex = 5;
            this.buttonRestart.Text = "Restart";
            this.buttonRestart.UseVisualStyleBackColor = true;
            this.buttonRestart.Click += new System.EventHandler(this.OnRestartClick);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(44, 115);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(101, 12);
            this.label6.TabIndex = 4;
            this.label6.Text = "Listen port number";
            // 
            // textBoxConfigListenPort
            // 
            this.textBoxConfigListenPort.Location = new System.Drawing.Point(154, 112);
            this.textBoxConfigListenPort.Name = "textBoxConfigListenPort";
            this.textBoxConfigListenPort.Size = new System.Drawing.Size(100, 19);
            this.textBoxConfigListenPort.TabIndex = 3;
            this.textBoxConfigListenPort.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.textBoxConfigListenPort.TextChanged += new System.EventHandler(this.OnListenPortTextChanged);
            // 
            // checkBoxConfigStartMonitor
            // 
            this.checkBoxConfigStartMonitor.AutoSize = true;
            this.checkBoxConfigStartMonitor.Location = new System.Drawing.Point(44, 48);
            this.checkBoxConfigStartMonitor.Name = "checkBoxConfigStartMonitor";
            this.checkBoxConfigStartMonitor.Size = new System.Drawing.Size(289, 16);
            this.checkBoxConfigStartMonitor.TabIndex = 2;
            this.checkBoxConfigStartMonitor.Text = "Start monitoring automatically at launching daemon.";
            this.checkBoxConfigStartMonitor.UseVisualStyleBackColor = true;
            this.checkBoxConfigStartMonitor.CheckedChanged += new System.EventHandler(this.OnAutoPlayCheckedChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(23, 87);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(76, 12);
            this.label5.TabIndex = 1;
            this.label5.Text = "PacketTrigger";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(23, 21);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(88, 12);
            this.label4.TabIndex = 0;
            this.label4.Text = "Process Monitor";
            // 
            // buttonRemoveAllowList
            // 
            this.buttonRemoveAllowList.Image = global::WatchingDemon.Properties.Resources.minus;
            this.buttonRemoveAllowList.Location = new System.Drawing.Point(766, 350);
            this.buttonRemoveAllowList.Name = "buttonRemoveAllowList";
            this.buttonRemoveAllowList.Size = new System.Drawing.Size(25, 25);
            this.buttonRemoveAllowList.TabIndex = 17;
            this.buttonRemoveAllowList.UseVisualStyleBackColor = true;
            this.buttonRemoveAllowList.Click += new System.EventHandler(this.OnRemoveAllowListClick);
            // 
            // buttonAddAllowList
            // 
            this.buttonAddAllowList.Image = global::WatchingDemon.Properties.Resources.plus;
            this.buttonAddAllowList.Location = new System.Drawing.Point(735, 350);
            this.buttonAddAllowList.Name = "buttonAddAllowList";
            this.buttonAddAllowList.Size = new System.Drawing.Size(25, 25);
            this.buttonAddAllowList.TabIndex = 16;
            this.buttonAddAllowList.UseVisualStyleBackColor = true;
            this.buttonAddAllowList.Click += new System.EventHandler(this.OnAddAllowListClick);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(733, 2);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(56, 12);
            this.label8.TabIndex = 15;
            this.label8.Text = "Allow List";
            // 
            // listViewAllowList
            // 
            this.listViewAllowList.HideSelection = false;
            this.listViewAllowList.LabelEdit = true;
            this.listViewAllowList.Location = new System.Drawing.Point(732, 21);
            this.listViewAllowList.Name = "listViewAllowList";
            this.listViewAllowList.Size = new System.Drawing.Size(280, 323);
            this.listViewAllowList.TabIndex = 14;
            this.listViewAllowList.UseCompatibleStateImageBehavior = false;
            this.listViewAllowList.AfterLabelEdit += new System.Windows.Forms.LabelEditEventHandler(this.OnAllowListAfterLabelEdit);
            // 
            // SettingForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1050, 510);
            this.Controls.Add(this.tabControlMain);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "SettingForm";
            this.Text = "Watching Demon";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.OnClosing);
            this.contextMenuStripMain.ResumeLayout(false);
            this.tabControlMain.ResumeLayout(false);
            this.tabPageMonitor.ResumeLayout(false);
            this.tabPageMonitor.PerformLayout();
            this.tabPagePacket.ResumeLayout(false);
            this.tabPagePacket.PerformLayout();
            this.tabPageSetting.ResumeLayout(false);
            this.tabPageSetting.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ContextMenuStrip contextMenuStripMain;
        private System.Windows.Forms.ToolStripMenuItem exitAppToolStripMenuItem;
        private System.Windows.Forms.NotifyIcon notifyIconMain;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem settingToolStripMenuItem;
        private System.Windows.Forms.TabControl tabControlMain;
        private System.Windows.Forms.TabPage tabPageMonitor;
        private System.Windows.Forms.TabPage tabPageSetting;
        private System.Windows.Forms.TabPage tabPagePacket;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListView listViewProcesses;
        private System.Windows.Forms.Button buttonAddProcess;
        private System.Windows.Forms.Button buttonRemoveProcess;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ListView listViewTriggers;
        private System.Windows.Forms.Button buttonMonitoring;
        private System.Windows.Forms.Label labelMonitoring;
        private System.Windows.Forms.CheckBox checkBoxConfigStartMonitor;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox textBoxConfigListenPort;
        private System.Windows.Forms.Button buttonRestart;
        private System.Windows.Forms.Label labelConfigApply;
        private System.Windows.Forms.Button buttonProcessEdit;
        private System.Windows.Forms.ToolStripMenuItem monitoringToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem restartToolStripMenuItem;
        private System.Windows.Forms.TextBox textBoxConfigSendPort;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button buttonRemoveAllowList;
        private System.Windows.Forms.Button buttonAddAllowList;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ListView listViewAllowList;
    }
}

