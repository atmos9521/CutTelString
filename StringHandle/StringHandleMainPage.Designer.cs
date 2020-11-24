namespace StringHandle
{
    partial class StringHandleMainPage
    {
        /// <summary>
        /// 設計工具所需的變數。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清除任何使用中的資源。
        /// </summary>
        /// <param name="disposing">如果應該處置 Managed 資源則為 true，否則為 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 設計工具產生的程式碼

        /// <summary>
        /// 此為設計工具支援所需的方法 - 請勿使用程式碼編輯器修改
        /// 這個方法的內容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.Occ_cbx = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.DataType_cbx = new System.Windows.Forms.ComboBox();
            this.StartToRead_btn = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.SheetName_cbx = new System.Windows.Forms.ComboBox();
            this.SheetName_lbl = new System.Windows.Forms.Label();
            this.SheetName_txt = new System.Windows.Forms.TextBox();
            this.ExcelDataType_btn = new System.Windows.Forms.Button();
            this.Occurse_ckb = new System.Windows.Forms.CheckBox();
            this.OpenTelString_btn = new System.Windows.Forms.Button();
            this.dataTypeSit_lbl = new System.Windows.Forms.Label();
            this.Occurse_lbl = new System.Windows.Forms.Label();
            this.Occursesit_txt = new System.Windows.Forms.TextBox();
            this.DataTypeSiteName_txt = new System.Windows.Forms.TextBox();
            this.Occursesit_counter = new System.Windows.Forms.NumericUpDown();
            this.dataTypesit_counter = new System.Windows.Forms.NumericUpDown();
            this.Reflash_btn = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.EndStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.telString_txt = new System.Windows.Forms.TextBox();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.ExcelName_lbl = new System.Windows.Forms.Label();
            this.TelName_lbl = new System.Windows.Forms.Label();
            this.OpenCompareTelString_btn = new System.Windows.Forms.Button();
            this.CompareReflash_btn = new System.Windows.Forms.Button();
            this.CompareName_lbl = new System.Windows.Forms.Label();
            this.ExcelPath_lbl = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.txtPath_lbl = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.ReadExcelTelName_txt = new System.Windows.Forms.TextBox();
            this.ByteTransfer = new System.Windows.Forms.Button();
            this.openExcel_btn = new System.Windows.Forms.Button();
            this.TelGroup = new System.Windows.Forms.GroupBox();
            this.ShowTelString_btn = new System.Windows.Forms.Button();
            this.ComparetelString_txt = new System.Windows.Forms.TextBox();
            this.CompareTelGroup = new System.Windows.Forms.GroupBox();
            this.ShowCompareTelString_btn = new System.Windows.Forms.Button();
            this.Compare_ckb = new System.Windows.Forms.CheckBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.ReadExcelTelName_cbx = new System.Windows.Forms.ComboBox();
            this.ComparetxtPath_lbl = new System.Windows.Forms.Label();
            this.CompareResult_lbl = new System.Windows.Forms.Label();
            this.ReturnExcel = new System.Windows.Forms.Button();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.DeleteItem_cbx = new System.Windows.Forms.ComboBox();
            this.DeleteIitemExcel_btn = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Occursesit_counter)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataTypesit_counter)).BeginInit();
            this.statusStrip1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.TelGroup.SuspendLayout();
            this.CompareTelGroup.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowDrop = true;
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(429, 56);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 27;
            this.dataGridView1.Size = new System.Drawing.Size(588, 544);
            this.dataGridView1.TabIndex = 1;
            this.dataGridView1.DragOver += new System.Windows.Forms.DragEventHandler(this.dataGridView1_DragOver);
            // 
            // Occ_cbx
            // 
            this.Occ_cbx.FormattingEnabled = true;
            this.Occ_cbx.Location = new System.Drawing.Point(143, 210);
            this.Occ_cbx.Name = "Occ_cbx";
            this.Occ_cbx.Size = new System.Drawing.Size(202, 33);
            this.Occ_cbx.TabIndex = 105;
            this.Occ_cbx.Visible = false;
            this.Occ_cbx.SelectedIndexChanged += new System.EventHandler(this.Occ_cbx_SelectedIndexChanged);
            this.Occ_cbx.TextChanged += new System.EventHandler(this.Occ_cbx_TextChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label4.Location = new System.Drawing.Point(352, 218);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(32, 25);
            this.label4.TabIndex = 21;
            this.label4.Text = "欄";
            this.toolTip1.SetToolTip(this.label4, "從左算起第幾欄");
            this.label4.Visible = false;
            // 
            // DataType_cbx
            // 
            this.DataType_cbx.FormattingEnabled = true;
            this.DataType_cbx.Location = new System.Drawing.Point(144, 139);
            this.DataType_cbx.Name = "DataType_cbx";
            this.DataType_cbx.Size = new System.Drawing.Size(202, 33);
            this.DataType_cbx.TabIndex = 104;
            this.DataType_cbx.SelectedIndexChanged += new System.EventHandler(this.DataType_cbx_SelectedIndexChanged);
            this.DataType_cbx.TextChanged += new System.EventHandler(this.DataType_cbx_TextChanged);
            // 
            // StartToRead_btn
            // 
            this.StartToRead_btn.Enabled = false;
            this.StartToRead_btn.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.StartToRead_btn.Location = new System.Drawing.Point(11, 254);
            this.StartToRead_btn.Name = "StartToRead_btn";
            this.StartToRead_btn.Size = new System.Drawing.Size(334, 60);
            this.StartToRead_btn.TabIndex = 18;
            this.StartToRead_btn.Text = "開始比對";
            this.StartToRead_btn.UseVisualStyleBackColor = true;
            this.StartToRead_btn.Click += new System.EventHandler(this.StartToRead_btn_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label1.Location = new System.Drawing.Point(352, 142);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(32, 25);
            this.label1.TabIndex = 20;
            this.label1.Text = "欄";
            this.toolTip1.SetToolTip(this.label1, "從左算起第幾欄");
            // 
            // SheetName_cbx
            // 
            this.SheetName_cbx.FormattingEnabled = true;
            this.SheetName_cbx.Location = new System.Drawing.Point(9, 97);
            this.SheetName_cbx.Name = "SheetName_cbx";
            this.SheetName_cbx.Size = new System.Drawing.Size(381, 33);
            this.SheetName_cbx.TabIndex = 16;
            this.SheetName_cbx.SelectedIndexChanged += new System.EventHandler(this.SheetName_cbx_SelectedIndexChanged);
            // 
            // SheetName_lbl
            // 
            this.SheetName_lbl.AutoSize = true;
            this.SheetName_lbl.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.SheetName_lbl.Location = new System.Drawing.Point(6, 66);
            this.SheetName_lbl.Name = "SheetName_lbl";
            this.SheetName_lbl.Size = new System.Drawing.Size(146, 25);
            this.SheetName_lbl.TabIndex = 13;
            this.SheetName_lbl.Text = "選擇Excel頁籤:";
            // 
            // SheetName_txt
            // 
            this.SheetName_txt.Enabled = false;
            this.SheetName_txt.Location = new System.Drawing.Point(9, 29);
            this.SheetName_txt.Name = "SheetName_txt";
            this.SheetName_txt.Size = new System.Drawing.Size(221, 34);
            this.SheetName_txt.TabIndex = 12;
            this.SheetName_txt.Visible = false;
            this.SheetName_txt.TextChanged += new System.EventHandler(this.SheetName_txt_TextChanged);
            // 
            // ExcelDataType_btn
            // 
            this.ExcelDataType_btn.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.ExcelDataType_btn.Location = new System.Drawing.Point(236, 29);
            this.ExcelDataType_btn.Name = "ExcelDataType_btn";
            this.ExcelDataType_btn.Size = new System.Drawing.Size(154, 62);
            this.ExcelDataType_btn.TabIndex = 11;
            this.ExcelDataType_btn.Text = "讀取Excel";
            this.toolTip1.SetToolTip(this.ExcelDataType_btn, "開啟需要處理的檔案");
            this.ExcelDataType_btn.UseVisualStyleBackColor = true;
            this.ExcelDataType_btn.Click += new System.EventHandler(this.ExcelDataType_btn_Click);
            // 
            // Occurse_ckb
            // 
            this.Occurse_ckb.AutoSize = true;
            this.Occurse_ckb.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.Occurse_ckb.Location = new System.Drawing.Point(6, 178);
            this.Occurse_ckb.Name = "Occurse_ckb";
            this.Occurse_ckb.Size = new System.Drawing.Size(154, 29);
            this.Occurse_ckb.TabIndex = 10;
            this.Occurse_ckb.Text = "有無重複電文";
            this.Occurse_ckb.UseVisualStyleBackColor = true;
            this.Occurse_ckb.CheckedChanged += new System.EventHandler(this.Occurse_ckb_CheckedChanged);
            // 
            // OpenTelString_btn
            // 
            this.OpenTelString_btn.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.OpenTelString_btn.Location = new System.Drawing.Point(200, 33);
            this.OpenTelString_btn.Name = "OpenTelString_btn";
            this.OpenTelString_btn.Size = new System.Drawing.Size(175, 113);
            this.OpenTelString_btn.TabIndex = 6;
            this.OpenTelString_btn.Text = "開啟電文檔";
            this.toolTip1.SetToolTip(this.OpenTelString_btn, "開啟需要處理的檔案");
            this.OpenTelString_btn.UseVisualStyleBackColor = true;
            this.OpenTelString_btn.Click += new System.EventHandler(this.openTelString);
            // 
            // dataTypeSit_lbl
            // 
            this.dataTypeSit_lbl.AutoSize = true;
            this.dataTypeSit_lbl.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.dataTypeSit_lbl.Location = new System.Drawing.Point(6, 139);
            this.dataTypeSit_lbl.Name = "dataTypeSit_lbl";
            this.dataTypeSit_lbl.Size = new System.Drawing.Size(132, 25);
            this.dataTypeSit_lbl.TabIndex = 5;
            this.dataTypeSit_lbl.Text = "資料型態欄位";
            this.toolTip1.SetToolTip(this.dataTypeSit_lbl, "從左算起第幾欄");
            // 
            // Occurse_lbl
            // 
            this.Occurse_lbl.AutoSize = true;
            this.Occurse_lbl.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.Occurse_lbl.Location = new System.Drawing.Point(4, 210);
            this.Occurse_lbl.Name = "Occurse_lbl";
            this.Occurse_lbl.Size = new System.Drawing.Size(132, 25);
            this.Occurse_lbl.TabIndex = 9;
            this.Occurse_lbl.Text = "重複次數欄位";
            this.toolTip1.SetToolTip(this.Occurse_lbl, "從左算起第幾欄");
            this.Occurse_lbl.Visible = false;
            // 
            // Occursesit_txt
            // 
            this.Occursesit_txt.Location = new System.Drawing.Point(98, 46);
            this.Occursesit_txt.Name = "Occursesit_txt";
            this.Occursesit_txt.Size = new System.Drawing.Size(79, 25);
            this.Occursesit_txt.TabIndex = 19;
            this.Occursesit_txt.Text = "A";
            this.Occursesit_txt.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.Occursesit_txt.WordWrap = false;
            this.Occursesit_txt.TextChanged += new System.EventHandler(this.Occursesit_txt_TextChanged);
            // 
            // DataTypeSiteName_txt
            // 
            this.DataTypeSiteName_txt.Location = new System.Drawing.Point(97, 14);
            this.DataTypeSiteName_txt.Name = "DataTypeSiteName_txt";
            this.DataTypeSiteName_txt.Size = new System.Drawing.Size(82, 25);
            this.DataTypeSiteName_txt.TabIndex = 14;
            this.DataTypeSiteName_txt.Text = "A";
            this.DataTypeSiteName_txt.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.DataTypeSiteName_txt.TextChanged += new System.EventHandler(this.DataTypeSiteName_txt_TextChanged);
            // 
            // Occursesit_counter
            // 
            this.Occursesit_counter.Location = new System.Drawing.Point(16, 46);
            this.Occursesit_counter.Name = "Occursesit_counter";
            this.Occursesit_counter.Size = new System.Drawing.Size(76, 25);
            this.Occursesit_counter.TabIndex = 8;
            this.Occursesit_counter.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.toolTip1.SetToolTip(this.Occursesit_counter, "從左算起第幾欄");
            this.Occursesit_counter.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.Occursesit_counter.ValueChanged += new System.EventHandler(this.Occursesit_counter_ValueChanged);
            // 
            // dataTypesit_counter
            // 
            this.dataTypesit_counter.Location = new System.Drawing.Point(16, 15);
            this.dataTypesit_counter.Name = "dataTypesit_counter";
            this.dataTypesit_counter.Size = new System.Drawing.Size(75, 25);
            this.dataTypesit_counter.TabIndex = 4;
            this.dataTypesit_counter.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.toolTip1.SetToolTip(this.dataTypesit_counter, "從左算起第幾欄");
            this.dataTypesit_counter.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.dataTypesit_counter.ValueChanged += new System.EventHandler(this.dataTypesit_counter_ValueChanged);
            // 
            // Reflash_btn
            // 
            this.Reflash_btn.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.Reflash_btn.Location = new System.Drawing.Point(6, 95);
            this.Reflash_btn.Name = "Reflash_btn";
            this.Reflash_btn.Size = new System.Drawing.Size(173, 51);
            this.Reflash_btn.TabIndex = 7;
            this.Reflash_btn.Text = "清除電文";
            this.toolTip1.SetToolTip(this.Reflash_btn, "開啟需要處理的檔案");
            this.Reflash_btn.UseVisualStyleBackColor = true;
            this.Reflash_btn.Click += new System.EventHandler(this.Reflash_btn_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // statusStrip1
            // 
            this.statusStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.EndStatus});
            this.statusStrip1.Location = new System.Drawing.Point(0, 712);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.statusStrip1.Size = new System.Drawing.Size(1244, 30);
            this.statusStrip1.TabIndex = 6;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // EndStatus
            // 
            this.EndStatus.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.EndStatus.Name = "EndStatus";
            this.EndStatus.Size = new System.Drawing.Size(92, 25);
            this.EndStatus.Text = "處理狀態";
            // 
            // telString_txt
            // 
            this.telString_txt.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.telString_txt.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.telString_txt.Location = new System.Drawing.Point(203, 33);
            this.telString_txt.Multiline = true;
            this.telString_txt.Name = "telString_txt";
            this.telString_txt.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.telString_txt.Size = new System.Drawing.Size(193, 113);
            this.telString_txt.TabIndex = 7;
            this.telString_txt.Visible = false;
            this.telString_txt.WordWrap = false;
            this.telString_txt.TextChanged += new System.EventHandler(this.telString_txt_TextChanged);
            this.telString_txt.Leave += new System.EventHandler(this.telString_txt_TextLeave);
            // 
            // ExcelName_lbl
            // 
            this.ExcelName_lbl.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.ExcelName_lbl.AutoSize = true;
            this.ExcelName_lbl.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.ExcelName_lbl.Location = new System.Drawing.Point(426, 603);
            this.ExcelName_lbl.Name = "ExcelName_lbl";
            this.ExcelName_lbl.Size = new System.Drawing.Size(181, 25);
            this.ExcelName_lbl.TabIndex = 19;
            this.ExcelName_lbl.Text = "讀取到的Excel路徑";
            this.toolTip1.SetToolTip(this.ExcelName_lbl, "從左算起第幾欄");
            // 
            // TelName_lbl
            // 
            this.TelName_lbl.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.TelName_lbl.AutoSize = true;
            this.TelName_lbl.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.TelName_lbl.Location = new System.Drawing.Point(426, 639);
            this.TelName_lbl.Name = "TelName_lbl";
            this.TelName_lbl.Size = new System.Drawing.Size(199, 25);
            this.TelName_lbl.TabIndex = 100;
            this.TelName_lbl.Text = "讀取到的電文txt路徑";
            this.toolTip1.SetToolTip(this.TelName_lbl, "從左算起第幾欄");
            // 
            // OpenCompareTelString_btn
            // 
            this.OpenCompareTelString_btn.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.OpenCompareTelString_btn.Location = new System.Drawing.Point(200, 33);
            this.OpenCompareTelString_btn.Name = "OpenCompareTelString_btn";
            this.OpenCompareTelString_btn.Size = new System.Drawing.Size(175, 113);
            this.OpenCompareTelString_btn.TabIndex = 6;
            this.OpenCompareTelString_btn.Text = "開啟電文檔";
            this.toolTip1.SetToolTip(this.OpenCompareTelString_btn, "開啟需要處理的檔案");
            this.OpenCompareTelString_btn.UseVisualStyleBackColor = true;
            this.OpenCompareTelString_btn.Click += new System.EventHandler(this.openTelString);
            // 
            // CompareReflash_btn
            // 
            this.CompareReflash_btn.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.CompareReflash_btn.Location = new System.Drawing.Point(6, 95);
            this.CompareReflash_btn.Name = "CompareReflash_btn";
            this.CompareReflash_btn.Size = new System.Drawing.Size(173, 51);
            this.CompareReflash_btn.TabIndex = 7;
            this.CompareReflash_btn.Text = "清除比對電文";
            this.toolTip1.SetToolTip(this.CompareReflash_btn, "開啟需要處理的檔案");
            this.CompareReflash_btn.UseVisualStyleBackColor = true;
            this.CompareReflash_btn.Click += new System.EventHandler(this.Reflash_btn_Click);
            // 
            // CompareName_lbl
            // 
            this.CompareName_lbl.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.CompareName_lbl.AutoSize = true;
            this.CompareName_lbl.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.CompareName_lbl.Location = new System.Drawing.Point(426, 675);
            this.CompareName_lbl.Name = "CompareName_lbl";
            this.CompareName_lbl.Size = new System.Drawing.Size(239, 25);
            this.CompareName_lbl.TabIndex = 107;
            this.CompareName_lbl.Text = "讀取到的比對電文txt路徑";
            this.toolTip1.SetToolTip(this.CompareName_lbl, "從左算起第幾欄");
            this.CompareName_lbl.Visible = false;
            // 
            // ExcelPath_lbl
            // 
            this.ExcelPath_lbl.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.ExcelPath_lbl.AutoSize = true;
            this.ExcelPath_lbl.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.ExcelPath_lbl.Location = new System.Drawing.Point(679, 603);
            this.ExcelPath_lbl.Name = "ExcelPath_lbl";
            this.ExcelPath_lbl.Size = new System.Drawing.Size(72, 25);
            this.ExcelPath_lbl.TabIndex = 102;
            this.ExcelPath_lbl.Text = "未讀取";
            this.ExcelPath_lbl.MouseHover += new System.EventHandler(this.ExcelPath_lbl_MouseHover);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(192, 11);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(129, 41);
            this.button2.TabIndex = 99;
            this.button2.Text = "開啟測試視窗";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // txtPath_lbl
            // 
            this.txtPath_lbl.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.txtPath_lbl.AutoSize = true;
            this.txtPath_lbl.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.txtPath_lbl.Location = new System.Drawing.Point(679, 639);
            this.txtPath_lbl.Name = "txtPath_lbl";
            this.txtPath_lbl.Size = new System.Drawing.Size(72, 25);
            this.txtPath_lbl.TabIndex = 101;
            this.txtPath_lbl.Text = "未讀取";
            this.txtPath_lbl.MouseHover += new System.EventHandler(this.ExcelPath_lbl_MouseHover);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(192, 64);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(129, 48);
            this.button1.TabIndex = 103;
            this.button1.Text = "另存txt用";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.ReadExcelTelName_txt);
            this.panel1.Controls.Add(this.ByteTransfer);
            this.panel1.Controls.Add(this.dataTypesit_counter);
            this.panel1.Controls.Add(this.DataTypeSiteName_txt);
            this.panel1.Controls.Add(this.button1);
            this.panel1.Controls.Add(this.Occursesit_counter);
            this.panel1.Controls.Add(this.Occursesit_txt);
            this.panel1.Controls.Add(this.button2);
            this.panel1.Location = new System.Drawing.Point(534, 96);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(353, 232);
            this.panel1.TabIndex = 104;
            this.panel1.Visible = false;
            // 
            // ReadExcelTelName_txt
            // 
            this.ReadExcelTelName_txt.Location = new System.Drawing.Point(16, 187);
            this.ReadExcelTelName_txt.Name = "ReadExcelTelName_txt";
            this.ReadExcelTelName_txt.Size = new System.Drawing.Size(201, 25);
            this.ReadExcelTelName_txt.TabIndex = 112;
            // 
            // ByteTransfer
            // 
            this.ByteTransfer.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.ByteTransfer.Location = new System.Drawing.Point(16, 84);
            this.ByteTransfer.Name = "ByteTransfer";
            this.ByteTransfer.Size = new System.Drawing.Size(136, 41);
            this.ByteTransfer.TabIndex = 111;
            this.ByteTransfer.Text = "byte轉字串";
            this.ByteTransfer.UseVisualStyleBackColor = true;
            this.ByteTransfer.Visible = false;
            this.ByteTransfer.Click += new System.EventHandler(this.ByteTransfer_Click);
            // 
            // openExcel_btn
            // 
            this.openExcel_btn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.openExcel_btn.Location = new System.Drawing.Point(1019, 55);
            this.openExcel_btn.Name = "openExcel_btn";
            this.openExcel_btn.Size = new System.Drawing.Size(205, 41);
            this.openExcel_btn.TabIndex = 104;
            this.openExcel_btn.Text = "excel儲存選項測試";
            this.openExcel_btn.UseVisualStyleBackColor = true;
            this.openExcel_btn.Click += new System.EventHandler(this.openExcel_btn_Click_1);
            // 
            // TelGroup
            // 
            this.TelGroup.Controls.Add(this.ShowTelString_btn);
            this.TelGroup.Controls.Add(this.OpenTelString_btn);
            this.TelGroup.Controls.Add(this.Reflash_btn);
            this.TelGroup.Controls.Add(this.telString_txt);
            this.TelGroup.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.TelGroup.Location = new System.Drawing.Point(24, 12);
            this.TelGroup.Name = "TelGroup";
            this.TelGroup.Size = new System.Drawing.Size(399, 162);
            this.TelGroup.TabIndex = 105;
            this.TelGroup.TabStop = false;
            this.TelGroup.Text = "電文字串(.txt)";
            // 
            // ShowTelString_btn
            // 
            this.ShowTelString_btn.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.ShowTelString_btn.Location = new System.Drawing.Point(6, 33);
            this.ShowTelString_btn.Name = "ShowTelString_btn";
            this.ShowTelString_btn.Size = new System.Drawing.Size(173, 51);
            this.ShowTelString_btn.TabIndex = 109;
            this.ShowTelString_btn.Text = "查看電文";
            this.ShowTelString_btn.UseVisualStyleBackColor = true;
            this.ShowTelString_btn.Click += new System.EventHandler(this.ShowTelString_btn_Click);
            // 
            // ComparetelString_txt
            // 
            this.ComparetelString_txt.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ComparetelString_txt.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.ComparetelString_txt.Location = new System.Drawing.Point(200, 33);
            this.ComparetelString_txt.Multiline = true;
            this.ComparetelString_txt.Name = "ComparetelString_txt";
            this.ComparetelString_txt.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.ComparetelString_txt.Size = new System.Drawing.Size(196, 113);
            this.ComparetelString_txt.TabIndex = 7;
            this.ComparetelString_txt.Visible = false;
            this.ComparetelString_txt.WordWrap = false;
            this.ComparetelString_txt.TextChanged += new System.EventHandler(this.telString_txt_TextChanged);
            this.ComparetelString_txt.Leave += new System.EventHandler(this.telString_txt_TextLeave);
            // 
            // CompareTelGroup
            // 
            this.CompareTelGroup.Controls.Add(this.ShowCompareTelString_btn);
            this.CompareTelGroup.Controls.Add(this.OpenCompareTelString_btn);
            this.CompareTelGroup.Controls.Add(this.CompareReflash_btn);
            this.CompareTelGroup.Controls.Add(this.ComparetelString_txt);
            this.CompareTelGroup.Enabled = false;
            this.CompareTelGroup.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.CompareTelGroup.Location = new System.Drawing.Point(24, 215);
            this.CompareTelGroup.Name = "CompareTelGroup";
            this.CompareTelGroup.Size = new System.Drawing.Size(399, 162);
            this.CompareTelGroup.TabIndex = 106;
            this.CompareTelGroup.TabStop = false;
            this.CompareTelGroup.Text = "比對電文字串(.txt)";
            // 
            // ShowCompareTelString_btn
            // 
            this.ShowCompareTelString_btn.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.ShowCompareTelString_btn.Location = new System.Drawing.Point(6, 33);
            this.ShowCompareTelString_btn.Name = "ShowCompareTelString_btn";
            this.ShowCompareTelString_btn.Size = new System.Drawing.Size(173, 51);
            this.ShowCompareTelString_btn.TabIndex = 110;
            this.ShowCompareTelString_btn.Text = "查看比對電文";
            this.ShowCompareTelString_btn.UseVisualStyleBackColor = true;
            this.ShowCompareTelString_btn.Click += new System.EventHandler(this.ShowTelString_btn_Click);
            // 
            // Compare_ckb
            // 
            this.Compare_ckb.AutoSize = true;
            this.Compare_ckb.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.Compare_ckb.Location = new System.Drawing.Point(24, 180);
            this.Compare_ckb.Name = "Compare_ckb";
            this.Compare_ckb.Size = new System.Drawing.Size(194, 29);
            this.Compare_ckb.TabIndex = 8;
            this.Compare_ckb.Text = "啟用比對字串區域";
            this.Compare_ckb.UseVisualStyleBackColor = true;
            this.Compare_ckb.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.ReadExcelTelName_cbx);
            this.groupBox4.Controls.Add(this.Occ_cbx);
            this.groupBox4.Controls.Add(this.StartToRead_btn);
            this.groupBox4.Controls.Add(this.label4);
            this.groupBox4.Controls.Add(this.ExcelDataType_btn);
            this.groupBox4.Controls.Add(this.DataType_cbx);
            this.groupBox4.Controls.Add(this.SheetName_lbl);
            this.groupBox4.Controls.Add(this.label1);
            this.groupBox4.Controls.Add(this.SheetName_txt);
            this.groupBox4.Controls.Add(this.Occurse_ckb);
            this.groupBox4.Controls.Add(this.SheetName_cbx);
            this.groupBox4.Controls.Add(this.dataTypeSit_lbl);
            this.groupBox4.Controls.Add(this.Occurse_lbl);
            this.groupBox4.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.groupBox4.Location = new System.Drawing.Point(24, 383);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(396, 320);
            this.groupBox4.TabIndex = 106;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "電文格式(Excel)";
            // 
            // ReadExcelTelName_cbx
            // 
            this.ReadExcelTelName_cbx.FormattingEnabled = true;
            this.ReadExcelTelName_cbx.Location = new System.Drawing.Point(9, 29);
            this.ReadExcelTelName_cbx.Name = "ReadExcelTelName_cbx";
            this.ReadExcelTelName_cbx.Size = new System.Drawing.Size(205, 33);
            this.ReadExcelTelName_cbx.TabIndex = 113;
            this.ReadExcelTelName_cbx.SelectedIndexChanged += new System.EventHandler(this.ReadExcelTelName_cbx_SelectedIndexChanged);
            this.ReadExcelTelName_cbx.TextChanged += new System.EventHandler(this.ReadExcelTelName_cbx_TextChanged);
            // 
            // ComparetxtPath_lbl
            // 
            this.ComparetxtPath_lbl.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.ComparetxtPath_lbl.AutoSize = true;
            this.ComparetxtPath_lbl.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.ComparetxtPath_lbl.Location = new System.Drawing.Point(679, 675);
            this.ComparetxtPath_lbl.Name = "ComparetxtPath_lbl";
            this.ComparetxtPath_lbl.Size = new System.Drawing.Size(72, 25);
            this.ComparetxtPath_lbl.TabIndex = 108;
            this.ComparetxtPath_lbl.Text = "未讀取";
            this.ComparetxtPath_lbl.Visible = false;
            this.ComparetxtPath_lbl.MouseHover += new System.EventHandler(this.ExcelPath_lbl_MouseHover);
            // 
            // CompareResult_lbl
            // 
            this.CompareResult_lbl.AutoSize = true;
            this.CompareResult_lbl.Font = new System.Drawing.Font("微軟正黑體", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.CompareResult_lbl.Location = new System.Drawing.Point(423, 9);
            this.CompareResult_lbl.Name = "CompareResult_lbl";
            this.CompareResult_lbl.Size = new System.Drawing.Size(182, 31);
            this.CompareResult_lbl.TabIndex = 110;
            this.CompareResult_lbl.Text = "比對電文結果：";
            // 
            // ReturnExcel
            // 
            this.ReturnExcel.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.ReturnExcel.Location = new System.Drawing.Point(611, 9);
            this.ReturnExcel.Name = "ReturnExcel";
            this.ReturnExcel.Size = new System.Drawing.Size(211, 41);
            this.ReturnExcel.TabIndex = 104;
            this.ReturnExcel.Text = "比對結果輸出EXCEL";
            this.ReturnExcel.UseVisualStyleBackColor = true;
            this.ReturnExcel.Click += new System.EventHandler(this.ReturnExcel_Click);
            // 
            // progressBar1
            // 
            this.progressBar1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.progressBar1.Location = new System.Drawing.Point(429, 719);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(795, 23);
            this.progressBar1.TabIndex = 111;
            // 
            // DeleteItem_cbx
            // 
            this.DeleteItem_cbx.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.DeleteItem_cbx.Font = new System.Drawing.Font("微軟正黑體", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.DeleteItem_cbx.FormattingEnabled = true;
            this.DeleteItem_cbx.Location = new System.Drawing.Point(1019, 12);
            this.DeleteItem_cbx.Name = "DeleteItem_cbx";
            this.DeleteItem_cbx.Size = new System.Drawing.Size(205, 37);
            this.DeleteItem_cbx.TabIndex = 114;
            // 
            // DeleteIitemExcel_btn
            // 
            this.DeleteIitemExcel_btn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.DeleteIitemExcel_btn.Location = new System.Drawing.Point(1019, 111);
            this.DeleteIitemExcel_btn.Name = "DeleteIitemExcel_btn";
            this.DeleteIitemExcel_btn.Size = new System.Drawing.Size(205, 41);
            this.DeleteIitemExcel_btn.TabIndex = 115;
            this.DeleteIitemExcel_btn.Text = "excel刪除選項測試";
            this.DeleteIitemExcel_btn.UseVisualStyleBackColor = true;
            this.DeleteIitemExcel_btn.Click += new System.EventHandler(this.DeleteIitemExcel_btn_Click);
            // 
            // StringHandleMainPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1244, 742);
            this.Controls.Add(this.DeleteIitemExcel_btn);
            this.Controls.Add(this.DeleteItem_cbx);
            this.Controls.Add(this.ReturnExcel);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.openExcel_btn);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.Compare_ckb);
            this.Controls.Add(this.CompareResult_lbl);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.ComparetxtPath_lbl);
            this.Controls.Add(this.CompareName_lbl);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.CompareTelGroup);
            this.Controls.Add(this.TelGroup);
            this.Controls.Add(this.ExcelPath_lbl);
            this.Controls.Add(this.txtPath_lbl);
            this.Controls.Add(this.TelName_lbl);
            this.Controls.Add(this.ExcelName_lbl);
            this.Controls.Add(this.statusStrip1);
            this.Name = "StringHandleMainPage";
            this.Text = "TelSplit";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.StringHandleMainPage_FormClosed);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Occursesit_counter)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataTypesit_counter)).EndInit();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.TelGroup.ResumeLayout(false);
            this.TelGroup.PerformLayout();
            this.CompareTelGroup.ResumeLayout(false);
            this.CompareTelGroup.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel EndStatus;
        private System.Windows.Forms.TextBox telString_txt;
        private System.Windows.Forms.NumericUpDown dataTypesit_counter;
        private System.Windows.Forms.Label dataTypeSit_lbl;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Button OpenTelString_btn;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button Reflash_btn;
        private System.Windows.Forms.Label Occurse_lbl;
        private System.Windows.Forms.NumericUpDown Occursesit_counter;
        private System.Windows.Forms.CheckBox Occurse_ckb;
        private System.Windows.Forms.Button ExcelDataType_btn;
        private System.Windows.Forms.Label SheetName_lbl;
        private System.Windows.Forms.TextBox SheetName_txt;
        private System.Windows.Forms.TextBox DataTypeSiteName_txt;
        private System.Windows.Forms.ComboBox SheetName_cbx;
        private System.Windows.Forms.Button StartToRead_btn;
        private System.Windows.Forms.Label ExcelName_lbl;
        private System.Windows.Forms.Label TelName_lbl;
        private System.Windows.Forms.Label txtPath_lbl;
        private System.Windows.Forms.Label ExcelPath_lbl;
        private System.Windows.Forms.TextBox Occursesit_txt;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ComboBox DataType_cbx;
        private System.Windows.Forms.ComboBox Occ_cbx;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.GroupBox TelGroup;
        private System.Windows.Forms.TextBox ComparetelString_txt;
        private System.Windows.Forms.GroupBox CompareTelGroup;
        private System.Windows.Forms.Button OpenCompareTelString_btn;
        private System.Windows.Forms.Button CompareReflash_btn;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Label ComparetxtPath_lbl;
        private System.Windows.Forms.Label CompareName_lbl;
        private System.Windows.Forms.CheckBox Compare_ckb;
        private System.Windows.Forms.Button ShowTelString_btn;
        private System.Windows.Forms.Button ShowCompareTelString_btn;
        private System.Windows.Forms.Label CompareResult_lbl;
        private System.Windows.Forms.Button ReturnExcel;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.Button ByteTransfer;
        private System.Windows.Forms.Button openExcel_btn;
        private System.Windows.Forms.TextBox ReadExcelTelName_txt;
        private System.Windows.Forms.ComboBox ReadExcelTelName_cbx;
        private System.Windows.Forms.ComboBox DeleteItem_cbx;
        private System.Windows.Forms.Button DeleteIitemExcel_btn;
    }
}

