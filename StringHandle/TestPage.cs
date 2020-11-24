using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
//NPOI將檔案加入參考後引入
using NPOI;
using NPOI.HSSF;
using NPOI.HSSF.UserModel;
using NPOI.SS.UserModel;
using System.Data.OleDb;

namespace StringHandle
{
    public partial class TestPage : Form
    {
        public TestPage()
        {
            InitializeComponent();
        }

        private void Transfer16to2_Click(object sender, EventArgs e)
        {
            ////16進位字串
            string String16 = textBox1.Text;
            //16進位字串轉換為位元組陣列
            byte[] myBytes = ConvertByte.HexToByte(String16);
            textBox2.Text = myBytes.ToString();
        }

        private void Transfer2to16_Click(object sender, EventArgs e)
        {
            ////16進位字串
            string String16 = textBox1.Text;
            //16進位字串轉換為位元組陣列
            byte[] myBytes = ConvertByte.HexToByte(String16);
            textBox2.Text = myBytes.ToString();
        }
    }
}
