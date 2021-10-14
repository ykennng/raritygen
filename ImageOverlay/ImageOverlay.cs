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

        public void GenerateImages(string image01, string image02, string image03, int counter, string baseFolder = null)
        {
            bool exists = System.IO.Directory.Exists(outputDirectory);

            if (!exists)
                System.IO.Directory.CreateDirectory(outputDirectory);

            try
            {
                var folder = baseFolder ?? imageDirectory;

                Image baseImage = Image.FromFile(folder + "base.jpg");
                Image image1 = Image.FromFile(folder + image01);
                Image image2 = Image.FromFile(folder + image02);
                Image image3 = Image.FromFile(folder + image03);

                //Image image1 = Image.FromFile(this.imageDirectory + @"alien.png");
                //Image image2 = Image.FromFile(this.imageDirectory + @"bandana.png");
                //Image image3 = Image.FromFile(this.imageDirectory + @"smallshades.png");

                Image img = new Bitmap(baseImage.Width, baseImage.Height);
                using (Graphics gr = Graphics.FromImage(img))
                {
                    gr.DrawImage(baseImage, new Point(0, 0));
                    gr.DrawImage(image1, new Point(0, 0));
                    gr.DrawImage(image2, new Point(0, 0));
                    gr.DrawImage(image3, new Point(0, 0));
                }
                img.Save(outputDirectory + @"\output"+counter+".png", ImageFormat.Bmp);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
