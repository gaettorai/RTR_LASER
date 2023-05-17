using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.IO;

using Microsoft.WindowsAPICodePack.Dialogs;
using OpenCvSharp;
using OpenCvSharp.Extensions;

namespace RTRLASER
{
    public partial class FormFieldCorrection : Form
    {
        FormMain mainForm;

        [DllImport("kernel32")]
        private static extern long WritePrivateProfileString(string section, string key, string val, string filePath);
        [DllImport("kernel32")]
        private static extern int GetPrivateProfileString(string section, string key, string def, StringBuilder retVal, int size, string filePath);

        double dMatchrate = 0.0;
        int nRepeat = 0;

        int nBinary_mark = 0;
        int nMorpOpen_mark = 0;
        int nMorpClose_mark = 0;

        int nBinary_image = 0;
        int nMorpOpen_image = 0;
        int nMorpClose_image = 0;

        public System.Drawing.Point pROIStart;
        public System.Drawing.Point pROIEnd;

        public double dGain = 0.0;
        public double dNewcal = 0.0;
        public int nPoint = 0;
        public double dLength = 0.0;

        public string strOLDCTfile = "";
        public string strNEWCTfile = "";

        public bool bCheckMarkReg = false;
        public Rectangle FCMarkRect;

        public bool bClickCheck = false;
        public bool bClickSizeLeft = false;
        public bool bClickSizeRight = false;
        public bool bClickSizeTop = false;
        public bool bClickSizeBottom = false;
        public bool bClickSizeLeftTop = false;
        public bool bClickSizeLeftBottom = false;
        public bool bClickSizeRightTop = false;
        public bool bClickSizeRightBottom = false;

        public static bool MouseInLeft { get; set; }
        public static bool MouseInRight { get; set; }
        public static bool MouseInTop { get; set; }
        public static bool MouseInBottom { get; set; }

        private System.Drawing.Point startPos;
        private System.Drawing.Point endPos;

        public bool bDetectMark = false;

        public System.Drawing.Point pDetectStart;
        public System.Drawing.Point pDetectEnd;

        public int nMagni = 1;

        public int nFCCount = 0;

        public DataTable dtResultX = new DataTable();
        public DataTable dtResultY = new DataTable();

        public class FCInfo
        {
            public struct stFC
            {
                public double dErrorX;
                public double dErrorY;

                public double dArrayX;
                public double dArrayY;

                public double dMarkingPosX;
                public double dMarkingPosY;

                public double dResultX;
                public double dResultY;
            }
        }

        [System.Runtime.InteropServices.StructLayout(System.Runtime.InteropServices.LayoutKind.Explicit)]

        public class UnionValue
        {
            [System.Runtime.InteropServices.FieldOffset(0)]
            public uint intValue;

            [System.Runtime.InteropServices.FieldOffset(0)]
            public ushort shortValue_low;

            [System.Runtime.InteropServices.FieldOffset(2)]
            public ushort shortValue_high;
        }

        public FCInfo.stFC[] stFC;
        public UnionValue union = new UnionValue();

        public FormFieldCorrection(FormMain parent)
        {
            MdiParent = mainForm = parent;

            InitializeComponent();

            DisplayRecipeName(mainForm.nSelectedRecipe);

            EnableSetting(false);

            LoadConfig();

            FCMarkRect = new Rectangle(0, 0, 100, 100);

            InitDataGrid();
            laserMarkingPosition();
        }

        public void InitDataGrid()
        {
            nFCCount = 0;

            dtResultX.Columns.Add("NUM", typeof(int));
            dtResultX.Columns.Add("0", typeof(string));
            dtResultX.Columns.Add("1", typeof(string));
            dtResultX.Columns.Add("2", typeof(string));
            dtResultX.Columns.Add("3", typeof(string));
            dtResultX.Columns.Add("4", typeof(string));
            dtResultX.Columns.Add("5", typeof(string));
            dtResultX.Columns.Add("6", typeof(string));
            dtResultX.Columns.Add("7", typeof(string));
            dtResultX.Columns.Add("8", typeof(string));
            dtResultX.Columns.Add("9", typeof(string));
            dtResultX.Columns.Add("10", typeof(string));

            dtResultX.Rows.Add(0, "", "", "", "", "", "", "", "", "", "");
            dtResultX.Rows.Add(1, "", "", "", "", "", "", "", "", "", "");
            dtResultX.Rows.Add(2, "", "", "", "", "", "", "", "", "", "");
            dtResultX.Rows.Add(3, "", "", "", "", "", "", "", "", "", "");
            dtResultX.Rows.Add(4, "", "", "", "", "", "", "", "", "", "");
            dtResultX.Rows.Add(5, "", "", "", "", "", "", "", "", "", "");
            dtResultX.Rows.Add(6, "", "", "", "", "", "", "", "", "", "");
            dtResultX.Rows.Add(7, "", "", "", "", "", "", "", "", "", "");
            dtResultX.Rows.Add(8, "", "", "", "", "", "", "", "", "", "");
            dtResultX.Rows.Add(9, "", "", "", "", "", "", "", "", "", "");
            dtResultX.Rows.Add(10, "", "", "", "", "", "", "", "", "", "");

            dataGridView_fc_result_x.DataSource = dtResultX;

            dataGridView_fc_result_x.Columns[0].Width = 40;

            for (int i = 1; i < 12; i++)
            {
                dataGridView_fc_result_x.Columns[i].Width = 40;
            }

            // DATA RESULT Y
            dtResultY.Columns.Add("NUM", typeof(int));
            dtResultY.Columns.Add("0", typeof(string));
            dtResultY.Columns.Add("1", typeof(string));
            dtResultY.Columns.Add("2", typeof(string));
            dtResultY.Columns.Add("3", typeof(string));
            dtResultY.Columns.Add("4", typeof(string));
            dtResultY.Columns.Add("5", typeof(string));
            dtResultY.Columns.Add("6", typeof(string));
            dtResultY.Columns.Add("7", typeof(string));
            dtResultY.Columns.Add("8", typeof(string));
            dtResultY.Columns.Add("9", typeof(string));
            dtResultY.Columns.Add("10", typeof(string));

            dtResultY.Rows.Add(0, "", "", "", "", "", "", "", "", "", "");
            dtResultY.Rows.Add(1, "", "", "", "", "", "", "", "", "", "");
            dtResultY.Rows.Add(2, "", "", "", "", "", "", "", "", "", "");
            dtResultY.Rows.Add(3, "", "", "", "", "", "", "", "", "", "");
            dtResultY.Rows.Add(4, "", "", "", "", "", "", "", "", "", "");
            dtResultY.Rows.Add(5, "", "", "", "", "", "", "", "", "", "");
            dtResultY.Rows.Add(6, "", "", "", "", "", "", "", "", "", "");
            dtResultY.Rows.Add(7, "", "", "", "", "", "", "", "", "", "");
            dtResultY.Rows.Add(8, "", "", "", "", "", "", "", "", "", "");
            dtResultY.Rows.Add(9, "", "", "", "", "", "", "", "", "", "");
            dtResultY.Rows.Add(10, "", "", "", "", "", "", "", "", "", "");

            dataGridView_fc_result_y.DataSource = dtResultY;

            dataGridView_fc_result_y.Columns[0].Width = 40;

            for (int i = 1; i < 12; i++)
            {
                dataGridView_fc_result_y.Columns[i].Width = 40;
            }
        }

