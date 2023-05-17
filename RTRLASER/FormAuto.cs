using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using System.Runtime.InteropServices;
using ScapsSamOpticModule2DCtrl;
using System.Threading;
using System.IO;

using SAMLIGHT_CLIENT_CTRL_EXLib;

namespace RTRLASER
{
    public partial class FormAuto : Form
    {
        FormMain mainForm;

        public bool bCheckSplit;

        public string DirTime;
        public string DirAlignResultPath;

        // laser 분할 갯수
        public int nLaserSplit;

        // process 공정 중 align 보정 값
        public double dAutoModifyX = 0.00;
        public double dAutoModifyY = 0.00;
        public double dAutoModifyT = 0.00;

        public Font textFont = new Font("굴림", 8);
        public Font textBoldFont = new Font("굴림", 8, FontStyle.Bold);
        public Pen penred = new Pen(Color.Red, 1);
        public Pen pengreen = new Pen(Color.Red, 1);

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

        public class ProcessInfo
        {
            public struct stProc
            {
                public string strName;

                public bool bLaserProcess;

                public double dOriginPosX;
                public double dOriginPosY;
                public double dOriginAngle;
                public double dOriginWidth;
                public double dOriginHeight;

                public double dAlignPosX;
                public double dAlignPosY;
                public double dAlignAngle;

                public double dMarkingPosX;
                public double dMarkingPosY;

            }
        }

        public ProcessInfo.stProc[] stProcess;
        public UnionValue union = new UnionValue();

        public FormAuto(FormMain parent)
        {
            MdiParent = mainForm = parent;

            InitializeComponent();

        }

        public void AlignResultUpdate(int nVision)
        {
            Bitmap AlignUpdateBMP;

            if (nVision == 0)
            {
                DirAlignResultPath = DirTime + "\\Align\\Image1.bmp";

                AlignUpdateBMP = new Bitmap(DirAlignResultPath);
                pictureBox_auto_result_align1.Image = AlignUpdateBMP;
                pictureBox_auto_result_align1.SizeMode = PictureBoxSizeMode.StretchImage;
            }

            else if (nVision == 1)
            {
                DirAlignResultPath = DirTime + "\\Align\\Image2.bmp";

                AlignUpdateBMP = new Bitmap(DirAlignResultPath);
                pictureBox_auto_result_align2.Image = AlignUpdateBMP;
                pictureBox_auto_result_align2.SizeMode = PictureBoxSizeMode.StretchImage;
            }

            else if (nVision == 2)
            {
                DirAlignResultPath = DirTime + "\\Align\\Image3.bmp";

                AlignUpdateBMP = new Bitmap(DirAlignResultPath);
                pictureBox_auto_result_align3.Image = AlignUpdateBMP;
                pictureBox_auto_result_align3.SizeMode = PictureBoxSizeMode.StretchImage;
            }

            else if (nVision == 3)
            {
                DirAlignResultPath = DirTime + "\\Align\\Image4.bmp";

                AlignUpdateBMP = new Bitmap(DirAlignResultPath);
                pictureBox_auto_result_align4.Image = AlignUpdateBMP;
                pictureBox_auto_result_align4.SizeMode = PictureBoxSizeMode.StretchImage;
            }

        }

