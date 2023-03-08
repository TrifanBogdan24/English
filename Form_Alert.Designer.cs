namespace English
{
    partial class Form_Alert
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
            this.fundal = new System.Windows.Forms.Panel();
            this.output = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.xulet = new System.Windows.Forms.PictureBox();
            this.icon = new System.Windows.Forms.PictureBox();
            this.fundal.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.xulet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.icon)).BeginInit();
            this.SuspendLayout();
            // 
            // fundal
            // 
            this.fundal.BackColor = System.Drawing.Color.DarkBlue;
            this.fundal.Controls.Add(this.xulet);
            this.fundal.Controls.Add(this.icon);
            this.fundal.Controls.Add(this.output);
            this.fundal.Dock = System.Windows.Forms.DockStyle.Fill;
            this.fundal.Location = new System.Drawing.Point(0, 0);
            this.fundal.Name = "fundal";
            this.fundal.Size = new System.Drawing.Size(475, 90);
            this.fundal.TabIndex = 0;
            this.fundal.Click += new System.EventHandler(this.fundal_Click);
            this.fundal.Paint += new System.Windows.Forms.PaintEventHandler(this.fundal_Paint);
            // 
            // output
            // 
            this.output.Font = new System.Drawing.Font("Century Gothic", 16F);
            this.output.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(233)))), ((int)(((byte)(74)))), ((int)(((byte)(95)))));
            this.output.Location = new System.Drawing.Point(49, 0);
            this.output.Name = "output";
            this.output.Size = new System.Drawing.Size(303, 83);
            this.output.TabIndex = 0;
            this.output.Text = "12 downloaded files";
            this.output.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.output.Click += new System.EventHandler(this.output_Click);
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // xulet
            // 
            this.xulet.Location = new System.Drawing.Point(433, 24);
            this.xulet.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.xulet.Name = "xulet";
            this.xulet.Size = new System.Drawing.Size(43, 40);
            this.xulet.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.xulet.TabIndex = 11;
            this.xulet.TabStop = false;
            this.xulet.Click += new System.EventHandler(this.xulet_Click);
            // 
            // icon
            // 
            this.icon.Location = new System.Drawing.Point(0, 24);
            this.icon.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.icon.Name = "icon";
            this.icon.Size = new System.Drawing.Size(43, 40);
            this.icon.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.icon.TabIndex = 10;
            this.icon.TabStop = false;
            this.icon.Click += new System.EventHandler(this.icon_Click);
            // 
            // Form_Alert
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(475, 90);
            this.Controls.Add(this.fundal);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Form_Alert";
            this.Text = "Form_Alert";
            this.fundal.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.xulet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.icon)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel fundal;
        private System.Windows.Forms.Label output;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.PictureBox xulet;
        private System.Windows.Forms.PictureBox icon;
    }
}