        public void laserMarkingPosition()
        {
            stFC = new FCInfo.stFC[nPoint * nPoint];

            for (int i = 0; i < nPoint * nPoint; i++)
            {
                double dXmm;
                double dYmm;

                dXmm = (((i % nPoint) - (nPoint / 2)) * dLength);
                dYmm = (((i / nPoint) - (nPoint / 2)) * dLength);

                int nXBit;
                int nYBit;

                nXBit = (int)(dXmm * dNewcal);
                nYBit = (int)(dYmm * dNewcal);

                stFC[i].dArrayX = dXmm;
                stFC[i].dArrayY = dYmm;

                stFC[i].dMarkingPosX = mainForm.dFCCenterX + dXmm;;
                stFC[i].dMarkingPosY = mainForm.dFCCenterY + dYmm;
            }
        }

        public void LoadConfig()
        {
            StringBuilder strData = new StringBuilder();

            int nRecipe;
            nRecipe = mainForm.nSelectedRecipe;

            String strFile = Application.StartupPath + @"\Config\" + nRecipe.ToString() + @"\FieldCorrectionConfig.ini";
            String strTag = "COMMON";

            GetPrivateProfileString(strTag, "MATCHRATE", "", strData, 32, strFile);
            dMatchrate = Convert.ToDouble(strData.ToString());

            GetPrivateProfileString(strTag, "REPEAT", "", strData, 32, strFile);
            nRepeat = Convert.ToInt16(strData.ToString());

            GetPrivateProfileString(strTag, "ROI START X", "", strData, 32, strFile);
            pROIStart.X = Convert.ToInt32(strData.ToString());

            GetPrivateProfileString(strTag, "ROI START Y", "", strData, 32, strFile);
            pROIStart.Y = Convert.ToInt32(strData.ToString());

            GetPrivateProfileString(strTag, "ROI END X", "", strData, 32, strFile);
            pROIEnd.X = Convert.ToInt32(strData.ToString());

            GetPrivateProfileString(strTag, "ROI END Y", "", strData, 32, strFile);
            pROIEnd.Y = Convert.ToInt32(strData.ToString());

            GetPrivateProfileString(strTag, "GAIN", "", strData, 32, strFile);
            dGain = Convert.ToDouble(strData.ToString());

            GetPrivateProfileString(strTag, "NEWCAL", "", strData, 32, strFile);
            dNewcal = Convert.ToDouble(strData.ToString());

            GetPrivateProfileString(strTag, "POINT", "", strData, 32, strFile);
            nPoint = Convert.ToInt16(strData.ToString());

            GetPrivateProfileString(strTag, "LENGTH", "", strData, 32, strFile);
            dLength = Convert.ToDouble(strData.ToString());

            GetPrivateProfileString(strTag, "OLDCTFILE", "", strData, 64, strFile);
            strOLDCTfile = strData.ToString();

            GetPrivateProfileString(strTag, "NEWCTFILE", "", strData, 64, strFile);
            strNEWCTfile = strData.ToString();

            strTag = "MARK";

            GetPrivateProfileString(strTag, "MORP OPEN", "", strData, 32, strFile);
            nMorpOpen_mark = Convert.ToInt16(strData.ToString());

            GetPrivateProfileString(strTag, "MORP CLOSE", "", strData, 32, strFile);
            nMorpClose_mark = Convert.ToInt16(strData.ToString());

            GetPrivateProfileString(strTag, "BINARY", "", strData, 32, strFile);
            nBinary_mark = Convert.ToInt16(strData.ToString());

            strTag = "IMAGE";

            GetPrivateProfileString(strTag, "MORP OPEN", "", strData, 32, strFile);
            nMorpOpen_image = Convert.ToInt16(strData.ToString());

            GetPrivateProfileString(strTag, "MORP CLOSE", "", strData, 32, strFile);
            nMorpClose_image = Convert.ToInt16(strData.ToString());

            GetPrivateProfileString(strTag, "BINARY", "", strData, 32, strFile);
            nBinary_image = Convert.ToInt16(strData.ToString());
        }

