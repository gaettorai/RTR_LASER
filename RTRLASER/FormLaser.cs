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
using System.Diagnostics;
using System.IO;    // for write log
using System.IO.Ports;
using System.Threading;
using SAMLIGHT_CLIENT_CTRL_EXLib;

using Microsoft.WindowsAPICodePack.Dialogs;

namespace RTRLASER
{
    public partial class FormLaser : Form
    {
        FormMain mainForm;

        [DllImport("user32")]
        private static extern IntPtr SetParent(IntPtr childWindowHandle, IntPtr parentWindowHandle);

        [DllImport("user32")]
        private static extern bool MoveWindow(IntPtr hwnd, int x, int y, int cx, int cy, bool repaint);

        [DllImport("kernel32")]
        private static extern long WritePrivateProfileString(string section, string key, string val, string filePath);
        [DllImport("kernel32")]
        private static extern int GetPrivateProfileString(string section, string key, string def, StringBuilder retVal, int size, string filePath);

        // 분할 유무
        public bool bCheckSplit = false;

        public int nLaserSplit;
        public int nRow, nCol;                      // 행렬 분할 갯수
        public int nSelectedEntity;                 // 선택한 Entity

        public Process pLaser = null;               // samlight program 실행 process

        public class SplitInfo
        {
            public struct stSplit
            {
                public string strName;

                public double dCenterPosX;
                public double dCenterPosY;

                public double dWidth;
                public double dHeight;
                public double dAngle;

                public double dOffsetX;
                public double dOffsetY;
                public double dOffsetAngle;
            }
        }

        public SplitInfo.stSplit[] stSplit;

        public FormLaser(FormMain parent)
        {
            MdiParent = mainForm = parent;

            InitializeComponent();

            //ExcutionLaser();
        }

        public void ExcutionLaser()
        {
            int status = 0;

            pLaser = System.Diagnostics.Process.Start("C:\\scaps\\sam2d\\samlight\\sam_light.exe");

            while (true)
            {
                try
                {
                    status = mainForm.ctrlLaser.ScGetConnectionStatus();
                }
                catch
                {
                }

                if (status == 1)
                {
                    SetParent(pLaser.MainWindowHandle, panel_laser.Handle);
                    MoveWindow(pLaser.MainWindowHandle, -10, -30, panel_laser.Width + 20, panel_laser.Height + 60, true);
                    break;
                }
            }
        }


        public void SplitApply(bool nCase)
        {
            if (nCase == true)
            {
                mainForm.ctrlLaser.ScSetDoubleValue((int)
                    ScComSAMLightClientCtrlValueTypes.scComSAMLightClientCtrlDoubleValueType2DSplitWidthValue, Convert.ToInt32(mainForm.ribbonTextBox_split_row.TextBoxText));

                mainForm.ctrlLaser.ScSetDoubleValue((int)
                    ScComSAMLightClientCtrlValueTypes.scComSAMLightClientCtrlDoubleValueType2DSplitHeightValue, Convert.ToInt32(mainForm.ribbonTextBox_split_col.TextBoxText));

                mainForm.ctrlLaser.ScExecCommand((int)
                    ScComSAMLightClientCtrlExecCommandConstants.scComSAMLightClientCtrlExecCommandResplitJob);

            }

            else
            {
                double Min_X, Min_Y, Max_X, Max_Y;
                Min_X = Min_Y = Max_X = Max_Y = 0.0;

                mainForm.ctrlLaser.ScGetEntityOutline2D("", ref Min_X, ref Min_Y, ref Max_X, ref Max_Y);

                double dWidth;
                double dHeight;

                dWidth = (Max_X - Min_X) / Convert.ToInt32(mainForm.ribbonTextBox_split_row.TextBoxText);
                dHeight = (Max_Y - Min_Y) / Convert.ToInt32(mainForm.ribbonTextBox_split_col.TextBoxText);

                mainForm.ctrlLaser.ScSetDoubleValue((int)
                    ScComSAMLightClientCtrlValueTypes.scComSAMLightClientCtrlDoubleValueType2DSplitWidthValue, dWidth);

                mainForm.ctrlLaser.ScSetDoubleValue((int)
                    ScComSAMLightClientCtrlValueTypes.scComSAMLightClientCtrlDoubleValueType2DSplitHeightValue, dHeight);

                if (dWidth > mainForm.ctrlLaser.ScGetWorkingArea(0x3) - mainForm.ctrlLaser.ScGetWorkingArea(0x0) ||
                    dHeight > mainForm.ctrlLaser.ScGetWorkingArea(0x4) - mainForm.ctrlLaser.ScGetWorkingArea(0x1))
                {
                    MessageBox.Show("Split size bigger than available working area ", "RTRLASER");
                    mainForm.ribbonCheckBox_split_apply.Checked = false;
                }

                else
                    mainForm.ctrlLaser.ScExecCommand((int)
                        ScComSAMLightClientCtrlExecCommandConstants.scComSAMLightClientCtrlExecCommandResplitJob);
            }
        }

