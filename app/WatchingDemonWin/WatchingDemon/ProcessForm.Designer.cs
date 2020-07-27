namespace WatchingDemon
{
    partial class ProcessForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.textBoxExePath = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.buttonExePath = new System.Windows.Forms.Button();
            this.buttonProcessSave = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.textBoxID = new System.Windows.Forms.TextBox();
            this.textBoxPeriod = new System.Windows.Forms.TextBox();
            this.comboBoxLogic = new System.Windows.Forms.ComboBox();
            this.textBoxArguments = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.textBoxInterval = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.checkBoxNoWindow = new System.Windows.Forms.CheckBox();
            this.checkBoxActivate = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // textBoxExePath
            // 
            this.textBoxExePath.AllowDrop = true;
            this.textBoxExePath.Location = new System.Drawing.Point(40, 28);
            this.textBoxExePath.Name = "textBoxExePath";
            this.textBoxExePath.ReadOnly = true;
            this.textBoxExePath.Size = new System.Drawing.Size(468, 19);
            this.textBoxExePath.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(25, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(72, 12);
            this.label1.TabIndex = 1;
            this.label1.Text = "EXE file path";
            // 
            // buttonExePath
            // 
            this.buttonExePath.Location = new System.Drawing.Point(518, 26);
            this.buttonExePath.Name = "buttonExePath";
            this.buttonExePath.Size = new System.Drawing.Size(33, 23);
            this.buttonExePath.TabIndex = 2;
            this.buttonExePath.Text = "...";
            this.buttonExePath.UseVisualStyleBackColor = true;
            this.buttonExePath.Click += new System.EventHandler(this.OnExePathClick);
            // 
            // buttonProcessSave
            // 
            this.buttonProcessSave.Location = new System.Drawing.Point(476, 194);
            this.buttonProcessSave.Name = "buttonProcessSave";
            this.buttonProcessSave.Size = new System.Drawing.Size(75, 23);
            this.buttonProcessSave.TabIndex = 3;
            this.buttonProcessSave.Text = "Save";
            this.buttonProcessSave.UseVisualStyleBackColor = true;
            this.buttonProcessSave.Click += new System.EventHandler(this.OnProcessSaveClick);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(78, 113);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(16, 12);
            this.label2.TabIndex = 4;
            this.label2.Text = "ID";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(272, 113);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(32, 12);
            this.label3.TabIndex = 5;
            this.label3.Text = "Logic";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(27, 145);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(66, 12);
            this.label4.TabIndex = 6;
            this.label4.Text = "Period(Sec.)";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // textBoxID
            // 
            this.textBoxID.Location = new System.Drawing.Point(101, 109);
            this.textBoxID.Name = "textBoxID";
            this.textBoxID.Size = new System.Drawing.Size(121, 19);
            this.textBoxID.TabIndex = 7;
            // 
            // textBoxPeriod
            // 
            this.textBoxPeriod.Location = new System.Drawing.Point(100, 141);
            this.textBoxPeriod.Name = "textBoxPeriod";
            this.textBoxPeriod.Size = new System.Drawing.Size(121, 19);
            this.textBoxPeriod.TabIndex = 8;
            // 
            // comboBoxLogic
            // 
            this.comboBoxLogic.FormattingEnabled = true;
            this.comboBoxLogic.Location = new System.Drawing.Point(308, 109);
            this.comboBoxLogic.Name = "comboBoxLogic";
            this.comboBoxLogic.Size = new System.Drawing.Size(121, 20);
            this.comboBoxLogic.TabIndex = 9;
            // 
            // textBoxArguments
            // 
            this.textBoxArguments.Location = new System.Drawing.Point(40, 67);
            this.textBoxArguments.Name = "textBoxArguments";
            this.textBoxArguments.Size = new System.Drawing.Size(468, 19);
            this.textBoxArguments.TabIndex = 10;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(25, 52);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(60, 12);
            this.label5.TabIndex = 11;
            this.label5.Text = "Arguments";
            // 
            // textBoxInterval
            // 
            this.textBoxInterval.Location = new System.Drawing.Point(308, 141);
            this.textBoxInterval.Name = "textBoxInterval";
            this.textBoxInterval.Size = new System.Drawing.Size(121, 19);
            this.textBoxInterval.TabIndex = 13;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(232, 145);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(72, 12);
            this.label6.TabIndex = 12;
            this.label6.Text = "Interval(Sec.)";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // checkBoxNoWindow
            // 
            this.checkBoxNoWindow.AutoSize = true;
            this.checkBoxNoWindow.Location = new System.Drawing.Point(100, 178);
            this.checkBoxNoWindow.Name = "checkBoxNoWindow";
            this.checkBoxNoWindow.Size = new System.Drawing.Size(80, 16);
            this.checkBoxNoWindow.TabIndex = 14;
            this.checkBoxNoWindow.Text = "No Window";
            this.checkBoxNoWindow.UseVisualStyleBackColor = true;
            // 
            // checkBoxActivate
            // 
            this.checkBoxActivate.AutoSize = true;
            this.checkBoxActivate.Location = new System.Drawing.Point(234, 178);
            this.checkBoxActivate.Name = "checkBoxActivate";
            this.checkBoxActivate.Size = new System.Drawing.Size(201, 16);
            this.checkBoxActivate.TabIndex = 15;
            this.checkBoxActivate.Text = "Active window at regular intervals.";
            this.checkBoxActivate.UseVisualStyleBackColor = true;
            // 
            // ProcessForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(577, 227);
            this.Controls.Add(this.checkBoxActivate);
            this.Controls.Add(this.checkBoxNoWindow);
            this.Controls.Add(this.textBoxInterval);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.textBoxArguments);
            this.Controls.Add(this.comboBoxLogic);
            this.Controls.Add(this.textBoxPeriod);
            this.Controls.Add(this.textBoxID);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.buttonProcessSave);
            this.Controls.Add(this.buttonExePath);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBoxExePath);
            this.Name = "ProcessForm";
            this.Text = "Process";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBoxExePath;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button buttonExePath;
        private System.Windows.Forms.Button buttonProcessSave;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBoxID;
        private System.Windows.Forms.TextBox textBoxPeriod;
        private System.Windows.Forms.ComboBox comboBoxLogic;
        private System.Windows.Forms.TextBox textBoxArguments;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textBoxInterval;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.CheckBox checkBoxNoWindow;
        private System.Windows.Forms.CheckBox checkBoxActivate;
    }
}