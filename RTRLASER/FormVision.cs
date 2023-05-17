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
using System.Drawing.Imaging;
using System.Runtime;
using System.IO;

using OpenCvSharp;

using System.IO.Ports;


namespace RTRLASER
{
    public partial class FormVision : Form
    {
        FormMain mainForm;

        public bool[] m_bOpen;

        public static int gImageCounter = 0;

        BGAPI2.SystemList systemList = null;
        BGAPI2.System mSystem = null;
        string sSystemID = "";

        BGAPI2.InterfaceList interfaceList = null;
        BGAPI2.Interface mInterface = null;
        string sInterfaceID = "";

        BGAPI2.DeviceList deviceList = null;
        BGAPI2.Device mDevice = null;
        string sDeviceID = "";

        public BGAPI2.Device[] mDevicea = new BGAPI2.Device[17];
        BGAPI2.DeviceList[] deviceLista = new BGAPI2.DeviceList[17];
        string[] sDeviceIDa = new string[17];
        static BGAPI2.DataStreamList[] datastreamLista = new BGAPI2.DataStreamList[17];
        static BGAPI2.DataStream[] mDataStreama = new BGAPI2.DataStream[17];
        string[] sDataStreamIDa = new string[17];

        BGAPI2.BufferList[] bufferLista = new BGAPI2.BufferList[17];
        BGAPI2.Buffer[] mBuffera = new BGAPI2.Buffer[17];
        public static IntPtr[] bufa = new IntPtr[17];

        // Vision pause, start 상태
        bool bAliveVision1 = true;
        bool bAliveVision2 = true;

        // Vision Tab 선택 카메라
        public int nSelectedVision = 0;
        public int nSelectedAlign = 0;

        public int nSelectedVision1 = 0;   // 0,1번 align 
        public int nSelectedVision2 = 2;   // 2,3번 align

        // Vision Tab Focus 영역
        public Rectangle Vision1_rectRoi;
        public Rectangle Vision2_rectRoi;

        // Vision draw
        Graphics VisionResult;

        public int nVisionNum;
        public int nAlignNum;

        public int nResolutionX;
        public int nResolutionY;

        public double dPixelsize;
        public int nMagnification;
        public double dDistance;
        public int nEdgeLevel;
        public int nEdgeMiss;

        public double dAlignRangeX;
        public double dAlignRangeY;
        public double dAlignRangeT;

        public bool bCapture = false;

        public bool bCheckAlignMark;
        public bool bCheckAlignEdge;

        public bool bCheckMarkReg = false;
        public Rectangle AlignMarkRect = new Rectangle(0, 0, 100, 100);

        public bool bCheckManual = false;
        public bool bCheckManualResult = false;

        public System.Drawing.Point pManualMarkStart;
        public System.Drawing.Point pManualMarkDimension;

        public bool bClickCheck = false;
        public bool bClickSizeLeft = false;
        public bool bClickSizeRight = false;
        public bool bClickSizeTop = false;
        public bool bClickSizeBottom = false;
        public bool bClickSizeLeftTop = false;
        public bool bClickSizeLeftBottom = false;
        public bool bClickSizeRightTop = false;
        public bool bClickSizeRightBottom = false;

        private System.Drawing.Point startPos;
        private System.Drawing.Point endPos;

        public int nMagni = 1;

        public static bool MouseInLeft { get; set; }
        public static bool MouseInRight { get; set; }
        public static bool MouseInTop { get; set; }
        public static bool MouseInBottom { get; set; }


        // 카메라 정보
        public class VisionInfo
        {
            public struct stVision
            {
                public string strSerial;
                public int nExposure;
                public int nLight;
            }
        }

        // align 진행 시 필요한 정보 (전처리, 정밀도 등)
        public class AlignInfo
        {
            public struct stAlign
            {
                public int nUsingVision;

                public double dUnitX;
                public double dUnitY;

                public int nEdgeBinary;
                public int nEdgeMorpOpen;
                public int nEdgeMorpClose;

                public string strEdgeDirection;

                public System.Drawing.Point pEdgeROIStart;
                public System.Drawing.Point pEdgeROIEnd;

                public int nEdgePrecision;

                public double dMatchrate;
                public System.Drawing.Point pMarkROIStart;
                public System.Drawing.Point pMarkROIEnd;

                public bool bCheckProprocess;

                public int nMarkBinary;
                public int nMarkMorpOpen;
                public int nMarkMorpClose;

                public int nImageBinary;
                public int nImageMorpOpen;
                public int nImageMorpClose;
            }
        }

        // align 결과에 대한 값들
        public class ResultInfo
        {
            public struct stReulst
            {
                public System.Drawing.Point pStartPosition; // 근사곡선 시작 위치
                public System.Drawing.Point pEndPosition;   // 근사곡선 끝 위치

                public System.Drawing.Point[] pEdgeAlignPoint;  // align point(좌표 점)
                public System.Drawing.Point pMarkAlignStartPoint;  // align point(좌표 점)
                public System.Drawing.Point pMarkAlignDimension;  // align point(좌표 점)

                public double[] pZscore;                    // z score (3이상 error)
                public System.Drawing.Point pAlignResult;   // align point 종합(Center 지점)

                public double dMatchrate;
                public bool bAlignJudge;

                public bool bCheckOriginSave;
                public bool bCheckAlignSave;

                public bool bCheckAlignComplete;            // align 종료 유무
                public bool bResultAlign;                   // 각 image에서의 align 결과
            }
        }

        public VisionInfo.stVision[] stVision;
        public AlignInfo.stAlign[] stAlign;
        public ResultInfo.stReulst[] stResult;

        [DllImport("kernel32")]
        private static extern long WritePrivateProfileString(string section, string key, string val, string filePath);
        [DllImport("kernel32")]
        private static extern int GetPrivateProfileString(string section, string key, string def, StringBuilder retVal, int size, string filePath);


        public FormVision(FormMain parent)
        {
            MdiParent = mainForm = parent;

            InitializeComponent();

            LoadConfig();

            mainForm.WriteLog("Error", "Initialize", "VisionForm Recipe Load Complete", "");

            m_bOpen = new bool[2];
            m_bOpen[0] = false;
            m_bOpen[1] = false;

            InitVision();

            OpenVision();

            Vision1_rectRoi = new Rectangle(0, 0, 165, 165);
            Vision2_rectRoi = new Rectangle(0, 0, 165, 165);

            EnableSetting(false);
            pictureBox_vision_focus.MouseWheel += new MouseEventHandler(pictureBox_vision_focus_MouseWheel);
        }

