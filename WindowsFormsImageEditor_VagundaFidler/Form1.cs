using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsImageEditor_VagundaFidler
{
    public partial class Form1 : Form
    {
        private BitMap LoadedImg;
        private BitMap ChangedImg;
        public bool ChangedPicture = true;//if is true show copy 1, if is false show copy 2
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        private void quitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void fileToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void saveImageToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void importImageToolStripMenuItem_Click(object sender, EventArgs e)
        {
            String imageLocation = "";
            try
            {
                OpenFileDialog dialog = new OpenFileDialog();
                dialog.Filter = "BMP files(*.bmp)|*.bmp| All Files(*.*)|*.*";

                if (dialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    imageLocation = dialog.FileName;
                    //loading of IMG to fram image1, just for view
                    image1.ImageLocation = imageLocation;

                    //loading of IMG to own created class BitMap for futher processing
                    LoadedImg = new BitMap(imageLocation);
                    ChangedImg = new BitMap(imageLocation);
                }
            }
            catch (Exception)
            {
                MessageBox.Show("An Error Occured", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {

            if (LoadedImg.BM_BitsPerPixel == 24) {
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
                ChangedImg.SavePictureToFile("d:\\dokumenty\\Vojta\\UTB\\5_LET_IT\\multimedia\\OneDrive_2020-02-12\\Zpracovani rastrovych obrazku formatu BMP & PCX\\_Obrazky_zdroj\\BMP\\changed\\changed.bmp");                
            }
            
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {

            MessageBox.Show("clicked mirroring");
        }

        private void refresh_Click(object sender, EventArgs e)
        {
            Image img;
            //reason described here
            //https://stackoverflow.com/questions/4803935/free-file-locked-by-new-bitmapfilepath/8701748#8701748
            using (var bmpTemp = new Bitmap("d:\\dokumenty\\Vojta\\UTB\\5_LET_IT\\multimedia\\OneDrive_2020-02-12\\Zpracovani rastrovych obrazku formatu BMP & PCX\\_Obrazky_zdroj\\BMP\\changed\\changed.bmp"))
            {
                img = new Bitmap(bmpTemp);
                image2.Image = img;
            }

        }
    }
}
