using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;

namespace ImageOverlay
{
    public class ImageOverlayClass
    {
        readonly string projectDirectory = Directory.GetParent(Environment.CurrentDirectory).FullName;

        public void GenerateImages(string image01, string image02, string image03, int counter, string baseFolder = null)
        {
            try
            {
                var folder = baseFolder ?? projectDirectory;
                if(!folder.EndsWith(@"\"))
                {
                    folder += @"\";
                }

                Image baseImage = Image.FromFile(folder + "base.jpg");
                Image image1 = Image.FromFile(folder + image01);
                Image image2 = Image.FromFile(folder + image02);
                Image image3 = Image.FromFile(folder + image03);

                Image img = new Bitmap(baseImage.Width, baseImage.Height);
                using (Graphics gr = Graphics.FromImage(img))
                {
                    gr.DrawImage(baseImage, new Point(0, 0));
                    gr.DrawImage(image1, new Point(0, 0));
                    gr.DrawImage(image2, new Point(0, 0));
                    gr.DrawImage(image3, new Point(0, 0));
                }

                var outputDirectory = baseFolder ?? projectDirectory;
                if (!string.IsNullOrEmpty(baseFolder))
                {
                    if (!outputDirectory.EndsWith(@"\"))
                    {
                        outputDirectory += @"\";
                    }
                }
                
                outputDirectory += @"Output";

                bool exists = System.IO.Directory.Exists(outputDirectory);

                if (!exists)
                    System.IO.Directory.CreateDirectory(outputDirectory);
                img.Save(outputDirectory + @"\output"+counter+".png", ImageFormat.Bmp);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
