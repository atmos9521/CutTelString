using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StringHandle
{
    public static class ConvertByte
    {
        public static string HEXtoUTF8(string BeforeTransfer)
        {
            string AfterTransfer = "";
            try
            {
                ////16進位字串
                string String16 = BeforeTransfer;
                string[] String16split = String16.Split('\'');
                string UTF8String = String16split[0]; ;
                int test1 = String16split.Length;
                int test2 = String16split.Count();

                int outboundstring = String16.IndexOf("outboundTelegram=");
                int inboundstring = String16.IndexOf("inboundTelegram=");
                int outboundString = String16.IndexOf("outboundString=");
                int inboundString = String16.IndexOf("inboundString=");
                if (outboundstring > 0)
                {
                    UTF8String = TransferVoid(String16split[1]);
                    AfterTransfer = UTF8String.Substring(155);
                }
                else if (inboundstring > 0)
                {
                    UTF8String = TransferVoid(String16split[1]);
                    AfterTransfer = UTF8String.Substring(157);
                }
                else if (outboundString > 0)
                {
                    UTF8String = String16split[1];
                    AfterTransfer = UTF8String.Substring(157);
                }
                else if (inboundString > 0)
                {
                    UTF8String = String16split[1];
                    AfterTransfer = UTF8String.Substring(157);
                }
                else
                {
                    AfterTransfer = UTF8String;
                }
            }
            catch (Exception)
            {
                AfterTransfer = "轉型失敗";
            }
            return AfterTransfer;
        }

        public static string TransferVoid(string HexStrings)
        {
            //16進位字串轉換為位元組陣列
            byte[] my16StringBytes = ConvertByte.HexToByte(HexStrings);
            string UTF8String = Encoding.UTF8.GetString(my16StringBytes);
            return UTF8String;
        }

        //1.16進位數字組成的字串轉換為Byte[]
        public static byte[] HexToByte(this string hexString)
        {
            //運算後的位元組長度:16進位數字字串長/2
            byte[] byteOUT = new byte[hexString.Length / 2];
            for (int i = 0; i < hexString.Length; i = i + 2)
            {
                //每2位16進位數字轉換為一個10進位整數
                byteOUT[i / 2] = Convert.ToByte(hexString.Substring(i, 2), 16);
            }
            return byteOUT;
        }

        //2.Byte[]轉換為16進位數字字串

        public static string BToHex(this byte[] Bdata)
        {
            return BitConverter.ToString(Bdata).Replace("-", "");
        }

        //3.取出字串右邊開始的指定數目字元
        //取出字串右邊開始的指定數目字元
        public static string Right(this string str, int len)
        {
            return str.Substring(str.Length - len, len);
        }
        //取出字串右邊開始的指定數目字元(跳過幾個字元)
        public static string Right(this string str, int len, int skiplen)
        {
            return str.Substring(str.Length - len - skiplen, len);
        }
    }
}
