
namespace RTRLASER
{
    partial class FormRecipeSelect
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
            this.comboBox_select_recipe = new System.Windows.Forms.ComboBox();
            this.label_select_recipe = new System.Windows.Forms.Label();
            this.button_select_recipe = new System.Windows.Forms.Button();
            this.button_cancel_recipe = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // comboBox_select_recipe
            // 
            this.comboBox_select_recipe.FormattingEnabled = true;
            this.comboBox_select_recipe.Location = new System.Drawing.Point(90, 15);
            this.comboBox_select_recipe.Name = "comboBox_select_recipe";
            this.comboBox_select_recipe.Size = new System.Drawing.Size(225, 21);
            this.comboBox_select_recipe.TabIndex = 0;
            // 
            // label_select_recipe
            // 
            this.label_select_recipe.AutoSize = true;
            this.label_select_recipe.Font = new System.Drawing.Font("굴림", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_select_recipe.ForeColor = System.Drawing.Color.DodgerBlue;
            this.label_select_recipe.Location = new System.Drawing.Point(20, 20);
            this.label_select_recipe.Name = "label_select_recipe";
            this.label_select_recipe.Size = new System.Drawing.Size(41, 11);
            this.label_select_recipe.TabIndex = 1;
            this.label_select_recipe.Text = "레시피";
            // 
            // button_select_recipe
            // 
            this.button_select_recipe.Font = new System.Drawing.Font("굴림", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_select_recipe.Location = new System.Drawing.Point(150, 50);
            this.button_select_recipe.Name = "button_select_recipe";
            this.button_select_recipe.Size = new System.Drawing.Size(80, 20);
            this.button_select_recipe.TabIndex = 2;
            this.button_select_recipe.Text = "불러오기";
            this.button_select_recipe.UseVisualStyleBackColor = false;
            this.button_select_recipe.Click += new System.EventHandler(this.button_select_recipe_Click);
            // 
            // button_cancel_recipe
            // 
            this.button_cancel_recipe.Font = new System.Drawing.Font("굴림", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_cancel_recipe.Location = new System.Drawing.Point(235, 50);
            this.button_cancel_recipe.Name = "button_cancel_recipe";
            this.button_cancel_recipe.Size = new System.Drawing.Size(80, 20);
            this.button_cancel_recipe.TabIndex = 3;
            this.button_cancel_recipe.Text = "취소";
            this.button_cancel_recipe.UseVisualStyleBackColor = false;
            this.button_cancel_recipe.Click += new System.EventHandler(this.button_cancel_recipe_Click);
            // 
            // FormRecipeSelect
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(334, 81);
            this.Controls.Add(this.button_cancel_recipe);
            this.Controls.Add(this.button_select_recipe);
            this.Controls.Add(this.label_select_recipe);
            this.Controls.Add(this.comboBox_select_recipe);
            this.Name = "FormRecipeSelect";
            this.Text = "레시피 불러오기";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label_select_recipe;
        public System.Windows.Forms.Button button_select_recipe;
        public System.Windows.Forms.Button button_cancel_recipe;
        public System.Windows.Forms.ComboBox comboBox_select_recipe;
    }
}