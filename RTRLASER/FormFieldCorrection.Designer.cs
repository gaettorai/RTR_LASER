
namespace RTRLASER
{
    partial class FormFieldCorrection
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle21 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle22 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle23 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle24 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle25 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle26 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle27 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle28 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle29 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle30 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel_fc = new System.Windows.Forms.Panel();
            this.pictureBox_fc = new System.Windows.Forms.PictureBox();
            this.panel_fc_setting = new System.Windows.Forms.Panel();
            this.label_fc_result_y = new System.Windows.Forms.Label();
            this.label_fc_result_x = new System.Windows.Forms.Label();
            this.button_fc_result_save = new System.Windows.Forms.Button();
            this.dataGridView_fc_result_y = new System.Windows.Forms.DataGridView();
            this.dataGridView_fc_result_x = new System.Windows.Forms.DataGridView();
            this.panel_fc_mark = new System.Windows.Forms.Panel();
            this.textBox_fc_mark_matchrate = new System.Windows.Forms.TextBox();
            this.label_fc_mark_matchrate = new System.Windows.Forms.Label();
            this.button_fc_mark_cancel = new System.Windows.Forms.Button();
            this.button_fc_mark_apply = new System.Windows.Forms.Button();
            this.button_fc_mark_reg = new System.Windows.Forms.Button();
            this.pictureBox_fc_mark = new System.Windows.Forms.PictureBox();
            this.panel_fc.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_fc)).BeginInit();
            this.panel_fc_setting.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_fc_result_y)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_fc_result_x)).BeginInit();
            this.panel_fc_mark.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_fc_mark)).BeginInit();
            this.SuspendLayout();
            // 
            // panel_fc
            // 
            this.panel_fc.AutoScroll = true;
            this.panel_fc.BackColor = System.Drawing.Color.Black;
            this.panel_fc.Controls.Add(this.pictureBox_fc);
            this.panel_fc.Location = new System.Drawing.Point(5, 5);
            this.panel_fc.Name = "panel_fc";
            this.panel_fc.Size = new System.Drawing.Size(1680, 880);
            this.panel_fc.TabIndex = 0;
            // 
            // pictureBox_fc
            // 
            this.pictureBox_fc.BackColor = System.Drawing.Color.DarkGray;
            this.pictureBox_fc.Location = new System.Drawing.Point(3, 3);
            this.pictureBox_fc.Name = "pictureBox_fc";
            this.pictureBox_fc.Size = new System.Drawing.Size(2448, 2048);
            this.pictureBox_fc.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox_fc.TabIndex = 0;
            this.pictureBox_fc.TabStop = false;
            this.pictureBox_fc.Paint += new System.Windows.Forms.PaintEventHandler(this.pictureBox_fc_Paint);
            this.pictureBox_fc.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pictureBox_fc_MouseDown);
            this.pictureBox_fc.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pictureBox_fc_MouseMove);
            this.pictureBox_fc.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pictureBox_fc_MouseUp);
            // 
            // panel_fc_setting
            // 
            this.panel_fc_setting.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel_fc_setting.Controls.Add(this.label_fc_result_y);
            this.panel_fc_setting.Controls.Add(this.label_fc_result_x);
            this.panel_fc_setting.Controls.Add(this.button_fc_result_save);
            this.panel_fc_setting.Controls.Add(this.dataGridView_fc_result_y);
            this.panel_fc_setting.Controls.Add(this.dataGridView_fc_result_x);
            this.panel_fc_setting.Location = new System.Drawing.Point(1700, 200);
            this.panel_fc_setting.Name = "panel_fc_setting";
            this.panel_fc_setting.Size = new System.Drawing.Size(205, 500);
            this.panel_fc_setting.TabIndex = 2;
            // 
            // label_fc_result_y
            // 
            this.label_fc_result_y.AutoSize = true;
            this.label_fc_result_y.Font = new System.Drawing.Font("굴림", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_fc_result_y.ForeColor = System.Drawing.Color.DodgerBlue;
            this.label_fc_result_y.Location = new System.Drawing.Point(10, 240);
            this.label_fc_result_y.Name = "label_fc_result_y";
            this.label_fc_result_y.Size = new System.Drawing.Size(111, 11);
            this.label_fc_result_y.TabIndex = 31;
            this.label_fc_result_y.Text = "RESULT (Y axis)";
            // 
            // label_fc_result_x
            // 
            this.label_fc_result_x.AutoSize = true;
            this.label_fc_result_x.Font = new System.Drawing.Font("굴림", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_fc_result_x.ForeColor = System.Drawing.Color.DodgerBlue;
            this.label_fc_result_x.Location = new System.Drawing.Point(10, 15);
            this.label_fc_result_x.Name = "label_fc_result_x";
            this.label_fc_result_x.Size = new System.Drawing.Size(111, 11);
            this.label_fc_result_x.TabIndex = 30;
            this.label_fc_result_x.Text = "RESULT (X axis)";
            // 
            // button_fc_result_save
            // 
            this.button_fc_result_save.Enabled = false;
            this.button_fc_result_save.Font = new System.Drawing.Font("굴림", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_fc_result_save.ForeColor = System.Drawing.Color.DodgerBlue;
            this.button_fc_result_save.Location = new System.Drawing.Point(115, 455);
            this.button_fc_result_save.Name = "button_fc_result_save";
            this.button_fc_result_save.Size = new System.Drawing.Size(75, 30);
            this.button_fc_result_save.TabIndex = 29;
            this.button_fc_result_save.Text = "저장";
            this.button_fc_result_save.UseVisualStyleBackColor = false;
            this.button_fc_result_save.Click += new System.EventHandler(this.button_fc_result_save_Click);
            // 
            // dataGridView_fc_result_y
            // 
            this.dataGridView_fc_result_y.AllowUserToAddRows = false;
            dataGridViewCellStyle21.Font = new System.Drawing.Font("Arial", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dataGridView_fc_result_y.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle21;
            this.dataGridView_fc_result_y.BackgroundColor = System.Drawing.Color.White;
            this.dataGridView_fc_result_y.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dataGridView_fc_result_y.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Sunken;
            this.dataGridView_fc_result_y.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Sunken;
            dataGridViewCellStyle22.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle22.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle22.Font = new System.Drawing.Font("Arial", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle22.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle22.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle22.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle22.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView_fc_result_y.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle22;
            this.dataGridView_fc_result_y.ColumnHeadersHeight = 30;
            this.dataGridView_fc_result_y.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dataGridViewCellStyle23.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle23.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle23.Font = new System.Drawing.Font("Arial", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle23.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle23.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle23.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle23.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridView_fc_result_y.DefaultCellStyle = dataGridViewCellStyle23;
            this.dataGridView_fc_result_y.GridColor = System.Drawing.Color.White;
            this.dataGridView_fc_result_y.Location = new System.Drawing.Point(10, 265);
            this.dataGridView_fc_result_y.Name = "dataGridView_fc_result_y";
            this.dataGridView_fc_result_y.ReadOnly = true;
            this.dataGridView_fc_result_y.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Sunken;
            dataGridViewCellStyle24.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle24.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle24.Font = new System.Drawing.Font("Arial", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle24.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle24.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle24.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle24.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView_fc_result_y.RowHeadersDefaultCellStyle = dataGridViewCellStyle24;
            this.dataGridView_fc_result_y.RowHeadersVisible = false;
            this.dataGridView_fc_result_y.RowHeadersWidth = 30;
            this.dataGridView_fc_result_y.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            dataGridViewCellStyle25.Font = new System.Drawing.Font("Arial", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dataGridView_fc_result_y.RowsDefaultCellStyle = dataGridViewCellStyle25;
            this.dataGridView_fc_result_y.Size = new System.Drawing.Size(180, 180);
            this.dataGridView_fc_result_y.TabIndex = 22;
            // 
            // dataGridView_fc_result_x
            // 
            this.dataGridView_fc_result_x.AllowUserToAddRows = false;
            dataGridViewCellStyle26.Font = new System.Drawing.Font("Arial", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dataGridView_fc_result_x.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle26;
            this.dataGridView_fc_result_x.BackgroundColor = System.Drawing.Color.White;
            this.dataGridView_fc_result_x.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dataGridView_fc_result_x.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Sunken;
            this.dataGridView_fc_result_x.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Sunken;
            dataGridViewCellStyle27.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle27.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle27.Font = new System.Drawing.Font("Arial", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle27.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle27.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle27.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle27.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView_fc_result_x.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle27;
            this.dataGridView_fc_result_x.ColumnHeadersHeight = 30;
            this.dataGridView_fc_result_x.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dataGridViewCellStyle28.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle28.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle28.Font = new System.Drawing.Font("Arial", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle28.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle28.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle28.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle28.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridView_fc_result_x.DefaultCellStyle = dataGridViewCellStyle28;
            this.dataGridView_fc_result_x.GridColor = System.Drawing.Color.White;
            this.dataGridView_fc_result_x.Location = new System.Drawing.Point(10, 40);
            this.dataGridView_fc_result_x.Name = "dataGridView_fc_result_x";
            this.dataGridView_fc_result_x.ReadOnly = true;
            this.dataGridView_fc_result_x.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Sunken;
            dataGridViewCellStyle29.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle29.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle29.Font = new System.Drawing.Font("Arial", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle29.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle29.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle29.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle29.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView_fc_result_x.RowHeadersDefaultCellStyle = dataGridViewCellStyle29;
            this.dataGridView_fc_result_x.RowHeadersVisible = false;
            this.dataGridView_fc_result_x.RowHeadersWidth = 30;
            this.dataGridView_fc_result_x.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            dataGridViewCellStyle30.Font = new System.Drawing.Font("Arial", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dataGridView_fc_result_x.RowsDefaultCellStyle = dataGridViewCellStyle30;
            this.dataGridView_fc_result_x.Size = new System.Drawing.Size(180, 180);
            this.dataGridView_fc_result_x.TabIndex = 20;
            // 
            // panel_fc_mark
            // 
            this.panel_fc_mark.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel_fc_mark.Controls.Add(this.textBox_fc_mark_matchrate);
            this.panel_fc_mark.Controls.Add(this.label_fc_mark_matchrate);
            this.panel_fc_mark.Controls.Add(this.button_fc_mark_cancel);
            this.panel_fc_mark.Controls.Add(this.button_fc_mark_apply);
            this.panel_fc_mark.Controls.Add(this.button_fc_mark_reg);
            this.panel_fc_mark.Controls.Add(this.pictureBox_fc_mark);
            this.panel_fc_mark.Location = new System.Drawing.Point(1700, 10);
            this.panel_fc_mark.Name = "panel_fc_mark";
            this.panel_fc_mark.Size = new System.Drawing.Size(205, 175);
            this.panel_fc_mark.TabIndex = 53;
            // 
            // textBox_fc_mark_matchrate
            // 
            this.textBox_fc_mark_matchrate.Location = new System.Drawing.Point(135, 145);
            this.textBox_fc_mark_matchrate.Name = "textBox_fc_mark_matchrate";
            this.textBox_fc_mark_matchrate.Size = new System.Drawing.Size(60, 20);
            this.textBox_fc_mark_matchrate.TabIndex = 19;
            this.textBox_fc_mark_matchrate.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textBox_fc_mark_matchrate.TextChanged += new System.EventHandler(this.textBox_fc_mark_matchrate_TextChanged);
            // 
            // label_fc_mark_matchrate
            // 
            this.label_fc_mark_matchrate.AutoSize = true;
            this.label_fc_mark_matchrate.Font = new System.Drawing.Font("굴림", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_fc_mark_matchrate.ForeColor = System.Drawing.Color.DodgerBlue;
            this.label_fc_mark_matchrate.Location = new System.Drawing.Point(10, 145);
            this.label_fc_mark_matchrate.Name = "label_fc_mark_matchrate";
            this.label_fc_mark_matchrate.Size = new System.Drawing.Size(62, 11);
            this.label_fc_mark_matchrate.TabIndex = 18;
            this.label_fc_mark_matchrate.Text = "매칭율(%)";
            // 
            // button_fc_mark_cancel
            // 
            this.button_fc_mark_cancel.Font = new System.Drawing.Font("굴림", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_fc_mark_cancel.ForeColor = System.Drawing.Color.DodgerBlue;
            this.button_fc_mark_cancel.Location = new System.Drawing.Point(120, 70);
            this.button_fc_mark_cancel.Name = "button_fc_mark_cancel";
            this.button_fc_mark_cancel.Size = new System.Drawing.Size(75, 25);
            this.button_fc_mark_cancel.TabIndex = 4;
            this.button_fc_mark_cancel.Text = "취소";
            this.button_fc_mark_cancel.UseVisualStyleBackColor = false;
            this.button_fc_mark_cancel.Click += new System.EventHandler(this.button_fc_mark_cancel_Click);
            // 
            // button_fc_mark_apply
            // 
            this.button_fc_mark_apply.Font = new System.Drawing.Font("굴림", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_fc_mark_apply.ForeColor = System.Drawing.Color.DodgerBlue;
            this.button_fc_mark_apply.Location = new System.Drawing.Point(120, 40);
            this.button_fc_mark_apply.Name = "button_fc_mark_apply";
            this.button_fc_mark_apply.Size = new System.Drawing.Size(75, 25);
            this.button_fc_mark_apply.TabIndex = 3;
            this.button_fc_mark_apply.Text = "적용";
            this.button_fc_mark_apply.UseVisualStyleBackColor = false;
            this.button_fc_mark_apply.Click += new System.EventHandler(this.button_fc_mark_apply_Click);
            // 
            // button_fc_mark_reg
            // 
            this.button_fc_mark_reg.Font = new System.Drawing.Font("굴림", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_fc_mark_reg.ForeColor = System.Drawing.Color.DodgerBlue;
            this.button_fc_mark_reg.Location = new System.Drawing.Point(120, 10);
            this.button_fc_mark_reg.Name = "button_fc_mark_reg";
            this.button_fc_mark_reg.Size = new System.Drawing.Size(75, 25);
            this.button_fc_mark_reg.TabIndex = 1;
            this.button_fc_mark_reg.Text = "등록";
            this.button_fc_mark_reg.UseVisualStyleBackColor = false;
            this.button_fc_mark_reg.Click += new System.EventHandler(this.button_fc_mark_reg_Click);
            // 
            // pictureBox_fc_mark
            // 
            this.pictureBox_fc_mark.BackColor = System.Drawing.Color.Black;
            this.pictureBox_fc_mark.Location = new System.Drawing.Point(10, 10);
            this.pictureBox_fc_mark.Name = "pictureBox_fc_mark";
            this.pictureBox_fc_mark.Size = new System.Drawing.Size(100, 100);
            this.pictureBox_fc_mark.TabIndex = 0;
            this.pictureBox_fc_mark.TabStop = false;
            // 
            // FormFieldCorrection
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1915, 895);
            this.Controls.Add(this.panel_fc_mark);
            this.Controls.Add(this.panel_fc_setting);
            this.Controls.Add(this.panel_fc);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FormFieldCorrection";
            this.Text = "FormFieldCorrection";
            this.panel_fc.ResumeLayout(false);
            this.panel_fc.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_fc)).EndInit();
            this.panel_fc_setting.ResumeLayout(false);
            this.panel_fc_setting.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_fc_result_y)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_fc_result_x)).EndInit();
            this.panel_fc_mark.ResumeLayout(false);
            this.panel_fc_mark.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_fc_mark)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel_fc;
        private System.Windows.Forms.Panel panel_fc_setting;
        private System.Windows.Forms.DataGridView dataGridView_fc_result_x;
        private System.Windows.Forms.Label label_fc_result_y;
        private System.Windows.Forms.Label label_fc_result_x;
        private System.Windows.Forms.DataGridView dataGridView_fc_result_y;
        public System.Windows.Forms.PictureBox pictureBox_fc;
        private System.Windows.Forms.Panel panel_fc_mark;
        private System.Windows.Forms.TextBox textBox_fc_mark_matchrate;
        private System.Windows.Forms.Label label_fc_mark_matchrate;
        private System.Windows.Forms.Button button_fc_mark_cancel;
        private System.Windows.Forms.Button button_fc_mark_apply;
        private System.Windows.Forms.Button button_fc_mark_reg;
        private System.Windows.Forms.PictureBox pictureBox_fc_mark;
        public System.Windows.Forms.Button button_fc_result_save;
    }
}