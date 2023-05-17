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
using System.Threading;

using SAMLIGHT_CLIENT_CTRL_EXLib;

using System.IO;    // for write log

using Microsoft.Win32;

using System.Runtime.Remoting.Channels;
using System.Runtime.Remoting;


namespace RTRLASER
{
    public partial class FormMain : Form
    {
        public ScSamlightClientCtrlEx ctrlLaser;        // samlight 원격 제어

        // display 화면
        public FormAuto dlgAuto;
        public FormLaser dlgLaser;
        public FormVision dlgVision;
        public FormFieldCorrection dlgFC;
        public FormLog dlgLog;

        // 선택 Recipe (Vision)
        public int nSelectedRecipe;
        public string strSelectedRecipe;
        public int nSelectDisplay = 1;

        // plc 통신 관련 내용

        ActUtlTypeLib.ActUtlType _ActUtlType;

        // 스레드는 auto run 할 때만 확인할 수 있게 하자. 
        Thread PLCThread;     // Vision start, pos cmd

        private object lockObject = new object();

        public bool bCheckAuto = false;
        public bool bCheckFC = false;

        public bool bCheckPCAlive = false;

        public bool bVisionStartCmd = false;
        public bool bVisionPosCmd = false;
        public bool bVisionManualCmd = false;
        public bool bVisionPassCmd = false;
        public bool bVisionStopCmd = false;
        public bool bLaserStartCmd = false;
        public bool bLaserPosCmd = false;
        public bool bFCStartCmd = false;
        public bool bFCPosCmd = false;

        // process 관련 
        public int nVisionCount = 0;
        public int nLaserCount = 0;
        public int nFCCount = 0;

        public double dLimitXLow = 0.0;
        public double dLimitXHigh = 760.0;
        public double dLimitYLow = -50.0;
        public double dLimitYHigh = 810.0;

        public double dLaserCenterX = 0.0;
        public double dLaserCenterY = 0.0;

        public double dFCCenterX = 0.0;
        public double dFCCenterY = 0.0;

        public int nExposure1 = 1;
        public int nExposure2 = 1;

        public double dWorkingMinX = 0.0;
        public double dWorkingMinY = 0.0;
        public double dWorkingMaxX = 0.0;
        public double dWorkingMaxY = 0.0;

        public double dFieldMinX = 0.0;
        public double dFieldMinY = 0.0;
        public double dFieldMaxX = 0.0;
        public double dFieldMaxY = 0.0;

        public string strGreenLED = "D:\\RTRLASER\\RTRLASER\\res\\led_green.png";
        public string strRedLED = "D:\\RTRLASER\\RTRLASER\\res\\led_red.png";

        [DllImport("user32")]
        private static extern IntPtr SetParent(IntPtr childWindowHandle, IntPtr parentWindowHandle);

        [DllImport("user32")]
        private static extern bool MoveWindow(IntPtr hwnd, int x, int y, int cx, int cy, bool repaint);

        public void WriteLog(string strType, string strMessage, string strContents, string strRemark)
        {
            string DirPath = Environment.CurrentDirectory + @"\Log";
            string FilePath = DirPath + "\\Log_" + DateTime.Today.ToString("yyMMdd") + ".log";
            string temp;

            DirectoryInfo di = new DirectoryInfo(DirPath);
            FileInfo fi = new FileInfo(FilePath);

            try
            {
                if (!di.Exists) Directory.CreateDirectory(DirPath);
                if (!fi.Exists)
                {
                    using (StreamWriter sw = new StreamWriter(FilePath))
                    {
                        temp = string.Format("[{0}], [{1}], {2}, {3}, {4}", DateTime.Now, strType, strMessage, strContents, strRemark);
                        sw.WriteLine(temp);
                        sw.Close();
                    }
                }
                else
                {
                    using (StreamWriter sw = File.AppendText(FilePath))
                    {
                        temp = string.Format("[{0}], [{1}], {2}, {3}, {4}", DateTime.Now, strType, strMessage, strContents, strRemark);
                        sw.WriteLine(temp);
                        sw.Close();
                    }
                }
            }
            catch (Exception e)
            {

            }
        }

        public FormMain()
        {
            InitializeComponent();

            ctrlLaser = new ScSamlightClientCtrlEx();   // samlight 연결

            // 레지스트리 내 데이터 불러오기
            // 선택했던 Recipe, Laser Center X,Y
            RegistryKey reg;
            reg = Registry.CurrentUser.CreateSubKey("Software").CreateSubKey("RTR_SOFTWARE");

            nSelectedRecipe = 1;
            //nSelectedRecipe = Convert.ToInt16(reg.GetValue("Recipe", "값이 없습니다.").ToString());
            //dLaserCenterX = Convert.ToDouble(reg.GetValue("LaserCenterX", "값이 없습니다.").ToString());
            //dLaserCenterY = Convert.ToDouble(reg.GetValue("LaserCenterY", "값이 없습니다.").ToString());

            //dLimitXLow = Convert.ToDouble(reg.GetValue("Unit Limit X Low", "값이 없습니다.").ToString());
            //dLimitXHigh = Convert.ToDouble(reg.GetValue("Unit Limit X High", "값이 없습니다.").ToString());
            //dLimitYLow = Convert.ToDouble(reg.GetValue("Unit Limit Y Low", "값이 없습니다.").ToString());
            //dLimitYHigh = Convert.ToDouble(reg.GetValue("Unit Limit Y High", "값이 없습니다.").ToString());


            //dFCCenterX = Convert.ToDouble(reg.GetValue("FieldCorrectionCenterX", "값이 없습니다.").ToString());
            //dFCCenterY = Convert.ToDouble(reg.GetValue("FieldCorrectionCenterY", "값이 없습니다.").ToString());

            //nExposure1 = Convert.ToInt32(reg.GetValue("Exposure1", "값이 없습니다").ToString());
            //nExposure2 = Convert.ToInt32(reg.GetValue("Exposure2", "값이 없습니다").ToString());

            //dWorkingMinX = Convert.ToDouble(reg.GetValue("WorkingMinX", "값이 없습니다.").ToString());
            //dWorkingMinY = Convert.ToDouble(reg.GetValue("WorkingMinY", "값이 없습니다.").ToString());
            //dWorkingMaxX = Convert.ToDouble(reg.GetValue("WorkingMaxX", "값이 없습니다.").ToString());
            //dWorkingMaxY = Convert.ToDouble(reg.GetValue("WorkingMaxY", "값이 없습니다.").ToString());

            //dFieldMinX = Convert.ToDouble(reg.GetValue("FieldMinX", "값이 없습니다.").ToString());
            //dFieldMinY = Convert.ToDouble(reg.GetValue("FieldMinY", "값이 없습니다.").ToString());
            //dFieldMaxX = Convert.ToDouble(reg.GetValue("FieldMaxX", "값이 없습니다.").ToString());
            //dFieldMaxY = Convert.ToDouble(reg.GetValue("FieldMaxY", "값이 없습니다.").ToString());
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            InitClass();

            ConnectPLC();
            WriteLog("Normal", "Initialize", "MainForm Load Complete", "");
        }

        public void InitClass()
        {
            dlgAuto = new FormAuto(this);
            dlgLaser = new FormLaser(this);
            dlgVision = new FormVision(this);
            dlgFC = new FormFieldCorrection(this);
            dlgLog = new FormLog(this);

            ribbonTextBox_motion_limit_x_low.TextBoxText = dLimitXLow.ToString();
            ribbonTextBox_motion_limit_x_high.TextBoxText = dLimitXHigh.ToString();
            ribbonTextBox_motion_limit_y_low.TextBoxText = dLimitYLow.ToString();
            ribbonTextBox_motion_limit_y_high.TextBoxText = dLimitYHigh.ToString();

            ribbonTextBox_laser_center_x.TextBoxText = dLaserCenterX.ToString();
            ribbonTextBox_laser_center_y.TextBoxText = dLaserCenterY.ToString();

            ribbonTextBox_fc_param_center_x.TextBoxText = dFCCenterX.ToString();
            ribbonTextBox_fc_param_center_y.TextBoxText = dFCCenterY.ToString();

            ribbonUpDown_vision_camera_exposure_1.TextBoxText = nExposure1.ToString();
            ribbonUpDown_vision_camera_exposure_2.TextBoxText = nExposure2.ToString();

            dlgVision.DisplaySetting(dlgVision.nSelectedAlign);
            dlgVision.DisplayRecipeName(nSelectedRecipe);

            dlgFC.DisplaySetting();

            //uint Output_States = 0b_1111_1111_1111_1110_0000_0000_0000_0000;
            //ctrlLaser.ScSetLongValue((int)
            //    ScComSAMLightClientCtrlValueTypes.scComSAMLightClientCtrlLongValueTypeOptoIO, (int)Output_States);

            //ctrlLaser.ScSetFieldSizeAndWorkingArea(dFieldMaxX - dFieldMinX, (dFieldMaxX + dFieldMinX) / 2, (dFieldMaxY + dFieldMinY) / 2,
            //    dWorkingMinX, dWorkingMinY, dWorkingMaxX, dWorkingMaxY);


            DisplayChange(1);

            WriteLog("Error", "Initialize", "MainForm Load Complete", "");
        }

        public void ConnectPLC()
        {
            PLCThread = new Thread(_PLC_Elapsed);

            ThreadStart();

        }

        public void ThreadStart()
        {
            PLCThread.Start();
        }

