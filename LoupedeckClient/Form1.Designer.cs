namespace LoupedeckClient
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            button1 = new Button();
            button2 = new Button();
            label1 = new Label();
            trackBar1 = new TrackBar();
            trackBar2 = new TrackBar();
            button3 = new Button();
            button4 = new Button();
            ActionList = new ListBox();
            TriggerAction = new Button();
            button5 = new Button();
            groupBox1 = new GroupBox();
            radioButton3 = new RadioButton();
            radioButton2 = new RadioButton();
            radioButton1 = new RadioButton();
            trackBar3 = new TrackBar();
            ((System.ComponentModel.ISupportInitialize)trackBar1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)trackBar2).BeginInit();
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)trackBar3).BeginInit();
            SuspendLayout();
            // 
            // button1
            // 
            button1.Location = new Point(12, 74);
            button1.Name = "button1";
            button1.Size = new Size(155, 29);
            button1.TabIndex = 0;
            button1.Text = "Set zoom 1";
            button1.UseVisualStyleBackColor = true;
            button1.Click += Button1_Click;
            // 
            // button2
            // 
            button2.Location = new Point(12, 109);
            button2.Name = "button2";
            button2.Size = new Size(155, 29);
            button2.TabIndex = 1;
            button2.Text = "get zoom level";
            button2.UseVisualStyleBackColor = true;
            button2.Click += Button2_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 330);
            label1.Name = "label1";
            label1.Size = new Size(0, 23);
            label1.TabIndex = 2;
            // 
            // trackBar1
            // 
            trackBar1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            trackBar1.LargeChange = 50;
            trackBar1.Location = new Point(12, 12);
            trackBar1.Maximum = 3000;
            trackBar1.Minimum = 1;
            trackBar1.Name = "trackBar1";
            trackBar1.Size = new Size(1100, 56);
            trackBar1.TabIndex = 3;
            trackBar1.TickFrequency = 100;
            trackBar1.TickStyle = TickStyle.TopLeft;
            trackBar1.Value = 10;
            trackBar1.ValueChanged += TrackBar1_ValueChanged;
            // 
            // trackBar2
            // 
            trackBar2.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            trackBar2.LargeChange = 50;
            trackBar2.Location = new Point(12, 152);
            trackBar2.Maximum = 180;
            trackBar2.Minimum = -180;
            trackBar2.Name = "trackBar2";
            trackBar2.Size = new Size(1100, 56);
            trackBar2.SmallChange = 10;
            trackBar2.TabIndex = 3;
            trackBar2.TickFrequency = 100;
            trackBar2.TickStyle = TickStyle.TopLeft;
            trackBar2.ValueChanged += TrackBar2_ValueChanged;
            // 
            // button3
            // 
            button3.Location = new Point(12, 214);
            button3.Name = "button3";
            button3.Size = new Size(155, 29);
            button3.TabIndex = 1;
            button3.Text = "get rotation";
            button3.UseVisualStyleBackColor = true;
            button3.Click += Button3_Click;
            // 
            // button4
            // 
            button4.Location = new Point(173, 214);
            button4.Name = "button4";
            button4.Size = new Size(155, 29);
            button4.TabIndex = 0;
            button4.Text = "Reset rotation";
            button4.UseVisualStyleBackColor = true;
            button4.Click += Button4_Click;
            // 
            // ActionList
            // 
            ActionList.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            ActionList.FormattingEnabled = true;
            ActionList.Location = new Point(12, 249);
            ActionList.Name = "ActionList";
            ActionList.Size = new Size(316, 188);
            ActionList.TabIndex = 4;
            // 
            // TriggerAction
            // 
            TriggerAction.Location = new Point(334, 249);
            TriggerAction.Name = "TriggerAction";
            TriggerAction.Size = new Size(94, 29);
            TriggerAction.TabIndex = 5;
            TriggerAction.Text = "Run";
            TriggerAction.UseVisualStyleBackColor = true;
            TriggerAction.Click += TriggerAction_Click;
            // 
            // button5
            // 
            button5.Location = new Point(539, 257);
            button5.Name = "button5";
            button5.Size = new Size(94, 29);
            button5.TabIndex = 6;
            button5.Text = "button5";
            button5.UseVisualStyleBackColor = true;
            button5.Click += button5_Click;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(radioButton3);
            groupBox1.Controls.Add(radioButton2);
            groupBox1.Controls.Add(radioButton1);
            groupBox1.Location = new Point(752, 229);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(250, 125);
            groupBox1.TabIndex = 7;
            groupBox1.TabStop = false;
            groupBox1.Text = "groupBox1";
            // 
            // radioButton3
            // 
            radioButton3.AutoSize = true;
            radioButton3.Location = new Point(10, 92);
            radioButton3.Name = "radioButton3";
            radioButton3.Size = new Size(106, 27);
            radioButton3.TabIndex = 0;
            radioButton3.TabStop = true;
            radioButton3.Text = "highlights";
            radioButton3.UseVisualStyleBackColor = true;
            radioButton3.CheckedChanged += radioButton3_CheckedChanged;
            // 
            // radioButton2
            // 
            radioButton2.AutoSize = true;
            radioButton2.Location = new Point(10, 62);
            radioButton2.Name = "radioButton2";
            radioButton2.Size = new Size(60, 27);
            radioButton2.TabIndex = 0;
            radioButton2.TabStop = true;
            radioButton2.Text = "mid";
            radioButton2.UseVisualStyleBackColor = true;
            radioButton2.CheckedChanged += radioButton2_CheckedChanged;
            // 
            // radioButton1
            // 
            radioButton1.AutoSize = true;
            radioButton1.Location = new Point(10, 29);
            radioButton1.Name = "radioButton1";
            radioButton1.Size = new Size(70, 27);
            radioButton1.TabIndex = 0;
            radioButton1.TabStop = true;
            radioButton1.Text = "black";
            radioButton1.UseVisualStyleBackColor = true;
            radioButton1.CheckedChanged += radioButton1_CheckedChanged;
            // 
            // trackBar3
            // 
            trackBar3.Location = new Point(705, 376);
            trackBar3.Maximum = 100;
            trackBar3.Name = "trackBar3";
            trackBar3.Size = new Size(378, 56);
            trackBar3.TabIndex = 8;
            trackBar3.ValueChanged += trackBar3_ValueChanged;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(9F, 23F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1124, 450);
            Controls.Add(trackBar3);
            Controls.Add(groupBox1);
            Controls.Add(button5);
            Controls.Add(TriggerAction);
            Controls.Add(ActionList);
            Controls.Add(trackBar2);
            Controls.Add(trackBar1);
            Controls.Add(label1);
            Controls.Add(button3);
            Controls.Add(button2);
            Controls.Add(button4);
            Controls.Add(button1);
            Name = "Form1";
            Text = "Form1";
            FormClosing += Form1_FormClosing;
            Load += Form1_Load;
            ((System.ComponentModel.ISupportInitialize)trackBar1).EndInit();
            ((System.ComponentModel.ISupportInitialize)trackBar2).EndInit();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)trackBar3).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button button1;
        private Button button2;
        private Label label1;
        private TrackBar trackBar1;
        private TrackBar trackBar2;
        private Button button3;
        private Button button4;
        private ListBox ActionList;
        private Button TriggerAction;
        private Button button5;
        private GroupBox groupBox1;
        private RadioButton radioButton3;
        private RadioButton radioButton2;
        private RadioButton radioButton1;
        private TrackBar trackBar3;
    }
}