        public void LoadConfig()
        {
            StringBuilder strData = new StringBuilder();

            int nRecipe;
            nRecipe = mainForm.nSelectedRecipe;

            String strFile = Application.StartupPath + @"\Config\" + nRecipe.ToString() + @"\VisionConfig.ini";
            String strTag = "COMMON";

            GetPrivateProfileString(strTag, "VISION NUM", "", strData, 32, strFile);
            nVisionNum = Convert.ToInt16(strData.ToString());

            GetPrivateProfileString(strTag, "ALIGN NUM", "", strData, 32, strFile);
            nAlignNum = Convert.ToInt16(strData.ToString());

            GetPrivateProfileString(strTag, "RESOLUTION X", "", strData, 32, strFile);
            nResolutionX = Convert.ToInt16(strData.ToString());

            GetPrivateProfileString(strTag, "RESOLUTION Y", "", strData, 32, strFile);
            nResolutionY = Convert.ToInt16(strData.ToString());

            GetPrivateProfileString(strTag, "PIXEL SIZE", "", strData, 32, strFile);
            dPixelsize = Convert.ToDouble(strData.ToString()) / 1000;

            GetPrivateProfileString(strTag, "MAGNIFICATION", "", strData, 32, strFile);
            nMagnification = Convert.ToInt16(strData.ToString());

            GetPrivateProfileString(strTag, "DISTANCE", "", strData, 32, strFile);
            dDistance = Convert.ToDouble(strData.ToString());

            GetPrivateProfileString(strTag, "EDGE LEVEL RANGE", "", strData, 32, strFile);
            nEdgeLevel = Convert.ToInt32(strData.ToString());

            GetPrivateProfileString(strTag, "EDGE MISS RANGE", "", strData, 32, strFile);
            nEdgeMiss = Convert.ToInt32(strData.ToString());

            GetPrivateProfileString(strTag, "CHECK ALIGN MARK", "", strData, 32, strFile);
            bCheckAlignMark = Convert.ToBoolean(strData.ToString());

            GetPrivateProfileString(strTag, "CHECK ALIGN EDGE", "", strData, 32, strFile);
            bCheckAlignEdge = Convert.ToBoolean(strData.ToString());

            GetPrivateProfileString(strTag, "ALIGN RANGE X", "", strData, 32, strFile);
            dAlignRangeX = Convert.ToDouble(strData.ToString());

            GetPrivateProfileString(strTag, "ALIGN RANGE Y", "", strData, 32, strFile);
            dAlignRangeY = Convert.ToDouble(strData.ToString());

            GetPrivateProfileString(strTag, "ALIGN RANGE T", "", strData, 32, strFile);
            dAlignRangeT = Convert.ToDouble(strData.ToString());

            stVision = new VisionInfo.stVision[nVisionNum];
            stAlign = new AlignInfo.stAlign[nAlignNum];
            stResult = new ResultInfo.stReulst[nAlignNum];

            for (int i = 0; i < nVisionNum; i++)
            {
                stVision[i] = new VisionInfo.stVision();
            }

            for (int i = 0; i < nAlignNum; i++)
            {
                stAlign[i] = new AlignInfo.stAlign();
                stResult[i] = new ResultInfo.stReulst();
            }


            for (int i = 0; i < nVisionNum; i++)
            {
                strTag = "VISION" + i.ToString();

                GetPrivateProfileString(strTag, "SERIAL", "", strData, 32, strFile);
                stVision[i].strSerial = strData.ToString();

                GetPrivateProfileString(strTag, "EXPOSURE", "", strData, 32, strFile);
                stVision[i].nExposure = Convert.ToInt32(strData.ToString());

                GetPrivateProfileString(strTag, "LIGHT ", "", strData, 32, strFile);
                stVision[i].nLight = Convert.ToInt32(strData.ToString());
            }


            for (int i = 0; i < nAlignNum; i++)
            {
                strTag = "ALIGN" + i.ToString();

                GetPrivateProfileString(strTag, "USING VISION", "", strData, 32, strFile);
                stAlign[i].nUsingVision = Convert.ToInt16(strData.ToString());

                GetPrivateProfileString(strTag, "UNIT X", "", strData, 32, strFile);
                stAlign[i].dUnitX = Convert.ToDouble(strData.ToString());

                GetPrivateProfileString(strTag, "UNIT Y", "", strData, 32, strFile);
                stAlign[i].dUnitY = Convert.ToDouble(strData.ToString());

                GetPrivateProfileString(strTag, "EDGE BINARY", "", strData, 32, strFile);
                stAlign[i].nEdgeBinary = Convert.ToInt16(strData.ToString());

                GetPrivateProfileString(strTag, "EDGE MORP OPEN", "", strData, 32, strFile);
                stAlign[i].nEdgeMorpOpen = Convert.ToInt32(strData.ToString());

                GetPrivateProfileString(strTag, "EDGE MORP CLOSE", "", strData, 32, strFile);
                stAlign[i].nEdgeMorpClose = Convert.ToInt32(strData.ToString());

                GetPrivateProfileString(strTag, "EDGE DIRECTION", "", strData, 32, strFile);
                stAlign[i].strEdgeDirection = strData.ToString();

                GetPrivateProfileString(strTag, "EDGE ROI START X", "", strData, 32, strFile);
                stAlign[i].pEdgeROIStart.X = Convert.ToInt32(strData.ToString());

                GetPrivateProfileString(strTag, "EDGE ROI START Y", "", strData, 32, strFile);
                stAlign[i].pEdgeROIStart.Y = Convert.ToInt32(strData.ToString());

                GetPrivateProfileString(strTag, "EDGE ROI END X", "", strData, 32, strFile);
                stAlign[i].pEdgeROIEnd.X = Convert.ToInt32(strData.ToString());

                GetPrivateProfileString(strTag, "EDGE ROI END Y", "", strData, 32, strFile);
                stAlign[i].pEdgeROIEnd.Y = Convert.ToInt32(strData.ToString());

                GetPrivateProfileString(strTag, "EDGE PRECISION", "", strData, 32, strFile);
                stAlign[i].nEdgePrecision = Convert.ToInt32(strData.ToString());

                GetPrivateProfileString(strTag, "MARK MATCHRATE ", "", strData, 32, strFile);
                stAlign[i].dMatchrate = Convert.ToDouble(strData.ToString());

                GetPrivateProfileString(strTag, "MARK ROI START X", "", strData, 32, strFile);
                stAlign[i].pMarkROIStart.X = Convert.ToInt32(strData.ToString());

                GetPrivateProfileString(strTag, "MARK ROI START Y", "", strData, 32, strFile);
                stAlign[i].pMarkROIStart.Y = Convert.ToInt32(strData.ToString());

                GetPrivateProfileString(strTag, "MARK ROI END X", "", strData, 32, strFile);
                stAlign[i].pMarkROIEnd.X = Convert.ToInt32(strData.ToString());

                GetPrivateProfileString(strTag, "MARK ROI END Y", "", strData, 32, strFile);
                stAlign[i].pMarkROIEnd.Y = Convert.ToInt32(strData.ToString());

                GetPrivateProfileString(strTag, "CHECK PREPROCESS", "", strData, 32, strFile);
                stAlign[i].bCheckProprocess = Convert.ToBoolean(strData.ToString());

                GetPrivateProfileString(strTag, "MARK BINARY", "", strData, 32, strFile);
                stAlign[i].nMarkBinary = Convert.ToInt16(strData.ToString());

                GetPrivateProfileString(strTag, "MARK MORP OPEN", "", strData, 32, strFile);
                stAlign[i].nMarkMorpOpen = Convert.ToInt32(strData.ToString());

                GetPrivateProfileString(strTag, "MARK MORP CLOSE", "", strData, 32, strFile);
                stAlign[i].nMarkMorpClose = Convert.ToInt32(strData.ToString());

                GetPrivateProfileString(strTag, "IMAGE BINARY", "", strData, 32, strFile);
                stAlign[i].nImageBinary = Convert.ToInt16(strData.ToString());

                GetPrivateProfileString(strTag, "IMAGE MORP OPEN", "", strData, 32, strFile);
                stAlign[i].nImageMorpOpen = Convert.ToInt32(strData.ToString());

                GetPrivateProfileString(strTag, "IMAGE MORP CLOSE", "", strData, 32, strFile);
                stAlign[i].nImageMorpClose = Convert.ToInt32(strData.ToString());
            }
        }

