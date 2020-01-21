using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Emgu.CV;
using Emgu.CV.Structure;

namespace Face.Services
{
    public class FindfaceEmgu : FindfaceBase
    {
        private static CascadeClassifier _classifier = new CascadeClassifier("haarcascade_frontalface_alt_tree.xml");
        protected override IEnumerable<Rectangle> GetFaces(Bitmap bitmap)
        {
            var grayImage = new Image<Bgr, byte>(bitmap);
            return _classifier.DetectMultiScale(grayImage, 1.4, 1);
        }
    }
}
