using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Drawing.Imaging;


namespace EffectAndEditProject
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            
            InitializeComponent();
            
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        Bitmap temp;
        Bitmap temp1;
        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "JPEG File (*.jpg)|*.jpg|Bitmap File (*.bmp)|*.bmp|PNG File(*.png)|*.png";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {

                pictureBox1.Image = Image.FromFile(openFileDialog1.FileName);
                pictureBox2.Image = pictureBox1.Image;
                temp1 = new Bitmap(pictureBox1.Image);
                temp = new Bitmap(pictureBox1.Image);

            }
            
        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (pictureBox1.Image != null)
                {
                    Bitmap white = new Bitmap(pictureBox2.Width, pictureBox2.Height);
                    pictureBox1.Image = white;
                    pictureBox2.Image = white;
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Image Not Found!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            saveFileDialog1.Filter = "JPEG File (*.jpg)|*.jpg|Bitmap File (*.bmp)|*.bmp|PNG File(*.png)|*.png";
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                switch (Path.GetExtension(saveFileDialog1.FileName))
                {
                    case ".jpg":
                        pictureBox2.Image.Save(saveFileDialog1.FileName, ImageFormat.Jpeg);
                        break;
                    case ".png":
                        pictureBox2.Image.Save(openFileDialog1.FileName,ImageFormat.Png);
                        break;
                    case ".Bmp":
                        pictureBox2.Image.Save(saveFileDialog1.FileName,ImageFormat.Bmp);
                        break;
                }
            }
        }

        private void editToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void selectAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void negativeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                Effects image = new Effects();
                pictureBox2.Image = image.ToNegative(temp1);
            }
            catch (Exception)
            {
                MessageBox.Show("Image Not Found !", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void grayscaleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                Effects image = new Effects();
                pictureBox2.Image = image.Grayscale(temp1);
            }
            catch (Exception)
            {
                MessageBox.Show("Image Not Found !", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Brightnessscroll_Scroll(object sender, ScrollEventArgs e)
        {

        }
        
        private void MainForm_Load(object sender, EventArgs e)
        {
            
        }


        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                pictureBox2.Image = temp;
                temp1 = temp;
                button1.Visible = false;
                button2.Visible = false;
            }
            catch (Exception)
            {
                MessageBox.Show("Image Not Found !", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                pictureBox2.Image = temp1;
                button1.Visible = false;
                button2.Visible = false;
            }
            catch (Exception)
            {
                 MessageBox.Show("Image Not Found !", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            try
            {
                Brightnesslbl.Text = trackBar1.Value.ToString();
                button1.Visible = true;
                button2.Visible = true;
            
            temp = AdjustBrightness(temp1, (float)(trackBar1.Value / 100.0));
            pictureBox2.Image = temp;
            }
            catch (Exception)
            {
                MessageBox.Show("Image Not Found !", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }
        private void trackBar1_MouseUp_1(object sender, MouseEventArgs e)
        {
            
        } 
        private Bitmap AdjustBrightness(Image image, float brightness)
        {
            float b = brightness;
            ColorMatrix cm = new ColorMatrix(new float[][]
                {
                    new float[] {b, 0, 0, 0, 0},
                    new float[] {0, b, 0, 0, 0},
                    new float[] {0, 0, b, 0, 0},
                    new float[] {0, 0, 0, 1, 0},
                    new float[] {0, 0, 0, 0, 1},
                });
            ImageAttributes attributes = new ImageAttributes();
            attributes.SetColorMatrix(cm);

            Point[] points =
            {
                new Point(0, 0),
                new Point(image.Width, 0),
                new Point(0, image.Height),
            };
            Rectangle rect = new Rectangle(0, 0, image.Width, image.Height);

            Bitmap bm = new Bitmap(image.Width, image.Height);
            using (Graphics gr = Graphics.FromImage(bm))
            {
                gr.DrawImage(image, points, rect, GraphicsUnit.Pixel, attributes);
            }
            return bm;
        }
        
        private void Brightnessscroll_Scroll_1(object sender, ScrollEventArgs e)
        {
            
        }


        private void rotateRight90ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                Bitmap rotated = new Bitmap(temp1);
                rotated.RotateFlip(RotateFlipType.Rotate90FlipNone);
                pictureBox2.Image = rotated;
                temp1 = rotated;
            }
            catch (Exception)
            {
                MessageBox.Show("Image Not Found !", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void rotateLeft90ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                Bitmap rotated = new Bitmap(temp1);
                rotated.RotateFlip(RotateFlipType.Rotate270FlipNone);
                pictureBox2.Image = rotated;
                temp1 = rotated;
            }
            catch (Exception)
            {
                MessageBox.Show("Image Not Found !", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void rotate180ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                Bitmap rotated = new Bitmap(temp1);
                rotated.RotateFlip(RotateFlipType.Rotate180FlipNone);
                pictureBox2.Image = rotated;
                temp1 = rotated;
            }
            catch (Exception)
            {
                MessageBox.Show("Image Not Found !", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void flipToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                Bitmap rotated = new Bitmap(temp1);
                rotated.RotateFlip(RotateFlipType.RotateNoneFlipX);
                pictureBox2.Image = rotated;
                temp1 = rotated;
            }
            catch (Exception)
            {
                MessageBox.Show("Image Not Found !", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void sepiaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                Effects image = new Effects();
                pictureBox2.Image = image.ToSepia(temp1);
            }
            catch (Exception)
            {
                MessageBox.Show("Image Not Found !", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void invertToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void blurToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                Rectangle rec = new Rectangle(0, 0, temp1.Width, temp1.Height);
                Effects image = new Effects();
                pictureBox2.Image = image.Blur(temp1, rec, 3);
                temp1 = new Bitmap(pictureBox2.Image);
            }
            catch (Exception)
            {
                MessageBox.Show("Image Not Found !", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void redToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                Effects image = new Effects();
                pictureBox2.Image = image.FilterColor(temp1, Effects.FilterType.Red);
            }
            catch (Exception)
            {
                MessageBox.Show("Image Not Found !", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void greenFilterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                Effects image = new Effects();
                pictureBox2.Image = image.FilterColor(temp1, Effects.FilterType.Green);
            }
            catch (Exception)
            {
                MessageBox.Show("Image Not Found !", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void blueFilterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                Effects image = new Effects();
                pictureBox2.Image = image.FilterColor(temp1, Effects.FilterType.blue);
            }
            catch (Exception)
            {
                MessageBox.Show("Image Not Found !", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }





        private void gammaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                Effects image = new Effects();
                GammaForm form = new GammaForm();
                form.RedComponent = form.GreenComponent = form.BlueComponent = 0;
                if (form.ShowDialog() == DialogResult.OK)
                {
                    pictureBox2.Image = image.SetGamma(temp1, form.RedComponent, form.GreenComponent, form.BlueComponent);
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Image Not Found !", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void MainForm_MouseUp(object sender, MouseEventArgs e)
        {
            
        }

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {


        }

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            xposlbl.Text = e.X.ToString();
            yposlbl.Text = e.Y.ToString();
            
        }

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {

        }
 
        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
        }

        private void button3_Click_1(object sender, EventArgs e)
        {

        }

        private void oilPaintingToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void trackBar1_MouseUp(object sender, MouseEventArgs e)
        {

        }

        private void effectToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void Contrastrackbar_Scroll(object sender, EventArgs e)
        {
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void apply_Click(object sender, EventArgs e)
        {

        }

        private void cancel_Click(object sender, EventArgs e)
        {

        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void aboutToolStripMenuItem1_Click(object sender, EventArgs e)
        {
        }

    }
}
