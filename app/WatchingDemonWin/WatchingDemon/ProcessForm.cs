using System;
using System.IO;
using System.Collections.Generic;
using System.Windows.Forms;

using ProcessMonitor;

namespace WatchingDemon
{
    public partial class ProcessForm : Form
    {

        public short Id { get; private set; }

        public ProcessTarget Process { get; set; }

        bool addProcess = true;

        public ProcessForm(short id = 0)
        {
            Id = id;
            Process = null;

            InitializeComponent();


            InitUI();
        }

        void InitUI()
        {
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.ShowInTaskbar = false;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.StartPosition = FormStartPosition.CenterParent;

            comboBoxLogic.Items.AddRange(new object[] {
                CheckLogicType.Process.ToString(),
                CheckLogicType.WindowMessage.ToString(),
                CheckLogicType.Udp.ToString(),
            });


            if (Id != 0)
            {
                //Edit
                Process = ProcessManager.Instance.GetProcess(Id);
                addProcess = false;
            }
            else
            {
                //Add
                addProcess = true;
            }

            if (Process == null)
            {
                //Add
                Id = 1;
                while (true)
                {
                    var pt = ProcessManager.Instance.GetProcess(Id);
                    if (pt == null) break;
                    Id++;
                }

                Process = new ProcessTarget();
            }

            textBoxID.Text = "" + Id;
            comboBoxLogic.SelectedIndex = (int)Process.LogicType;
            textBoxPeriod.Text = "" + Process.Period;
            textBoxInterval.Text = "" + Process.Interval;
            textBoxExePath.Text = Process.ExePath;
            textBoxArguments.Text = Process.Arguments;
            checkBoxNoWindow.Checked = Process.NoWindow;
            checkBoxActivate.Checked = Process.Activate;


        }

        private void OnExePathClick(object sender, EventArgs e)
        {
            var openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "EXE Files(.exe) | *.exe";
               DialogResult dr = openFileDialog.ShowDialog();
            if (dr == System.Windows.Forms.DialogResult.OK)
            {
                textBoxExePath.Text = openFileDialog.FileName;
            }
        }

        bool ValidateParam()
        {
            try
            {
                if (!File.Exists(textBoxExePath.Text)) return false;

                int period = int.Parse(textBoxPeriod.Text);
                if (period <= 0) return false;

                int interval = int.Parse(textBoxInterval.Text);
                if (interval <= 0) return false;

                short id = short.Parse(textBoxID.Text);

                if (id <= 0) return false;
                else if (id > byte.MaxValue) return false;

                if (addProcess || id != Id)
                {
                    var p = ProcessManager.Instance.GetProcess(id);
                    if (p != null) return false;
                }
                else
                {
                    var p = ProcessManager.Instance.GetProcess(id);
                    if (p == null) return false;
                }

            }
            catch
            {
                return false;
            }

            return true;
        }

        private void OnProcessSaveClick(object sender, EventArgs e)
        {
            if (ValidateParam())
            {
                short id = short.Parse(textBoxID.Text);

                if (id != Id)
                {
                    ProcessManager.Instance.RemoveProcess(Id);
                }

                Id = id;

                Process.Id = Id;
                CheckLogicType type = (CheckLogicType)comboBoxLogic.SelectedIndex;
                Process.GenerateLogic(type);
                Process.ExePath = textBoxExePath.Text;
                Process.Arguments = textBoxArguments.Text;
                Process.Period = short.Parse(textBoxPeriod.Text);
                Process.Interval = short.Parse(textBoxInterval.Text);
                Process.NoWindow = checkBoxNoWindow.Checked;
                Process.Activate = checkBoxActivate.Checked;

                if (ProcessManager.Instance.GetProcess(Id) == null)
                    ProcessManager.Instance.AddProcess(Process);

                ProcessManager.Instance.Serialize(Const.ProcessPath);

                Close();
            }
            else
            {
                MessageBox.Show(
                    "Invalid Parameter.", "Warning",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                    );
            }
        }
    }
}
