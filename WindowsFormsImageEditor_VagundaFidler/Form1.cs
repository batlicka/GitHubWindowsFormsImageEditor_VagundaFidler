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
        private Changes ChangedPicture; 

        
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
                    ChangedPicture= new Changes(LoadedImg, ChangedImg);
                }
            }
            catch (Exception)
            {
                MessageBox.Show("An Error Occured", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        //Grey Scale
        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            Changes ChangedPicture = new Changes(LoadedImg, ChangedImg);
            ChangedPicture.GreyScale();
            UpdateRightFrame();
            
            
        }

        //flip verticaly
        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            
            Changes ChangedPicture = new Changes(LoadedImg, ChangedImg);
            ChangedPicture.MirroringHorizontaly();
            UpdateRightFrame();
            
            //MessageBox.Show("clicked mirroring");
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {

        }

        private void UpdateRightFrame() {
            //reason described here
            //https://stackoverflow.com/questions/4803935/free-file-locked-by-new-bitmapfilepath/8701748#8701748
            Image img;
            using (var bmpTemp = new Bitmap("d:\\dokumenty\\Vojta\\UTB\\5_LET_IT\\multimedia\\OneDrive_2020-02-12\\Zpracovani rastrovych obrazku formatu BMP & PCX\\_Obrazky_zdroj\\BMP\\changed\\changed.bmp"))
            {
                img = new Bitmap(bmpTemp);
                image2.Image = img;
            }
        }

        //flip horizontaly
        private void toolStripButton4_Click(object sender, EventArgs e)
        {            
            Changes ChangedPicture = new Changes(LoadedImg, ChangedImg);
            ChangedPicture.MirroringVerticaly();
            UpdateRightFrame();
            
        }
        //rotate 90 degree
        private void toolStripButton5_Click(object sender, EventArgs e)
        {
            
           
            ChangedPicture.Rotate90();
            BitMap LoadedImg2 = (BitMap)LoadedImg.Clone();
            LoadedImg = LoadedImg2;
            UpdateRightFrame();
        }

        private void toolStripButton6_Click(object sender, EventArgs e)
        {
            ChangedPicture.Rotate90AgainClockvise();
            BitMap LoadedImg2 = (BitMap)LoadedImg.Clone();
            LoadedImg = LoadedImg2;
            UpdateRightFrame();
        }
    }
}