        public void CreateSplitFolder()
        {
            nLaserSplit = CountEntity();

            int cur_Mode = 0;
            mainForm.ctrlLaser.ScGetMode(ref cur_Mode);
            cur_Mode |= (int)
            ScComSAMLightClientCtrlFlags.scComSAMLightClientCtrlModeFlagEntityNamesSeparatedBySemicolon;
            mainForm.ctrlLaser.ScSetMode(cur_Mode);

            string strGroup = "";

            string Name = "";

            SetEntityName(nLaserSplit);

            mainForm.ctrlLaser.ScGetIDStringData((int)
                    ScComSAMLightClientCtrlFlags.scComSAMLightClientCtrlStringDataIdGetEntityName, 0, ref Name);
            strGroup = Name;

            if (nLaserSplit > 1)
            {
                for (int i = 1; i < nLaserSplit; i++)
                {
                    mainForm.ctrlLaser.ScGetIDStringData((int)
                    ScComSAMLightClientCtrlFlags.scComSAMLightClientCtrlStringDataIdGetEntityName, i, ref Name);

                    strGroup += ";" + Name;
                }

                mainForm.ctrlLaser.ScSetEntityLongData(strGroup, (int)
                ScComSAMLightClientCtrlFlags.scComSAMLightClientCtrlLongDataIdEntitySelected, 1);

                mainForm.ctrlLaser.ScExecCommand((int)
                    ScComSAMLightClientCtrlExecCommandConstants.scComSAMLightClientCtrlExecCommandGroupEntities);

                mainForm.ctrlLaser.ScSetIDStringData((int)
                    ScComSAMLightClientCtrlFlags.scComSAMLightClientCtrlStringDataIdSetEntityName, 0, "Project");

                //mainForm.ctrlLaser.ScExecCommand((int)
                //    ScComSAMLightClientCtrlExecCommandConstants.scComSAMLightClientCtrlExecCommandUngroupEntities);
            }

            double Min_X, Min_Y, Max_X, Max_Y;
            Min_X = Min_Y = Max_X = Max_Y = 0.0;
            mainForm.ctrlLaser.ScGetEntityOutline2D("Project", ref Min_X, ref Min_Y, ref Max_X, ref Max_Y);

            double dXdist, dYdist;

            dXdist = Max_X - Min_X;
            dYdist = Max_Y - Min_Y;

            if (mainForm.ribbonRadioBox_split_size.Checked)
            {
                nRow = (int)(Math.Ceiling((dXdist / Convert.ToInt32(mainForm.ribbonTextBox_split_row.TextBoxText))));
                nCol = (int)(Math.Ceiling((dYdist / Convert.ToInt32(mainForm.ribbonTextBox_split_col.TextBoxText))));
            }

            else
            {
                nRow = Convert.ToInt32(mainForm.ribbonTextBox_split_row.TextBoxText);
                nCol = Convert.ToInt32(mainForm.ribbonTextBox_split_col.TextBoxText);
            }

            if (nRow > 10 || nCol > 10)
            {
                MessageBox.Show("SPLIT SETTING OVER", "RTRLASER");
            }

            else
            {
                double dCenterPosX;
                double dCenterPosY;

                dCenterPosX = Max_X - ((Max_X - Min_X) / 2);
                dCenterPosY = Max_Y - ((Max_Y - Min_Y) / 2);

                double dSplitCenterPosX;
                double dSplitCenterPosY;

                string fileName;
                SaveFileDialog saveFileDialog = new SaveFileDialog();
                saveFileDialog.Title = "";
                saveFileDialog.OverwritePrompt = true;
                saveFileDialog.Filter = "SAF (Scaps Archive File)|*.saf";

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    fileName = saveFileDialog.FileName;
                    mainForm.ctrlLaser.ScSetStringValue((int)
                        ScComSAMLightClientCtrlValueTypes.scComSAMLightClientCtrlStringValueTypeSaveSplitsJobFileName,
                        Environment.ExpandEnvironmentVariables(fileName));

                    mainForm.ctrlLaser.ScExecCommand((int)
                        ScComSAMLightClientCtrlExecCommandConstants.scComSAMLightClientCtrlExecCommandSaveSplitsAsEntities);
                    
                    mainForm.ctrlLaser.ScLoadJob(fileName, 1, 1, 1);

                    mainForm.ctrlLaser.ScGetEntityOutline2D("", ref Min_X, ref Min_Y, ref Max_X, ref Max_Y);

                    dSplitCenterPosX = Max_X - ((Max_X - Min_X) / 2);
                    dSplitCenterPosY = Max_Y - ((Max_Y - Min_Y) / 2);

                    mainForm.ctrlLaser.ScTranslateEntity("", dCenterPosX - dSplitCenterPosX, dCenterPosY - dSplitCenterPosY, 0);

                    //int nCount = 1;
                    //string FileName;
                    //string DirPath = fileName.Substring(0, fileName.Length - 4) + "_SPLIT";

                    //DirectoryInfo di = new DirectoryInfo(DirPath);

                    //if (!di.Exists) Directory.CreateDirectory(DirPath);
                    //{
                    //    System.IO.FileInfo[] files = di.GetFiles("*.*", SearchOption.AllDirectories);

                    //    foreach (System.IO.FileInfo file in files)
                    //        file.Delete();

                    //    FileName = DirPath + "\\Project" + nCount.ToString() + ".saf";

                    //    for (int i = 0; i < nCol * nRow; i++)
                    //    {
                    //        FileName = DirPath + "\\Project" + nCount.ToString() + ".saf";
                    //        int flags = 0X10;
                    //        flags |= 0x100;

                    //        if (nCol * nRow < 10)
                    //            mainForm.ctrlLaser.ScExport(nCount.ToString(), FileName, "saf", 0.001, flags);

                    //        else if (nCol * nRow < 100)
                    //            mainForm.ctrlLaser.ScExport(nCount.ToString("D2"), FileName, "saf", 0.001, flags);

                    //        else if (nCol * nRow == 100)
                    //            mainForm.ctrlLaser.ScExport(nCount.ToString("D3"), FileName, "saf", 0.001, flags);

                    //        nCount++;
                    //    }
                    //}


                    nLaserSplit = CountEntity();
                    SetEntityName(nLaserSplit);
                    mainForm.ribbonCheckBox_split_apply.Checked = false;
                    int flags = 0X10;
                    flags |= 0x100;
                    mainForm.ctrlLaser.ScExport("", fileName, "saf", 0.001, flags);

                }
            }
        }

