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

        public String PathToChangedPicture { get; set; }
        public bool SettingsDone { get; set; }

        public bool FlipHoriz { get; set; }
        public Form1()
        {
            InitializeComponent();
            PathToChangedPicture = "d:\\dokumenty\\Vojta\\UTB\\5_LET_IT\\multimedia\\OneDrive_2020-02-12\\Zpracovani rastrovych obrazku formatu BMP & PCX\\_Obrazky_zdroj\\BMP\\changed\\changed.bmp";
            SettingsDone = false;
            FlipHoriz = true;
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
                        ChangedImg = new BitMap(imageLocation);
                        ChangedPicture = new Changes(LoadedImg, ChangedImg, PathToChangedPicture);
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
        }

        //flip horizontaly
        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            if (FlipHoriz == true) {
                ChangedPicture.MirroringHorizontaly();
                UpdateRightFrame();
                FlipHoriz = false;
            }else
                MessageBox.Show("horizontal and vertical mirroring can be used only once for 1 loaded picture, If you want to use " +
                         "it oncemore please Import new image");
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

        //flip Verticaly
        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            if (FlipHoriz == true)
            {
                ChangedPicture.MirroringVerticaly();
                UpdateRightFrame();
                FlipHoriz = false;
            }else
                MessageBox.Show("horizontal and vertical mirroring can be used only once for 1 loaded picture, If you want to use " +
                    "it oncemore please Import new image");


        }
        //rotate 90 degree
        private void toolStripButton5_Click(object sender, EventArgs e)
        {
            ChangedPicture.Rotate90();            
            UpdateRightFrame();
        }

        //rotate 90 again clockwise
        private void toolStripButton6_Click(object sender, EventArgs e)
        {
            ChangedPicture.Rotate90AgainClockwise();            
            UpdateRightFrame();
        }
        //negative
        private void toolStripButton7_Click(object sender, EventArgs e)
        {            
            ChangedPicture.Negativ();
            UpdateRightFrame();
            
        }

        //brightness increment
        private void toolStripButton8_Click(object sender, EventArgs e)
        {
            ChangedPicture.BrightnessINC();
            UpdateRightFrame();
            
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
            
        }
        //Kontrast Inc
        private void toolStripButton3_Click_1(object sender, EventArgs e)
        {
            ChangedPicture.KonstrastINC();
            UpdateRightFrame();
           
        }
        //Kontrast Dec
        private void toolStripButton10_Click(object sender, EventArgs e)
        {
            ChangedPicture.KonstrastDEC();
            UpdateRightFrame();
            
        }
        

        

    }
}
