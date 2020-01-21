using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Emgu.CV;
using Emgu.CV.Structure;

namespace Face
{
    public partial class Form1 : Form
    {
        private static CascadeClassifier _classifier = new CascadeClassifier("haarcascade_frontalface_alt_tree.xml");
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                var res = openFileDialog1.ShowDialog();
                if (res == DialogResult.OK)
                {
                    var path = openFileDialog1.FileName;
                    var img = Image.FromFile(path);
                    pictureBox1.Image = img;
                    var bitmap = new Bitmap(img);
                    var grayImage = new Image<Bgr, byte>(bitmap);
                    var faces = _classifier.DetectMultiScale(grayImage, 1.4, 0);

                    foreach (var face in faces)
                        using (var graphics = Graphics.FromImage(bitmap))
                        using (var pen = new Pen(Color.Yellow, 3))
                            graphics.DrawRectangle(pen, face);

                    pictureBox1.Image = bitmap;
                }
                else
                {
                    MessageBox.Show(@"Image is not selected!", @"Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, @"Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
