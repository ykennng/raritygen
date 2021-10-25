using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;

namespace ImageOverlay
{
    public class ImageOverlayClass
    {
        readonly string projectDirectory = Directory.GetParent(Environment.CurrentDirectory).FullName;
        public const string OutputPrefix = "Output";
        public string GenerateImages(int counter, string image01 = null, string image02 = null, string image03 = null, string image04 = null, string image05 = null, string image06 = null, string baseFolder = null)
        {
            try
            {
                var folder = baseFolder ?? projectDirectory;
                if(!folder.EndsWith(@"\"))
                {
                    folder += @"\";
                }

                Image baseImage = Image.FromFile(folder + "base.jpg");
                
                Image img = new Bitmap(baseImage.Width, baseImage.Height);
                using (Graphics gr = Graphics.FromImage(img))
                {
                    gr.DrawImage(baseImage, new Point(0, 0));

                    if (!string.IsNullOrEmpty(image01))
                    {
                        Image image1 = Image.FromFile(folder + image01);
                        gr.DrawImage(image1, new Point(0, 0));
                    }

                    if (!string.IsNullOrEmpty(image02))
                    {
                        Image image2 = Image.FromFile(folder + image02);
                        gr.DrawImage(image2, new Point(0, 0));
                    }

                    if (!string.IsNullOrEmpty(image03))
                    {
                        Image image3 = Image.FromFile(folder + image03);
                        gr.DrawImage(image3, new Point(0, 0));
                    }

                    if (!string.IsNullOrEmpty(image04))
                    {
                        Image image4 = Image.FromFile(folder + image04);
                        gr.DrawImage(image4, new Point(0, 0));
                    }

                    if (!string.IsNullOrEmpty(image05))
                    {
                        Image image5 = Image.FromFile(folder + image05);
                        gr.DrawImage(image5, new Point(0, 0));
                    }

                    if (!string.IsNullOrEmpty(image06))
                    {
                        Image image6 = Image.FromFile(folder + image06);
                        gr.DrawImage(image6, new Point(0, 0));
                    }
                }

                var outputDirectory = baseFolder ?? projectDirectory;
                if (!string.IsNullOrEmpty(baseFolder))
                {
                    if (!outputDirectory.EndsWith(@"\"))
                    {
                        outputDirectory += @"\";
                    }
                }
                
                outputDirectory += OutputPrefix;

                bool exists = System.IO.Directory.Exists(outputDirectory);

                if (!exists)
                    System.IO.Directory.CreateDirectory(outputDirectory);
                img.Save(outputDirectory + @"\output"+counter+".png", ImageFormat.Bmp);

                return OutputPrefix + counter + ".png";
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