        public void _PLC_Elapsed()
        {
            _ActUtlType = new ActUtlTypeLib.ActUtlType();
            _ActUtlType.ActLogicalStationNumber = Convert.ToInt32("0");

            if (_ActUtlType.Open().Equals(0))
            {
                while (true)
                {
                    while (bCheckAuto)
                    {
                        int nVisionStartValue = 0;
                        int nVisionPosValue = 0;
                        int nLaserStartValue = 0;
                        int nLaserPosValue = 0;
                        int nVisionManual = 0;
                        int nVisionPass = 0;
                        int nVisionStop = 0;

                        _ActUtlType.GetDevice("D7001", out nVisionStartValue);
                        _ActUtlType.GetDevice("D7002", out nVisionPosValue);
                        _ActUtlType.GetDevice("D7010", out nLaserStartValue);
                        _ActUtlType.GetDevice("D7011", out nLaserPosValue);
                        _ActUtlType.GetDevice("D7020", out nVisionManual);
                        _ActUtlType.GetDevice("D7021", out nVisionPass);
                        _ActUtlType.GetDevice("D7022", out nVisionStop);

                        // Vision Start
                        if (nVisionStartValue == 1)
                        {
                            CommunicatinoPLC(dlgAuto.pictureBox_auto_cmd_vision_start, strGreenLED);

                            if (!bVisionStartCmd)
                            {
                                if (nVisionCount == 0)
                                    dlgAuto.CreateDirAlignData();   // 현재 시간에 대한 폴더 생성
                                                                    // VISION 결과 들 초기화
                                bVisionStartCmd = true;         // 한번만 수행할 수 있도록

                                // VISION POS DATA SET
                                dlgAuto.union.intValue = (uint)(dlgVision.stAlign[nVisionCount].dUnitX * 1000);
                                _ActUtlType.SetDevice("D7506", dlgAuto.union.shortValue_high);
                                _ActUtlType.SetDevice("D7505", dlgAuto.union.shortValue_low);
                                CommunicatinoPLC(dlgAuto.pictureBox_auto_reply_vision_data_x, strGreenLED);

                                dlgAuto.union.intValue = (uint)(dlgVision.stAlign[nVisionCount].dUnitY * 1000);
                                _ActUtlType.SetDevice("D7508", dlgAuto.union.shortValue_high);
                                _ActUtlType.SetDevice("D7507", dlgAuto.union.shortValue_low);
                                CommunicatinoPLC(dlgAuto.pictureBox_auto_reply_vision_data_y, strGreenLED);

                                // data set delay
                                Thread.Sleep(500);

                                // VISION ALIGN START CMD REPLY
                                _ActUtlType.SetDevice("D7501", 1);
                                CommunicatinoPLC(dlgAuto.pictureBox_auto_reply_vision_start, strGreenLED);
                            }
                        }

                        else
                        {
                            CommunicatinoPLC(dlgAuto.pictureBox_auto_cmd_vision_start, strRedLED);
                            _ActUtlType.SetDevice("D7501", 0);
                            CommunicatinoPLC(dlgAuto.pictureBox_auto_reply_vision_start, strRedLED);
                            CommunicatinoPLC(dlgAuto.pictureBox_auto_reply_vision_data_x, strRedLED);
                            CommunicatinoPLC(dlgAuto.pictureBox_auto_reply_vision_data_y, strRedLED);

                            bVisionStartCmd = false;            // 0이 되면 다시 1이 올때까지 대기
                        }

                        // Vision Pos
                        if (nVisionPosValue == 1)
                        {
                            CommunicatinoPLC(dlgAuto.pictureBox_auto_cmd_vision_pos, strGreenLED);

                            if (!bVisionPosCmd)
                            {
                                // edge align의 경우 한번에 좌, 우 진행
                                if (dlgVision.bCheckAlignEdge)
                                {
                                    dlgVision.stResult[nVisionCount].bCheckOriginSave = true;
                                    dlgVision.FindEdge(nVisionCount);
                                    dlgVision.stResult[nVisionCount].bCheckAlignComplete = true;

                                    if (nVisionCount == 0)
                                        dlgAuto.button_auto_result_align1.BackColor = Color.LimeGreen;

                                    else if (nVisionCount == 2)
                                        dlgAuto.button_auto_result_align3.BackColor = Color.LimeGreen;

                                    nVisionCount++;

                                    dlgVision.stResult[nVisionCount].bCheckOriginSave = true;
                                    Thread.Sleep(500);
                                    dlgVision.FindEdge(nVisionCount);
                                    dlgVision.stResult[nVisionCount].bCheckAlignComplete = true;

                                    if (nVisionCount == 1)
                                        dlgAuto.button_auto_result_align2.BackColor = Color.LimeGreen;

                                    else if (nVisionCount == 3)
                                        dlgAuto.button_auto_result_align4.BackColor = Color.LimeGreen;

                                    nVisionCount++;

                                    _ActUtlType.SetDevice("D7502", 1);      // VISION COMPLETE
                                    CommunicatinoPLC(dlgAuto.pictureBox_auto_reply_vision_complete, strGreenLED);
                                }

                                else if (dlgVision.bCheckAlignMark)
                                {
                                    dlgVision.stResult[nVisionCount].bCheckOriginSave = true;
                                    dlgVision.FindMark(nVisionCount);
                                    dlgVision.stResult[nVisionCount].bCheckAlignComplete = true;

                                    if (nVisionCount == 0)
                                    {
                                        if (dlgVision.stResult[nVisionCount].bAlignJudge)
                                            dlgAuto.button_auto_result_align1.BackColor = Color.LimeGreen;

                                        else
                                            dlgAuto.button_auto_result_align1.BackColor = Color.DarkRed;
                                    }

                                    else if (nVisionCount == 1)
                                    {
                                        if (dlgVision.stResult[nVisionCount].bAlignJudge)
                                            dlgAuto.button_auto_result_align2.BackColor = Color.LimeGreen;

                                        else
                                            dlgAuto.button_auto_result_align2.BackColor = Color.DarkRed;
                                    }

                                    else if (nVisionCount == 2)
                                    {
                                        if (dlgVision.stResult[nVisionCount].bAlignJudge)
                                            dlgAuto.button_auto_result_align3.BackColor = Color.LimeGreen;

                                        else
                                            dlgAuto.button_auto_result_align3.BackColor = Color.DarkRed;
                                    }

                                    else if (nVisionCount == 3)
                                    {
                                        if (dlgVision.stResult[nVisionCount].bAlignJudge)
                                            dlgAuto.button_auto_result_align4.BackColor = Color.LimeGreen;

                                        else
                                            dlgAuto.button_auto_result_align4.BackColor = Color.DarkRed;
                                    }

                                    nVisionCount++;

                                    if (nVisionCount < 4)
                                    {
                                        _ActUtlType.SetDevice("D7502", 1);      // VISION COMPLETE
                                        CommunicatinoPLC(dlgAuto.pictureBox_auto_reply_vision_complete, strGreenLED);
                                    }
                                }

                                // com 신호 주어야 한다 .
                                if (nVisionCount == 4)
                                {
                                    bool bRet = dlgVision.AlignCalculation();
                                    Thread.Sleep(500);

                                    dlgAuto.CheckProcessInfo();

                                    if (bRet == true)
                                    {
                                        // ALIGN END
                                        _ActUtlType.SetDevice("D7503", 1);      // VISION END
                                        CommunicatinoPLC(dlgAuto.pictureBox_auto_reply_vision_end, strGreenLED);
                                        Thread.Sleep(500);

                                        dlgAuto.applyAlignValue();
                                    }

                                    else
                                    {
                                        _ActUtlType.SetDevice("D7504", 1);      // VISION NG
                                        CommunicatinoPLC(dlgAuto.pictureBox_auto_reply_vision_ng, strGreenLED);
                                        Thread.Sleep(500);
                                    }

                                    nVisionCount = 0;
                                }

                                bVisionPosCmd = true;
                            }
                        }

                        else
                        {
                            CommunicatinoPLC(dlgAuto.pictureBox_auto_cmd_vision_pos, strRedLED);

                            bVisionPosCmd = false;
                            _ActUtlType.SetDevice("D7502", 0);  // VISION COMPLETE
                            _ActUtlType.SetDevice("D7503", 0);  // VISION END
                            _ActUtlType.SetDevice("D7504", 0);  // VISION NG

                            CommunicatinoPLC(dlgAuto.pictureBox_auto_reply_vision_complete, strRedLED);
                            CommunicatinoPLC(dlgAuto.pictureBox_auto_reply_vision_end, strRedLED);
                            CommunicatinoPLC(dlgAuto.pictureBox_auto_reply_vision_ng, strRedLED);
                        }

                        // manual align cmd
                        if (nVisionManual == 1)
                        {
                            if (!bVisionManualCmd)
                            {
                                CommunicatinoPLC(dlgAuto.pictureBox_auto_cmd_vision_manual, strGreenLED);

                                _ActUtlType.SetDevice("D7520", 1);      // VISION MANUAL
                                CommunicatinoPLC(dlgAuto.pictureBox_auto_reply_vision_manual, strGreenLED);

                                FormManualAlign dlgManual = new FormManualAlign();
                                DialogResult result = DialogResult.None;

                                dlgManual.strPath = dlgAuto.DirTime + "\\Origin";
                                dlgManual.dDistance = dlgVision.dDistance;

                                for (int i = 0; i < 4; i++)
                                {
                                    dlgManual.stResult[i].pMarkAlignStartPoint = dlgVision.stResult[i].pMarkAlignStartPoint;
                                    dlgManual.stResult[i].pMarkAlignDimension = dlgVision.stResult[i].pMarkAlignDimension;
                                    dlgManual.stResult[i].pAlignResult = dlgVision.stResult[i].pAlignResult;
                                    dlgManual.stResult[i].pManualAlignResult = dlgVision.stResult[i].pAlignResult;
                                    dlgManual.stResult[i].bAlignJudge = dlgVision.stResult[i].bAlignJudge;
                                    dlgManual.stResult[i].dUnitX = dlgVision.stAlign[i].dUnitX;
                                    dlgManual.stResult[i].dUnitY = dlgVision.stAlign[i].dUnitY;
                                }

                                dlgManual.DisplayParameter();
                                this.Invoke((MethodInvoker)delegate { result = dlgManual.ShowDialog(); });

                                if (result == DialogResult.OK)
                                {
                                    dlgAuto.label_auto_result_modify_x_value.Invoke(new EventHandler(delegate
                                    { dlgAuto.label_auto_result_modify_x_value.Text = dlgManual.dApplyModifyX.ToString("F2") + "mm"; }));

                                    dlgAuto.label_auto_result_modify_y_value.Invoke(new EventHandler(delegate
                                    { dlgAuto.label_auto_result_modify_y_value.Text = dlgManual.dApplyModifyY.ToString("F2") + "mm"; }));

                                    dlgAuto.label_auto_result_modify_t_value.Invoke(new EventHandler(delegate
                                    { dlgAuto.label_auto_result_modify_t_value.Text = dlgManual.dApplyModifyT.ToString("F3") + "˚"; }));

                                    dlgAuto.dAutoModifyX = dlgManual.dApplyModifyX;
                                    dlgAuto.dAutoModifyY = dlgManual.dApplyModifyY;
                                    dlgAuto.dAutoModifyT = dlgManual.dApplyModifyT;

                                    dlgAuto.applyAlignValue();
                                }

                                dlgManual.Dispose();

                                _ActUtlType.SetDevice("D7503", 1);      // VISION END
                                CommunicatinoPLC(dlgAuto.pictureBox_auto_reply_vision_end, strGreenLED);

                                bVisionManualCmd = true;
                            }
                        }

                        else
                        {
                            CommunicatinoPLC(dlgAuto.pictureBox_auto_cmd_vision_manual, strRedLED);

                            _ActUtlType.SetDevice("D7520", 0);      // VISION MANUAL
                            CommunicatinoPLC(dlgAuto.pictureBox_auto_reply_vision_manual, strRedLED);

                            _ActUtlType.SetDevice("D7504", 0);  // VISION NG
                            CommunicatinoPLC(dlgAuto.pictureBox_auto_reply_vision_ng, strRedLED);

                            bVisionManualCmd = false;

                        }

                        // ALIGN PASS CMD
                        if (nVisionPass == 1)
                        {
                            if (!bVisionPassCmd)
                            {
                                dlgAuto.label_auto_result_modify_x_value.Invoke(new EventHandler(delegate
                                { dlgAuto.label_auto_result_modify_x_value.Text = "0.00mm"; }));

                                dlgAuto.label_auto_result_modify_y_value.Invoke(new EventHandler(delegate
                                { dlgAuto.label_auto_result_modify_y_value.Text = "0.00mm"; }));

                                dlgAuto.label_auto_result_modify_t_value.Invoke(new EventHandler(delegate
                                { dlgAuto.label_auto_result_modify_t_value.Text = "0.000˚"; }));

                                dlgAuto.dAutoModifyX = 0.0;
                                dlgAuto.dAutoModifyY = 0.0;
                                dlgAuto.dAutoModifyT = 0.0;

                                CommunicatinoPLC(dlgAuto.pictureBox_auto_cmd_vision_pass, strGreenLED);
                                _ActUtlType.SetDevice("D7521", 1);

                                bVisionPassCmd = true;
                            }
                        }
                        else
                        {
                            CommunicatinoPLC(dlgAuto.pictureBox_auto_cmd_vision_pass, strRedLED);

                            _ActUtlType.SetDevice("D7521", 0);
                            CommunicatinoPLC(dlgAuto.pictureBox_auto_reply_vision_pass, strRedLED);

                            bVisionPassCmd = false;
                        }

                        // PROCESS STOP CMD
                        if (nVisionStop == 1)
                        {
                            if (!bVisionStopCmd)
                            {
                                dlgAuto.dAutoModifyX = 0.0;
                                dlgAuto.dAutoModifyY = 0.0;
                                dlgAuto.dAutoModifyT = 0.0;

                                CommunicatinoPLC(dlgAuto.pictureBox_auto_cmd_vision_stop, strGreenLED);

                                _ActUtlType.SetDevice("D7522", 1);

                                bVisionStopCmd = true;
                            }
                        }

                        else
                        {
                            CommunicatinoPLC(dlgAuto.pictureBox_auto_cmd_vision_stop, strRedLED);

                            _ActUtlType.SetDevice("D7522", 0);
                            CommunicatinoPLC(dlgAuto.pictureBox_auto_reply_vision_stop, strRedLED);

                            bVisionStopCmd = false;
                        }

                        // Laser Start
                        if (nLaserStartValue == 1)
                        {
                            CommunicatinoPLC(dlgAuto.pictureBox_auto_cmd_laser_start, strGreenLED);

                            if (!bLaserStartCmd)
                            {
                                if (!ribbonCheckBox_marking_align.Checked)
                                {
                                    dlgAuto.CheckProcessInfo();
                                }


                                dlgAuto.laserMarkingPosition();
                                bLaserStartCmd = true;

                                if (!dlgAuto.stProcess[nLaserCount].bLaserProcess)
                                {
                                    for (int i = nLaserCount; i < dlgAuto.nLaserSplit; i++)
                                    {
                                        if (dlgAuto.stProcess[i].bLaserProcess)
                                        {
                                            nLaserCount = i;
                                            break;
                                        }
                                    }
                                }

                                // LASER POS DATA SET
                                dlgAuto.union.intValue = (uint)(dlgAuto.stProcess[nLaserCount].dMarkingPosX * 1000);
                                _ActUtlType.SetDevice("D7515", dlgAuto.union.shortValue_high);
                                _ActUtlType.SetDevice("D7514", dlgAuto.union.shortValue_low);
                                CommunicatinoPLC(dlgAuto.pictureBox_auto_reply_laser_data_x, strGreenLED);

                                ribbonTextBox_auto_laser_position_x.TextBoxText = dlgAuto.stProcess[nLaserCount].dMarkingPosX.ToString("F3");

                                dlgAuto.union.intValue = (uint)(dlgAuto.stProcess[nLaserCount].dMarkingPosY * 1000);
                                _ActUtlType.SetDevice("D7517", dlgAuto.union.shortValue_high);
                                _ActUtlType.SetDevice("D7516", dlgAuto.union.shortValue_low);
                                CommunicatinoPLC(dlgAuto.pictureBox_auto_reply_laser_data_y, strGreenLED);

                                ribbonTextBox_auto_laser_position_y.TextBoxText = dlgAuto.stProcess[nLaserCount].dMarkingPosY.ToString("F3");

                                // LASER START CMD REPLY
                                _ActUtlType.SetDevice("D7510", 1);
                                CommunicatinoPLC(dlgAuto.pictureBox_auto_reply_laser_start, strGreenLED);
                            }
                        }

                        else
                        {
                            CommunicatinoPLC(dlgAuto.pictureBox_auto_cmd_laser_start, strRedLED);
                            _ActUtlType.SetDevice("D7510", 0);

                            CommunicatinoPLC(dlgAuto.pictureBox_auto_reply_laser_start, strRedLED);
                            CommunicatinoPLC(dlgAuto.pictureBox_auto_reply_laser_data_x, strRedLED);
                            CommunicatinoPLC(dlgAuto.pictureBox_auto_reply_laser_data_y, strRedLED);

                            bLaserStartCmd = false;            // 0이 되면 다시 1이 올때까지 대기
                        }

                        // Laser Pos
                        if (nLaserPosValue == 1)
                        {
                            CommunicatinoPLC(dlgAuto.pictureBox_auto_cmd_laser_pos, strGreenLED);

                            if (!bLaserPosCmd)
                            {
                                dlgAuto.laserMarking(nLaserCount);
                                nLaserCount++;

                                if (nLaserCount < dlgAuto.nLaserSplit)
                                {
                                    if (!dlgAuto.stProcess[nLaserCount].bLaserProcess)
                                    {
                                        for (int i = nLaserCount; i < dlgAuto.nLaserSplit; i++)
                                        {
                                            if (dlgAuto.stProcess[i].bLaserProcess)
                                            {
                                                nLaserCount = i;
                                                break;
                                            }

                                            if (i == dlgAuto.nLaserSplit - 1)
                                                nLaserCount = dlgAuto.nLaserSplit;
                                        }
                                    }
                                }


                                if (nLaserCount < dlgAuto.nLaserSplit)
                                {

                                    _ActUtlType.SetDevice("D7511", 1);      // MARKING COMPLETE
                                    CommunicatinoPLC(dlgAuto.pictureBox_auto_reply_laser_complete, strGreenLED);
                                }

                                // laser com 신호를 넘겨주어야 한다. 
                                else if (nLaserCount >= dlgAuto.nLaserSplit)
                                {
                                    ctrlLaser.ScSetEntityLongData("", (int)
                                        ScComSAMLightClientCtrlFlags.scComSAMLightClientCtrlLongDataIdEntitySelected, 1);


                                    _ActUtlType.SetDevice("D7512", 1);      // MARKING END
                                    CommunicatinoPLC(dlgAuto.pictureBox_auto_reply_laser_end, strGreenLED);
                                    Thread.Sleep(500);

                                    nLaserCount = 0;
                                }
                                bLaserPosCmd = true;
                            }
                        }

                        else
                        {
                            CommunicatinoPLC(dlgAuto.pictureBox_auto_cmd_laser_pos, strRedLED);

                            _ActUtlType.SetDevice("D7511", 0);  // LASER COMPLETE
                            _ActUtlType.SetDevice("D7512", 0);  // LASER END
                            _ActUtlType.SetDevice("D7513", 0);  // LASER NG

                            CommunicatinoPLC(dlgAuto.pictureBox_auto_reply_laser_complete, strRedLED);
                            CommunicatinoPLC(dlgAuto.pictureBox_auto_reply_laser_end, strRedLED);
                            CommunicatinoPLC(dlgAuto.pictureBox_auto_reply_laser_ng, strRedLED);

                            bLaserPosCmd = false;
                        }
                    }

                    while (bCheckFC)
                    {
                        int nFCStartValue = 0;
                        int nFCPosValue = 0;
                        _ActUtlType.GetDevice("D7030", out nFCStartValue);
                        _ActUtlType.GetDevice("D7031", out nFCPosValue);

                        // Field Correction Start
                        if (nFCStartValue == 1)
                        {
                            if (!bFCStartCmd)
                            {
                                //dlgFC.laserMarkingPosition();
                                bFCStartCmd = true;

                                dlgFC.union.intValue = (uint)(dlgFC.stFC[nFCCount].dMarkingPosX * 1000);
                                _ActUtlType.SetDevice("D7535", dlgFC.union.shortValue_high);
                                _ActUtlType.SetDevice("D7534", dlgFC.union.shortValue_low);

                                dlgFC.union.intValue = (uint)(dlgFC.stFC[nFCCount].dMarkingPosY * 1000);
                                _ActUtlType.SetDevice("D7537", dlgFC.union.shortValue_high);
                                _ActUtlType.SetDevice("D7536", dlgFC.union.shortValue_low);

                                _ActUtlType.SetDevice("D7530", 1);
                            }
                        }

                        else
                        {
                            _ActUtlType.SetDevice("D7530", 0);

                            bFCStartCmd = false;            // 0이 되면 다시 1이 올때까지 대기
                        }

                        if (nFCPosValue == 1)
                        {
                            CommunicatinoPLC(dlgAuto.pictureBox_auto_cmd_laser_pos, strGreenLED);

                            if (!bFCPosCmd)
                            {
                                dlgFC.fc_marking(nFCCount);
                                nFCCount++;

                                if (nFCCount < dlgFC.nPoint * dlgFC.nPoint)
                                {
                                    _ActUtlType.SetDevice("D7531", 1);      // MARKING COMPLETE
                                    CommunicatinoPLC(dlgAuto.pictureBox_auto_reply_laser_complete, strGreenLED);
                                }

                                else if (nFCCount >= dlgFC.nPoint * dlgFC.nPoint)
                                {
                                    _ActUtlType.SetDevice("D7532", 1);      // MARKING END
                                    Thread.Sleep(500);

                                    dlgFC.button_fc_result_save.Invoke(new EventHandler(delegate { dlgFC.button_fc_result_save.Enabled = true; }));

                                    nFCCount = 0;
                                }
                                bFCPosCmd = true;
                            }
                        }

                        else
                        {
                            CommunicatinoPLC(dlgAuto.pictureBox_auto_cmd_laser_pos, strRedLED);

                            _ActUtlType.SetDevice("D7531", 0);  // FCCOMPLETE
                            _ActUtlType.SetDevice("D7532", 0);  // FC END
                            _ActUtlType.SetDevice("D7533", 0);  // FC NG

                            bFCPosCmd = false;
                        }
                    }
                }
            }
            else
                MessageBox.Show("PLC 연결 실패");

        }

