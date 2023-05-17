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
    public partial class FormManualAlign : Form
    {
        public string strPath;      // image가 저장된 위치
        public Rectangle ManualRect;    // 기존 align rect 위치

        public int nSelectManual = 0;   // 선택하는 vision 카메라
        public bool bStart = false;

        public System.Drawing.Point pClickPoint;    // 새로 누르는 point지점

        public double dDistance;

        public double dModifyX;
        public double dModifyY;
        public double dModifyT;

        public double dApplyModifyX = 0.00;
        public double dApplyModifyY = 0.00;
        public double dApplyModifyT = 0.00;
        public class ResultInfo
        {
            public struct stReulst
            {
                public System.Drawing.Point pStartPosition; // 근사곡선 시작 위치
                public System.Drawing.Point pEndPosition;   // 근사곡선 끝 위치

                public System.Drawing.Point[] pEdgeAlignPoint;  // align point(좌표 점)
                public System.Drawing.Point pMarkAlignStartPoint;  // align point(좌표 점)
                public System.Drawing.Point pMarkAlignDimension;  // align point(좌표 점)

                public System.Drawing.Point pAlignResult;   // align point 종합(Center 지점)

                public System.Drawing.Point pManualAlignResult; // manual 측정 위치

                public bool bAlignJudge;                   // 각 image에서의 align 결과

                public double dUnitX;
                public double dUnitY;
            }
        }

        public ResultInfo.stReulst[] stResult = new ResultInfo.stReulst[4];

        // 각각의 point 지점 알아야 되고,
        // 해당 값을 근거로 align 보정치 알아야되고,
        // 각 지점의 align 위치 값 알아야 되고, 

        public FormManualAlign()
        {
            InitializeComponent();
        }

        public void DisplayParameter()
        {
            nSelectManual = 0;
            string strImage = strPath + "\\Image" + (nSelectManual + 1).ToString() + ".bmp";

            pictureBox_manualalign_image.Image = Bitmap.FromFile(strImage);
            pictureBox_manualalign_image.SizeMode = PictureBoxSizeMode.AutoSize;

            ManualRect = new Rectangle(stResult[nSelectManual].pManualAlignResult.X - stResult[nSelectManual].pMarkAlignDimension.X / 2,
                stResult[nSelectManual].pManualAlignResult.Y - stResult[nSelectManual].pMarkAlignDimension.Y / 2,
                stResult[nSelectManual].pMarkAlignDimension.X, stResult[nSelectManual].pMarkAlignDimension.Y);

            textBox_manualalign_point_x_vision1.Text = stResult[0].pAlignResult.X.ToString();
            textBox_manualalign_point_y_vision1.Text = stResult[0].pAlignResult.Y.ToString();
            textBox_manualalign_point_x_vision2.Text = stResult[1].pAlignResult.X.ToString();
            textBox_manualalign_point_y_vision2.Text = stResult[1].pAlignResult.Y.ToString();
            textBox_manualalign_point_x_vision3.Text = stResult[2].pAlignResult.X.ToString();
            textBox_manualalign_point_y_vision3.Text = stResult[2].pAlignResult.Y.ToString();
            textBox_manualalign_point_x_vision4.Text = stResult[3].pAlignResult.X.ToString();
            textBox_manualalign_point_y_vision4.Text = stResult[3].pAlignResult.Y.ToString();

            AlignCalculation();

            dApplyModifyX = dModifyX;
            dApplyModifyY = dModifyY;
            dApplyModifyT = dModifyT;
        }

        private void button_manualalign_vision1_Click(object sender, EventArgs e)
        {
            nSelectManual = 0;
            string strImage = strPath + "\\Image" + (nSelectManual + 1).ToString() + ".bmp";

            pictureBox_manualalign_image.Image = Bitmap.FromFile(strImage);
            pictureBox_manualalign_image.SizeMode = PictureBoxSizeMode.AutoSize;

            ManualRect = new Rectangle(stResult[nSelectManual].pManualAlignResult.X - stResult[nSelectManual].pMarkAlignDimension.X / 2,
                stResult[nSelectManual].pManualAlignResult.Y - stResult[nSelectManual].pMarkAlignDimension.Y / 2,
                stResult[nSelectManual].pMarkAlignDimension.X, stResult[nSelectManual].pMarkAlignDimension.Y);
        }

        private void button_manualalign_vision2_Click(object sender, EventArgs e)
        {
            nSelectManual = 1;
            string strImage = strPath + "\\Image" + (nSelectManual + 1).ToString() + ".bmp";

            pictureBox_manualalign_image.Image = Bitmap.FromFile(strImage);
            pictureBox_manualalign_image.SizeMode = PictureBoxSizeMode.AutoSize;

            ManualRect = new Rectangle(stResult[nSelectManual].pManualAlignResult.X - stResult[nSelectManual].pMarkAlignDimension.X / 2,
                stResult[nSelectManual].pManualAlignResult.Y - stResult[nSelectManual].pMarkAlignDimension.Y / 2,
                stResult[nSelectManual].pMarkAlignDimension.X, stResult[nSelectManual].pMarkAlignDimension.Y);
        }

        private void button_manualalign_vision3_Click(object sender, EventArgs e)
        {
            nSelectManual = 2;
            string strImage = strPath + "\\Image" + (nSelectManual + 1).ToString() + ".bmp";

            pictureBox_manualalign_image.Image = Bitmap.FromFile(strImage);
            pictureBox_manualalign_image.SizeMode = PictureBoxSizeMode.AutoSize;

            ManualRect = new Rectangle(stResult[nSelectManual].pManualAlignResult.X - stResult[nSelectManual].pMarkAlignDimension.X / 2,
                stResult[nSelectManual].pManualAlignResult.Y - stResult[nSelectManual].pMarkAlignDimension.Y / 2,
                stResult[nSelectManual].pMarkAlignDimension.X, stResult[nSelectManual].pMarkAlignDimension.Y);
        }

        private void button_manualalign_vision4_Click(object sender, EventArgs e)
        {
            nSelectManual = 3;
            string strImage = strPath + "\\Image" + (nSelectManual + 1).ToString() + ".bmp";

            pictureBox_manualalign_image.Image = Bitmap.FromFile(strImage);
            pictureBox_manualalign_image.SizeMode = PictureBoxSizeMode.AutoSize;

            ManualRect = new Rectangle(stResult[nSelectManual].pManualAlignResult.X - stResult[nSelectManual].pMarkAlignDimension.X / 2,
                stResult[nSelectManual].pManualAlignResult.Y - stResult[nSelectManual].pMarkAlignDimension.Y / 2,
                stResult[nSelectManual].pMarkAlignDimension.X, stResult[nSelectManual].pMarkAlignDimension.Y);
        }

        private void pictureBox_manualalign_image_Paint(object sender, PaintEventArgs e)
        {
            if (stResult[nSelectManual].bAlignJudge)
            {
                using (Pen penGreen = new Pen(Color.Green, 2))
                {
                    e.Graphics.DrawRectangle(penGreen, ManualRect.X, ManualRect.Y, ManualRect.Width, ManualRect.Height);
                    
                    e.Graphics.DrawLine(penGreen, ManualRect.X + ManualRect.Width / 2, (ManualRect.Y + ManualRect.Height / 2) - 10,
                        ManualRect.X + ManualRect.Width / 2, (ManualRect.Y + ManualRect.Height / 2) + 10);
                    e.Graphics.DrawLine(penGreen, (ManualRect.X + ManualRect.Width / 2) - 10, (ManualRect.Y + ManualRect.Height / 2),
                        (ManualRect.X + ManualRect.Width / 2) + 10, (ManualRect.Y + ManualRect.Height / 2));
                }
            }

            else
            {
                using (Pen penRed = new Pen(Color.Red, 2))
                {
                    e.Graphics.DrawRectangle(penRed, ManualRect.X, ManualRect.Y, ManualRect.Width, ManualRect.Height);

                    e.Graphics.DrawLine(penRed, ManualRect.X + ManualRect.Width / 2, (ManualRect.Y + ManualRect.Height / 2) - 10,
                        ManualRect.X + ManualRect.Width / 2, (ManualRect.Y + ManualRect.Height / 2) + 10);
                    e.Graphics.DrawLine(penRed, (ManualRect.X + ManualRect.Width / 2) - 10, (ManualRect.Y + ManualRect.Height / 2),
                        (ManualRect.X + ManualRect.Width / 2) + 10, (ManualRect.Y + ManualRect.Height / 2));
                }
            }
        }

        private void pictureBox_manualalign_image_MouseDown(object sender, MouseEventArgs e)
        {
            stResult[nSelectManual].pManualAlignResult.X = e.X;
            stResult[nSelectManual].pManualAlignResult.Y = e.Y;

            if (nSelectManual == 0)
            {
                textBox_manualalign_point_x_vision1.Text = e.X.ToString();
                textBox_manualalign_point_y_vision1.Text = e.Y.ToString();
            }

            else if (nSelectManual == 1)
            {
                textBox_manualalign_point_x_vision2.Text = e.X.ToString();
                textBox_manualalign_point_y_vision2.Text = e.Y.ToString();
            }

            else if (nSelectManual == 2)
            {
                textBox_manualalign_point_x_vision3.Text = e.X.ToString();
                textBox_manualalign_point_y_vision3.Text = e.Y.ToString();
            }

            else if (nSelectManual == 3)
            {
                textBox_manualalign_point_x_vision4.Text = e.X.ToString();
                textBox_manualalign_point_y_vision4.Text = e.Y.ToString();
            }

            ManualRect.X = e.X - (stResult[nSelectManual].pMarkAlignDimension.X / 2);
            ManualRect.Y = e.Y - (stResult[nSelectManual].pMarkAlignDimension.Y / 2);
            ManualRect.Width = (stResult[nSelectManual].pMarkAlignDimension.X);
            ManualRect.Height = (stResult[nSelectManual].pMarkAlignDimension.Y);

            pictureBox_manualalign_image.Refresh();

            AlignCalculation();
        }

        public bool AlignCalculation()
        {
            bool bRet = true;

            double dT12;
            double dT34;

            double dXPos1;
            double dXPos2;
            double dXPos3;
            double dXPos4;

            double dYPos1;
            double dYPos2;
            double dYPos3;
            double dYPos4;

            dXPos1 = stResult[0].pManualAlignResult.X - (2448 / 2);
            dXPos2 = stResult[1].pManualAlignResult.X - (2448 / 2);
            dXPos3 = stResult[2].pManualAlignResult.X - (2448 / 2);
            dXPos4 = stResult[3].pManualAlignResult.X - (2448 / 2);

            dYPos1 = stResult[0].pManualAlignResult.Y - (2048 / 2);
            dYPos2 = stResult[1].pManualAlignResult.Y - (2048 / 2);
            dYPos3 = stResult[2].pManualAlignResult.Y - (2048 / 2);
            dYPos4 = stResult[3].pManualAlignResult.Y - (2048 / 2);

            // edge 인 경우
            //dT12 = (dYPos2 - dYPos1) / dDistance;
            //dT34 = (dYPos4 - dYPos3) / dDistance;

            // mark 인 경우
            // align 위치 값을 이용해서 거리를 계산해야 한다.
            // unit 위치가 있어도 카메라와의 거리 값이 있기 때문에 

            dT12 = (dYPos2 - dYPos1) / (stResult[1].dUnitX - stResult[0].dUnitX - dDistance);
            dT34 = (dYPos4 - dYPos3) / (stResult[3].dUnitX - stResult[2].dUnitX - dDistance);

            dModifyX = (dXPos1 + dXPos2 + dXPos3 + dXPos4) / 4;
            dModifyY = (dYPos1 + dYPos2 + dYPos3 + dYPos4) / 4;
            dModifyT = (dT12 + dT34) / 2;

            dModifyX *= 0.00345 / 2;
            dModifyY *= 0.00345 / 2;

            textBox_manualalign_modify_x.Text = dModifyX.ToString("F3") + "mm";
            textBox_manualalign_modify_y.Text = dModifyY.ToString("F3") + "mm";
            textBox_manualalign_modify_t.Text = dModifyT.ToString("F4") + "˚";

            return bRet;
        }

        private void button_manualalign_apply_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("ALIGN 값을 적용하시겠습니까?", "RTR LASER", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                for (int i = 0; i < 4; i++)
                {
                    stResult[i].pAlignResult.X = stResult[i].pManualAlignResult.X;
                    stResult[i].pAlignResult.Y = stResult[i].pManualAlignResult.Y;

                    dApplyModifyX = dModifyX;
                    dApplyModifyY = dModifyY;
                    dApplyModifyT = dModifyT;
                }
            }

            else
            {

            }
        }

        private void button_manualalign_cancel_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < 4; i++)
            {
                stResult[i].pManualAlignResult.X = stResult[i].pAlignResult.X;
                stResult[i].pManualAlignResult.Y = stResult[i].pAlignResult.Y;
            }

            ManualRect.X = stResult[nSelectManual].pManualAlignResult.X - (stResult[nSelectManual].pMarkAlignDimension.X / 2);
            ManualRect.Y = stResult[nSelectManual].pManualAlignResult.Y - (stResult[nSelectManual].pMarkAlignDimension.Y / 2);
            ManualRect.Width = (stResult[nSelectManual].pMarkAlignDimension.X);
            ManualRect.Height = (stResult[nSelectManual].pMarkAlignDimension.Y);

            textBox_manualalign_point_x_vision1.Text = stResult[0].pManualAlignResult.X.ToString();
            textBox_manualalign_point_y_vision1.Text = stResult[0].pManualAlignResult.Y.ToString();
            textBox_manualalign_point_x_vision2.Text = stResult[1].pManualAlignResult.X.ToString();
            textBox_manualalign_point_y_vision2.Text = stResult[1].pManualAlignResult.Y.ToString();
            textBox_manualalign_point_x_vision3.Text = stResult[2].pManualAlignResult.X.ToString();
            textBox_manualalign_point_y_vision3.Text = stResult[2].pManualAlignResult.Y.ToString();
            textBox_manualalign_point_x_vision4.Text = stResult[3].pManualAlignResult.X.ToString();
            textBox_manualalign_point_y_vision4.Text = stResult[3].pManualAlignResult.Y.ToString();

            AlignCalculation();

            dApplyModifyX = dModifyX;
            dApplyModifyY = dModifyY;
            dApplyModifyT = dModifyT;

            pictureBox_manualalign_image.Refresh();
        }

        private void button_manualalign_close_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("종료하시겠습니까?", "RTR LASER", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                this.DialogResult = DialogResult.OK;

                this.Close();
            }
        }
    }
}
