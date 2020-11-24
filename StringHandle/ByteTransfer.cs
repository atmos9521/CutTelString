using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StringHandle
{
    public partial class ByteTransfer : Form
    {
        public ByteTransfer()
        {
            InitializeComponent();
        }
        
        //首先要先在 B 視窗宣告一個委派供存放之後要呼叫的方法的指標
        public delegate void ReturnValueDelegate(string sendToMainPageTransferString);
        //接著繼續在 B 視窗宣告一個回調的事件
        public event ReturnValueDelegate ReturnValueCallback;

        //傳回給主畫面的值
        private void BeforeTransfer_TextChanged(object sender, EventArgs e)
        {
            ////16進位字串
            string String16 = BeforeTransfer.Text;
            //16進位字串轉換為位元組陣列
            byte[] my16StringBytes = ConvertByte.HexToByte(String16);
            string UTF8String = Encoding.UTF8.GetString(my16StringBytes);
            AfterTransfer.Text = UTF8String;
        }

        private void Transfer_Click(object sender, EventArgs e)
        {
            AfterTransfer.Text = ConvertByte.HEXtoUTF8(BeforeTransfer.Text);
        }
        
        private void StringToUTF8_Click(object sender, EventArgs e)
        {
            //string StringANSI = BeforeTransfer.Text;
            //byte[] byteArray = System.Text.Encoding.Default.GetBytes(StringANSI);
            //string UTF8String = Encoding.UTF8.GetString(byteArray);
            //AfterTransfer.Text = UTF8String;

            ////轉成正確的byte
            //byte[] unknow = Encoding.GetEncoding(28591).GetBytes(StringANSI);
            ////轉BIG5
            ////string Big5 = Encoding.GetEncoding(950).GetString(unknow);
            ////string UTF8StringReal = Encoding.UTF8.GetString(unknow);
            //int testnum = 0;
            
        }
    }
}