        public void CreateDirAlignData()
        {
            string DirDay = Environment.CurrentDirectory + @"\Data\\Vision Align\\" + DateTime.Today.ToString("yyMMdd");
            DirTime = DirDay + "\\" + DateTime.Now.ToString("HHmmss");

            string strOrigin = DirTime + "\\Origin";
            string strAlign = DirTime + "\\Align";

            DirectoryInfo di = new DirectoryInfo(DirDay);
            DirectoryInfo di_time = new DirectoryInfo(DirTime);

            mainForm.dlgVision.stResult[0].bCheckAlignComplete = false;
            mainForm.dlgVision.stResult[1].bCheckAlignComplete = false;
            mainForm.dlgVision.stResult[2].bCheckAlignComplete = false;
            mainForm.dlgVision.stResult[3].bCheckAlignComplete = false;

            pictureBox_auto_result_align1.Image = null;
            pictureBox_auto_result_align2.Image = null;
            pictureBox_auto_result_align3.Image = null;
            pictureBox_auto_result_align4.Image = null;

            label_auto_result_modify_x_value.Invoke(new EventHandler(delegate { label_auto_result_modify_x_value.Text = ""; }));
            label_auto_result_modify_y_value.Invoke(new EventHandler(delegate { label_auto_result_modify_y_value.Text = ""; }));
            label_auto_result_modify_t_value.Invoke(new EventHandler(delegate { label_auto_result_modify_t_value.Text = ""; }));

            label_auto_modify_x_judge.Invoke(new EventHandler(delegate { label_auto_modify_x_judge.Text = ""; }));
            label_auto_modify_y_judge.Invoke(new EventHandler(delegate { label_auto_modify_y_judge.Text = ""; }));
            label_auto_modify_t_judge.Invoke(new EventHandler(delegate { label_auto_modify_t_judge.Text = ""; }));

            label_auto_total_judge.Invoke(new EventHandler(delegate { label_auto_total_judge.Text = ""; }));

            try
            {
                if (!di.Exists) Directory.CreateDirectory(DirDay);
                if (!di_time.Exists) Directory.CreateDirectory(DirTime);
                if (!di_time.Exists) Directory.CreateDirectory(strOrigin);
                if (!di_time.Exists) Directory.CreateDirectory(strAlign);
            }
            catch (Exception error)
            {

            }

            button_auto_result_align1.BackColor = Color.Silver;
            button_auto_result_align2.BackColor = Color.Silver;
            button_auto_result_align3.BackColor = Color.Silver;
            button_auto_result_align4.BackColor = Color.Silver;

            laserReturn();
        }

        private void pictureBox_auto_result_align1_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.DrawString("매칭율 : ", textFont, Brushes.White, 5, 160);
            e.Graphics.DrawString("X : ", textFont, Brushes.White, 5, 175);
            e.Graphics.DrawString("Y : ", textFont, Brushes.White, 5, 190);

            if (mainForm.dlgVision.stResult[0].bCheckAlignComplete)
            {
                e.Graphics.DrawString(mainForm.dlgVision.stResult[0].dMatchrate.ToString("F2") + "%", textFont, Brushes.White, 50, 160);
                e.Graphics.DrawString(mainForm.dlgVision.stResult[0].pAlignResult.X.ToString(), textFont, Brushes.White, 50, 175);
                e.Graphics.DrawString(mainForm.dlgVision.stResult[0].pAlignResult.Y.ToString(), textFont, Brushes.White, 50, 190);
            }
        }

        private void pictureBox_auto_result_align2_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.DrawString("매칭율 : ", textFont, Brushes.White, 5, 160);
            e.Graphics.DrawString("X : ", textFont, Brushes.White, 5, 175);
            e.Graphics.DrawString("Y : ", textFont, Brushes.White, 5, 190);

