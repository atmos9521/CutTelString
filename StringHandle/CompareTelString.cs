using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StringHandle
{
    public partial class CompareTelString : Form
    {
        public CompareTelString()
        {
            InitializeComponent();
        }
        public string getCompareTelStrings { get; set; }
        public string GetCompareTelPath { get; set; }
        private void CompareTelString_Load(object sender, EventArgs e)
        {
            CompareTelString_txt.Text = getCompareTelStrings;
        }

        //首先要先在 B 視窗宣告一個委派供存放之後要呼叫的方法的指標
        public delegate void ReturnValueDelegate(string CompareTelPath, string sendToMainPageTelString,bool IsOpening);
        //接著繼續在 B 視窗宣告一個回調的事件
        public event ReturnValueDelegate ReturnValueCallback;
        //回傳給主畫面的值
        private void CompareTelString_txt_TextChanged(object sender, EventArgs e)
        {
            string CompareTelStrings = ConvertByte.HEXtoUTF8(CompareTelString_txt.Text);
            ReturnValueCallback(GetCompareTelPath, CompareTelStrings, true);
        }

        private void CompareTelString_txt_DragDrop(object sender, DragEventArgs e)
        {
            // 已經在 DrapEnter 內進行防呆，DrapDrop 內就直接抓取資料
            string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);
            string filepath = files[0];
            FileStream fs = new FileStream(filepath, FileMode.Open, FileAccess.Read);
            // Encoding.Default 可以避免內容產生亂碼
            StreamReader sr = new StreamReader(fs, Encoding.Default);
            CompareTelString_txt.Text = sr.ReadToEnd();
        }

        private void CompareTelString_txt_DragOver(object sender, DragEventArgs e)
        {
            // 判斷
            // 1. 是否有拖曳物件
            // 2. 該物件是否無 txt 檔案
            // 3. 是不是 DataFormats.FileDrop
            bool fileformatCheck = e.Data.GetDataPresent(DataFormats.FileDrop);
            string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);
            if (fileformatCheck == false ||
               files == null || files.Length == 0 ||
               Path.GetExtension(files[0]).ToUpperInvariant() != ".TXT")
            {
                // 當 e.Effect = DragDropEffects.None 時，DragDrop 事件不會被觸發
                e.Effect = DragDropEffects.None;
            }
            else
            {
                // 當 e.Effect = DragDropEffects.Copy （非DragDropEffects.None）時，DrapDrop 事件會被觸發，且 TextBox 上的拖曳符號會變成 +
                e.Effect = DragDropEffects.Copy;
                GetCompareTelPath = files[0];
                string telstrings = "";
                string line = string.Empty;
                StreamReader ReadTelStrings = new StreamReader(files[0]);
                while ((line = ReadTelStrings.ReadLine()) != null)
                {
                    try
                    {
                        telstrings = string.Format(telstrings + "{0}", line);
                        CompareTelString_txt.Text = telstrings;
                        //ShowStatusMessage("GetTelString");
                        //txtPath_lbl.Text = getfilepath;
                    }
                    catch (Exception)
                    {
                        CompareTelString_txt.Text = "";
                        //ShowStatusMessage("GetTelStringError");

                        //ShowStatusMessage("NontxtPath");
                    }
                }
            }
        }

        private void CompareTelString_FormClosed(object sender, FormClosedEventArgs e)
        {
            string CompareTelStrings = ConvertByte.HEXtoUTF8(CompareTelString_txt.Text);
            ReturnValueCallback(GetCompareTelPath, CompareTelStrings, false);
        }
    }
}