        public void SaveConfig()
        {
            int nRecipe;
            nRecipe = mainForm.nSelectedRecipe;

            String strFile = Application.StartupPath + @"\Config\" + nRecipe.ToString() + @"\VisionConfig.ini";

            WritePrivateProfileString("COMMON", "DISTANCE", dDistance.ToString(), strFile);
            WritePrivateProfileString("COMMON", "EDGE LEVEL RANGE", nEdgeLevel.ToString(), strFile);
            WritePrivateProfileString("COMMON", "EDGE MISS RANGE", nEdgeMiss.ToString(), strFile);

            WritePrivateProfileString("COMMON", "CHECK ALIGN MARK", bCheckAlignMark.ToString(), strFile);
            WritePrivateProfileString("COMMON", "CHECK ALIGN EDGE", bCheckAlignEdge.ToString(), strFile);

            WritePrivateProfileString("COMMON", "ALIGN RANGE X", dAlignRangeX.ToString(), strFile);
            WritePrivateProfileString("COMMON", "ALIGN RANGE Y", dAlignRangeY.ToString(), strFile);
            WritePrivateProfileString("COMMON", "ALIGN RANGE T", dAlignRangeT.ToString(), strFile);

            for (int i = 0; i < nVisionNum; i++)
            {
                String strTag = "VISION" + i.ToString();

                WritePrivateProfileString(strTag, "EXPOSURE", stVision[i].nExposure.ToString(), strFile);
                WritePrivateProfileString(strTag, "LIGHT", stVision[i].nLight.ToString(), strFile);
            }

            for (int i = 0; i < nAlignNum; i++)
            {
                String strTag = "ALIGN" + i.ToString();

                WritePrivateProfileString(strTag, "EDGE BINARY", stAlign[i].nEdgeBinary.ToString(), strFile);
                WritePrivateProfileString(strTag, "UNIT X", stAlign[i].dUnitX.ToString(), strFile);
                WritePrivateProfileString(strTag, "UNIT Y", stAlign[i].dUnitY.ToString(), strFile);
                WritePrivateProfileString(strTag, "EDGE MORP OPEN", stAlign[i].nEdgeMorpOpen.ToString(), strFile);
                WritePrivateProfileString(strTag, "EDGE MORP CLOSE", stAlign[i].nEdgeMorpClose.ToString(), strFile);
                WritePrivateProfileString(strTag, "EDGE DIRECTION", stAlign[i].strEdgeDirection.ToString(), strFile);
                WritePrivateProfileString(strTag, "EDGE ROI START X", stAlign[i].pEdgeROIStart.X.ToString(), strFile);
                WritePrivateProfileString(strTag, "EDGE ROI START Y", stAlign[i].pEdgeROIStart.Y.ToString(), strFile);
                WritePrivateProfileString(strTag, "EDGE ROI END X", stAlign[i].pEdgeROIEnd.X.ToString(), strFile);
                WritePrivateProfileString(strTag, "EDGE ROI END Y", stAlign[i].pEdgeROIEnd.Y.ToString(), strFile);
                WritePrivateProfileString(strTag, "EDGE PRECISION", stAlign[i].nEdgePrecision.ToString(), strFile);

                WritePrivateProfileString(strTag, "MARK MATCHRATE", stAlign[i].dMatchrate.ToString(), strFile);
                WritePrivateProfileString(strTag, "MARK ROI START X", stAlign[i].pMarkROIStart.X.ToString(), strFile);
                WritePrivateProfileString(strTag, "MARK ROI START Y", stAlign[i].pMarkROIStart.Y.ToString(), strFile);
                WritePrivateProfileString(strTag, "MARK ROI END X", stAlign[i].pMarkROIEnd.X.ToString(), strFile);
                WritePrivateProfileString(strTag, "MARK ROI END Y", stAlign[i].pMarkROIEnd.Y.ToString(), strFile);
                WritePrivateProfileString(strTag, "CHECK PREPROCESS", stAlign[i].bCheckProprocess.ToString(), strFile);
                WritePrivateProfileString(strTag, "MARK BINARY", stAlign[i].nMarkBinary.ToString(), strFile);
                WritePrivateProfileString(strTag, "MARK MORP OPEN", stAlign[i].nMarkMorpOpen.ToString(), strFile);
                WritePrivateProfileString(strTag, "MARK MORP CLOSE", stAlign[i].nMarkMorpClose.ToString(), strFile);
                WritePrivateProfileString(strTag, "IMAGE BINARY", stAlign[i].nImageBinary.ToString(), strFile);
                WritePrivateProfileString(strTag, "IMAGE MORP OPEN", stAlign[i].nImageMorpOpen.ToString(), strFile);
                WritePrivateProfileString(strTag, "IMAGE MORP CLOSE", stAlign[i].nImageMorpClose.ToString(), strFile);
            }

            string strSaveRecipe;
            strSaveRecipe = "Recipe" + mainForm.nSelectedRecipe.ToString();
            WritePrivateProfileString("RecipeName", strSaveRecipe, mainForm.ribbonTextBox_vision_recipe_name.TextBoxText.ToString(), Application.StartupPath + @"\Config\\RecipeName.ini");
            DisplayRecipeName(mainForm.nSelectedRecipe);
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

        public string DisplayFCRecipeName(int nRecipeNum)
        {
            String strFile = Application.StartupPath + @"\Config\\RecipeName.ini";
            String strRecipeName;
            StringBuilder strData = new StringBuilder();

            strRecipeName = "Recipe" + nRecipeNum.ToString();
            GetPrivateProfileString("RecipeName", strRecipeName, "", strData, 32, strFile);

            return strData.ToString();
        }

        public void DisplaySetting(int nVision)
        {
            mainForm.ribbonTextBox_vision_align_param_distance.TextBoxText = dDistance.ToString();

            mainForm.ribbonTextBox_vision_align_param_judge_x.TextBoxText = dAlignRangeX.ToString();
            mainForm.ribbonTextBox_vision_align_param_judge_y.TextBoxText = dAlignRangeY.ToString();
            mainForm.ribbonTextBox_vision_align_param_judge_t.TextBoxText = dAlignRangeT.ToString();

            mainForm.ribbonTextBox_vision_align_param_unitx.TextBoxText = stAlign[nVision].dUnitX.ToString();
            mainForm.ribbonTextBox_vision_align_param_unity.TextBoxText = stAlign[nVision].dUnitY.ToString();

            mainForm.ribbonTextBox_vision_align_edge_level.TextBoxText = nEdgeLevel.ToString();
            mainForm.ribbonTextBox_vision_align_edge_miss.TextBoxText = nEdgeMiss.ToString();
            mainForm.ribbonTextBox_vision_align_edge_preprocess_binary.TextBoxText = stAlign[nVision].nEdgeBinary.ToString();
            mainForm.ribbonTextBox_vision_align_edge_preprocess_morp_open.TextBoxText = stAlign[nVision].nEdgeMorpOpen.ToString();
            mainForm.ribbonTextBox_vision_align_edge_preprocess_morp_close.TextBoxText = stAlign[nVision].nEdgeMorpClose.ToString();
            mainForm.ribbonTextBox_vision_align_edge_roi_start_x.TextBoxText = stAlign[nVision].pEdgeROIStart.X.ToString();
            mainForm.ribbonTextBox_vision_align_edge_roi_start_y.TextBoxText = stAlign[nVision].pEdgeROIStart.Y.ToString();
            mainForm.ribbonTextBox_vision_align_edge_roi_end_x.TextBoxText = stAlign[nVision].pEdgeROIEnd.X.ToString();
            mainForm.ribbonTextBox_vision_align_edge_roi_end_y.TextBoxText = stAlign[nVision].pEdgeROIEnd.Y.ToString();
            mainForm.ribbonUpDown_vision_align_edge_precision.TextBoxText = stAlign[nVision].nEdgePrecision.ToString();


            if (stAlign[nVision].strEdgeDirection == "UPWARD")
            {
                mainForm.ribbonRadioBox_vision_align_edge_upward.Checked = true;
                mainForm.ribbonRadioBox_vision_align_edge_downward.Checked = false;
            }

            else if (stAlign[nVision].strEdgeDirection == "DOWNWARD")
            {
                mainForm.ribbonRadioBox_vision_align_edge_upward.Checked = false;
                mainForm.ribbonRadioBox_vision_align_edge_downward.Checked = true;
            }

            textBox_vision_mark_matchrate.Text = stAlign[nVision].dMatchrate.ToString();

            int nRecipe;
            nRecipe = mainForm.nSelectedRecipe;

            string DirPath = Application.StartupPath + @"\Config\" + nRecipe.ToString();

            pictureBox_vision_mark.Image = null;
            pictureBox_vision_mark.Update();

            string DirFilePath = DirPath + "\\Align_Mark" + nVision.ToString() + ".bmp";
            Bitmap AlignMark;

            try
            {
                AlignMark = new Bitmap(DirFilePath);

                pictureBox_vision_mark.Image = AlignMark;
                pictureBox_vision_mark.SizeMode = PictureBoxSizeMode.StretchImage;
            }
            catch (Exception e)
            {

            }
        }

        public void EnableSetting(bool nCase)
        {
            mainForm.ribbonTextBox_vision_align_param_distance.Enabled = nCase;
            mainForm.ribbonTextBox_vision_align_param_unitx.Enabled = nCase;
            mainForm.ribbonTextBox_vision_align_param_unity.Enabled = nCase;

            mainForm.ribbonTextBox_vision_align_param_judge_x.Enabled = nCase;
            mainForm.ribbonTextBox_vision_align_param_judge_y.Enabled = nCase;
            mainForm.ribbonTextBox_vision_align_param_judge_t.Enabled = nCase;

            mainForm.ribbonRadioBox_vision_align_param_mark.Enabled = nCase;
            mainForm.ribbonRadioBox_vision_align_param_edge.Enabled = nCase;

            if (nCase == false)
            {
                EnableEdge(nCase);
                EnableMark(nCase);
            }
        }

        public void EnableEdge(bool nCase)
        {
            mainForm.ribbonTextBox_vision_align_edge_preprocess_binary.Enabled = nCase;
            mainForm.ribbonTextBox_vision_align_edge_preprocess_morp_open.Enabled = nCase;
            mainForm.ribbonTextBox_vision_align_edge_preprocess_morp_close.Enabled = nCase;

            mainForm.ribbonRadioBox_vision_align_edge_upward.Enabled = nCase;
            mainForm.ribbonRadioBox_vision_align_edge_downward.Enabled = nCase;

            mainForm.ribbonTextBox_vision_align_edge_roi_start_x.Enabled = nCase;
            mainForm.ribbonTextBox_vision_align_edge_roi_start_y.Enabled = nCase;
            mainForm.ribbonTextBox_vision_align_edge_roi_end_x.Enabled = nCase;
            mainForm.ribbonTextBox_vision_align_edge_roi_end_y.Enabled = nCase;

            mainForm.ribbonTextBox_vision_align_edge_level.Enabled = nCase;
            mainForm.ribbonTextBox_vision_align_edge_miss.Enabled = nCase;

            mainForm.ribbonUpDown_vision_align_edge_precision.Enabled = nCase;
        }

        public void EnableMark(bool nCase)
        {
            mainForm.ribbonButton_vision_align_mark_reg.Enabled = nCase;

            button_vision_mark_reg.Enabled = nCase;
            button_vision_mark_apply.Enabled = nCase;
            button_vision_mark_cancel.Enabled = nCase;

            textBox_vision_mark_matchrate.Enabled = nCase;
        }

        public void InitVision()
        {
            int systemcount = 0;
            systemList = BGAPI2.SystemList.Instance;
            systemList.Refresh();
            systemcount = systemList.Count;

            foreach (KeyValuePair<string, BGAPI2.System> sys_pair in BGAPI2.SystemList.Instance)
            {
                sys_pair.Value.Open();
                sSystemID = sys_pair.Key;
                mSystem = systemList[sSystemID];
                interfaceList = sys_pair.Value.Interfaces;

                interfaceList.Refresh(100);

                foreach (KeyValuePair<string, BGAPI2.Interface> ifc_pair in interfaceList)
                {

                    ifc_pair.Value.Open();

                    deviceList = ifc_pair.Value.Devices;
                    deviceList.Refresh(100);

                    if (deviceList.Count == 0)
                    {
                        ifc_pair.Value.Close();
                    }

                    else
                    {
                        sInterfaceID = ifc_pair.Key;

                        if (sInterfaceID != "")
                        {

                            mInterface = interfaceList[sInterfaceID];
                            deviceList = mInterface.Devices;
                            deviceList.Refresh(100);

                            foreach (KeyValuePair<string, BGAPI2.Device> dev_pair in deviceList)
                            {

                                string CameraVendor = "";
                                string serial = "";
                                bool m_open = false;

                                CameraVendor = dev_pair.Value.Vendor.ToString();
                                //check serial
                                serial = dev_pair.Value.SerialNumber.ToString();
                                string name = dev_pair.Value.DisplayName.ToString();
                                m_open = dev_pair.Value.IsOpen;

                                //check serial
                                if (serial == stVision[0].strSerial)
                                {
                                    if (m_open == false && m_bOpen[0] == false)
                                    {
                                        dev_pair.Value.Open();
                                        sDeviceID = dev_pair.Key;

                                        if (sDeviceID == "")
                                        {
                                            Console.Read();
                                            mInterface.Close();
                                            mSystem.Close();
                                        }
                                        else
                                        {
                                            mDevice = deviceList[sDeviceID];
                                            mDevicea[0] = deviceList[sDeviceID];
                                            m_bOpen[0] = true;
                                        }
                                    }
                                    else
                                    {

                                    }
                                }
                                else if (serial == stVision[1].strSerial)
                                {
                                    if (m_open == false && m_bOpen[1] == false)
                                    {
                                        dev_pair.Value.Open();
                                        sDeviceID = dev_pair.Key;

                                        if (sDeviceID == "")
                                        {
                                            Console.Read();
                                            mInterface.Close();
                                            mSystem.Close();
                                        }
                                        else
                                        {
                                            mDevice = deviceList[sDeviceID];
                                            mDevicea[1] = deviceList[sDeviceID];
                                            m_bOpen[1] = true;
                                        }
                                    }

                                    else
                                    {

                                    }
                                }
                            }
                        }
                    }
                }
            }
        }

        public void OpenVision()
        {
            for (int i = 0; i < 2; i++)
            {
                if (m_bOpen[i] == true)
                {
                    datastreamLista[i] = mDevicea[i].DataStreams;
                    datastreamLista[i].Refresh();

                    foreach (KeyValuePair<string, BGAPI2.DataStream> dst_pair in datastreamLista[i])
                    {
                        dst_pair.Value.Open();
                        sDataStreamIDa[i] = dst_pair.Key;
                        break;
                    }

                    if (sDataStreamIDa[i] == "")
                    {
                        Console.Read();
                        mDevicea[i].Close();
                        mInterface.Close();
                        mSystem.Close();
                    }
                    else
                    {
                        mDataStreama[i] = datastreamLista[i][sDataStreamIDa[i]];
                    }

                    bufferLista[i] = mDataStreama[i].BufferList;

                    for (int j = 0; j < 4; j++)
                    {
                        mBuffera[i] = new BGAPI2.Buffer();
                        bufferLista[i].Add(mBuffera[i]);
                    }

                    foreach (KeyValuePair<string, BGAPI2.Buffer> buf_pair in bufferLista[i])
                    {
                        buf_pair.Value.QueueBuffer();
                    }

                    mDataStreama[i].RegisterNewBufferEvent(BGAPI2.Events.EventMode.EVENT_HANDLER);

                    if (i == 0)
                    {
                        mDataStreama[i].NewBufferEvent += new BGAPI2.Events.DataStreamEventControl.NewBufferEventHandler(mDataStream_NewBufferEvent1);

                        mDataStreama[i].StartAcquisition();

                        mDevicea[i].RemoteNodeList["AcquisitionStart"].Execute();
                    }

                    else if (i == 1)
                    {
                        mDataStreama[i].NewBufferEvent += new BGAPI2.Events.DataStreamEventControl.NewBufferEventHandler(mDataStream_NewBufferEvent2);

                        mDataStreama[i].StartAcquisition();

                        mDevicea[i].RemoteNodeList["AcquisitionStart"].Execute();
                    }

                }
            }
        }

        public void mDataStream_NewBufferEvent1(object sender, BGAPI2.Events.NewBufferEventArgs mDSEvent)
        {
            BGAPI2.Buffer mBufferFilled = null;
            mBufferFilled = mDSEvent.BufferObj;
            if (mBufferFilled == null)
            {

            }
            else if (mBufferFilled.IsIncomplete == true)
            {

                mBufferFilled.QueueBuffer();
            }
            else
            {
                int x, y;
                y = (int)mBufferFilled.Height;
                x = (int)mBufferFilled.Width;

                bufa[0] = mBufferFilled.MemPtr;
                Bitmap pBitmap;
                System.Drawing.Imaging.BitmapData bmpdata;
                Rectangle prcSource = new Rectangle();

                pBitmap = new System.Drawing.Bitmap((int)mBufferFilled.Width, (int)mBufferFilled.Height, System.Drawing.Imaging.PixelFormat.Format8bppIndexed);
                prcSource.X = 0;
                prcSource.Y = 0;
                prcSource.Width = (int)mBufferFilled.Width;
                prcSource.Height = (int)mBufferFilled.Height;

                System.Drawing.Imaging.ColorPalette palette = pBitmap.Palette;
                for (int i = 0; i < 256; i++)
                {
                    palette.Entries[i] = Color.FromArgb(255, i, i, i);
                }
                byte[] managedArray = new byte[prcSource.Width * prcSource.Height];
                System.Runtime.InteropServices.Marshal.Copy(mBufferFilled.MemPtr, managedArray, 0, prcSource.Width * prcSource.Height);

                pBitmap.Palette = palette;
                bmpdata = pBitmap.LockBits(prcSource, System.Drawing.Imaging.ImageLockMode.WriteOnly, System.Drawing.Imaging.PixelFormat.Format8bppIndexed);
                System.Runtime.InteropServices.Marshal.Copy(managedArray, 0, bmpdata.Scan0, prcSource.Width * prcSource.Height);
                pBitmap.UnlockBits(bmpdata);

                System.Drawing.Size resize = new System.Drawing.Size(2448 / nMagni, 2048 / nMagni);

                if (stResult[0].bCheckOriginSave)
                {
                    string DirFilePath = mainForm.dlgAuto.DirTime + "\\Origin\\Image1.bmp";
                    SaveOrigin(mainForm.dlgAuto.pictureBox_auto_vision_1, DirFilePath);

                    stResult[0].bCheckOriginSave = false;
                }

                if (stResult[0].bCheckAlignSave)
                {
                    string DirFilePath = mainForm.dlgAuto.DirTime + "\\Origin\\Image1.bmp";
                    SaveAlign(DirFilePath, 0);

                    mainForm.dlgAuto.AlignResultUpdate(0);
                    stResult[0].bCheckAlignSave = false;
                }

                if (stResult[2].bCheckOriginSave)
                {
                    string DirFilePath = mainForm.dlgAuto.DirTime + "\\Origin\\Image3.bmp";
                    SaveOrigin(mainForm.dlgAuto.pictureBox_auto_vision_1, DirFilePath);

                    stResult[2].bCheckOriginSave = false;
                }

                if (stResult[2].bCheckAlignSave)
                {
                    string DirFilePath = mainForm.dlgAuto.DirTime + "\\Origin\\Image3.bmp";
                    SaveAlign(DirFilePath, 2);

                    mainForm.dlgAuto.AlignResultUpdate(2);
                    stResult[2].bCheckAlignSave = false;
                }

                try
                {
                    if (mainForm.nSelectDisplay == 0)
                        DisplayPicture(pBitmap, mainForm.dlgAuto.pictureBox_auto_vision_1);

                    else if (mainForm.nSelectDisplay == 2)
                    {
                        if (nSelectedVision == 0)
                            DisplayPicture(pBitmap, pictureBox_vision_focus);
                    }

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                    throw;
                }

                mBufferFilled.QueueBuffer();
            }

            return;
        }

        public void mDataStream_NewBufferEvent2(object sender, BGAPI2.Events.NewBufferEventArgs mDSEvent)
        {
            BGAPI2.Buffer mBufferFilled = null;
            mBufferFilled = mDSEvent.BufferObj;
            if (mBufferFilled == null)
            {

            }
            else if (mBufferFilled.IsIncomplete == true)
            {

                mBufferFilled.QueueBuffer();
            }
            else
            {

                int x, y;
                y = (int)mBufferFilled.Height;
                x = (int)mBufferFilled.Width;

                bufa[1] = mBufferFilled.MemPtr;

                Bitmap pBitmap;
                System.Drawing.Imaging.BitmapData bmpdata;
                Rectangle prcSource = new Rectangle();


                pBitmap = new System.Drawing.Bitmap((int)mBufferFilled.Width, (int)mBufferFilled.Height, System.Drawing.Imaging.PixelFormat.Format8bppIndexed);
                prcSource.X = 0;
                prcSource.Y = 0;
                prcSource.Width = (int)mBufferFilled.Width;
                prcSource.Height = (int)mBufferFilled.Height;

                System.Drawing.Imaging.ColorPalette palette = pBitmap.Palette;
                for (int i = 0; i < 256; i++)
                {
                    palette.Entries[i] = Color.FromArgb(255, i, i, i);
                }
                byte[] managedArray = new byte[prcSource.Width * prcSource.Height];
                System.Runtime.InteropServices.Marshal.Copy(mBufferFilled.MemPtr, managedArray, 0, prcSource.Width * prcSource.Height);

                pBitmap.Palette = palette;
                bmpdata = pBitmap.LockBits(prcSource, System.Drawing.Imaging.ImageLockMode.WriteOnly, System.Drawing.Imaging.PixelFormat.Format8bppIndexed);
                System.Runtime.InteropServices.Marshal.Copy(managedArray, 0, bmpdata.Scan0, prcSource.Width * prcSource.Height);
                pBitmap.UnlockBits(bmpdata);

                if (stResult[1].bCheckOriginSave)
                {
                    string DirFilePath = mainForm.dlgAuto.DirTime + "\\Origin\\Image2.bmp";
                    SaveOrigin(mainForm.dlgAuto.pictureBox_auto_vision_2, DirFilePath);

                    stResult[1].bCheckOriginSave = false;
                }

                if (stResult[1].bCheckAlignSave)
                {
                    string DirFilePath = mainForm.dlgAuto.DirTime + "\\Origin\\Image2.bmp";
                    SaveAlign(DirFilePath, 1);

                    mainForm.dlgAuto.AlignResultUpdate(1);
                    stResult[1].bCheckAlignSave = false;
                }

                if (stResult[3].bCheckOriginSave)
                {
                    string DirFilePath = mainForm.dlgAuto.DirTime + "\\Origin\\Image4.bmp";
                    SaveOrigin(mainForm.dlgAuto.pictureBox_auto_vision_2, DirFilePath);

                    stResult[3].bCheckOriginSave = false;
                }

                if (stResult[3].bCheckAlignSave)
                {
                    string DirFilePath = mainForm.dlgAuto.DirTime + "\\Origin\\image4.bmp";
                    SaveAlign(DirFilePath, 3);

                    mainForm.dlgAuto.AlignResultUpdate(3);
                    stResult[3].bCheckAlignSave = false;
                }

                try
                {
                    if (mainForm.nSelectDisplay == 0)
                        DisplayPicture(pBitmap, mainForm.dlgAuto.pictureBox_auto_vision_2);

                    else if (mainForm.nSelectDisplay == 2)
                    {
                        if (nSelectedVision == 1)
                            DisplayPicture(pBitmap, pictureBox_vision_focus);
                    }

                    else if (mainForm.nSelectDisplay == 3)
                    {
                        DisplayPicture(pBitmap, mainForm.dlgFC.pictureBox_fc);

                        if (mainForm.dlgFC.bCheckMarkReg)
                        {

                        }
                    }

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                    throw;
                }

                mBufferFilled.QueueBuffer();
            }

            return;
        }

        public void DisplayPicture(Bitmap img, PictureBox picBox)
        {
            picBox.Invoke(new EventHandler(delegate { picBox.Image = img; }));
        }

        public void SaveOrigin(PictureBox picBox, string strPath)
        {
            picBox.Invoke(new EventHandler(delegate { picBox.Image.Save(strPath, ImageFormat.Jpeg); }));
        }

        public void SaveAlign(string strPath, int nVision)
        {
            Bitmap SaveBmp = new Bitmap(strPath);

            string DirFilePath = mainForm.dlgAuto.DirTime + "\\Align\\Image" + (nVision + 1).ToString() + ".bmp";

            PaintEventArgs e;
            Pen penRed = new Pen(Color.Red, 10);
            Pen penGreen = new Pen(Color.Green, 10);
            VisionResult = Graphics.FromImage(SaveBmp);

            if (bCheckAlignEdge)
            {
                int nStartx;
                int nStarty;

                int nEndx;
                int nEndy;

                nStartx = stResult[nVision].pStartPosition.X;
                nEndx = stResult[nVision].pEndPosition.X;

                nStarty = stResult[nVision].pStartPosition.Y;
                nEndy = stResult[nVision].pEndPosition.Y;

                VisionResult.DrawLine(penRed, nStartx, nStarty, nEndx, nEndy);
                VisionResult.DrawRectangle(penGreen, stAlign[nVision].pEdgeROIStart.X, stAlign[nVision].pEdgeROIStart.Y,
                    stAlign[nVision].pEdgeROIEnd.X - stAlign[nVision].pEdgeROIStart.X, stAlign[nVision].pEdgeROIEnd.Y - stAlign[nVision].pEdgeROIStart.Y);

                for (int i = 0; i < stResult[nVision].pEdgeAlignPoint.Length; i++)
                {
                    VisionResult.DrawRectangle(penRed, stResult[nVision].pEdgeAlignPoint[i].X, stResult[nVision].pEdgeAlignPoint[i].Y, 8, 8);

                    if (Math.Abs(stResult[nVision].pZscore[i]) > 1.5)
                        VisionResult.DrawLine(penRed, stResult[nVision].pEdgeAlignPoint[i].X, stAlign[nVision].pEdgeROIStart.Y, stResult[nVision].pEdgeAlignPoint[i].X, stAlign[nVision].pEdgeROIEnd.Y);

                    else
                        VisionResult.DrawLine(penGreen, stResult[nVision].pEdgeAlignPoint[i].X, stAlign[nVision].pEdgeROIStart.Y, stResult[nVision].pEdgeAlignPoint[i].X, stAlign[nVision].pEdgeROIEnd.Y);
                }
            }

            else if (bCheckAlignMark)
            {
                if (stResult[nVision].bAlignJudge)
                {
                    VisionResult.DrawRectangle(penGreen, stResult[nVision].pMarkAlignStartPoint.X, stResult[nVision].pMarkAlignStartPoint.Y,
                    stResult[nVision].pMarkAlignDimension.X, stResult[nVision].pMarkAlignDimension.Y);

                    VisionResult.DrawLine(penGreen, (stResult[nVision].pMarkAlignStartPoint.X + stResult[nVision].pMarkAlignDimension.X / 2),
                        (stResult[nVision].pMarkAlignStartPoint.Y + stResult[nVision].pMarkAlignDimension.Y / 2) - 5,
                        (stResult[nVision].pMarkAlignStartPoint.X + stResult[nVision].pMarkAlignDimension.X / 2),
                        (stResult[nVision].pMarkAlignStartPoint.Y + stResult[nVision].pMarkAlignDimension.Y / 2) + 5);
                }

                else
                {
                    VisionResult.DrawRectangle(penRed, stResult[nVision].pMarkAlignStartPoint.X, stResult[nVision].pMarkAlignStartPoint.Y,
                    stResult[nVision].pMarkAlignDimension.X, stResult[nVision].pMarkAlignDimension.Y);

                    VisionResult.DrawLine(penRed, (stResult[nVision].pMarkAlignStartPoint.X + stResult[nVision].pMarkAlignDimension.X / 2),
                        (stResult[nVision].pMarkAlignStartPoint.Y + stResult[nVision].pMarkAlignDimension.Y / 2) - 5,
                        (stResult[nVision].pMarkAlignStartPoint.X + stResult[nVision].pMarkAlignDimension.X / 2),
                        (stResult[nVision].pMarkAlignStartPoint.Y + stResult[nVision].pMarkAlignDimension.Y / 2) + 5);
                }
            }

            SaveBmp.Save(DirFilePath);
        }

        private void pictureBox_vision_focus_MouseDown(object sender, MouseEventArgs e)
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

        private void pictureBox_vision_focus_MouseMove(object sender, MouseEventArgs e)
        {
            if (bCheckMarkReg)
            {
                CheckMousePosition(AlignMarkRect, new System.Drawing.Point(e.X, e.Y));
                ChangeCursor();

                if (e.X > 0 && e.X < 2448)
                {
                    if (e.Y > 0 && e.Y < 2048)
                    {
                        if (bClickCheck)
                        {
                            endPos = new System.Drawing.Point(e.X, e.Y);

                            AlignMarkRect.X += endPos.X - startPos.X;
                            AlignMarkRect.Y += endPos.Y - startPos.Y;

                            startPos = endPos;
                        }

                        else if (bClickSizeLeft)
                        {
                            endPos = new System.Drawing.Point(e.X, e.Y);

                            AlignMarkRect.X += (endPos.X - startPos.X);
                            AlignMarkRect.Width -= (endPos.X - startPos.X);

                            startPos = endPos;
                        }

                        else if (bClickSizeRight)
                        {
                            endPos = new System.Drawing.Point(e.X, e.Y);

                            AlignMarkRect.Width += (endPos.X - startPos.X);

                            startPos = endPos;
                        }

                        else if (bClickSizeTop)
                        {
                            endPos = new System.Drawing.Point(e.X, e.Y);

                            AlignMarkRect.Y += (endPos.Y - startPos.Y);
                            AlignMarkRect.Height -= (endPos.Y - startPos.Y);

                            startPos = endPos;

                        }

                        else if (bClickSizeBottom)
                        {
                            endPos = new System.Drawing.Point(e.X, e.Y);

                            AlignMarkRect.Height += (endPos.Y - startPos.Y);

                            startPos = endPos;
                        }

                        else if (bClickSizeLeftTop)
                        {
                            endPos = new System.Drawing.Point(e.X, e.Y);

                            AlignMarkRect.X += (endPos.X - startPos.X);
                            AlignMarkRect.Width -= (endPos.X - startPos.X);
                            AlignMarkRect.Y += (endPos.Y - startPos.Y);
                            AlignMarkRect.Height -= (endPos.Y - startPos.Y);

                            startPos = endPos;
                        }

                        else if (bClickSizeLeftBottom)
                        {
                            endPos = new System.Drawing.Point(e.X, e.Y);

                            AlignMarkRect.X += (endPos.X - startPos.X);
                            AlignMarkRect.Width -= (endPos.X - startPos.X);
                            AlignMarkRect.Height += (endPos.Y - startPos.Y);

                            startPos = endPos;
                        }

                        else if (bClickSizeRightTop)
                        {
                            endPos = new System.Drawing.Point(e.X, e.Y);

                            AlignMarkRect.Width += (endPos.X - startPos.X);
                            AlignMarkRect.Y += (endPos.Y - startPos.Y);
                            AlignMarkRect.Height -= (endPos.Y - startPos.Y);

                            startPos = endPos;
                        }

                        else if (bClickSizeRightBottom)
                        {
                            endPos = new System.Drawing.Point(e.X, e.Y);

                            AlignMarkRect.Width += (endPos.X - startPos.X);
                            AlignMarkRect.Height += (endPos.Y - startPos.Y);

                            startPos = endPos;
                        }
                    }
                }
            }

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
                    pictureBox_vision_focus.Cursor = Cursors.SizeNWSE;

                else if (MouseInBottom)
                    pictureBox_vision_focus.Cursor = Cursors.SizeNESW;

                else
                    pictureBox_vision_focus.Cursor = Cursors.SizeWE;
            }

            else if (MouseInRight)
            {
                if (MouseInTop)
                    pictureBox_vision_focus.Cursor = Cursors.SizeNESW;

                else if (MouseInBottom)
                    pictureBox_vision_focus.Cursor = Cursors.SizeNWSE;

                else
                    pictureBox_vision_focus.Cursor = Cursors.SizeWE;
            }

            else if (MouseInTop || MouseInBottom)
                pictureBox_vision_focus.Cursor = Cursors.SizeNS;

            else
                pictureBox_vision_focus.Cursor = Cursors.Default;
        }

