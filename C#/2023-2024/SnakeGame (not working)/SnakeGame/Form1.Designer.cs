namespace SnakeGame
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
            components = new System.ComponentModel.Container();
            label1 = new Label();
            pictureBox1 = new PictureBox();
            label2 = new Label();
            label3 = new Label();
            GameTimer = new System.Windows.Forms.Timer(components);
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            label1.ForeColor = SystemColors.ControlLightLight;
            label1.Location = new Point(617, 22);
            label1.Name = "label1";
            label1.Size = new Size(84, 32);
            label1.TabIndex = 0;
            label1.Text = "Score:";
            // 
            // pictureBox1
            // 
            pictureBox1.BackColor = SystemColors.ControlDark;
            pictureBox1.Location = new Point(12, 12);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(541, 560);
            pictureBox1.TabIndex = 1;
            pictureBox1.TabStop = false;
            pictureBox1.Paint += updateGraphics;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            label2.ForeColor = SystemColors.ControlLightLight;
            label2.Location = new Point(707, 22);
            label2.Name = "label2";
            label2.Size = new Size(42, 32);
            label2.TabIndex = 2;
            label2.Text = "00";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.BackColor = SystemColors.Desktop;
            label3.BorderStyle = BorderStyle.FixedSingle;
            label3.FlatStyle = FlatStyle.Flat;
            label3.Font = new Font("Segoe UI", 20F, FontStyle.Bold);
            label3.ForeColor = Color.FromArgb(192, 0, 0);
            label3.Location = new Point(161, 266);
            label3.Name = "label3";
            label3.Size = new Size(230, 48);
            label3.TabIndex = 3;
            label3.Text = "GAME OVER!";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ControlDarkDark;
            ClientSize = new Size(907, 623);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(pictureBox1);
            Controls.Add(label1);
            Name = "Form1";
            Text = "SnakeGame";
            Load += Form1_Load;
            KeyDown += keyisdown;
            KeyUp += keyisup;
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private PictureBox pictureBox1;
        private Label label2;
        private Label label3;
        private System.Windows.Forms.Timer GameTimer;
    }
}
