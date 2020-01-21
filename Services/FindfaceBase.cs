using System.Collections.Generic;
using System.Drawing;

namespace Face.Services
{
    public abstract class FindfaceBase : IFindfaceService
    {
        public Image FindAndDraw(string path)
        {
            var img = Image.FromFile(path);
            var bitmap = new Bitmap(img);

            var faces = GetFaces(bitmap);

            foreach (var face in faces)
                using (var graphics = Graphics.FromImage(bitmap))
                using (var pen = new Pen(Color.Yellow, 3))
                    graphics.DrawRectangle(pen, face);

            return bitmap;

        }

        protected abstract IEnumerable<Rectangle> GetFaces(Bitmap bitmap);

    }
}