        private void pictureBox_vision_focus_MouseUp(object sender, MouseEventArgs e)
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

        private void pictureBox_vision_focus_MouseWheel(object sender, MouseEventArgs e)
        {
            if (bCheckMarkReg)
            {
                if (e.Delta / 120 > 0)
                {
                    AlignMarkRect.X--;
                    AlignMarkRect.Width += 2;

                }

                else
                {
                    AlignMarkRect.X++;
                    AlignMarkRect.Width -= 2;
                }
            }
        }

        private void pictureBox_vision_focus_Paint(object sender, PaintEventArgs e)
        {
            using (Pen penGreen = new Pen(Color.LimeGreen, 1))
            {
                if (bCheckMarkReg)
                    e.Graphics.DrawRectangle(penGreen, AlignMarkRect.X, AlignMarkRect.Y, AlignMarkRect.Width, AlignMarkRect.Height);

                if (bCheckManual)
                {
                    if (bCheckManualResult)
                    {
                        e.Graphics.DrawRectangle(penGreen, pManualMarkStart.X, pManualMarkStart.Y, pManualMarkDimension.X, pManualMarkDimension.Y);
                        e.Graphics.DrawLine(penGreen, pManualMarkStart.X + pManualMarkDimension.X / 2, (pManualMarkStart.Y + pManualMarkDimension.Y / 2) - 5,
                            pManualMarkStart.X + pManualMarkDimension.X / 2, (pManualMarkStart.Y + pManualMarkDimension.Y / 2) + 5);
                        e.Graphics.DrawLine(penGreen, (pManualMarkStart.X + pManualMarkDimension.X / 2) - 5, (pManualMarkStart.Y + pManualMarkDimension.Y / 2),
                            (pManualMarkStart.X + pManualMarkDimension.X / 2) + 5, (pManualMarkStart.Y + pManualMarkDimension.Y / 2));
                    }
                        
                }
            }

            using (Pen penRed = new Pen(Color.Red, 1))
            {
                if (bCheckManual)
                {
                    if (!bCheckManualResult)
                        e.Graphics.DrawRectangle(penRed, pManualMarkStart.X, pManualMarkStart.Y, pManualMarkDimension.X, pManualMarkDimension.Y);
                }
            }
        }

