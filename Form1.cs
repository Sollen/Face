using System;
using System.Drawing;
using System.Windows.Forms;
using Face.Services;

namespace Face
{
    public partial class Form1 : Form
    {
        private readonly FindfaceEmgu serviceEmgu = new FindfaceEmgu();
        private readonly FindfaceAccord serviceAccord = new FindfaceAccord();

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
