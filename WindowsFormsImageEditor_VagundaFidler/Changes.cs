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

        public void MirroringHorizontaly() {
            //mirroring 24bit picture
            if (LoadedImg.BM_BitsPerPixel == 24) {
                for (uint column = 0; column < LoadedImg.BM_Height; column++)
                {
                    for (uint row = 0; row < LoadedImg.BM_Width; row++)
                    {
                        ChangedImg.pixelArr[column, row] = LoadedImg.pixelArr[ column, LoadedImg.BM_Width - row-1];
                    }
                }
            }            
            ChangedImg.SavePictureToFile("d:\\dokumenty\\Vojta\\UTB\\5_LET_IT\\multimedia\\OneDrive_2020-02-12\\Zpracovani rastrovych obrazku formatu BMP & PCX\\_Obrazky_zdroj\\BMP\\changed\\changed.bmp");

        }

        public void MirroringVerticaly()
        {
            //mirroring 24bit picture
            if (LoadedImg.BM_BitsPerPixel == 24)
            {
                for (uint column = 0; column < LoadedImg.BM_Height; column++)
                {
                    for (uint row = 0; row < LoadedImg.BM_Width; row++)
                    {
                        ChangedImg.pixelArr[column, row] = LoadedImg.pixelArr[LoadedImg.BM_Height - column - 1,  row ];
                    }
                }
            }
            ChangedImg.SavePictureToFile("d:\\dokumenty\\Vojta\\UTB\\5_LET_IT\\multimedia\\OneDrive_2020-02-12\\Zpracovani rastrovych obrazku formatu BMP & PCX\\_Obrazky_zdroj\\BMP\\changed\\changed.bmp");

        }

        public void Rotate90() {
            //int height = 2;
            //int width = 4;

            //int [,]ArrSource =new int[height, width];
            //int[,] ArrDest = new int[width, height];

            //ArrSource[0, 0] = 1; ArrSource[0, 1] = 2; ArrSource[0, 2] = 3; ArrSource[0, 3] = 4;
            //ArrSource[1, 0] = 5; ArrSource[1, 1] = 6; ArrSource[1, 2] = 7; ArrSource[1, 3] = 8;


            //for (int r = 0; r < height; r++)
            //{
            //    for (int c = 0; c < width; c++)
            //    {
            //        ArrDest[c, (height - r - 1)] = ArrSource[r, c];
            //    }
            //}
            //normalne [vyska,sirka] po otoceni [sirka, vyska]


            //uint NewRowByte = 
            //uint length = LoadedImg.BM_Offset + (LoadedImg.BM_Height+LoadedImg.Ro);
            //byte[] buffResized= new byte[length];
            //VColor[,] pixelArrDest= new VColor[LoadedImg.BM_Width, LoadedImg.BM_Height];
            //for (int r = 0; r < LoadedImg.BM_Height; r++)
            //{
            //    for (int c = 0; c < LoadedImg.BM_Width; c++)
            //    {                    
            //        pixelArrDest[c,(LoadedImg.BM_Height - r - 1)] = LoadedImg.pixelArr[r , c];
            //    }
            //}
        }
    }
}