        public void FindEdge(int nVision)
        {
            Bitmap findBitmap;

            string DirPath = Environment.CurrentDirectory + @"\Data";

            DirectoryInfo di = new DirectoryInfo(DirPath);
            try
            {
                if (!di.Exists) Directory.CreateDirectory(DirPath);
            }
            catch (Exception e)
            {

            }

            string DirFilePath;

            if (nVision == 0)
                DirFilePath = DirPath + "\\1.bmp";

            else if (nVision == 1)
                DirFilePath = DirPath + "\\2.bmp";

            else if (nVision == 2)
                DirFilePath = DirPath + "\\3.bmp";

            else
                DirFilePath = DirPath + "\\4.bmp";


            findBitmap = new Bitmap(DirFilePath);

            stResult[nVision].pEdgeAlignPoint = new System.Drawing.Point[stAlign[nVision].nEdgePrecision];
            stResult[nVision].pZscore = new double[stAlign[nVision].nEdgePrecision];

            if (stAlign[nVision].strEdgeDirection == "UPWARD")
            {
                int nPoint;

                for (int i = 0; i < stAlign[nVision].nEdgePrecision; i++)
                {
                    for (int j = stAlign[nVision].pEdgeROIEnd.Y; j > stAlign[nVision].pEdgeROIStart.Y; j--)
                    {
                        nPoint = (int)stAlign[nVision].pEdgeROIStart.X + ((stAlign[nVision].pEdgeROIEnd.X - stAlign[nVision].pEdgeROIStart.X) / (stAlign[nVision].nEdgePrecision + 1) * (i + 1));

                        Color colorPixel = findBitmap.GetPixel(nPoint, j);
                        int nColorPixel = (colorPixel.R + colorPixel.G + colorPixel.B) / 3;
                        if (nColorPixel >= stAlign[nVision].nEdgeBinary)
                            nColorPixel = 255;

                        else if (nColorPixel < stAlign[nVision].nEdgeBinary)
                            nColorPixel = 0;

                        if (nColorPixel == 255)
                        {
                            stResult[nVision].pEdgeAlignPoint[i].X = nPoint;
                            stResult[nVision].pEdgeAlignPoint[i].Y = j;

                            break;
                        }
                    }
                }
            }

            else if (stAlign[nVision].strEdgeDirection == "DOWNWARD")
            {
                int nPoint;

                for (int i = 0; i < stAlign[nVision].nEdgePrecision; i++)
                {
                    for (int j = stAlign[nVision].pEdgeROIStart.Y; j < stAlign[nVision].pEdgeROIEnd.Y; j++)
                    {
                        nPoint = (int)stAlign[nVision].pEdgeROIStart.X + ((stAlign[nVision].pEdgeROIEnd.X - stAlign[nVision].pEdgeROIStart.X) / (stAlign[nVision].nEdgePrecision + 1) * (i + 1));

                        Color colorPixel = findBitmap.GetPixel(nPoint, j);
                        int nColorPixel = (colorPixel.R + colorPixel.G + colorPixel.B) / 3;
                        if (nColorPixel >= stAlign[nVision].nEdgeBinary)
                            nColorPixel = 255;

                        else if (nColorPixel < stAlign[nVision].nEdgeBinary)
                            nColorPixel = 0;

                        if (nColorPixel == 255)
                        {
                            stResult[nVision].pEdgeAlignPoint[i].X = nPoint;
                            stResult[nVision].pEdgeAlignPoint[i].Y = j;

                            break;
                        }
                    }
                }
            }

            double dSum = 0.0;
            double dAvg = 0.0;
            double dDispersion = 0.0;
            double dSD = 0.0;

            for (int i = 0; i < stAlign[nVision].nEdgePrecision; i++)
            {
                dSum += stResult[nVision].pEdgeAlignPoint[i].Y;
            }

            dAvg = dSum / stAlign[nVision].nEdgePrecision;

            for (int i = 0; i < stAlign[nVision].nEdgePrecision; i++)
            {
                dDispersion += Math.Pow((stResult[nVision].pEdgeAlignPoint[i].Y - dAvg), 2);
            }

            dSD = Math.Sqrt(dDispersion / (stAlign[nVision].nEdgePrecision - 1));

            int count = 0;
            for (int i = 0; i < stAlign[nVision].nEdgePrecision; i++)
            {
                stResult[nVision].pZscore[i] = (stResult[nVision].pEdgeAlignPoint[i].Y - dAvg) / dSD;

                if (Math.Abs((stResult[nVision].pEdgeAlignPoint[i].Y - dAvg) / dSD) > 1.5)
                    count++;
            }

            double sumAnBn = 0.0;
            double sumAn = 0.0;
            double sumBn = 0.0;
            double sumAnAn = 0.0;

            for (int i = 0; i < stResult[nVision].pEdgeAlignPoint.Length; i++)
            {
                sumAnBn += stResult[nVision].pEdgeAlignPoint[i].X * stResult[nVision].pEdgeAlignPoint[i].Y;
                sumAn += stResult[nVision].pEdgeAlignPoint[i].X;
                sumBn += stResult[nVision].pEdgeAlignPoint[i].Y;
                sumAnAn += stResult[nVision].pEdgeAlignPoint[i].X * stResult[nVision].pEdgeAlignPoint[i].X;
            }

            int n = stResult[nVision].pEdgeAlignPoint.Length;
            double Q = sumAnAn * n - sumAn * sumAn;

            double theta1 = (n * sumAnBn - sumAn * sumBn) / Q;
            double theta0 = (-sumAn * sumAnBn + sumAnAn * sumBn) / Q;

            stResult[nVision].pStartPosition.X = stAlign[nVision].pEdgeROIStart.X;
            stResult[nVision].pStartPosition.Y = (int)(theta0 + (theta1) * stAlign[nVision].pEdgeROIStart.X);

            stResult[nVision].pEndPosition.X = stAlign[nVision].pEdgeROIEnd.X;
            stResult[nVision].pEndPosition.Y = (int)(theta0 + (theta1) * stAlign[nVision].pEdgeROIEnd.X);

            stResult[nVision].pAlignResult.X = 1224;
            stResult[nVision].pAlignResult.Y = (int)(theta0 + (theta1) * 1224);
            stResult[nVision].bCheckAlignSave = true;

            if (count >= 1)
                stResult[nVision].bResultAlign = false;

            else
                stResult[nVision].bResultAlign = true;

        }