        public void SaveConfig()
        {
            int nRecipe;
            nRecipe = mainForm.nSelectedRecipe;

            String strFile = Application.StartupPath + @"\Config\" + nRecipe.ToString() + @"\FieldCorrectionConfig.ini";

            WritePrivateProfileString("COMMON", "MATCHRATE", dMatchrate.ToString(), strFile);
            WritePrivateProfileString("COMMON", "REPEAT", nRepeat.ToString(), strFile);
            WritePrivateProfileString("COMMON", "ROI START X", pROIStart.X.ToString(), strFile);
            WritePrivateProfileString("COMMON", "ROI START Y", pROIStart.Y.ToString(), strFile);
            WritePrivateProfileString("COMMON", "ROI END X", pROIEnd.X.ToString(), strFile);
            WritePrivateProfileString("COMMON", "ROI END Y", pROIEnd.Y.ToString(), strFile);

            WritePrivateProfileString("COMMON", "GAIN", dGain.ToString(), strFile);
            WritePrivateProfileString("COMMON", "NEWCAL", dNewcal.ToString(), strFile);
            WritePrivateProfileString("COMMON", "POINT", nPoint.ToString(), strFile);
            WritePrivateProfileString("COMMON", "LENGTH", dLength.ToString(), strFile);
            WritePrivateProfileString("COMMON", "OLDCTFILE", strOLDCTfile, strFile);
            WritePrivateProfileString("COMMON", "NEWCTFILE", strNEWCTfile, strFile);

            WritePrivateProfileString("MARK", "MORP OPEN", nMorpOpen_mark.ToString(), strFile);
            WritePrivateProfileString("MARK", "MORP CLOSE", nMorpClose_mark.ToString(), strFile);
            WritePrivateProfileString("MARK", "BINARY", nBinary_mark.ToString(), strFile);

            WritePrivateProfileString("IMAGE", "MORP OPEN", nMorpOpen_image.ToString(), strFile);
            WritePrivateProfileString("IMAGE", "MORP CLOSE", nMorpClose_image.ToString(), strFile);
            WritePrivateProfileString("IMAGE", "BINARY", nBinary_image.ToString(), strFile);
        }

        public void DisplaySetting()
        {
            textBox_fc_mark_matchrate.Text = dMatchrate.ToString();

            mainForm.ribbonTextBox_fc_param_gain.TextBoxText = dGain.ToString();
            mainForm.ribbonTextBox_fc_param_newcal.TextBoxText = dNewcal.ToString();
            mainForm.ribbonTextBox_fc_param_point.TextBoxText = nPoint.ToString();
            mainForm.ribbonTextBox_fc_param_length.TextBoxText = dLength.ToString();

            mainForm.ribbonTextBox_fc_param_oldctfile.TextBoxText = strOLDCTfile;
            mainForm.ribbonTextBox_fc_param_newctfile.TextBoxText = strNEWCTfile;


            int nRecipe;
            nRecipe = mainForm.nSelectedRecipe;

            string DirPath = Application.StartupPath + @"\Config\" + nRecipe.ToString();

            pictureBox_fc_mark.Image = null;
            pictureBox_fc_mark.Update();

            string DirFilePath = DirPath + "\\FC_Mark.bmp";
            Bitmap FCMark;

            try
            {
                FCMark = new Bitmap(DirFilePath);

                pictureBox_fc_mark.Image = FCMark;
                pictureBox_fc_mark.SizeMode = PictureBoxSizeMode.StretchImage;
            }
            catch (Exception e)
            {

            }
        }


        private void button_fc_mark_reg_Click(object sender, EventArgs e)
        {
            bCheckMarkReg = true;
        }

        private void button_fc_mark_apply_Click(object sender, EventArgs e)
        {
            int nRecipe;
            nRecipe = mainForm.nSelectedRecipe;

            string DirPath = Application.StartupPath + @"\Config\" + nRecipe.ToString();
            string DirFilePath = DirPath + "\\FC_Mark.bmp";

            CreateImagePath();

            bCheckMarkReg = false;
        }

        public void CreateImagePath()
        {
            int nRecipe;
            nRecipe = mainForm.nSelectedRecipe;

            string DirPath = Application.StartupPath + @"\Config\" + nRecipe.ToString();

            pictureBox_fc_mark.Image = null;
            pictureBox_fc_mark.Update();
            string strPath = DirPath + "\\FC_Origin.bmp";

            mainForm.dlgVision.SaveOrigin(pictureBox_fc, strPath);

            Bitmap FCMark = new Bitmap(strPath);

            string DirFilePath = DirPath + "\\FC_Mark.bmp";

            FCMark = FCMark.Clone(new Rectangle(FCMarkRect.X * nMagni, FCMarkRect.Y * nMagni, FCMarkRect.Width * nMagni, FCMarkRect.Height * nMagni), System.Drawing.Imaging.PixelFormat.DontCare);
            FCMark.Save(DirFilePath);

            pictureBox_fc_mark.Image = FCMark;
            pictureBox_fc_mark.SizeMode = PictureBoxSizeMode.StretchImage;
        }