        //public void SplitDrawingSave()
        //{
        //    nLaserSplit = CountEntity();

        //    int cur_Mode = 0;
        //    mainForm.ctrlLaser.ScGetMode(ref cur_Mode);
        //    cur_Mode |= (int)
        //    ScComSAMLightClientCtrlFlags.scComSAMLightClientCtrlModeFlagEntityNamesSeparatedBySemicolon;
        //    mainForm.ctrlLaser.ScSetMode(cur_Mode);

        //    SetEntityName(nLaserSplit);

        //    string fileName;
        //    SaveFileDialog saveFileDialog = new SaveFileDialog();
        //    saveFileDialog.Title = "";
        //    saveFileDialog.OverwritePrompt = true;
        //    saveFileDialog.Filter = "SAF (Scaps Archive File)|*.saf";

        //    fileName = mainForm.ribbonTextBox_split_drawing_path.TextBoxText;

        //    int nCount = 1;
        //    string Name = "";
        //    string FileName;
        //    string DirPath = fileName;

        //    DirectoryInfo di = new DirectoryInfo(DirPath);

        //    if (!di.Exists) Directory.CreateDirectory(DirPath);
        //    {
        //        System.IO.FileInfo[] files = di.GetFiles("*.*", SearchOption.AllDirectories);

        //        foreach (System.IO.FileInfo file in files)
        //            file.Delete();

        //        FileName = DirPath + "\\Project" + nCount.ToString() + ".saf";

