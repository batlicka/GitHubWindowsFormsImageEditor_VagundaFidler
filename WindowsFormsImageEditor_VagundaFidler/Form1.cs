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

        //this will not be change during running of program
        private BitMap OriginalLoadedImg;

        public String PathToChangedPicture { get; set; }
        public bool SettingsDone { get; set; }

        public bool FlipHorizVerti { get; set; }
        public Form1()
        {
            InitializeComponent();
            PathToChangedPicture = "d:\\dokumenty\\Vojta\\UTB\\5_LET_IT\\multimedia\\OneDrive_2020-02-12\\Zpracovani rastrovych obrazku formatu BMP & PCX\\_Obrazky_zdroj\\BMP\\changed\\changed.bmp";
            SettingsDone = true;
            FlipHorizVerti = true;
        }

        private void Form1_Load(object sender, EventArgs e)
        {           
           
        }

        private void quitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void saveImageToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void importImageToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (SettingsDone == true)
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
                        OriginalLoadedImg = new BitMap(imageLocation);
                        ChangedImg = new BitMap(imageLocation);
                        ChangedPicture = new Changes(LoadedImg, ChangedImg, PathToChangedPicture);
                        FlipHorizVerti = true;
                    }
                }
                catch (Exception)
                {
                    MessageBox.Show("An Error Occured", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
                MessageBox.Show("please frist go to Settings and set path to attached picture named change.bmp");


        }
        //Grey Scale
        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            ChangedPicture.GreyScale();            
            UpdateRightFrame();
            //FlipHorizVerti = false;
        }

        //flip horizontaly
        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            if (FlipHorizVerti == true) {
                ChangedPicture.MirroringHorizontaly();
                UpdateRightFrame();
                FlipHorizVerti = false;
            }else
                MessageBox.Show("In this version Horizontal and Vertical mirroring can be used only as first change on picture and MAX 1×. If you want to use it " +
                         "please Import new image");
        }

        //flip Verticaly
        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            if (FlipHorizVerti == true)
            {
                ChangedPicture.MirroringVerticaly();
                UpdateRightFrame();
                FlipHorizVerti = false;
            }
            else
                MessageBox.Show("In this version Horizontal and Vertical mirroring can be used only as first change on picture and MAX 1×. If you want to use it " +
                         "please Import new image");
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {

        }

        private void UpdateRightFrame() {
            //reason described here
            //https://stackoverflow.com/questions/4803935/free-file-locked-by-new-bitmapfilepath/8701748#8701748
            Image img;
            using (var bmpTemp = new Bitmap(PathToChangedPicture))
            {
                img = new Bitmap(bmpTemp);
                image2.Image = img;
            }
        }

        
        //rotate 90 degree
        private void toolStripButton5_Click(object sender, EventArgs e)
        {
            ChangedPicture.Rotate90();            
            UpdateRightFrame();
            //FlipHorizVerti = false;
        }

        //rotate 90 again clockwise
        private void toolStripButton6_Click(object sender, EventArgs e)
        {
            ChangedPicture.Rotate90AgainClockwise();            
            UpdateRightFrame();
            //FlipHorizVerti = false;
        }
        //negative
        private void toolStripButton7_Click(object sender, EventArgs e)
        {            
            ChangedPicture.Negativ();
            UpdateRightFrame();
            //FlipHorizVerti = false;

        }

        //brightness increment
        private void toolStripButton8_Click(object sender, EventArgs e)
        {
            ChangedPicture.BrightnessINC();
            UpdateRightFrame();
            //FlipHorizVerti = false;

        }

        private void settingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog dialog = new OpenFileDialog();
                dialog.Filter = "BMP files(*.bmp)|*.bmp| All Files(*.*)|*.*";

                if (dialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    PathToChangedPicture = dialog.FileName;
                }
                SettingsDone = true;
            }
            catch (Exception)
            {
                MessageBox.Show("An Error Occured", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        //Brightness Decrement
        private void toolStripButton9_Click(object sender, EventArgs e)
        {
            ChangedPicture.BrightnessDEC();
            UpdateRightFrame();
            //FlipHorizVerti = false;

        }
        //Kontrast Inc
        private void toolStripButton3_Click_1(object sender, EventArgs e)
        {
            ChangedPicture.KonstrastINC();
            UpdateRightFrame();
            //FlipHorizVerti = false;

        }
        //Kontrast Dec
        private void toolStripButton10_Click(object sender, EventArgs e)
        {
            ChangedPicture.KonstrastDEC();
            UpdateRightFrame();
            //FlipHorizVerti = false;

        }

        private void AboutChangedImageToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show(
                "BMP header:" +
                "\n  Type: " + ChangedImg.BM_Type +
                "\n  Size: " + ChangedImg.BM_Size + " bajtů"+
                "\n  Offset: " + ChangedImg.BM_Offset +
                "\n ¨----------BMP info header:------" +
                "\n  NumberOfBit: " + ChangedImg.BM_NumberOfBit +
                "\n  Width: " + ChangedImg.BM_Width +
                "px \n  Height: " + ChangedImg.BM_Height +
                "px \n  Planes: " + ChangedImg.BM_Planes +
                "\n  BitsPerPixel: " + ChangedImg.BM_BitsPerPixel +
                "\n  Compression: " + ChangedImg.BM_Compression +
                "\n  ByteSizeToCom: " + ChangedImg.BM_ByteSizeToCom +
                "\n  XOutPerMeter: " + ChangedImg.BM_XOutPerMeter +
                "\n  YOutPerMeter: " + ChangedImg.BM_YOutPerMeter +
                "\n  ByteColorUsed: " + ChangedImg.BM_ByteColorUsed +
                "\n  NeededByteToColor: " + ChangedImg.BM_NeededByteToColor
                );
        }

        private void AboutOriginalImageToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show(
                  "BMP header:" +
                  "\n  Type: " + OriginalLoadedImg.BM_Type +
                  "\n  Size: " + OriginalLoadedImg.BM_Size + " bajtů" +
                  "\n  Offset: " + OriginalLoadedImg.BM_Offset +
                 "\n ----------BMP info header:------" +
                  "\n  NumberOfBit: " + OriginalLoadedImg.BM_NumberOfBit +
                  "\n  Width: " + OriginalLoadedImg.BM_Width +
                  "px \n  Height: " + OriginalLoadedImg.BM_Height +
                  "px \n  Planes: " + OriginalLoadedImg.BM_Planes +
                  "\n  BitsPerPixel: " + OriginalLoadedImg.BM_BitsPerPixel +
                  "\n  Compression: " + OriginalLoadedImg.BM_Compression +
                  "\n  ByteSizeToCom: " + OriginalLoadedImg.BM_ByteSizeToCom +
                  "\n  XOutPerMeter: " + OriginalLoadedImg.BM_XOutPerMeter +
                  "\n  YOutPerMeter: " + OriginalLoadedImg.BM_YOutPerMeter +
                  "\n  ByteColorUsed: " + OriginalLoadedImg.BM_ByteColorUsed +
                  "\n  NeededByteToColor: " + OriginalLoadedImg.BM_NeededByteToColor
                  );
        }

    }
}
