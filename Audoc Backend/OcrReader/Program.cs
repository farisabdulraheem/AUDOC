using System;
using System.IO;
using System.Drawing;
using Tesseract;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using System.Net.Http.Headers;

namespace OcrReader
{
    class Program
    {
        private const string UPLOAD_IMAGE = "http://www.teqso.in/ocr/imageupload.php";
        static void Main(string[] args)
        {

            //string path = @"C:\Users\faris\Documents\Visual Studio 2017\Projects\ConsoleApp3\ConsoleApp3\bin\Debug\hellocrop.png";
            string ogpath = @"C:\Users\faris\Documents\Visual Studio 2017\Projects\OcrReader\OcrReader\resource\input.png";
            Bitmap bgimage = new Bitmap(ogpath);
             UploadBitmapAsync(bgimage);

            //  Bitmap image = new Bitmap(path);
            List<Bitmap> image = new List<Bitmap>();
            ImageProccesingTools ob = new ImageProccesingTools();
            Bitmap im = ob.CropUnwantedBackground(bgimage);
            slice slicer = new slice();

            // Bitmap image = slicer.slicefn(im);
            image = slicer.slicefn(im);
            Program p1 = new Program();
            int i = 0;
            foreach (var t in image)
            {

                string val = GetText(t);
                Console.WriteLine(val);

                FileStream createFile = new FileStream(@"C:\Users\faris\Documents\Visual Studio 2017\Projects\OcrReader\OcrReader\bin\Debug\" + i + ".doc", FileMode.OpenOrCreate, FileAccess.Write);

                //save the image text in the text file 
                StreamWriter writeFile = new StreamWriter(createFile);


                writeFile.Write(string.Join(Environment.NewLine, val));
                writeFile.Close();

                i++;
            }

            int a = i - 1;
            doc obj = new doc();
            obj.docprocessing(a);
        }

        public static void UploadBitmapAsync(Bitmap bitmap)
        {
            System.Net.WebClient Client = new System.Net.WebClient();

            Client.Headers.Add("Content-Type", "binary/multi-part");

            byte[] result = Client.UploadFile("http://www.teqso.in/ocr/imageupload.php", "POST",
                                              @"C:\Users\faris\Documents\Visual Studio 2017\Projects\OcrReader\OcrReader\resource\input.png");

            string s = System.Text.Encoding.UTF8.GetString(result, 0, result.Length);
        }

        public static string GetText(Bitmap imgsource)
        {
            var ocrtext = string.Empty;
            using (var engine = new TesseractEngine(@"./tessdata", "eng", EngineMode.Default))
            {
                using (var img = PixConverter.ToPix(imgsource))
                {
                    using (var page = engine.Process(img))
                    {

                        //ocrtext = string.Format(page.GetText());
                        ocrtext = page.GetText();

                    }
                }
            }
            return ocrtext;
        }



    }
    
}
