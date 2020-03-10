using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsImageEditor_VagundaFidler
{
    class Changes
    {
        public BitMap LoadedImg { get; private set; } //4B-biSize
        public BitMap ChangedImg { get; private set; } //4B-biSize

        public Changes(BitMap LoadedImg, BitMap ChangedImg) {
            this.LoadedImg = LoadedImg;
            this.ChangedImg = ChangedImg;
        }

        public void GreyScale()
        {
            if (LoadedImg.BM_BitsPerPixel == 24)
            {
                for (int y = 0; y < LoadedImg.BM_Height; y++)
                {
                    for (int x = 0; x < LoadedImg.BM_Width; x++)
                    {
                        //extract pixel component ARGB                        
                        int r = LoadedImg.pixelArr[y, x].R;
                        int g = LoadedImg.pixelArr[y, x].G;
                        int b = LoadedImg.pixelArr[y, x].B;

                        //find average
                        int avg = (r + g + b) / 3;
                        ChangedImg.pixelArr[y, x].R = avg;
                        ChangedImg.pixelArr[y, x].G = avg;
                        ChangedImg.pixelArr[y, x].B = avg;
                        //set new pixel value

                    }
                }
            }
            if (LoadedImg.BM_BitsPerPixel == 8) {
                for (int i = 0; i < ChangedImg.ColorPalette.Length; i++) {
                    int r = LoadedImg.ColorPalette[i].R;
                    int g = LoadedImg.ColorPalette[i].G;
                    int b = LoadedImg.ColorPalette[i].B;
                    int avg = (r + g + b) / 3;
                    ChangedImg.ColorPalette[i].R = avg;
                    ChangedImg.ColorPalette[i].G = avg;
                    ChangedImg.ColorPalette[i].B = avg;
                }                
            }
            ChangedImg.SavePictureToFile("d:\\dokumenty\\Vojta\\UTB\\5_LET_IT\\multimedia\\OneDrive_2020-02-12\\Zpracovani rastrovych obrazku formatu BMP & PCX\\_Obrazky_zdroj\\BMP\\changed\\changed.bmp");
        }
    }
}
