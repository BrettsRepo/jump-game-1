namespace juuump
{
    partial class Form1
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
            this.components = new System.ComponentModel.Container();
            this.Heartbeat = new System.Windows.Forms.Timer(this.components);
            this.labelinfo = new System.Windows.Forms.Label();
            this.labelscore = new System.Windows.Forms.Label();
            this.platformRight = new System.Windows.Forms.PictureBox();
            this.player = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.platformRight)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.player)).BeginInit();
            this.SuspendLayout();
            // 
            // Heartbeat
            // 
            this.Heartbeat.Interval = 25;
            this.Heartbeat.Tick += new System.EventHandler(this.Heartbeat_Tick);
            // 
            // labelinfo
            // 
            this.labelinfo.AutoSize = true;
            this.labelinfo.Location = new System.Drawing.Point(12, 9);
            this.labelinfo.Name = "labelinfo";
            this.labelinfo.Size = new System.Drawing.Size(35, 13);
            this.labelinfo.TabIndex = 0;
            this.labelinfo.Text = "label1";
            // 
            // labelscore
            // 
            this.labelscore.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.labelscore.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelscore.Location = new System.Drawing.Point(0, 278);
            this.labelscore.Name = "labelscore";
            this.labelscore.Size = new System.Drawing.Size(55, 26);
            this.labelscore.TabIndex = 3;
            this.labelscore.Text = "0";
            // 
            // platformRight
            // 
            this.platformRight.Image = global::juuump.Properties.Resources.marioCloud2;
            this.platformRight.Location = new System.Drawing.Point(276, 542);
            this.platformRight.Name = "platformRight";
            this.platformRight.Size = new System.Drawing.Size(55, 19);
            this.platformRight.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.platformRight.TabIndex = 2;
            this.platformRight.TabStop = false;
            this.platformRight.Tag = "15";
            // 
            // player
            // 
            this.player.Image = global::juuump.Properties.Resources.mario;
            this.player.InitialImage = global::juuump.Properties.Resources.mario;
            this.player.Location = new System.Drawing.Point(350, 323);
            this.player.Name = "player";
            this.player.Size = new System.Drawing.Size(24, 33);
            this.player.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.player.TabIndex = 1;
            this.player.TabStop = false;
            this.player.Click += new System.EventHandler(this.player_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Aqua;
            this.ClientSize = new System.Drawing.Size(584, 561);
            this.Controls.Add(this.labelscore);
            this.Controls.Add(this.platformRight);
            this.Controls.Add(this.player);
            this.Controls.Add(this.labelinfo);
            this.MaximumSize = new System.Drawing.Size(600, 600);
            this.MinimumSize = new System.Drawing.Size(600, 600);
            this.Name = "Form1";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Form1_KeyPress);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyUp);
            ((System.ComponentModel.ISupportInitialize)(this.platformRight)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.player)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Timer Heartbeat;
        private System.Windows.Forms.Label labelinfo;
        private System.Windows.Forms.PictureBox player;
        private System.Windows.Forms.PictureBox platformRight;
        private System.Windows.Forms.Label labelscore;
    }
}