        public void SimulationFCMark()
        {
            int nRecipe;
            nRecipe = mainForm.nSelectedRecipe;

            string DirPath = Application.StartupPath + @"\Config\" + nRecipe.ToString();

            string strPath = DirPath + "\\FC_Origin.bmp";
            // 원본 저장
            mainForm.dlgVision.SaveOrigin(pictureBox_fc, strPath);

            Bitmap FCOrigin = new Bitmap(strPath);

            string strMark = DirPath + "\\FC_Mark.bmp";
            Bitmap FCMark = new Bitmap(strMark);

            Bitmap FCResult = new Bitmap(2448, 2048);

            Mat inputMat = OpenCvSharp.Extensions.BitmapConverter.ToMat(FCOrigin);
            Mat searchMat = OpenCvSharp.Extensions.BitmapConverter.ToMat(FCMark);
            Mat resultMat = OpenCvSharp.Extensions.BitmapConverter.ToMat(FCResult);

            Cv2.MatchTemplate(inputMat, searchMat, resultMat, TemplateMatchModes.CCoeffNormed);

            OpenCvSharp.Point minloc, maxloc;
            double minval, maxval;
            Cv2.MinMaxLoc(resultMat, out minval, out maxval, out minloc, out maxloc);

            pDetectStart.X = maxloc.X / nMagni;
            pDetectStart.Y = maxloc.Y / nMagni;
            pDetectEnd.X = FCMark.Width / nMagni;
            pDetectEnd.Y = FCMark.Height / nMagni;

            mainForm.ribbonTextBox_fc_detect_matchrate.TextBoxText = (maxval * 100).ToString("F2") + "%";
            mainForm.ribbonTextBox_fc_detect_point_x.TextBoxText = (maxloc.X + FCMark.Width / 2).ToString();
            mainForm.ribbonTextBox_fc_detect_point_y.TextBoxText = (maxloc.Y + FCMark.Height / 2).ToString();

            bDetectMark = true;
        }

        public void FindFCMark(int nFCCount)
        {
            int nRecipe;
            nRecipe = mainForm.nSelectedRecipe;

            string DirPath = Application.StartupPath + @"\Config\" + nRecipe.ToString();

            string strPath = DirPath + "\\FC_Origin.bmp";

            mainForm.dlgVision.SaveOrigin(pictureBox_fc, strPath);

            Bitmap FCOrigin = new Bitmap(strPath);

            string strMark = DirPath + "\\FC_Mark.bmp";
            Bitmap FCMark = new Bitmap(strMark);

            Bitmap FCResult = new Bitmap(2448, 2048);

            Mat inputMat = OpenCvSharp.Extensions.BitmapConverter.ToMat(FCOrigin);
            Mat searchMat = OpenCvSharp.Extensions.BitmapConverter.ToMat(FCMark);
            Mat resultMat = OpenCvSharp.Extensions.BitmapConverter.ToMat(FCResult);

            Cv2.MatchTemplate(inputMat, searchMat, resultMat, TemplateMatchModes.CCoeffNormed);

            OpenCvSharp.Point minloc, maxloc;
            double minval, maxval;
            Cv2.MinMaxLoc(resultMat, out minval, out maxval, out minloc, out maxloc);

            pDetectStart.X = maxloc.X / nMagni;
            pDetectStart.Y = maxloc.Y / nMagni;
            pDetectEnd.X = FCMark.Width / nMagni;
            pDetectEnd.Y = FCMark.Height / nMagni;

            stFC[nFCCount].dErrorX = 1224 - (maxloc.X + FCMark.Width / 2);
            stFC[nFCCount].dErrorY = 1024 - (maxloc.Y + FCMark.Height / 2);

            stFC[nFCCount].dResultX = stFC[nFCCount].dArrayX - (stFC[nFCCount].dErrorX * 0.0008625);
            stFC[nFCCount].dResultY = stFC[nFCCount].dArrayY - (stFC[nFCCount].dErrorY * 0.0008625);

            bDetectMark = true;
        }

        private void button_fc_mark_cancel_Click(object sender, EventArgs e)
        {
            FCMarkRect = new Rectangle(0, 0, 100, 100);
            bCheckMarkReg = false;
        }

        private void textBox_fc_mark_matchrate_TextChanged(object sender, EventArgs e)
        {
            String strInput = textBox_fc_mark_matchrate.Text;

            if (double.TryParse(strInput, out dMatchrate))
            {
            }

            else
            {
            }
        }

        public void LoadOldctFile()
        {

            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "ct5 file(*.ct5) | *.ct5 |모든 파일 (*.*) | *.*";
            ofd.InitialDirectory = "D:\\";

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                mainForm.ribbonTextBox_fc_param_oldctfile.TextBoxText = ofd.FileName;
                strOLDCTfile = ofd.FileName;

                mainForm.ribbonTextBox_fc_param_newctfile.TextBoxText = ofd.FileName.Substring(0, ofd.FileName.Length - 4) + "_2.ct5";
                strNEWCTfile = ofd.FileName.Substring(0, ofd.FileName.Length - 4) + "_2.ct5";
            }
        }

