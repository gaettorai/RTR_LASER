
namespace RTRLASER
{
    partial class FormLaser
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
            this.panel_laser_line = new System.Windows.Forms.Panel();
            this.panel_laser = new System.Windows.Forms.Panel();
            this.panel_laser_line.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel_laser_line
            // 
            this.panel_laser_line.BackColor = System.Drawing.Color.Black;
            this.panel_laser_line.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel_laser_line.Controls.Add(this.panel_laser);
            this.panel_laser_line.Location = new System.Drawing.Point(5, 5);
            this.panel_laser_line.Name = "panel_laser_line";
            this.panel_laser_line.Size = new System.Drawing.Size(1910, 890);
            this.panel_laser_line.TabIndex = 0;
            // 
            // panel_laser
            // 
            this.panel_laser.BackColor = System.Drawing.Color.White;
            this.panel_laser.Location = new System.Drawing.Point(1, 1);
            this.panel_laser.Name = "panel_laser";
            this.panel_laser.Size = new System.Drawing.Size(1902, 882);
            this.panel_laser.TabIndex = 1;
            // 
            // FormLaser
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1915, 895);
            this.Controls.Add(this.panel_laser_line);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FormLaser";
            this.Text = "FormLaser";
            this.panel_laser_line.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel_laser_line;
        public System.Windows.Forms.Panel panel_laser;
    }
}