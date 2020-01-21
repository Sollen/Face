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
using Face.Services;

namespace Face
{
    public partial class Form1 : Form
    {
        private FindfaceEmgu serviceEmgu = new FindfaceEmgu();
        private FindfaceAccord serviceAccord = new FindfaceAccord();

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
                    pictureBox2.Image = img;

                    label1.Text = "EMGU";
                    label2.Text = "Accord";
                    var emguResult = serviceEmgu.FindAndDraw(path);
                    var accordResult = serviceAccord.FindAndDraw(path);
                    pictureBox1.Image = emguResult;
                    pictureBox2.Image = accordResult;
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