        public void FindMark(int nVision)
        {
            Bitmap InputBmp;
            Bitmap SearchBmp;
            Bitmap ResultBmp;

            int nRecipe;
            nRecipe = mainForm.nSelectedRecipe;

            string DirOrigin = mainForm.dlgAuto.DirTime + "\\Origin\\Image" + (nVision + 1).ToString() + ".bmp";
            string DirPath = Application.StartupPath + @"\Config\" + nRecipe.ToString();

            while (true)
            {
                try
                {
                    string strPath = DirOrigin;
                    InputBmp = new Bitmap(strPath);

                    string strMark = DirPath + "\\Align_Mark" + nVision.ToString() + ".bmp";
                    SearchBmp = new Bitmap(strMark);

                    ResultBmp = new Bitmap(2448, 2048);

                    Mat inputMat = OpenCvSharp.Extensions.BitmapConverter.ToMat(InputBmp);
                    Mat searchMat = OpenCvSharp.Extensions.BitmapConverter.ToMat(SearchBmp);
                    Mat resultMat = OpenCvSharp.Extensions.BitmapConverter.ToMat(ResultBmp);

                    stResult[nVision].pAlignResult.X = 0;
                    stResult[nVision].pAlignResult.Y = 0;
                    stResult[nVision].dMatchrate = 0.0;

                    Cv2.MatchTemplate(inputMat, searchMat, resultMat, TemplateMatchModes.CCoeffNormed);

                    OpenCvSharp.Point minloc, maxloc;
                    double minval, maxval;
                    Cv2.MinMaxLoc(resultMat, out minval, out maxval, out minloc, out maxloc);

                    stResult[nVision].pMarkAlignStartPoint.X = maxloc.X;
                    stResult[nVision].pMarkAlignStartPoint.Y = maxloc.Y;

                    stResult[nVision].pMarkAlignDimension.X = searchMat.Width;
                    stResult[nVision].pMarkAlignDimension.Y = searchMat.Height;

                    stResult[nVision].pAlignResult.X = (maxloc.X + searchMat.Width / 2);
                    stResult[nVision].pAlignResult.Y = (maxloc.Y + searchMat.Height / 2);
                    stResult[nVision].dMatchrate = maxval * 100;

                    stResult[nVision].bCheckAlignSave = true;

                    if (stResult[nVision].dMatchrate <= stAlign[nVision].dMatchrate)
                        stResult[nVision].bAlignJudge = false;

                    else
                        stResult[nVision].bAlignJudge = true;
                    break;
                }
                catch
                {

                }
            }
        }

