using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RTRLASER
{
    public partial class FormRecipeSelect : Form
    {

        public string[] strRecipeName = new string[100];
        public int nSelectRecipe;
        public FormRecipeSelect()
        {
            InitializeComponent();
        }

        private void button_select_recipe_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            nSelectRecipe = comboBox_select_recipe.SelectedIndex;
            this.Close();
        }

        private void button_cancel_recipe_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        public void LoadRecipeName()
        {
            for (int i = 0; i < 100; i++)
            {
                //strRecipeName = mainForm.dlgVision.DisplayRecipeName(i);
                comboBox_select_recipe.Items.Add(strRecipeName[i]);
            }
        }

        public void SelectedRecipe(int nRecipe)
        {
            comboBox_select_recipe.SelectedIndex = nRecipe - 1;
        }
    }
}