        private void button_fc_result_save_Click(object sender, EventArgs e)
        {
            button_fc_result_save.Enabled = false;

            string DirDay = Environment.CurrentDirectory + @"\Data\\Field Correction\\" + DateTime.Today.ToString("yyMMdd");

            DirectoryInfo di = new DirectoryInfo(DirDay);
            if (!di.Exists) Directory.CreateDirectory(DirDay);

            FileStream fs = new FileStream(DirDay + "\\" + DateTime.Now.ToString("HHmmss") + ".dat", FileMode.OpenOrCreate);

            StreamWriter sw = new StreamWriter(fs);

            sw.WriteLine("//RTC6 Correction Data File");
            sw.WriteLine("");
            sw.WriteLine("OLDCTFILE = " + strOLDCTfile);
            sw.WriteLine("NEWCTFILE = " + strNEWCTfile);
            sw.WriteLine("");
            sw.WriteLine("TOLERANCE = " + dGain.ToString("F3"));
            sw.WriteLine("");
            sw.WriteLine("NEWCAL = " + dNewcal.ToString("F3"));
            sw.WriteLine("");
            sw.WriteLine("// RTC-X [Bit] RTC-Y[Bit]     REAL-X[mm]  REAL-Y[mm]");

            for (int i = 0; i < nPoint * nPoint; i++)
            {
                if (i % nPoint == 0)
                    sw.WriteLine("");

                string strValue;

                double dXmm;
                double dYmm;

                dXmm = (((i % nPoint) - (nPoint / 2)) * dLength);
                dYmm = (((i / nPoint) - (nPoint / 2)) * dLength);

                int nXBit;
                int nYBit;

                nXBit = (int)(dXmm * dNewcal);
                nYBit = (int)(dYmm * dNewcal);

                string strXBit = (nXBit.ToString()).PadLeft(10, ' ');
                string strYBit = (nYBit.ToString()).PadLeft(10, ' ');

                string strXreal = (stFC[i].dResultX.ToString("F3")).PadLeft(10, ' ');
                string strYreal = (stFC[i].dResultY.ToString("F3")).PadLeft(10, ' ');

                strValue = " " + strXBit + " " + strYBit + "    " + strXreal + "  " + strYreal;
                sw.WriteLine(strValue);
            }

            sw.Close();
            fs.Close();

            ResetDataGrid();
            laserMarkingPosition();
            nFCCount = 0;
            button_fc_result_save.Enabled = false;
        }

        public void EnableSetting(bool nCase)
        {
            button_fc_mark_reg.Enabled = nCase;
            button_fc_mark_apply.Enabled = nCase;
            button_fc_mark_cancel.Enabled = nCase;
            textBox_fc_mark_matchrate.Enabled = nCase;

            mainForm.ribbonTextBox_fc_param_center_x.Enabled = nCase;
            mainForm.ribbonTextBox_fc_param_center_y.Enabled = nCase;

            mainForm.ribbonTextBox_fc_param_gain.Enabled = nCase;
            mainForm.ribbonTextBox_fc_param_newcal.Enabled = nCase;
            mainForm.ribbonTextBox_fc_param_point.Enabled = nCase;
            mainForm.ribbonTextBox_fc_param_length.Enabled = nCase;

            mainForm.ribbonButton_fc_param_oldctfile.Enabled = nCase;
            mainForm.ribbonTextBox_fc_param_oldctfile.Enabled = nCase;
            mainForm.ribbonTextBox_fc_param_newctfile.Enabled = nCase;
        }

        private void pictureBox_fc_Paint(object sender, PaintEventArgs e)
        {
            using (Pen penGreen = new Pen(Color.LimeGreen, 1))
            {
                if (bCheckMarkReg)
                    e.Graphics.DrawRectangle(penGreen, FCMarkRect.X, FCMarkRect.Y, FCMarkRect.Width, FCMarkRect.Height);

                if (bDetectMark)
                {
                    e.Graphics.DrawRectangle(penGreen, pDetectStart.X, pDetectStart.Y, pDetectEnd.X, pDetectEnd.Y);
                    e.Graphics.DrawLine(penGreen, (pDetectStart.X + pDetectEnd.X / 2), (pDetectStart.Y + pDetectEnd.Y / 2) - 5,
                        (pDetectStart.X + pDetectEnd.X / 2), (pDetectStart.Y + pDetectEnd.Y / 2) + 5);

                    e.Graphics.DrawLine(penGreen, (pDetectStart.X + pDetectEnd.X / 2) - 5, (pDetectStart.Y + pDetectEnd.Y / 2),
                        (pDetectStart.X + pDetectEnd.X / 2) + 5, (pDetectStart.Y + pDetectEnd.Y / 2));
                }
            }
        }

        private void pictureBox_fc_MouseDown(object sender, MouseEventArgs e)
        {
            if (bCheckMarkReg)
            {
                startPos = new System.Drawing.Point(e.X, e.Y);

                bClickSizeLeft = false;
                bClickSizeRight = false;
                bClickSizeTop = false;
                bClickSizeBottom = false;
                bClickSizeLeftTop = false;
                bClickSizeLeftBottom = false;
                bClickSizeRightTop = false;
                bClickSizeRightBottom = false;
                bClickCheck = false;

                if (MouseInLeft)
                {
                    if (MouseInTop)
                        bClickSizeLeftTop = true;

                    else if (MouseInBottom)
                        bClickSizeLeftBottom = true;

                    else
                        bClickSizeLeft = true;
                }

                else if (MouseInRight)
                {
                    if (MouseInTop)
                        bClickSizeRightTop = true;

                    else if (MouseInBottom)
                        bClickSizeRightBottom = true;

                    else
                        bClickSizeRight = true;
                }

                else if (MouseInTop)
                {
                    bClickSizeTop = true;
                }

                else if (MouseInBottom)
                {
                    bClickSizeBottom = true;
                }

                else
                {
                    bClickCheck = true;
                }
            }
        }

