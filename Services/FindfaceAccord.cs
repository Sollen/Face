using System.Collections.Generic;
using System.Drawing;
using Accord.Vision.Detection;
using Accord.Vision.Detection.Cascades;

namespace Face.Services
{
    public class FindfaceAccord : FindfaceBase
    {
        protected override IEnumerable<Rectangle> GetFaces(Bitmap bitmap)
        {
            var faceDetector = new HaarObjectDetector(new FaceHaarCascade(), minSize: 25, searchMode: ObjectDetectorSearchMode.NoOverlap);

            return faceDetector.ProcessFrame(bitmap);
        }
    }
}
