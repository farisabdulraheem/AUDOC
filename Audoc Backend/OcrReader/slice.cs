using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AForge.Imaging;
using AForge.Math.Geometry;
using AForge;
using System.Drawing;
using AForge.Imaging.Filters;

namespace OcrReader
{
    class slice
    { 
        public List<Bitmap> slicefn(Bitmap image)
        {
            // Open your image

            //  Bitmap image = (Bitmap)Bitmap.FromFile("C: \\Users\\faris\\Desktop\\work\\WindowsFormsApplication39\\WindowsFormsApplication39\\bin\\Debug\\result.png");
           
            List<cordinatemodal> cordinates = new List<cordinatemodal>();
            List<Bitmap> croppedimages = new List<Bitmap>();
            cordinates.Add(new cordinatemodal(0, 0, 561, 57));
            cordinates.Add(new cordinatemodal(0, 57, 669, 54));
            cordinates.Add(new cordinatemodal(0, 110, 667, 165));
            cordinates.Add(new cordinatemodal(0, 275, 663, 56));
            cordinates.Add(new cordinatemodal(0, 330, 664, 244));
            cordinates.Add(new cordinatemodal(674, 58, 279, 45));
            cordinates.Add(new cordinatemodal(953, 60, 270, 46));
            cordinates.Add(new cordinatemodal(674, 112, 276, 53));
            cordinates.Add(new cordinatemodal(953, 167, 270, 46));
            cordinates.Add(new cordinatemodal(674, 221, 276, 53));
            cordinates.Add(new cordinatemodal(950, 221, 270, 46));
            cordinates.Add(new cordinatemodal(674, 276, 276, 53));
            cordinates.Add(new cordinatemodal(953, 276, 270, 46));
           cordinates.Add(new cordinatemodal(670, 331, 270, 50));
            cordinates.Add(new cordinatemodal(950, 330, 276, 55));
            cordinates.Add(new cordinatemodal(953, 385, 276, 53));
            cordinates.Add(new cordinatemodal(950, 438, 276, 53));
            cordinates.Add(new cordinatemodal(950, 492, 276, 53));
            cordinates.Add(new cordinatemodal(670, 438, 276, 134));
            cordinates.Add(new cordinatemodal(0, 574, 356, 57));
            cordinates.Add(new cordinatemodal(363, 574, 195, 54));
            cordinates.Add(new cordinatemodal(556, 574, 179, 54));
            cordinates.Add(new cordinatemodal(739, 574, 195, 54));
            cordinates.Add(new cordinatemodal(932, 574, 179, 54));
            cordinates.Add(new cordinatemodal(1112, 574, 114, 54));

            int i = 0;
            foreach (var ima in cordinates)
            {
                
                Crop filter = new Crop(new Rectangle(ima.x,ima.y,ima.w,ima.h));



                // apply the filter
                Bitmap newImage = filter.Apply(image);

                newImage.Save(i+".png");
                i++;
                croppedimages.Add(newImage);
              

            }
            return croppedimages;
        }

    }
}


   