        public void FindMarkManual(int nVision)
        {
            Bitmap InputBmp;
            Bitmap SearchBmp;
            Bitmap ResultBmp;

            int nRecipe;
            nRecipe = mainForm.nSelectedRecipe;

            string DirPath = Application.StartupPath + @"\Config\" + nRecipe.ToString();

            string strPath = DirPath + "\\Align_Origin" + nVision.ToString() + ".bmp";
            InputBmp = new Bitmap(strPath);

            string strMark = DirPath + "\\Align_Mark" + nVision.ToString() + ".bmp";
            SearchBmp = new Bitmap(strMark);

            ResultBmp = new Bitmap(2448, 2048);

            Mat inputMat = OpenCvSharp.Extensions.BitmapConverter.ToMat(InputBmp);
            Mat searchMat = OpenCvSharp.Extensions.BitmapConverter.ToMat(SearchBmp);
            Mat resultMat = OpenCvSharp.Extensions.BitmapConverter.ToMat(ResultBmp);

            Cv2.MatchTemplate(inputMat, searchMat, resultMat, TemplateMatchModes.CCoeffNormed);

            OpenCvSharp.Point minloc, maxloc;
            double minval, maxval;
            Cv2.MinMaxLoc(resultMat, out minval, out maxval, out minloc, out maxloc);

            pManualMarkStart.X = 0;
            pManualMarkStart.Y = 0;

            pManualMarkDimension.X = 0;
            pManualMarkDimension.Y = 0;

            pManualMarkStart.X = maxloc.X / nMagni;
            pManualMarkStart.Y = maxloc.Y / nMagni;
            pManualMarkDimension.X = searchMat.Width / nMagni;
            pManualMarkDimension.Y = searchMat.Height / nMagni;

            mainForm.ribbonTextBox_vision_align_mark_matchrate.TextBoxText = (maxval * 100).ToString();
            mainForm.ribbonTextBox_vision_align_mark_detect_x.TextBoxText = (maxloc.X + searchMat.Width / 2).ToString();
            mainForm.ribbonTextBox_vision_align_mark_detect_y.TextBoxText = (maxloc.Y + searchMat.Height / 2).ToString();
            
            if (maxval * 100 > stAlign[nSelectedAlign].dMatchrate)
                bCheckManualResult = true;

            else
                bCheckManualResult = false;

            bCheckManual = true;
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

            double dXModify;
            double dYModify;
            double dTModify;

            dXPos1 = stResult[0].pAlignResult.X - (nResolutionX / 2);
            dXPos2 = stResult[1].pAlignResult.X - (nResolutionX / 2);
            dXPos3 = stResult[2].pAlignResult.X - (nResolutionX / 2);
            dXPos4 = stResult[3].pAlignResult.X - (nResolutionX / 2);

            dYPos1 = stResult[0].pAlignResult.Y - (nResolutionY / 2);
            dYPos2 = stResult[1].pAlignResult.Y - (nResolutionY / 2);
            dYPos3 = stResult[2].pAlignResult.Y - (nResolutionY / 2);
            dYPos4 = stResult[3].pAlignResult.Y - (nResolutionY / 2);


            // edge 인 경우
            //dT12 = (dYPos2 - dYPos1) / dDistance;
            //dT34 = (dYPos4 - dYPos3) / dDistance;

            // mark 인 경우
            // align 위치 값을 이용해서 거리를 계산해야 한다.
            // unit 위치가 있어도 카메라와의 거리 값이 있기 때문에 
            dT12 = (dYPos2 - dYPos1) / (stAlign[1].dUnitX - stAlign[0].dUnitX - dDistance);
            dT34 = (dYPos4 - dYPos3) / (stAlign[3].dUnitX - stAlign[2].dUnitX - dDistance);

            dXModify = (dXPos1 + dXPos2 + dXPos3 + dXPos4) / 4;
            dYModify = (dYPos1 + dYPos2 + dYPos3 + dYPos4) / 4;
            dTModify = (dT12 + dT34) / 2;

            dXModify *= dPixelsize / nMagnification;
            dYModify *= dPixelsize / nMagnification;

            textBoxString(mainForm.dlgAuto.label_auto_result_modify_x_value, dXModify.ToString("F3") + "mm");
            textBoxString(mainForm.dlgAuto.label_auto_result_modify_y_value, dYModify.ToString("F3") + "mm");
            textBoxString(mainForm.dlgAuto.label_auto_result_modify_t_value, dTModify.ToString("F4") + "˚");

            mainForm.dlgAuto.dAutoModifyX = dXModify;
            mainForm.dlgAuto.dAutoModifyY = dYModify;
            mainForm.dlgAuto.dAutoModifyT = dTModify;

            textBoxString(mainForm.dlgAuto.label_auto_total_judge, "OK");
            mainForm.dlgAuto.label_auto_total_judge.ForeColor = Color.LimeGreen;

            for (int i = 0; i < 4; i++)
            {
                if (stResult[i].bAlignJudge == false)
                {
                    textBoxString(mainForm.dlgAuto.label_auto_total_judge, "NG");
                    mainForm.dlgAuto.label_auto_total_judge.ForeColor = Color.Red;
                    bRet = false;
                    break;
                }
            }

            if (Math.Abs(mainForm.dlgAuto.dAutoModifyX) >= dAlignRangeX)
            {
                textBoxString(mainForm.dlgAuto.label_auto_modify_x_judge, "NG");
                textBoxString(mainForm.dlgAuto.label_auto_total_judge, "NG");
                mainForm.dlgAuto.label_auto_modify_x_judge.ForeColor = Color.Red;
                mainForm.dlgAuto.label_auto_total_judge.ForeColor = Color.Red;

                bRet = false;
            }

            else
            {
                textBoxString(mainForm.dlgAuto.label_auto_modify_x_judge, "OK");
                mainForm.dlgAuto.label_auto_modify_x_judge.ForeColor = Color.LimeGreen;
            }

            if (Math.Abs(mainForm.dlgAuto.dAutoModifyY) >= dAlignRangeY)
            {
                textBoxString(mainForm.dlgAuto.label_auto_modify_y_judge, "NG");
                textBoxString(mainForm.dlgAuto.label_auto_total_judge, "NG");
                mainForm.dlgAuto.label_auto_modify_y_judge.ForeColor = Color.Red;
                mainForm.dlgAuto.label_auto_total_judge.ForeColor = Color.Red;

                bRet = false;
            }

            else
            {
                textBoxString(mainForm.dlgAuto.label_auto_modify_y_judge, "OK");
                mainForm.dlgAuto.label_auto_modify_y_judge.ForeColor = Color.LimeGreen;
            }

            if (Math.Abs(mainForm.dlgAuto.dAutoModifyT) >= dAlignRangeT)
            {
                textBoxString(mainForm.dlgAuto.label_auto_modify_t_judge, "NG");
                textBoxString(mainForm.dlgAuto.label_auto_total_judge, "NG");
                mainForm.dlgAuto.label_auto_modify_t_judge.ForeColor = Color.Red;
                mainForm.dlgAuto.label_auto_total_judge.ForeColor = Color.Red;

                bRet = false;
            }

            else
            {
                textBoxString(mainForm.dlgAuto.label_auto_modify_t_judge, "OK");
                mainForm.dlgAuto.label_auto_modify_t_judge.ForeColor = Color.LimeGreen;
            }

            return bRet;
        }

        public void textBoxString(Label textBox, string strText)
        {
            textBox.Invoke(new EventHandler(delegate { textBox.Text = strText; }));
        }

        public void LoadRecipe()
        {
            FormRecipeSelect dlgSelectRecipe = new FormRecipeSelect();

            dlgSelectRecipe.Owner = this;

            dlgSelectRecipe.Text = "레시피 불러오기";
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
                    DisplayFCRecipeName(mainForm.nSelectedRecipe);

                    LoadConfig();
                    DisplaySetting(nSelectedAlign);
                    
                    mainForm.dlgFC.LoadConfig();
                    mainForm.dlgFC.DisplaySetting();
                }
            }

