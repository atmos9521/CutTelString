using NPOI.HSSF.UserModel;
using NPOI.SS.UserModel;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StringHandle
{
    public static class ExcelControl
    {
        public struct ExcelDataStruct
        {
            public ExcelDataStruct(int intValue, List<string> strValue)
            {
                Key = intValue;
                StringData = strValue;
            }

            public int Key { get; set; }
            public List<string> StringData { get; set; }
        }

        //Excel連接字串
        static string ReadExcelString(string OpeningExcel, string ExcelFullFileName)
        {
            string ConnectExcelString = "";
            switch (OpeningExcel)
            {
                case ".xlsx":
                    ConnectExcelString =
                        "provider = Microsoft.ACE.OLEDB.12.0; data source = " +
                        //路徑(檔案讀取路徑)
                        ExcelFullFileName +
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
                    ConnectExcelString = "Provider=Microsoft.Jet.OLEDB.4.0;" +

                    //路徑(檔案讀取路徑)
                    "Data Source =  " + ExcelFullFileName + ";" +

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
                    ConnectExcelString =
                        "provider = Microsoft.ACE.OLEDB.12.0; data source = " +
                        //路徑(檔案讀取路徑)
                        ExcelFullFileName +
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
                    ConnectExcelString = "Provider=Microsoft.Jet.OLEDB.4.0;" +

                    //路徑(檔案讀取路徑)
                    "Data Source=" + ExcelFullFileName + ";" +

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
            return ConnectExcelString;
        }

        //取得Excel內某行的值
        public static List<string> getExceloneData(List<ExcelDataStruct> ExcelData, int Lines)
        {
            var ExcelOneLineData = from OutPutExcelData in ExcelData
                                   where OutPutExcelData.Key == Lines
                                   select OutPutExcelData.StringData;
            return ExcelOneLineData.Single();
        }

        //Excel 頁籤:SheetName內的資料
        public static bool NewOpenExcelMethod(string OpenExcelFileName, string SheetName, out Hashtable ExcelData)
        {
            ExcelData = null;
            bool OpenExcelResult = false;//是否成功開啟
            /*步驟1：讀取開啟Excel連結字串*/
            string ConnectExcelString = "";
            if (OpenExcelFileName.IndexOf('.') != -1)
            {
                string ExcelType = (OpenExcelFileName.Split('.'))[1];
                /*步驟2：依照Excel的屬性及路徑開啟檔案*/
                //Excel路徑及相關資訊匯入
                ConnectExcelString = ReadExcelString(string.Format(".{0}", ExcelType), OpenExcelFileName);
                OleDbConnection GetXLS = new OleDbConnection(ConnectExcelString);
                //"Provider=Microsoft.Jet.OLEDB.4.0;Data Source =  @\"...\\ExcelDataBase\\MyTelsData\\MyTelsData.xls;Extended Properties='Excel 8.0;HDR=NO;IMEX=1'"
                //打開檔案
                try
                {
                    GetXLS.Open();
                    ExcelData = ReadExcel(GetXLS, SheetName);//儲存該Excel頁籤所有資料
                    OpenExcelResult = true;
                }
                catch (Exception ex)
                {
                    //無法開啟Excel
                    Console.WriteLine(string.Format("無法開啟Excel:/n{0}", ex));
                }
                finally
                {
                    GetXLS.Close();
                }
            }
            else
            {
                //檔案沒有副檔名
                Console.WriteLine(string.Format("無法開啟Excel:/n{0}", "檔案沒有副檔名"));
            }

            return OpenExcelResult;
        }

        //取得Excel內所有資料
        public static Hashtable ReadExcel(OleDbConnection GetXLS, string SheetName)
        {
            Hashtable ht = new Hashtable();
            List<ExcelDataStruct> ExcelDatas = new List<ExcelDataStruct>();
            /*步驟3：搜尋此Excel的所有工作表，找到特定工作表進行讀檔，並將其資料存入List*/
            //搜尋xls的工作表(工作表名稱需要加$字串)
            DataTable Table = GetXLS.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null);
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
                if (SelectSheetName == SheetName)
                {
                    //select 工作表名稱
                    OleDbCommand cmSheetA = new OleDbCommand(" SELECT * FROM [" + SheetName + "$] ", GetXLS);
                    OleDbDataReader drSheetA = cmSheetA.ExecuteReader();

                    //讀取工作表SheetA資料
                    int dataCount = 0;//行數 = 第幾筆資料
                                      //讀取工作表SheetA資料                            
                    while (drSheetA.Read())
                    {
                        List<string> ColDatas = new List<string>();
                        for (int i = 0; i < drSheetA.FieldCount; i++)
                        {
                            ht.Add(dataCount, drSheetA[i]);
                        }
                        dataCount++;
                    }
                    //---------------------------------------------------------------------------------------------------
                    /*步驟4：關閉檔案*/

                    //結束關閉讀檔(必要，不關會有error)
                    drSheetA.Close();
                }
                else
                {
                    //尚未開啟任何頁籤
                    Console.WriteLine(string.Format("尚未開啟任何頁籤:/n{0}", ""));
                }
            }
            return ht;
        }

        //新增Excel
        public static bool CreateExcelMethod(string FileName, Hashtable ht)
        {
            if (ht == null)
            {
                return false;
            }
            try
            {
                //建立Excel 2003檔案
                IWorkbook wb = new HSSFWorkbook();
                ISheet ws;
                ////建立Excel 2007檔案
                //IWorkbook wb = new XSSFWorkbook();
                //ISheet ws;
                
                if (ht.Count <= 0)
                {
                    return false;
                }
                ws = wb.CreateSheet("Sheet1");

                for (int i = 0; i < ht.Count; i++)
                {
                    ws.CreateRow(i);
                    List<string> data = (List<string>)ht[i];
                    for (int j = 0; j < data.Count; j++)
                    {
                        ws.GetRow(i).CreateCell(j).SetCellValue(data[j]);
                    }
                }
                
                //FileStream file = new FileStream(@"..\testExcel.xls", FileMode.Create);//產生檔案
                string fileName = string.Format("ExcelDataBase\\MyTelsData\\{0}.xls", FileName);
                FileStream file = new FileStream(fileName, FileMode.Create);//產生檔案

                wb.Write(file);
                file.Close();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