            if (mainForm.dlgVision.stResult[1].bCheckAlignComplete)
            {
                e.Graphics.DrawString(mainForm.dlgVision.stResult[1].dMatchrate.ToString("F2") + "%", textFont, Brushes.White, 50, 160);
                e.Graphics.DrawString(mainForm.dlgVision.stResult[1].pAlignResult.X.ToString(), textFont, Brushes.White, 50, 175);
                e.Graphics.DrawString(mainForm.dlgVision.stResult[1].pAlignResult.Y.ToString(), textFont, Brushes.White, 50, 190);
            }
        }

        private void pictureBox_auto_result_align3_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.DrawString("매칭율 : ", textFont, Brushes.White, 5, 160);
            e.Graphics.DrawString("X : ", textFont, Brushes.White, 5, 175);
            e.Graphics.DrawString("Y : ", textFont, Brushes.White, 5, 190);

            if (mainForm.dlgVision.stResult[2].bCheckAlignComplete)
            {
                e.Graphics.DrawString(mainForm.dlgVision.stResult[2].dMatchrate.ToString("F2") + "%", textFont, Brushes.White, 50, 160);
                e.Graphics.DrawString(mainForm.dlgVision.stResult[2].pAlignResult.X.ToString(), textFont, Brushes.White, 50, 175);
                e.Graphics.DrawString(mainForm.dlgVision.stResult[2].pAlignResult.Y.ToString(), textFont, Brushes.White, 50, 190);
            }
        }

        private void pictureBox_auto_result_align4_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.DrawString("매칭율 : ", textFont, Brushes.White, 5, 160);
            e.Graphics.DrawString("X : ", textFont, Brushes.White, 5, 175);
            e.Graphics.DrawString("Y : ", textFont, Brushes.White, 5, 190);

            if (mainForm.dlgVision.stResult[3].bCheckAlignComplete)
            {
                e.Graphics.DrawString(mainForm.dlgVision.stResult[3].dMatchrate.ToString("F2") + "%", textFont, Brushes.White, 50, 160);
                e.Graphics.DrawString(mainForm.dlgVision.stResult[3].pAlignResult.X.ToString(), textFont, Brushes.White, 50, 175);
                e.Graphics.DrawString(mainForm.dlgVision.stResult[3].pAlignResult.Y.ToString(), textFont, Brushes.White, 50, 190);
            }
        }

        public void CheckProcessInfo()
        {
            if (mainForm.ribbonCheckBox_split_enable.Checked)
            {
                // 분할 숫자 확인
                nLaserSplit = mainForm.dlgLaser.CountEntity();

                int cur_Mode = 0;
                mainForm.ctrlLaser.ScGetMode(ref cur_Mode);
                cur_Mode |= (int)
                ScComSAMLightClientCtrlFlags.scComSAMLightClientCtrlModeFlagTopLevelOnly;
                mainForm.ctrlLaser.ScSetMode(cur_Mode);

                // process 구조체 선언
                stProcess = new ProcessInfo.stProc[nLaserSplit];

                for (int i = 0; i < nLaserSplit; i++)
                {
                    string strName = "";
                    mainForm.ctrlLaser.ScGetIDStringData((int)
                         ScComSAMLightClientCtrlFlags.scComSAMLightClientCtrlStringDataIdGetEntityName, i, ref strName);

                    double Min_X = 0.0;
                    double Min_Y = 0.0;
                    double Max_X = 0.0;
                    double Max_Y = 0.0;
                    double dAngle = 0.0;

                    try
                    {
                        mainForm.ctrlLaser.ScGetEntityOutline2D(strName, ref Min_X, ref Min_Y, ref Max_X, ref Max_Y);
                        mainForm.ctrlLaser.ScGetEntityDoubleData(strName, (int)
                        ScComSAMLightClientCtrlFlags.scComSAMLightClientCtrlDoubleDataIdEntityRotationAngle, ref dAngle);

                        stProcess[i].strName = strName;
                        stProcess[i].dOriginPosX = Max_X - (Max_X - Min_X) / 2;
                        stProcess[i].dOriginPosY = Max_Y - (Max_Y - Min_Y) / 2;
                        stProcess[i].dOriginAngle = dAngle;
                        stProcess[i].dOriginWidth = Max_X - Min_X;
                        stProcess[i].dOriginHeight = Max_Y - Min_Y;
                        stProcess[i].bLaserProcess = true;
                    }
                    catch
                    {
                        stProcess[i].bLaserProcess = false;
                    }
                }
            }

            else
            {
                stProcess = new ProcessInfo.stProc[1];

                double Min_X = 0.0;
                double Min_Y = 0.0;
                double Max_X = 0.0;
                double Max_Y = 0.0;
                double dAngle = 0.0;

                mainForm.ctrlLaser.ScGetEntityOutline2D("", ref Min_X, ref Min_Y, ref Max_X, ref Max_Y);
                mainForm.ctrlLaser.ScGetEntityDoubleData("", (int)
                    ScComSAMLightClientCtrlFlags.scComSAMLightClientCtrlDoubleDataIdEntityRotationAngle, ref dAngle);

                stProcess[0].dOriginPosX = Max_X - (Max_X - Min_X) / 2;
                stProcess[0].dOriginPosY = Max_Y - (Max_Y - Min_Y) / 2;
                stProcess[0].dOriginAngle = dAngle;
                stProcess[0].dOriginWidth = Max_X - Min_X;
                stProcess[0].dOriginHeight = Max_Y - Min_Y;
                stProcess[0].bLaserProcess = true;
            }
        }

        public void applyAlignValue()
        {
            mainForm.dlgLaser.MoveDrawing(dAutoModifyX, dAutoModifyY, dAutoModifyT);
        }

        public void laserReturn()
        {
            mainForm.dlgLaser.MoveDrawing(-dAutoModifyX, -dAutoModifyY, -dAutoModifyT);
        }

        public void laserMarkingPosition()
        {
            if (mainForm.ribbonCheckBox_split_enable.Checked)
            {
                int nLaserSplit = mainForm.dlgLaser.CountEntity();

                for (int i = 0; i < nLaserSplit; i++)
                {
                    double Min_X = 0.0;
                    double Min_Y = 0.0;
                    double Max_X = 0.0;
                    double Max_Y = 0.0;
                    double dAngle = 0.0;

                    try
                    {
                        mainForm.ctrlLaser.ScGetEntityOutline2D(stProcess[i].strName, ref Min_X, ref Min_Y, ref Max_X, ref Max_Y);
                        mainForm.ctrlLaser.ScGetEntityDoubleData(stProcess[i].strName, (int)
                            ScComSAMLightClientCtrlFlags.scComSAMLightClientCtrlDoubleDataIdEntityRotationAngle, ref dAngle);

                        if (stProcess[i].bLaserProcess)
                        {
                            stProcess[i].dAlignPosX = Max_X - (Max_X - Min_X) / 2;
                            stProcess[i].dAlignPosY = Max_Y - (Max_Y - Min_Y) / 2;
                            stProcess[i].dAlignAngle = dAngle;

                            stProcess[i].dMarkingPosX = stProcess[i].dAlignPosX + mainForm.dLaserCenterX;
                            stProcess[i].dMarkingPosY = mainForm.dLaserCenterY - stProcess[i].dAlignPosY;
                        }
                        
                        else
                        {
                            stProcess[i].dAlignPosX = 0.00;
                            stProcess[i].dAlignPosY = 0.00;
                            stProcess[i].dAlignAngle = 0.00;

                            stProcess[i].dMarkingPosX = 0.00;
                            stProcess[i].dMarkingPosY = 0.00;
                        }
                        
                    }

                    catch
                    {
                        stProcess[i].dAlignPosX = 0.00;
                        stProcess[i].dAlignPosY = 0.00;
                        stProcess[i].dAlignAngle = 0.00;

                        stProcess[i].dMarkingPosX = 0.00;
                        stProcess[i].dMarkingPosY = 0.00;
                    }
                }
            }

            else
            {
                stProcess[0].dMarkingPosX = mainForm.dLaserCenterX;
                stProcess[0].dMarkingPosY = mainForm.dLaserCenterY;
            }
        }

        public void laserMarking(int nLaser)
        {
            // 분할인 경우
            if (mainForm.ribbonCheckBox_split_enable.Checked)
            {
                for (int i = 0; i < nLaserSplit; i++)
                {
                    mainForm.ctrlLaser.ScSetEntityLongData(stProcess[i].strName, (int)
                        ScComSAMLightClientCtrlFlags.scComSAMLightClientCtrlLongDataIdEntitySelected, 0);
                }

                mainForm.ctrlLaser.ScSetEntityLongData(stProcess[nLaser].strName, (int)
                                  ScComSAMLightClientCtrlFlags.scComSAMLightClientCtrlLongDataIdEntitySelected, 1);

                // X축 , Y축 OFFSET 을 줘서 LASER 쏠 때는 CENTER 위치로 오게끔
                mainForm.ctrlLaser.ScSetDoubleValue((int)
                    ScComSAMLightClientCtrlValueTypes.scComSAMLightClientCtrlDoubleValueTypeOffsetX, -(stProcess[nLaser].dAlignPosX));

                mainForm.ctrlLaser.ScSetDoubleValue((int)
                    ScComSAMLightClientCtrlValueTypes.scComSAMLightClientCtrlDoubleValueTypeOffsetY, -(stProcess[nLaser].dAlignPosY));

                mainForm.ctrlLaser.ScMarkEntityByName(stProcess[nLaser].strName, 1);

                // offset 적용 값은 해당 laser marking 종료 이후 원래 위치로 이동시켜야 한다. 
                mainForm.ctrlLaser.ScSetDoubleValue((int)
                    ScComSAMLightClientCtrlValueTypes.scComSAMLightClientCtrlDoubleValueTypeOffsetX, stProcess[nLaser].dAlignPosX);

                mainForm.ctrlLaser.ScSetDoubleValue((int)
                    ScComSAMLightClientCtrlValueTypes.scComSAMLightClientCtrlDoubleValueTypeOffsetY, stProcess[nLaser].dAlignPosY);
            }

            // 분할이 아닌 경우 전체 영역을 그냥 한번에 다 쏴라
            else
            {
                mainForm.ctrlLaser.ScSetEntityLongData("", (int)
                  ScComSAMLightClientCtrlFlags.scComSAMLightClientCtrlLongDataIdEntitySelected, 1);

                mainForm.ctrlLaser.ScMarkEntityByName("", 1);
            }
        }

        private void button_auto_count_reset_Click(object sender, EventArgs e)
        {
            mainForm.nVisionCount = 0;
            mainForm.nLaserCount = 0;

            mainForm.dlgVision.stResult[0].bCheckAlignComplete = false;
            mainForm.dlgVision.stResult[1].bCheckAlignComplete = false;
            mainForm.dlgVision.stResult[2].bCheckAlignComplete = false;
            mainForm.dlgVision.stResult[3].bCheckAlignComplete = false;

            pictureBox_auto_result_align1.Image = null;
            pictureBox_auto_result_align2.Image = null;
            pictureBox_auto_result_align3.Image = null;
            pictureBox_auto_result_align4.Image = null;

            label_auto_result_modify_x_value.Invoke(new EventHandler(delegate { label_auto_result_modify_x_value.Text = ""; }));
            label_auto_result_modify_y_value.Invoke(new EventHandler(delegate { label_auto_result_modify_y_value.Text = ""; }));
            label_auto_result_modify_t_value.Invoke(new EventHandler(delegate { label_auto_result_modify_t_value.Text = ""; }));

            label_auto_modify_x_judge.Invoke(new EventHandler(delegate { label_auto_modify_x_judge.Text = ""; }));
            label_auto_modify_y_judge.Invoke(new EventHandler(delegate { label_auto_modify_y_judge.Text = ""; }));
            label_auto_modify_t_judge.Invoke(new EventHandler(delegate { label_auto_modify_t_judge.Text = ""; }));

            label_auto_total_judge.Invoke(new EventHandler(delegate { label_auto_total_judge.Text = ""; }));

            button_auto_result_align1.BackColor = Color.Silver;
            button_auto_result_align2.BackColor = Color.Silver;
            button_auto_result_align3.BackColor = Color.Silver;
            button_auto_result_align4.BackColor = Color.Silver;

            mainForm.ctrlLaser.ScSetEntityLongData("", (int)
                ScComSAMLightClientCtrlFlags.scComSAMLightClientCtrlLongDataIdEntitySelected, 1);
        }
    }
}
