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
            ((System.ComponentModel.ISupportInitialize)trackBar1).BeginInit();
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
            button1.Click += button1_Click;
            // 
            // button2
            // 
            button2.Location = new Point(12, 109);
            button2.Name = "button2";
            button2.Size = new Size(155, 29);
            button2.TabIndex = 1;
            button2.Text = "get zoom level";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(134, 126);
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
            trackBar1.Minimum = 10;
            trackBar1.Name = "trackBar1";
            trackBar1.Size = new Size(1100, 56);
            trackBar1.SmallChange = 10;
            trackBar1.TabIndex = 3;
            trackBar1.TickFrequency = 100;
            trackBar1.TickStyle = TickStyle.TopLeft;
            trackBar1.Value = 10;
            trackBar1.Scroll += trackBar1_Scroll;
            trackBar1.ValueChanged += trackBar1_ValueChanged;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(9F, 23F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1124, 450);
            Controls.Add(trackBar1);
            Controls.Add(label1);
            Controls.Add(button2);
            Controls.Add(button1);
            Name = "Form1";
            Text = "Form1";
            FormClosing += Form1_FormClosing;
            Load += Form1_Load;
            ((System.ComponentModel.ISupportInitialize)trackBar1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button button1;
        private Button button2;
        private Label label1;
        private TrackBar trackBar1;
    }
}
