
namespace RTRLASER
{
    partial class FormVision
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
            this.panel_vision_focus = new System.Windows.Forms.Panel();
            this.pictureBox_vision_focus = new System.Windows.Forms.PictureBox();
            this.panel_vision_measurement = new System.Windows.Forms.Panel();
            this.dataGridView_measurement = new System.Windows.Forms.DataGridView();
            this.button_vision_measurement_mode = new System.Windows.Forms.Button();
            this.button_vision_measurement_control5 = new System.Windows.Forms.Button();
            this.button_vision_measurement_control4 = new System.Windows.Forms.Button();
            this.button_vision_measurement_control3 = new System.Windows.Forms.Button();
            this.button_vision_measurement_control2 = new System.Windows.Forms.Button();
            this.button_vision_measurement_control1 = new System.Windows.Forms.Button();
            this.panel_vision_mark = new System.Windows.Forms.Panel();
            this.textBox_vision_mark_matchrate = new System.Windows.Forms.TextBox();
            this.label_vision_mark_matchrate = new System.Windows.Forms.Label();
            this.button_vision_mark_cancel = new System.Windows.Forms.Button();
            this.button_vision_mark_apply = new System.Windows.Forms.Button();
            this.button_vision_mark_reg = new System.Windows.Forms.Button();
            this.pictureBox_vision_mark = new System.Windows.Forms.PictureBox();
            this.panel_vision_focus.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_vision_focus)).BeginInit();
            this.panel_vision_measurement.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_measurement)).BeginInit();
            this.panel_vision_mark.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_vision_mark)).BeginInit();
            this.SuspendLayout();
            // 
            // panel_vision_focus
            // 
            this.panel_vision_focus.AutoScroll = true;
            this.panel_vision_focus.BackColor = System.Drawing.Color.Black;
            this.panel_vision_focus.Controls.Add(this.pictureBox_vision_focus);
            this.panel_vision_focus.Location = new System.Drawing.Point(5, 5);
            this.panel_vision_focus.Name = "panel_vision_focus";
            this.panel_vision_focus.Size = new System.Drawing.Size(1680, 880);
            this.panel_vision_focus.TabIndex = 3;
            // 
            // pictureBox_vision_focus
            // 
            this.pictureBox_vision_focus.BackColor = System.Drawing.Color.DarkGray;
            this.pictureBox_vision_focus.Location = new System.Drawing.Point(3, 3);
            this.pictureBox_vision_focus.Name = "pictureBox_vision_focus";
            this.pictureBox_vision_focus.Size = new System.Drawing.Size(2448, 2048);
            this.pictureBox_vision_focus.TabIndex = 0;
            this.pictureBox_vision_focus.TabStop = false;
            this.pictureBox_vision_focus.Paint += new System.Windows.Forms.PaintEventHandler(this.pictureBox_vision_focus_Paint);
            this.pictureBox_vision_focus.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pictureBox_vision_focus_MouseDown);
            this.pictureBox_vision_focus.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pictureBox_vision_focus_MouseMove);
            this.pictureBox_vision_focus.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pictureBox_vision_focus_MouseUp);
            // 
            // panel_vision_measurement
            // 
            this.panel_vision_measurement.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel_vision_measurement.Controls.Add(this.dataGridView_measurement);
            this.panel_vision_measurement.Location = new System.Drawing.Point(1700, 470);
            this.panel_vision_measurement.Name = "panel_vision_measurement";
            this.panel_vision_measurement.Size = new System.Drawing.Size(205, 415);
            this.panel_vision_measurement.TabIndex = 88;
            // 
            // dataGridView_measurement
            // 
            this.dataGridView_measurement.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_measurement.Location = new System.Drawing.Point(5, 5);
            this.dataGridView_measurement.Name = "dataGridView_measurement";
            this.dataGridView_measurement.Size = new System.Drawing.Size(190, 400);
            this.dataGridView_measurement.TabIndex = 0;
            // 
            // button_vision_measurement_mode
            // 
            this.button_vision_measurement_mode.Font = new System.Drawing.Font("굴림", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_vision_measurement_mode.ForeColor = System.Drawing.Color.DodgerBlue;
            this.button_vision_measurement_mode.Location = new System.Drawing.Point(1865, 253);
            this.button_vision_measurement_mode.Name = "button_vision_measurement_mode";
            this.button_vision_measurement_mode.Size = new System.Drawing.Size(30, 30);
            this.button_vision_measurement_mode.TabIndex = 94;
            this.button_vision_measurement_mode.Text = "MODE";
            this.button_vision_measurement_mode.UseVisualStyleBackColor = false;
            this.button_vision_measurement_mode.Click += new System.EventHandler(this.button_vision_measurement_mode_Click);
            // 
            // button_vision_measurement_control5
            // 
            this.button_vision_measurement_control5.Font = new System.Drawing.Font("굴림", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_vision_measurement_control5.ForeColor = System.Drawing.Color.DodgerBlue;
            this.button_vision_measurement_control5.Location = new System.Drawing.Point(1865, 433);
            this.button_vision_measurement_control5.Name = "button_vision_measurement_control5";
            this.button_vision_measurement_control5.Size = new System.Drawing.Size(30, 30);
            this.button_vision_measurement_control5.TabIndex = 93;
            this.button_vision_measurement_control5.Text = "M5";
            this.button_vision_measurement_control5.UseVisualStyleBackColor = false;
            this.button_vision_measurement_control5.Click += new System.EventHandler(this.button_vision_measurement_control5_Click);
            // 
            // button_vision_measurement_control4
            // 
            this.button_vision_measurement_control4.Font = new System.Drawing.Font("굴림", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_vision_measurement_control4.ForeColor = System.Drawing.Color.DodgerBlue;
            this.button_vision_measurement_control4.Location = new System.Drawing.Point(1865, 397);
            this.button_vision_measurement_control4.Name = "button_vision_measurement_control4";
            this.button_vision_measurement_control4.Size = new System.Drawing.Size(30, 30);
            this.button_vision_measurement_control4.TabIndex = 92;
            this.button_vision_measurement_control4.Text = "M4";
            this.button_vision_measurement_control4.UseVisualStyleBackColor = false;
            this.button_vision_measurement_control4.Click += new System.EventHandler(this.button_vision_measurement_control4_Click);
            // 
            // button_vision_measurement_control3
            // 
            this.button_vision_measurement_control3.Font = new System.Drawing.Font("굴림", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_vision_measurement_control3.ForeColor = System.Drawing.Color.DodgerBlue;
            this.button_vision_measurement_control3.Location = new System.Drawing.Point(1865, 361);
            this.button_vision_measurement_control3.Name = "button_vision_measurement_control3";
            this.button_vision_measurement_control3.Size = new System.Drawing.Size(30, 30);
            this.button_vision_measurement_control3.TabIndex = 91;
            this.button_vision_measurement_control3.Text = "M3";
            this.button_vision_measurement_control3.UseVisualStyleBackColor = false;
            this.button_vision_measurement_control3.Click += new System.EventHandler(this.button_vision_measurement_control3_Click);
            // 
            // button_vision_measurement_control2
            // 
            this.button_vision_measurement_control2.Font = new System.Drawing.Font("굴림", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_vision_measurement_control2.ForeColor = System.Drawing.Color.DodgerBlue;
            this.button_vision_measurement_control2.Location = new System.Drawing.Point(1865, 325);
            this.button_vision_measurement_control2.Name = "button_vision_measurement_control2";
            this.button_vision_measurement_control2.Size = new System.Drawing.Size(30, 30);
            this.button_vision_measurement_control2.TabIndex = 90;
            this.button_vision_measurement_control2.Text = "M2";
            this.button_vision_measurement_control2.UseVisualStyleBackColor = false;
            this.button_vision_measurement_control2.Click += new System.EventHandler(this.button_vision_measurement_control2_Click);
            // 
            // button_vision_measurement_control1
            // 
            this.button_vision_measurement_control1.Font = new System.Drawing.Font("굴림", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_vision_measurement_control1.ForeColor = System.Drawing.Color.DodgerBlue;
            this.button_vision_measurement_control1.Location = new System.Drawing.Point(1865, 289);
            this.button_vision_measurement_control1.Name = "button_vision_measurement_control1";
            this.button_vision_measurement_control1.Size = new System.Drawing.Size(30, 30);
            this.button_vision_measurement_control1.TabIndex = 89;
            this.button_vision_measurement_control1.Text = "M1";
            this.button_vision_measurement_control1.UseVisualStyleBackColor = false;
            this.button_vision_measurement_control1.Click += new System.EventHandler(this.button_vision_measurement_control1_Click);
            // 
            // panel_vision_mark
            // 
            this.panel_vision_mark.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel_vision_mark.Controls.Add(this.textBox_vision_mark_matchrate);
            this.panel_vision_mark.Controls.Add(this.label_vision_mark_matchrate);
            this.panel_vision_mark.Controls.Add(this.button_vision_mark_cancel);
            this.panel_vision_mark.Controls.Add(this.button_vision_mark_apply);
            this.panel_vision_mark.Controls.Add(this.button_vision_mark_reg);
            this.panel_vision_mark.Controls.Add(this.pictureBox_vision_mark);
            this.panel_vision_mark.Location = new System.Drawing.Point(1700, 10);
            this.panel_vision_mark.Name = "panel_vision_mark";
            this.panel_vision_mark.Size = new System.Drawing.Size(205, 180);
            this.panel_vision_mark.TabIndex = 53;
            // 
            // textBox_vision_mark_matchrate
            // 
            this.textBox_vision_mark_matchrate.Location = new System.Drawing.Point(135, 140);
            this.textBox_vision_mark_matchrate.Name = "textBox_vision_mark_matchrate";
            this.textBox_vision_mark_matchrate.Size = new System.Drawing.Size(60, 20);
            this.textBox_vision_mark_matchrate.TabIndex = 19;
            this.textBox_vision_mark_matchrate.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textBox_vision_mark_matchrate.TextChanged += new System.EventHandler(this.textBox_vision_mark_matchrate_TextChanged);
            // 
            // label_vision_mark_matchrate
            // 
            this.label_vision_mark_matchrate.AutoSize = true;
            this.label_vision_mark_matchrate.Font = new System.Drawing.Font("굴림", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_vision_mark_matchrate.ForeColor = System.Drawing.Color.DodgerBlue;
            this.label_vision_mark_matchrate.Location = new System.Drawing.Point(10, 145);
            this.label_vision_mark_matchrate.Name = "label_vision_mark_matchrate";
            this.label_vision_mark_matchrate.Size = new System.Drawing.Size(62, 11);
            this.label_vision_mark_matchrate.TabIndex = 18;
            this.label_vision_mark_matchrate.Text = "매칭율(%)";
            // 
            // button_vision_mark_cancel
            // 
            this.button_vision_mark_cancel.Font = new System.Drawing.Font("굴림", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_vision_mark_cancel.ForeColor = System.Drawing.Color.DodgerBlue;
            this.button_vision_mark_cancel.Location = new System.Drawing.Point(120, 70);
            this.button_vision_mark_cancel.Name = "button_vision_mark_cancel";
            this.button_vision_mark_cancel.Size = new System.Drawing.Size(75, 25);
            this.button_vision_mark_cancel.TabIndex = 4;
            this.button_vision_mark_cancel.Text = "취소";
            this.button_vision_mark_cancel.UseVisualStyleBackColor = false;
            this.button_vision_mark_cancel.Click += new System.EventHandler(this.button_vision_mark_cancel_Click);
            // 
            // button_vision_mark_apply
            // 
            this.button_vision_mark_apply.Font = new System.Drawing.Font("굴림", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_vision_mark_apply.ForeColor = System.Drawing.Color.DodgerBlue;
            this.button_vision_mark_apply.Location = new System.Drawing.Point(120, 40);
            this.button_vision_mark_apply.Name = "button_vision_mark_apply";
            this.button_vision_mark_apply.Size = new System.Drawing.Size(75, 25);
            this.button_vision_mark_apply.TabIndex = 3;
            this.button_vision_mark_apply.Text = "적용";
            this.button_vision_mark_apply.UseVisualStyleBackColor = false;
            this.button_vision_mark_apply.Click += new System.EventHandler(this.button_vision_mark_apply_Click);
            // 
            // button_vision_mark_reg
            // 
            this.button_vision_mark_reg.Font = new System.Drawing.Font("굴림", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_vision_mark_reg.ForeColor = System.Drawing.Color.DodgerBlue;
            this.button_vision_mark_reg.Location = new System.Drawing.Point(120, 10);
            this.button_vision_mark_reg.Name = "button_vision_mark_reg";
            this.button_vision_mark_reg.Size = new System.Drawing.Size(75, 25);
            this.button_vision_mark_reg.TabIndex = 1;
            this.button_vision_mark_reg.Text = "등록";
            this.button_vision_mark_reg.UseVisualStyleBackColor = false;
            this.button_vision_mark_reg.Click += new System.EventHandler(this.button_vision_mark_reg_Click);
            // 
            // pictureBox_vision_mark
            // 
            this.pictureBox_vision_mark.BackColor = System.Drawing.Color.Black;
            this.pictureBox_vision_mark.Location = new System.Drawing.Point(10, 10);
            this.pictureBox_vision_mark.Name = "pictureBox_vision_mark";
            this.pictureBox_vision_mark.Size = new System.Drawing.Size(100, 100);
            this.pictureBox_vision_mark.TabIndex = 0;
            this.pictureBox_vision_mark.TabStop = false;
            // 
            // FormVision
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1915, 895);
            this.Controls.Add(this.panel_vision_mark);
            this.Controls.Add(this.button_vision_measurement_mode);
            this.Controls.Add(this.button_vision_measurement_control5);
            this.Controls.Add(this.button_vision_measurement_control4);
            this.Controls.Add(this.button_vision_measurement_control3);
            this.Controls.Add(this.button_vision_measurement_control2);
            this.Controls.Add(this.button_vision_measurement_control1);
            this.Controls.Add(this.panel_vision_measurement);
            this.Controls.Add(this.panel_vision_focus);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FormVision";
            this.panel_vision_focus.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_vision_focus)).EndInit();
            this.panel_vision_measurement.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_measurement)).EndInit();
            this.panel_vision_mark.ResumeLayout(false);
            this.panel_vision_mark.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_vision_mark)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel panel_vision_focus;
        private System.Windows.Forms.Panel panel_vision_measurement;
        private System.Windows.Forms.DataGridView dataGridView_measurement;
        private System.Windows.Forms.Button button_vision_measurement_mode;
        private System.Windows.Forms.Button button_vision_measurement_control5;
        private System.Windows.Forms.Button button_vision_measurement_control4;
        private System.Windows.Forms.Button button_vision_measurement_control3;
        private System.Windows.Forms.Button button_vision_measurement_control2;
        private System.Windows.Forms.Button button_vision_measurement_control1;
        private System.Windows.Forms.Panel panel_vision_mark;
        private System.Windows.Forms.TextBox textBox_vision_mark_matchrate;
        private System.Windows.Forms.Label label_vision_mark_matchrate;
        private System.Windows.Forms.Button button_vision_mark_cancel;
        private System.Windows.Forms.Button button_vision_mark_apply;
        private System.Windows.Forms.Button button_vision_mark_reg;
        private System.Windows.Forms.PictureBox pictureBox_vision_mark;
        public System.Windows.Forms.PictureBox pictureBox_vision_focus;
    }
}