        public void CommunicatinoPLC(PictureBox picBox, string strLED)
        {
            picBox.Invoke(new EventHandler(delegate { picBox.Image = System.Drawing.Image.FromFile(strLED); }));
        }

        private void FormMain_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Alt && e.KeyCode == Keys.F4)
            {
                if ((int)dlgVision.nMagni == 2)
                {
                    dlgVision.nMagni = 1;

                    dlgVision.pManualMarkStart.X = dlgVision.pManualMarkStart.X * 2;
                    dlgVision.pManualMarkStart.Y = dlgVision.pManualMarkStart.Y * 2;
                    dlgVision.pManualMarkDimension.X = dlgVision.pManualMarkDimension.X * 2;
                    dlgVision.pManualMarkDimension.Y = dlgVision.pManualMarkDimension.Y * 2;
                }

                else if ((int)dlgVision.nMagni == 4)
                {
                    dlgVision.nMagni = 1;

                    dlgVision.pManualMarkStart.X = dlgVision.pManualMarkStart.X * 4;
                    dlgVision.pManualMarkStart.Y = dlgVision.pManualMarkStart.Y * 4;
                    dlgVision.pManualMarkDimension.X = dlgVision.pManualMarkDimension.X * 4;
                    dlgVision.pManualMarkDimension.Y = dlgVision.pManualMarkDimension.Y * 4;
                }

                dlgVision.pictureBox_vision_focus.Size = new System.Drawing.Size(2448, 2048);

                ribbonUpDown_vision_camera_magni.TextBoxText = "1";

                e.Handled = true;

                if (MessageBox.Show("프로그램을 종료하시겠습니까", "RTR LASER", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    dlgVision.mDevicea[0].RemoteNodeList["AcquisitionAbort"].Execute();
                    dlgVision.mDevicea[0].RemoteNodeList["AcquisitionStop"].Execute();

                    dlgVision.mDevicea[1].RemoteNodeList["AcquisitionAbort"].Execute();
                    dlgVision.mDevicea[1].RemoteNodeList["AcquisitionStop"].Execute();

                    if (ribbonCheckBox_marking_guide.Checked)
                    {
                        uint Output_States = 0b_1111_1111_1111_1110_0000_0000_0000_0000;
                        ctrlLaser.ScSetLongValue((int)
                            ScComSAMLightClientCtrlValueTypes.scComSAMLightClientCtrlLongValueTypeOptoIO, (int)Output_States);
                    }

                    // 현재 저장된 Recipe 값을 레지스트리에 저장
                    RegistryKey reg;
                    reg = Registry.CurrentUser.CreateSubKey("Software").CreateSubKey("RTR_SOFTWARE");

                    reg.SetValue("Recipe", nSelectedRecipe.ToString(), RegistryValueKind.String);
                    reg.SetValue("LaserCenterX", dLaserCenterX.ToString(), RegistryValueKind.String);
                    reg.SetValue("LaserCenterY", dLaserCenterY.ToString(), RegistryValueKind.String);

                    reg.SetValue("Unit Limit X Low", dLimitXLow.ToString(), RegistryValueKind.String);
                    reg.SetValue("Unit Limit X High", dLimitXHigh.ToString(), RegistryValueKind.String);
                    reg.SetValue("Unit Limit Y Low", dLimitYLow.ToString(), RegistryValueKind.String);
                    reg.SetValue("Unit Limit Y High", dLimitYHigh.ToString(), RegistryValueKind.String);

                    reg.SetValue("FieldCorrectionCenterX", dFCCenterX.ToString(), RegistryValueKind.String);
                    reg.SetValue("FieldCorrectionCenterY", dFCCenterY.ToString(), RegistryValueKind.String);

                    reg.SetValue("Exposure1", nExposure1.ToString(), RegistryValueKind.String);
                    reg.SetValue("Exposure2", nExposure2.ToString(), RegistryValueKind.String);

                    // 현재 working area
                    reg.SetValue("WorkingMinX", ctrlLaser.ScGetWorkingArea(0x0).ToString(), RegistryValueKind.String);
                    reg.SetValue("WorkingMinY", ctrlLaser.ScGetWorkingArea(0x1).ToString(), RegistryValueKind.String);
                    reg.SetValue("WorkingMaxX", ctrlLaser.ScGetWorkingArea(0x3).ToString(), RegistryValueKind.String);
                    reg.SetValue("WorkingMaxY", ctrlLaser.ScGetWorkingArea(0x4).ToString(), RegistryValueKind.String);

                    // 현재 Field Size
                    reg.SetValue("FieldMinX", ctrlLaser.ScGetDoubleValue((int)ScComSAMLightClientCtrlValueTypes.scComSAMLightClientCtrlDoubleValueTypeFieldMinX).ToString(), RegistryValueKind.String);
                    reg.SetValue("FieldMinY", ctrlLaser.ScGetDoubleValue((int)ScComSAMLightClientCtrlValueTypes.scComSAMLightClientCtrlDoubleValueTypeFieldMinY).ToString(), RegistryValueKind.String);
                    reg.SetValue("FieldMaxX", ctrlLaser.ScGetDoubleValue((int)ScComSAMLightClientCtrlValueTypes.scComSAMLightClientCtrlDoubleValueTypeFieldMaxX).ToString(), RegistryValueKind.String);
                    reg.SetValue("FieldMaxY", ctrlLaser.ScGetDoubleValue((int)ScComSAMLightClientCtrlValueTypes.scComSAMLightClientCtrlDoubleValueTypeFieldMaxY).ToString(), RegistryValueKind.String);

                    PLCThread.Abort();

                    _ActUtlType.Close();

                    if (Application.MessageLoop == true)
                        Application.Exit();
                    else
                        Environment.Exit(1);
                }
                else
                {
                    dlgVision.mDevicea[0].RemoteNodeList["AcquisitionStart"].Execute(); ;
                    dlgVision.mDevicea[1].RemoteNodeList["AcquisitionStart"].Execute();
                }
            }
        }

