namespace MoverDemo
{
    partial class Form1
    {
        /// <summary>
        /// Erforderliche Designervariable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Verwendete Ressourcen bereinigen.
        /// </summary>
        /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Vom Windows Form-Designer generierter Code

        /// <summary>
        /// Erforderliche Methode für die Designerunterstützung.
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.labelStatus = new System.Windows.Forms.Label();
            this.buttonSetJointsToZero = new System.Windows.Forms.Button();
            this.buttonEnable = new System.Windows.Forms.Button();
            this.buttonReset = new System.Windows.Forms.Button();
            this.buttonConnect = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.labelErrorCodes = new System.Windows.Forms.Label();
            this.buttonJogPlus = new System.Windows.Forms.Button();
            this.buttonJogMinus = new System.Windows.Forms.Button();
            this.labelOverride = new System.Windows.Forms.Label();
            this.buttonOvrPlus = new System.Windows.Forms.Button();
            this.buttonOvrMinus = new System.Windows.Forms.Button();
            this.comboBoxJoints = new System.Windows.Forms.ComboBox();
            this.labelJointsCurrent = new System.Windows.Forms.Label();
            this.labelJointsSetPoint = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.checkBoxOutTCP2 = new System.Windows.Forms.CheckBox();
            this.checkBoxOutTCP1 = new System.Windows.Forms.CheckBox();
            this.checkBoxOutBase4 = new System.Windows.Forms.CheckBox();
            this.checkBoxOutBase3 = new System.Windows.Forms.CheckBox();
            this.checkBoxOutBase2 = new System.Windows.Forms.CheckBox();
            this.checkBoxOutBase1 = new System.Windows.Forms.CheckBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.checkBoxInBase4 = new System.Windows.Forms.CheckBox();
            this.checkBoxInBase3 = new System.Windows.Forms.CheckBox();
            this.checkBoxInBase2 = new System.Windows.Forms.CheckBox();
            this.checkBoxInBase1 = new System.Windows.Forms.CheckBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.labelStatus);
            this.groupBox1.Controls.Add(this.buttonSetJointsToZero);
            this.groupBox1.Controls.Add(this.buttonEnable);
            this.groupBox1.Controls.Add(this.buttonReset);
            this.groupBox1.Controls.Add(this.buttonConnect);
            this.groupBox1.Location = new System.Drawing.Point(18, 18);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBox1.Size = new System.Drawing.Size(207, 386);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "HW Control";
            // 
            // labelStatus
            // 
            this.labelStatus.AutoSize = true;
            this.labelStatus.Location = new System.Drawing.Point(9, 71);
            this.labelStatus.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelStatus.Name = "labelStatus";
            this.labelStatus.Size = new System.Drawing.Size(86, 20);
            this.labelStatus.TabIndex = 4;
            this.labelStatus.Text = "Status: n/a";
            // 
            // buttonSetJointsToZero
            // 
            this.buttonSetJointsToZero.Location = new System.Drawing.Point(9, 342);
            this.buttonSetJointsToZero.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.buttonSetJointsToZero.Name = "buttonSetJointsToZero";
            this.buttonSetJointsToZero.Size = new System.Drawing.Size(112, 35);
            this.buttonSetJointsToZero.TabIndex = 3;
            this.buttonSetJointsToZero.Text = "SetJointsToZero";
            this.buttonSetJointsToZero.UseVisualStyleBackColor = true;
            this.buttonSetJointsToZero.Click += new System.EventHandler(this.buttonSetJointsToZero_Click);
            // 
            // buttonEnable
            // 
            this.buttonEnable.Location = new System.Drawing.Point(10, 172);
            this.buttonEnable.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.buttonEnable.Name = "buttonEnable";
            this.buttonEnable.Size = new System.Drawing.Size(112, 35);
            this.buttonEnable.TabIndex = 2;
            this.buttonEnable.Text = "Enable";
            this.buttonEnable.UseVisualStyleBackColor = true;
            this.buttonEnable.Click += new System.EventHandler(this.buttonEnable_Click);
            // 
            // buttonReset
            // 
            this.buttonReset.Location = new System.Drawing.Point(10, 126);
            this.buttonReset.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.buttonReset.Name = "buttonReset";
            this.buttonReset.Size = new System.Drawing.Size(112, 35);
            this.buttonReset.TabIndex = 1;
            this.buttonReset.Text = "Reset";
            this.buttonReset.UseVisualStyleBackColor = true;
            this.buttonReset.Click += new System.EventHandler(this.buttonReset_Click);
            // 
            // buttonConnect
            // 
            this.buttonConnect.Location = new System.Drawing.Point(10, 31);
            this.buttonConnect.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.buttonConnect.Name = "buttonConnect";
            this.buttonConnect.Size = new System.Drawing.Size(112, 35);
            this.buttonConnect.TabIndex = 0;
            this.buttonConnect.Text = "Connect";
            this.buttonConnect.UseVisualStyleBackColor = true;
            this.buttonConnect.Click += new System.EventHandler(this.buttonConnect_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.labelErrorCodes);
            this.groupBox2.Controls.Add(this.buttonJogPlus);
            this.groupBox2.Controls.Add(this.buttonJogMinus);
            this.groupBox2.Controls.Add(this.labelOverride);
            this.groupBox2.Controls.Add(this.buttonOvrPlus);
            this.groupBox2.Controls.Add(this.buttonOvrMinus);
            this.groupBox2.Controls.Add(this.comboBoxJoints);
            this.groupBox2.Controls.Add(this.labelJointsCurrent);
            this.groupBox2.Controls.Add(this.labelJointsSetPoint);
            this.groupBox2.Location = new System.Drawing.Point(234, 18);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBox2.Size = new System.Drawing.Size(483, 386);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Joint Motion";
            // 
            // labelErrorCodes
            // 
            this.labelErrorCodes.AutoSize = true;
            this.labelErrorCodes.Location = new System.Drawing.Point(10, 126);
            this.labelErrorCodes.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelErrorCodes.Name = "labelErrorCodes";
            this.labelErrorCodes.Size = new System.Drawing.Size(162, 20);
            this.labelErrorCodes.TabIndex = 8;
            this.labelErrorCodes.Text = "Joint Error Codes: n/a";
            // 
            // buttonJogPlus
            // 
            this.buttonJogPlus.Location = new System.Drawing.Point(285, 277);
            this.buttonJogPlus.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.buttonJogPlus.Name = "buttonJogPlus";
            this.buttonJogPlus.Size = new System.Drawing.Size(159, 83);
            this.buttonJogPlus.TabIndex = 7;
            this.buttonJogPlus.Text = "Jog Plus";
            this.buttonJogPlus.UseVisualStyleBackColor = true;
            this.buttonJogPlus.MouseDown += new System.Windows.Forms.MouseEventHandler(this.buttonJog_MouseDown);
            this.buttonJogPlus.MouseUp += new System.Windows.Forms.MouseEventHandler(this.buttonJog_MouseUp);
            // 
            // buttonJogMinus
            // 
            this.buttonJogMinus.Location = new System.Drawing.Point(68, 277);
            this.buttonJogMinus.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.buttonJogMinus.Name = "buttonJogMinus";
            this.buttonJogMinus.Size = new System.Drawing.Size(168, 83);
            this.buttonJogMinus.TabIndex = 6;
            this.buttonJogMinus.Text = "Jog Minus";
            this.buttonJogMinus.UseVisualStyleBackColor = true;
            this.buttonJogMinus.MouseDown += new System.Windows.Forms.MouseEventHandler(this.buttonJog_MouseDown);
            this.buttonJogMinus.MouseUp += new System.Windows.Forms.MouseEventHandler(this.buttonJog_MouseUp);
            // 
            // labelOverride
            // 
            this.labelOverride.AutoSize = true;
            this.labelOverride.Location = new System.Drawing.Point(300, 217);
            this.labelOverride.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelOverride.Name = "labelOverride";
            this.labelOverride.Size = new System.Drawing.Size(41, 20);
            this.labelOverride.TabIndex = 5;
            this.labelOverride.Text = "30%";
            // 
            // buttonOvrPlus
            // 
            this.buttonOvrPlus.Location = new System.Drawing.Point(350, 200);
            this.buttonOvrPlus.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.buttonOvrPlus.Name = "buttonOvrPlus";
            this.buttonOvrPlus.Size = new System.Drawing.Size(112, 54);
            this.buttonOvrPlus.TabIndex = 4;
            this.buttonOvrPlus.Text = "Override Plus";
            this.buttonOvrPlus.UseVisualStyleBackColor = true;
            this.buttonOvrPlus.Click += new System.EventHandler(this.buttonOvrPlus_Click);
            // 
            // buttonOvrMinus
            // 
            this.buttonOvrMinus.Location = new System.Drawing.Point(165, 200);
            this.buttonOvrMinus.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.buttonOvrMinus.Name = "buttonOvrMinus";
            this.buttonOvrMinus.Size = new System.Drawing.Size(112, 54);
            this.buttonOvrMinus.TabIndex = 3;
            this.buttonOvrMinus.Text = "Override Minus";
            this.buttonOvrMinus.UseVisualStyleBackColor = true;
            this.buttonOvrMinus.Click += new System.EventHandler(this.buttonOvrMinus_Click);
            // 
            // comboBoxJoints
            // 
            this.comboBoxJoints.FormattingEnabled = true;
            this.comboBoxJoints.Items.AddRange(new object[] {
            "Joint 1",
            "Joint 2",
            "Joint 3",
            "Joint 4",
            "Joint 5",
            "Joint 6"});
            this.comboBoxJoints.Location = new System.Drawing.Point(15, 212);
            this.comboBoxJoints.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.comboBoxJoints.Name = "comboBoxJoints";
            this.comboBoxJoints.Size = new System.Drawing.Size(115, 28);
            this.comboBoxJoints.TabIndex = 2;
            this.comboBoxJoints.Text = "Joint 1";
            this.comboBoxJoints.SelectedIndexChanged += new System.EventHandler(this.comboBoxJoints_SelectedIndexChanged);
            // 
            // labelJointsCurrent
            // 
            this.labelJointsCurrent.AutoSize = true;
            this.labelJointsCurrent.Location = new System.Drawing.Point(10, 86);
            this.labelJointsCurrent.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelJointsCurrent.Name = "labelJointsCurrent";
            this.labelJointsCurrent.Size = new System.Drawing.Size(138, 20);
            this.labelJointsCurrent.TabIndex = 1;
            this.labelJointsCurrent.Text = "Joints Current: n/a";
            // 
            // labelJointsSetPoint
            // 
            this.labelJointsSetPoint.AutoSize = true;
            this.labelJointsSetPoint.Location = new System.Drawing.Point(10, 45);
            this.labelJointsSetPoint.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelJointsSetPoint.Name = "labelJointsSetPoint";
            this.labelJointsSetPoint.Size = new System.Drawing.Size(146, 20);
            this.labelJointsSetPoint.TabIndex = 0;
            this.labelJointsSetPoint.Text = "Joints SetPoint: n/a";
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.checkBoxOutTCP2);
            this.groupBox3.Controls.Add(this.checkBoxOutTCP1);
            this.groupBox3.Controls.Add(this.checkBoxOutBase4);
            this.groupBox3.Controls.Add(this.checkBoxOutBase3);
            this.groupBox3.Controls.Add(this.checkBoxOutBase2);
            this.groupBox3.Controls.Add(this.checkBoxOutBase1);
            this.groupBox3.Location = new System.Drawing.Point(726, 26);
            this.groupBox3.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBox3.Size = new System.Drawing.Size(300, 183);
            this.groupBox3.TabIndex = 2;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Digital Out";
            // 
            // checkBoxOutTCP2
            // 
            this.checkBoxOutTCP2.AutoSize = true;
            this.checkBoxOutTCP2.Location = new System.Drawing.Point(174, 72);
            this.checkBoxOutTCP2.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.checkBoxOutTCP2.Name = "checkBoxOutTCP2";
            this.checkBoxOutTCP2.Size = new System.Drawing.Size(78, 24);
            this.checkBoxOutTCP2.TabIndex = 1;
            this.checkBoxOutTCP2.Text = "TCP 2";
            this.checkBoxOutTCP2.UseVisualStyleBackColor = true;
            this.checkBoxOutTCP2.CheckedChanged += new System.EventHandler(this.checkBoxOut_CheckedChanged);
            // 
            // checkBoxOutTCP1
            // 
            this.checkBoxOutTCP1.AutoSize = true;
            this.checkBoxOutTCP1.Location = new System.Drawing.Point(174, 37);
            this.checkBoxOutTCP1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.checkBoxOutTCP1.Name = "checkBoxOutTCP1";
            this.checkBoxOutTCP1.Size = new System.Drawing.Size(78, 24);
            this.checkBoxOutTCP1.TabIndex = 1;
            this.checkBoxOutTCP1.Text = "TCP 1";
            this.checkBoxOutTCP1.UseVisualStyleBackColor = true;
            this.checkBoxOutTCP1.CheckedChanged += new System.EventHandler(this.checkBoxOut_CheckedChanged);
            // 
            // checkBoxOutBase4
            // 
            this.checkBoxOutBase4.AutoSize = true;
            this.checkBoxOutBase4.Location = new System.Drawing.Point(27, 143);
            this.checkBoxOutBase4.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.checkBoxOutBase4.Name = "checkBoxOutBase4";
            this.checkBoxOutBase4.Size = new System.Drawing.Size(85, 24);
            this.checkBoxOutBase4.TabIndex = 0;
            this.checkBoxOutBase4.Text = "Base 4";
            this.checkBoxOutBase4.UseVisualStyleBackColor = true;
            this.checkBoxOutBase4.CheckedChanged += new System.EventHandler(this.checkBoxOut_CheckedChanged);
            // 
            // checkBoxOutBase3
            // 
            this.checkBoxOutBase3.AutoSize = true;
            this.checkBoxOutBase3.Location = new System.Drawing.Point(27, 108);
            this.checkBoxOutBase3.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.checkBoxOutBase3.Name = "checkBoxOutBase3";
            this.checkBoxOutBase3.Size = new System.Drawing.Size(85, 24);
            this.checkBoxOutBase3.TabIndex = 0;
            this.checkBoxOutBase3.Text = "Base 3";
            this.checkBoxOutBase3.UseVisualStyleBackColor = true;
            this.checkBoxOutBase3.CheckedChanged += new System.EventHandler(this.checkBoxOut_CheckedChanged);
            // 
            // checkBoxOutBase2
            // 
            this.checkBoxOutBase2.AutoSize = true;
            this.checkBoxOutBase2.Location = new System.Drawing.Point(27, 72);
            this.checkBoxOutBase2.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.checkBoxOutBase2.Name = "checkBoxOutBase2";
            this.checkBoxOutBase2.Size = new System.Drawing.Size(85, 24);
            this.checkBoxOutBase2.TabIndex = 0;
            this.checkBoxOutBase2.Text = "Base 2";
            this.checkBoxOutBase2.UseVisualStyleBackColor = true;
            this.checkBoxOutBase2.CheckedChanged += new System.EventHandler(this.checkBoxOut_CheckedChanged);
            // 
            // checkBoxOutBase1
            // 
            this.checkBoxOutBase1.AutoSize = true;
            this.checkBoxOutBase1.Location = new System.Drawing.Point(27, 37);
            this.checkBoxOutBase1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.checkBoxOutBase1.Name = "checkBoxOutBase1";
            this.checkBoxOutBase1.Size = new System.Drawing.Size(85, 24);
            this.checkBoxOutBase1.TabIndex = 0;
            this.checkBoxOutBase1.Text = "Base 1";
            this.checkBoxOutBase1.UseVisualStyleBackColor = true;
            this.checkBoxOutBase1.CheckedChanged += new System.EventHandler(this.checkBoxOut_CheckedChanged);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.checkBoxInBase4);
            this.groupBox4.Controls.Add(this.checkBoxInBase3);
            this.groupBox4.Controls.Add(this.checkBoxInBase2);
            this.groupBox4.Controls.Add(this.checkBoxInBase1);
            this.groupBox4.Location = new System.Drawing.Point(726, 218);
            this.groupBox4.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBox4.Size = new System.Drawing.Size(300, 186);
            this.groupBox4.TabIndex = 3;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Digital In";
            // 
            // checkBoxInBase4
            // 
            this.checkBoxInBase4.AutoCheck = false;
            this.checkBoxInBase4.AutoSize = true;
            this.checkBoxInBase4.Location = new System.Drawing.Point(27, 148);
            this.checkBoxInBase4.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.checkBoxInBase4.Name = "checkBoxInBase4";
            this.checkBoxInBase4.Size = new System.Drawing.Size(85, 24);
            this.checkBoxInBase4.TabIndex = 1;
            this.checkBoxInBase4.Text = "Base 4";
            this.checkBoxInBase4.UseVisualStyleBackColor = true;
            // 
            // checkBoxInBase3
            // 
            this.checkBoxInBase3.AutoCheck = false;
            this.checkBoxInBase3.AutoSize = true;
            this.checkBoxInBase3.Location = new System.Drawing.Point(27, 112);
            this.checkBoxInBase3.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.checkBoxInBase3.Name = "checkBoxInBase3";
            this.checkBoxInBase3.Size = new System.Drawing.Size(85, 24);
            this.checkBoxInBase3.TabIndex = 2;
            this.checkBoxInBase3.Text = "Base 3";
            this.checkBoxInBase3.UseVisualStyleBackColor = true;
            // 
            // checkBoxInBase2
            // 
            this.checkBoxInBase2.AutoCheck = false;
            this.checkBoxInBase2.AutoSize = true;
            this.checkBoxInBase2.Location = new System.Drawing.Point(27, 77);
            this.checkBoxInBase2.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.checkBoxInBase2.Name = "checkBoxInBase2";
            this.checkBoxInBase2.Size = new System.Drawing.Size(85, 24);
            this.checkBoxInBase2.TabIndex = 3;
            this.checkBoxInBase2.Text = "Base 2";
            this.checkBoxInBase2.UseVisualStyleBackColor = true;
            // 
            // checkBoxInBase1
            // 
            this.checkBoxInBase1.AutoCheck = false;
            this.checkBoxInBase1.AutoSize = true;
            this.checkBoxInBase1.Location = new System.Drawing.Point(27, 42);
            this.checkBoxInBase1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.checkBoxInBase1.Name = "checkBoxInBase1";
            this.checkBoxInBase1.Size = new System.Drawing.Size(85, 24);
            this.checkBoxInBase1.TabIndex = 4;
            this.checkBoxInBase1.Text = "Base 1";
            this.checkBoxInBase1.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1064, 496);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "Form1";
            this.Text = "CPR Mover Demo";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label labelStatus;
        private System.Windows.Forms.Button buttonSetJointsToZero;
        private System.Windows.Forms.Button buttonEnable;
        private System.Windows.Forms.Button buttonReset;
        private System.Windows.Forms.Button buttonConnect;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button buttonJogPlus;
        private System.Windows.Forms.Button buttonJogMinus;
        private System.Windows.Forms.Label labelOverride;
        private System.Windows.Forms.Button buttonOvrPlus;
        private System.Windows.Forms.Button buttonOvrMinus;
        private System.Windows.Forms.ComboBox comboBoxJoints;
        private System.Windows.Forms.Label labelJointsCurrent;
        private System.Windows.Forms.Label labelJointsSetPoint;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label labelErrorCodes;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.CheckBox checkBoxOutTCP2;
        private System.Windows.Forms.CheckBox checkBoxOutTCP1;
        private System.Windows.Forms.CheckBox checkBoxOutBase4;
        private System.Windows.Forms.CheckBox checkBoxOutBase3;
        private System.Windows.Forms.CheckBox checkBoxOutBase2;
        private System.Windows.Forms.CheckBox checkBoxOutBase1;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.CheckBox checkBoxInBase4;
        private System.Windows.Forms.CheckBox checkBoxInBase3;
        private System.Windows.Forms.CheckBox checkBoxInBase2;
        private System.Windows.Forms.CheckBox checkBoxInBase1;
    }
}

