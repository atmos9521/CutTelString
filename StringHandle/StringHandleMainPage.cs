/*存EXCEL*/
using NPOI;
using NPOI.HSSF.UserModel;
using NPOI.XSSF.UserModel;
using NPOI.SS.UserModel;
//使用NPOI存取EXCEL
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using static StringHandle.ExcelControl;

namespace StringHandle
{
    public partial class StringHandleMainPage : Form
    {
        public StringHandleMainPage()
        {
            InitializeComponent();
            TelWindowOpening = false;
            CompareTelWindowOpening = false;

            Hashtable ExcelData = new Hashtable();
            bool openresult = ExcelControl.NewOpenExcelMethod("ExcelDataBase\\MyTelsData\\MyTelsData.xls", "Sheet1", out ExcelData);
            if (openresult)
            {
                //ExcelControl.getExceloneData(ExcelData,lines);

                for (int i = 0; i < ExcelData.Count - 1; i++)
                {
                    var test = ExcelData[i].ToString();
                    if (ExcelData.Contains(i) && ExcelData[i].ToString() != "")
                    {
                        ReadExcelTelName_cbx.Items.Add(ExcelData[i].ToString());
                        DeleteItem_cbx.Items.Add(ExcelData[i].ToString());
                    }
                }
            }
        }


        string OldtelStrings { get; set; }
        string getExcelFileName { get; set; }
        int ExcelColCount { get; set; }
        int dataTatalCount { get; set; }
        Encoding getEncoding { get; set; }
        string TriggerTelStringPath { get; set; }
        string TriggerCompareTelStringPath { get; set; }

        bool TelWindowOpening { get; set; }
        bool CompareTelWindowOpening { get; set; }
        //取得電文Type長度
        #region 取得電文Type
        int reSite(string[] sp)
        {
            int datalenth = 0;
            string spstring = "";
            int left, right;
            try
            {
                spstring = sp[0];
            }
            catch (Exception)
            {
                ShowStatusMessage("GetTelStringError");

                return -1;
            }

            char[] splitChar = { 'V', 'v' };
            string[] spstringSplit = spstring.Split(splitChar);

            string firstword, lastword = "";
            //firstword = sp[datatypesit - 1].Substring(0, 1).ToUpper();
            try
            {
                firstword = sp[0].Substring(0, 1).ToUpper();
                lastword = sp[0].Substring(sp[0].Length - 1).ToUpper();
            }
            catch (Exception)
            {
                ShowStatusMessage("GetDataTypeError");
                return -1;
            }

            //取得dataType
            try
            {
                //判斷dataType第一個字
                switch (firstword)
                {
                    case "X"://文字
                        left = sp[0].IndexOf('(');
                        right = sp[0].IndexOf(')');
                        if (left < 0)
                        {
                            datalenth += sp[0].Length;
                        }
                        else
                        {
                            spstring = sp[0].Substring(left + 1, (right - left - 1));
                            int.TryParse(spstring, out datalenth);
                        }

                        break;
                    case "9"://數字
                        foreach (string item in spstringSplit)
                        {
                            int templenth = datalenth;
                            left = item.IndexOf('(');
                            right = item.IndexOf(')');
                            if (left < 0)
                            {
                                datalenth += item.Length;//如果寫成999計算字串字數為資料長度
                                if (item.Substring(item.Length - 1).ToUpper() == "S")
                                {
                                    datalenth--;
                                }
                            }
                            else
                            {
                                spstring = item.Substring(left + 1, (right - left - 1));
                                int.TryParse(spstring, out datalenth);
                                datalenth += templenth;
                            }
                        }

                        break;
                    case "S"://帶正負數字
                        foreach (string item in spstringSplit)
                        {
                            int templenth = datalenth;
                            left = item.IndexOf('(');
                            right = item.IndexOf(')');
                            if (left < 0)
                            {
                                datalenth += item.Length;
                                if (item.Substring(0, 1).ToUpper() == "S")
                                {
                                    datalenth--;
                                }
                            }
                            else
                            {
                                spstring = item.Substring(left + 1, (right - left - 1));
                                int.TryParse(spstring, out datalenth);
                                datalenth += templenth;
                            }
                        }
                        break;
                    case "D"://日期
                        datalenth = sp[0].Length;
                        break;
                    case "Y"://日期
                        datalenth = sp[0].Length;
                        break;
                    case "M"://日期
                        datalenth = sp[0].Length;
                        break;
                    default:
                        int.TryParse(sp[0], out datalenth);
                        break;
                }

                if (firstword == "S" || lastword == "S")
                {
                    datalenth++;
                }
                return datalenth;
            }
            catch
            {
                ShowStatusMessage("GetDataTypeError");
                return -1;
            }

        }

        #endregion


        void showvalue(int DataStartSit, int datalenth, DataTable dt, string[] sp, int seq)
        {
            #region  電文資料處理
            ////電文資料
            //string telstring = telString_txt.Text;
            //----------------------------------------------------------------------------------------------

            //電文值
            string telstringcell = "";
            try
            {
                telstringcell = telstrings.Substring(DataStartSit - 1, datalenth);
            }
            catch (Exception)
            {
                telstringcell = "";
                //ShowStatusMessage("GetTelStringError");
                //return;
            }
            #endregion
            //----------------------------------------------------------------------------------------------

            DataRow dr = dt.NewRow();
            //加入資料
            int CatchColStartSite = dataGridView1.ColumnCount - sp.Length;
            dr[0] = seq.ToString();
            for (int i = CatchColStartSite; i < dataGridView1.ColumnCount; i++)
            {
                dr[1] = datalenth;
                dr[2] = DataStartSit;
                dr[3] = telstringcell;
                string[] test = sp;
                dr[i] = sp[sp.Length - (dataGridView1.ColumnCount - i)];
            }
            dt.Rows.Add(dr);
            dataGridView1.DataSource = dt;
        }


        void ShowStatusMessage(string MessageNumber)
        {
            switch (MessageNumber)
            {
                case "EnterTelNameError":
                    EndStatus.Text = "請輸入6碼電文代號加i或o";
                    break;
                case "PressReadExcel":
                    EndStatus.Text = "請執行\"讀取Excel\"按鈕";
                    break;
                case "NotFindCorrectTel":
                    EndStatus.Text = "此Excel只有TX或RX";
                    break;
                case "SaveExcelEnd":
                    EndStatus.Text = "Excel存取資料成功";
                    break;
                case "NonExcelPath":
                    ExcelPath_lbl.Text = "未讀取";
                    break;
                case "NontxtPath":
                    txtPath_lbl.Text = "未讀取";
                    break;
                case "NonComparetxtPath":
                    ComparetxtPath_lbl.Text = "未讀取";
                    break;
                case "telToShort":
                    EndStatus.Text = "電文長度不足";
                    break;
                case "ComparetelToShort":
                    EndStatus.Text = "比對電文長度不足";
                    break;
                case "openExcelErrro":
                    EndStatus.Text = "Excel副檔名不為.xls或未輸入正確的電碼代號";
                    break;
                case "openExcelSheetErrro":
                    EndStatus.Text = "請輸入頁籤名稱";
                    break;
                case "inputDatatypeSitNumberError":
                    EndStatus.Text = "Datatype位置必須為 >= 1的整數";
                    break;
                case "inputOccureceSitNumberError":
                    EndStatus.Text = "Occurece位置必須為 >= 1的整數";
                    break;
                case "inputOccureceTimesNumberError":
                    EndStatus.Text = "Occurece次數必須為 >= 1的整數";
                    break;
                case "NoTelString":
                    EndStatus.Text = "尚未輸入電文字串";
                    break;
                case "ExcelNotOpen":
                    EndStatus.Text = "尚未開啟任何Excel頁籤";
                    break;
                case "DataNotFound":
                    EndStatus.Text = "無此檔案";
                    break;
                case "Handling":
                    EndStatus.Text = "處理中.......";
                    break;
                case "Handle end":
                    EndStatus.Text = "處理完畢";
                    break;
                case "TelLenthError":
                    EndStatus.Text = "輸入電文長度不正確";
                    break;
                case "GetTelStringError":
                    EndStatus.Text = "取得電文字串失敗";
                    break;
                case "GetCompareTelStringError":
                    EndStatus.Text = "取得比對電文字串失敗";
                    break;
                case "GetDataTypeError":
                    EndStatus.Text = "取得dataType失敗";
                    break;
                case "GetTelString":
                    EndStatus.Text = "取得電文字串成功";
                    break;
                case "CleanTelString":
                    EndStatus.Text = "清除電文字串完畢";
                    break;
                default:
                    EndStatus.Text = "處理狀態";
                    break;
            }
        }

