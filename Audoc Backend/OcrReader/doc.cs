using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GemBox.Spreadsheet;
namespace OcrReader
{
    class doc
    {
       public void  docprocessing(int a)
        {

            SpreadsheetInfo.SetLicense("FREE-LIMITED-KEY");

            ExcelFile ef = new ExcelFile();
            ExcelWorksheet ws = ef.Worksheets.Add("Hello World");
            int i = 0;
            string[] heading = new string[a];

            string[] contenttext = new string[a];

            while (i < a)
            {
                int flag = 0;
                
                string[] text = System.IO.File.ReadAllLines(@"C:\Users\faris\Documents\Visual Studio 2017\Projects\OcrReader\OcrReader\bin\Debug\" + i + ".doc");

                foreach (string line in text)
                {
                    if (flag == 0)
                    {
                        heading[i] = line;
                        ws.Cells[0, i].Value = heading[i];
                        flag = 1;

                    }
                    else
                    {
                        contenttext[i] += line;
                    }
                    
                }

                ws.Cells[1,i].Value = contenttext[i];

                i++;

            }


            ef.Save("Hello World.xlsx");
        }



    }
}