        //        for (int i = 0; i < nLaserSplit; i++)
        //        {
        //            mainForm.ctrlLaser.ScGetIDStringData((int)
        //            ScComSAMLightClientCtrlFlags.scComSAMLightClientCtrlStringDataIdGetEntityName, i, ref Name);

        //            FileName = DirPath + "\\Project" + nCount.ToString() + ".saf";
        //            int flags = 0X10;
        //            flags |= 0x100;
        //            mainForm.ctrlLaser.ScExport(Name, FileName, "saf", 0.001, flags);
        //            nCount++;
        //        }
        //    }

        //    mainForm.ribbonTextBox_split_drawing_path.TextBoxText = DirPath;
        //}

        //public void SplitDrawingSaveAs()
        //{
        //    nLaserSplit = CountEntity();

        //    int cur_Mode = 0;
        //    mainForm.ctrlLaser.ScGetMode(ref cur_Mode);
        //    cur_Mode |= (int)
        //    ScComSAMLightClientCtrlFlags.scComSAMLightClientCtrlModeFlagEntityNamesSeparatedBySemicolon;
        //    mainForm.ctrlLaser.ScSetMode(cur_Mode);

        //    SetEntityName(nLaserSplit);

        //    string fileName;
        //    SaveFileDialog saveFileDialog = new SaveFileDialog();
        //    saveFileDialog.Title = "";
        //    saveFileDialog.OverwritePrompt = true;
        //    saveFileDialog.Filter = "SAF (Scaps Archive File)|*.saf";

        //    if (saveFileDialog.ShowDialog() == DialogResult.OK)
        //    {
        //        fileName = saveFileDialog.FileName;

        //        int nCount = 1;
        //        string Name = "";
        //        string FileName;
        //        string DirPath = fileName.Substring(0, fileName.Length - 4) + "_SPLIT";

        //        DirectoryInfo di = new DirectoryInfo(DirPath);

        //        if (!di.Exists) Directory.CreateDirectory(DirPath);
        //        {
        //            System.IO.FileInfo[] files = di.GetFiles("*.*", SearchOption.AllDirectories);

        //            foreach (System.IO.FileInfo file in files)
        //                file.Delete();

        //            FileName = DirPath + "\\Project" + nCount.ToString() + ".saf";

        //            for (int i = 0; i < nLaserSplit; i++)
        //            {
        //                mainForm.ctrlLaser.ScGetIDStringData((int)
        //                ScComSAMLightClientCtrlFlags.scComSAMLightClientCtrlStringDataIdGetEntityName, i, ref Name);

        //                FileName = DirPath + "\\Project" + nCount.ToString() + ".saf";
        //                int flags = 0X10;
        //                flags |= 0x100;
        //                mainForm.ctrlLaser.ScExport(Name, FileName, "saf", 0.001, flags);
        //                nCount++;
        //            }
        //        }

        //        mainForm.ribbonTextBox_split_drawing_path.TextBoxText = DirPath;
        //    }
        //}

        public int CountEntity()
        {
            int nEntityCount;
            nEntityCount = mainForm.ctrlLaser.ScGetLongValue((int)
                ScComSAMLightClientCtrlValueTypes.scComSAMLightClientCtrlLongValueTypeTopLevelEntityNum);

            return nEntityCount;
        }

        public void SetEntityName(int nEntity)
        {
            int cur_Mode = 0;
            mainForm.ctrlLaser.ScGetMode(ref cur_Mode);
            cur_Mode |= (int)
            ScComSAMLightClientCtrlFlags.scComSAMLightClientCtrlModeFlagTopLevelOnly;
            mainForm.ctrlLaser.ScSetMode(cur_Mode);

            string strEntityName;

            if (nEntity == 1)
            {
                mainForm.ctrlLaser.ScSetIDStringData((int)
                     ScComSAMLightClientCtrlFlags.scComSAMLightClientCtrlStringDataIdSetEntityName, 0, "Project");
            }

            else
            {
                for (int n = 0; n < nEntity; n++)
                {
                    strEntityName = "Project" + (n + 1).ToString();
                    mainForm.ctrlLaser.ScSetIDStringData((int)
                        ScComSAMLightClientCtrlFlags.scComSAMLightClientCtrlStringDataIdSetEntityName, n, strEntityName);
                }
            }

        }

        //public void openFile()
        //{
        //    CommonOpenFileDialog dialog = new CommonOpenFileDialog();