            dlgSelectRecipe.Dispose();
        }

        public void SaveRecipe()
        {
            FormRecipeSelect dlgSelectRecipe = new FormRecipeSelect();
            dlgSelectRecipe.Owner = this;

            dlgSelectRecipe.Text = "레시피 저장하기";
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
                    WritePrivateProfileString("RecipeName", strSaveRecipe, mainForm.ribbonTextBox_vision_recipe_name.TextBoxText.ToString(), strFile);
                    DisplayRecipeName(mainForm.nSelectedRecipe);
                    DisplayFCRecipeName(mainForm.nSelectedRecipe);

                    LoadConfig();
                    DisplaySetting(nSelectedAlign);
                    
                    mainForm.dlgFC.LoadConfig();
                    mainForm.dlgFC.DisplaySetting();
                }

                else
                {
                    if (MessageBox.Show("레시피를 덮어씌우겠습니까?", "RTR LASER", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        mainForm.nSelectedRecipe = dlgSelectRecipe.nSelectRecipe + 1;

                        string strSaveRecipe;
                        strSaveRecipe = "Recipe" + mainForm.nSelectedRecipe.ToString();
                        WritePrivateProfileString("RecipeName", strSaveRecipe, mainForm.ribbonTextBox_vision_recipe_name.TextBoxText.ToString(), strFile);
                        DisplayRecipeName(mainForm.nSelectedRecipe);
                        DisplayFCRecipeName(mainForm.nSelectedRecipe);

                        SaveConfig();
                        mainForm.dlgFC.SaveConfig();

                        LoadConfig();
                        DisplaySetting(nSelectedAlign);
                        
                        mainForm.dlgFC.LoadConfig();
                        mainForm.dlgFC.DisplaySetting();
                    }

                    else
                    {
                    }
                }
            }

            dlgSelectRecipe.Dispose();
        }

        // 측정 관련 button 기능들
        private void button_vision_measurement_mode_Click(object sender, EventArgs e)
        {

        }

        private void button_vision_measurement_control1_Click(object sender, EventArgs e)
        {

        }

        private void button_vision_measurement_control2_Click(object sender, EventArgs e)
        {

        }

        private void button_vision_measurement_control3_Click(object sender, EventArgs e)
        {

        }

        private void button_vision_measurement_control4_Click(object sender, EventArgs e)
        {

        }

        private void button_vision_measurement_control5_Click(object sender, EventArgs e)
        {

        }

        private void button_vision_mark_reg_Click(object sender, EventArgs e)
        {
            AlignMarkRect = new Rectangle(0, 0, 100, 100);
            bCheckMarkReg = true;
        }

        private void button_vision_mark_apply_Click(object sender, EventArgs e)
        {
            CreateAlignMark(nSelectedAlign);

            bCheckMarkReg = false;
        }

        private void button_vision_mark_cancel_Click(object sender, EventArgs e)
        {
            AlignMarkRect = new Rectangle(0, 0, 100, 100);
            bCheckMarkReg = false;
        }

        public void CreateAlignMark(int nVision)
        {
            int nRecipe;
            nRecipe = mainForm.nSelectedRecipe;

            string DirPath = Application.StartupPath + @"\Config\" + nRecipe.ToString();

            pictureBox_vision_mark.Image = null;
            pictureBox_vision_mark.Update();
            string strPath = DirPath + "\\Align_Origin" + nVision.ToString() + ".bmp";

            mainForm.dlgVision.SaveOrigin(pictureBox_vision_focus, strPath);

            Bitmap AlignImage = new Bitmap(strPath);

            string DirFilePath = DirPath + "\\Align_Mark" + nVision.ToString() + ".bmp";

            Bitmap AlignMark = new Bitmap(AlignImage);
            AlignMark = AlignImage.Clone(new Rectangle(AlignMarkRect.X * nMagni, AlignMarkRect.Y * nMagni, AlignMarkRect.Width * nMagni, AlignMarkRect.Height * nMagni), System.Drawing.Imaging.PixelFormat.DontCare);
            AlignImage.Dispose();
            AlignImage = null;
            AlignMark.Save(DirFilePath);

            pictureBox_vision_mark.Image = AlignMark;
            pictureBox_vision_mark.SizeMode = PictureBoxSizeMode.StretchImage;
        }

        private void textBox_vision_mark_matchrate_TextChanged(object sender, EventArgs e)
        {
            String strInput = textBox_vision_mark_matchrate.Text;

            if (double.TryParse(strInput, out stAlign[nSelectedAlign].dMatchrate))
            {
            }

            else
            {
            }
        }

        public void SimulationMarkDetect()
        {
            int nRecipe;
            nRecipe = mainForm.nSelectedRecipe;

            string DirPath = Application.StartupPath + @"\Config\" + nRecipe.ToString();

            string strPath = DirPath + "\\Align_Origin" + nSelectedAlign.ToString() + ".bmp";

            mainForm.dlgVision.SaveOrigin(pictureBox_vision_focus, strPath);

            Bitmap AlignOrigin = new Bitmap(strPath);
            string strMark = DirPath + "\\Align_Mark" + nSelectedAlign.ToString() + ".bmp";

            Bitmap AlignMark = new Bitmap(strMark);
            Bitmap AlignResult = new Bitmap(2448, 2048);

            FindMarkManual(nSelectedAlign);
        }

        public void VisionMagni(int nMagniEvent)
        {
            if (nMagniEvent == 1)
            {
                if ((int)nMagni == 2)
                {
                    nMagni = 1;
                    AlignMarkRect.X = AlignMarkRect.X * 2;
                    AlignMarkRect.Y = AlignMarkRect.Y * 2;
                    AlignMarkRect.Width = AlignMarkRect.Width * 2;
                    AlignMarkRect.Height = AlignMarkRect.Height * 2;

                    pManualMarkStart.X = pManualMarkStart.X * 2;
                    pManualMarkStart.Y = pManualMarkStart.Y * 2;
                    pManualMarkDimension.X = pManualMarkDimension.X * 2;
                    pManualMarkDimension.Y = pManualMarkDimension.Y * 2;
                }

                else if ((int)nMagni == 4)
                {
                    nMagni = 1;
                    AlignMarkRect.X = AlignMarkRect.X * 4;
                    AlignMarkRect.Y = AlignMarkRect.Y * 4;
                    AlignMarkRect.Width = AlignMarkRect.Width * 4;
                    AlignMarkRect.Height = AlignMarkRect.Height * 4;

                    pManualMarkStart.X = pManualMarkStart.X * 4;
                    pManualMarkStart.Y = pManualMarkStart.Y * 4;
                    pManualMarkDimension.X = pManualMarkDimension.X * 4;
                    pManualMarkDimension.Y = pManualMarkDimension.Y * 4;
                }

                pictureBox_vision_focus.Size = new System.Drawing.Size(2448, 2048);
                pictureBox_vision_focus.SizeMode = PictureBoxSizeMode.Normal;
            }

            else if (nMagniEvent == 2)
            {
                if ((int)nMagni == 1)
                {
                    nMagni = 2;

                    AlignMarkRect.X = AlignMarkRect.X / 2;
                    AlignMarkRect.Y = AlignMarkRect.Y / 2;
                    AlignMarkRect.Width = AlignMarkRect.Width / 2;
                    AlignMarkRect.Height = AlignMarkRect.Height / 2;

                    pManualMarkStart.X = pManualMarkStart.X / 2;
                    pManualMarkStart.Y = pManualMarkStart.Y / 2;
                    pManualMarkDimension.X = pManualMarkDimension.X / 2;
                    pManualMarkDimension.Y = pManualMarkDimension.Y / 2;
                }

                else if ((int)nMagni == 4)
                {
                    nMagni = 2;

                    AlignMarkRect.X = AlignMarkRect.X * 2;
                    AlignMarkRect.Y = AlignMarkRect.Y * 2;
                    AlignMarkRect.Width = AlignMarkRect.Width * 2;
                    AlignMarkRect.Height = AlignMarkRect.Height * 2;

                    pManualMarkStart.X = pManualMarkStart.X * 2;
                    pManualMarkStart.Y = pManualMarkStart.Y * 2;
                    pManualMarkDimension.X = pManualMarkDimension.X * 2;
                    pManualMarkDimension.Y = pManualMarkDimension.Y * 2;
                }

                pictureBox_vision_focus.Size = new System.Drawing.Size(1224, 1024);
                pictureBox_vision_focus.SizeMode = PictureBoxSizeMode.Zoom;
            }

            else if (nMagniEvent == 4)
            {
                if ((int)nMagni == 1)
                {
                    nMagni = 4;

                    AlignMarkRect.X = AlignMarkRect.X / 4;
                    AlignMarkRect.Y = AlignMarkRect.Y / 4;
                    AlignMarkRect.Width = AlignMarkRect.Width / 4;
                    AlignMarkRect.Height = AlignMarkRect.Height / 4;

                    pManualMarkStart.X = pManualMarkStart.X / 4;
                    pManualMarkStart.Y = pManualMarkStart.Y / 4;
                    pManualMarkDimension.X = pManualMarkDimension.X / 4;
                    pManualMarkDimension.Y = pManualMarkDimension.Y / 4;
                }

                else if ((int)nMagni == 2)
                {
                    nMagni = 4;

                    AlignMarkRect.X = AlignMarkRect.X / 2;
                    AlignMarkRect.Y = AlignMarkRect.Y / 2;
                    AlignMarkRect.Width = AlignMarkRect.Width / 2;
                    AlignMarkRect.Height = AlignMarkRect.Height / 2;

                    pManualMarkStart.X = pManualMarkStart.X / 2;
                    pManualMarkStart.Y = pManualMarkStart.Y / 2;
                    pManualMarkDimension.X = pManualMarkDimension.X / 2;
                    pManualMarkDimension.Y = pManualMarkDimension.Y / 2;
                }

                pictureBox_vision_focus.Size = new System.Drawing.Size(612, 512);
                pictureBox_vision_focus.SizeMode = PictureBoxSizeMode.Zoom;
            }
        }
    }
}