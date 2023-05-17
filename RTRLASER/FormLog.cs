using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.IO;

namespace RTRLASER
{
    public partial class FormLog : Form
    {
        FormMain mainForm;


        public string strPath;
        public string[] strLogDate;
        public string[] strLogFrom;
        public string[] strLogTo;

        public FormLog(FormMain parent)
        {
            MdiParent = mainForm = parent;

            InitializeComponent();

            datagridview_Init();

            string DirPath = Environment.CurrentDirectory + @"\Log";
            string FilePath = DirPath + "\\Log_" + DateTime.Today.ToString("yyMMdd") + ".log";

            DirectoryInfo di = new DirectoryInfo(DirPath);
            FileInfo fi = new FileInfo(FilePath);

            try
            {
                if (!di.Exists) Directory.CreateDirectory(DirPath);
                if (!fi.Exists)
                {
                    foreach (var item in di.GetFiles())
                    {
                        strPath = item.Name;
                    }
                }
                else
                {
                    strPath = FilePath;
                }
            }
            catch (Exception e)
            {

            }

            strLogDate = new string[24];

            for (int i = 0; i < 24; i++)
            {
                strLogDate[i] = i.ToString();
            }

            ReadLogData(strPath);

        }

        public void LoadLogData()
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "모든 파일 (*.*) | *.*";
            ofd.InitialDirectory = "D:\\";

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                datagridview_Init();
                strPath = ofd.FileName;
                ReadLogData(ofd.FileName);
            }
        }

        private void button_log_load_Click(object sender, EventArgs e)
        {
            LoadLogData();
        }

        public void ReadLogData(string logFile)
        {
            string logName = logFile.Substring(logFile.Length - 14, 14);
            mainForm.ribbonTextBox_log_data_name.TextBoxText = logName;

            string[] textValue = System.IO.File.ReadAllLines(logFile);

            if (textValue.Length > 0)
            {
                for (int i = 0; i < textValue.Length; i++)
                {

                    string[] phoneNumberSplit = textValue[i].Split(new string[] { "," }, StringSplitOptions.None);

                    string strTime = phoneNumberSplit[0];

                    string strHour = strTime.Substring(14, 4);
                    string index = ":";

                    int IndexValue = strHour.IndexOf(index);

                    if (phoneNumberSplit[1] == " [Normal]" && mainForm.ribbonCheckBox_log_setting_1.Checked == true)//toggleButton_log_type_unknown.Checked == true)
                        dataGridView_log_display.Rows.Add(i, phoneNumberSplit[0], phoneNumberSplit[1], phoneNumberSplit[2], phoneNumberSplit[3], phoneNumberSplit[4]);

                    if (phoneNumberSplit[1] == " [Setting]" && mainForm.ribbonCheckBox_log_setting_2.Checked == true)
                        dataGridView_log_display.Rows.Add(i, phoneNumberSplit[0], phoneNumberSplit[1], phoneNumberSplit[2], phoneNumberSplit[3], phoneNumberSplit[4]);

                    if (phoneNumberSplit[1] == " [Debug]" && mainForm.ribbonCheckBox_log_setting_3.Checked == true)
                        dataGridView_log_display.Rows.Add(i, phoneNumberSplit[0], phoneNumberSplit[1], phoneNumberSplit[2], phoneNumberSplit[3], phoneNumberSplit[4]);

                    if (phoneNumberSplit[1] == " [Alarm]" && mainForm.ribbonCheckBox_log_setting_4.Checked == true)
                        dataGridView_log_display.Rows.Add(i, phoneNumberSplit[0], phoneNumberSplit[1], phoneNumberSplit[2], phoneNumberSplit[3], phoneNumberSplit[4]);

                    if (phoneNumberSplit[1] == " [Warning]" && mainForm.ribbonCheckBox_log_setting_5.Checked == true)
                        dataGridView_log_display.Rows.Add(i, phoneNumberSplit[0], phoneNumberSplit[1], phoneNumberSplit[2], phoneNumberSplit[3], phoneNumberSplit[4]);

                    if (phoneNumberSplit[1] == " [System]" && mainForm.ribbonCheckBox_log_setting_6.Checked == true)
                        dataGridView_log_display.Rows.Add(i, phoneNumberSplit[0], phoneNumberSplit[1], phoneNumberSplit[2], phoneNumberSplit[3], phoneNumberSplit[4]);

                    if (phoneNumberSplit[1] == " [Process]" && mainForm.ribbonCheckBox_log_setting_7.Checked == true)
                        dataGridView_log_display.Rows.Add(i, phoneNumberSplit[0], phoneNumberSplit[1], phoneNumberSplit[2], phoneNumberSplit[3], phoneNumberSplit[4]);

                    if (phoneNumberSplit[1] == " [TactTime]" && mainForm.ribbonCheckBox_log_setting_8.Checked == true)
                        dataGridView_log_display.Rows.Add(i, phoneNumberSplit[0], phoneNumberSplit[1], phoneNumberSplit[2], phoneNumberSplit[3], phoneNumberSplit[4]);

                    if (phoneNumberSplit[1] == " [User]" && mainForm.ribbonCheckBox_log_setting_9.Checked == true)
                        dataGridView_log_display.Rows.Add(i, phoneNumberSplit[0], phoneNumberSplit[1], phoneNumberSplit[2], phoneNumberSplit[3], phoneNumberSplit[4]);

                    if (phoneNumberSplit[1] == " [Vision]" && mainForm.ribbonCheckBox_log_setting_10.Checked == true)
                        dataGridView_log_display.Rows.Add(i, phoneNumberSplit[0], phoneNumberSplit[1], phoneNumberSplit[2], phoneNumberSplit[3], phoneNumberSplit[4]);

                    if (phoneNumberSplit[1] == " [Field Correction]" && mainForm.ribbonCheckBox_log_setting_11.Checked == true)
                        dataGridView_log_display.Rows.Add(i, phoneNumberSplit[0], phoneNumberSplit[1], phoneNumberSplit[2], phoneNumberSplit[3], phoneNumberSplit[4]);

                    if (phoneNumberSplit[1] == " [Network]" && mainForm.ribbonCheckBox_log_setting_12.Checked == true)
                        dataGridView_log_display.Rows.Add(i, phoneNumberSplit[0], phoneNumberSplit[1], phoneNumberSplit[2], phoneNumberSplit[3], phoneNumberSplit[4]);

                }
            }
        }

        public void datagridview_Init()
        {
            dataGridView_log_display.CancelEdit();
            dataGridView_log_display.Columns.Clear();
            dataGridView_log_display.DataSource = null;

            dataGridView_log_display.Columns.Add("NO", "No");
            dataGridView_log_display.Columns.Add("DATE", "시간");
            dataGridView_log_display.Columns.Add("TYPE", "유형");
            dataGridView_log_display.Columns.Add("MESSAGE", "메시지");
            dataGridView_log_display.Columns.Add("CONTENTS", "내용");
            dataGridView_log_display.Columns.Add("REMARK", "비고");

            dataGridView_log_display.Columns[0].Width = 60;
            dataGridView_log_display.Columns[1].Width = 300;
            dataGridView_log_display.Columns[2].Width = 300;
            dataGridView_log_display.Columns[3].Width = 300;
            dataGridView_log_display.Columns[4].Width = 633;
            dataGridView_log_display.Columns[5].Width = 300;
        }

        private void dataGridView_log_display_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dataGridView_log_display.Rows[e.RowIndex].Cells[2].Value == null)
                return;

            if (dataGridView_log_display.Rows[e.RowIndex].Cells[2].Value.ToString() == " [Normal]")
                e.CellStyle.ForeColor = Color.Blue;

            if (dataGridView_log_display.Rows[e.RowIndex].Cells[2].Value.ToString() == " [Error]")
                e.CellStyle.ForeColor = Color.Red;
        }
    }
}
