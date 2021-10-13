using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;

namespace ImageOverlay
{
    public class ImageOverlayClass
    {
        string projectDirectory = Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.FullName;
        string imageDirectory = Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.FullName + @"\Images";
        string outputDirectory = Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.FullName + @"\Output";

        public void GenerateImages(string image01, string image02, string image03, string image04)
        {
            try
            {
                Image imageBackground = Image.FromFile(this.imageDirectory + @"\alien.png");
                Image imageOverlay = Image.FromFile(this.imageDirectory + @"\bandana.png");
                Image image3 = Image.FromFile(this.imageDirectory + @"\smallshades.png");

                Image img = new Bitmap(imageBackground.Width, imageBackground.Height);
                using (Graphics gr = Graphics.FromImage(img))
                {
                    gr.DrawImage(imageBackground, new Point(0, 0));
                    gr.DrawImage(imageOverlay, new Point(0, 0));
                    gr.DrawImage(image3, new Point(0, 0));
                }
                img.Save(outputDirectory + @"\test.png", ImageFormat.Bmp);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