        private void pictureBox_fc_MouseMove(object sender, MouseEventArgs e)
        {
            if (bCheckMarkReg)
            {
                CheckMousePosition(FCMarkRect, new System.Drawing.Point(e.X, e.Y));
                ChangeCursor();

                if (e.X > 0 && e.X < 2448)
                {
                    if (e.Y > 0 && e.Y < 2048)
                    {
                        if (bClickCheck)
                        {
                            endPos = new System.Drawing.Point(e.X, e.Y);

                            FCMarkRect.X += endPos.X - startPos.X;
                            FCMarkRect.Y += endPos.Y - startPos.Y;

                            startPos = endPos;
                        }

                        else if (bClickSizeLeft)
                        {
                            endPos = new System.Drawing.Point(e.X, e.Y);

                            FCMarkRect.X += (endPos.X - startPos.X);
                            FCMarkRect.Width -= (endPos.X - startPos.X);

                            startPos = endPos;
                        }

                        else if (bClickSizeRight)
                        {
                            endPos = new System.Drawing.Point(e.X, e.Y);

                            FCMarkRect.Width += (endPos.X - startPos.X);

                            startPos = endPos;
                        }

                        else if (bClickSizeTop)
                        {
                            endPos = new System.Drawing.Point(e.X, e.Y);

                            FCMarkRect.Y += (endPos.Y - startPos.Y);
                            FCMarkRect.Height -= (endPos.Y - startPos.Y);

                            startPos = endPos;
                        }

                        else if (bClickSizeBottom)
                        {
                            endPos = new System.Drawing.Point(e.X, e.Y);

                            FCMarkRect.Height += (endPos.Y - startPos.Y);

                            startPos = endPos;
                        }

                        else if (bClickSizeLeftTop)
                        {
                            endPos = new System.Drawing.Point(e.X, e.Y);

                            FCMarkRect.X += (endPos.X - startPos.X);
                            FCMarkRect.Width -= (endPos.X - startPos.X);
                            FCMarkRect.Y += (endPos.Y - startPos.Y);
                            FCMarkRect.Height -= (endPos.Y - startPos.Y);

                            startPos = endPos;
                        }

                        else if (bClickSizeLeftBottom)
                        {
                            endPos = new System.Drawing.Point(e.X, e.Y);

                            FCMarkRect.X += (endPos.X - startPos.X);
                            FCMarkRect.Width -= (endPos.X - startPos.X);
                            FCMarkRect.Height += (endPos.Y - startPos.Y);

                            startPos = endPos;
                        }

                        else if (bClickSizeRightTop)
                        {
                            endPos = new System.Drawing.Point(e.X, e.Y);

                            FCMarkRect.Width += (endPos.X - startPos.X);
                            FCMarkRect.Y += (endPos.Y - startPos.Y);
                            FCMarkRect.Height -= (endPos.Y - startPos.Y);

                            startPos = endPos;
                        }

                        else if (bClickSizeRightBottom)
                        {
                            endPos = new System.Drawing.Point(e.X, e.Y);

                            FCMarkRect.Width += (endPos.X - startPos.X);
                            FCMarkRect.Height += (endPos.Y - startPos.Y);

                            startPos = endPos;
                        }
                    }
                }
            }
        }

        private void pictureBox_fc_MouseUp(object sender, MouseEventArgs e)
        {
            bClickCheck = false;
            bClickSizeLeft = false;
            bClickSizeRight = false;
            bClickSizeTop = false;
            bClickSizeBottom = false;
            bClickSizeLeftTop = false;
            bClickSizeLeftBottom = false;
            bClickSizeRightTop = false;
            bClickSizeRightBottom = false;
        }

        public void CheckMousePosition(Rectangle r, System.Drawing.Point e)
        {
            MouseInLeft = (Math.Abs(e.X - r.X) <= 5) && (e.Y > r.Y) && (e.Y < r.Y + r.Height);
            MouseInRight = (Math.Abs(e.X - r.X - r.Width) <= 5) && (e.Y > r.Y) && (e.Y < r.Y + r.Height);
            MouseInTop = (Math.Abs(e.Y - r.Y) <= 5) && (e.X > r.X) && (e.X < r.X + r.Width);
            MouseInBottom = (Math.Abs(e.Y - r.Y - r.Height) <= 5) && (e.X > r.X) && (e.X < r.X + r.Width);
        }

        public void ChangeCursor()
        {
            if (MouseInLeft)
            {
                if (MouseInTop)
                    pictureBox_fc.Cursor = Cursors.SizeNWSE;

                else if (MouseInBottom)
                    pictureBox_fc.Cursor = Cursors.SizeNESW;

                else
                    pictureBox_fc.Cursor = Cursors.SizeWE;
            }

            else if (MouseInRight)
            {
                if (MouseInTop)
                    pictureBox_fc.Cursor = Cursors.SizeNESW;

                else if (MouseInBottom)
                    pictureBox_fc.Cursor = Cursors.SizeNWSE;

                else
                    pictureBox_fc.Cursor = Cursors.SizeWE;
            }

            else if (MouseInTop || MouseInBottom)
                pictureBox_fc.Cursor = Cursors.SizeNS;

            else
                pictureBox_fc.Cursor = Cursors.Default;
        }


