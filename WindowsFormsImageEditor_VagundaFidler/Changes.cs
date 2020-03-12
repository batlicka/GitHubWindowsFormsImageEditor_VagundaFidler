using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsImageEditor_VagundaFidler 
{
    class Changes
    {
        public BitMap LoadedImg { get; set; } //4B-biSize
        public BitMap ChangedImg { get; set; } //4B-biSize

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

            //after all ¨changes ubdate LoadImg by ChangedImg
            BitMap ClonedChangedImg = (BitMap)ChangedImg.Clone();
            LoadedImg = ClonedChangedImg;
        }

        public void MirroringHorizontaly() {
            //mirroring 24bit picture
            VColor[,] pixelArrTmp = ChangedImg.pixelArr;
            if (ChangedImg.BM_BitsPerPixel == 24) {
                for (uint column = 0; column < ChangedImg.BM_Height; column++)
                {
                    for (uint row = 0; row < ChangedImg.BM_Width; row++)
                    {
                        ChangedImg.pixelArr[column, row] = pixelArrTmp[ column, ChangedImg.BM_Width - row-1];
                    }
                }
            }            
            ChangedImg.SavePictureToFile("d:\\dokumenty\\Vojta\\UTB\\5_LET_IT\\multimedia\\OneDrive_2020-02-12\\Zpracovani rastrovych obrazku formatu BMP & PCX\\_Obrazky_zdroj\\BMP\\changed\\changed.bmp");

            //after all ¨changes ubdate LoadImg by ChangedImg
            BitMap ClonedChangedImg = (BitMap)ChangedImg.Clone();
            LoadedImg = ClonedChangedImg;
        }

        public void MirroringVerticaly()
        {
            //VColor[,] pixelArrTmp = ChangedImg.pixelArr;
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

            //after all ¨changes ubdate LoadImg by ChangedImg
            BitMap ClonedChangedImg = (BitMap)ChangedImg.Clone();
            LoadedImg = ClonedChangedImg;
        }

        public void Rotate90() {
            
            if (ChangedImg.BM_BitsPerPixel == 24) {
                uint height = ChangedImg.BM_Height;
                uint width = ChangedImg.BM_Width;
                ChangedImg.BM_Width = height;
                //change Width in buffer array
                ChangedImg.SetWidthTObuff(height);
                
                ChangedImg.BM_Height = width;
                //change Height in buffer array
                ChangedImg.SetHeightTObuff(width);

                ChangedImg.RowLength = Convert.ToUInt32(Math.Ceiling(ChangedImg.BM_Width * ChangedImg.BM_BitsPerPixel / 32.0) * 4); //number of bytes on the row
                ChangedImg.RowBitAlignment = (ChangedImg.RowLength * 8) - (ChangedImg.BM_Width * ChangedImg.BM_BitsPerPixel); //number of bits used for aligment of row
                ChangedImg.RowByteAlignment = ChangedImg.RowBitAlignment / 8;
                
                uint NewBuffLength = ChangedImg.BM_Offset + (ChangedImg.RowLength) * ChangedImg.BM_Height;
                byte[] buffResized = new byte[NewBuffLength];                

                VColor[,] pixelArrDest = new VColor[ChangedImg.BM_Height, ChangedImg.BM_Width];
                for (int r = 0; r < ChangedImg.BM_Width; r++)
                {
                    for (int c = 0; c < ChangedImg.BM_Height; c++)
                    {
                        pixelArrDest[c, (ChangedImg.BM_Width - r - 1)] = ChangedImg.pixelArr[r, c];
                    }
                }
                //set new created pixelArr
                ChangedImg.pixelArr = pixelArrDest;
                //copy fist 52 bytes to 
                Array.Copy(ChangedImg.buff, 0, buffResized, 0, ChangedImg.BM_Offset);
                ChangedImg.buff = buffResized;

                //change BM_Size in buffer array
                ChangedImg.BM_Size = NewBuffLength;
                ChangedImg.SetSizeTObuff(ChangedImg.BM_Size);

                ChangedImg.SavePictureToFile("d:\\dokumenty\\Vojta\\UTB\\5_LET_IT\\multimedia\\OneDrive_2020-02-12\\Zpracovani rastrovych obrazku formatu BMP & PCX\\_Obrazky_zdroj\\BMP\\changed\\changed.bmp");

                //after all ¨changes ubdate LoadImg by ChangedImg
                BitMap ClonedChangedImg = (BitMap)ChangedImg.Clone();
                LoadedImg = ClonedChangedImg;
            }
        }
        public void Rotate90AgainClockvise()
        {
            if (ChangedImg.BM_BitsPerPixel == 24)
            {
                uint height = ChangedImg.BM_Height;
                uint width = ChangedImg.BM_Width;
                ChangedImg.BM_Width = height;
                //change Width in buffer array
                ChangedImg.SetWidthTObuff(height);

                ChangedImg.BM_Height = width;
                //change Height in buffer array
                ChangedImg.SetHeightTObuff(width);

                ChangedImg.RowLength = Convert.ToUInt32(Math.Ceiling(ChangedImg.BM_Width * ChangedImg.BM_BitsPerPixel / 32.0) * 4); //number of bytes on the row
                ChangedImg.RowBitAlignment = (ChangedImg.RowLength * 8) - (ChangedImg.BM_Width * ChangedImg.BM_BitsPerPixel); //number of bits used for aligment of row
                ChangedImg.RowByteAlignment = ChangedImg.RowBitAlignment / 8;

                uint NewBuffLength = ChangedImg.BM_Offset + (ChangedImg.RowLength) * ChangedImg.BM_Height;
                byte[] buffResized = new byte[NewBuffLength];

                VColor[,] pixelArrDest = new VColor[ChangedImg.BM_Height,ChangedImg.BM_Width];
                for (int r = 0; r < ChangedImg.BM_Width; r++)
                {
                    for (int c = 0; c < ChangedImg.BM_Height; c++)
                    {
                        pixelArrDest[c, r] = ChangedImg.pixelArr[r, ChangedImg.BM_Height - 1 -c];
                    }
                }
                //set new created pixelArr
                ChangedImg.pixelArr = pixelArrDest;
                //copy fist 52 bytes to 
                Array.Copy(ChangedImg.buff, 0, buffResized, 0, ChangedImg.BM_Offset);
                ChangedImg.buff = buffResized;

                //change BM_Size in buffer array
                ChangedImg.BM_Size = NewBuffLength;
                ChangedImg.SetSizeTObuff(ChangedImg.BM_Size);

                ChangedImg.SavePictureToFile("d:\\dokumenty\\Vojta\\UTB\\5_LET_IT\\multimedia\\OneDrive_2020-02-12\\Zpracovani rastrovych obrazku formatu BMP & PCX\\_Obrazky_zdroj\\BMP\\changed\\changed.bmp");

                //after all ¨changes ubdate LoadImg by ChangedImg
                BitMap ClonedChangedImg = (BitMap)ChangedImg.Clone();
                LoadedImg = ClonedChangedImg;
            }
        }

        public void Negativ() {
            if (LoadedImg.BM_BitsPerPixel == 24)
            {
                for (int y = 0; y < LoadedImg.BM_Height; y++)
                {
                    for (int x = 0; x < LoadedImg.BM_Width; x++)
                    {
                        int r = LoadedImg.pixelArr[y, x].R;
                        int g = LoadedImg.pixelArr[y, x].G;
                        int b = LoadedImg.pixelArr[y, x].B;

                        ChangedImg.pixelArr[y, x].R = 255 - r;
                        ChangedImg.pixelArr[y, x].G = 255 - g;
                        ChangedImg.pixelArr[y, x].B = 255 - b;
                    }
                }
            }

            if (LoadedImg.BM_BitsPerPixel == 8) {
                for (int y = 0; y < LoadedImg.ColorPalette.Length; y++)
                {
                        int r = LoadedImg.ColorPalette[y].R;
                        int g = LoadedImg.ColorPalette[y].G;
                        int b = LoadedImg.ColorPalette[y].B;

                        ChangedImg.ColorPalette[y].R = 255 - r;
                        ChangedImg.ColorPalette[y].G = 255 - g;
                        ChangedImg.ColorPalette[y].B = 255 - b;
                }
            }
            ChangedImg.SavePictureToFile("d:\\dokumenty\\Vojta\\UTB\\5_LET_IT\\multimedia\\OneDrive_2020-02-12\\Zpracovani rastrovych obrazku formatu BMP & PCX\\_Obrazky_zdroj\\BMP\\changed\\changed.bmp");
            //after all ¨changes ubdate LoadImg by ChangedImg
            BitMap ClonedChangedImg = (BitMap)ChangedImg.Clone();
            LoadedImg = ClonedChangedImg;

        }
    }
}