        string telstrings, Comparetelstrings;
        private void openTelString(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            //限制副檔名為 *.txt
            openFileDialog1.Filter = "txt Files|*.txt";
            openFileDialog1.Title = "Select a txt File";
            string clickbtnName = ((Button)sender).Name;
            switch (clickbtnName)
            {
                case "OpenTelString_btn":
                    telString_txt.Text = "";
                    break;
                case "OpenCompareTelString_btn":
                    ComparetelString_txt.Text = "";
                    break;
                default:
                    break;
            }

            ShowStatusMessage("Handling");
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                //進度條歸零
                progressBar1.Value = 0;
                string getfilepath = openFileDialog1.FileName;

                if (getfilepath != "" && getfilepath != null)
                {
                    //檔案存在
                    if (File.Exists(getfilepath))
                    {
                        StreamReader ReadTelStrings = new StreamReader(getfilepath);
                        getEncoding = CheckCoding(ReadTelStrings);
                        string line = string.Empty;
                        DataGridViewRowCollection rowsdata = dataGridView1.Rows;
                        //if (ChangWords == false)
                        //{
                        switch (clickbtnName)
                        {
                            case "OpenTelString_btn":
                                telstrings = "";//將之前取得的電文字串清除
                                while ((line = ReadTelStrings.ReadLine()) != null)
                                {
                                    try
                                    {
                                        telstrings = string.Format(telstrings + "{0}", line);
                                        telString_txt.Text = telstrings;
                                        ShowStatusMessage("GetTelString");
                                        txtPath_lbl.Text = getfilepath;
                                    }
                                    catch (Exception)
                                    {
                                        ShowStatusMessage("GetTelStringError");
                                        telString_txt.Text = "";
                                        ShowStatusMessage("NontxtPath");
                                    }
                                }
                                //}

                                break;
                            case "OpenCompareTelString_btn":
                                Comparetelstrings = "";
                                while ((line = ReadTelStrings.ReadLine()) != null && line != null && line != "")
                                {
                                    try
                                    {
                                        Comparetelstrings = string.Format(Comparetelstrings + "{0}", line);
                                        ComparetelString_txt.Text = Comparetelstrings;
                                        ShowStatusMessage("GetTelString");
                                        ComparetxtPath_lbl.Text = getfilepath;
                                    }
                                    catch (Exception ex)
                                    {
                                        ShowStatusMessage("GetTelStringError");
                                        ComparetelString_txt.Text = "";
                                        ShowStatusMessage("NonComparetxtPath");
                                    }
                                }
                                //}

                                break;
                            default:
                                break;
                        }

                        ReadTelStrings.Close();
                    }
                    else
                    {
                        TelError(clickbtnName);
                    }
                }
                else
                {
                    TelError(clickbtnName);
                }
            }
            else
            {
                TelError(clickbtnName);
            }
            enableSwitch();
        }
        void TelError(string ButtonName)
        {
            switch (ButtonName)
            {
                case "OpenTelString_btn":
                    telString_txt.Text = "";
                    ShowStatusMessage("NontxtPath");
                    ShowStatusMessage("GetTelStringError");
                    break;
                case "OpenCompareTelString_btn":
                    ComparetelString_txt.Text = "";
                    ShowStatusMessage("NonComparetxtPath");
                    ShowStatusMessage("GetCompareTelStringError");
                    break;
                default:
                    break;
            }
        }


        void enableSwitch()
        {
            bool ComparePass = true;

            if (Compare_ckb.Checked  //要比對
               && (ComparetelString_txt.Text == "" || ComparetelString_txt.Text == null))
            {//沒有輸入比對電文
                ComparePass = false;
            }

            if (telString_txt.Text != "" && telString_txt.Text != null
                && SheetName_txt.Text != "" && SheetName_txt.Text != null
                && dataTypesit_counter.Value != 0
                && ComparePass
                && DataType_cbx.Text != "")
            {
                if (Occurse_ckb.Checked && (Occursesit_counter.Value == 0 || Occ_cbx.Text == ""))//有occ但是occ位置=0不可開放
                {
                    StartToRead_btn.Enabled = false;
                }
                else
                {
                    StartToRead_btn.Enabled = true;
                }
            }
            else
            {
                StartToRead_btn.Enabled = false;
            }
        }
        //全形字串+兩個空格
        string HandleString(string tel)
        {
            //if (getEncoding.ToString() == "System.Text.UTF8Encoding")
            //{
            //    byte[] UTF8bytes = Encoding.UTF8.GetBytes(tel);
            //    for (int i = tel.Length - 1; i >= 0; i--)
            //    {
            //        if (UTF8bytes[i] == 63)
            //        {
            //            tel = tel.Insert(i + 1, "  ");
            //        }
            //    }
            //}
            //else if (getEncoding.ToString() != "System.Text.UTF8Encoding")
            //{
            //    //byte[] UTF8bytes = Encoding.UTF8.GetBytes(tel);
            //    byte[] ASCIIbytes = Encoding.ASCII.GetBytes(tel);//中文字或全形 = 63
            //    for (int i = tel.Length - 1; i >= 0; i--)
            //    {
            //        if (ASCIIbytes[i] == 63)
            //        {
            //            tel = tel.Insert(i + 1, "  ");
            //        }
            //    }
            //}

            //byte[] UTF8bytes = Encoding.UTF8.GetBytes(tel);
            byte[] ASCIIbytes = Encoding.ASCII.GetBytes(tel);//中文字或全形 = 63
            for (int i = tel.Length - 1; i >= 0; i--)
            {
                if (ASCIIbytes[i] == 63)
                {
                    tel = tel.Insert(i + 1, "  ");
                }
            }
            return tel;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            TestPage form2 = new TestPage();
            form2.Show();
        }

        private void Reflash_btn_Click(object sender, EventArgs e)
        {
            //進度條歸零
            progressBar1.Value = 0;
            string clickbtnName = ((Button)sender).Name;
            switch (clickbtnName)
            {
                case "Reflash_btn":
                    telstrings = "";//暫存的電文資料
                    telString_txt.Text = "";//畫面上輸入電文的欄位
                    ShowStatusMessage("NontxtPath");
                    break;
                case "CompareReflash_btn":
                    Comparetelstrings = "";
                    ComparetelString_txt.Text = "";
                    ShowStatusMessage("NonComparetxtPath");
                    break;
                default:
                    break;
            }

            ShowStatusMessage("CleanTelString");//清除狀態欄
            enableSwitch();
        }

        //電文Type資料位置
        private void dataTypesit_counter_ValueChanged(object sender, EventArgs e)
        {
            int dataTypesitValue = 0;
            if (!int.TryParse(dataTypesit_counter.Value.ToString(), out dataTypesitValue))
            {
                ShowStatusMessage("inputDatatypeSitNumberError");
            }
            //else
            //{
            //    ConvertNumberToColName(sender);
            //}
            dataTypesit_counter.Value = dataTypesitValue;
        }
        //Occurce資料位置
        private void Occursesit_counter_ValueChanged(object sender, EventArgs e)
        {
            int OccValue = 0;
            if (!int.TryParse(Occursesit_counter.Value.ToString(), out OccValue))
            {
                ShowStatusMessage("inputOccureceSitNumberError");
            }
            //else
            //{
            //    ConvertNumberToColName(sender);
            //}
            Occursesit_counter.Value = OccValue;
        }

        private void Occurse_ckb_CheckedChanged(object sender, EventArgs e)
        {
            Occurse_lbl.Visible = Occurse_ckb.Checked;
            //Occursesit_counter.Visible = Occurse_ckb.Checked;
            //Occursesit_txt.Visible = Occurse_ckb.Checked;
            label4.Visible = Occurse_ckb.Checked;
            Occ_cbx.Visible = Occurse_ckb.Checked;
            enableSwitch();
        }

        //離開電文字串欄位時，判斷有無電文字串
        private void telString_txt_TextLeave(object sender, EventArgs e)
        {
            //if (telString_txt.Text != null && telString_txt.Text != "")
            //{
            //    OldtelStrings = telString_txt.Text;
            //    //telString_txt.Text = HandleString(telString_txt.Text);
            //    telstrings = HandleString(telString_txt.Text);
            //}
            //else
            //{
            //    telstrings = "";
            //    StartToRead_btn.Enabled = false;
            //}
            enableSwitch();
        }

        private void DataType_cbx_SelectedIndexChanged(object sender, EventArgs e)
        {
            dataTypesit_counter.Value = DataType_cbx.SelectedIndex + 1;
            enableSwitch();
        }

        private void Occ_cbx_SelectedIndexChanged(object sender, EventArgs e)
        {
            Occursesit_counter.Value = Occ_cbx.SelectedIndex + 1;
            enableSwitch();
        }

