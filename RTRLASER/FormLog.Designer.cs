
namespace RTRLASER
{
    partial class FormLog
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
            this.dataGridView_log_display = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_log_display)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView_log_display
            // 
            this.dataGridView_log_display.AllowUserToAddRows = false;
            this.dataGridView_log_display.BackgroundColor = System.Drawing.Color.Silver;
            this.dataGridView_log_display.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Sunken;
            this.dataGridView_log_display.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Sunken;
            this.dataGridView_log_display.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dataGridView_log_display.GridColor = System.Drawing.Color.White;
            this.dataGridView_log_display.Location = new System.Drawing.Point(10, 10);
            this.dataGridView_log_display.Name = "dataGridView_log_display";
            this.dataGridView_log_display.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Sunken;
            this.dataGridView_log_display.RowHeadersVisible = false;
            this.dataGridView_log_display.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dataGridView_log_display.RowTemplate.Height = 23;
            this.dataGridView_log_display.Size = new System.Drawing.Size(1895, 875);
            this.dataGridView_log_display.TabIndex = 0;
            this.dataGridView_log_display.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dataGridView_log_display_CellFormatting);
            // 
            // FormLog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1915, 895);
            this.Controls.Add(this.dataGridView_log_display);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FormLog";
            this.Text = "FormLog";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_log_display)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView_log_display;
    }
}