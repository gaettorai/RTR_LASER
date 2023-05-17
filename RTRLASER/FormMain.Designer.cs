
namespace RTRLASER
{
    partial class FormMain
    {
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMain));
            this.ribbonPanel_split = new System.Windows.Forms.RibbonPanel();
            this.ribbonRadioBox_split_array = new System.Windows.Forms.RibbonCheckBox();
            this.ribbonRadioBox_split_size = new System.Windows.Forms.RibbonCheckBox();
            this.ribbonSeparator_split_1 = new System.Windows.Forms.RibbonSeparator();
            this.ribbonTextBox_split_row = new System.Windows.Forms.RibbonTextBox();
            this.ribbonTextBox_split_col = new System.Windows.Forms.RibbonTextBox();
            this.ribbonCheckBox_split_apply = new System.Windows.Forms.RibbonCheckBox();
            this.ribbonButton_split_save = new System.Windows.Forms.RibbonButton();
            this.ribbonPanel_laser_center = new System.Windows.Forms.RibbonPanel();
            this.ribbonTextBox_laser_center_x = new System.Windows.Forms.RibbonTextBox();
            this.ribbonTextBox_laser_center_y = new System.Windows.Forms.RibbonTextBox();
            this.ribbonPanel_marking = new System.Windows.Forms.RibbonPanel();
            this.ribbonCheckBox_marking_guide = new System.Windows.Forms.RibbonCheckBox();
            this.ribbonCheckBox_marking_align = new System.Windows.Forms.RibbonCheckBox();
            this.ribbonButton_marking_mark = new System.Windows.Forms.RibbonButton();
            this.ribbonButton_vision_cam_right = new System.Windows.Forms.RibbonButton();
            this.ribbonPanel_vision_align = new System.Windows.Forms.RibbonPanel();
            this.ribbonButton_vision_align_1 = new System.Windows.Forms.RibbonButton();
            this.ribbonButton_vision_align_3 = new System.Windows.Forms.RibbonButton();
            this.ribbonButton_vision_align_2 = new System.Windows.Forms.RibbonButton();
            this.ribbonButton_vision_align_4 = new System.Windows.Forms.RibbonButton();
            this.ribbonPanel_vision_align_param = new System.Windows.Forms.RibbonPanel();
            this.ribbonButton_vision_align_param_modify = new System.Windows.Forms.RibbonButton();
            this.ribbonButton_vision_align_param_apply = new System.Windows.Forms.RibbonButton();
            this.ribbonButton_vision_align_param_cancel = new System.Windows.Forms.RibbonButton();
            this.ribbonSeparator_vision_align_param_1 = new System.Windows.Forms.RibbonSeparator();
            this.ribbonRadioBox_vision_align_param_mark = new System.Windows.Forms.RibbonCheckBox();
            this.ribbonRadioBox_vision_align_param_edge = new System.Windows.Forms.RibbonCheckBox();
            this.ribbonSeparator_vision_align_param_2 = new System.Windows.Forms.RibbonSeparator();
            this.ribbonTextBox_vision_align_param_unitx = new System.Windows.Forms.RibbonTextBox();
            this.ribbonTextBox_vision_align_param_unity = new System.Windows.Forms.RibbonTextBox();
            this.ribbonTextBox_vision_align_param_distance = new System.Windows.Forms.RibbonTextBox();
            this.ribbonSeparator_vision_align_param_3 = new System.Windows.Forms.RibbonSeparator();
            this.ribbonTextBox_vision_align_param_judge_x = new System.Windows.Forms.RibbonTextBox();
            this.ribbonTextBox_vision_align_param_judge_y = new System.Windows.Forms.RibbonTextBox();
            this.ribbonTextBox_vision_align_param_judge_t = new System.Windows.Forms.RibbonTextBox();
            this.ribbonButton_fc_stop = new System.Windows.Forms.RibbonButton();
            this.ribbonPanel_vision_align_edge = new System.Windows.Forms.RibbonPanel();
            this.ribbonUpDown_vision_align_edge_precision = new System.Windows.Forms.RibbonUpDown();
            this.ribbonRadioBox_vision_align_edge_upward = new System.Windows.Forms.RibbonCheckBox();
            this.ribbonRadioBox_vision_align_edge_downward = new System.Windows.Forms.RibbonCheckBox();
            this.ribbonSeparator_vision_align_edge_1 = new System.Windows.Forms.RibbonSeparator();
            this.ribbonTextBox_vision_align_edge_preprocess_binary = new System.Windows.Forms.RibbonTextBox();
            this.ribbonTextBox_vision_align_edge_preprocess_morp_open = new System.Windows.Forms.RibbonTextBox();
            this.ribbonTextBox_vision_align_edge_preprocess_morp_close = new System.Windows.Forms.RibbonTextBox();
            this.ribbonSeparator_vision_align_edge_2 = new System.Windows.Forms.RibbonSeparator();
            this.ribbonTextBox_vision_align_edge_level = new System.Windows.Forms.RibbonTextBox();
            this.ribbonTextBox_vision_align_edge_miss = new System.Windows.Forms.RibbonTextBox();
            this.ribbonLabel_vision_align_edge_empty_1 = new System.Windows.Forms.RibbonLabel();
            this.ribbonSeparator_vision_align_edge_3 = new System.Windows.Forms.RibbonSeparator();
            this.ribbonTextBox_vision_align_edge_roi_start_x = new System.Windows.Forms.RibbonTextBox();
            this.ribbonTextBox_vision_align_edge_roi_start_y = new System.Windows.Forms.RibbonTextBox();
            this.ribbonLabel_vision_align_edge_empty_2 = new System.Windows.Forms.RibbonLabel();
            this.ribbonLabel_vision_align_edge_wave = new System.Windows.Forms.RibbonLabel();
            this.ribbonLabel_vision_align_edge_empty_3 = new System.Windows.Forms.RibbonLabel();
            this.ribbonLabel_vision_align_edge_empty_4 = new System.Windows.Forms.RibbonLabel();
            this.ribbonTextBox_vision_align_edge_roi_end_x = new System.Windows.Forms.RibbonTextBox();
            this.ribbonTextBox_vision_align_edge_roi_end_y = new System.Windows.Forms.RibbonTextBox();
            this.ribbonLabel_vision_align_edge_empty_5 = new System.Windows.Forms.RibbonLabel();
            this.ribbonTab_help = new System.Windows.Forms.RibbonTab();
            this.ribbonPanel_help = new System.Windows.Forms.RibbonPanel();
            this.ribbonButton_help_contact = new System.Windows.Forms.RibbonButton();
            this.ribbonTab_log = new System.Windows.Forms.RibbonTab();
            this.ribbonPanel_log_data = new System.Windows.Forms.RibbonPanel();
            this.ribbonButton_log_data_load = new System.Windows.Forms.RibbonButton();
            this.ribbonSeparator_log_data_1 = new System.Windows.Forms.RibbonSeparator();
            this.ribbonTextBox_log_data_name = new System.Windows.Forms.RibbonTextBox();
            this.ribbonPanel_log_setting = new System.Windows.Forms.RibbonPanel();
            this.ribbonCheckBox_log_setting_all = new System.Windows.Forms.RibbonCheckBox();
            this.ribbonSeparator_log_setting_1 = new System.Windows.Forms.RibbonSeparator();
            this.ribbonCheckBox_log_setting_1 = new System.Windows.Forms.RibbonCheckBox();
            this.ribbonCheckBox_log_setting_2 = new System.Windows.Forms.RibbonCheckBox();
            this.ribbonCheckBox_log_setting_3 = new System.Windows.Forms.RibbonCheckBox();
            this.ribbonCheckBox_log_setting_4 = new System.Windows.Forms.RibbonCheckBox();
            this.ribbonCheckBox_log_setting_5 = new System.Windows.Forms.RibbonCheckBox();
            this.ribbonCheckBox_log_setting_6 = new System.Windows.Forms.RibbonCheckBox();
            this.ribbonCheckBox_log_setting_7 = new System.Windows.Forms.RibbonCheckBox();
            this.ribbonCheckBox_log_setting_8 = new System.Windows.Forms.RibbonCheckBox();
            this.ribbonCheckBox_log_setting_9 = new System.Windows.Forms.RibbonCheckBox();
            this.ribbonCheckBox_log_setting_10 = new System.Windows.Forms.RibbonCheckBox();
            this.ribbonCheckBox_log_setting_11 = new System.Windows.Forms.RibbonCheckBox();
            this.ribbonCheckBox_log_setting_12 = new System.Windows.Forms.RibbonCheckBox();
            this.ribbonPanel_settings = new System.Windows.Forms.RibbonPanel();
            this.ribbonButton_setting = new System.Windows.Forms.RibbonButton();
            this.ribbonTab_fc = new System.Windows.Forms.RibbonTab();
            this.ribbonPanel_fc = new System.Windows.Forms.RibbonPanel();
            this.ribbonButton_fc = new System.Windows.Forms.RibbonButton();
            this.ribbonPanel_fc_recipe = new System.Windows.Forms.RibbonPanel();
            this.ribbonButton_fc_recipe_load = new System.Windows.Forms.RibbonButton();
            this.ribbonButton_fc_recipe_save = new System.Windows.Forms.RibbonButton();
            this.ribbonSeparator_fc_recipe_1 = new System.Windows.Forms.RibbonSeparator();
            this.ribbonTextBox_fc_recipe_num = new System.Windows.Forms.RibbonTextBox();
            this.ribbonTextBox_fc_recipe_name = new System.Windows.Forms.RibbonTextBox();
            this.ribbonPanel_fc_camera = new System.Windows.Forms.RibbonPanel();
            this.ribbonUpDown_fc_camera_magni = new System.Windows.Forms.RibbonUpDown();
            this.ribbonPanel_fc_param = new System.Windows.Forms.RibbonPanel();
            this.ribbonButton_fc_param_modify = new System.Windows.Forms.RibbonButton();
            this.ribbonButton_fc_param_apply = new System.Windows.Forms.RibbonButton();
            this.ribbonButton_fc_param_cancel = new System.Windows.Forms.RibbonButton();
            this.ribbonSeparator_fc_param_1 = new System.Windows.Forms.RibbonSeparator();
            this.ribbonTextBox_fc_param_center_x = new System.Windows.Forms.RibbonTextBox();
            this.ribbonTextBox_fc_param_center_y = new System.Windows.Forms.RibbonTextBox();
            this.ribbonSeparator_fc_param_2 = new System.Windows.Forms.RibbonSeparator();
            this.ribbonTextBox_fc_param_gain = new System.Windows.Forms.RibbonTextBox();
            this.ribbonTextBox_fc_param_newcal = new System.Windows.Forms.RibbonTextBox();
            this.ribbonTextBox_fc_param_point = new System.Windows.Forms.RibbonTextBox();
            this.ribbonTextBox_fc_param_length = new System.Windows.Forms.RibbonTextBox();
            this.ribbonLabel_fc_param_empty_1 = new System.Windows.Forms.RibbonLabel();
            this.ribbonLabel_fc_param_empty_2 = new System.Windows.Forms.RibbonLabel();
            this.ribbonSeparator_fc_param_3 = new System.Windows.Forms.RibbonSeparator();
            this.ribbonButton_fc_param_oldctfile = new System.Windows.Forms.RibbonButton();
            this.ribbonTextBox_fc_param_oldctfile = new System.Windows.Forms.RibbonTextBox();
            this.ribbonTextBox_fc_param_newctfile = new System.Windows.Forms.RibbonTextBox();
            this.ribbonPanel_fc_detect = new System.Windows.Forms.RibbonPanel();
            this.ribbonButton_fc_detect_mark = new System.Windows.Forms.RibbonButton();
            this.ribbonButton_fc_detect_clear = new System.Windows.Forms.RibbonButton();
            this.ribbonSeparator_fc_detect_1 = new System.Windows.Forms.RibbonSeparator();
            this.ribbonTextBox_fc_detect_matchrate = new System.Windows.Forms.RibbonTextBox();
            this.ribbonTextBox_fc_detect_point_x = new System.Windows.Forms.RibbonTextBox();
            this.ribbonTextBox_fc_detect_point_y = new System.Windows.Forms.RibbonTextBox();
            this.ribbonSeparator_fc_detect_2 = new System.Windows.Forms.RibbonSeparator();
            this.ribbonButton_fc_detect_simulation = new System.Windows.Forms.RibbonButton();
            this.ribbonButton_fc_detect_simulation_clear = new System.Windows.Forms.RibbonButton();
            this.ribbonTab_auto = new System.Windows.Forms.RibbonTab();
            this.ribbonPanel_autorun = new System.Windows.Forms.RibbonPanel();
            this.ribbonButton_autorun_start = new System.Windows.Forms.RibbonButton();
            this.ribbonButton_autorun_stop = new System.Windows.Forms.RibbonButton();
            this.ribbonPanel_auto_vision_recipe = new System.Windows.Forms.RibbonPanel();
            this.ribbonTextBox_auto_vision_recipe_num = new System.Windows.Forms.RibbonTextBox();
            this.ribbonTextBox_auto_vision_recipe_name = new System.Windows.Forms.RibbonTextBox();
            this.ribbonPanel_auto_vision_position = new System.Windows.Forms.RibbonPanel();
            this.ribbonTextBox_auto_vision_position_x_1 = new System.Windows.Forms.RibbonTextBox();
            this.ribbonTextBox_auto_vision_position_y_1 = new System.Windows.Forms.RibbonTextBox();
            this.ribbonLabel_auto_vision_position_empty_1 = new System.Windows.Forms.RibbonLabel();
            this.ribbonTextBox_auto_vision_position_x_2 = new System.Windows.Forms.RibbonTextBox();
            this.ribbonTextBox_auto_vision_position_y_2 = new System.Windows.Forms.RibbonTextBox();
            this.ribbonLabel_auto_vision_position_empty_2 = new System.Windows.Forms.RibbonLabel();
            this.ribbonTextBox_auto_vision_position_x_3 = new System.Windows.Forms.RibbonTextBox();
            this.ribbonTextBox_auto_vision_position_y_3 = new System.Windows.Forms.RibbonTextBox();
            this.ribbonLabel_auto_vision_position_empty_3 = new System.Windows.Forms.RibbonLabel();
            this.ribbonTextBox_auto_vision_position_x_4 = new System.Windows.Forms.RibbonTextBox();
            this.ribbonTextBox_auto_vision_position_y_4 = new System.Windows.Forms.RibbonTextBox();
            this.ribbonLabel_auto_vision_position_empty_4 = new System.Windows.Forms.RibbonLabel();
            this.ribbonPanel_auto_laser_position = new System.Windows.Forms.RibbonPanel();
            this.ribbonTextBox_auto_laser_position_x = new System.Windows.Forms.RibbonTextBox();
            this.ribbonTextBox_auto_laser_position_y = new System.Windows.Forms.RibbonTextBox();
            this.ribbonLabel_auto_laser_position_empty_1 = new System.Windows.Forms.RibbonLabel();
            this.ribbonPanel_auto_align = new System.Windows.Forms.RibbonPanel();
            this.ribbonRadioBox_auto_align_mark = new System.Windows.Forms.RibbonCheckBox();
            this.ribbonRadioBox_auto_align_edge = new System.Windows.Forms.RibbonCheckBox();
            this.ribbonSeparator_auto_align_1 = new System.Windows.Forms.RibbonSeparator();
            this.ribbonTextBox_auto_align_distance = new System.Windows.Forms.RibbonTextBox();
            this.ribbonLabel_auto_align_empty_1 = new System.Windows.Forms.RibbonLabel();
            this.ribbonLabel_auto_align_empty_2 = new System.Windows.Forms.RibbonLabel();
            this.ribbonTextBox_auto_align_range_x = new System.Windows.Forms.RibbonTextBox();
            this.ribbonTextBox_auto_align_range_y = new System.Windows.Forms.RibbonTextBox();
            this.ribbonTextBox_auto_align_range_t = new System.Windows.Forms.RibbonTextBox();
            this.ribbonSeparator_auto_align_2 = new System.Windows.Forms.RibbonSeparator();
            this.ribbonTextBox_auto_align_mark_matchrate_1 = new System.Windows.Forms.RibbonTextBox();
            this.ribbonTextBox_auto_align_mark_matchrate_2 = new System.Windows.Forms.RibbonTextBox();
            this.ribbonLabel_auto_align_empty_3 = new System.Windows.Forms.RibbonLabel();
            this.ribbonTextBox_auto_align_mark_matchrate_3 = new System.Windows.Forms.RibbonTextBox();
            this.ribbonTextBox_auto_align_mark_matchrate_4 = new System.Windows.Forms.RibbonTextBox();
            this.ribbonLabel_auto_align_empty_4 = new System.Windows.Forms.RibbonLabel();
            this.ribbonSeparator_auto_align_3 = new System.Windows.Forms.RibbonSeparator();
            this.ribbonTextBox_auto_align_edge_level = new System.Windows.Forms.RibbonTextBox();
            this.ribbonTextBox_auto_align_edge_miss = new System.Windows.Forms.RibbonTextBox();
            this.ribbonLabel_auto_align_empty_5 = new System.Windows.Forms.RibbonLabel();
            this.ribbonTab_vision = new System.Windows.Forms.RibbonTab();
            this.ribbonPanel_vision_recipe = new System.Windows.Forms.RibbonPanel();
            this.ribbonButton_vision_recipe_load = new System.Windows.Forms.RibbonButton();
            this.ribbonButton_vision_recipe_save = new System.Windows.Forms.RibbonButton();
            this.ribbonSeparator_vision_recipe_1 = new System.Windows.Forms.RibbonSeparator();
            this.ribbonTextBox_vision_recipe_num = new System.Windows.Forms.RibbonTextBox();
            this.ribbonTextBox_vision_recipe_name = new System.Windows.Forms.RibbonTextBox();
            this.ribbonPanel_vision_camera = new System.Windows.Forms.RibbonPanel();
            this.ribbonButton_vision_camera_1 = new System.Windows.Forms.RibbonButton();
            this.ribbonButton_vision_camera_2 = new System.Windows.Forms.RibbonButton();
            this.ribbonSeparator_vision_camera_1 = new System.Windows.Forms.RibbonSeparator();
            this.ribbonUpDown_vision_camera_exposure_1 = new System.Windows.Forms.RibbonUpDown();
            this.ribbonUpDown_vision_camera_exposure_2 = new System.Windows.Forms.RibbonUpDown();
            this.ribbonSeparator_vision_camera_2 = new System.Windows.Forms.RibbonSeparator();
            this.ribbonUpDown_vision_camera_magni = new System.Windows.Forms.RibbonUpDown();
            this.ribbonLabel_vision_camera_empty_1 = new System.Windows.Forms.RibbonLabel();
            this.ribbonPanel_vision_align_mark = new System.Windows.Forms.RibbonPanel();
            this.ribbonButton_vision_align_mark_reg = new System.Windows.Forms.RibbonButton();
            this.ribbonSeparator_vision_align_mark_1 = new System.Windows.Forms.RibbonSeparator();
            this.ribbonButton_vision_align_mark_detect = new System.Windows.Forms.RibbonButton();
            this.ribbonButton_vision_align_mark_clear = new System.Windows.Forms.RibbonButton();
            this.ribbonTextBox_vision_align_mark_matchrate = new System.Windows.Forms.RibbonTextBox();
            this.ribbonTextBox_vision_align_mark_detect_x = new System.Windows.Forms.RibbonTextBox();
            this.ribbonTextBox_vision_align_mark_detect_y = new System.Windows.Forms.RibbonTextBox();
            this.ribbonButton_vision_cam_left = new System.Windows.Forms.RibbonButton();
            this.ribbonTab_laser = new System.Windows.Forms.RibbonTab();
            this.ribbon_menu = new System.Windows.Forms.Ribbon();
            this.ribbonCheckBox_split_enable = new System.Windows.Forms.RibbonCheckBox();
            this.ribbonSeparator_split_2 = new System.Windows.Forms.RibbonSeparator();
            this.ribbonPanel_motion_limit = new System.Windows.Forms.RibbonPanel();
            this.ribbonTextBox_motion_limit_x_low = new System.Windows.Forms.RibbonTextBox();
            this.ribbonTextBox_motion_limit_x_high = new System.Windows.Forms.RibbonTextBox();
            this.ribbonSeparator_motion_limit_1 = new System.Windows.Forms.RibbonSeparator();
            this.ribbonTextBox_motion_limit_y_low = new System.Windows.Forms.RibbonTextBox();
            this.ribbonTextBox_motion_limit_y_high = new System.Windows.Forms.RibbonTextBox();
            this.SuspendLayout();
            // 
            // ribbonPanel_split
            // 
            this.ribbonPanel_split.Items.Add(this.ribbonCheckBox_split_enable);
            this.ribbonPanel_split.Items.Add(this.ribbonSeparator_split_1);
            this.ribbonPanel_split.Items.Add(this.ribbonRadioBox_split_array);
            this.ribbonPanel_split.Items.Add(this.ribbonRadioBox_split_size);
            this.ribbonPanel_split.Items.Add(this.ribbonSeparator_split_2);
            this.ribbonPanel_split.Items.Add(this.ribbonTextBox_split_row);
            this.ribbonPanel_split.Items.Add(this.ribbonTextBox_split_col);
            this.ribbonPanel_split.Items.Add(this.ribbonCheckBox_split_apply);
            this.ribbonPanel_split.Items.Add(this.ribbonButton_split_save);
            this.ribbonPanel_split.Name = "ribbonPanel_split";
            this.ribbonPanel_split.Text = "Split Settings";
            // 
            // ribbonRadioBox_split_array
            // 
            this.ribbonRadioBox_split_array.Checked = true;
            this.ribbonRadioBox_split_array.Enabled = false;
            this.ribbonRadioBox_split_array.Name = "ribbonRadioBox_split_array";
            this.ribbonRadioBox_split_array.Style = System.Windows.Forms.RibbonCheckBox.CheckBoxStyle.RadioButton;
            this.ribbonRadioBox_split_array.Text = "Array";
            this.ribbonRadioBox_split_array.CheckBoxCheckChanged += new System.EventHandler(this.ribbonRadioBox_split_array_CheckBoxCheckChanged);
            // 
            // ribbonRadioBox_split_size
            // 
            this.ribbonRadioBox_split_size.Enabled = false;
            this.ribbonRadioBox_split_size.Name = "ribbonRadioBox_split_size";
            this.ribbonRadioBox_split_size.Style = System.Windows.Forms.RibbonCheckBox.CheckBoxStyle.RadioButton;
            this.ribbonRadioBox_split_size.Text = "Size";
            this.ribbonRadioBox_split_size.CheckBoxCheckChanged += new System.EventHandler(this.ribbonRadioBox_split_size_CheckBoxCheckChanged);
            // 
            // ribbonSeparator_split_1
            // 
            this.ribbonSeparator_split_1.Name = "ribbonSeparator_split_1";
            // 
            // ribbonTextBox_split_row
            // 
            this.ribbonTextBox_split_row.Enabled = false;
            this.ribbonTextBox_split_row.LabelWidth = 40;
            this.ribbonTextBox_split_row.Name = "ribbonTextBox_split_row";
            this.ribbonTextBox_split_row.Text = "Row";
            this.ribbonTextBox_split_row.TextBoxText = "2";
            this.ribbonTextBox_split_row.TextBoxWidth = 40;
            // 
            // ribbonTextBox_split_col
            // 
            this.ribbonTextBox_split_col.Enabled = false;
            this.ribbonTextBox_split_col.LabelWidth = 40;
            this.ribbonTextBox_split_col.Name = "ribbonTextBox_split_col";
            this.ribbonTextBox_split_col.Text = "Col";
            this.ribbonTextBox_split_col.TextBoxText = "2";
            this.ribbonTextBox_split_col.TextBoxWidth = 40;
            // 
            // ribbonCheckBox_split_apply
            // 
            this.ribbonCheckBox_split_apply.Enabled = false;
            this.ribbonCheckBox_split_apply.LabelWidth = 60;
            this.ribbonCheckBox_split_apply.Name = "ribbonCheckBox_split_apply";
            this.ribbonCheckBox_split_apply.Text = "Split Apply";
            this.ribbonCheckBox_split_apply.CheckBoxCheckChanged += new System.EventHandler(this.ribbonCheckBox_split_apply_CheckBoxCheckChanged);
            // 
            // ribbonButton_split_save
            // 
            this.ribbonButton_split_save.Enabled = false;
            this.ribbonButton_split_save.Image = ((System.Drawing.Image)(resources.GetObject("ribbonButton_split_save.Image")));
            this.ribbonButton_split_save.LargeImage = ((System.Drawing.Image)(resources.GetObject("ribbonButton_split_save.LargeImage")));
            this.ribbonButton_split_save.Name = "ribbonButton_split_save";
            this.ribbonButton_split_save.SmallImage = ((System.Drawing.Image)(resources.GetObject("ribbonButton_split_save.SmallImage")));
            this.ribbonButton_split_save.Text = "  Save";
            this.ribbonButton_split_save.Click += new System.EventHandler(this.ribbonButton_split_save_Click);
            // 
            // ribbonPanel_laser_center
            // 
            this.ribbonPanel_laser_center.Items.Add(this.ribbonTextBox_laser_center_x);
            this.ribbonPanel_laser_center.Items.Add(this.ribbonTextBox_laser_center_y);
            this.ribbonPanel_laser_center.Name = "ribbonPanel_laser_center";
            this.ribbonPanel_laser_center.Text = "Laser Center";
            // 
            // ribbonTextBox_laser_center_x
            // 
            this.ribbonTextBox_laser_center_x.LabelWidth = 50;
            this.ribbonTextBox_laser_center_x.Name = "ribbonTextBox_laser_center_x";
            this.ribbonTextBox_laser_center_x.Text = "Unit X";
            this.ribbonTextBox_laser_center_x.TextAlignment = System.Windows.Forms.RibbonItem.RibbonItemTextAlignment.Center;
            this.ribbonTextBox_laser_center_x.TextBoxText = "";
            this.ribbonTextBox_laser_center_x.TextBoxWidth = 40;
            this.ribbonTextBox_laser_center_x.TextBoxTextChanged += new System.EventHandler(this.ribbonTextBox_laser_center_x_TextBoxTextChanged);
            // 
            // ribbonTextBox_laser_center_y
            // 
            this.ribbonTextBox_laser_center_y.LabelWidth = 50;
            this.ribbonTextBox_laser_center_y.Name = "ribbonTextBox_laser_center_y";
            this.ribbonTextBox_laser_center_y.Text = "Unit Y";
            this.ribbonTextBox_laser_center_y.TextAlignment = System.Windows.Forms.RibbonItem.RibbonItemTextAlignment.Center;
            this.ribbonTextBox_laser_center_y.TextBoxText = "";
            this.ribbonTextBox_laser_center_y.TextBoxWidth = 40;
            // 
            // ribbonPanel_marking
            // 
            this.ribbonPanel_marking.Items.Add(this.ribbonCheckBox_marking_guide);
            this.ribbonPanel_marking.Items.Add(this.ribbonCheckBox_marking_align);
            this.ribbonPanel_marking.Items.Add(this.ribbonButton_marking_mark);
            this.ribbonPanel_marking.Name = "ribbonPanel_marking";
            this.ribbonPanel_marking.Text = "Laser Marking";
            // 
            // ribbonCheckBox_marking_guide
            // 
            this.ribbonCheckBox_marking_guide.Name = "ribbonCheckBox_marking_guide";
            this.ribbonCheckBox_marking_guide.Text = "Guide";
            this.ribbonCheckBox_marking_guide.CheckBoxCheckChanged += new System.EventHandler(this.ribbonCheckBox_marking_guide_CheckBoxCheckChanged);
            // 
            // ribbonCheckBox_marking_align
            // 
            this.ribbonCheckBox_marking_align.Name = "ribbonCheckBox_marking_align";
            this.ribbonCheckBox_marking_align.Text = "Vision Align ";
            // 
            // ribbonButton_marking_mark
            // 
            this.ribbonButton_marking_mark.Image = ((System.Drawing.Image)(resources.GetObject("ribbonButton_marking_mark.Image")));
            this.ribbonButton_marking_mark.LargeImage = ((System.Drawing.Image)(resources.GetObject("ribbonButton_marking_mark.LargeImage")));
            this.ribbonButton_marking_mark.Name = "ribbonButton_marking_mark";
            this.ribbonButton_marking_mark.SmallImage = ((System.Drawing.Image)(resources.GetObject("ribbonButton_marking_mark.SmallImage")));
            this.ribbonButton_marking_mark.Text = "Marking Laser";
            this.ribbonButton_marking_mark.Click += new System.EventHandler(this.ribbonButton_marking_mark_Click);
            // 
            // ribbonButton_vision_cam_right
            // 
            this.ribbonButton_vision_cam_right.Image = ((System.Drawing.Image)(resources.GetObject("ribbonButton_vision_cam_right.Image")));
            this.ribbonButton_vision_cam_right.LargeImage = ((System.Drawing.Image)(resources.GetObject("ribbonButton_vision_cam_right.LargeImage")));
            this.ribbonButton_vision_cam_right.Name = "ribbonButton_vision_cam_right";
            this.ribbonButton_vision_cam_right.SmallImage = ((System.Drawing.Image)(resources.GetObject("ribbonButton_vision_cam_right.SmallImage")));
            this.ribbonButton_vision_cam_right.Text = "";
            // 
            // ribbonPanel_vision_align
            // 
            this.ribbonPanel_vision_align.Items.Add(this.ribbonButton_vision_align_1);
            this.ribbonPanel_vision_align.Items.Add(this.ribbonButton_vision_align_3);
            this.ribbonPanel_vision_align.Items.Add(this.ribbonButton_vision_align_2);
            this.ribbonPanel_vision_align.Items.Add(this.ribbonButton_vision_align_4);
            this.ribbonPanel_vision_align.Name = "ribbonPanel_vision_align";
            this.ribbonPanel_vision_align.Text = "Align Set";
            // 
            // ribbonButton_vision_align_1
            // 
            this.ribbonButton_vision_align_1.Checked = true;
            this.ribbonButton_vision_align_1.Image = ((System.Drawing.Image)(resources.GetObject("ribbonButton_vision_align_1.Image")));
            this.ribbonButton_vision_align_1.LargeImage = ((System.Drawing.Image)(resources.GetObject("ribbonButton_vision_align_1.LargeImage")));
            this.ribbonButton_vision_align_1.MaxSizeMode = System.Windows.Forms.RibbonElementSizeMode.Compact;
            this.ribbonButton_vision_align_1.Name = "ribbonButton_vision_align_1";
            this.ribbonButton_vision_align_1.SmallImage = ((System.Drawing.Image)(resources.GetObject("ribbonButton_vision_align_1.SmallImage")));
            this.ribbonButton_vision_align_1.Text = "Align 1";
            this.ribbonButton_vision_align_1.Click += new System.EventHandler(this.ribbonButton_vision_align_1_Click);
            // 
            // ribbonButton_vision_align_3
            // 
            this.ribbonButton_vision_align_3.Image = ((System.Drawing.Image)(resources.GetObject("ribbonButton_vision_align_3.Image")));
            this.ribbonButton_vision_align_3.LargeImage = ((System.Drawing.Image)(resources.GetObject("ribbonButton_vision_align_3.LargeImage")));
            this.ribbonButton_vision_align_3.MaxSizeMode = System.Windows.Forms.RibbonElementSizeMode.Compact;
            this.ribbonButton_vision_align_3.Name = "ribbonButton_vision_align_3";
            this.ribbonButton_vision_align_3.SmallImage = ((System.Drawing.Image)(resources.GetObject("ribbonButton_vision_align_3.SmallImage")));
            this.ribbonButton_vision_align_3.Text = "Align 3";
            this.ribbonButton_vision_align_3.Click += new System.EventHandler(this.ribbonButton_vision_align_3_Click);
            // 
            // ribbonButton_vision_align_2
            // 
            this.ribbonButton_vision_align_2.Image = ((System.Drawing.Image)(resources.GetObject("ribbonButton_vision_align_2.Image")));
            this.ribbonButton_vision_align_2.LargeImage = ((System.Drawing.Image)(resources.GetObject("ribbonButton_vision_align_2.LargeImage")));
            this.ribbonButton_vision_align_2.MaxSizeMode = System.Windows.Forms.RibbonElementSizeMode.Compact;
            this.ribbonButton_vision_align_2.Name = "ribbonButton_vision_align_2";
            this.ribbonButton_vision_align_2.SmallImage = ((System.Drawing.Image)(resources.GetObject("ribbonButton_vision_align_2.SmallImage")));
            this.ribbonButton_vision_align_2.Text = "Align 2";
            this.ribbonButton_vision_align_2.Click += new System.EventHandler(this.ribbonButton_vision_align_2_Click);
            // 
            // ribbonButton_vision_align_4
            // 
            this.ribbonButton_vision_align_4.Image = ((System.Drawing.Image)(resources.GetObject("ribbonButton_vision_align_4.Image")));
            this.ribbonButton_vision_align_4.LargeImage = ((System.Drawing.Image)(resources.GetObject("ribbonButton_vision_align_4.LargeImage")));
            this.ribbonButton_vision_align_4.MaxSizeMode = System.Windows.Forms.RibbonElementSizeMode.Compact;
            this.ribbonButton_vision_align_4.Name = "ribbonButton_vision_align_4";
            this.ribbonButton_vision_align_4.SmallImage = ((System.Drawing.Image)(resources.GetObject("ribbonButton_vision_align_4.SmallImage")));
            this.ribbonButton_vision_align_4.Text = "Align 4";
            this.ribbonButton_vision_align_4.Click += new System.EventHandler(this.ribbonButton_vision_align_4_Click);
            // 
            // ribbonPanel_vision_align_param
            // 
            this.ribbonPanel_vision_align_param.Items.Add(this.ribbonButton_vision_align_param_modify);
            this.ribbonPanel_vision_align_param.Items.Add(this.ribbonButton_vision_align_param_apply);
            this.ribbonPanel_vision_align_param.Items.Add(this.ribbonButton_vision_align_param_cancel);
            this.ribbonPanel_vision_align_param.Items.Add(this.ribbonSeparator_vision_align_param_1);
            this.ribbonPanel_vision_align_param.Items.Add(this.ribbonRadioBox_vision_align_param_mark);
            this.ribbonPanel_vision_align_param.Items.Add(this.ribbonRadioBox_vision_align_param_edge);
            this.ribbonPanel_vision_align_param.Items.Add(this.ribbonSeparator_vision_align_param_2);
            this.ribbonPanel_vision_align_param.Items.Add(this.ribbonTextBox_vision_align_param_unitx);
            this.ribbonPanel_vision_align_param.Items.Add(this.ribbonTextBox_vision_align_param_unity);
            this.ribbonPanel_vision_align_param.Items.Add(this.ribbonTextBox_vision_align_param_distance);
            this.ribbonPanel_vision_align_param.Items.Add(this.ribbonSeparator_vision_align_param_3);
            this.ribbonPanel_vision_align_param.Items.Add(this.ribbonTextBox_vision_align_param_judge_x);
            this.ribbonPanel_vision_align_param.Items.Add(this.ribbonTextBox_vision_align_param_judge_y);
            this.ribbonPanel_vision_align_param.Items.Add(this.ribbonTextBox_vision_align_param_judge_t);
            this.ribbonPanel_vision_align_param.Name = "ribbonPanel_vision_align_param";
            this.ribbonPanel_vision_align_param.Text = "Align Parameter";
            // 
            // ribbonButton_vision_align_param_modify
            // 
            this.ribbonButton_vision_align_param_modify.Image = ((System.Drawing.Image)(resources.GetObject("ribbonButton_vision_align_param_modify.Image")));
            this.ribbonButton_vision_align_param_modify.LargeImage = ((System.Drawing.Image)(resources.GetObject("ribbonButton_vision_align_param_modify.LargeImage")));
            this.ribbonButton_vision_align_param_modify.MaxSizeMode = System.Windows.Forms.RibbonElementSizeMode.Large;
            this.ribbonButton_vision_align_param_modify.Name = "ribbonButton_vision_align_param_modify";
            this.ribbonButton_vision_align_param_modify.SmallImage = ((System.Drawing.Image)(resources.GetObject("ribbonButton_vision_align_param_modify.SmallImage")));
            this.ribbonButton_vision_align_param_modify.Text = "  Modify";
            this.ribbonButton_vision_align_param_modify.Click += new System.EventHandler(this.ribbonButton_vision_align_param_modify_Click);
            // 
            // ribbonButton_vision_align_param_apply
            // 
            this.ribbonButton_vision_align_param_apply.Enabled = false;
            this.ribbonButton_vision_align_param_apply.Image = ((System.Drawing.Image)(resources.GetObject("ribbonButton_vision_align_param_apply.Image")));
            this.ribbonButton_vision_align_param_apply.LargeImage = ((System.Drawing.Image)(resources.GetObject("ribbonButton_vision_align_param_apply.LargeImage")));
            this.ribbonButton_vision_align_param_apply.MaxSizeMode = System.Windows.Forms.RibbonElementSizeMode.Medium;
            this.ribbonButton_vision_align_param_apply.Name = "ribbonButton_vision_align_param_apply";
            this.ribbonButton_vision_align_param_apply.SmallImage = ((System.Drawing.Image)(resources.GetObject("ribbonButton_vision_align_param_apply.SmallImage")));
            this.ribbonButton_vision_align_param_apply.Text = "Apply";
            this.ribbonButton_vision_align_param_apply.Click += new System.EventHandler(this.ribbonButton_vision_align_param_apply_Click);
            // 
            // ribbonButton_vision_align_param_cancel
            // 
            this.ribbonButton_vision_align_param_cancel.Enabled = false;
            this.ribbonButton_vision_align_param_cancel.Image = ((System.Drawing.Image)(resources.GetObject("ribbonButton_vision_align_param_cancel.Image")));
            this.ribbonButton_vision_align_param_cancel.LargeImage = ((System.Drawing.Image)(resources.GetObject("ribbonButton_vision_align_param_cancel.LargeImage")));
            this.ribbonButton_vision_align_param_cancel.MaxSizeMode = System.Windows.Forms.RibbonElementSizeMode.Medium;
            this.ribbonButton_vision_align_param_cancel.Name = "ribbonButton_vision_align_param_cancel";
            this.ribbonButton_vision_align_param_cancel.SmallImage = ((System.Drawing.Image)(resources.GetObject("ribbonButton_vision_align_param_cancel.SmallImage")));
            this.ribbonButton_vision_align_param_cancel.Text = "Cancel";
            this.ribbonButton_vision_align_param_cancel.Click += new System.EventHandler(this.ribbonButton_vision_align_param_cancel_Click);
            // 
            // ribbonSeparator_vision_align_param_1
            // 
            this.ribbonSeparator_vision_align_param_1.Name = "ribbonSeparator_vision_align_param_1";
            // 
            // ribbonRadioBox_vision_align_param_mark
            // 
            this.ribbonRadioBox_vision_align_param_mark.Checked = true;
            this.ribbonRadioBox_vision_align_param_mark.Name = "ribbonRadioBox_vision_align_param_mark";
            this.ribbonRadioBox_vision_align_param_mark.Style = System.Windows.Forms.RibbonCheckBox.CheckBoxStyle.RadioButton;
            this.ribbonRadioBox_vision_align_param_mark.Text = "Mark";
            this.ribbonRadioBox_vision_align_param_mark.CheckBoxCheckChanged += new System.EventHandler(this.ribbonRadioBox_vision_align_param_mark_CheckBoxCheckChanged);
            // 
            // ribbonRadioBox_vision_align_param_edge
            // 
            this.ribbonRadioBox_vision_align_param_edge.Name = "ribbonRadioBox_vision_align_param_edge";
            this.ribbonRadioBox_vision_align_param_edge.Style = System.Windows.Forms.RibbonCheckBox.CheckBoxStyle.RadioButton;
            this.ribbonRadioBox_vision_align_param_edge.Text = "Edge";
            this.ribbonRadioBox_vision_align_param_edge.CheckBoxCheckChanged += new System.EventHandler(this.ribbonRadioBox_vision_align_param_edge_CheckBoxCheckChanged);
            // 
            // ribbonSeparator_vision_align_param_2
            // 
            this.ribbonSeparator_vision_align_param_2.Name = "ribbonSeparator_vision_align_param_2";
            // 
            // ribbonTextBox_vision_align_param_unitx
            // 
            this.ribbonTextBox_vision_align_param_unitx.LabelWidth = 60;
            this.ribbonTextBox_vision_align_param_unitx.Name = "ribbonTextBox_vision_align_param_unitx";
            this.ribbonTextBox_vision_align_param_unitx.Text = "UnitX";
            this.ribbonTextBox_vision_align_param_unitx.TextBoxText = "";
            this.ribbonTextBox_vision_align_param_unitx.TextBoxWidth = 60;
            this.ribbonTextBox_vision_align_param_unitx.TextBoxTextChanged += new System.EventHandler(this.ribbonTextBox_vision_alignparam_unitx_TextBoxTextChanged);
            // 
            // ribbonTextBox_vision_align_param_unity
            // 
            this.ribbonTextBox_vision_align_param_unity.LabelWidth = 60;
            this.ribbonTextBox_vision_align_param_unity.Name = "ribbonTextBox_vision_align_param_unity";
            this.ribbonTextBox_vision_align_param_unity.Text = "UnitY";
            this.ribbonTextBox_vision_align_param_unity.TextBoxText = "";
            this.ribbonTextBox_vision_align_param_unity.TextBoxWidth = 60;
            this.ribbonTextBox_vision_align_param_unity.TextBoxTextChanged += new System.EventHandler(this.ribbonTextBox_vision_alignparam_unity_TextBoxTextChanged);
            // 
            // ribbonTextBox_vision_align_param_distance
            // 
            this.ribbonTextBox_vision_align_param_distance.LabelWidth = 60;
            this.ribbonTextBox_vision_align_param_distance.Name = "ribbonTextBox_vision_align_param_distance";
            this.ribbonTextBox_vision_align_param_distance.Text = "distance";
            this.ribbonTextBox_vision_align_param_distance.TextBoxText = "";
            this.ribbonTextBox_vision_align_param_distance.TextBoxWidth = 60;
            this.ribbonTextBox_vision_align_param_distance.TextBoxTextChanged += new System.EventHandler(this.ribbonTextBox_vision_alignparam_distance_TextBoxTextChanged);
            // 
            // ribbonSeparator_vision_align_param_3
            // 
            this.ribbonSeparator_vision_align_param_3.Name = "ribbonSeparator_vision_align_param_3";
            // 
            // ribbonTextBox_vision_align_param_judge_x
            // 
            this.ribbonTextBox_vision_align_param_judge_x.LabelWidth = 60;
            this.ribbonTextBox_vision_align_param_judge_x.Name = "ribbonTextBox_vision_align_param_judge_x";
            this.ribbonTextBox_vision_align_param_judge_x.Text = "X축 (±㎜)";
            this.ribbonTextBox_vision_align_param_judge_x.TextBoxText = "";
            this.ribbonTextBox_vision_align_param_judge_x.TextBoxWidth = 60;
            this.ribbonTextBox_vision_align_param_judge_x.TextBoxTextChanged += new System.EventHandler(this.ribbonTextBox_vision_align_param_judge_x_TextBoxTextChanged);
            // 
            // ribbonTextBox_vision_align_param_judge_y
            // 
            this.ribbonTextBox_vision_align_param_judge_y.LabelWidth = 60;
            this.ribbonTextBox_vision_align_param_judge_y.Name = "ribbonTextBox_vision_align_param_judge_y";
            this.ribbonTextBox_vision_align_param_judge_y.Text = "Y축 (±㎜)";
            this.ribbonTextBox_vision_align_param_judge_y.TextBoxText = "";
            this.ribbonTextBox_vision_align_param_judge_y.TextBoxWidth = 60;
            this.ribbonTextBox_vision_align_param_judge_y.TextBoxTextChanged += new System.EventHandler(this.ribbonTextBox_vision_align_param_judge_y_TextBoxTextChanged);
            // 
            // ribbonTextBox_vision_align_param_judge_t
            // 
            this.ribbonTextBox_vision_align_param_judge_t.LabelWidth = 60;
            this.ribbonTextBox_vision_align_param_judge_t.Name = "ribbonTextBox_vision_align_param_judge_t";
            this.ribbonTextBox_vision_align_param_judge_t.Text = "Turn (±˚)";
            this.ribbonTextBox_vision_align_param_judge_t.TextBoxText = "";
            this.ribbonTextBox_vision_align_param_judge_t.TextBoxWidth = 60;
            this.ribbonTextBox_vision_align_param_judge_t.TextBoxTextChanged += new System.EventHandler(this.ribbonTextBox_vision_align_param_judge_t_TextBoxTextChanged);
            // 
            // ribbonButton_fc_stop
            // 
            this.ribbonButton_fc_stop.Image = ((System.Drawing.Image)(resources.GetObject("ribbonButton_fc_stop.Image")));
            this.ribbonButton_fc_stop.LargeImage = ((System.Drawing.Image)(resources.GetObject("ribbonButton_fc_stop.LargeImage")));
            this.ribbonButton_fc_stop.MaxSizeMode = System.Windows.Forms.RibbonElementSizeMode.Large;
            this.ribbonButton_fc_stop.Name = "ribbonButton_fc_stop";
            this.ribbonButton_fc_stop.SmallImage = ((System.Drawing.Image)(resources.GetObject("ribbonButton_fc_stop.SmallImage")));
            this.ribbonButton_fc_stop.Text = "Process Stop";
            this.ribbonButton_fc_stop.Click += new System.EventHandler(this.ribbonButton_fc_stop_Click);
            // 
            // ribbonPanel_vision_align_edge
            // 
            this.ribbonPanel_vision_align_edge.Items.Add(this.ribbonUpDown_vision_align_edge_precision);
            this.ribbonPanel_vision_align_edge.Items.Add(this.ribbonRadioBox_vision_align_edge_upward);
            this.ribbonPanel_vision_align_edge.Items.Add(this.ribbonRadioBox_vision_align_edge_downward);
            this.ribbonPanel_vision_align_edge.Items.Add(this.ribbonSeparator_vision_align_edge_1);
            this.ribbonPanel_vision_align_edge.Items.Add(this.ribbonTextBox_vision_align_edge_preprocess_binary);
            this.ribbonPanel_vision_align_edge.Items.Add(this.ribbonTextBox_vision_align_edge_preprocess_morp_open);
            this.ribbonPanel_vision_align_edge.Items.Add(this.ribbonTextBox_vision_align_edge_preprocess_morp_close);
            this.ribbonPanel_vision_align_edge.Items.Add(this.ribbonSeparator_vision_align_edge_2);
            this.ribbonPanel_vision_align_edge.Items.Add(this.ribbonTextBox_vision_align_edge_level);
            this.ribbonPanel_vision_align_edge.Items.Add(this.ribbonTextBox_vision_align_edge_miss);
            this.ribbonPanel_vision_align_edge.Items.Add(this.ribbonLabel_vision_align_edge_empty_1);
            this.ribbonPanel_vision_align_edge.Items.Add(this.ribbonSeparator_vision_align_edge_3);
            this.ribbonPanel_vision_align_edge.Items.Add(this.ribbonTextBox_vision_align_edge_roi_start_x);
            this.ribbonPanel_vision_align_edge.Items.Add(this.ribbonTextBox_vision_align_edge_roi_start_y);
            this.ribbonPanel_vision_align_edge.Items.Add(this.ribbonLabel_vision_align_edge_empty_2);
            this.ribbonPanel_vision_align_edge.Items.Add(this.ribbonLabel_vision_align_edge_wave);
            this.ribbonPanel_vision_align_edge.Items.Add(this.ribbonLabel_vision_align_edge_empty_3);
            this.ribbonPanel_vision_align_edge.Items.Add(this.ribbonLabel_vision_align_edge_empty_4);
            this.ribbonPanel_vision_align_edge.Items.Add(this.ribbonTextBox_vision_align_edge_roi_end_x);
            this.ribbonPanel_vision_align_edge.Items.Add(this.ribbonTextBox_vision_align_edge_roi_end_y);
            this.ribbonPanel_vision_align_edge.Items.Add(this.ribbonLabel_vision_align_edge_empty_5);
            this.ribbonPanel_vision_align_edge.Name = "ribbonPanel_vision_align_edge";
            this.ribbonPanel_vision_align_edge.Text = "Alignment (Edge)";
            // 
            // ribbonUpDown_vision_align_edge_precision
            // 
            this.ribbonUpDown_vision_align_edge_precision.LabelWidth = 60;
            this.ribbonUpDown_vision_align_edge_precision.Name = "ribbonUpDown_vision_align_edge_precision";
            this.ribbonUpDown_vision_align_edge_precision.Text = "Precision";
            this.ribbonUpDown_vision_align_edge_precision.TextBoxText = "";
            this.ribbonUpDown_vision_align_edge_precision.TextBoxWidth = 30;
            this.ribbonUpDown_vision_align_edge_precision.UpButtonClicked += new System.Windows.Forms.MouseEventHandler(this.ribbonUpDown_vision_align_edge_precision_UpButtonClicked);
            this.ribbonUpDown_vision_align_edge_precision.DownButtonClicked += new System.Windows.Forms.MouseEventHandler(this.ribbonUpDown_vision_align_edge_precision_DownButtonClicked);
            this.ribbonUpDown_vision_align_edge_precision.TextBoxTextChanged += new System.EventHandler(this.ribbonUpDown_vision_align_edge_precision_TextBoxTextChanged);
            // 
            // ribbonRadioBox_vision_align_edge_upward
            // 
            this.ribbonRadioBox_vision_align_edge_upward.Name = "ribbonRadioBox_vision_align_edge_upward";
            this.ribbonRadioBox_vision_align_edge_upward.Style = System.Windows.Forms.RibbonCheckBox.CheckBoxStyle.RadioButton;
            this.ribbonRadioBox_vision_align_edge_upward.Text = "UpWard";
            this.ribbonRadioBox_vision_align_edge_upward.CheckBoxCheckChanged += new System.EventHandler(this.ribbonRadioBox_vision_align_edge_upward_CheckBoxCheckChanged);
            // 
            // ribbonRadioBox_vision_align_edge_downward
            // 
            this.ribbonRadioBox_vision_align_edge_downward.Name = "ribbonRadioBox_vision_align_edge_downward";
            this.ribbonRadioBox_vision_align_edge_downward.Style = System.Windows.Forms.RibbonCheckBox.CheckBoxStyle.RadioButton;
            this.ribbonRadioBox_vision_align_edge_downward.Text = "DownWard";
            this.ribbonRadioBox_vision_align_edge_downward.CheckBoxCheckChanged += new System.EventHandler(this.ribbonRadioBox_vision_align_edge_downward_CheckBoxCheckChanged);
            // 
            // ribbonSeparator_vision_align_edge_1
            // 
            this.ribbonSeparator_vision_align_edge_1.Name = "ribbonSeparator_vision_align_edge_1";
            // 
            // ribbonTextBox_vision_align_edge_preprocess_binary
            // 
            this.ribbonTextBox_vision_align_edge_preprocess_binary.LabelWidth = 70;
            this.ribbonTextBox_vision_align_edge_preprocess_binary.Name = "ribbonTextBox_vision_align_edge_preprocess_binary";
            this.ribbonTextBox_vision_align_edge_preprocess_binary.Text = "Binary";
            this.ribbonTextBox_vision_align_edge_preprocess_binary.TextBoxText = "";
            this.ribbonTextBox_vision_align_edge_preprocess_binary.TextBoxWidth = 40;
            this.ribbonTextBox_vision_align_edge_preprocess_binary.TextBoxTextChanged += new System.EventHandler(this.ribbonTextBox_vision_align_edge_preprocess_binary_TextBoxTextChanged);
            // 
            // ribbonTextBox_vision_align_edge_preprocess_morp_open
            // 
            this.ribbonTextBox_vision_align_edge_preprocess_morp_open.LabelWidth = 70;
            this.ribbonTextBox_vision_align_edge_preprocess_morp_open.Name = "ribbonTextBox_vision_align_edge_preprocess_morp_open";
            this.ribbonTextBox_vision_align_edge_preprocess_morp_open.Text = "Morp.Open";
            this.ribbonTextBox_vision_align_edge_preprocess_morp_open.TextBoxText = "";
            this.ribbonTextBox_vision_align_edge_preprocess_morp_open.TextBoxWidth = 40;
            this.ribbonTextBox_vision_align_edge_preprocess_morp_open.TextBoxTextChanged += new System.EventHandler(this.ribbonTextBox_vision_align_edge_preprocess_morp_open_TextBoxTextChanged);
            // 
            // ribbonTextBox_vision_align_edge_preprocess_morp_close
            // 
            this.ribbonTextBox_vision_align_edge_preprocess_morp_close.LabelWidth = 70;
            this.ribbonTextBox_vision_align_edge_preprocess_morp_close.Name = "ribbonTextBox_vision_align_edge_preprocess_morp_close";
            this.ribbonTextBox_vision_align_edge_preprocess_morp_close.Text = "Morp.Close";
            this.ribbonTextBox_vision_align_edge_preprocess_morp_close.TextBoxText = "";
            this.ribbonTextBox_vision_align_edge_preprocess_morp_close.TextBoxWidth = 40;
            this.ribbonTextBox_vision_align_edge_preprocess_morp_close.TextBoxTextChanged += new System.EventHandler(this.ribbonTextBox_vision_align_edge_preprocess_morp_close_TextBoxTextChanged);
            // 
            // ribbonSeparator_vision_align_edge_2
            // 
            this.ribbonSeparator_vision_align_edge_2.Name = "ribbonSeparator_vision_align_edge_2";
            // 
            // ribbonTextBox_vision_align_edge_level
            // 
            this.ribbonTextBox_vision_align_edge_level.LabelWidth = 80;
            this.ribbonTextBox_vision_align_edge_level.Name = "ribbonTextBox_vision_align_edge_level";
            this.ribbonTextBox_vision_align_edge_level.Text = "Level Judge";
            this.ribbonTextBox_vision_align_edge_level.TextBoxText = "";
            this.ribbonTextBox_vision_align_edge_level.TextBoxWidth = 40;
            this.ribbonTextBox_vision_align_edge_level.TextBoxTextChanged += new System.EventHandler(this.ribbonTextBox_vision_align_edge_level_TextBoxTextChanged);
            // 
            // ribbonTextBox_vision_align_edge_miss
            // 
            this.ribbonTextBox_vision_align_edge_miss.LabelWidth = 80;
            this.ribbonTextBox_vision_align_edge_miss.Name = "ribbonTextBox_vision_align_edge_miss";
            this.ribbonTextBox_vision_align_edge_miss.Text = "Miss Judge";
            this.ribbonTextBox_vision_align_edge_miss.TextBoxText = "";
            this.ribbonTextBox_vision_align_edge_miss.TextBoxWidth = 40;
            this.ribbonTextBox_vision_align_edge_miss.TextBoxTextChanged += new System.EventHandler(this.ribbonTextBox_vision_align_edge_miss_TextBoxTextChanged);
            // 
            // ribbonLabel_vision_align_edge_empty_1
            // 
            this.ribbonLabel_vision_align_edge_empty_1.Name = "ribbonLabel_vision_align_edge_empty_1";
            // 
            // ribbonSeparator_vision_align_edge_3
            // 
            this.ribbonSeparator_vision_align_edge_3.Name = "ribbonSeparator_vision_align_edge_3";
            // 
            // ribbonTextBox_vision_align_edge_roi_start_x
            // 
            this.ribbonTextBox_vision_align_edge_roi_start_x.LabelWidth = 20;
            this.ribbonTextBox_vision_align_edge_roi_start_x.Name = "ribbonTextBox_vision_align_edge_roi_start_x";
            this.ribbonTextBox_vision_align_edge_roi_start_x.Text = "X";
            this.ribbonTextBox_vision_align_edge_roi_start_x.TextBoxText = "";
            this.ribbonTextBox_vision_align_edge_roi_start_x.TextBoxWidth = 40;
            this.ribbonTextBox_vision_align_edge_roi_start_x.TextBoxTextChanged += new System.EventHandler(this.ribbonTextBox_vision_align_edge_roi_start_x_TextBoxTextChanged);
            // 
            // ribbonTextBox_vision_align_edge_roi_start_y
            // 
            this.ribbonTextBox_vision_align_edge_roi_start_y.LabelWidth = 20;
            this.ribbonTextBox_vision_align_edge_roi_start_y.Name = "ribbonTextBox_vision_align_edge_roi_start_y";
            this.ribbonTextBox_vision_align_edge_roi_start_y.Text = "Y";
            this.ribbonTextBox_vision_align_edge_roi_start_y.TextBoxText = "";
            this.ribbonTextBox_vision_align_edge_roi_start_y.TextBoxWidth = 40;
            this.ribbonTextBox_vision_align_edge_roi_start_y.TextBoxTextChanged += new System.EventHandler(this.ribbonTextBox_vision_align_edge_roi_start_y_TextBoxTextChanged);
            // 
            // ribbonLabel_vision_align_edge_empty_2
            // 
            this.ribbonLabel_vision_align_edge_empty_2.Name = "ribbonLabel_vision_align_edge_empty_2";
            // 
            // ribbonLabel_vision_align_edge_wave
            // 
            this.ribbonLabel_vision_align_edge_wave.Name = "ribbonLabel_vision_align_edge_wave";
            this.ribbonLabel_vision_align_edge_wave.Text = "~";
            // 
            // ribbonLabel_vision_align_edge_empty_3
            // 
            this.ribbonLabel_vision_align_edge_empty_3.Name = "ribbonLabel_vision_align_edge_empty_3";
            // 
            // ribbonLabel_vision_align_edge_empty_4
            // 
            this.ribbonLabel_vision_align_edge_empty_4.Name = "ribbonLabel_vision_align_edge_empty_4";
            // 
            // ribbonTextBox_vision_align_edge_roi_end_x
            // 
            this.ribbonTextBox_vision_align_edge_roi_end_x.LabelWidth = 20;
            this.ribbonTextBox_vision_align_edge_roi_end_x.Name = "ribbonTextBox_vision_align_edge_roi_end_x";
            this.ribbonTextBox_vision_align_edge_roi_end_x.Text = "X";
            this.ribbonTextBox_vision_align_edge_roi_end_x.TextBoxText = "";
            this.ribbonTextBox_vision_align_edge_roi_end_x.TextBoxWidth = 40;
            this.ribbonTextBox_vision_align_edge_roi_end_x.TextBoxTextChanged += new System.EventHandler(this.ribbonTextBox_vision_align_edge_roi_end_x_TextBoxTextChanged);
            // 
            // ribbonTextBox_vision_align_edge_roi_end_y
            // 
            this.ribbonTextBox_vision_align_edge_roi_end_y.LabelWidth = 20;
            this.ribbonTextBox_vision_align_edge_roi_end_y.Name = "ribbonTextBox_vision_align_edge_roi_end_y";
            this.ribbonTextBox_vision_align_edge_roi_end_y.Text = "Y";
            this.ribbonTextBox_vision_align_edge_roi_end_y.TextBoxText = "";
            this.ribbonTextBox_vision_align_edge_roi_end_y.TextBoxWidth = 40;
            this.ribbonTextBox_vision_align_edge_roi_end_y.TextBoxTextChanged += new System.EventHandler(this.ribbonTextBox_vision_align_edge_roi_end_y_TextBoxTextChanged);
            // 
            // ribbonLabel_vision_align_edge_empty_5
            // 
            this.ribbonLabel_vision_align_edge_empty_5.Name = "ribbonLabel_vision_align_edge_empty_5";
            // 
            // ribbonTab_help
            // 
            this.ribbonTab_help.Name = "ribbonTab_help";
            this.ribbonTab_help.Panels.Add(this.ribbonPanel_help);
            this.ribbonTab_help.Text = "Help";
            // 
            // ribbonPanel_help
            // 
            this.ribbonPanel_help.Items.Add(this.ribbonButton_help_contact);
            this.ribbonPanel_help.Name = "ribbonPanel_help";
            this.ribbonPanel_help.Text = "Help";
            // 
            // ribbonButton_help_contact
            // 
            this.ribbonButton_help_contact.Image = ((System.Drawing.Image)(resources.GetObject("ribbonButton_help_contact.Image")));
            this.ribbonButton_help_contact.LargeImage = ((System.Drawing.Image)(resources.GetObject("ribbonButton_help_contact.LargeImage")));
            this.ribbonButton_help_contact.MaxSizeMode = System.Windows.Forms.RibbonElementSizeMode.Large;
            this.ribbonButton_help_contact.Name = "ribbonButton_help_contact";
            this.ribbonButton_help_contact.SmallImage = ((System.Drawing.Image)(resources.GetObject("ribbonButton_help_contact.SmallImage")));
            this.ribbonButton_help_contact.Text = "Contact Info";
            this.ribbonButton_help_contact.Click += new System.EventHandler(this.ribbonButton_help_contact_Click);
            // 
            // ribbonTab_log
            // 
            this.ribbonTab_log.Name = "ribbonTab_log";
            this.ribbonTab_log.Panels.Add(this.ribbonPanel_log_data);
            this.ribbonTab_log.Panels.Add(this.ribbonPanel_log_setting);
            this.ribbonTab_log.Text = "Log";
            // 
            // ribbonPanel_log_data
            // 
            this.ribbonPanel_log_data.Items.Add(this.ribbonButton_log_data_load);
            this.ribbonPanel_log_data.Items.Add(this.ribbonSeparator_log_data_1);
            this.ribbonPanel_log_data.Items.Add(this.ribbonTextBox_log_data_name);
            this.ribbonPanel_log_data.Name = "ribbonPanel_log_data";
            this.ribbonPanel_log_data.Text = "Log Data";
            // 
            // ribbonButton_log_data_load
            // 
            this.ribbonButton_log_data_load.Image = ((System.Drawing.Image)(resources.GetObject("ribbonButton_log_data_load.Image")));
            this.ribbonButton_log_data_load.LargeImage = ((System.Drawing.Image)(resources.GetObject("ribbonButton_log_data_load.LargeImage")));
            this.ribbonButton_log_data_load.MaxSizeMode = System.Windows.Forms.RibbonElementSizeMode.Large;
            this.ribbonButton_log_data_load.Name = "ribbonButton_log_data_load";
            this.ribbonButton_log_data_load.SmallImage = ((System.Drawing.Image)(resources.GetObject("ribbonButton_log_data_load.SmallImage")));
            this.ribbonButton_log_data_load.Text = "  Load";
            this.ribbonButton_log_data_load.Click += new System.EventHandler(this.ribbonButton_log_data_load_Click);
            // 
            // ribbonSeparator_log_data_1
            // 
            this.ribbonSeparator_log_data_1.Name = "ribbonSeparator_log_data_1";
            // 
            // ribbonTextBox_log_data_name
            // 
            this.ribbonTextBox_log_data_name.Name = "ribbonTextBox_log_data_name";
            this.ribbonTextBox_log_data_name.Text = "Log File";
            this.ribbonTextBox_log_data_name.TextBoxText = "";
            // 
            // ribbonPanel_log_setting
            // 
            this.ribbonPanel_log_setting.Items.Add(this.ribbonCheckBox_log_setting_all);
            this.ribbonPanel_log_setting.Items.Add(this.ribbonSeparator_log_setting_1);
            this.ribbonPanel_log_setting.Items.Add(this.ribbonCheckBox_log_setting_1);
            this.ribbonPanel_log_setting.Items.Add(this.ribbonCheckBox_log_setting_2);
            this.ribbonPanel_log_setting.Items.Add(this.ribbonCheckBox_log_setting_3);
            this.ribbonPanel_log_setting.Items.Add(this.ribbonCheckBox_log_setting_4);
            this.ribbonPanel_log_setting.Items.Add(this.ribbonCheckBox_log_setting_5);
            this.ribbonPanel_log_setting.Items.Add(this.ribbonCheckBox_log_setting_6);
            this.ribbonPanel_log_setting.Items.Add(this.ribbonCheckBox_log_setting_7);
            this.ribbonPanel_log_setting.Items.Add(this.ribbonCheckBox_log_setting_8);
            this.ribbonPanel_log_setting.Items.Add(this.ribbonCheckBox_log_setting_9);
            this.ribbonPanel_log_setting.Items.Add(this.ribbonCheckBox_log_setting_10);
            this.ribbonPanel_log_setting.Items.Add(this.ribbonCheckBox_log_setting_11);
            this.ribbonPanel_log_setting.Items.Add(this.ribbonCheckBox_log_setting_12);
            this.ribbonPanel_log_setting.Name = "ribbonPanel_log_setting";
            this.ribbonPanel_log_setting.Text = "Log Display Setting";
            // 
            // ribbonCheckBox_log_setting_all
            // 
            this.ribbonCheckBox_log_setting_all.Name = "ribbonCheckBox_log_setting_all";
            this.ribbonCheckBox_log_setting_all.Text = "All";
            this.ribbonCheckBox_log_setting_all.CheckBoxCheckChanged += new System.EventHandler(this.ribbonCheckBox_log_setting_all_CheckBoxCheckChanged);
            // 
            // ribbonSeparator_log_setting_1
            // 
            this.ribbonSeparator_log_setting_1.Name = "ribbonSeparator_log_setting_1";
            // 
            // ribbonCheckBox_log_setting_1
            // 
            this.ribbonCheckBox_log_setting_1.Name = "ribbonCheckBox_log_setting_1";
            this.ribbonCheckBox_log_setting_1.Text = "Unknown";
            this.ribbonCheckBox_log_setting_1.CheckBoxCheckChanged += new System.EventHandler(this.ribbonCheckBox_log_setting_1_CheckBoxCheckChanged);
            // 
            // ribbonCheckBox_log_setting_2
            // 
            this.ribbonCheckBox_log_setting_2.Name = "ribbonCheckBox_log_setting_2";
            this.ribbonCheckBox_log_setting_2.Text = "Setting";
            this.ribbonCheckBox_log_setting_2.CheckBoxCheckChanged += new System.EventHandler(this.ribbonCheckBox_log_setting_2_CheckBoxCheckChanged);
            // 
            // ribbonCheckBox_log_setting_3
            // 
            this.ribbonCheckBox_log_setting_3.Name = "ribbonCheckBox_log_setting_3";
            this.ribbonCheckBox_log_setting_3.Text = "Debug";
            this.ribbonCheckBox_log_setting_3.CheckBoxCheckChanged += new System.EventHandler(this.ribbonCheckBox_log_setting_3_CheckBoxCheckChanged);
            // 
            // ribbonCheckBox_log_setting_4
            // 
            this.ribbonCheckBox_log_setting_4.Name = "ribbonCheckBox_log_setting_4";
            this.ribbonCheckBox_log_setting_4.Text = "Alarm";
            this.ribbonCheckBox_log_setting_4.CheckBoxCheckChanged += new System.EventHandler(this.ribbonCheckBox_log_setting_4_CheckBoxCheckChanged);
            // 
            // ribbonCheckBox_log_setting_5
            // 
            this.ribbonCheckBox_log_setting_5.Name = "ribbonCheckBox_log_setting_5";
            this.ribbonCheckBox_log_setting_5.Text = "Warning";
            this.ribbonCheckBox_log_setting_5.CheckBoxCheckChanged += new System.EventHandler(this.ribbonCheckBox_log_setting_5_CheckBoxCheckChanged);
            // 
            // ribbonCheckBox_log_setting_6
            // 
            this.ribbonCheckBox_log_setting_6.Name = "ribbonCheckBox_log_setting_6";
            this.ribbonCheckBox_log_setting_6.Text = "System";
            this.ribbonCheckBox_log_setting_6.CheckBoxCheckChanged += new System.EventHandler(this.ribbonCheckBox_log_setting_6_CheckBoxCheckChanged);
            // 
            // ribbonCheckBox_log_setting_7
            // 
            this.ribbonCheckBox_log_setting_7.Name = "ribbonCheckBox_log_setting_7";
            this.ribbonCheckBox_log_setting_7.Text = "Process";
            this.ribbonCheckBox_log_setting_7.CheckBoxCheckChanged += new System.EventHandler(this.ribbonCheckBox_log_setting_7_CheckBoxCheckChanged);
            // 
            // ribbonCheckBox_log_setting_8
            // 
            this.ribbonCheckBox_log_setting_8.Name = "ribbonCheckBox_log_setting_8";
            this.ribbonCheckBox_log_setting_8.Text = "TactTime";
            this.ribbonCheckBox_log_setting_8.CheckBoxCheckChanged += new System.EventHandler(this.ribbonCheckBox_log_setting_8_CheckBoxCheckChanged);
            // 
            // ribbonCheckBox_log_setting_9
            // 
            this.ribbonCheckBox_log_setting_9.Name = "ribbonCheckBox_log_setting_9";
            this.ribbonCheckBox_log_setting_9.Text = "User";
            this.ribbonCheckBox_log_setting_9.CheckBoxCheckChanged += new System.EventHandler(this.ribbonCheckBox_log_setting_9_CheckBoxCheckChanged);
            // 
            // ribbonCheckBox_log_setting_10
            // 
            this.ribbonCheckBox_log_setting_10.Name = "ribbonCheckBox_log_setting_10";
            this.ribbonCheckBox_log_setting_10.Text = "Vision";
            this.ribbonCheckBox_log_setting_10.CheckBoxCheckChanged += new System.EventHandler(this.ribbonCheckBox_log_setting_10_CheckBoxCheckChanged);
            // 
            // ribbonCheckBox_log_setting_11
            // 
            this.ribbonCheckBox_log_setting_11.Name = "ribbonCheckBox_log_setting_11";
            this.ribbonCheckBox_log_setting_11.Text = "FieldCorrection";
            this.ribbonCheckBox_log_setting_11.CheckBoxCheckChanged += new System.EventHandler(this.ribbonCheckBox_log_setting_11_CheckBoxCheckChanged);
            // 
            // ribbonCheckBox_log_setting_12
            // 
            this.ribbonCheckBox_log_setting_12.Name = "ribbonCheckBox_log_setting_12";
            this.ribbonCheckBox_log_setting_12.Text = "Network";
            this.ribbonCheckBox_log_setting_12.CheckBoxCheckChanged += new System.EventHandler(this.ribbonCheckBox_log_setting_12_CheckBoxCheckChanged);
            // 
            // ribbonPanel_settings
            // 
            this.ribbonPanel_settings.Name = "ribbonPanel_settings";
            this.ribbonPanel_settings.Text = "설정";
            // 
            // ribbonButton_setting
            // 
            this.ribbonButton_setting.Image = ((System.Drawing.Image)(resources.GetObject("ribbonButton_setting.Image")));
            this.ribbonButton_setting.LargeImage = ((System.Drawing.Image)(resources.GetObject("ribbonButton_setting.LargeImage")));
            this.ribbonButton_setting.MaxSizeMode = System.Windows.Forms.RibbonElementSizeMode.Compact;
            this.ribbonButton_setting.Name = "ribbonButton_setting";
            this.ribbonButton_setting.SmallImage = ((System.Drawing.Image)(resources.GetObject("ribbonButton_setting.SmallImage")));
            this.ribbonButton_setting.Text = "설정";
            // 
            // ribbonTab_fc
            // 
            this.ribbonTab_fc.Name = "ribbonTab_fc";
            this.ribbonTab_fc.Panels.Add(this.ribbonPanel_fc);
            this.ribbonTab_fc.Panels.Add(this.ribbonPanel_fc_recipe);
            this.ribbonTab_fc.Panels.Add(this.ribbonPanel_fc_camera);
            this.ribbonTab_fc.Panels.Add(this.ribbonPanel_fc_param);
            this.ribbonTab_fc.Panels.Add(this.ribbonPanel_fc_detect);
            this.ribbonTab_fc.Text = "FieldCorrection";
            // 
            // ribbonPanel_fc
            // 
            this.ribbonPanel_fc.Items.Add(this.ribbonButton_fc);
            this.ribbonPanel_fc.Items.Add(this.ribbonButton_fc_stop);
            this.ribbonPanel_fc.Name = "ribbonPanel_fc";
            this.ribbonPanel_fc.Text = "FieldCorrection";
            // 
            // ribbonButton_fc
            // 
            this.ribbonButton_fc.Image = ((System.Drawing.Image)(resources.GetObject("ribbonButton_fc.Image")));
            this.ribbonButton_fc.LargeImage = ((System.Drawing.Image)(resources.GetObject("ribbonButton_fc.LargeImage")));
            this.ribbonButton_fc.MaxSizeMode = System.Windows.Forms.RibbonElementSizeMode.Large;
            this.ribbonButton_fc.Name = "ribbonButton_fc";
            this.ribbonButton_fc.SmallImage = ((System.Drawing.Image)(resources.GetObject("ribbonButton_fc.SmallImage")));
            this.ribbonButton_fc.Text = "Process Ready";
            this.ribbonButton_fc.Click += new System.EventHandler(this.ribbonButton_fc_Click);
            // 
            // ribbonPanel_fc_recipe
            // 
            this.ribbonPanel_fc_recipe.Items.Add(this.ribbonButton_fc_recipe_load);
            this.ribbonPanel_fc_recipe.Items.Add(this.ribbonButton_fc_recipe_save);
            this.ribbonPanel_fc_recipe.Items.Add(this.ribbonSeparator_fc_recipe_1);
            this.ribbonPanel_fc_recipe.Items.Add(this.ribbonTextBox_fc_recipe_num);
            this.ribbonPanel_fc_recipe.Items.Add(this.ribbonTextBox_fc_recipe_name);
            this.ribbonPanel_fc_recipe.Name = "ribbonPanel_fc_recipe";
            this.ribbonPanel_fc_recipe.Text = "Field Correction Recipe";
            // 
            // ribbonButton_fc_recipe_load
            // 
            this.ribbonButton_fc_recipe_load.Image = ((System.Drawing.Image)(resources.GetObject("ribbonButton_fc_recipe_load.Image")));
            this.ribbonButton_fc_recipe_load.LargeImage = ((System.Drawing.Image)(resources.GetObject("ribbonButton_fc_recipe_load.LargeImage")));
            this.ribbonButton_fc_recipe_load.MaxSizeMode = System.Windows.Forms.RibbonElementSizeMode.Medium;
            this.ribbonButton_fc_recipe_load.Name = "ribbonButton_fc_recipe_load";
            this.ribbonButton_fc_recipe_load.SmallImage = ((System.Drawing.Image)(resources.GetObject("ribbonButton_fc_recipe_load.SmallImage")));
            this.ribbonButton_fc_recipe_load.Text = "Load";
            this.ribbonButton_fc_recipe_load.Click += new System.EventHandler(this.ribbonButton_fc_recipe_load_Click);
            // 
            // ribbonButton_fc_recipe_save
            // 
            this.ribbonButton_fc_recipe_save.Image = ((System.Drawing.Image)(resources.GetObject("ribbonButton_fc_recipe_save.Image")));
            this.ribbonButton_fc_recipe_save.LargeImage = ((System.Drawing.Image)(resources.GetObject("ribbonButton_fc_recipe_save.LargeImage")));
            this.ribbonButton_fc_recipe_save.MaxSizeMode = System.Windows.Forms.RibbonElementSizeMode.Medium;
            this.ribbonButton_fc_recipe_save.Name = "ribbonButton_fc_recipe_save";
            this.ribbonButton_fc_recipe_save.SmallImage = ((System.Drawing.Image)(resources.GetObject("ribbonButton_fc_recipe_save.SmallImage")));
            this.ribbonButton_fc_recipe_save.Text = "Save";
            this.ribbonButton_fc_recipe_save.Click += new System.EventHandler(this.ribbonButton_fc_recipe_save_Click);
            // 
            // ribbonSeparator_fc_recipe_1
            // 
            this.ribbonSeparator_fc_recipe_1.Name = "ribbonSeparator_fc_recipe_1";
            // 
            // ribbonTextBox_fc_recipe_num
            // 
            this.ribbonTextBox_fc_recipe_num.LabelWidth = 50;
            this.ribbonTextBox_fc_recipe_num.Name = "ribbonTextBox_fc_recipe_num";
            this.ribbonTextBox_fc_recipe_num.Text = "Num";
            this.ribbonTextBox_fc_recipe_num.TextBoxText = "";
            this.ribbonTextBox_fc_recipe_num.TextBoxWidth = 20;
            // 
            // ribbonTextBox_fc_recipe_name
            // 
            this.ribbonTextBox_fc_recipe_name.LabelWidth = 50;
            this.ribbonTextBox_fc_recipe_name.Name = "ribbonTextBox_fc_recipe_name";
            this.ribbonTextBox_fc_recipe_name.Text = "Name";
            this.ribbonTextBox_fc_recipe_name.TextBoxText = "";
            this.ribbonTextBox_fc_recipe_name.TextBoxWidth = 120;
            // 
            // ribbonPanel_fc_camera
            // 
            this.ribbonPanel_fc_camera.Items.Add(this.ribbonUpDown_fc_camera_magni);
            this.ribbonPanel_fc_camera.Name = "ribbonPanel_fc_camera";
            this.ribbonPanel_fc_camera.Text = "F.C Camera";
            // 
            // ribbonUpDown_fc_camera_magni
            // 
            this.ribbonUpDown_fc_camera_magni.Name = "ribbonUpDown_fc_camera_magni";
            this.ribbonUpDown_fc_camera_magni.Text = "Magni";
            this.ribbonUpDown_fc_camera_magni.TextBoxText = "1";
            this.ribbonUpDown_fc_camera_magni.TextBoxWidth = 25;
            this.ribbonUpDown_fc_camera_magni.UpButtonClicked += new System.Windows.Forms.MouseEventHandler(this.ribbonUpDown_fc_camera_magni_UpButtonClicked);
            this.ribbonUpDown_fc_camera_magni.DownButtonClicked += new System.Windows.Forms.MouseEventHandler(this.ribbonUpDown_fc_camera_magni_DownButtonClicked);
            // 
            // ribbonPanel_fc_param
            // 
            this.ribbonPanel_fc_param.Items.Add(this.ribbonButton_fc_param_modify);
            this.ribbonPanel_fc_param.Items.Add(this.ribbonButton_fc_param_apply);
            this.ribbonPanel_fc_param.Items.Add(this.ribbonButton_fc_param_cancel);
            this.ribbonPanel_fc_param.Items.Add(this.ribbonSeparator_fc_param_1);
            this.ribbonPanel_fc_param.Items.Add(this.ribbonTextBox_fc_param_center_x);
            this.ribbonPanel_fc_param.Items.Add(this.ribbonTextBox_fc_param_center_y);
            this.ribbonPanel_fc_param.Items.Add(this.ribbonSeparator_fc_param_2);
            this.ribbonPanel_fc_param.Items.Add(this.ribbonTextBox_fc_param_gain);
            this.ribbonPanel_fc_param.Items.Add(this.ribbonTextBox_fc_param_newcal);
            this.ribbonPanel_fc_param.Items.Add(this.ribbonTextBox_fc_param_point);
            this.ribbonPanel_fc_param.Items.Add(this.ribbonTextBox_fc_param_length);
            this.ribbonPanel_fc_param.Items.Add(this.ribbonLabel_fc_param_empty_1);
            this.ribbonPanel_fc_param.Items.Add(this.ribbonLabel_fc_param_empty_2);
            this.ribbonPanel_fc_param.Items.Add(this.ribbonSeparator_fc_param_3);
            this.ribbonPanel_fc_param.Items.Add(this.ribbonButton_fc_param_oldctfile);
            this.ribbonPanel_fc_param.Items.Add(this.ribbonTextBox_fc_param_oldctfile);
            this.ribbonPanel_fc_param.Items.Add(this.ribbonTextBox_fc_param_newctfile);
            this.ribbonPanel_fc_param.Name = "ribbonPanel_fc_param";
            this.ribbonPanel_fc_param.Text = "Field Correction Parameter";
            // 
            // ribbonButton_fc_param_modify
            // 
            this.ribbonButton_fc_param_modify.Image = ((System.Drawing.Image)(resources.GetObject("ribbonButton_fc_param_modify.Image")));
            this.ribbonButton_fc_param_modify.LargeImage = ((System.Drawing.Image)(resources.GetObject("ribbonButton_fc_param_modify.LargeImage")));
            this.ribbonButton_fc_param_modify.MaxSizeMode = System.Windows.Forms.RibbonElementSizeMode.Large;
            this.ribbonButton_fc_param_modify.Name = "ribbonButton_fc_param_modify";
            this.ribbonButton_fc_param_modify.SmallImage = ((System.Drawing.Image)(resources.GetObject("ribbonButton_fc_param_modify.SmallImage")));
            this.ribbonButton_fc_param_modify.Text = "  Modify";
            this.ribbonButton_fc_param_modify.Click += new System.EventHandler(this.ribbonButton_fc_param_modify_Click);
            // 
            // ribbonButton_fc_param_apply
            // 
            this.ribbonButton_fc_param_apply.Enabled = false;
            this.ribbonButton_fc_param_apply.Image = ((System.Drawing.Image)(resources.GetObject("ribbonButton_fc_param_apply.Image")));
            this.ribbonButton_fc_param_apply.LargeImage = ((System.Drawing.Image)(resources.GetObject("ribbonButton_fc_param_apply.LargeImage")));
            this.ribbonButton_fc_param_apply.MaxSizeMode = System.Windows.Forms.RibbonElementSizeMode.Medium;
            this.ribbonButton_fc_param_apply.Name = "ribbonButton_fc_param_apply";
            this.ribbonButton_fc_param_apply.SmallImage = ((System.Drawing.Image)(resources.GetObject("ribbonButton_fc_param_apply.SmallImage")));
            this.ribbonButton_fc_param_apply.Text = "Apply";
            this.ribbonButton_fc_param_apply.Click += new System.EventHandler(this.ribbonButton_fc_param_apply_Click);
            // 
            // ribbonButton_fc_param_cancel
            // 
            this.ribbonButton_fc_param_cancel.Enabled = false;
            this.ribbonButton_fc_param_cancel.Image = ((System.Drawing.Image)(resources.GetObject("ribbonButton_fc_param_cancel.Image")));
            this.ribbonButton_fc_param_cancel.LargeImage = ((System.Drawing.Image)(resources.GetObject("ribbonButton_fc_param_cancel.LargeImage")));
            this.ribbonButton_fc_param_cancel.MaxSizeMode = System.Windows.Forms.RibbonElementSizeMode.Medium;
            this.ribbonButton_fc_param_cancel.Name = "ribbonButton_fc_param_cancel";
            this.ribbonButton_fc_param_cancel.SmallImage = ((System.Drawing.Image)(resources.GetObject("ribbonButton_fc_param_cancel.SmallImage")));
            this.ribbonButton_fc_param_cancel.Text = "Cancel";
            this.ribbonButton_fc_param_cancel.Click += new System.EventHandler(this.ribbonButton_fc_param_cancel_Click);
            // 
            // ribbonSeparator_fc_param_1
            // 
            this.ribbonSeparator_fc_param_1.Name = "ribbonSeparator_fc_param_1";
            // 
            // ribbonTextBox_fc_param_center_x
            // 
            this.ribbonTextBox_fc_param_center_x.Enabled = false;
            this.ribbonTextBox_fc_param_center_x.LabelWidth = 60;
            this.ribbonTextBox_fc_param_center_x.Name = "ribbonTextBox_fc_param_center_x";
            this.ribbonTextBox_fc_param_center_x.Text = "Center X";
            this.ribbonTextBox_fc_param_center_x.TextBoxText = "";
            this.ribbonTextBox_fc_param_center_x.TextBoxWidth = 40;
            this.ribbonTextBox_fc_param_center_x.TextBoxTextChanged += new System.EventHandler(this.ribbonTextBox_fc_param_center_x_TextBoxTextChanged);
            // 
            // ribbonTextBox_fc_param_center_y
            // 
            this.ribbonTextBox_fc_param_center_y.Enabled = false;
            this.ribbonTextBox_fc_param_center_y.LabelWidth = 60;
            this.ribbonTextBox_fc_param_center_y.Name = "ribbonTextBox_fc_param_center_y";
            this.ribbonTextBox_fc_param_center_y.Text = "Center Y";
            this.ribbonTextBox_fc_param_center_y.TextBoxText = "";
            this.ribbonTextBox_fc_param_center_y.TextBoxWidth = 40;
            this.ribbonTextBox_fc_param_center_y.TextBoxTextChanged += new System.EventHandler(this.ribbonTextBox_fc_param_center_y_TextBoxTextChanged);
            // 
            // ribbonSeparator_fc_param_2
            // 
            this.ribbonSeparator_fc_param_2.Name = "ribbonSeparator_fc_param_2";
            // 
            // ribbonTextBox_fc_param_gain
            // 
            this.ribbonTextBox_fc_param_gain.Enabled = false;
            this.ribbonTextBox_fc_param_gain.LabelWidth = 80;
            this.ribbonTextBox_fc_param_gain.Name = "ribbonTextBox_fc_param_gain";
            this.ribbonTextBox_fc_param_gain.Text = "Gain";
            this.ribbonTextBox_fc_param_gain.TextBoxText = "";
            this.ribbonTextBox_fc_param_gain.TextBoxWidth = 40;
            this.ribbonTextBox_fc_param_gain.TextBoxTextChanged += new System.EventHandler(this.ribbonTextBox_fc_param_gain_TextBoxTextChanged);
            // 
            // ribbonTextBox_fc_param_newcal
            // 
            this.ribbonTextBox_fc_param_newcal.Enabled = false;
            this.ribbonTextBox_fc_param_newcal.LabelWidth = 80;
            this.ribbonTextBox_fc_param_newcal.Name = "ribbonTextBox_fc_param_newcal";
            this.ribbonTextBox_fc_param_newcal.Text = "Bit/mm";
            this.ribbonTextBox_fc_param_newcal.TextBoxText = "";
            this.ribbonTextBox_fc_param_newcal.TextBoxWidth = 40;
            this.ribbonTextBox_fc_param_newcal.TextBoxTextChanged += new System.EventHandler(this.ribbonTextBox_fc_param_newcal_TextBoxTextChanged);
            // 
            // ribbonTextBox_fc_param_point
            // 
            this.ribbonTextBox_fc_param_point.Enabled = false;
            this.ribbonTextBox_fc_param_point.LabelWidth = 80;
            this.ribbonTextBox_fc_param_point.Name = "ribbonTextBox_fc_param_point";
            this.ribbonTextBox_fc_param_point.Text = "Point(n x n)";
            this.ribbonTextBox_fc_param_point.TextBoxText = "";
            this.ribbonTextBox_fc_param_point.TextBoxWidth = 40;
            this.ribbonTextBox_fc_param_point.TextBoxTextChanged += new System.EventHandler(this.ribbonTextBox_fc_param_point_TextBoxTextChanged);
            // 
            // ribbonTextBox_fc_param_length
            // 
            this.ribbonTextBox_fc_param_length.Enabled = false;
            this.ribbonTextBox_fc_param_length.LabelWidth = 80;
            this.ribbonTextBox_fc_param_length.Name = "ribbonTextBox_fc_param_length";
            this.ribbonTextBox_fc_param_length.Text = "Length(mm)";
            this.ribbonTextBox_fc_param_length.TextBoxText = "";
            this.ribbonTextBox_fc_param_length.TextBoxWidth = 40;
            this.ribbonTextBox_fc_param_length.TextBoxTextChanged += new System.EventHandler(this.ribbonTextBox_fc_param_length_TextBoxTextChanged);
            // 
            // ribbonLabel_fc_param_empty_1
            // 
            this.ribbonLabel_fc_param_empty_1.Name = "ribbonLabel_fc_param_empty_1";
            // 
            // ribbonLabel_fc_param_empty_2
            // 
            this.ribbonLabel_fc_param_empty_2.Name = "ribbonLabel_fc_param_empty_2";
            // 
            // ribbonSeparator_fc_param_3
            // 
            this.ribbonSeparator_fc_param_3.Name = "ribbonSeparator_fc_param_3";
            // 
            // ribbonButton_fc_param_oldctfile
            // 
            this.ribbonButton_fc_param_oldctfile.Enabled = false;
            this.ribbonButton_fc_param_oldctfile.Image = ((System.Drawing.Image)(resources.GetObject("ribbonButton_fc_param_oldctfile.Image")));
            this.ribbonButton_fc_param_oldctfile.LargeImage = ((System.Drawing.Image)(resources.GetObject("ribbonButton_fc_param_oldctfile.LargeImage")));
            this.ribbonButton_fc_param_oldctfile.MaxSizeMode = System.Windows.Forms.RibbonElementSizeMode.Large;
            this.ribbonButton_fc_param_oldctfile.Name = "ribbonButton_fc_param_oldctfile";
            this.ribbonButton_fc_param_oldctfile.SmallImage = ((System.Drawing.Image)(resources.GetObject("ribbonButton_fc_param_oldctfile.SmallImage")));
            this.ribbonButton_fc_param_oldctfile.Text = "  Oldctfile";
            this.ribbonButton_fc_param_oldctfile.Click += new System.EventHandler(this.ribbonButton_fc_param_oldctfile_Click);
            // 
            // ribbonTextBox_fc_param_oldctfile
            // 
            this.ribbonTextBox_fc_param_oldctfile.Enabled = false;
            this.ribbonTextBox_fc_param_oldctfile.LabelWidth = 70;
            this.ribbonTextBox_fc_param_oldctfile.MaxSizeMode = System.Windows.Forms.RibbonElementSizeMode.Overflow;
            this.ribbonTextBox_fc_param_oldctfile.Name = "ribbonTextBox_fc_param_oldctfile";
            this.ribbonTextBox_fc_param_oldctfile.Text = "Old File";
            this.ribbonTextBox_fc_param_oldctfile.TextBoxText = "";
            this.ribbonTextBox_fc_param_oldctfile.TextBoxWidth = 150;
            this.ribbonTextBox_fc_param_oldctfile.TextBoxTextChanged += new System.EventHandler(this.ribbonTextBox_fc_param_oldctfile_TextBoxTextChanged);
            // 
            // ribbonTextBox_fc_param_newctfile
            // 
            this.ribbonTextBox_fc_param_newctfile.Enabled = false;
            this.ribbonTextBox_fc_param_newctfile.LabelWidth = 70;
            this.ribbonTextBox_fc_param_newctfile.MaxSizeMode = System.Windows.Forms.RibbonElementSizeMode.Overflow;
            this.ribbonTextBox_fc_param_newctfile.Name = "ribbonTextBox_fc_param_newctfile";
            this.ribbonTextBox_fc_param_newctfile.Text = "New File";
            this.ribbonTextBox_fc_param_newctfile.TextBoxText = "";
            this.ribbonTextBox_fc_param_newctfile.TextBoxWidth = 150;
            this.ribbonTextBox_fc_param_newctfile.TextBoxTextChanged += new System.EventHandler(this.ribbonTextBox_fc_param_newctfile_TextBoxTextChanged);
            // 
            // ribbonPanel_fc_detect
            // 
            this.ribbonPanel_fc_detect.Items.Add(this.ribbonButton_fc_detect_mark);
            this.ribbonPanel_fc_detect.Items.Add(this.ribbonButton_fc_detect_clear);
            this.ribbonPanel_fc_detect.Items.Add(this.ribbonSeparator_fc_detect_1);
            this.ribbonPanel_fc_detect.Items.Add(this.ribbonTextBox_fc_detect_matchrate);
            this.ribbonPanel_fc_detect.Items.Add(this.ribbonTextBox_fc_detect_point_x);
            this.ribbonPanel_fc_detect.Items.Add(this.ribbonTextBox_fc_detect_point_y);
            this.ribbonPanel_fc_detect.Items.Add(this.ribbonSeparator_fc_detect_2);
            this.ribbonPanel_fc_detect.Items.Add(this.ribbonButton_fc_detect_simulation);
            this.ribbonPanel_fc_detect.Items.Add(this.ribbonButton_fc_detect_simulation_clear);
            this.ribbonPanel_fc_detect.Name = "ribbonPanel_fc_detect";
            this.ribbonPanel_fc_detect.Text = "Field Correction Detect";
            // 
            // ribbonButton_fc_detect_mark
            // 
            this.ribbonButton_fc_detect_mark.Image = ((System.Drawing.Image)(resources.GetObject("ribbonButton_fc_detect_mark.Image")));
            this.ribbonButton_fc_detect_mark.LargeImage = ((System.Drawing.Image)(resources.GetObject("ribbonButton_fc_detect_mark.LargeImage")));
            this.ribbonButton_fc_detect_mark.MaxSizeMode = System.Windows.Forms.RibbonElementSizeMode.Large;
            this.ribbonButton_fc_detect_mark.Name = "ribbonButton_fc_detect_mark";
            this.ribbonButton_fc_detect_mark.SmallImage = ((System.Drawing.Image)(resources.GetObject("ribbonButton_fc_detect_mark.SmallImage")));
            this.ribbonButton_fc_detect_mark.Text = "  Detect";
            this.ribbonButton_fc_detect_mark.Click += new System.EventHandler(this.ribbonButton_fc_detect_mark_Click);
            // 
            // ribbonButton_fc_detect_clear
            // 
            this.ribbonButton_fc_detect_clear.Image = ((System.Drawing.Image)(resources.GetObject("ribbonButton_fc_detect_clear.Image")));
            this.ribbonButton_fc_detect_clear.LargeImage = ((System.Drawing.Image)(resources.GetObject("ribbonButton_fc_detect_clear.LargeImage")));
            this.ribbonButton_fc_detect_clear.MaxSizeMode = System.Windows.Forms.RibbonElementSizeMode.Large;
            this.ribbonButton_fc_detect_clear.Name = "ribbonButton_fc_detect_clear";
            this.ribbonButton_fc_detect_clear.SmallImage = ((System.Drawing.Image)(resources.GetObject("ribbonButton_fc_detect_clear.SmallImage")));
            this.ribbonButton_fc_detect_clear.Text = "  Clear";
            this.ribbonButton_fc_detect_clear.Click += new System.EventHandler(this.ribbonButton_fc_detect_clear_Click);
            // 
            // ribbonSeparator_fc_detect_1
            // 
            this.ribbonSeparator_fc_detect_1.Name = "ribbonSeparator_fc_detect_1";
            // 
            // ribbonTextBox_fc_detect_matchrate
            // 
            this.ribbonTextBox_fc_detect_matchrate.LabelWidth = 90;
            this.ribbonTextBox_fc_detect_matchrate.Name = "ribbonTextBox_fc_detect_matchrate";
            this.ribbonTextBox_fc_detect_matchrate.Text = "MatchRate(%)";
            this.ribbonTextBox_fc_detect_matchrate.TextBoxText = "";
            this.ribbonTextBox_fc_detect_matchrate.TextBoxWidth = 50;
            // 
            // ribbonTextBox_fc_detect_point_x
            // 
            this.ribbonTextBox_fc_detect_point_x.LabelWidth = 90;
            this.ribbonTextBox_fc_detect_point_x.Name = "ribbonTextBox_fc_detect_point_x";
            this.ribbonTextBox_fc_detect_point_x.Text = "X Point";
            this.ribbonTextBox_fc_detect_point_x.TextBoxText = "";
            this.ribbonTextBox_fc_detect_point_x.TextBoxWidth = 50;
            // 
            // ribbonTextBox_fc_detect_point_y
            // 
            this.ribbonTextBox_fc_detect_point_y.LabelWidth = 90;
            this.ribbonTextBox_fc_detect_point_y.Name = "ribbonTextBox_fc_detect_point_y";
            this.ribbonTextBox_fc_detect_point_y.Text = "Y Point";
            this.ribbonTextBox_fc_detect_point_y.TextBoxText = "";
            this.ribbonTextBox_fc_detect_point_y.TextBoxWidth = 50;
            // 
            // ribbonSeparator_fc_detect_2
            // 
            this.ribbonSeparator_fc_detect_2.Name = "ribbonSeparator_fc_detect_2";
            // 
            // ribbonButton_fc_detect_simulation
            // 
            this.ribbonButton_fc_detect_simulation.Image = ((System.Drawing.Image)(resources.GetObject("ribbonButton_fc_detect_simulation.Image")));
            this.ribbonButton_fc_detect_simulation.LargeImage = ((System.Drawing.Image)(resources.GetObject("ribbonButton_fc_detect_simulation.LargeImage")));
            this.ribbonButton_fc_detect_simulation.Name = "ribbonButton_fc_detect_simulation";
            this.ribbonButton_fc_detect_simulation.SmallImage = ((System.Drawing.Image)(resources.GetObject("ribbonButton_fc_detect_simulation.SmallImage")));
            this.ribbonButton_fc_detect_simulation.Click += new System.EventHandler(this.ribbonButton_fc_detect_simulation_Click);
            // 
            // ribbonButton_fc_detect_simulation_clear
            // 
            this.ribbonButton_fc_detect_simulation_clear.Image = ((System.Drawing.Image)(resources.GetObject("ribbonButton_fc_detect_simulation_clear.Image")));
            this.ribbonButton_fc_detect_simulation_clear.LargeImage = ((System.Drawing.Image)(resources.GetObject("ribbonButton_fc_detect_simulation_clear.LargeImage")));
            this.ribbonButton_fc_detect_simulation_clear.Name = "ribbonButton_fc_detect_simulation_clear";
            this.ribbonButton_fc_detect_simulation_clear.SmallImage = ((System.Drawing.Image)(resources.GetObject("ribbonButton_fc_detect_simulation_clear.SmallImage")));
            this.ribbonButton_fc_detect_simulation_clear.Click += new System.EventHandler(this.ribbonButton_fc_detect_simulation_clear_Click);
            // 
            // ribbonTab_auto
            // 
            this.ribbonTab_auto.Name = "ribbonTab_auto";
            this.ribbonTab_auto.Panels.Add(this.ribbonPanel_autorun);
            this.ribbonTab_auto.Panels.Add(this.ribbonPanel_auto_vision_recipe);
            this.ribbonTab_auto.Panels.Add(this.ribbonPanel_auto_vision_position);
            this.ribbonTab_auto.Panels.Add(this.ribbonPanel_auto_laser_position);
            this.ribbonTab_auto.Panels.Add(this.ribbonPanel_auto_align);
            this.ribbonTab_auto.Text = "Auto";
            // 
            // ribbonPanel_autorun
            // 
            this.ribbonPanel_autorun.Items.Add(this.ribbonButton_autorun_start);
            this.ribbonPanel_autorun.Items.Add(this.ribbonButton_autorun_stop);
            this.ribbonPanel_autorun.Name = "ribbonPanel_autorun";
            this.ribbonPanel_autorun.Text = "Auto Run";
            // 
            // ribbonButton_autorun_start
            // 
            this.ribbonButton_autorun_start.Image = ((System.Drawing.Image)(resources.GetObject("ribbonButton_autorun_start.Image")));
            this.ribbonButton_autorun_start.LargeImage = ((System.Drawing.Image)(resources.GetObject("ribbonButton_autorun_start.LargeImage")));
            this.ribbonButton_autorun_start.MaxSizeMode = System.Windows.Forms.RibbonElementSizeMode.Large;
            this.ribbonButton_autorun_start.Name = "ribbonButton_autorun_start";
            this.ribbonButton_autorun_start.SmallImage = ((System.Drawing.Image)(resources.GetObject("ribbonButton_autorun_start.SmallImage")));
            this.ribbonButton_autorun_start.Text = "Process Ready";
            this.ribbonButton_autorun_start.Click += new System.EventHandler(this.ribbonButton_autorun_start_Click);
            // 
            // ribbonButton_autorun_stop
            // 
            this.ribbonButton_autorun_stop.Image = ((System.Drawing.Image)(resources.GetObject("ribbonButton_autorun_stop.Image")));
            this.ribbonButton_autorun_stop.LargeImage = ((System.Drawing.Image)(resources.GetObject("ribbonButton_autorun_stop.LargeImage")));
            this.ribbonButton_autorun_stop.Name = "ribbonButton_autorun_stop";
            this.ribbonButton_autorun_stop.SmallImage = ((System.Drawing.Image)(resources.GetObject("ribbonButton_autorun_stop.SmallImage")));
            this.ribbonButton_autorun_stop.Text = "Process Stop";
            // 
            // ribbonPanel_auto_vision_recipe
            // 
            this.ribbonPanel_auto_vision_recipe.Items.Add(this.ribbonTextBox_auto_vision_recipe_num);
            this.ribbonPanel_auto_vision_recipe.Items.Add(this.ribbonTextBox_auto_vision_recipe_name);
            this.ribbonPanel_auto_vision_recipe.Name = "ribbonPanel_auto_vision_recipe";
            this.ribbonPanel_auto_vision_recipe.Text = "Vision Recipe";
            // 
            // ribbonTextBox_auto_vision_recipe_num
            // 
            this.ribbonTextBox_auto_vision_recipe_num.LabelWidth = 50;
            this.ribbonTextBox_auto_vision_recipe_num.Name = "ribbonTextBox_auto_vision_recipe_num";
            this.ribbonTextBox_auto_vision_recipe_num.Text = "Num";
            this.ribbonTextBox_auto_vision_recipe_num.TextBoxText = "";
            this.ribbonTextBox_auto_vision_recipe_num.TextBoxWidth = 20;
            // 
            // ribbonTextBox_auto_vision_recipe_name
            // 
            this.ribbonTextBox_auto_vision_recipe_name.LabelWidth = 50;
            this.ribbonTextBox_auto_vision_recipe_name.Name = "ribbonTextBox_auto_vision_recipe_name";
            this.ribbonTextBox_auto_vision_recipe_name.Text = "Name";
            this.ribbonTextBox_auto_vision_recipe_name.TextBoxText = "";
            this.ribbonTextBox_auto_vision_recipe_name.TextBoxWidth = 150;
            // 
            // ribbonPanel_auto_vision_position
            // 
            this.ribbonPanel_auto_vision_position.Items.Add(this.ribbonTextBox_auto_vision_position_x_1);
            this.ribbonPanel_auto_vision_position.Items.Add(this.ribbonTextBox_auto_vision_position_y_1);
            this.ribbonPanel_auto_vision_position.Items.Add(this.ribbonLabel_auto_vision_position_empty_1);
            this.ribbonPanel_auto_vision_position.Items.Add(this.ribbonTextBox_auto_vision_position_x_2);
            this.ribbonPanel_auto_vision_position.Items.Add(this.ribbonTextBox_auto_vision_position_y_2);
            this.ribbonPanel_auto_vision_position.Items.Add(this.ribbonLabel_auto_vision_position_empty_2);
            this.ribbonPanel_auto_vision_position.Items.Add(this.ribbonTextBox_auto_vision_position_x_3);
            this.ribbonPanel_auto_vision_position.Items.Add(this.ribbonTextBox_auto_vision_position_y_3);
            this.ribbonPanel_auto_vision_position.Items.Add(this.ribbonLabel_auto_vision_position_empty_3);
            this.ribbonPanel_auto_vision_position.Items.Add(this.ribbonTextBox_auto_vision_position_x_4);
            this.ribbonPanel_auto_vision_position.Items.Add(this.ribbonTextBox_auto_vision_position_y_4);
            this.ribbonPanel_auto_vision_position.Items.Add(this.ribbonLabel_auto_vision_position_empty_4);
            this.ribbonPanel_auto_vision_position.Name = "ribbonPanel_auto_vision_position";
            this.ribbonPanel_auto_vision_position.Text = "Vision Position";
            // 
            // ribbonTextBox_auto_vision_position_x_1
            // 
            this.ribbonTextBox_auto_vision_position_x_1.LabelWidth = 30;
            this.ribbonTextBox_auto_vision_position_x_1.Name = "ribbonTextBox_auto_vision_position_x_1";
            this.ribbonTextBox_auto_vision_position_x_1.Text = "1(X)";
            this.ribbonTextBox_auto_vision_position_x_1.TextBoxText = "";
            this.ribbonTextBox_auto_vision_position_x_1.TextBoxWidth = 50;
            // 
            // ribbonTextBox_auto_vision_position_y_1
            // 
            this.ribbonTextBox_auto_vision_position_y_1.LabelWidth = 30;
            this.ribbonTextBox_auto_vision_position_y_1.Name = "ribbonTextBox_auto_vision_position_y_1";
            this.ribbonTextBox_auto_vision_position_y_1.Text = "1(Y)";
            this.ribbonTextBox_auto_vision_position_y_1.TextBoxText = "";
            this.ribbonTextBox_auto_vision_position_y_1.TextBoxWidth = 50;
            // 
            // ribbonLabel_auto_vision_position_empty_1
            // 
            this.ribbonLabel_auto_vision_position_empty_1.Name = "ribbonLabel_auto_vision_position_empty_1";
            // 
            // ribbonTextBox_auto_vision_position_x_2
            // 
            this.ribbonTextBox_auto_vision_position_x_2.LabelWidth = 30;
            this.ribbonTextBox_auto_vision_position_x_2.Name = "ribbonTextBox_auto_vision_position_x_2";
            this.ribbonTextBox_auto_vision_position_x_2.Text = "2(X)";
            this.ribbonTextBox_auto_vision_position_x_2.TextBoxText = "";
            this.ribbonTextBox_auto_vision_position_x_2.TextBoxWidth = 50;
            // 
            // ribbonTextBox_auto_vision_position_y_2
            // 
            this.ribbonTextBox_auto_vision_position_y_2.LabelWidth = 30;
            this.ribbonTextBox_auto_vision_position_y_2.Name = "ribbonTextBox_auto_vision_position_y_2";
            this.ribbonTextBox_auto_vision_position_y_2.Text = "2(Y)";
            this.ribbonTextBox_auto_vision_position_y_2.TextBoxText = "";
            this.ribbonTextBox_auto_vision_position_y_2.TextBoxWidth = 50;
            // 
            // ribbonLabel_auto_vision_position_empty_2
            // 
            this.ribbonLabel_auto_vision_position_empty_2.Name = "ribbonLabel_auto_vision_position_empty_2";
            // 
            // ribbonTextBox_auto_vision_position_x_3
            // 
            this.ribbonTextBox_auto_vision_position_x_3.LabelWidth = 30;
            this.ribbonTextBox_auto_vision_position_x_3.Name = "ribbonTextBox_auto_vision_position_x_3";
            this.ribbonTextBox_auto_vision_position_x_3.Text = "3(X)";
            this.ribbonTextBox_auto_vision_position_x_3.TextBoxText = "";
            this.ribbonTextBox_auto_vision_position_x_3.TextBoxWidth = 50;
            // 
            // ribbonTextBox_auto_vision_position_y_3
            // 
            this.ribbonTextBox_auto_vision_position_y_3.LabelWidth = 30;
            this.ribbonTextBox_auto_vision_position_y_3.Name = "ribbonTextBox_auto_vision_position_y_3";
            this.ribbonTextBox_auto_vision_position_y_3.Text = "3(Y)";
            this.ribbonTextBox_auto_vision_position_y_3.TextBoxText = "";
            this.ribbonTextBox_auto_vision_position_y_3.TextBoxWidth = 50;
            // 
            // ribbonLabel_auto_vision_position_empty_3
            // 
            this.ribbonLabel_auto_vision_position_empty_3.Name = "ribbonLabel_auto_vision_position_empty_3";
            // 
            // ribbonTextBox_auto_vision_position_x_4
            // 
            this.ribbonTextBox_auto_vision_position_x_4.LabelWidth = 30;
            this.ribbonTextBox_auto_vision_position_x_4.Name = "ribbonTextBox_auto_vision_position_x_4";
            this.ribbonTextBox_auto_vision_position_x_4.Text = "4(X)";
            this.ribbonTextBox_auto_vision_position_x_4.TextBoxText = "";
            this.ribbonTextBox_auto_vision_position_x_4.TextBoxWidth = 50;
            // 
            // ribbonTextBox_auto_vision_position_y_4
            // 
            this.ribbonTextBox_auto_vision_position_y_4.LabelWidth = 30;
            this.ribbonTextBox_auto_vision_position_y_4.Name = "ribbonTextBox_auto_vision_position_y_4";
            this.ribbonTextBox_auto_vision_position_y_4.Text = "4(Y)";
            this.ribbonTextBox_auto_vision_position_y_4.TextBoxText = "";
            this.ribbonTextBox_auto_vision_position_y_4.TextBoxWidth = 50;
            // 
            // ribbonLabel_auto_vision_position_empty_4
            // 
            this.ribbonLabel_auto_vision_position_empty_4.Name = "ribbonLabel_auto_vision_position_empty_4";
            // 
            // ribbonPanel_auto_laser_position
            // 
            this.ribbonPanel_auto_laser_position.Items.Add(this.ribbonTextBox_auto_laser_position_x);
            this.ribbonPanel_auto_laser_position.Items.Add(this.ribbonTextBox_auto_laser_position_y);
            this.ribbonPanel_auto_laser_position.Items.Add(this.ribbonLabel_auto_laser_position_empty_1);
            this.ribbonPanel_auto_laser_position.Name = "ribbonPanel_auto_laser_position";
            this.ribbonPanel_auto_laser_position.Text = "Laser Position";
            // 
            // ribbonTextBox_auto_laser_position_x
            // 
            this.ribbonTextBox_auto_laser_position_x.LabelWidth = 50;
            this.ribbonTextBox_auto_laser_position_x.Name = "ribbonTextBox_auto_laser_position_x";
            this.ribbonTextBox_auto_laser_position_x.Text = "X Pos";
            this.ribbonTextBox_auto_laser_position_x.TextBoxText = "";
            this.ribbonTextBox_auto_laser_position_x.TextBoxWidth = 60;
            // 
            // ribbonTextBox_auto_laser_position_y
            // 
            this.ribbonTextBox_auto_laser_position_y.LabelWidth = 50;
            this.ribbonTextBox_auto_laser_position_y.Name = "ribbonTextBox_auto_laser_position_y";
            this.ribbonTextBox_auto_laser_position_y.Text = "Y Pos";
            this.ribbonTextBox_auto_laser_position_y.TextBoxText = "";
            this.ribbonTextBox_auto_laser_position_y.TextBoxWidth = 60;
            // 
            // ribbonLabel_auto_laser_position_empty_1
            // 
            this.ribbonLabel_auto_laser_position_empty_1.Name = "ribbonLabel_auto_laser_position_empty_1";
            // 
            // ribbonPanel_auto_align
            // 
            this.ribbonPanel_auto_align.Items.Add(this.ribbonRadioBox_auto_align_mark);
            this.ribbonPanel_auto_align.Items.Add(this.ribbonRadioBox_auto_align_edge);
            this.ribbonPanel_auto_align.Items.Add(this.ribbonSeparator_auto_align_1);
            this.ribbonPanel_auto_align.Items.Add(this.ribbonTextBox_auto_align_distance);
            this.ribbonPanel_auto_align.Items.Add(this.ribbonLabel_auto_align_empty_1);
            this.ribbonPanel_auto_align.Items.Add(this.ribbonLabel_auto_align_empty_2);
            this.ribbonPanel_auto_align.Items.Add(this.ribbonTextBox_auto_align_range_x);
            this.ribbonPanel_auto_align.Items.Add(this.ribbonTextBox_auto_align_range_y);
            this.ribbonPanel_auto_align.Items.Add(this.ribbonTextBox_auto_align_range_t);
            this.ribbonPanel_auto_align.Items.Add(this.ribbonSeparator_auto_align_2);
            this.ribbonPanel_auto_align.Items.Add(this.ribbonTextBox_auto_align_mark_matchrate_1);
            this.ribbonPanel_auto_align.Items.Add(this.ribbonTextBox_auto_align_mark_matchrate_2);
            this.ribbonPanel_auto_align.Items.Add(this.ribbonLabel_auto_align_empty_3);
            this.ribbonPanel_auto_align.Items.Add(this.ribbonTextBox_auto_align_mark_matchrate_3);
            this.ribbonPanel_auto_align.Items.Add(this.ribbonTextBox_auto_align_mark_matchrate_4);
            this.ribbonPanel_auto_align.Items.Add(this.ribbonLabel_auto_align_empty_4);
            this.ribbonPanel_auto_align.Items.Add(this.ribbonSeparator_auto_align_3);
            this.ribbonPanel_auto_align.Items.Add(this.ribbonTextBox_auto_align_edge_level);
            this.ribbonPanel_auto_align.Items.Add(this.ribbonTextBox_auto_align_edge_miss);
            this.ribbonPanel_auto_align.Items.Add(this.ribbonLabel_auto_align_empty_5);
            this.ribbonPanel_auto_align.Name = "ribbonPanel_auto_align";
            this.ribbonPanel_auto_align.Text = "Align Parameter";
            // 
            // ribbonRadioBox_auto_align_mark
            // 
            this.ribbonRadioBox_auto_align_mark.Name = "ribbonRadioBox_auto_align_mark";
            this.ribbonRadioBox_auto_align_mark.Style = System.Windows.Forms.RibbonCheckBox.CheckBoxStyle.RadioButton;
            this.ribbonRadioBox_auto_align_mark.Text = "Mark";
            // 
            // ribbonRadioBox_auto_align_edge
            // 
            this.ribbonRadioBox_auto_align_edge.Name = "ribbonRadioBox_auto_align_edge";
            this.ribbonRadioBox_auto_align_edge.Style = System.Windows.Forms.RibbonCheckBox.CheckBoxStyle.RadioButton;
            this.ribbonRadioBox_auto_align_edge.Text = "Edge";
            // 
            // ribbonSeparator_auto_align_1
            // 
            this.ribbonSeparator_auto_align_1.Name = "ribbonSeparator_auto_align_1";
            // 
            // ribbonTextBox_auto_align_distance
            // 
            this.ribbonTextBox_auto_align_distance.LabelWidth = 60;
            this.ribbonTextBox_auto_align_distance.Name = "ribbonTextBox_auto_align_distance";
            this.ribbonTextBox_auto_align_distance.Text = "Distance";
            this.ribbonTextBox_auto_align_distance.TextBoxText = "";
            this.ribbonTextBox_auto_align_distance.TextBoxWidth = 40;
            // 
            // ribbonLabel_auto_align_empty_1
            // 
            this.ribbonLabel_auto_align_empty_1.Name = "ribbonLabel_auto_align_empty_1";
            // 
            // ribbonLabel_auto_align_empty_2
            // 
            this.ribbonLabel_auto_align_empty_2.Name = "ribbonLabel_auto_align_empty_2";
            // 
            // ribbonTextBox_auto_align_range_x
            // 
            this.ribbonTextBox_auto_align_range_x.LabelWidth = 60;
            this.ribbonTextBox_auto_align_range_x.Name = "ribbonTextBox_auto_align_range_x";
            this.ribbonTextBox_auto_align_range_x.Text = "X (±㎜)";
            this.ribbonTextBox_auto_align_range_x.TextBoxText = "";
            this.ribbonTextBox_auto_align_range_x.TextBoxWidth = 40;
            // 
            // ribbonTextBox_auto_align_range_y
            // 
            this.ribbonTextBox_auto_align_range_y.LabelWidth = 60;
            this.ribbonTextBox_auto_align_range_y.Name = "ribbonTextBox_auto_align_range_y";
            this.ribbonTextBox_auto_align_range_y.Text = "Y (±㎜)";
            this.ribbonTextBox_auto_align_range_y.TextBoxText = "";
            this.ribbonTextBox_auto_align_range_y.TextBoxWidth = 40;
            // 
            // ribbonTextBox_auto_align_range_t
            // 
            this.ribbonTextBox_auto_align_range_t.LabelWidth = 60;
            this.ribbonTextBox_auto_align_range_t.Name = "ribbonTextBox_auto_align_range_t";
            this.ribbonTextBox_auto_align_range_t.Text = "Turn (±˚)";
            this.ribbonTextBox_auto_align_range_t.TextBoxText = "";
            this.ribbonTextBox_auto_align_range_t.TextBoxWidth = 40;
            // 
            // ribbonSeparator_auto_align_2
            // 
            this.ribbonSeparator_auto_align_2.Name = "ribbonSeparator_auto_align_2";
            // 
            // ribbonTextBox_auto_align_mark_matchrate_1
            // 
            this.ribbonTextBox_auto_align_mark_matchrate_1.LabelWidth = 90;
            this.ribbonTextBox_auto_align_mark_matchrate_1.Name = "ribbonTextBox_auto_align_mark_matchrate_1";
            this.ribbonTextBox_auto_align_mark_matchrate_1.Text = "MatchRate (1)";
            this.ribbonTextBox_auto_align_mark_matchrate_1.TextBoxText = "";
            this.ribbonTextBox_auto_align_mark_matchrate_1.TextBoxWidth = 40;
            // 
            // ribbonTextBox_auto_align_mark_matchrate_2
            // 
            this.ribbonTextBox_auto_align_mark_matchrate_2.LabelWidth = 90;
            this.ribbonTextBox_auto_align_mark_matchrate_2.Name = "ribbonTextBox_auto_align_mark_matchrate_2";
            this.ribbonTextBox_auto_align_mark_matchrate_2.Text = "MatchRate (2)";
            this.ribbonTextBox_auto_align_mark_matchrate_2.TextBoxText = "";
            this.ribbonTextBox_auto_align_mark_matchrate_2.TextBoxWidth = 40;
            // 
            // ribbonLabel_auto_align_empty_3
            // 
            this.ribbonLabel_auto_align_empty_3.Name = "ribbonLabel_auto_align_empty_3";
            // 
            // ribbonTextBox_auto_align_mark_matchrate_3
            // 
            this.ribbonTextBox_auto_align_mark_matchrate_3.LabelWidth = 90;
            this.ribbonTextBox_auto_align_mark_matchrate_3.Name = "ribbonTextBox_auto_align_mark_matchrate_3";
            this.ribbonTextBox_auto_align_mark_matchrate_3.Text = "MatchRate (3)";
            this.ribbonTextBox_auto_align_mark_matchrate_3.TextBoxText = "";
            this.ribbonTextBox_auto_align_mark_matchrate_3.TextBoxWidth = 40;
            // 
            // ribbonTextBox_auto_align_mark_matchrate_4
            // 
            this.ribbonTextBox_auto_align_mark_matchrate_4.LabelWidth = 90;
            this.ribbonTextBox_auto_align_mark_matchrate_4.Name = "ribbonTextBox_auto_align_mark_matchrate_4";
            this.ribbonTextBox_auto_align_mark_matchrate_4.Text = "MatchRate (4)";
            this.ribbonTextBox_auto_align_mark_matchrate_4.TextBoxText = "";
            this.ribbonTextBox_auto_align_mark_matchrate_4.TextBoxWidth = 40;
            // 
            // ribbonLabel_auto_align_empty_4
            // 
            this.ribbonLabel_auto_align_empty_4.Name = "ribbonLabel_auto_align_empty_4";
            // 
            // ribbonSeparator_auto_align_3
            // 
            this.ribbonSeparator_auto_align_3.Name = "ribbonSeparator_auto_align_3";
            // 
            // ribbonTextBox_auto_align_edge_level
            // 
            this.ribbonTextBox_auto_align_edge_level.LabelWidth = 50;
            this.ribbonTextBox_auto_align_edge_level.Name = "ribbonTextBox_auto_align_edge_level";
            this.ribbonTextBox_auto_align_edge_level.Text = "Level";
            this.ribbonTextBox_auto_align_edge_level.TextBoxText = "";
            this.ribbonTextBox_auto_align_edge_level.TextBoxWidth = 40;
            // 
            // ribbonTextBox_auto_align_edge_miss
            // 
            this.ribbonTextBox_auto_align_edge_miss.LabelWidth = 50;
            this.ribbonTextBox_auto_align_edge_miss.Name = "ribbonTextBox_auto_align_edge_miss";
            this.ribbonTextBox_auto_align_edge_miss.Text = "Miss";
            this.ribbonTextBox_auto_align_edge_miss.TextBoxText = "";
            this.ribbonTextBox_auto_align_edge_miss.TextBoxWidth = 40;
            // 
            // ribbonLabel_auto_align_empty_5
            // 
            this.ribbonLabel_auto_align_empty_5.Name = "ribbonLabel_auto_align_empty_5";
            // 
            // ribbonTab_vision
            // 
            this.ribbonTab_vision.Name = "ribbonTab_vision";
            this.ribbonTab_vision.Panels.Add(this.ribbonPanel_vision_recipe);
            this.ribbonTab_vision.Panels.Add(this.ribbonPanel_vision_camera);
            this.ribbonTab_vision.Panels.Add(this.ribbonPanel_vision_align);
            this.ribbonTab_vision.Panels.Add(this.ribbonPanel_vision_align_param);
            this.ribbonTab_vision.Panels.Add(this.ribbonPanel_vision_align_mark);
            this.ribbonTab_vision.Panels.Add(this.ribbonPanel_vision_align_edge);
            this.ribbonTab_vision.Text = "Vision";
            // 
            // ribbonPanel_vision_recipe
            // 
            this.ribbonPanel_vision_recipe.Items.Add(this.ribbonButton_vision_recipe_load);
            this.ribbonPanel_vision_recipe.Items.Add(this.ribbonButton_vision_recipe_save);
            this.ribbonPanel_vision_recipe.Items.Add(this.ribbonSeparator_vision_recipe_1);
            this.ribbonPanel_vision_recipe.Items.Add(this.ribbonTextBox_vision_recipe_num);
            this.ribbonPanel_vision_recipe.Items.Add(this.ribbonTextBox_vision_recipe_name);
            this.ribbonPanel_vision_recipe.Name = "ribbonPanel_vision_recipe";
            this.ribbonPanel_vision_recipe.Text = "Vision Recipe";
            // 
            // ribbonButton_vision_recipe_load
            // 
            this.ribbonButton_vision_recipe_load.Image = ((System.Drawing.Image)(resources.GetObject("ribbonButton_vision_recipe_load.Image")));
            this.ribbonButton_vision_recipe_load.LargeImage = ((System.Drawing.Image)(resources.GetObject("ribbonButton_vision_recipe_load.LargeImage")));
            this.ribbonButton_vision_recipe_load.MaxSizeMode = System.Windows.Forms.RibbonElementSizeMode.Medium;
            this.ribbonButton_vision_recipe_load.Name = "ribbonButton_vision_recipe_load";
            this.ribbonButton_vision_recipe_load.SmallImage = ((System.Drawing.Image)(resources.GetObject("ribbonButton_vision_recipe_load.SmallImage")));
            this.ribbonButton_vision_recipe_load.Text = "Load";
            this.ribbonButton_vision_recipe_load.Click += new System.EventHandler(this.ribbonButton_vision_recipe_load_Click);
            // 
            // ribbonButton_vision_recipe_save
            // 
            this.ribbonButton_vision_recipe_save.Image = ((System.Drawing.Image)(resources.GetObject("ribbonButton_vision_recipe_save.Image")));
            this.ribbonButton_vision_recipe_save.LargeImage = ((System.Drawing.Image)(resources.GetObject("ribbonButton_vision_recipe_save.LargeImage")));
            this.ribbonButton_vision_recipe_save.MaxSizeMode = System.Windows.Forms.RibbonElementSizeMode.Medium;
            this.ribbonButton_vision_recipe_save.Name = "ribbonButton_vision_recipe_save";
            this.ribbonButton_vision_recipe_save.SmallImage = ((System.Drawing.Image)(resources.GetObject("ribbonButton_vision_recipe_save.SmallImage")));
            this.ribbonButton_vision_recipe_save.Text = "Save";
            this.ribbonButton_vision_recipe_save.Click += new System.EventHandler(this.ribbonButton_vision_recipe_save_Click);
            // 
            // ribbonSeparator_vision_recipe_1
            // 
            this.ribbonSeparator_vision_recipe_1.Name = "ribbonSeparator_vision_recipe_1";
            // 
            // ribbonTextBox_vision_recipe_num
            // 
            this.ribbonTextBox_vision_recipe_num.LabelWidth = 50;
            this.ribbonTextBox_vision_recipe_num.Name = "ribbonTextBox_vision_recipe_num";
            this.ribbonTextBox_vision_recipe_num.Text = "Num";
            this.ribbonTextBox_vision_recipe_num.TextBoxText = "";
            this.ribbonTextBox_vision_recipe_num.TextBoxWidth = 20;
            // 
            // ribbonTextBox_vision_recipe_name
            // 
            this.ribbonTextBox_vision_recipe_name.LabelWidth = 50;
            this.ribbonTextBox_vision_recipe_name.Name = "ribbonTextBox_vision_recipe_name";
            this.ribbonTextBox_vision_recipe_name.Text = "Name";
            this.ribbonTextBox_vision_recipe_name.TextBoxText = "";
            this.ribbonTextBox_vision_recipe_name.TextBoxWidth = 120;
            // 
            // ribbonPanel_vision_camera
            // 
            this.ribbonPanel_vision_camera.Items.Add(this.ribbonButton_vision_camera_1);
            this.ribbonPanel_vision_camera.Items.Add(this.ribbonButton_vision_camera_2);
            this.ribbonPanel_vision_camera.Items.Add(this.ribbonSeparator_vision_camera_1);
            this.ribbonPanel_vision_camera.Items.Add(this.ribbonUpDown_vision_camera_exposure_1);
            this.ribbonPanel_vision_camera.Items.Add(this.ribbonUpDown_vision_camera_exposure_2);
            this.ribbonPanel_vision_camera.Items.Add(this.ribbonSeparator_vision_camera_2);
            this.ribbonPanel_vision_camera.Items.Add(this.ribbonUpDown_vision_camera_magni);
            this.ribbonPanel_vision_camera.Items.Add(this.ribbonLabel_vision_camera_empty_1);
            this.ribbonPanel_vision_camera.Name = "ribbonPanel_vision_camera";
            this.ribbonPanel_vision_camera.Text = "Vision Camera";
            // 
            // ribbonButton_vision_camera_1
            // 
            this.ribbonButton_vision_camera_1.Checked = true;
            this.ribbonButton_vision_camera_1.Image = ((System.Drawing.Image)(resources.GetObject("ribbonButton_vision_camera_1.Image")));
            this.ribbonButton_vision_camera_1.LargeImage = ((System.Drawing.Image)(resources.GetObject("ribbonButton_vision_camera_1.LargeImage")));
            this.ribbonButton_vision_camera_1.MaxSizeMode = System.Windows.Forms.RibbonElementSizeMode.Compact;
            this.ribbonButton_vision_camera_1.Name = "ribbonButton_vision_camera_1";
            this.ribbonButton_vision_camera_1.SmallImage = ((System.Drawing.Image)(resources.GetObject("ribbonButton_vision_camera_1.SmallImage")));
            this.ribbonButton_vision_camera_1.Click += new System.EventHandler(this.ribbonButton_vision_camera_1_Click);
            // 
            // ribbonButton_vision_camera_2
            // 
            this.ribbonButton_vision_camera_2.Image = ((System.Drawing.Image)(resources.GetObject("ribbonButton_vision_camera_2.Image")));
            this.ribbonButton_vision_camera_2.LargeImage = ((System.Drawing.Image)(resources.GetObject("ribbonButton_vision_camera_2.LargeImage")));
            this.ribbonButton_vision_camera_2.MaxSizeMode = System.Windows.Forms.RibbonElementSizeMode.Compact;
            this.ribbonButton_vision_camera_2.Name = "ribbonButton_vision_camera_2";
            this.ribbonButton_vision_camera_2.SmallImage = ((System.Drawing.Image)(resources.GetObject("ribbonButton_vision_camera_2.SmallImage")));
            this.ribbonButton_vision_camera_2.Click += new System.EventHandler(this.ribbonButton_vision_camera_2_Click);
            // 
            // ribbonSeparator_vision_camera_1
            // 
            this.ribbonSeparator_vision_camera_1.Name = "ribbonSeparator_vision_camera_1";
            // 
            // ribbonUpDown_vision_camera_exposure_1
            // 
            this.ribbonUpDown_vision_camera_exposure_1.Name = "ribbonUpDown_vision_camera_exposure_1";
            this.ribbonUpDown_vision_camera_exposure_1.Text = "Exposure(1)";
            this.ribbonUpDown_vision_camera_exposure_1.TextBoxText = "1";
            this.ribbonUpDown_vision_camera_exposure_1.TextBoxWidth = 30;
            this.ribbonUpDown_vision_camera_exposure_1.UpButtonClicked += new System.Windows.Forms.MouseEventHandler(this.ribbonUpDown_vision_camera_exposure_1_UpButtonClicked);
            this.ribbonUpDown_vision_camera_exposure_1.DownButtonClicked += new System.Windows.Forms.MouseEventHandler(this.ribbonUpDown_vision_camera_exposure_1_DownButtonClicked);
            // 
            // ribbonUpDown_vision_camera_exposure_2
            // 
            this.ribbonUpDown_vision_camera_exposure_2.Name = "ribbonUpDown_vision_camera_exposure_2";
            this.ribbonUpDown_vision_camera_exposure_2.Text = "Exposure(2)";
            this.ribbonUpDown_vision_camera_exposure_2.TextBoxText = "1";
            this.ribbonUpDown_vision_camera_exposure_2.TextBoxWidth = 30;
            this.ribbonUpDown_vision_camera_exposure_2.UpButtonClicked += new System.Windows.Forms.MouseEventHandler(this.ribbonUpDown_vision_camera_exposure_2_UpButtonClicked);
            this.ribbonUpDown_vision_camera_exposure_2.DownButtonClicked += new System.Windows.Forms.MouseEventHandler(this.ribbonUpDown_vision_camera_exposure_2_DownButtonClicked);
            // 
            // ribbonSeparator_vision_camera_2
            // 
            this.ribbonSeparator_vision_camera_2.Name = "ribbonSeparator_vision_camera_2";
            // 
            // ribbonUpDown_vision_camera_magni
            // 
            this.ribbonUpDown_vision_camera_magni.Name = "ribbonUpDown_vision_camera_magni";
            this.ribbonUpDown_vision_camera_magni.Text = "Magni";
            this.ribbonUpDown_vision_camera_magni.TextBoxText = "1";
            this.ribbonUpDown_vision_camera_magni.TextBoxWidth = 25;
            this.ribbonUpDown_vision_camera_magni.UpButtonClicked += new System.Windows.Forms.MouseEventHandler(this.ribbonUpDown_vision_camera_magni_UpButtonClicked);
            this.ribbonUpDown_vision_camera_magni.DownButtonClicked += new System.Windows.Forms.MouseEventHandler(this.ribbonUpDown_vision_camera_magni_DownButtonClicked);
            // 
            // ribbonLabel_vision_camera_empty_1
            // 
            this.ribbonLabel_vision_camera_empty_1.Name = "ribbonLabel_vision_camera_empty_1";
            // 
            // ribbonPanel_vision_align_mark
            // 
            this.ribbonPanel_vision_align_mark.Items.Add(this.ribbonButton_vision_align_mark_reg);
            this.ribbonPanel_vision_align_mark.Items.Add(this.ribbonSeparator_vision_align_mark_1);
            this.ribbonPanel_vision_align_mark.Items.Add(this.ribbonButton_vision_align_mark_detect);
            this.ribbonPanel_vision_align_mark.Items.Add(this.ribbonButton_vision_align_mark_clear);
            this.ribbonPanel_vision_align_mark.Items.Add(this.ribbonTextBox_vision_align_mark_matchrate);
            this.ribbonPanel_vision_align_mark.Items.Add(this.ribbonTextBox_vision_align_mark_detect_x);
            this.ribbonPanel_vision_align_mark.Items.Add(this.ribbonTextBox_vision_align_mark_detect_y);
            this.ribbonPanel_vision_align_mark.Name = "ribbonPanel_vision_align_mark";
            this.ribbonPanel_vision_align_mark.Text = "Alignment (Mark)";
            // 
            // ribbonButton_vision_align_mark_reg
            // 
            this.ribbonButton_vision_align_mark_reg.Image = ((System.Drawing.Image)(resources.GetObject("ribbonButton_vision_align_mark_reg.Image")));
            this.ribbonButton_vision_align_mark_reg.LargeImage = ((System.Drawing.Image)(resources.GetObject("ribbonButton_vision_align_mark_reg.LargeImage")));
            this.ribbonButton_vision_align_mark_reg.MaxSizeMode = System.Windows.Forms.RibbonElementSizeMode.Large;
            this.ribbonButton_vision_align_mark_reg.Name = "ribbonButton_vision_align_mark_reg";
            this.ribbonButton_vision_align_mark_reg.SmallImage = ((System.Drawing.Image)(resources.GetObject("ribbonButton_vision_align_mark_reg.SmallImage")));
            this.ribbonButton_vision_align_mark_reg.Text = "Align Mark";
            // 
            // ribbonSeparator_vision_align_mark_1
            // 
            this.ribbonSeparator_vision_align_mark_1.Name = "ribbonSeparator_vision_align_mark_1";
            // 
            // ribbonButton_vision_align_mark_detect
            // 
            this.ribbonButton_vision_align_mark_detect.Image = ((System.Drawing.Image)(resources.GetObject("ribbonButton_vision_align_mark_detect.Image")));
            this.ribbonButton_vision_align_mark_detect.LargeImage = ((System.Drawing.Image)(resources.GetObject("ribbonButton_vision_align_mark_detect.LargeImage")));
            this.ribbonButton_vision_align_mark_detect.MaxSizeMode = System.Windows.Forms.RibbonElementSizeMode.Large;
            this.ribbonButton_vision_align_mark_detect.Name = "ribbonButton_vision_align_mark_detect";
            this.ribbonButton_vision_align_mark_detect.SmallImage = ((System.Drawing.Image)(resources.GetObject("ribbonButton_vision_align_mark_detect.SmallImage")));
            this.ribbonButton_vision_align_mark_detect.Text = "  Detect";
            this.ribbonButton_vision_align_mark_detect.Click += new System.EventHandler(this.ribbonButton_vision_align_mark_detect_Click);
            // 
            // ribbonButton_vision_align_mark_clear
            // 
            this.ribbonButton_vision_align_mark_clear.Image = ((System.Drawing.Image)(resources.GetObject("ribbonButton_vision_align_mark_clear.Image")));
            this.ribbonButton_vision_align_mark_clear.LargeImage = ((System.Drawing.Image)(resources.GetObject("ribbonButton_vision_align_mark_clear.LargeImage")));
            this.ribbonButton_vision_align_mark_clear.MaxSizeMode = System.Windows.Forms.RibbonElementSizeMode.Large;
            this.ribbonButton_vision_align_mark_clear.Name = "ribbonButton_vision_align_mark_clear";
            this.ribbonButton_vision_align_mark_clear.SmallImage = ((System.Drawing.Image)(resources.GetObject("ribbonButton_vision_align_mark_clear.SmallImage")));
            this.ribbonButton_vision_align_mark_clear.Text = "  Clear";
            this.ribbonButton_vision_align_mark_clear.Click += new System.EventHandler(this.ribbonButton_vision_align_mark_clear_Click);
            // 
            // ribbonTextBox_vision_align_mark_matchrate
            // 
            this.ribbonTextBox_vision_align_mark_matchrate.LabelWidth = 90;
            this.ribbonTextBox_vision_align_mark_matchrate.Name = "ribbonTextBox_vision_align_mark_matchrate";
            this.ribbonTextBox_vision_align_mark_matchrate.Text = "MatchRate(%)";
            this.ribbonTextBox_vision_align_mark_matchrate.TextBoxText = "";
            this.ribbonTextBox_vision_align_mark_matchrate.TextBoxWidth = 50;
            // 
            // ribbonTextBox_vision_align_mark_detect_x
            // 
            this.ribbonTextBox_vision_align_mark_detect_x.LabelWidth = 90;
            this.ribbonTextBox_vision_align_mark_detect_x.Name = "ribbonTextBox_vision_align_mark_detect_x";
            this.ribbonTextBox_vision_align_mark_detect_x.Text = "X Point";
            this.ribbonTextBox_vision_align_mark_detect_x.TextBoxText = "";
            this.ribbonTextBox_vision_align_mark_detect_x.TextBoxWidth = 50;
            // 
            // ribbonTextBox_vision_align_mark_detect_y
            // 
            this.ribbonTextBox_vision_align_mark_detect_y.LabelWidth = 90;
            this.ribbonTextBox_vision_align_mark_detect_y.Name = "ribbonTextBox_vision_align_mark_detect_y";
            this.ribbonTextBox_vision_align_mark_detect_y.Text = "Y Point";
            this.ribbonTextBox_vision_align_mark_detect_y.TextBoxText = "";
            this.ribbonTextBox_vision_align_mark_detect_y.TextBoxWidth = 50;
            // 
            // ribbonButton_vision_cam_left
            // 
            this.ribbonButton_vision_cam_left.Image = ((System.Drawing.Image)(resources.GetObject("ribbonButton_vision_cam_left.Image")));
            this.ribbonButton_vision_cam_left.LargeImage = ((System.Drawing.Image)(resources.GetObject("ribbonButton_vision_cam_left.LargeImage")));
            this.ribbonButton_vision_cam_left.Name = "ribbonButton_vision_cam_left";
            this.ribbonButton_vision_cam_left.SmallImage = ((System.Drawing.Image)(resources.GetObject("ribbonButton_vision_cam_left.SmallImage")));
            this.ribbonButton_vision_cam_left.Text = "";
            // 
            // ribbonTab_laser
            // 
            this.ribbonTab_laser.Name = "ribbonTab_laser";
            this.ribbonTab_laser.Panels.Add(this.ribbonPanel_split);
            this.ribbonTab_laser.Panels.Add(this.ribbonPanel_laser_center);
            this.ribbonTab_laser.Panels.Add(this.ribbonPanel_motion_limit);
            this.ribbonTab_laser.Panels.Add(this.ribbonPanel_marking);
            this.ribbonTab_laser.Text = "Laser";
            // 
            // ribbon_menu
            // 
            this.ribbon_menu.Cursor = System.Windows.Forms.Cursors.Default;
            this.ribbon_menu.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ribbon_menu.Location = new System.Drawing.Point(0, 0);
            this.ribbon_menu.Minimized = false;
            this.ribbon_menu.Name = "ribbon_menu";
            // 
            // 
            // 
            this.ribbon_menu.OrbDropDown.BorderRoundness = 8;
            this.ribbon_menu.OrbDropDown.Location = new System.Drawing.Point(0, 0);
            this.ribbon_menu.OrbDropDown.Name = "";
            this.ribbon_menu.OrbDropDown.Size = new System.Drawing.Size(527, 72);
            this.ribbon_menu.OrbDropDown.TabIndex = 0;
            this.ribbon_menu.OrbVisible = false;
            this.ribbon_menu.RibbonTabFont = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ribbon_menu.Size = new System.Drawing.Size(1920, 140);
            this.ribbon_menu.TabIndex = 1;
            this.ribbon_menu.Tabs.Add(this.ribbonTab_laser);
            this.ribbon_menu.Tabs.Add(this.ribbonTab_vision);
            this.ribbon_menu.Tabs.Add(this.ribbonTab_auto);
            this.ribbon_menu.Tabs.Add(this.ribbonTab_fc);
            this.ribbon_menu.Tabs.Add(this.ribbonTab_log);
            this.ribbon_menu.Tabs.Add(this.ribbonTab_help);
            this.ribbon_menu.Text = "ribbon_menu";
            this.ribbon_menu.ActiveTabChanged += new System.EventHandler(this.ribbon_menu_ActiveTabChanged_1);
            // 
            // ribbonCheckBox_split_enable
            // 
            this.ribbonCheckBox_split_enable.Name = "ribbonCheckBox_split_enable";
            this.ribbonCheckBox_split_enable.Text = "Split Enable";
            this.ribbonCheckBox_split_enable.CheckBoxCheckChanged += new System.EventHandler(this.ribbonCheckBox_split_enable_CheckBoxCheckChanged);
            // 
            // ribbonSeparator_split_2
            // 
            this.ribbonSeparator_split_2.Name = "ribbonSeparator_split_2";
            // 
            // ribbonPanel_motion_limit
            // 
            this.ribbonPanel_motion_limit.Items.Add(this.ribbonTextBox_motion_limit_x_low);
            this.ribbonPanel_motion_limit.Items.Add(this.ribbonTextBox_motion_limit_x_high);
            this.ribbonPanel_motion_limit.Items.Add(this.ribbonSeparator_motion_limit_1);
            this.ribbonPanel_motion_limit.Items.Add(this.ribbonTextBox_motion_limit_y_low);
            this.ribbonPanel_motion_limit.Items.Add(this.ribbonTextBox_motion_limit_y_high);
            this.ribbonPanel_motion_limit.Name = "ribbonPanel_motion_limit";
            this.ribbonPanel_motion_limit.Text = "Motion Limit";
            // 
            // ribbonTextBox_motion_limit_x_low
            // 
            this.ribbonTextBox_motion_limit_x_low.LabelWidth = 80;
            this.ribbonTextBox_motion_limit_x_low.Name = "ribbonTextBox_motion_limit_x_low";
            this.ribbonTextBox_motion_limit_x_low.Text = "Unit X(Low)";
            this.ribbonTextBox_motion_limit_x_low.TextBoxText = "";
            this.ribbonTextBox_motion_limit_x_low.TextBoxWidth = 40;
            this.ribbonTextBox_motion_limit_x_low.TextBoxTextChanged += new System.EventHandler(this.ribbonTextBox_motion_limit_x_low_TextBoxTextChanged);
            // 
            // ribbonTextBox_motion_limit_x_high
            // 
            this.ribbonTextBox_motion_limit_x_high.LabelWidth = 80;
            this.ribbonTextBox_motion_limit_x_high.Name = "ribbonTextBox_motion_limit_x_high";
            this.ribbonTextBox_motion_limit_x_high.Text = "Unit X(High)";
            this.ribbonTextBox_motion_limit_x_high.TextBoxText = "";
            this.ribbonTextBox_motion_limit_x_high.TextBoxWidth = 40;
            this.ribbonTextBox_motion_limit_x_high.TextBoxTextChanged += new System.EventHandler(this.ribbonTextBox_motion_limit_x_high_TextBoxTextChanged);
            // 
            // ribbonSeparator_motion_limit_1
            // 
            this.ribbonSeparator_motion_limit_1.Name = "ribbonSeparator_motion_limit_1";
            // 
            // ribbonTextBox_motion_limit_y_low
            // 
            this.ribbonTextBox_motion_limit_y_low.LabelWidth = 80;
            this.ribbonTextBox_motion_limit_y_low.Name = "ribbonTextBox_motion_limit_y_low";
            this.ribbonTextBox_motion_limit_y_low.Text = "Unit Y(Low)";
            this.ribbonTextBox_motion_limit_y_low.TextBoxText = "";
            this.ribbonTextBox_motion_limit_y_low.TextBoxWidth = 40;
            this.ribbonTextBox_motion_limit_y_low.TextBoxTextChanged += new System.EventHandler(this.ribbonTextBox_motion_limit_y_low_TextBoxTextChanged);
            // 
            // ribbonTextBox_motion_limit_y_high
            // 
            this.ribbonTextBox_motion_limit_y_high.LabelWidth = 80;
            this.ribbonTextBox_motion_limit_y_high.Name = "ribbonTextBox_motion_limit_y_high";
            this.ribbonTextBox_motion_limit_y_high.Text = "Unit Y(High)";
            this.ribbonTextBox_motion_limit_y_high.TextBoxText = "";
            this.ribbonTextBox_motion_limit_y_high.TextBoxWidth = 40;
            this.ribbonTextBox_motion_limit_y_high.TextBoxTextChanged += new System.EventHandler(this.ribbonTextBox_motion_limit_y_high_TextBoxTextChanged);
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1920, 1040);
            this.Controls.Add(this.ribbon_menu);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.IsMdiContainer = true;
            this.KeyPreview = true;
            this.Name = "FormMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "FormMain";
            this.Load += new System.EventHandler(this.FormMain_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FormMain_KeyDown);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.RibbonPanel ribbonPanel_split;
        private System.Windows.Forms.RibbonPanel ribbonPanel_marking;
        private System.Windows.Forms.RibbonButton ribbonButton_marking_mark;
        public System.Windows.Forms.RibbonTextBox ribbonTextBox_laser_center_x;
        public System.Windows.Forms.RibbonTextBox ribbonTextBox_laser_center_y;
        public System.Windows.Forms.RibbonPanel ribbonPanel_laser_center;
        public System.Windows.Forms.RibbonCheckBox ribbonRadioBox_split_size;
        public System.Windows.Forms.RibbonCheckBox ribbonRadioBox_split_array;
        public System.Windows.Forms.RibbonTextBox ribbonTextBox_split_col;
        public System.Windows.Forms.RibbonTextBox ribbonTextBox_split_row;
        public System.Windows.Forms.RibbonCheckBox ribbonCheckBox_split_apply;
        public System.Windows.Forms.RibbonButton ribbonButton_split_save;
        public System.Windows.Forms.RibbonCheckBox ribbonCheckBox_marking_guide;
        public System.Windows.Forms.RibbonCheckBox ribbonCheckBox_marking_align;
        private System.Windows.Forms.RibbonButton ribbonButton_vision_cam_right;
        private System.Windows.Forms.RibbonPanel ribbonPanel_vision_align;
        private System.Windows.Forms.RibbonPanel ribbonPanel_vision_align_param;
        private System.Windows.Forms.RibbonButton ribbonButton_vision_align_1;
        private System.Windows.Forms.RibbonButton ribbonButton_vision_align_2;
        private System.Windows.Forms.RibbonButton ribbonButton_vision_align_3;
        private System.Windows.Forms.RibbonButton ribbonButton_vision_align_4;
        private System.Windows.Forms.RibbonPanel ribbonPanel_vision_align_edge;
        private System.Windows.Forms.RibbonTab ribbonTab_help;
        private System.Windows.Forms.RibbonTab ribbonTab_log;
        private System.Windows.Forms.RibbonPanel ribbonPanel_settings;
        private System.Windows.Forms.RibbonButton ribbonButton_setting;
        private System.Windows.Forms.RibbonTab ribbonTab_fc;
        private System.Windows.Forms.RibbonPanel ribbonPanel_fc;
        private System.Windows.Forms.RibbonTab ribbonTab_auto;
        private System.Windows.Forms.RibbonPanel ribbonPanel_autorun;
        private System.Windows.Forms.RibbonButton ribbonButton_autorun_start;
        private System.Windows.Forms.RibbonTab ribbonTab_vision;
        private System.Windows.Forms.RibbonButton ribbonButton_vision_cam_left;
        public System.Windows.Forms.RibbonTab ribbonTab_laser;
        private System.Windows.Forms.RibbonPanel ribbonPanel_split_drawing;
        public System.Windows.Forms.Ribbon ribbon_menu;
        private System.Windows.Forms.RibbonPanel ribbonPanel_vision_align_mark;
        private System.Windows.Forms.RibbonButton ribbonButton_vision_align_mark_detect;
        private System.Windows.Forms.RibbonButton ribbonButton_vision_align_mark_clear;
        private System.Windows.Forms.RibbonSeparator ribbonSeparator_vision_align_mark_1;
        private System.Windows.Forms.RibbonPanel ribbonPanel_vision_camera;
        private System.Windows.Forms.RibbonButton ribbonButton_vision_camera_1;
        private System.Windows.Forms.RibbonButton ribbonButton_vision_camera_2;
        private System.Windows.Forms.RibbonSeparator ribbonSeparator_vision_camera_1;
        private System.Windows.Forms.RibbonUpDown ribbonUpDown_vision_camera_exposure_1;
        private System.Windows.Forms.RibbonUpDown ribbonUpDown_vision_camera_exposure_2;
        private System.Windows.Forms.RibbonSeparator ribbonSeparator_split_1;
        private System.Windows.Forms.RibbonSeparator ribbonSeparator_vision_align_param_1;
        private System.Windows.Forms.RibbonSeparator ribbonSeparator_vision_align_edge_1;
        private System.Windows.Forms.RibbonSeparator ribbonSeparator_vision_align_edge_2;
        private System.Windows.Forms.RibbonLabel ribbonLabel_vision_align_edge_empty_1;
        private System.Windows.Forms.RibbonLabel ribbonLabel_vision_align_edge_wave;
        private System.Windows.Forms.RibbonLabel ribbonLabel_vision_align_edge_empty_2;
        private System.Windows.Forms.RibbonLabel ribbonLabel_vision_align_edge_empty_3;
        private System.Windows.Forms.RibbonLabel ribbonLabel_vision_align_edge_empty_4;
        private System.Windows.Forms.RibbonSeparator ribbonSeparator_vision_align_param_2;
        private System.Windows.Forms.RibbonButton ribbonButton_vision_align_param_modify;
        private System.Windows.Forms.RibbonButton ribbonButton_vision_align_param_apply;
        private System.Windows.Forms.RibbonButton ribbonButton_vision_align_param_cancel;
        private System.Windows.Forms.RibbonSeparator ribbonSeparator_vision_align_param_3;
        private System.Windows.Forms.RibbonPanel ribbonPanel_auto_vision_recipe;
        public System.Windows.Forms.RibbonTextBox ribbonTextBox_vision_align_param_unitx;
        public System.Windows.Forms.RibbonTextBox ribbonTextBox_vision_align_param_unity;
        public System.Windows.Forms.RibbonTextBox ribbonTextBox_vision_align_param_distance;
        public System.Windows.Forms.RibbonCheckBox ribbonRadioBox_vision_align_edge_upward;
        public System.Windows.Forms.RibbonCheckBox ribbonRadioBox_vision_align_edge_downward;
        public System.Windows.Forms.RibbonUpDown ribbonUpDown_vision_align_edge_precision;
        public System.Windows.Forms.RibbonTextBox ribbonTextBox_vision_align_mark_matchrate;
        public System.Windows.Forms.RibbonTextBox ribbonTextBox_vision_align_mark_detect_x;
        public System.Windows.Forms.RibbonTextBox ribbonTextBox_vision_align_mark_detect_y;
        public System.Windows.Forms.RibbonTextBox ribbonTextBox_vision_align_param_judge_x;
        public System.Windows.Forms.RibbonTextBox ribbonTextBox_vision_align_param_judge_y;
        public System.Windows.Forms.RibbonTextBox ribbonTextBox_vision_align_param_judge_t;
        public System.Windows.Forms.RibbonTextBox ribbonTextBox_vision_align_edge_preprocess_binary;
        public System.Windows.Forms.RibbonTextBox ribbonTextBox_vision_align_edge_preprocess_morp_open;
        public System.Windows.Forms.RibbonTextBox ribbonTextBox_vision_align_edge_preprocess_morp_close;
        public System.Windows.Forms.RibbonTextBox ribbonTextBox_vision_align_edge_roi_start_x;
        public System.Windows.Forms.RibbonTextBox ribbonTextBox_vision_align_edge_roi_end_x;
        public System.Windows.Forms.RibbonTextBox ribbonTextBox_vision_align_edge_roi_start_y;
        public System.Windows.Forms.RibbonTextBox ribbonTextBox_vision_align_edge_roi_end_y;
        public System.Windows.Forms.RibbonCheckBox ribbonRadioBox_vision_align_param_mark;
        public System.Windows.Forms.RibbonCheckBox ribbonRadioBox_vision_align_param_edge;
        public System.Windows.Forms.RibbonTextBox ribbonTextBox_vision_align_edge_level;
        public System.Windows.Forms.RibbonTextBox ribbonTextBox_vision_align_edge_miss;
        private System.Windows.Forms.RibbonSeparator ribbonSeparator_vision_align_edge_3;
        private System.Windows.Forms.RibbonLabel ribbonLabel_vision_align_edge_empty_5;
        public System.Windows.Forms.RibbonButton ribbonButton_vision_align_mark_reg;
        private System.Windows.Forms.RibbonPanel ribbonPanel_vision_recipe;
        private System.Windows.Forms.RibbonButton ribbonButton_vision_recipe_load;
        private System.Windows.Forms.RibbonButton ribbonButton_vision_recipe_save;
        private System.Windows.Forms.RibbonSeparator ribbonSeparator_vision_recipe_1;
        public System.Windows.Forms.RibbonTextBox ribbonTextBox_vision_recipe_num;
        public System.Windows.Forms.RibbonTextBox ribbonTextBox_vision_recipe_name;
        private System.Windows.Forms.RibbonSeparator ribbonSeparator_vision_camera_2;
        private System.Windows.Forms.RibbonLabel ribbonLabel_vision_camera_empty_1;
        public System.Windows.Forms.RibbonUpDown ribbonUpDown_vision_camera_magni;
        private System.Windows.Forms.RibbonPanel ribbonPanel_auto_vision_position;
        private System.Windows.Forms.RibbonLabel ribbonLabel_auto_vision_position_empty_1;
        private System.Windows.Forms.RibbonPanel ribbonPanel_auto_laser_position;
        private System.Windows.Forms.RibbonPanel ribbonPanel_auto_align;
        private System.Windows.Forms.RibbonLabel ribbonLabel_auto_vision_position_empty_2;
        private System.Windows.Forms.RibbonLabel ribbonLabel_auto_vision_position_empty_3;
        private System.Windows.Forms.RibbonLabel ribbonLabel_auto_vision_position_empty_4;
        private System.Windows.Forms.RibbonLabel ribbonLabel_auto_laser_position_empty_1;
        private System.Windows.Forms.RibbonSeparator ribbonSeparator_auto_align_1;
        private System.Windows.Forms.RibbonLabel ribbonLabel_auto_align_empty_1;
        private System.Windows.Forms.RibbonLabel ribbonLabel_auto_align_empty_2;
        private System.Windows.Forms.RibbonSeparator ribbonSeparator_auto_align_2;
        private System.Windows.Forms.RibbonLabel ribbonLabel_auto_align_empty_3;
        private System.Windows.Forms.RibbonLabel ribbonLabel_auto_align_empty_4;
        private System.Windows.Forms.RibbonSeparator ribbonSeparator_auto_align_3;
        private System.Windows.Forms.RibbonLabel ribbonLabel_auto_align_empty_5;
        private System.Windows.Forms.RibbonButton ribbonButton_autorun_stop;
        public System.Windows.Forms.RibbonTextBox ribbonTextBox_auto_vision_recipe_num;
        public System.Windows.Forms.RibbonTextBox ribbonTextBox_auto_vision_recipe_name;
        public System.Windows.Forms.RibbonTextBox ribbonTextBox_auto_vision_position_x_1;
        public System.Windows.Forms.RibbonTextBox ribbonTextBox_auto_vision_position_y_1;
        public System.Windows.Forms.RibbonTextBox ribbonTextBox_auto_vision_position_x_2;
        public System.Windows.Forms.RibbonTextBox ribbonTextBox_auto_vision_position_y_2;
        public System.Windows.Forms.RibbonTextBox ribbonTextBox_auto_vision_position_x_3;
        public System.Windows.Forms.RibbonTextBox ribbonTextBox_auto_vision_position_y_3;
        public System.Windows.Forms.RibbonTextBox ribbonTextBox_auto_vision_position_x_4;
        public System.Windows.Forms.RibbonTextBox ribbonTextBox_auto_vision_position_y_4;
        public System.Windows.Forms.RibbonTextBox ribbonTextBox_auto_laser_position_x;
        public System.Windows.Forms.RibbonTextBox ribbonTextBox_auto_laser_position_y;
        public System.Windows.Forms.RibbonCheckBox ribbonRadioBox_auto_align_mark;
        public System.Windows.Forms.RibbonCheckBox ribbonRadioBox_auto_align_edge;
        public System.Windows.Forms.RibbonTextBox ribbonTextBox_auto_align_distance;
        public System.Windows.Forms.RibbonTextBox ribbonTextBox_auto_align_range_x;
        public System.Windows.Forms.RibbonTextBox ribbonTextBox_auto_align_range_y;
        public System.Windows.Forms.RibbonTextBox ribbonTextBox_auto_align_range_t;
        public System.Windows.Forms.RibbonTextBox ribbonTextBox_auto_align_mark_matchrate_1;
        public System.Windows.Forms.RibbonTextBox ribbonTextBox_auto_align_mark_matchrate_2;
        public System.Windows.Forms.RibbonTextBox ribbonTextBox_auto_align_mark_matchrate_3;
        public System.Windows.Forms.RibbonTextBox ribbonTextBox_auto_align_mark_matchrate_4;
        public System.Windows.Forms.RibbonTextBox ribbonTextBox_auto_align_edge_level;
        public System.Windows.Forms.RibbonTextBox ribbonTextBox_auto_align_edge_miss;
        private System.Windows.Forms.RibbonPanel ribbonPanel_fc_recipe;
        private System.Windows.Forms.RibbonButton ribbonButton_fc_recipe_load;
        private System.Windows.Forms.RibbonButton ribbonButton_fc_recipe_save;
        private System.Windows.Forms.RibbonSeparator ribbonSeparator_fc_recipe_1;
        private System.Windows.Forms.RibbonPanel ribbonPanel_fc_camera;
        private System.Windows.Forms.RibbonPanel ribbonPanel_fc_param;
        private System.Windows.Forms.RibbonButton ribbonButton_fc_param_modify;
        private System.Windows.Forms.RibbonButton ribbonButton_fc_param_apply;
        private System.Windows.Forms.RibbonButton ribbonButton_fc_param_cancel;
        private System.Windows.Forms.RibbonSeparator ribbonSeparator_fc_param_1;
        private System.Windows.Forms.RibbonSeparator ribbonSeparator_fc_param_2;
        private System.Windows.Forms.RibbonLabel ribbonLabel_fc_param_empty_1;
        private System.Windows.Forms.RibbonLabel ribbonLabel_fc_param_empty_2;
        private System.Windows.Forms.RibbonPanel ribbonPanel_fc_detect;
        private System.Windows.Forms.RibbonButton ribbonButton_fc_detect_mark;
        private System.Windows.Forms.RibbonButton ribbonButton_fc_detect_clear;
        private System.Windows.Forms.RibbonSeparator ribbonSeparator_fc_detect_1;
        public System.Windows.Forms.RibbonTextBox ribbonTextBox_fc_recipe_num;
        public System.Windows.Forms.RibbonTextBox ribbonTextBox_fc_recipe_name;
        public System.Windows.Forms.RibbonUpDown ribbonUpDown_fc_camera_magni;
        public System.Windows.Forms.RibbonTextBox ribbonTextBox_fc_param_gain;
        public System.Windows.Forms.RibbonTextBox ribbonTextBox_fc_param_newcal;
        public System.Windows.Forms.RibbonTextBox ribbonTextBox_fc_param_point;
        public System.Windows.Forms.RibbonTextBox ribbonTextBox_fc_param_length;
        public System.Windows.Forms.RibbonTextBox ribbonTextBox_fc_param_oldctfile;
        public System.Windows.Forms.RibbonTextBox ribbonTextBox_fc_param_newctfile;
        public System.Windows.Forms.RibbonButton ribbonButton_fc_param_oldctfile;
        public System.Windows.Forms.RibbonTextBox ribbonTextBox_fc_detect_matchrate;
        public System.Windows.Forms.RibbonTextBox ribbonTextBox_fc_detect_point_x;
        public System.Windows.Forms.RibbonTextBox ribbonTextBox_fc_detect_point_y;
        private System.Windows.Forms.RibbonSeparator ribbonSeparator_fc_detect_2;
        private System.Windows.Forms.RibbonButton ribbonButton_fc_detect_simulation;
        private System.Windows.Forms.RibbonButton ribbonButton_fc_detect_simulation_clear;
        private System.Windows.Forms.RibbonPanel ribbonPanel_log_data;
        private System.Windows.Forms.RibbonButton ribbonButton_log_data_load;
        private System.Windows.Forms.RibbonSeparator ribbonSeparator_log_data_1;
        private System.Windows.Forms.RibbonPanel ribbonPanel_log_setting;
        public System.Windows.Forms.RibbonTextBox ribbonTextBox_log_data_name;
        public System.Windows.Forms.RibbonCheckBox ribbonCheckBox_log_setting_1;
        public System.Windows.Forms.RibbonCheckBox ribbonCheckBox_log_setting_2;
        public System.Windows.Forms.RibbonCheckBox ribbonCheckBox_log_setting_3;
        public System.Windows.Forms.RibbonCheckBox ribbonCheckBox_log_setting_4;
        public System.Windows.Forms.RibbonCheckBox ribbonCheckBox_log_setting_5;
        public System.Windows.Forms.RibbonCheckBox ribbonCheckBox_log_setting_6;
        public System.Windows.Forms.RibbonCheckBox ribbonCheckBox_log_setting_7;
        public System.Windows.Forms.RibbonCheckBox ribbonCheckBox_log_setting_8;
        public System.Windows.Forms.RibbonCheckBox ribbonCheckBox_log_setting_9;
        public System.Windows.Forms.RibbonCheckBox ribbonCheckBox_log_setting_10;
        public System.Windows.Forms.RibbonCheckBox ribbonCheckBox_log_setting_11;
        public System.Windows.Forms.RibbonCheckBox ribbonCheckBox_log_setting_12;
        private System.Windows.Forms.RibbonCheckBox ribbonCheckBox_log_setting_all;
        private System.Windows.Forms.RibbonSeparator ribbonSeparator_log_setting_1;
        private System.Windows.Forms.RibbonPanel ribbonPanel_help;
        private System.Windows.Forms.RibbonButton ribbonButton_help_contact;
        private System.Windows.Forms.RibbonSeparator ribbonSeparator_fc_param_3;
        public System.Windows.Forms.RibbonTextBox ribbonTextBox_fc_param_center_x;
        public System.Windows.Forms.RibbonTextBox ribbonTextBox_fc_param_center_y;
        public System.Windows.Forms.RibbonButton ribbonButton_fc_stop;
        public System.Windows.Forms.RibbonButton ribbonButton_fc;
        private System.Windows.Forms.RibbonSeparator ribbonSeparator_split_2;
        public System.Windows.Forms.RibbonCheckBox ribbonCheckBox_split_enable;
        private System.Windows.Forms.RibbonPanel ribbonPanel_motion_limit;
        private System.Windows.Forms.RibbonTextBox ribbonTextBox_motion_limit_x_low;
        private System.Windows.Forms.RibbonTextBox ribbonTextBox_motion_limit_x_high;
        private System.Windows.Forms.RibbonSeparator ribbonSeparator_motion_limit_1;
        private System.Windows.Forms.RibbonTextBox ribbonTextBox_motion_limit_y_low;
        private System.Windows.Forms.RibbonTextBox ribbonTextBox_motion_limit_y_high;
    }
}