        private void ribbon_menu_ActiveTabChanged_1(object sender, EventArgs e)
        {
            string strTab = ribbon_menu.ActiveTab.ToString();

            int nCheckSameValue = nSelectDisplay;

            if (strTab == "Tab: Laser")
                nSelectDisplay = 1;

            else if (strTab == "Tab: Vision")
                nSelectDisplay = 2;

            else if (strTab == "Tab: Auto")
                nSelectDisplay = 0;

            else if (strTab == "Tab: FieldCorrection")
                nSelectDisplay = 3;

            else if (strTab == "Tab: Log")
                nSelectDisplay = 4;

            if ((int)nCheckSameValue == (int)nSelectDisplay)
            {

            }

            else
            {
                //if (nSelectDisplay != 0)
                DisplayChange(nSelectDisplay);
            }

        }

        public void DisplayChange(int nCase)
        {
            if (nCase == 0)
            {
                dlgAuto.Focus();

                dlgAuto.WindowState = FormWindowState.Maximized;
                dlgLaser.WindowState = FormWindowState.Minimized;
                dlgVision.WindowState = FormWindowState.Minimized;
                dlgFC.WindowState = FormWindowState.Minimized;
                dlgLog.WindowState = FormWindowState.Minimized;

                // RECIPE 등을 기록
                ribbonTextBox_auto_vision_recipe_num.TextBoxText = nSelectedRecipe.ToString();
                ribbonTextBox_auto_vision_recipe_name.TextBoxText = dlgVision.DisplayRecipeName(nSelectedRecipe);

                // POSITION
                ribbonTextBox_auto_vision_position_x_1.TextBoxText = dlgVision.stAlign[0].dUnitX.ToString();
                ribbonTextBox_auto_vision_position_x_2.TextBoxText = dlgVision.stAlign[1].dUnitX.ToString();
                ribbonTextBox_auto_vision_position_x_3.TextBoxText = dlgVision.stAlign[2].dUnitX.ToString();
                ribbonTextBox_auto_vision_position_x_4.TextBoxText = dlgVision.stAlign[3].dUnitX.ToString();
                ribbonTextBox_auto_vision_position_y_1.TextBoxText = dlgVision.stAlign[0].dUnitY.ToString();
                ribbonTextBox_auto_vision_position_y_2.TextBoxText = dlgVision.stAlign[1].dUnitY.ToString();
                ribbonTextBox_auto_vision_position_y_3.TextBoxText = dlgVision.stAlign[2].dUnitY.ToString();
                ribbonTextBox_auto_vision_position_y_4.TextBoxText = dlgVision.stAlign[3].dUnitY.ToString();

                if (!ribbonCheckBox_split_enable.Checked)
                {
                    ribbonTextBox_auto_laser_position_x.TextBoxText = dLaserCenterX.ToString();
                    ribbonTextBox_auto_laser_position_y.TextBoxText = dLaserCenterY.ToString();
                }

                else
                {
                    ribbonTextBox_auto_laser_position_x.TextBoxText = "-";
                    ribbonTextBox_auto_laser_position_y.TextBoxText = "-";
                }

                if (dlgVision.bCheckAlignEdge)
                {
                    ribbonRadioBox_auto_align_edge.Checked = true;
                    ribbonRadioBox_auto_align_mark.Checked = false;
                }

                else if (dlgVision.bCheckAlignMark)
                {
                    ribbonRadioBox_auto_align_edge.Checked = false;
                    ribbonRadioBox_auto_align_mark.Checked = true;
                }

                // COMMON
                ribbonTextBox_auto_align_distance.TextBoxText = dlgVision.dDistance.ToString();
                ribbonTextBox_auto_align_range_x.TextBoxText = dlgVision.dAlignRangeX.ToString();
                ribbonTextBox_auto_align_range_y.TextBoxText = dlgVision.dAlignRangeY.ToString();
                ribbonTextBox_auto_align_range_t.TextBoxText = dlgVision.dAlignRangeT.ToString();

                // EDGE
                ribbonTextBox_auto_align_edge_level.TextBoxText = dlgVision.nEdgeLevel.ToString();
                ribbonTextBox_auto_align_edge_miss.TextBoxText = dlgVision.nEdgeMiss.ToString();

                // MARK
                ribbonTextBox_auto_align_mark_matchrate_1.TextBoxText = dlgVision.stAlign[0].dMatchrate.ToString();
                ribbonTextBox_auto_align_mark_matchrate_2.TextBoxText = dlgVision.stAlign[1].dMatchrate.ToString();
                ribbonTextBox_auto_align_mark_matchrate_3.TextBoxText = dlgVision.stAlign[2].dMatchrate.ToString();
                ribbonTextBox_auto_align_mark_matchrate_4.TextBoxText = dlgVision.stAlign[3].dMatchrate.ToString();

                SetParent(dlgLaser.pLaser.MainWindowHandle, dlgAuto.panel_laser.Handle);
                MoveWindow(dlgLaser.pLaser.MainWindowHandle, -182, -145, dlgAuto.panel_laser.Width + 492, dlgAuto.panel_laser.Height + 195, true);

                ctrlLaser.ScExecCommand((int)
                    ScComSAMLightClientCtrlExecCommandConstants.scComSAMLightClientCtrlExecCommandFitViewToWorkingArea);
            }

            else if (nCase == 1)
            {
                dlgLaser.Focus();

                dlgAuto.WindowState = FormWindowState.Minimized;
                dlgLaser.WindowState = FormWindowState.Maximized;
                dlgVision.WindowState = FormWindowState.Minimized;
                dlgFC.WindowState = FormWindowState.Minimized;
                dlgLog.WindowState = FormWindowState.Minimized;

                //SetParent(dlgLaser.pLaser.MainWindowHandle, dlgLaser.panel_laser.Handle);
                //MoveWindow(dlgLaser.pLaser.MainWindowHandle, -10, -30, dlgLaser.panel_laser.Width + 20, dlgLaser.panel_laser.Height + 60, true);

                bCheckAuto = false;
            }

            else if (nCase == 2)
            {
                dlgVision.Focus();

                dlgVision.nMagni = 1;
                dlgVision.pictureBox_vision_focus.Size = new System.Drawing.Size(2448, 2048);

                ribbonUpDown_vision_camera_magni.TextBoxText = "1";

                dlgAuto.WindowState = FormWindowState.Minimized;
                dlgLaser.WindowState = FormWindowState.Minimized;
                dlgVision.WindowState = FormWindowState.Maximized;
                dlgFC.WindowState = FormWindowState.Minimized;
                dlgLog.WindowState = FormWindowState.Minimized;

                bCheckAuto = false;
            }

            else if (nCase == 3)
            {
                dlgFC.Focus();

                dlgFC.nMagni = 1;
                dlgFC.pictureBox_fc.Size = new System.Drawing.Size(2448, 2048);

                ribbonUpDown_fc_camera_magni.TextBoxText = "1";

                dlgAuto.WindowState = FormWindowState.Minimized;
                dlgLaser.WindowState = FormWindowState.Minimized;
                dlgVision.WindowState = FormWindowState.Minimized;
                dlgFC.WindowState = FormWindowState.Maximized;
                dlgLog.WindowState = FormWindowState.Minimized;

                bCheckAuto = false;
            }

            else if (nCase == 4)
            {
                dlgLog.Focus();

                dlgAuto.WindowState = FormWindowState.Minimized;
                dlgLaser.WindowState = FormWindowState.Minimized;
                dlgVision.WindowState = FormWindowState.Minimized;
                dlgFC.WindowState = FormWindowState.Minimized;
                dlgLog.WindowState = FormWindowState.Maximized;

                bCheckAuto = false;
            }
        }