        public void FCMagni(int nMagniEvent)
        {
            if (nMagniEvent == 1)
            {
                if ((int)nMagni == 2)
                {
                    nMagni = 1;
                    pDetectStart.X = pDetectStart.X * 2;
                    pDetectStart.Y = pDetectStart.Y * 2;
                    pDetectEnd.X = pDetectEnd.X * 2;
                    pDetectEnd.Y = pDetectEnd.Y * 2;

                    FCMarkRect.X = FCMarkRect.X * 2;
                    FCMarkRect.Y = FCMarkRect.Y * 2;
                    FCMarkRect.Width = FCMarkRect.Width * 2;
                    FCMarkRect.Height = FCMarkRect.Height * 2;
                }

                else if ((int)nMagni == 4)
                {
                    nMagni = 1;
                    pDetectStart.X = pDetectStart.X * 4;
                    pDetectStart.Y = pDetectStart.Y * 4;
                    pDetectEnd.X = pDetectEnd.X * 4;
                    pDetectEnd.Y = pDetectEnd.Y * 4;

                    FCMarkRect.X = FCMarkRect.X * 4;
                    FCMarkRect.Y = FCMarkRect.Y * 4;
                    FCMarkRect.Width = FCMarkRect.Width * 4;
                    FCMarkRect.Height = FCMarkRect.Height * 4;
                }

                pictureBox_fc.Size = new System.Drawing.Size(2448, 2048);
                pictureBox_fc.SizeMode = PictureBoxSizeMode.Normal;
            }

            else if (nMagniEvent == 2)
            {
                if ((int)nMagni == 1)
                {
                    nMagni = 2;
                    pDetectStart.X = pDetectStart.X / 2;
                    pDetectStart.Y = pDetectStart.Y / 2;
                    pDetectEnd.X = pDetectEnd.X / 2;
                    pDetectEnd.Y = pDetectEnd.Y / 2;

                    FCMarkRect.X = FCMarkRect.X / 2;
                    FCMarkRect.Y = FCMarkRect.Y / 2;
                    FCMarkRect.Width = FCMarkRect.Width / 2;
                    FCMarkRect.Height = FCMarkRect.Height / 2;
                }

                else if ((int)nMagni == 4)
                {
                    nMagni = 2;
                    pDetectStart.X = pDetectStart.X * 2;
                    pDetectStart.Y = pDetectStart.Y * 2;
                    pDetectEnd.X = pDetectEnd.X * 2;
                    pDetectEnd.Y = pDetectEnd.Y * 2;

                    FCMarkRect.X = FCMarkRect.X * 2;
                    FCMarkRect.Y = FCMarkRect.Y * 2;
                    FCMarkRect.Width = FCMarkRect.Width * 2;
                    FCMarkRect.Height = FCMarkRect.Height * 2;
                }

                pictureBox_fc.Size = new System.Drawing.Size(1224, 1024);
                pictureBox_fc.SizeMode = PictureBoxSizeMode.Zoom;
            }
            
            else if (nMagniEvent == 4)
            {
                if ((int)nMagni == 1)
                {
                    nMagni = 4;
                    pDetectStart.X = pDetectStart.X / 4;
                    pDetectStart.Y = pDetectStart.Y / 4;
                    pDetectEnd.X = pDetectEnd.X / 4;
                    pDetectEnd.Y = pDetectEnd.Y / 4;

                    FCMarkRect.X = FCMarkRect.X / 4;
                    FCMarkRect.Y = FCMarkRect.Y / 4;
                    FCMarkRect.Width = FCMarkRect.Width / 4;
                    FCMarkRect.Height = FCMarkRect.Height / 4;
                }

                else if ((int)nMagni == 2)
                {
                    nMagni = 4;
                    pDetectStart.X = pDetectStart.X / 2;
                    pDetectStart.Y = pDetectStart.Y / 2;
                    pDetectEnd.X = pDetectEnd.X / 2;
                    pDetectEnd.Y = pDetectEnd.Y / 2;

                    FCMarkRect.X = FCMarkRect.X / 2;
                    FCMarkRect.Y = FCMarkRect.Y / 2;
                    FCMarkRect.Width = FCMarkRect.Width / 2;
                    FCMarkRect.Height = FCMarkRect.Height / 2;
                }

                pictureBox_fc.Size = new System.Drawing.Size(612, 512);
                pictureBox_fc.SizeMode = PictureBoxSizeMode.Zoom;
            }
        }


        public void simulationDetect()
        {
            int nFCMaxCount = nPoint * nPoint;

            if (nFCCount < nFCMaxCount)
            {
                if (nFCCount == nFCMaxCount - 1)
                    button_fc_result_save.Enabled = true;

                fc_marking(nFCCount);

                nFCCount++;
            }
        }

        public void fc_marking(int nFCCount)
        {
            FindFCMark(nFCCount);

            dtResultX.Rows[nFCCount / nPoint][(nFCCount % nPoint) + 1] = stFC[nFCCount].dResultX.ToString("F3");
            dtResultY.Rows[nFCCount / nPoint][(nFCCount % nPoint) + 1] = stFC[nFCCount].dResultY.ToString("F3");
        }


        public void ResetDataGrid()
        {
            for (int i = 0; i < 11; i++)
            {
                for (int j = 0; j < 11; j++)
                {
                    dtResultX.Rows[i][j + 1] = "";
                    dtResultY.Rows[i][j + 1] = "";
                }

            }
        }

