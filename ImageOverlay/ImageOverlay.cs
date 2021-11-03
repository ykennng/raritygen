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
        public const string FilePrefix = "fsjal";
        public const int WebDPI = 72;

        public string GenerateImages(int counter, string image01 = null, string image02 = null, string image03 = null, string image04 = null, string image05 = null, string image06 = null, string baseFolder = null)
        {
            try
            {
                var folder = baseFolder ?? projectDirectory;
                if(!folder.EndsWith(@"\"))
                {
                    folder += @"\";
                }

                Bitmap baseImageBMP = new Bitmap(folder + "FSJAL.png");
                baseImageBMP.SetResolution(WebDPI, WebDPI);
                Image baseImage = baseImageBMP;
                //Image baseImage = Image.FromFile(folder + "FSJAL.png");
                
                var bitmap = new Bitmap(baseImage.Width, baseImage.Height);
                bitmap.SetResolution(WebDPI, WebDPI);

                Image img = bitmap;
                using (Graphics gr = Graphics.FromImage(img))
                {
                    //background first
                    if (!string.IsNullOrEmpty(image01))
                    {
                        Bitmap i1 = new Bitmap(folder + image01);
                        i1.SetResolution(WebDPI, WebDPI);
                        Image image1 = i1;
                        gr.DrawImage(image1, new Point(0, 0));
                    }

                    //FSJAL
                    gr.DrawImage(baseImage, new Point(0, 0));

                    if (!string.IsNullOrEmpty(image02))
                    {
                        Bitmap i2 = new Bitmap(folder + image02);
                        i2.SetResolution(WebDPI, WebDPI);
                        Image image2 = i2;
                        gr.DrawImage(image2, new Point(0, 0));
                    }

                    if (!string.IsNullOrEmpty(image03))
                    {
                        Bitmap i3 = new Bitmap(folder + image03);
                        i3.SetResolution(WebDPI, WebDPI);
                        Image image3 = i3;
                        gr.DrawImage(image3, new Point(0, 0));
                    }

                    if (!string.IsNullOrEmpty(image04))
                    {
                        Bitmap i4 = new Bitmap(folder + image04);
                        i4.SetResolution(WebDPI, WebDPI);
                        Image image4 = i4;
                        gr.DrawImage(image4, new Point(0, 0));
                    }

                    if (!string.IsNullOrEmpty(image05))
                    {
                        Bitmap i5 = new Bitmap(folder + image05);
                        i5.SetResolution(WebDPI, WebDPI);
                        Image image5 = i5;
                        gr.DrawImage(image5, new Point(0, 0));
                    }

                    if (!string.IsNullOrEmpty(image06))
                    {
                        Bitmap i6 = new Bitmap(folder + image06);
                        i6.SetResolution(WebDPI, WebDPI);
                        Image image6 = i6;
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
                img.Save(outputDirectory + @"\fsjal"+counter+".png", ImageFormat.Png);

                return FilePrefix + counter + ".png";
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