        private void DataType_cbx_TextChanged(object sender, EventArgs e)
        {
            if (DataType_cbx.SelectedIndex < 0)
            {
                int DataTypeSite = ConvertColcode(((ComboBox)sender).Name, DataType_cbx.Text);
                if (DataTypeSite > ExcelColCount)
                {
                    MessageBox.Show("孩子，你/妳沒這麼多欄位吧!!", "選擇錯誤", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    dataTypesit_counter.Value = 0;
                }
                if (DataTypeSite < 0)
                {
                    dataTypesit_counter.Value = 0;
                    //MessageBox.Show("請重新輸入DataType欄位", "嚴重錯誤", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else if (DataTypeSite > 100 || DataTypeSite == 0)
                {
                    MessageBox.Show("別亂輸入!!", "誇張錯誤", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }

            enableSwitch();
        }

        private void Occ_cbx_TextChanged(object sender, EventArgs e)
        {
            if (Occ_cbx.SelectedIndex < 0)
            {
                int OccSite = ConvertColcode(((ComboBox)sender).Name, Occ_cbx.Text);
                if (OccSite > ExcelColCount)
                {
                    MessageBox.Show("孩子，你/妳沒這麼多欄位吧!!", "選擇錯誤", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    dataTypesit_counter.Value = 0;
                    return;
                }
                if (OccSite < 0)
                {
                    Occursesit_counter.Value = 0;
                    //MessageBox.Show("別亂輸入!!", "嚴重錯誤", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else if (OccSite > 100 || OccSite == 0)
                {
                    MessageBox.Show("哪來這麼多欄位", "誇張錯誤", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            enableSwitch();
        }
        string strCon = "";
        private void ExcelDataType_btn_Click(object sender, EventArgs e)
        {
            //進度條歸零
            progressBar1.Value = 0;
            //清除SheetName下拉選單
            SheetName_cbx.Items.Clear();
            //清除下拉選單讀取到的頁籤名稱
            DataType_cbx.Text = "";
            Occ_cbx.Text = "";
            DataType_cbx.Items.Clear();
            Occ_cbx.Items.Clear();
            //清掉已選擇的頁籤名稱
            SheetName_txt.Text = "";

            string TelName = ReadExcelTelName_cbx.Text;
            if (TelName != "" && TelName.Length == 7)//電文代號 ex 044100i
            {
                string filepath = string.Format("TelExcelFile\\{0}.xlsx", TelName.Substring(0, 6));//第0位，取6碼
                try
                {
                    openExcel(filepath);
                }
                catch (Exception)
                {
                    filepath = string.Format("TelExcelFile\\{0}.xls", TelName.Substring(0, 6));//第0位，取6碼
                    openExcel(filepath);
                }
            }
            else if (TelName != "" && TelName.Length != 7)//讀取Excel資料庫
            {
                string SelectTelFile = ReadExcelTelName_cbx.Items.ToString();
                string filepath = string.Format("ExcelDataBase\\TelsData\\{0}", SelectTelFile);
                openExcel(filepath);
            }
            else
            {
                //載入excel 
                OpenFileDialog openFileDialog1 = new OpenFileDialog();
                //限制副檔名為 *.xls 或 .xlsx
                //openFileDialog1.DefaultExt = ".xlsx";
                //openFileDialog1.Filter = "xlsx Files|*.xlsx|xls Files|*.xls|所有檔案 (*.*)| *.*";
                openFileDialog1.Filter = "所有檔案 (*.*)| *.*|xls Files|*.xls|xlsx Files|*.xlsx";
                //"文字檔 (*.txt)|*.txt|所有檔案 (*.*)|*.*"
                openFileDialog1.Title = "Select a xls File";

                /*步驟1：設定Excel的屬性、路徑*/

                if (openFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    //顯示"處理中"狀態
                    ShowStatusMessage("Handling");
                    getExcelFileName = openFileDialog1.FileName;
                    string[] ExcelNameString = getExcelFileName.Split('.');

                    /*步驟1：讀取開啟Excel連結字串*/
                    readExcelString(ExcelNameString[1]);

                    /*步驟2：依照Excel的屬性及路徑開啟檔案*/

                    //Excel路徑及相關資訊匯入
                    OleDbConnection GetXLS = new OleDbConnection(strCon);

                    //打開檔案
                    try
                    {
                        GetXLS.Open();
                        ExcelPath_lbl.Text = getExcelFileName;
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("開啟Excel失敗訊息:\n" + ex);
                        ShowStatusMessage("openExcelErrro");
                        ShowStatusMessage("NonExcelPath");
                        enableSwitch();
                        return;
                    }

                    /*步驟3：搜尋此Excel的所有工作表，找到特定工作表進行讀檔，並將其資料存入List*/
                    //搜尋xls的工作表(工作表名稱需要加$字串)
                    DataTable Table = GetXLS.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null);

                    //查詢此Excel所有的工作表名稱
                    string SelectSheetName = "";
                    foreach (DataRow row in Table.Rows)
                    {
                        //抓取Xls各個Sheet的名稱(+'$')-有的名稱需要加名稱''，有的不用
                        SelectSheetName = (string)row["TABLE_NAME"];
                        //SelectSheetName = (string)row["sheet1$"];

                        SelectSheetName = SelectSheetName.Replace("\'", "").Replace("$", "");
                        //string[] ReadSheetName = SelectSheetName.Split('\'');
                        SheetName_cbx.Items.Add(SelectSheetName);
                    }

                    SheetName_cbx.Text = "請選擇讀取的excel頁籤";
                    ShowStatusMessage("Handle end");
                    enableSwitch();
                    GetXLS.Close();
                }
                else
                {
                    SheetName_cbx.Text = "excel頁籤讀取失敗";
                    SheetName_cbx.Items.Clear();
                    ShowStatusMessage("NonExcelPath");
                    ShowStatusMessage("");
                    //清除下拉選單讀取到的頁籤名稱
                    DataType_cbx.Text = "";
                    Occ_cbx.Text = "";
                    DataType_cbx.Items.Clear();
                    Occ_cbx.Items.Clear();
                    //清掉已選擇的頁籤名稱
                    SheetName_txt.Text = "";
                    enableSwitch();
                }
            }
        }

        //依照選擇的變更DATAType的位置
        private void DataTypeSiteName_txt_Leave(object sender, EventArgs e)
        {
            byte[] array = new byte[1];
            array = Encoding.ASCII.GetBytes(DataTypeSiteName_txt.Text); //string轉換的字母
            int asciicode = (short)(array[0]);
            string ASCIIcode = Convert.ToString(asciicode); //將轉換一的ASCII轉碼換成string型

            //数字转换成字母
            //byte[] arrayToWord = new byte[1];
            //arrayToWord[0] = (byte)(Convert.ToInt32(ASCII码)); //ASCII碼强制轉換二進制
            //轉換後的字母 = Convert.ToString(System.Text.Encoding.ASCII.GetString(array));
            Console.WriteLine("" + asciicode);
        }

        private void DataTypeSiteName_txt_TextChanged(object sender, EventArgs e)
        {
            int DataTypeSite = ConvertColcode(((TextBox)sender).Name, DataTypeSiteName_txt.Text);
            if (DataTypeSite < 0)
            {
                dataTypesit_counter.Value = 0;
                //MessageBox.Show("請重新輸入DataType欄位", "嚴重錯誤", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (DataTypeSite > 100 || DataTypeSite == 0)
            {
                MessageBox.Show("別亂輸入!!", "誇張錯誤", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            enableSwitch();
        }
        private void Occursesit_txt_TextChanged(object sender, EventArgs e)
        {
            int OccSite = ConvertColcode(((TextBox)sender).Name, Occursesit_txt.Text);
            if (OccSite < 0)
            {
                Occursesit_counter.Value = 0;
                //MessageBox.Show("別亂輸入!!", "嚴重錯誤", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (OccSite > 100 || OccSite == 0)
            {
                MessageBox.Show("哪來這麼多欄位", "誇張錯誤", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            enableSwitch();
        }

        int ConvertColcode(string ComboBoxName, string ColCode)
        {
            if (ColCode != "")
            {
                byte[] array = new byte[1];

                array = Encoding.ASCII.GetBytes(ColCode.ToLower()); //string轉換的字母編碼
                //int asciicode = (short)(array[0]);
                int asciicode = 0;
                int index = 0;
                string tempNumber = "";
                foreach (byte item in array)
                {
                    if (item > 96 && index > 0)
                    {
                        asciicode += 25;
                    }
                    if (item > 96)
                    {
                        asciicode += (item - 96);
                    }
                    if (item >= 48 && item <= 57)//輸入0編碼為48，9為57
                    {
                        tempNumber = string.Format(tempNumber + "{0}", ColCode.Substring(index, 1));
                    }
                    index++;
                }
                if (ComboBoxName == "DataType_cbx")
                {
                    dataTypesit_counter.Value = asciicode;
                    if (asciicode == 0 && tempNumber != "")
                    {
                        int.TryParse(tempNumber, out asciicode);
                    }
                    try
                    {
                        dataTypesit_counter.Value = asciicode;
                    }
                    catch (Exception)//超過DataTypeCounterMax
                    {
                        dataTypesit_counter.Value = 0;
                        asciicode = 0;
                    }

                }
                else if (ComboBoxName == "Occ_cbx")
                {
                    Occursesit_counter.Value = asciicode;
                    if (asciicode == 0 && tempNumber != "")
                    {
                        int.TryParse(tempNumber, out asciicode);
                    }
                    try
                    {
                        Occursesit_counter.Value = asciicode;
                    }
                    catch (Exception)//超過OccCounterMax
                    {
                        Occursesit_counter.Value = 0;
                        asciicode = 0;
                    }
                }

                return asciicode;
            }
            return -1;
        }
        void ConvertNumberToColName(object CounterName)
        {
            var test = ((NumericUpDown)CounterName).Value;
            string ASCIIcode = Convert.ToString(((NumericUpDown)CounterName).Value); //將轉換一的ASCII轉碼換成string型

        }
        private void SheetName_cbx_SelectedIndexChanged(object sender, EventArgs e)
        {
            SheetName_txt.Text = SheetName_cbx.Text;

            //下拉選單變更
            if (SheetName_txt.Text != "")
            {
                /*步驟1：設定Excel的屬性、路徑*/

                //顯示"處理中"狀態
                ShowStatusMessage("Handling");
                string getFileName = getExcelFileName;

                /*步驟2：依照Excel的屬性及路徑開啟檔案*/
                //Excel路徑及相關資訊匯入
                OleDbConnection GetXLS = new OleDbConnection(strCon);

                //打開檔案
                try
                {
                    GetXLS.Open();
                    ExcelPath_lbl.Text = getFileName;
                }
                catch (Exception)
                {
                    ShowStatusMessage("openExcelErrro");
                    ShowStatusMessage("NonExcelPath");
                    return;
                }


                /*步驟3：搜尋此Excel的所有工作表，找到特定工作表進行讀檔，並將其資料存入List*/

                //搜尋xls的工作表(工作表名稱需要加$字串)
                DataTable Table = GetXLS.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null);

                //查詢此Excel所有的工作表名稱
                string SelectSheetName = "";
                foreach (DataRow row in Table.Rows)
                {
                    //抓取Xls各個Sheet的名稱(+'$')-有的名稱需要加名稱''，有的不用
                    SelectSheetName = (string)row["TABLE_NAME"];
                    //SelectSheetName = (string)row["sheet1$"];

                    SelectSheetName = SelectSheetName.Replace("\'", "").Replace("$", "");
                    //工作表名稱有特殊字元、空格，需加'工作表名稱$'，ex：'Sheet_A$'
                    //工作表名稱沒有特殊字元、空格，需加工作表名稱$，ex：SheetA$
                    //所有工作表名稱為Sheet1，讀取此工作表的內容
                    if (SelectSheetName == SheetName_txt.Text)
                    {
                        //select 工作表名稱
                        OleDbCommand cmSheetA = new OleDbCommand(" SELECT * FROM [" + SheetName_txt.Text + "$] ", GetXLS);
                        OleDbDataReader drSheetA = cmSheetA.ExecuteReader();

                        //讀取工作表SheetA資料
                        //drSheetA.Read();//讀一行

                        //清除下拉選單讀取到的頁籤名稱
                        DataType_cbx.Text = "";
                        Occ_cbx.Text = "";
                        DataType_cbx.Items.Clear();
                        Occ_cbx.Items.Clear();

                        drSheetA.Read();
                        //取出標題名稱
                        for (int i = 0; i < drSheetA.FieldCount; i++)
                        {
                            ////2018/02/07  讀取欄位部分有值但是讀取出來為""，故註解
                            //if (drSheetA[i].ToString() != "" && drSheetA[i] != null)
                            //{
                            //    DataType_cbx.Items.Add(drSheetA[i]);
                            //    Occ_cbx.Items.Add(drSheetA[i]);
                            //}
                            DataType_cbx.Items.Add(drSheetA[i]);
                            Occ_cbx.Items.Add(drSheetA[i]);
                        }
                        ExcelColCount = drSheetA.FieldCount;

                        //讀一次EXCEL內容得到所有資料筆數
                        while (drSheetA.Read())
                        {
                            int dataCount = 1;
                            //讀取工作表SheetA資料
                            List<string> ListSheetA = new List<string>();
                            while (drSheetA.Read())
                            {
                                dataTatalCount = dataCount;
                                dataCount++;
                            }
                        }
                        //---------------------------------------------------------------------------------------------------
                        /*步驟4：關閉檔案*/

                        //結束關閉讀檔(必要，不關會有error)
                        drSheetA.Close();
                        GetXLS.Close();
                        ShowStatusMessage("Handle end");
                    }
                    else
                    {
                        //尚未開啟任何頁籤
                        ShowStatusMessage("ExcelNotOpen");
                        SheetName_cbx.Text = "請選擇要讀取的頁籤";
                    }
                }
            }
            enableSwitch();
        }

        int checklines = 1;
        private void StartToRead_btn_Click(object sender, EventArgs e)
        {
            /*步驟1：設定Excel的屬性、路徑*/

            DataTable dt = new DataTable();
            dt.Clear();

            //顯示"處理中"狀態
            ShowStatusMessage("Handling");
            string getFileName = getExcelFileName;

            /*步驟2：依照Excel的屬性及路徑開啟檔案*/
            //Excel路徑及相關資訊匯入
            OleDbConnection GetXLS = new OleDbConnection(strCon);

            //打開檔案
            try
            {
                GetXLS.Open();
                ExcelPath_lbl.Text = getFileName;
                telstrings = HandleString(telString_txt.Text);//打開Excel成功，處理電文有中文的部分
                if (Compare_ckb.Checked)
                {
                    Comparetelstrings = HandleString(ComparetelString_txt.Text);//打開Excel成功，處理電文有中文的部分
                }
            }
            catch (Exception)
            {
                ShowStatusMessage("openExcelErrro");
                ShowStatusMessage("NonExcelPath");
                return;
            }

            int telstringsLenth = telstrings.Length;//10041
            TelGroup.Text = string.Format("電文字串(.txt)  長度：{0}", telstringsLenth);
            if (Compare_ckb.Checked)
            {
                //補足較長的電文長度
                int ComparetelstringsLenth = Comparetelstrings.Length;//8915
                CompareTelGroup.Text = string.Format("比對電文字串(.txt)  長度：{0}", ComparetelstringsLenth);
                if (telstringsLenth > ComparetelstringsLenth)
                {
                    Comparetelstrings = Comparetelstrings.PadRight(telstringsLenth, ' ');
                }
                else
                {
                    telstrings = telstrings.PadRight(ComparetelstringsLenth, ' ');
                }
            }


            /*步驟3：搜尋此Excel的所有工作表，找到特定工作表進行讀檔，並將其資料存入List*/

            //搜尋xls的工作表(工作表名稱需要加$字串)
            DataTable Table = GetXLS.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null);

            //查詢此Excel所有的工作表名稱
            string SelectSheetName = "";
            foreach (DataRow row in Table.Rows)
            {
                //抓取Xls各個Sheet的名稱(+'$')-有的名稱需要加名稱''，有的不用
                SelectSheetName = (string)row["TABLE_NAME"];
                //SelectSheetName = (string)row["sheet1$"];

                SelectSheetName = SelectSheetName.Replace("\'", "").Replace("$", "");
                //工作表名稱有特殊字元、空格，需加'工作表名稱$'，ex：'Sheet_A$'
                //工作表名稱沒有特殊字元、空格，需加工作表名稱$，ex：SheetA$
                //所有工作表名稱為Sheet1，讀取此工作表的內容
                if (SelectSheetName == SheetName_txt.Text)
                {
                    //select 工作表名稱
                    OleDbCommand cmSheetA = new OleDbCommand(" SELECT * FROM [" + SheetName_txt.Text + "$] ", GetXLS);
                    OleDbDataReader drSheetA = cmSheetA.ExecuteReader();

                    //讀取工作表SheetA資料
                    List<string> ListSheetA = new List<string>();
                    //欄位名稱設定----------------------------------------------------------------------------------------
                    drSheetA.Read();
                    //序號欄位
                    dt.Columns.Add("序號");
                    dt.Columns.Add("資料長度");
                    dt.Columns.Add("起始位置");
                    dt.Columns.Add("電文資料");
                    if (Compare_ckb.Checked)
                    {
                        dt.Columns.Add("比對電文");
                    }

                    //自訂標題
                    for (int i = 0; i < drSheetA.FieldCount; i++)
                    {
                        //drSheetA[i].ToString().Trim();
                        try
                        {
                            dt.Columns.Add(drSheetA[i].ToString());
                        }
                        catch (Exception)
                        {
                            dt.Columns.Add(drSheetA[i].ToString() + "_" + (i - 2));
                        }
                    }

                    dataGridView1.DataSource = dt;
                    //dataGridView1.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                    //dataGridView1.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                    //dataGridView1.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;

                    dataGridView1.Columns[0].Width = 60;
                    dataGridView1.Columns[1].Width = 80;
                    dataGridView1.Columns[2].Width = 80;
                    if (Compare_ckb.Checked)
                    {
                        dataGridView1.Columns[3].Width = 80;
                    }

                    for (int i = 0; i < drSheetA.FieldCount; i++)
                    {
                        //dataGridView1.Columns[3 + i].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                        //不排序
                        dataGridView1.Columns[i].SortMode = DataGridViewColumnSortMode.NotSortable;
                    }
                    //---------------------------------------------------------------------------------------------------
                    //內容-----------------------------------------------------------------------------------------------
                    int seqno = 1;//序號
                    //int dataLenth = 0;//資料長度
                    int dataStartSite = 1;//資料起始位置

                    //occDataType
                    List<List<string>> occDataType = new List<List<string>>();//存放occDataType
                    int OccurseTimes = 0;//要重複的次數
                    int lastOccTimes = 0;//上一個重複次數
                                         //int tempOccTimes = 0;//最後一筆Occ處理次數

                    while (drSheetA.Read())
                    {
                        //for (int k = 0; k < drSheetA.FieldCount; k++)//測試此行取到的值
                        //{
                        //    string getExcelLine = drSheetA[k].ToString();
                        //}
                        //int CheckInputDataTypeIsMatch = ReadThisData(drSheetA[1].ToString(), drSheetA, 1);
                        //檢查是否為需要的電文
                        if (checklines == 1 && ReadThisData(drSheetA[1].ToString(), drSheetA, 1) == -1)
                        {
                            checklines = -1;
                            //重新執行
                            StartToRead_btn_Click(sender, e);
                            checklines = -1;
                            break;
                        }

                        //test新方法
                        if (Occurse_ckb.Checked)//有勾選重複區塊
                        {
                            string ExcelOccdata = "";
                            try
                            {
                                ExcelOccdata = drSheetA[(int)Occursesit_counter.Value - 1].ToString();
                            }
                            catch (Exception)
                            {
                                MessageBox.Show("重複字串位置選擇錯誤", "Error");
                            }

                            bool canParse = int.TryParse(ExcelOccdata, out OccurseTimes);
                            //讀取資料判斷 occStart 和 occEnd狀態
                            if (!canParse && ExcelOccdata != "")//轉型失敗，且有輸入文字，但不是數字
                            {
                                ShowStatusMessage("inputOccureceTimesNumberError");
                                return;
                            }
                            else if ((canParse && lastOccTimes == 0) || //第一筆重複資料
                                     (canParse && OccurseTimes != 0 && lastOccTimes == OccurseTimes))//第一筆外的重複資料
                            {
                                List<string> colstring = new List<string>();
                                for (int i = 0; i < drSheetA.FieldCount; i++)//EXCEL讀的該行資料 分段儲存
                                {
                                    colstring.Add(drSheetA[i].ToString());
                                }
                                occDataType.Add(colstring);//儲存所有重複字串的資料
                            }

                            //輸出
                            //1.上次!=這次                      2.上次!=0            3.有重複區塊資料
                            if (lastOccTimes != OccurseTimes && lastOccTimes != 0 && occDataType.Count != 0)//上次跟這次的重複次數不同且重複區塊有值，則要輸出
                            {
                                dataStartSite = handleData(lastOccTimes, occDataType, dt, seqno, dataStartSite);
                                occDataType.Clear();
                                if (ExcelOccdata == "")//如果重複次數欄位沒有值，將此筆資料輸出
                                {
                                    dataStartSite = handleSingleData(drSheetA, dt, seqno, dataStartSite);
                                }

                                if (OccurseTimes != 0)//OccurseTimes !=0   緊接另一個重複區塊，儲存下個occDataType
                                {
                                    List<string> colstring = new List<string>();
                                    for (int i = 0; i < drSheetA.FieldCount; i++)//EXCEL讀的該行資料 分段儲存
                                    {
                                        colstring.Add(drSheetA[i].ToString());
                                    }
                                    occDataType.Add(colstring);//儲存所有重複字串的資料
                                }
                            }
                            else if (!canParse || OccurseTimes == 0)//輸出單筆資料，無需重複
                            {
                                dataStartSite = handleSingleData(drSheetA, dt, seqno, dataStartSite);
                                seqno++;
                            }
                        }
                        else//沒有重複，直接輸出單筆資料
                        {
                            dataStartSite = handleSingleData(drSheetA, dt, seqno, dataStartSite);
                            seqno++;
                        }
                        lastOccTimes = OccurseTimes;
                    }

                    if (checklines == -1)
                    {
                        ShowStatusMessage("NotFindCorrectTel");//沒有核對到正確的上/下行電文
                    }
                    else
                    {
                        ShowStatusMessage("Handle end");
                    }
                    checklines = 1;

                    progressBar1.Value = 100;
                    drSheetA.Read();
                    if (OccurseTimes != 0)
                    {
                        dataStartSite = handleData(lastOccTimes, occDataType, dt, seqno, dataStartSite);
                        occDataType.Clear();
                    }
                    //---------------------------------------------------------------------------------------------------
                    /*步驟4：關閉檔案*/

                    //結束關閉讀檔(必要，不關會有error)
                    drSheetA.Close();
                    GetXLS.Close();
                }
                else
                {
                    //尚未開啟任何頁籤
                    ShowStatusMessage("ExcelNotOpen");
                    SheetName_cbx.Text = "請選擇要讀取的頁籤";
                }
            }
        }

        int handleData(int lastOccTimes, List<List<string>> occDataType, DataTable dt, int seqno, int dataStartSite)
        {
            for (int i = 1; i <= lastOccTimes; i++)
            {
                foreach (List<string> item in occDataType)
                {
                    DataRow drinsite = dt.NewRow();
                    //計算處理進度
                    int completepersent = (seqno * 100) / (dataTatalCount + 1);
                    if (completepersent > 100)
                    {
                        progressBar1.Value = 100;
                    }
                    else
                    {
                        progressBar1.Value = completepersent;
                    }
                    //序號
                    drinsite[0] = seqno;
                    seqno++;
                    //資料長度(get dataType)
                    string[] OccobjChangeArray = { item[(int)dataTypesit_counter.Value - 1].ToString() };
                    int dataLenth = reSite(OccobjChangeArray);
                    drinsite[1] = dataLenth;

                    //資料起始位置
                    drinsite[2] = dataStartSite;
                    //擷取電文
                    try
                    {
                        drinsite[3] = telstrings.Substring(dataStartSite - 1, dataLenth);
                    }
                    catch (Exception)
                    {
                        ShowStatusMessage("telToShort");
                    }

                    int colum = 4;//若無比對電文從4開始
                    if (Compare_ckb.Checked)
                    {
                        try
                        {
                            drinsite[4] = Comparetelstrings.Substring(dataStartSite - 1, dataLenth);
                        }
                        catch (Exception)
                        {
                            ShowStatusMessage("ComparetelToShort");
                        }

                        colum = 5;//有比對電文從5開始
                    }

                    for (int j = 0; j < item.Count; j++)
                    {
                        drinsite[colum + j] = item[j].ToString();
                    }
                    dt.Rows.Add(drinsite);
                    dataGridView1.DataSource = dt;
                    dataStartSite += dataLenth;
                }
            }
            return dataStartSite;
        }

        int handleSingleData(OleDbDataReader drSheetA, DataTable dt, int seqno, int dataStartSite)
        {
            DataRow dr = dt.NewRow();
            //計算處理進度
            int completepersent = (seqno * 100) / (dataTatalCount + 1);
            if (completepersent > 100)
            {
                progressBar1.Value = 100;
            }
            else
            {
                progressBar1.Value = completepersent;
            }
            //序號
            dr[0] = seqno.ToString();

            //資料長度(get dataType)
            int test = (int)dataTypesit_counter.Value - 1;
            string[] objChangeArray = { drSheetA[(int)dataTypesit_counter.Value - 1].ToString() };
            int dataLenth = reSite(objChangeArray);
            dr[1] = dataLenth;

            //資料起始位置
            dr[2] = dataStartSite;

            //取電文
            try
            {
                dr[3] = telstrings.Substring(dataStartSite - 1, dataLenth);
            }
            catch (Exception)
            {
                ShowStatusMessage("GetTelStringError");
                return 0;
            }

            if (Compare_ckb.Checked)
            {
                try
                {
                    dr[4] = Comparetelstrings.Substring(dataStartSite - 1, dataLenth);
                }
                catch (Exception)
                {
                    ShowStatusMessage("GetCompareTelStringError");
                    return 0;
                }
            }

            //20180203
            if (Compare_ckb.Checked)
            {
                for (int j = 0; j < drSheetA.FieldCount; j++)
                {
                    dr[5 + j] = drSheetA[j].ToString();
                }
            }
            else
            {
                for (int j = 0; j < drSheetA.FieldCount; j++)
                {
                    dr[4 + j] = drSheetA[j].ToString();
                }
            }

            dt.Rows.Add(dr);
            dataGridView1.DataSource = dt;
            dataStartSite += dataLenth;
            return dataStartSite;
        }

        //bool ChangWords = false;//有無轉換中文字串長度    20180203
        private void telString_txt_TextChanged(object sender, EventArgs e)
        {
            string TelStringChengeTxtName = ((TextBox)sender).Name;
            switch (TelStringChengeTxtName)
            {
                case "telString_txt":
                    TelGroup.Text = string.Format("電文字串(.txt)  長度：{0}", HandleString(telString_txt.Text).Length);
                    break;
                case "ComparetelString_txt":
                    CompareTelGroup.Text = string.Format("比對電文字串(.txt)  長度：{0}", HandleString(ComparetelString_txt.Text).Length);
                    break;
                default:
                    break;
            }
            //if (telString_txt.Text != null && telString_txt.Text != "")
            //{
            //    //StartToRead_btn.Enabled = true;     20180203
            //    //ChangWords = true;
            //}
            //else
            //{
            //    telstrings = "";
            //    txtPath_lbl.Text = "";
            //    //StartToRead_btn.Enabled = false;     20180203
            //    //ChangWords = false;
            //    //OldtelStrings = "";      20180203
            //}
            enableSwitch();
        }


        private void button1_Click_1(object sender, EventArgs e)
        {
            StreamWriter sw = new StreamWriter("myTelString.txt");
            string myTel = OldtelStrings;//要啟動此區塊 要搜尋"OldtelStrings"
            //sw.Write(HandleString());
            sw.Write(myTel);
            sw.Close();
        }

        private void SheetName_txt_TextChanged(object sender, EventArgs e)
        {
            //if (SheetName_txt.Text != "")
            //{
            //    /*步驟1：設定Excel的屬性、路徑*/

            //    //顯示"處理中"狀態
            //    ShowStatusMessage("Handling");
            //    string getFileName = getExcelFileName;

            //    /*步驟2：依照Excel的屬性及路徑開啟檔案*/
            //    //Excel路徑及相關資訊匯入
            //    OleDbConnection GetXLS = new OleDbConnection(strCon);

            //    //打開檔案
            //    try
            //    {
            //        GetXLS.Open();
            //        ExcelPath_lbl.Text = getFileName;
            //    }
            //    catch (Exception)
            //    {
            //        ShowStatusMessage("openExcelErrro");
            //        ShowStatusMessage("NonExcelPath");
            //        return;
            //    }


            //    /*步驟3：搜尋此Excel的所有工作表，找到特定工作表進行讀檔，並將其資料存入List*/

            //    //搜尋xls的工作表(工作表名稱需要加$字串)
            //    DataTable Table = GetXLS.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null);

            //    //查詢此Excel所有的工作表名稱
            //    string SelectSheetName = "";
            //    foreach (DataRow row in Table.Rows)
            //    {
            //        //抓取Xls各個Sheet的名稱(+'$')-有的名稱需要加名稱''，有的不用
            //        SelectSheetName = (string)row["TABLE_NAME"];
            //        //SelectSheetName = (string)row["sheet1$"];

            //        SelectSheetName = SelectSheetName.Replace("\'", "").Replace("$", "");
            //        //工作表名稱有特殊字元、空格，需加'工作表名稱$'，ex：'Sheet_A$'
            //        //工作表名稱沒有特殊字元、空格，需加工作表名稱$，ex：SheetA$
            //        //所有工作表名稱為Sheet1，讀取此工作表的內容
            //        if (SelectSheetName == SheetName_txt.Text)
            //        {
            //            //select 工作表名稱
            //            OleDbCommand cmSheetA = new OleDbCommand(" SELECT * FROM [" + SheetName_txt.Text + "$] ", GetXLS);
            //            OleDbDataReader drSheetA = cmSheetA.ExecuteReader();

            //            //讀取工作表SheetA資料
            //            //drSheetA.Read();//讀一行

            //            //清除下拉選單讀取到的頁籤名稱
            //            DataType_cbx.Text = "";
            //            Occ_cbx.Text = "";
            //            DataType_cbx.Items.Clear();
            //            Occ_cbx.Items.Clear();

            //            drSheetA.Read();
            //            //取出標題名稱
            //            for (int i = 0; i < drSheetA.FieldCount; i++)
            //            {
            //                ////2018/02/07  讀取欄位部分有值但是讀取出來為""，故註解
            //                //if (drSheetA[i].ToString() != "" && drSheetA[i] != null)
            //                //{
            //                //    DataType_cbx.Items.Add(drSheetA[i]);
            //                //    Occ_cbx.Items.Add(drSheetA[i]);
            //                //}
            //                DataType_cbx.Items.Add(drSheetA[i]);
            //                Occ_cbx.Items.Add(drSheetA[i]);
            //            }
            //            ExcelColCount = drSheetA.FieldCount;

            //            //讀一次EXCEL內容得到所有資料筆數
            //            while (drSheetA.Read())
            //            {
            //                int dataCount = 1;
            //                //讀取工作表SheetA資料
            //                List<string> ListSheetA = new List<string>();
            //                while (drSheetA.Read())
            //                {
            //                    dataTatalCount = dataCount;
            //                    dataCount++;
            //                }
            //            }
            //            //---------------------------------------------------------------------------------------------------
            //            /*步驟4：關閉檔案*/

            //            //結束關閉讀檔(必要，不關會有error)
            //            drSheetA.Close();
            //            GetXLS.Close();
            //            ShowStatusMessage("Handle end");
            //        }
            //        else
            //        {
            //            //尚未開啟任何頁籤
            //            ShowStatusMessage("ExcelNotOpen");
            //            SheetName_cbx.Text = "請選擇要讀取的頁籤";
            //        }
            //    }
            //}
            //enableSwitch();
        }

        void readExcelString(string OpeningExcel)
        {
            //string returnString="";
            string test = getExcelFileName;
            switch (OpeningExcel)
            {
                case ".xlsx":
                    strCon =
                        "provider = Microsoft.ACE.OLEDB.12.0; data source = @\"...\\" +
                        //路徑(檔案讀取路徑)
                        getExcelFileName +
                        //選擇Excel版本
                        "; Extended Properties = 'Excel 12.0;" +
                        //開頭是否為資料
                        "HDR=No;" +
                        //IMEX=1 為「匯入模式」，能對檔案進行讀取的動作。
                        //-----------------------------------------------
                        //"IMEX=1;"
                        //+"ImportMixedTypes=Text;TypeGuessRows=0'";
                        //-----------------------------------------------
                        "IMEX=1;'";
                    //"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + getExcelFileName + "'Extended Properties='Excel 12.0;HDR=No'";
                    break;
                case ".xls"://97 - 2007Excel
                            //設定讀取的Excel屬性
                    strCon = "Provider=Microsoft.Jet.OLEDB.4.0;" +

                    //路徑(檔案讀取路徑)
                    "Data Source =  @\"...\\" + getExcelFileName + ";" +

                    //選擇Excel版本
                    //Excel 12.0 針對Excel 2010、2007版本(OLEDB.12.0)
                    //Excel 8.0 針對Excel 97-2003版本(OLEDB.4.0)
                    //Excel 5.0 針對Excel 97(OLEDB.4.0)
                    "Extended Properties='Excel 8.0;" +

                    //開頭是否為資料
                    //若指定值為 Yes，代表 Excel 檔中的工作表第一列是欄位名稱，oleDB直接從第二列讀取
                    //若指定值為 No，代表 Excel 檔中的工作表第一列就是資料了，沒有欄位名稱，oleDB直接從第一列讀取
                    "HDR=NO;" +

                    //IMEX=0 為「匯出模式」，能對檔案進行寫入的動作。
                    //IMEX=1 為「匯入模式」，能對檔案進行讀取的動作。
                    //IMEX=2 為「連結模式」，能對檔案進行讀取與寫入的動作。
                    //-----------------------------------------------
                    //"IMEX=1" +
                    //"ImportMixedTypes = Text; TypeGuessRows = 0'";
                    //-----------------------------------------------
                    "IMEX=1'";
                    break;
                case "xlsx"://2010Excel
                    strCon =
                        "provider = Microsoft.ACE.OLEDB.12.0; data source = " +
                        //路徑(檔案讀取路徑)
                        getExcelFileName +
                        //選擇Excel版本
                        "; Extended Properties = 'Excel 12.0;" +
                        //開頭是否為資料
                        "HDR=No;" +
                        //IMEX=1 為「匯入模式」，能對檔案進行讀取的動作。
                        //-----------------------------------------------
                        //"IMEX=1;"
                        //+"ImportMixedTypes=Text;TypeGuessRows=0'";
                        //-----------------------------------------------
                        "IMEX=1;'";
                    //"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + getExcelFileName + "'Extended Properties='Excel 12.0;HDR=No'";
                    break;
                case "xls"://97 - 2007Excel
                           //設定讀取的Excel屬性
                    strCon = "Provider=Microsoft.Jet.OLEDB.4.0;" +

                    //路徑(檔案讀取路徑)
                    "Data Source=" + getExcelFileName + ";" +

                    //選擇Excel版本
                    //Excel 12.0 針對Excel 2010、2007版本(OLEDB.12.0)
                    //Excel 8.0 針對Excel 97-2003版本(OLEDB.4.0)
                    //Excel 5.0 針對Excel 97(OLEDB.4.0)
                    "Extended Properties='Excel 8.0;" +

                    //開頭是否為資料
                    //若指定值為 Yes，代表 Excel 檔中的工作表第一列是欄位名稱，oleDB直接從第二列讀取
                    //若指定值為 No，代表 Excel 檔中的工作表第一列就是資料了，沒有欄位名稱，oleDB直接從第一列讀取
                    "HDR=NO;" +

                    //IMEX=0 為「匯出模式」，能對檔案進行寫入的動作。
                    //IMEX=1 為「匯入模式」，能對檔案進行讀取的動作。
                    //IMEX=2 為「連結模式」，能對檔案進行讀取與寫入的動作。
                    //-----------------------------------------------
                    //"IMEX=1" +
                    //"ImportMixedTypes = Text; TypeGuessRows = 0'";
                    //-----------------------------------------------
                    "IMEX=1'";
                    break;
                default:

                    break;
            }
            //return returnString;
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            CompareTelGroup.Enabled = Compare_ckb.Checked;
            CompareName_lbl.Visible = Compare_ckb.Checked;
            ComparetxtPath_lbl.Visible = Compare_ckb.Checked;
            dataGridView1.DataSource = "";
            enableSwitch();
        }

        private void ExcelPath_lbl_MouseHover(object sender, EventArgs e)
        {
            string hoverLableName = ((Label)sender).Name;
            switch (hoverLableName)
            {
                case "ExcelPath_lbl":
                    toolTip1.Show(ExcelPath_lbl.Text, ExcelPath_lbl);
                    break;
                case "txtPath_lbl":
                    toolTip1.Show(txtPath_lbl.Text, ExcelPath_lbl);
                    break;
                case "ComparetxtPath_lbl":
                    toolTip1.Show(ComparetxtPath_lbl.Text, ExcelPath_lbl);
                    break;
                default:
                    break;
            }
        }

        private void ShowTelString_btn_Click(object sender, EventArgs e)
        {
            //進度條歸零
            progressBar1.Value = 0;
            string clickbtnName = ((Button)sender).Name;
            switch (clickbtnName)
            {
                case "ShowTelString_btn":
                    if (!TelWindowOpening)
                    {
                        StringHandle.TelString telStringWindow = new TelString();
                        telStringWindow.GetTelStrings = telString_txt.Text;
                        telStringWindow.GetTelPath = txtPath_lbl.Text;
                        //在 A 視窗開啟 B 視窗的事件中綁定指定的委派事件，傳入事件觸發後委派所要回調的方法
                        telStringWindow.ReturnValueCallback += new TelString.ReturnValueDelegate(this.SetReturnValueCallbackFun);

                        telStringWindow.Show();
                        TelWindowOpening = true;
                    }
                    break;
                case "ShowCompareTelString_btn":
                    if (!CompareTelWindowOpening)
                    {
                        StringHandle.CompareTelString CompareTelStringWindow = new CompareTelString();
                        CompareTelStringWindow.getCompareTelStrings = ComparetelString_txt.Text;
                        CompareTelStringWindow.GetCompareTelPath = ComparetxtPath_lbl.Text;
                        //在 A 視窗開啟 B 視窗的事件中綁定指定的委派事件，傳入事件觸發後委派所要回調的方法
                        CompareTelStringWindow.ReturnValueCallback += new CompareTelString.ReturnValueDelegate(this.CompareWindowSetReturnValueCallbackFun);

                        CompareTelStringWindow.Show();
                        CompareTelWindowOpening = true;
                    }

                    break;
                default:
                    break;
            }
            enableSwitch();
        }
        //接收telStringWindow字串
        private void SetReturnValueCallbackFun(string getTelPathfromWindow, string getFromTelStringWindowString, bool OpenStatus)
        {
            telString_txt.Text = getFromTelStringWindowString;
            telstrings = getFromTelStringWindowString;//2018 05 11 test
            txtPath_lbl.Text = getTelPathfromWindow;
            TelWindowOpening = OpenStatus;
            //telstrings = getFromTelStringWindowString;
        }

        //接收ComparetelStringWindow字串
        private void CompareWindowSetReturnValueCallbackFun(string getCompareTelPathfromWindow, string getFromTelStringWindowString, bool OpenStatus)
        {
            ComparetelString_txt.Text = getFromTelStringWindowString;
            Comparetelstrings = getFromTelStringWindowString;//2018 05 11 test
            ComparetxtPath_lbl.Text = getCompareTelPathfromWindow;
            CompareTelWindowOpening = OpenStatus;
            //Comparetelstrings = getFromTelStringWindowString;
        }

        private void ByteTransfer_Click(object sender, EventArgs e)
        {
            StringHandle.ByteTransfer ByteTransfer = new ByteTransfer();
            //在 A 視窗開啟 B 視窗的事件中綁定指定的委派事件，傳入事件觸發後委派所要回調的方法
            ByteTransfer.ReturnValueCallback += new ByteTransfer.ReturnValueDelegate(this.TransferWindowSetReturnValueCallbackFun);

            ByteTransfer.Show();
        }
        //接收ComparetelStringWindow字串
        private void TransferWindowSetReturnValueCallbackFun(string getFromTransferStringWindowString)
        {

        }

        //Converts the DataGridView to DataTable  
        public static DataTable DataGridView2DataTable(DataGridView dgv, String tblName = "", int minRow = 0)
        {
            DataTable dt = new DataTable();
            if (dgv.Columns.Count <= 0)
            {
                MessageBox.Show("沒資料轉什麼轉?", "犯傻了嗎?");
                return dt;
            }
            // Header columns  
            foreach (DataGridViewColumn column in dgv.Columns)
            {
                //DataColumn dc = new DataColumn(column.Name.ToString());  
                DataColumn dc = new DataColumn(column.HeaderText.ToString());
                dt.Columns.Add(dc);
            }
            // Data cells  
            for (int i = 0; i < dgv.Rows.Count; i++)
            {
                DataGridViewRow row = dgv.Rows[i];
                DataRow dr = dt.NewRow();
                for (int j = 1; j < dgv.Columns.Count; j++)//要顯示幾欄(從左邊數起)
                {
                    dr[j] = (row.Cells[j].Value == null) ? "" : row.Cells[j].Value.ToString();
                }
                dt.Rows.Add(dr);
            }
            // Related to the bug arround min size when using ExcelLibrary for export  
            for (int i = dgv.Rows.Count; i < minRow; i++)
            {
                DataRow dr = dt.NewRow();
                for (int j = 0; j < dt.Columns.Count; j++)
                {
                    dr[j] = " ";
                }
                dt.Rows.Add(dr);
            }
            return dt;
        }
        private void ReturnExcel_Click(object sender, EventArgs e)
        {
            //進度條歸零
            progressBar1.Value = 0;

            saveFileDialog1.Filter = "xls Files|*.xls";
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                //建立Excel 2003檔案
                IWorkbook wb = new HSSFWorkbook();
                ISheet ws;
                ////建立Excel 2007檔案
                //IWorkbook wb = new XSSFWorkbook();
                //ISheet ws;

                //dataGrigview 轉 dataTable
                DataTable dt = DataGridView2DataTable(dataGridView1);
                if (dt.Columns.Count <= 0)
                {
                    return;
                }
                if (dt.TableName != string.Empty)
                {
                    ws = wb.CreateSheet(dt.TableName);
                }
                else
                {
                    ws = wb.CreateSheet("Sheet1");
                }

                ws.CreateRow(0);//第一行為欄位名稱
                for (int i = 0; i < dt.Columns.Count; i++)
                {
                    ws.GetRow(0).CreateCell(i).SetCellValue(dt.Columns[i].ColumnName);
                }

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    ws.CreateRow(i + 1);
                    for (int j = 1; j < dt.Columns.Count; j++)
                    {
                        ws.GetRow(i + 1).CreateCell(0).SetCellValue(i + 1);
                        ws.GetRow(i + 1).CreateCell(j).SetCellValue(dt.Rows[i][j].ToString());
                    }
                }

                //FileStream file = new FileStream(@"..\testExcel.xls", FileMode.Create);//產生檔案
                string fileName = saveFileDialog1.FileName;
                if (fileName.IndexOf('.') != -1)
                {
                    fileName = (fileName.Split('.'))[0];
                }
                fileName = String.Format("{0}.xls", fileName);

                FileStream file = new FileStream(fileName, FileMode.Create);//產生檔案

                wb.Write(file);
                file.Close();
                ShowStatusMessage("SaveExcelEnd");
            }
        }

        private void dataGridView1_DragOver(object sender, DragEventArgs e)
        {
            DataType_cbx.Text = "";
            Occ_cbx.Text = "";
            SheetName_cbx.Items.Clear();
            Occ_cbx.Items.Clear();
            // 判斷
            // 1. 是否有拖曳物件
            // 2. 該物件是否無 txt 檔案
            // 3. 是不是 DataFormats.FileDrop
            bool fileformatCheck = e.Data.GetDataPresent(DataFormats.FileDrop);
            string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);
            if (fileformatCheck == false ||
               files == null || files.Length == 0 ||
               (Path.GetExtension(files[0]).ToUpperInvariant() != ".XLSX" && Path.GetExtension(files[0]).ToUpperInvariant() != ".XLS"))
            {
                // 當 e.Effect = DragDropEffects.None 時，DragDrop 事件不會被觸發
                e.Effect = DragDropEffects.None;
            }
            else
            {
                // 當 e.Effect = DragDropEffects.Copy （非DragDropEffects.None）時，DrapDrop 事件會被觸發，且 TextBox 上的拖曳符號會變成 +
                e.Effect = DragDropEffects.Copy;


                //顯示"處理中"狀態
                ShowStatusMessage("Handling");
                getExcelFileName = files[0];
                string[] ExcelNameString = getExcelFileName.Split('.');

                /*步驟1：讀取開啟Excel連結字串*/
                readExcelString(ExcelNameString[1]);

                /*步驟2：依照Excel的屬性及路徑開啟檔案*/

                //Excel路徑及相關資訊匯入
                OleDbConnection GetXLS = new OleDbConnection(strCon);

                //打開檔案
                try
                {
                    GetXLS.Open();
                    ExcelPath_lbl.Text = getExcelFileName;
                }
                catch (Exception ex)
                {
                    Console.WriteLine("開啟Excel失敗訊息:\n" + ex);
                    ShowStatusMessage("openExcelErrro");
                    ShowStatusMessage("NonExcelPath");
                    enableSwitch();
                    return;
                }


                /*步驟3：搜尋此Excel的所有工作表，找到特定工作表進行讀檔，並將其資料存入List*/
                //搜尋xls的工作表(工作表名稱需要加$字串)
                DataTable Table = GetXLS.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null);

                //查詢此Excel所有的工作表名稱
                string SelectSheetName = "";
                foreach (DataRow row in Table.Rows)
                {
                    //抓取Xls各個Sheet的名稱(+'$')-有的名稱需要加名稱''，有的不用
                    SelectSheetName = (string)row["TABLE_NAME"];
                    //SelectSheetName = (string)row["sheet1$"];

                    SelectSheetName = SelectSheetName.Replace("\'", "").Replace("$", "");
                    //string[] ReadSheetName = SelectSheetName.Split('\'');
                    SheetName_cbx.Items.Add(SelectSheetName);
                }

                SheetName_cbx.Text = "請選擇讀取的excel頁籤";
                ShowStatusMessage("Handle end");
                enableSwitch();
                GetXLS.Close();
            }
        }

        private void StringHandleMainPage_FormClosed(object sender, FormClosedEventArgs e)
        {
            //MessageBox.Show("確定要結束程式?", "關閉訊息");
        }

        Encoding CheckCoding(StreamReader ReadTelStrings)
        {
            Encoding CodingString = ReadTelStrings.CurrentEncoding;//UTF-8 >>> System.Text.UTF8Encoding
            return CodingString;
        }

        private void openExcel_btn_Click(object sender, EventArgs e)
        {

        }

        //string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);        
        //getExcelFileName = files[0];
        //string[] ExcelNameString = getExcelFileName.Split('.');
        void openExcel(string ExcelNameString)
        {
            //顯示"處理中"狀態
            ShowStatusMessage("Handling");
            getExcelFileName = ExcelNameString;//檔案名稱
            /*步驟1：讀取開啟Excel連結字串*/
            readExcelString("xlsx");//依照Excel副檔名取得開啟方式
            /*步驟2：依照Excel的屬性及路徑開啟檔案*/

            //Excel路徑及相關資訊匯入
            OleDbConnection GetXLS = new OleDbConnection(strCon);

            //打開檔案
            try
            {
                GetXLS.Open();
                ExcelPath_lbl.Text = getExcelFileName;
            }
            catch (Exception ex)
            {
                Console.WriteLine("開啟Excel失敗訊息:\n" + ex);
                ShowStatusMessage("openExcelErrro");
                ShowStatusMessage("NonExcelPath");
                enableSwitch();
                return;
            }


            /*步驟3：搜尋此Excel的所有工作表，找到特定工作表進行讀檔，並將其資料存入List*/

            //搜尋xls的工作表(工作表名稱需要加$字串)
            DataTable Table = GetXLS.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null);

            //查詢此Excel所有的工作表名稱
            string SelectSheetName = "";
            foreach (DataRow row in Table.Rows)
            {
                //抓取Xls各個Sheet的名稱(+'$')-有的名稱需要加名稱''，有的不用
                SelectSheetName = (string)row["TABLE_NAME"];
                //SelectSheetName = (string)row["sheet1$"];

                SelectSheetName = SelectSheetName.Replace("\'", "").Replace("$", "");
                //string[] ReadSheetName = SelectSheetName.Split('\'');
                SheetName_cbx.Items.Add(SelectSheetName);
            }

            SheetName_cbx.Text = "請選擇讀取的excel頁籤";
            ShowStatusMessage("Handle end");
            enableSwitch();
            GetXLS.Close();
        }

        //test
        void openExcel(string ExcelNameString, string inital)
        {
            /*步驟1：讀取開啟Excel連結字串*/
            readExcelString("xls");//依照Excel副檔名取得開啟方式
            /*步驟2：依照Excel的屬性及路徑開啟檔案*/

            //Excel路徑及相關資訊匯入
            OleDbConnection GetXLS = new OleDbConnection(strCon);

            //打開檔案
            try
            {
                GetXLS.Open();
                ExcelPath_lbl.Text = getExcelFileName;
            }
            catch (Exception ex)
            {
                return;
            }

            GetXLS.Close();
        }

        private void ReadExcelTelName_cbx_TextChanged(object sender, EventArgs e)
        {
            if (ReadExcelTelName_cbx.Text != "")
            {
                ShowStatusMessage("PressReadExcel");
                StartToRead_btn.Enabled = false;
            }
        }

        private void ReadExcelTelName_cbx_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ReadExcelTelName_cbx.Text != "")
            {
                ShowStatusMessage("PressReadExcel");
                StartToRead_btn.Enabled = false;
            }
        }

        private void openExcel_btn_Click_1(object sender, EventArgs e)
        {
            string cbx_text = ReadExcelTelName_cbx.Text;
            if (cbx_text == "")
            {
                return;
            }
            Hashtable ht = new Hashtable();
            Hashtable Check_ht = new Hashtable();
            List<string> FirstPreAddDatas = new List<string>();
            FirstPreAddDatas.Add(cbx_text);
            ht.Add(0, FirstPreAddDatas);

            for (int i = 0; i < ReadExcelTelName_cbx.Items.Count; i++)
            {
                List<string> PreAddDatas = new List<string>();
                string PreAdddData = ReadExcelTelName_cbx.Items[i].ToString();
                PreAddDatas.Add(PreAdddData);
                ht.Add(i + 1, PreAddDatas);
                Check_ht.Add(PreAdddData, PreAdddData);
            }

            if (!Check_ht.Contains(cbx_text) && CreateExcelMethod("MyTelsData2", ht))//檢查是否有在下拉選單內 && 寫入Excel成功
            {
                //寫入成功
            }
            else
            {
                //寫入失敗
            }
        }

        private void DeleteIitemExcel_btn_Click(object sender, EventArgs e)
        {
            string selectText = DeleteItem_cbx.SelectedItem.ToString();
            string preDeleteItem = DeleteItem_cbx.Text;
            Hashtable ht = new Hashtable();
            int preAddKeyNumber = 0;
            for (int i = 0; i < ReadExcelTelName_cbx.Items.Count; i++)
            {
                List<string> PreAddDatas = new List<string>();
                string PreAdddData = ReadExcelTelName_cbx.Items[i].ToString();
                if (PreAdddData != preDeleteItem)
                {
                    PreAddDatas.Add(PreAdddData);
                    ht.Add(preAddKeyNumber, PreAddDatas);
                    preAddKeyNumber++;
                }
            }

            if (preDeleteItem != "" && CreateExcelMethod("MyTelsData", ht))//檢查是否有在下拉選單內 && 寫入Excel成功
            {
                //寫入成功
            }
            else
            {
                //寫入失敗
            }
        }

        int ReadThisData(string ColString, OleDbDataReader drSheetA, int lines)
        {
            if (ExcelPath_lbl.Text.IndexOf("TelExcelFile") != -1)//自動讀取
            {
                string InOrOut = ReadExcelTelName_cbx.Text.Substring(6, 1).ToLower();
                if ((InOrOut == "i" && ColString == "RX") || (InOrOut == "o" && ColString == "TX"))
                {
                    try
                    {
                        drSheetA.Read();
                        return ReadThisData(drSheetA[1].ToString(), drSheetA, lines + 1);
                    }
                    catch (Exception)
                    {
                        return -1;
                    }
                }
            }
            return lines;
        }
    }
}