        private void ribbonButton_autorun_start_Click(object sender, EventArgs e)
        {
            int nEntityCount;
            nEntityCount = dlgLaser.CountEntity();
            double Min_X = 0.0;
            double Min_Y = 0.0;
            double Max_X = 0.0;
            double Max_Y = 0.0;
            double dMaxWidth = 0.0;
            double dMaxHeight = 0.0;
            bool bOverMotion = true;

            int cur_Mode = 0;
            ctrlLaser.ScGetMode(ref cur_Mode);
            cur_Mode |= (int)
            ScComSAMLightClientCtrlFlags.scComSAMLightClientCtrlModeFlagTopLevelOnly;
            ctrlLaser.ScSetMode(cur_Mode);


            if (!ribbonCheckBox_split_enable.Checked)
            {
                ctrlLaser.ScGetEntityOutline2D("", ref Min_X, ref Min_Y, ref Max_X, ref Max_Y);               
            }

            else
            {
                for (int i = 0; i < nEntityCount; i++)
                {
                    string strName = "";
                    ctrlLaser.ScGetIDStringData((int)
                         ScComSAMLightClientCtrlFlags.scComSAMLightClientCtrlStringDataIdGetEntityName, i, ref strName);

                    try
                    {
                        ctrlLaser.ScGetEntityOutline2D(strName, ref Min_X, ref Min_Y, ref Max_X, ref Max_Y);

                        if(Max_X - Min_X >= dMaxWidth)
                            dMaxWidth = Max_X - Min_X;

                        if (Max_Y - Min_Y >= dMaxHeight)
                            dMaxHeight = Max_Y - Min_Y;

                        double dd = (Max_X - (Max_X - Min_X) / 2 + dLaserCenterX);
                        double dd2 = (Max_X - (dLaserCenterY - Max_Y - (Max_Y - Min_Y) / 2));

                        if ((Max_X - (Max_X - Min_X) / 2 + dLaserCenterX <= dLimitXLow) || (Max_X - (Max_X - Min_X) / 2 + dLaserCenterX >= dLimitXHigh)
                            || (dLaserCenterY - Max_Y - (Max_Y - Min_Y) / 2) <= dLimitYLow || (dLaserCenterY - Max_Y - (Max_Y - Min_Y) / 2) >= dLimitYHigh)
                            bOverMotion = false;
                    }
                    catch
                    {

                    }
                }
            }

            ///
            if (nEntityCount == 0)
            {
                MessageBox.Show("The Drawing is not confirmed. \r Please Proceed with Drawing Setting.");
            }

            else if (!ribbonCheckBox_split_enable.Checked && (Min_X < ctrlLaser.ScGetWorkingArea(0x0) || Min_Y < ctrlLaser.ScGetWorkingArea(0x1) ||
                    Max_X > ctrlLaser.ScGetWorkingArea(0x3) || Max_Y > ctrlLaser.ScGetWorkingArea(0x4)))
                MessageBox.Show("Drawing size bigger than available working area");

            else if (ribbonCheckBox_split_enable.Checked && (dMaxWidth > ctrlLaser.ScGetWorkingArea(0x3) - ctrlLaser.ScGetWorkingArea(0x0)
                || dMaxHeight > ctrlLaser.ScGetWorkingArea(0x4) - ctrlLaser.ScGetWorkingArea(0x1)))
                MessageBox.Show("Split size bigger than available working area");

            else if (!bOverMotion)
                MessageBox.Show("Split Motion over than motion limit");

            else
            {
                nSelectDisplay = 0;

                string strMessage = "Start the Auto Process? \r\r";


                if (!ribbonCheckBox_marking_align.Checked)
                    strMessage += "Vision Align : NO \r";

                else
                    strMessage += "Vision Align : YES [Recipe : " + dlgVision.DisplayRecipeName(nSelectedRecipe) + "]\r";

                if (!ribbonCheckBox_marking_guide.Checked)
                    strMessage += "Guide Laser : NO \r";

                else
                    strMessage += "Guide Laser : YES \r";

                if (!ribbonCheckBox_split_enable.Checked)
                    strMessage += "Laser Split : NO";

                else
                    strMessage += "Laser Split : YES";

                if (MessageBox.Show(strMessage, "RTR LASER", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    dlgAuto.dAutoModifyX = 0.00;
                    dlgAuto.dAutoModifyY = 0.00;
                    dlgAuto.dAutoModifyT = 0.00;
                    bCheckAuto = true;
                }
                else
                {

                }
            }
        }

        private void ribbonButton_fc_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Start the FieldCorrection Process?", "RTR LASER", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                ribbonButton_fc.Checked = true;
                ribbonButton_fc_stop.Checked = false;
                bCheckFC = true;
            }
            else
            {

            }
        }

        private void ribbonButton_fc_stop_Click(object sender, EventArgs e)
        {
            if (bCheckFC)
            {
                bCheckFC = false;
                ribbonButton_fc.Checked = false;
                ribbonButton_fc_stop.Checked = true;
            }
        }

        private void ribbonTextBox_laser_center_x_TextBoxTextChanged(object sender, EventArgs e)
        {
            String strInput = ribbonTextBox_laser_center_x.TextBoxText;

            if (double.TryParse(strInput, out dLaserCenterX))
            {
            }

            else
            {
            }
        }

        private void ribbonCheckBox_split_apply_CheckBoxCheckChanged(object sender, EventArgs e)
        {
            if (ribbonCheckBox_split_apply.Checked)
            {
                int nEntityCount = dlgLaser.CountEntity();

                if (nEntityCount == 0)
                {
                    MessageBox.Show("DRAWING NOT FOUND", "RTRLASER");
                    ribbonCheckBox_split_apply.Checked = false;
                }

                else
                {
                    if (ribbonRadioBox_split_size.Checked)
                        dlgLaser.SplitApply(true);

                    else
                        dlgLaser.SplitApply(false);
                }

            }
            else
            {
                ctrlLaser.ScExecCommand((int)
                    ScComSAMLightClientCtrlExecCommandConstants.scComSAMLightClientCtrlExecCommandDisableSplit);
            }

        }

        private void ribbonRadioBox_split_size_CheckBoxCheckChanged(object sender, EventArgs e)
        {
            if (ribbonRadioBox_split_size.Checked)
            {
                ribbonRadioBox_split_array.Checked = false;
                ribbonTextBox_split_col.TextBoxText = "100";
                ribbonTextBox_split_row.TextBoxText = "100";
            }

            else
            {
                ribbonRadioBox_split_array.Checked = true;
                ribbonTextBox_split_col.TextBoxText = "2";
                ribbonTextBox_split_row.TextBoxText = "2";
            }

        }

        private void ribbonRadioBox_split_array_CheckBoxCheckChanged(object sender, EventArgs e)
        {
            if (ribbonRadioBox_split_array.Checked)
            {
                ribbonRadioBox_split_size.Checked = false;
                ribbonTextBox_split_col.TextBoxText = "2";
                ribbonTextBox_split_row.TextBoxText = "2";
            }

            else
            {
                ribbonRadioBox_split_size.Checked = true;
                ribbonTextBox_split_col.TextBoxText = "100";
                ribbonTextBox_split_row.TextBoxText = "100";
            }
        }

        private void ribbonButton_split_save_Click(object sender, EventArgs e)
        {
            dlgLaser.CreateSplitFolder();
        }

        private void ribbonTextBox_motion_limit_x_low_TextBoxTextChanged(object sender, EventArgs e)
        {
            String strInput = ribbonTextBox_motion_limit_x_low.TextBoxText;

            if (double.TryParse(strInput, out dLimitXLow))
            {
            }

            else
            {
            }
        }

        private void ribbonTextBox_motion_limit_x_high_TextBoxTextChanged(object sender, EventArgs e)
        {
            String strInput = ribbonTextBox_motion_limit_x_high.TextBoxText;

            if (double.TryParse(strInput, out dLimitXHigh))
            {
            }

            else
            {
            }
        }

        private void ribbonTextBox_motion_limit_y_low_TextBoxTextChanged(object sender, EventArgs e)
        {
            String strInput = ribbonTextBox_motion_limit_y_low.TextBoxText;

            if (double.TryParse(strInput, out dLimitYLow))
            {
            }

            else
            {
            }
        }

        private void ribbonTextBox_motion_limit_y_high_TextBoxTextChanged(object sender, EventArgs e)
        {
            String strInput = ribbonTextBox_motion_limit_y_high.TextBoxText;

            if (double.TryParse(strInput, out dLimitYHigh))
            {
            }

            else
            {
            }
        }

        private void ribbonCheckBox_marking_guide_CheckBoxCheckChanged(object sender, EventArgs e)
        {
            dlgLaser.EnableGuideLaser(ribbonCheckBox_marking_guide.Checked);
        }

        private void ribbonButton_marking_mark_Click(object sender, EventArgs e)
        {
            dlgLaser.TestLaserMaking();
        }

        private void ribbonButton_vision_recipe_load_Click(object sender, EventArgs e)
        {
            dlgVision.LoadRecipe();
        }

        private void ribbonButton_vision_recipe_save_Click(object sender, EventArgs e)
        {
            dlgVision.SaveRecipe();
        }

        private void ribbonButton_vision_camera_1_Click(object sender, EventArgs e)
        {
            dlgVision.nSelectedVision = 0;

            ribbonButton_vision_camera_1.Checked = true;
            ribbonButton_vision_camera_2.Checked = false;
        }

        private void ribbonButton_vision_camera_2_Click(object sender, EventArgs e)
        {
            dlgVision.nSelectedVision = 1;

            ribbonButton_vision_camera_1.Checked = false;
            ribbonButton_vision_camera_2.Checked = true;
        }

        private void ribbonUpDown_vision_camera_exposure_1_UpButtonClicked(object sender, MouseEventArgs e)
        {
            nExposure1 = Convert.ToInt32(ribbonUpDown_vision_camera_exposure_1.TextBoxText);

            if (nExposure1 < 10)
            {
                nExposure1++;
                dlgVision.mDevicea[0].RemoteNodeList["ExposureTime"].Value = (double)(nExposure1 * 5000);
                ribbonUpDown_vision_camera_exposure_1.TextBoxText = nExposure1.ToString();
            }
        }

        private void ribbonUpDown_vision_camera_exposure_1_DownButtonClicked(object sender, MouseEventArgs e)
        {
            nExposure1 = Convert.ToInt32(ribbonUpDown_vision_camera_exposure_1.TextBoxText);

            if (nExposure1 > 1)
            {
                nExposure1--;
                dlgVision.mDevicea[0].RemoteNodeList["ExposureTime"].Value = (double)(nExposure1 * 5000);
                ribbonUpDown_vision_camera_exposure_1.TextBoxText = nExposure1.ToString();
            }
        }

        private void ribbonUpDown_vision_camera_exposure_2_UpButtonClicked(object sender, MouseEventArgs e)
        {
            nExposure2 = Convert.ToInt32(ribbonUpDown_vision_camera_exposure_2.TextBoxText);

            if (nExposure2 < 10)
            {
                nExposure2++;
                dlgVision.mDevicea[1].RemoteNodeList["ExposureTime"].Value = (double)(nExposure2 * 5000);
                ribbonUpDown_vision_camera_exposure_2.TextBoxText = nExposure2.ToString();
            }
        }

        private void ribbonUpDown_vision_camera_exposure_2_DownButtonClicked(object sender, MouseEventArgs e)
        {
            nExposure2 = Convert.ToInt32(ribbonUpDown_vision_camera_exposure_2.TextBoxText);

            if (nExposure2 > 1)
            {
                nExposure2--;
                dlgVision.mDevicea[1].RemoteNodeList["ExposureTime"].Value = (double)(nExposure2 * 5000);
                ribbonUpDown_vision_camera_exposure_2.TextBoxText = nExposure2.ToString();
            }
        }

        private void ribbonButton_vision_align_1_Click(object sender, EventArgs e)
        {
            dlgVision.nSelectedAlign = 0;

            ribbonButton_vision_align_1.Checked = true;
            ribbonButton_vision_align_2.Checked = false;
            ribbonButton_vision_align_3.Checked = false;
            ribbonButton_vision_align_4.Checked = false;

            dlgVision.DisplaySetting(0);

        }

        private void ribbonButton_vision_align_2_Click(object sender, EventArgs e)
        {
            dlgVision.nSelectedAlign = 1;

            ribbonButton_vision_align_1.Checked = false;
            ribbonButton_vision_align_2.Checked = true;
            ribbonButton_vision_align_3.Checked = false;
            ribbonButton_vision_align_4.Checked = false;

            dlgVision.DisplaySetting(1);
        }

        private void ribbonButton_vision_align_3_Click(object sender, EventArgs e)
        {
            dlgVision.nSelectedAlign = 2;

            ribbonButton_vision_align_1.Checked = false;
            ribbonButton_vision_align_2.Checked = false;
            ribbonButton_vision_align_3.Checked = true;
            ribbonButton_vision_align_4.Checked = false;

            dlgVision.DisplaySetting(2);
        }

        private void ribbonButton_vision_align_4_Click(object sender, EventArgs e)
        {
            dlgVision.nSelectedAlign = 3;

            ribbonButton_vision_align_1.Checked = false;
            ribbonButton_vision_align_2.Checked = false;
            ribbonButton_vision_align_3.Checked = false;
            ribbonButton_vision_align_4.Checked = true;

            dlgVision.DisplaySetting(3);
        }

        private void ribbonButton_vision_align_param_modify_Click(object sender, EventArgs e)
        {
            ribbonButton_vision_align_param_modify.Enabled = false;
            ribbonButton_vision_align_param_apply.Enabled = true;
            ribbonButton_vision_align_param_cancel.Enabled = true;

            dlgVision.EnableSetting(true);
        }

        private void ribbonButton_vision_align_param_apply_Click(object sender, EventArgs e)
        {
            ribbonButton_vision_align_param_modify.Enabled = true;
            ribbonButton_vision_align_param_apply.Enabled = false;
            ribbonButton_vision_align_param_cancel.Enabled = false;

            dlgVision.SaveConfig();
            dlgVision.EnableSetting(false);
        }

        private void ribbonButton_vision_align_param_cancel_Click(object sender, EventArgs e)
        {
            ribbonButton_vision_align_param_modify.Enabled = true;
            ribbonButton_vision_align_param_apply.Enabled = false;
            ribbonButton_vision_align_param_cancel.Enabled = false;

            dlgVision.LoadConfig();
            dlgVision.DisplaySetting(dlgVision.nSelectedAlign);
            dlgVision.EnableSetting(false);
        }

        private void ribbonRadioBox_vision_align_param_mark_CheckBoxCheckChanged(object sender, EventArgs e)
        {
            if (ribbonRadioBox_vision_align_param_mark.Checked)
            {
                ribbonRadioBox_vision_align_param_edge.Checked = false;

                dlgVision.EnableEdge(false);
                dlgVision.EnableMark(true);

                dlgVision.bCheckAlignEdge = false;
                dlgVision.bCheckAlignMark = true;
            }

            else
            {
                ribbonRadioBox_vision_align_param_edge.Checked = true;

                dlgVision.EnableEdge(true);
                dlgVision.EnableMark(false);

                dlgVision.bCheckAlignEdge = true;
                dlgVision.bCheckAlignMark = false;
            }
        }

        private void ribbonRadioBox_vision_align_param_edge_CheckBoxCheckChanged(object sender, EventArgs e)
        {
            if (ribbonRadioBox_vision_align_param_edge.Checked)
            {
                ribbonRadioBox_vision_align_param_mark.Checked = false;

                dlgVision.EnableEdge(true);
                dlgVision.EnableMark(false);

                dlgVision.bCheckAlignEdge = true;
                dlgVision.bCheckAlignMark = false;
            }

            else
            {
                ribbonRadioBox_vision_align_param_mark.Checked = true;

                dlgVision.EnableEdge(false);
                dlgVision.EnableMark(true);

                dlgVision.bCheckAlignEdge = false;
                dlgVision.bCheckAlignMark = true;
            }
        }

        private void ribbonTextBox_vision_alignparam_unitx_TextBoxTextChanged(object sender, EventArgs e)
        {
            String strInput = ribbonTextBox_vision_align_param_unitx.TextBoxText;

            if (double.TryParse(strInput, out dlgVision.stAlign[dlgVision.nSelectedAlign].dUnitX))
            {
            }

            else
            {
            }
        }

        private void ribbonTextBox_vision_alignparam_unity_TextBoxTextChanged(object sender, EventArgs e)
        {
            String strInput = ribbonTextBox_vision_align_param_unity.TextBoxText;

            if (double.TryParse(strInput, out dlgVision.stAlign[dlgVision.nSelectedAlign].dUnitY))
            {
            }

            else
            {
            }
        }

        private void ribbonTextBox_vision_alignparam_distance_TextBoxTextChanged(object sender, EventArgs e)
        {
            String strInput = ribbonTextBox_vision_align_param_distance.TextBoxText;

            if (double.TryParse(strInput, out dlgVision.dDistance))
            {
            }

            else
            {
            }
        }

        private void ribbonTextBox_vision_align_param_judge_x_TextBoxTextChanged(object sender, EventArgs e)
        {
            String strInput = ribbonTextBox_vision_align_param_judge_x.TextBoxText;

            if (double.TryParse(strInput, out dlgVision.dAlignRangeX))
            {
            }

            else
            {
            }
        }

        private void ribbonTextBox_vision_align_param_judge_y_TextBoxTextChanged(object sender, EventArgs e)
        {
            String strInput = ribbonTextBox_vision_align_param_judge_y.TextBoxText;

            if (double.TryParse(strInput, out dlgVision.dAlignRangeY))
            {
            }

            else
            {
            }
        }

        private void ribbonTextBox_vision_align_param_judge_t_TextBoxTextChanged(object sender, EventArgs e)
        {
            String strInput = ribbonTextBox_vision_align_param_judge_t.TextBoxText;

            if (double.TryParse(strInput, out dlgVision.dAlignRangeT))
            {
            }

            else
            {
            }
        }

        private void ribbonUpDown_vision_align_edge_precision_UpButtonClicked(object sender, MouseEventArgs e)
        {

        }

        private void ribbonUpDown_vision_align_edge_precision_DownButtonClicked(object sender, MouseEventArgs e)
        {

        }

        private void ribbonUpDown_vision_align_edge_precision_TextBoxTextChanged(object sender, EventArgs e)
        {
            String strInput = ribbonUpDown_vision_align_edge_precision.TextBoxText;

            if (int.TryParse(strInput, out dlgVision.stAlign[dlgVision.nSelectedAlign].nEdgePrecision))
            {
            }

            else
            {
            }
        }

        private void ribbonRadioBox_vision_align_edge_upward_CheckBoxCheckChanged(object sender, EventArgs e)
        {
            if (ribbonRadioBox_vision_align_edge_upward.Checked)
            {
                dlgVision.stAlign[dlgVision.nSelectedAlign].strEdgeDirection = "UPWARD";
                ribbonRadioBox_vision_align_edge_downward.Checked = false;
            }

            else
            {
                dlgVision.stAlign[dlgVision.nSelectedAlign].strEdgeDirection = "DOWNWARD";
                ribbonRadioBox_vision_align_edge_downward.Checked = true;
            }
        }

        private void ribbonRadioBox_vision_align_edge_downward_CheckBoxCheckChanged(object sender, EventArgs e)
        {
            if (ribbonRadioBox_vision_align_edge_downward.Checked)
            {
                dlgVision.stAlign[dlgVision.nSelectedAlign].strEdgeDirection = "DOWNWARD";
                ribbonRadioBox_vision_align_edge_upward.Checked = false;
            }

            else
            {
                dlgVision.stAlign[dlgVision.nSelectedAlign].strEdgeDirection = "UPWARD";
                ribbonRadioBox_vision_align_edge_upward.Checked = true;
            }
        }

        private void ribbonTextBox_vision_align_edge_preprocess_binary_TextBoxTextChanged(object sender, EventArgs e)
        {
            String strInput = ribbonTextBox_vision_align_edge_preprocess_binary.TextBoxText;

            if (int.TryParse(strInput, out dlgVision.stAlign[dlgVision.nSelectedAlign].nEdgeBinary))
            {
            }

            else
            {
            }
        }

        private void ribbonTextBox_vision_align_edge_preprocess_morp_open_TextBoxTextChanged(object sender, EventArgs e)
        {
            String strInput = ribbonTextBox_vision_align_edge_preprocess_morp_open.TextBoxText;

            if (int.TryParse(strInput, out dlgVision.stAlign[dlgVision.nSelectedAlign].nEdgeMorpOpen))
            {
            }

            else
            {
            }
        }

        private void ribbonTextBox_vision_align_edge_preprocess_morp_close_TextBoxTextChanged(object sender, EventArgs e)
        {
            String strInput = ribbonTextBox_vision_align_edge_preprocess_morp_close.TextBoxText;

            if (int.TryParse(strInput, out dlgVision.stAlign[dlgVision.nSelectedAlign].nEdgeMorpClose))
            {
            }

            else
            {
            }
        }

        private void ribbonTextBox_vision_align_edge_level_TextBoxTextChanged(object sender, EventArgs e)
        {
            String strInput = ribbonTextBox_vision_align_edge_level.TextBoxText;

            if (int.TryParse(strInput, out dlgVision.nEdgeLevel))
            {
            }

            else
            {
            }
        }

        private void ribbonTextBox_vision_align_edge_miss_TextBoxTextChanged(object sender, EventArgs e)
        {
            String strInput = ribbonTextBox_vision_align_edge_miss.TextBoxText;

            if (int.TryParse(strInput, out dlgVision.nEdgeMiss))
            {
            }

            else
            {
            }
        }

        private void ribbonTextBox_vision_align_edge_roi_start_x_TextBoxTextChanged(object sender, EventArgs e)
        {
            String strInput = ribbonTextBox_vision_align_edge_roi_start_x.TextBoxText;

            int nValue;
            if (int.TryParse(strInput, out nValue))
            {
                dlgVision.stAlign[dlgVision.nSelectedAlign].pEdgeROIStart.X = nValue;
            }

            else
            {
            }
        }

        private void ribbonTextBox_vision_align_edge_roi_end_x_TextBoxTextChanged(object sender, EventArgs e)
        {
            String strInput = ribbonTextBox_vision_align_edge_roi_end_x.TextBoxText;

            int nValue;
            if (int.TryParse(strInput, out nValue))
            {
                dlgVision.stAlign[dlgVision.nSelectedAlign].pEdgeROIEnd.X = nValue;
            }

            else
            {
            }
        }

        private void ribbonTextBox_vision_align_edge_roi_start_y_TextBoxTextChanged(object sender, EventArgs e)
        {
            String strInput = ribbonTextBox_vision_align_edge_roi_start_y.TextBoxText;

            int nValue;
            if (int.TryParse(strInput, out nValue))
            {
                dlgVision.stAlign[dlgVision.nSelectedAlign].pEdgeROIStart.Y = nValue;
            }

            else
            {
            }
        }

        private void ribbonTextBox_vision_align_edge_roi_end_y_TextBoxTextChanged(object sender, EventArgs e)
        {
            String strInput = ribbonTextBox_vision_align_edge_roi_end_y.TextBoxText;

            int nValue;
            if (int.TryParse(strInput, out nValue))
            {
                dlgVision.stAlign[dlgVision.nSelectedAlign].pEdgeROIEnd.Y = nValue;
            }

            else
            {
            }

        }

        private void ribbonButton_vision_align_mark_detect_Click(object sender, EventArgs e)
        {
            dlgVision.SimulationMarkDetect();
        }

        private void ribbonButton_vision_align_mark_clear_Click(object sender, EventArgs e)
        {
            dlgVision.bCheckManual = false;

            ribbonTextBox_vision_align_mark_matchrate.TextBoxText = "";
            ribbonTextBox_vision_align_mark_detect_x.TextBoxText = "";
            ribbonTextBox_vision_align_mark_detect_y.TextBoxText = "";
        }

        private void ribbonUpDown_vision_camera_magni_DownButtonClicked(object sender, MouseEventArgs e)
        {
            if (ribbonUpDown_vision_camera_magni.TextBoxText == "1")
            {
                ribbonUpDown_vision_camera_magni.TextBoxText = "1/2";
                dlgVision.VisionMagni(2);
            }

            else if (ribbonUpDown_vision_camera_magni.TextBoxText == "1/2")
            {
                ribbonUpDown_vision_camera_magni.TextBoxText = "1/4";
                dlgVision.VisionMagni(4);
            }
        }

        private void ribbonUpDown_vision_camera_magni_UpButtonClicked(object sender, MouseEventArgs e)
        {
            if (ribbonUpDown_vision_camera_magni.TextBoxText == "1/4")
            {
                ribbonUpDown_vision_camera_magni.TextBoxText = "1/2";
                dlgVision.VisionMagni(2);
            }

            else if (ribbonUpDown_vision_camera_magni.TextBoxText == "1/2")
            {
                ribbonUpDown_vision_camera_magni.TextBoxText = "1";
                dlgVision.VisionMagni(1);
            }

        }

        public void enableRibbon(bool nCase)
        {
            ribbonRadioBox_split_array.Enabled = nCase;
            ribbonRadioBox_split_size.Enabled = nCase;

            ribbonTextBox_split_row.Enabled = nCase;
            ribbonTextBox_split_col.Enabled = nCase;
            ribbonCheckBox_split_apply.Enabled = nCase;
            ribbonButton_split_save.Enabled = nCase;
        }

        private void ribbonButton_fc_recipe_load_Click(object sender, EventArgs e)
        {
            dlgFC.LoadRecipe();
        }

        private void ribbonButton_fc_recipe_save_Click(object sender, EventArgs e)
        {
            dlgFC.SaveRecipe();
        }

        private void ribbonUpDown_fc_camera_magni_DownButtonClicked(object sender, MouseEventArgs e)
        {
            if (ribbonUpDown_fc_camera_magni.TextBoxText == "1")
            {
                ribbonUpDown_fc_camera_magni.TextBoxText = "1/2";
                dlgFC.FCMagni(2);
            }

            else if (ribbonUpDown_fc_camera_magni.TextBoxText == "1/2")
            {
                ribbonUpDown_fc_camera_magni.TextBoxText = "1/4";
                dlgFC.FCMagni(4);
            }
        }

        private void ribbonUpDown_fc_camera_magni_UpButtonClicked(object sender, MouseEventArgs e)
        {
            if (ribbonUpDown_fc_camera_magni.TextBoxText == "1/4")
            {
                ribbonUpDown_fc_camera_magni.TextBoxText = "1/2";
                dlgFC.FCMagni(2);
            }

            else if (ribbonUpDown_fc_camera_magni.TextBoxText == "1/2")
            {
                ribbonUpDown_fc_camera_magni.TextBoxText = "1";
                dlgFC.FCMagni(1);
            }

        }

        private void ribbonButton_fc_param_modify_Click(object sender, EventArgs e)
        {
            ribbonButton_fc_param_modify.Enabled = false;
            ribbonButton_fc_param_apply.Enabled = true;
            ribbonButton_fc_param_cancel.Enabled = true;

            dlgFC.EnableSetting(true);
        }

        private void ribbonButton_fc_param_apply_Click(object sender, EventArgs e)
        {
            ribbonButton_fc_param_modify.Enabled = true;
            ribbonButton_fc_param_apply.Enabled = false;
            ribbonButton_fc_param_cancel.Enabled = false;

            dlgFC.SaveConfig();
            dlgFC.EnableSetting(false);

            dlgFC.laserMarkingPosition();
        }

        private void ribbonButton_fc_param_cancel_Click(object sender, EventArgs e)
        {
            ribbonButton_fc_param_modify.Enabled = true;
            ribbonButton_fc_param_apply.Enabled = false;
            ribbonButton_fc_param_cancel.Enabled = false;

            dlgFC.LoadConfig();
            dlgFC.DisplaySetting();
            dlgFC.EnableSetting(false);
        }


        private void ribbonTextBox_fc_param_center_x_TextBoxTextChanged(object sender, EventArgs e)
        {
            string strInput = ribbonTextBox_fc_param_center_x.TextBoxText;

            if (double.TryParse(strInput, out dFCCenterX))
            {
            }

            else
            {
            }
        }

        private void ribbonTextBox_fc_param_center_y_TextBoxTextChanged(object sender, EventArgs e)
        {
            string strInput = ribbonTextBox_fc_param_center_y.TextBoxText;

            if (double.TryParse(strInput, out dFCCenterY))
            {
            }

            else
            {
            }
        }

        private void ribbonTextBox_fc_param_gain_TextBoxTextChanged(object sender, EventArgs e)
        {
            String strInput = ribbonTextBox_fc_param_gain.TextBoxText;

            if (double.TryParse(strInput, out dlgFC.dGain))
            {
            }

            else
            {
            }
        }

        private void ribbonTextBox_fc_param_newcal_TextBoxTextChanged(object sender, EventArgs e)
        {
            String strInput = ribbonTextBox_fc_param_newcal.TextBoxText;

            if (double.TryParse(strInput, out dlgFC.dNewcal))
            {
            }

            else
            {
            }
        }

        private void ribbonTextBox_fc_param_point_TextBoxTextChanged(object sender, EventArgs e)
        {
            String strInput = ribbonTextBox_fc_param_point.TextBoxText;

            if (int.TryParse(strInput, out dlgFC.nPoint))
            {
            }

            else
            {
            }
        }

        private void ribbonTextBox_fc_param_length_TextBoxTextChanged(object sender, EventArgs e)
        {
            String strInput = ribbonTextBox_fc_param_length.TextBoxText;

            if (double.TryParse(strInput, out dlgFC.dLength))
            {
            }

            else
            {
            }
        }

        private void ribbonButton_fc_param_oldctfile_Click(object sender, EventArgs e)
        {
            dlgFC.LoadOldctFile();
        }

        private void ribbonTextBox_fc_param_oldctfile_TextBoxTextChanged(object sender, EventArgs e)
        {
            String strInput = ribbonTextBox_fc_param_oldctfile.TextBoxText;

            try
            {
                dlgFC.strOLDCTfile = strInput;
            }

            catch
            {

            }
        }

        private void ribbonTextBox_fc_param_newctfile_TextBoxTextChanged(object sender, EventArgs e)
        {
            String strInput = ribbonTextBox_fc_param_newctfile.TextBoxText;

            try
            {
                dlgFC.strNEWCTfile = strInput;
            }

            catch
            {

            }
        }

        private void ribbonButton_fc_detect_mark_Click(object sender, EventArgs e)
        {
            dlgFC.SimulationFCMark();
        }

        private void ribbonButton_fc_detect_clear_Click(object sender, EventArgs e)
        {
            dlgFC.bDetectMark = false;

            ribbonTextBox_fc_detect_matchrate.TextBoxText = "";
            ribbonTextBox_fc_detect_point_x.TextBoxText = "";
            ribbonTextBox_fc_detect_point_y.TextBoxText = "";
        }

        private void ribbonButton_fc_detect_simulation_Click(object sender, EventArgs e)
        {
            dlgFC.simulationDetect();
        }

        private void ribbonButton_fc_detect_simulation_clear_Click(object sender, EventArgs e)
        {
            dlgFC.nFCCount = 0;
            dlgFC.ResetDataGrid();
        }

        private void ribbonButton_log_data_load_Click(object sender, EventArgs e)
        {
            dlgLog.LoadLogData();
        }

        private void ribbonCheckBox_log_setting_1_CheckBoxCheckChanged(object sender, EventArgs e)
        {
            dlgLog.datagridview_Init();
            dlgLog.ReadLogData(dlgLog.strPath);
        }

        private void ribbonCheckBox_log_setting_2_CheckBoxCheckChanged(object sender, EventArgs e)
        {
            dlgLog.datagridview_Init();
            dlgLog.ReadLogData(dlgLog.strPath);
        }

        private void ribbonCheckBox_log_setting_3_CheckBoxCheckChanged(object sender, EventArgs e)
        {
            dlgLog.datagridview_Init();
            dlgLog.ReadLogData(dlgLog.strPath);
        }

        private void ribbonCheckBox_log_setting_4_CheckBoxCheckChanged(object sender, EventArgs e)
        {
            dlgLog.datagridview_Init();
            dlgLog.ReadLogData(dlgLog.strPath);
        }

        private void ribbonCheckBox_log_setting_5_CheckBoxCheckChanged(object sender, EventArgs e)
        {
            dlgLog.datagridview_Init();
            dlgLog.ReadLogData(dlgLog.strPath);
        }

        private void ribbonCheckBox_log_setting_6_CheckBoxCheckChanged(object sender, EventArgs e)
        {
            dlgLog.datagridview_Init();
            dlgLog.ReadLogData(dlgLog.strPath);
        }

        private void ribbonCheckBox_log_setting_7_CheckBoxCheckChanged(object sender, EventArgs e)
        {
            dlgLog.datagridview_Init();
            dlgLog.ReadLogData(dlgLog.strPath);
        }

        private void ribbonCheckBox_log_setting_8_CheckBoxCheckChanged(object sender, EventArgs e)
        {
            dlgLog.datagridview_Init();
            dlgLog.ReadLogData(dlgLog.strPath);
        }

        private void ribbonCheckBox_log_setting_9_CheckBoxCheckChanged(object sender, EventArgs e)
        {
            dlgLog.datagridview_Init();
            dlgLog.ReadLogData(dlgLog.strPath);
        }

        private void ribbonCheckBox_log_setting_10_CheckBoxCheckChanged(object sender, EventArgs e)
        {
            dlgLog.datagridview_Init();
            dlgLog.ReadLogData(dlgLog.strPath);
        }

        private void ribbonCheckBox_log_setting_11_CheckBoxCheckChanged(object sender, EventArgs e)
        {
            dlgLog.datagridview_Init();
            dlgLog.ReadLogData(dlgLog.strPath);
        }

        private void ribbonCheckBox_log_setting_12_CheckBoxCheckChanged(object sender, EventArgs e)
        {
            dlgLog.datagridview_Init();
            dlgLog.ReadLogData(dlgLog.strPath);
        }

        private void ribbonCheckBox_log_setting_all_CheckBoxCheckChanged(object sender, EventArgs e)
        {
            if (ribbonCheckBox_log_setting_all.Checked)
            {
                ribbonCheckBox_log_setting_1.Checked = true;
                ribbonCheckBox_log_setting_2.Checked = true;
                ribbonCheckBox_log_setting_3.Checked = true;
                ribbonCheckBox_log_setting_4.Checked = true;
                ribbonCheckBox_log_setting_5.Checked = true;
                ribbonCheckBox_log_setting_6.Checked = true;
                ribbonCheckBox_log_setting_7.Checked = true;
                ribbonCheckBox_log_setting_8.Checked = true;
                ribbonCheckBox_log_setting_9.Checked = true;
                ribbonCheckBox_log_setting_10.Checked = true;
                ribbonCheckBox_log_setting_11.Checked = true;
                ribbonCheckBox_log_setting_12.Checked = true;
            }

            else
            {
                ribbonCheckBox_log_setting_1.Checked = false;
                ribbonCheckBox_log_setting_2.Checked = false;
                ribbonCheckBox_log_setting_3.Checked = false;
                ribbonCheckBox_log_setting_4.Checked = false;
                ribbonCheckBox_log_setting_5.Checked = false;
                ribbonCheckBox_log_setting_6.Checked = false;
                ribbonCheckBox_log_setting_7.Checked = false;
                ribbonCheckBox_log_setting_8.Checked = false;
                ribbonCheckBox_log_setting_9.Checked = false;
                ribbonCheckBox_log_setting_10.Checked = false;
                ribbonCheckBox_log_setting_11.Checked = false;
                ribbonCheckBox_log_setting_12.Checked = false;
            }

            dlgLog.datagridview_Init();
            dlgLog.ReadLogData(dlgLog.strPath);
        }

        private void ribbonButton_help_contact_Click(object sender, EventArgs e)
        {
            MessageBox.Show("오승훈 과장 / 01076878823", "RTRLASER");
        }

        private void ribbonCheckBox_split_enable_CheckBoxCheckChanged(object sender, EventArgs e)
        {
            enableRibbon(ribbonCheckBox_split_enable.Checked);
        }
    }
}