        //    dialog.IsFolderPicker = true;

        //    if (dialog.ShowDialog() == CommonFileDialogResult.Ok)
        //    {
        //        mainForm.ctrlLaser.ScExecCommand((int)ScComSAMLightClientCtrlExecCommandConstants.scComSAMLightClientCtrlExecCommandNewJob);

        //        string strLoadName;
        //        string strEntityName;

        //        DirectoryInfo di = new DirectoryInfo(dialog.FileName);

        //        int nCount = 0;
        //        foreach (FileInfo fileInfo in di.GetFiles("*.saf"))
        //        {
        //            try
        //            {
        //                nCount++;
        //            }
        //            catch (Exception ex)
        //            {
        //            }
        //        }

        //        for (int i = 0; i < nCount; i++)
        //        {
        //            strLoadName = dialog.FileName + "\\Project" + (i + 1).ToString() + ".saf";
        //            strEntityName = "Project" + (i + 1).ToString();

        //            mainForm.ctrlLaser.ScImport(strEntityName, strLoadName, "saf", 0.001, (int)
        //                ScComSAMLightClientCtrlFlags.scComSAMLightClientCtrlImportFlagReadPenInfo);
        //        }
        //        mainForm.ribbonTextBox_split_path.TextBoxText = dialog.FileName;
        //    }
        //}

        public void MoveDrawing(double dMoveX, double dMoveY, double dMoveT)
        {
            mainForm.ctrlLaser.ScTranslateEntity("", dMoveX, dMoveY, 0);

            mainForm.ctrlLaser.ScRotateEntity("", 0.0, 0.0, dMoveT);
        }

        public void TestLaserMaking()
        {
            nLaserSplit = CountEntity();

            if (nLaserSplit < 1)
                MessageBox.Show("DRAWING NOT FOUND", "RTRLASER");

            else
            {
                double Min_X, Min_Y, Max_X, Max_Y;
                Min_X = Min_Y = Max_X = Max_Y = 0.0;

                double Entity_Min_X, Entity_Max_X, Entity_Min_Y, Entity_Max_Y;
                Entity_Min_X = Entity_Max_X = Entity_Min_Y = Entity_Max_Y = 0.0;

                Min_X = mainForm.ctrlLaser.ScGetDoubleValue((int)
                    ScComSAMLightClientCtrlValueTypes.scComSAMLightClientCtrlDoubleValueTypeWorkingAreaMinX);
                Max_X = mainForm.ctrlLaser.ScGetDoubleValue((int)
                    ScComSAMLightClientCtrlValueTypes.scComSAMLightClientCtrlDoubleValueTypeWorkingAreaMaxX);
                Min_Y = mainForm.ctrlLaser.ScGetDoubleValue((int)
                    ScComSAMLightClientCtrlValueTypes.scComSAMLightClientCtrlDoubleValueTypeWorkingAreaMinY);
                Max_Y = mainForm.ctrlLaser.ScGetDoubleValue((int)
                    ScComSAMLightClientCtrlValueTypes.scComSAMLightClientCtrlDoubleValueTypeWorkingAreaMaxY);

                mainForm.ctrlLaser.ScGetEntityOutline2D("", ref Entity_Min_X, ref Entity_Min_Y, ref Entity_Max_X, ref Entity_Max_Y);

                if (Entity_Min_X < Min_X || Entity_Max_X > Max_X || Entity_Min_Y < Min_Y || Entity_Max_Y > Max_Y)
                {
                    MessageBox.Show("Working Area 를 벗어났습니다.");
                }

                else
                {
                    mainForm.ctrlLaser.ScMarkEntityByName("", 1);
                }

            }
        }

        public void EnableGuideLaser(bool nCase)
        {
            if (nCase == true)
            {
                uint Output_States = 0b_1111_1111_1111_1110_0000_0000_0000_0001;
                mainForm.ctrlLaser.ScSetLongValue((int)
                    ScComSAMLightClientCtrlValueTypes.scComSAMLightClientCtrlLongValueTypeOptoIO, (int)Output_States);
            }

            else
            {
                uint Output_States = 0b_1111_1111_1111_1110_0000_0000_0000_0000;
                mainForm.ctrlLaser.ScSetLongValue((int)
                    ScComSAMLightClientCtrlValueTypes.scComSAMLightClientCtrlLongValueTypeOptoIO, (int)Output_States);

            }
        }
    }
}
