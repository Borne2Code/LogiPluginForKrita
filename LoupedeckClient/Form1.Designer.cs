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
            tabControl1 = new TabControl();
            tabPage1 = new TabPage();
            BurnExposurePlus = new Button();
            BurnExposureMinus = new Button();
            tabPage2 = new TabPage();
            BlurCbShape = new ComboBox();
            label6 = new Label();
            label5 = new Label();
            label4 = new Label();
            label3 = new Label();
            label2 = new Label();
            BlurSliderAngle = new TrackBar();
            sliderBlurStrength = new TrackBar();
            bBlurActivate = new Button();
            sliderBlurVerRadius = new TrackBar();
            sliderBlurHorRadius = new TrackBar();
            tabPage3 = new TabPage();
            ColorBalanceActivate = new Button();
            label7 = new Label();
            ColorBalanceCyanRedShadows = new TrackBar();
            ((System.ComponentModel.ISupportInitialize)trackBar1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)trackBar2).BeginInit();
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)trackBar3).BeginInit();
            tabControl1.SuspendLayout();
            tabPage1.SuspendLayout();
            tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)BlurSliderAngle).BeginInit();
            ((System.ComponentModel.ISupportInitialize)sliderBlurStrength).BeginInit();
            ((System.ComponentModel.ISupportInitialize)sliderBlurVerRadius).BeginInit();
            ((System.ComponentModel.ISupportInitialize)sliderBlurHorRadius).BeginInit();
            tabPage3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)ColorBalanceCyanRedShadows).BeginInit();
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
            ActionList.Size = new Size(316, 464);
            ActionList.TabIndex = 4;
            // 
            // TriggerAction
            // 
            TriggerAction.Location = new Point(12, 728);
            TriggerAction.Name = "TriggerAction";
            TriggerAction.Size = new Size(94, 29);
            TriggerAction.TabIndex = 5;
            TriggerAction.Text = "Run";
            TriggerAction.UseVisualStyleBackColor = true;
            TriggerAction.Click += TriggerAction_Click;
            // 
            // button5
            // 
            button5.Location = new Point(6, 6);
            button5.Name = "button5";
            button5.Size = new Size(94, 29);
            button5.TabIndex = 6;
            button5.Text = "Open";
            button5.UseVisualStyleBackColor = true;
            button5.Click += button5_Click;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(radioButton3);
            groupBox1.Controls.Add(radioButton2);
            groupBox1.Controls.Add(radioButton1);
            groupBox1.Location = new Point(6, 41);
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
            trackBar3.Location = new Point(6, 166);
            trackBar3.Maximum = 100;
            trackBar3.Name = "trackBar3";
            trackBar3.Size = new Size(378, 56);
            trackBar3.TabIndex = 8;
            trackBar3.ValueChanged += trackBar3_ValueChanged;
            // 
            // tabControl1
            // 
            tabControl1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            tabControl1.Controls.Add(tabPage1);
            tabControl1.Controls.Add(tabPage2);
            tabControl1.Controls.Add(tabPage3);
            tabControl1.Location = new Point(334, 214);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(778, 543);
            tabControl1.TabIndex = 9;
            // 
            // tabPage1
            // 
            tabPage1.Controls.Add(BurnExposurePlus);
            tabPage1.Controls.Add(BurnExposureMinus);
            tabPage1.Controls.Add(button5);
            tabPage1.Controls.Add(trackBar3);
            tabPage1.Controls.Add(groupBox1);
            tabPage1.Location = new Point(4, 32);
            tabPage1.Name = "tabPage1";
            tabPage1.Padding = new Padding(3);
            tabPage1.Size = new Size(770, 507);
            tabPage1.TabIndex = 0;
            tabPage1.Text = "Burn...";
            tabPage1.UseVisualStyleBackColor = true;
            // 
            // BurnExposurePlus
            // 
            BurnExposurePlus.Location = new Point(511, 182);
            BurnExposurePlus.Name = "BurnExposurePlus";
            BurnExposurePlus.Size = new Size(94, 29);
            BurnExposurePlus.TabIndex = 10;
            BurnExposurePlus.Text = "+";
            BurnExposurePlus.UseVisualStyleBackColor = true;
            BurnExposurePlus.Click += BurnExposureplus_Click;
            // 
            // BurnExposureMinus
            // 
            BurnExposureMinus.Location = new Point(409, 178);
            BurnExposureMinus.Name = "BurnExposureMinus";
            BurnExposureMinus.Size = new Size(94, 29);
            BurnExposureMinus.TabIndex = 9;
            BurnExposureMinus.Text = "-";
            BurnExposureMinus.UseVisualStyleBackColor = true;
            BurnExposureMinus.Click += BurnExposureMinus_Click;
            // 
            // tabPage2
            // 
            tabPage2.Controls.Add(BlurCbShape);
            tabPage2.Controls.Add(label6);
            tabPage2.Controls.Add(label5);
            tabPage2.Controls.Add(label4);
            tabPage2.Controls.Add(label3);
            tabPage2.Controls.Add(label2);
            tabPage2.Controls.Add(BlurSliderAngle);
            tabPage2.Controls.Add(sliderBlurStrength);
            tabPage2.Controls.Add(bBlurActivate);
            tabPage2.Controls.Add(sliderBlurVerRadius);
            tabPage2.Controls.Add(sliderBlurHorRadius);
            tabPage2.Location = new Point(4, 32);
            tabPage2.Name = "tabPage2";
            tabPage2.Padding = new Padding(3);
            tabPage2.Size = new Size(770, 507);
            tabPage2.TabIndex = 1;
            tabPage2.Text = "Blur";
            tabPage2.UseVisualStyleBackColor = true;
            // 
            // BlurCbShape
            // 
            BlurCbShape.FormattingEnabled = true;
            BlurCbShape.Items.AddRange(new object[] { "Circle", "Rectangle" });
            BlurCbShape.Location = new Point(3, 391);
            BlurCbShape.Name = "BlurCbShape";
            BlurCbShape.Size = new Size(151, 31);
            BlurCbShape.TabIndex = 3;
            BlurCbShape.SelectedIndexChanged += BlurCbShape_SelectedIndexChanged;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(-4, 365);
            label6.Name = "label6";
            label6.Size = new Size(57, 23);
            label6.TabIndex = 2;
            label6.Text = "Shape";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(3, 289);
            label5.Name = "label5";
            label5.Size = new Size(54, 23);
            label5.TabIndex = 2;
            label5.Text = "Angle";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(6, 213);
            label4.Name = "label4";
            label4.Size = new Size(75, 23);
            label4.TabIndex = 2;
            label4.Text = "Strength";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(9, 127);
            label3.Name = "label3";
            label3.Size = new Size(90, 23);
            label3.TabIndex = 2;
            label3.Text = "Ver Radius";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(6, 41);
            label2.Name = "label2";
            label2.Size = new Size(93, 23);
            label2.TabIndex = 2;
            label2.Text = "Hor Radius";
            // 
            // BlurSliderAngle
            // 
            BlurSliderAngle.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            BlurSliderAngle.Location = new Point(0, 316);
            BlurSliderAngle.Maximum = 360;
            BlurSliderAngle.Name = "BlurSliderAngle";
            BlurSliderAngle.Size = new Size(758, 56);
            BlurSliderAngle.TabIndex = 0;
            BlurSliderAngle.ValueChanged += BlurSliderAngle_ValueChanged;
            // 
            // sliderBlurStrength
            // 
            sliderBlurStrength.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            sliderBlurStrength.Location = new Point(3, 240);
            sliderBlurStrength.Maximum = 100;
            sliderBlurStrength.Name = "sliderBlurStrength";
            sliderBlurStrength.Size = new Size(758, 56);
            sliderBlurStrength.TabIndex = 0;
            sliderBlurStrength.ValueChanged += sliderBlurStrength_ValueChanged;
            // 
            // bBlurActivate
            // 
            bBlurActivate.Location = new Point(6, 6);
            bBlurActivate.Name = "bBlurActivate";
            bBlurActivate.Size = new Size(94, 29);
            bBlurActivate.TabIndex = 1;
            bBlurActivate.Text = "Activate";
            bBlurActivate.UseVisualStyleBackColor = true;
            bBlurActivate.Click += bBlurActivate_Click;
            // 
            // sliderBlurVerRadius
            // 
            sliderBlurVerRadius.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            sliderBlurVerRadius.Location = new Point(6, 154);
            sliderBlurVerRadius.Maximum = 100;
            sliderBlurVerRadius.Name = "sliderBlurVerRadius";
            sliderBlurVerRadius.Size = new Size(758, 56);
            sliderBlurVerRadius.TabIndex = 0;
            sliderBlurVerRadius.ValueChanged += sliderBlurVerRadius_ValueChanged;
            // 
            // sliderBlurHorRadius
            // 
            sliderBlurHorRadius.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            sliderBlurHorRadius.Location = new Point(3, 68);
            sliderBlurHorRadius.Maximum = 100;
            sliderBlurHorRadius.Name = "sliderBlurHorRadius";
            sliderBlurHorRadius.Size = new Size(758, 56);
            sliderBlurHorRadius.TabIndex = 0;
            sliderBlurHorRadius.ValueChanged += sliderBlurHorRadius_ValueChanged;
            // 
            // tabPage3
            // 
            tabPage3.Controls.Add(ColorBalanceActivate);
            tabPage3.Controls.Add(label7);
            tabPage3.Controls.Add(ColorBalanceCyanRedShadows);
            tabPage3.Location = new Point(4, 32);
            tabPage3.Name = "tabPage3";
            tabPage3.Padding = new Padding(3);
            tabPage3.Size = new Size(770, 507);
            tabPage3.TabIndex = 2;
            tabPage3.Text = "ColorBalance";
            tabPage3.UseVisualStyleBackColor = true;
            // 
            // ColorBalanceActivate
            // 
            ColorBalanceActivate.Location = new Point(16, 10);
            ColorBalanceActivate.Name = "ColorBalanceActivate";
            ColorBalanceActivate.Size = new Size(94, 29);
            ColorBalanceActivate.TabIndex = 2;
            ColorBalanceActivate.Text = "Activate";
            ColorBalanceActivate.UseVisualStyleBackColor = true;
            ColorBalanceActivate.Click += ColorBalanceActivate_Click;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(12, 43);
            label7.Name = "label7";
            label7.Size = new Size(156, 23);
            label7.TabIndex = 1;
            label7.Text = "Shadows Cyan/Red";
            // 
            // ColorBalanceCyanRedShadows
            // 
            ColorBalanceCyanRedShadows.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            ColorBalanceCyanRedShadows.Location = new Point(8, 66);
            ColorBalanceCyanRedShadows.Maximum = 100;
            ColorBalanceCyanRedShadows.Minimum = -100;
            ColorBalanceCyanRedShadows.Name = "ColorBalanceCyanRedShadows";
            ColorBalanceCyanRedShadows.Size = new Size(742, 56);
            ColorBalanceCyanRedShadows.TabIndex = 0;
            ColorBalanceCyanRedShadows.ValueChanged += ColorBalanceCyanRedShadows_ValueChanged;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(9F, 23F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1124, 769);
            Controls.Add(tabControl1);
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
            tabControl1.ResumeLayout(false);
            tabPage1.ResumeLayout(false);
            tabPage1.PerformLayout();
            tabPage2.ResumeLayout(false);
            tabPage2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)BlurSliderAngle).EndInit();
            ((System.ComponentModel.ISupportInitialize)sliderBlurStrength).EndInit();
            ((System.ComponentModel.ISupportInitialize)sliderBlurVerRadius).EndInit();
            ((System.ComponentModel.ISupportInitialize)sliderBlurHorRadius).EndInit();
            tabPage3.ResumeLayout(false);
            tabPage3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)ColorBalanceCyanRedShadows).EndInit();
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
        private TabControl tabControl1;
        private TabPage tabPage1;
        private TabPage tabPage2;
        private Button bBlurActivate;
        private TrackBar sliderBlurHorRadius;
        private Label label4;
        private Label label3;
        private Label label2;
        private TrackBar sliderBlurStrength;
        private TrackBar sliderBlurVerRadius;
        private Label label5;
        private TrackBar BlurSliderAngle;
        private ComboBox BlurCbShape;
        private Label label6;
        private TabPage tabPage3;
        private Label label7;
        private TrackBar ColorBalanceCyanRedShadows;
        private Button ColorBalanceActivate;
        private Button BurnExposurePlus;
        private Button BurnExposureMinus;
    }
}