        public void LoadRecipe()
        {
            FormRecipeSelect dlgSelectRecipe = new FormRecipeSelect();

            dlgSelectRecipe.Owner = this;

            dlgSelectRecipe.button_select_recipe.Text = "불러오기";

            String strFile = Application.StartupPath + @"\Config\\RecipeName.ini";
            String strRecipeName;
            StringBuilder strData = new StringBuilder();

            for (int i = 0; i < 100; i++)
            {
                strRecipeName = "Recipe" + (i + 1).ToString();
                GetPrivateProfileString("RecipeName", strRecipeName, "", strData, 32, strFile);

                dlgSelectRecipe.strRecipeName[i] = "[" + (i + 1).ToString() + "] " + strData;
            }

            dlgSelectRecipe.LoadRecipeName();
            dlgSelectRecipe.SelectedRecipe(mainForm.nSelectedRecipe);

            if (dlgSelectRecipe.ShowDialog() == DialogResult.OK)
            {
                string folderPath = Application.StartupPath + @"\Config\" + (dlgSelectRecipe.nSelectRecipe + 1).ToString();

                DirectoryInfo di = new DirectoryInfo(folderPath);

                if (di.Exists == false)
                {
                    MessageBox.Show("등록된 레시피 정보가 확인되지 않습니다.");
                }

                else
                {
                    mainForm.nSelectedRecipe = dlgSelectRecipe.nSelectRecipe + 1;
                    DisplayRecipeName(mainForm.nSelectedRecipe);

                    LoadConfig();
                    DisplaySetting();

                    mainForm.dlgVision.LoadConfig();
                    mainForm.dlgVision.DisplaySetting(mainForm.dlgVision.nSelectedAlign);
                    ResetDataGrid();
                }
            }

            dlgSelectRecipe.Dispose();
        }

        public void SaveRecipe()
        {
            FormRecipeSelect dlgSelectRecipe = new FormRecipeSelect();
            dlgSelectRecipe.Owner = this;

            dlgSelectRecipe.button_select_recipe.Text = "저장하기";

            String strFile = Application.StartupPath + @"\Config\\RecipeName.ini";
            String strRecipeName;
            StringBuilder strData = new StringBuilder();

            for (int i = 0; i < 100; i++)
            {
                strRecipeName = "Recipe" + (i + 1).ToString();
                GetPrivateProfileString("RecipeName", strRecipeName, "", strData, 32, strFile);

                dlgSelectRecipe.strRecipeName[i] = "[" + (i + 1).ToString() + "] " + strData;
            }

            dlgSelectRecipe.LoadRecipeName();
            dlgSelectRecipe.SelectedRecipe(mainForm.nSelectedRecipe);

            if (dlgSelectRecipe.ShowDialog() == DialogResult.OK)
            {
                string sourcePath = Application.StartupPath + @"\Config\" + mainForm.nSelectedRecipe.ToString();
                string folderPath = Application.StartupPath + @"\Config\" + (dlgSelectRecipe.nSelectRecipe + 1).ToString();

                DirectoryInfo di = new DirectoryInfo(folderPath);

                if (di.Exists == false)
                {
                    Directory.CreateDirectory(folderPath);

                    string[] files = Directory.GetFiles(sourcePath);

                    foreach (string file in files)
                    {
                        string name = Path.GetFileName(file);
                        string dest = Path.Combine(folderPath, name);
                        File.Copy(file, dest);
                    }

                    mainForm.nSelectedRecipe = dlgSelectRecipe.nSelectRecipe + 1;

                    string strSaveRecipe;
                    strSaveRecipe = "Recipe" + mainForm.nSelectedRecipe.ToString();
                    WritePrivateProfileString("RecipeName", strSaveRecipe, mainForm.ribbonTextBox_fc_recipe_name.TextBoxText.ToString(), strFile);
                    DisplayRecipeName(mainForm.nSelectedRecipe);

                    LoadConfig();
                    ResetDataGrid();
                    mainForm.dlgVision.LoadConfig();
                }

                else
                {
                    if (MessageBox.Show("레시피를 덮어씌우겠습니까?", "RTR LASER", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        mainForm.nSelectedRecipe = dlgSelectRecipe.nSelectRecipe + 1;

                        string strSaveRecipe;
                        strSaveRecipe = "Recipe" + mainForm.nSelectedRecipe.ToString();
                        WritePrivateProfileString("RecipeName", strSaveRecipe, mainForm.ribbonTextBox_fc_recipe_name.TextBoxText.ToString(), strFile);
                        DisplayRecipeName(mainForm.nSelectedRecipe);
                        SaveConfig();
                        LoadConfig();
                        DisplaySetting();
                        ResetDataGrid();

                        mainForm.dlgVision.SaveConfig();
                        mainForm.dlgVision.LoadConfig();
                        mainForm.dlgVision.DisplaySetting(mainForm.dlgVision.nSelectedAlign);
                    }

                    else
                    {
                    }
                }
            }

            dlgSelectRecipe.Dispose();
        }


        public string DisplayRecipeName(int nRecipeNum)
        {
            String strFile = Application.StartupPath + @"\Config\\RecipeName.ini";
            String strRecipeName;
            StringBuilder strData = new StringBuilder();

            strRecipeName = "Recipe" + nRecipeNum.ToString();
            GetPrivateProfileString("RecipeName", strRecipeName, "", strData, 32, strFile);
            mainForm.ribbonTextBox_vision_recipe_name.TextBoxText = strData.ToString();
            mainForm.ribbonTextBox_fc_recipe_name.TextBoxText = strData.ToString();

            mainForm.ribbonTextBox_vision_recipe_num.TextBoxText = nRecipeNum.ToString();
            mainForm.ribbonTextBox_fc_recipe_num.TextBoxText = nRecipeNum.ToString();

            return strData.ToString();
        }
    }
}
