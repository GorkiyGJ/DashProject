using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using Gif.Components;

namespace Manitou.Helper
{
    public class GraphicUtils
    {
        public static byte[] BitmapToByteArray(Image img)
        {
            MemoryStream ms = new MemoryStream();
            img.Save(ms, img.RawFormat);

            return ms.ToArray();
        }

        public static Image ByteArrayToImage(byte[] imgByte)
        {
            MemoryStream m = new MemoryStream(imgByte);
            return Image.FromStream(m);
        }

        public static double GetProportionalHeight(Image img, int maxWidth)
        {
            if (img.Width > maxWidth)
                return Convert.ToDouble(img.Height) * Convert.ToDouble(maxWidth) / Convert.ToDouble(img.Width);
            else
                return img.Width;
        }

        public static double GetProportionalWidth(Image img, int maxHeight)
        {
            if (img.Height > maxHeight)
                return Convert.ToDouble(img.Width) * Convert.ToDouble(maxHeight) / Convert.ToDouble(img.Height);
            else
                return img.Width;
        }

        public static byte[] GetOriginalCenterBox(byte[] imgByte)
        {
            Image img = ByteArrayToImage(imgByte);

            int maxSize;
            int x, y;

            if (img.Width > img.Height)
            {
                y = 0;
                x = (img.Width - img.Height) / 2;

                maxSize = img.Height;
            }
            else
            {
                maxSize = img.Width;

                x = 0;
                y = (img.Height - img.Width) / 2;
            }

            return GetAllowImageByte(img, x, y, maxSize, maxSize);
        }

        public static byte[] Crop(Image img, int width, int height)
        {
            int x, y;
            if (width > img.Width || height > img.Height)
            {
                width = img.Width;
                height = img.Height;
                x = 0;
                y = 0;
            }
            else
            {
                x = (img.Width - width) / 2;
                y = (img.Height - height) / 2;
            }

            return GetAllowImageByte(img, x, y, width, height);
        }

        public static Size GetProportionalWidthHeight(Image img, int maxWidth, int maxHeight)
        {
#pragma warning disable RedundantCast
            float ar = (float)img.Width / (float)img.Height;
            float maxar = (float)maxWidth / (float)maxHeight;
#pragma warning restore RedundantCast

            if (maxWidth < img.Width || maxHeight < img.Height)
            {
                int width;
                int height;

                if (ar > maxar)
                {
                    width = maxWidth;
                    height = (int)(width / ar);
                }
                else
                {
                    height = maxHeight;
                    width = (int)(height * ar);
                }

                return new Size(width, height);
            }
            else
            {
                return new Size(img.Width, img.Height);
            }
        }

        public static byte[] GetAllowImageByte(Image img, int width, int height, bool isMobile)
        {
            return GetAllowImageByte(img, 0, 0, width, height, isMobile);
        }

        public static byte[] GetAllowImageByte(Image img, int width, int height)
        {
            return GetAllowImageByte(img, 0, 0, width, height, false);
        }

        private static Image GetAllowImage(Image img, int x, int y, int width, int height)
        {
            return GetAllowImage(img, x, y, width, height, false);
        }

        private static Image GetAllowImage(Image img, int x, int y, int width, int height, bool isMobile)
        {

            Bitmap imgOutput = new Bitmap(width, height);
            imgOutput.MakeTransparent();
            imgOutput.MakeTransparent(Color.Black);

            Graphics newGraphics = Graphics.FromImage(imgOutput);
            newGraphics.Clear(Color.FromArgb(0, 255, 255, 255));
            newGraphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
            newGraphics.SmoothingMode = SmoothingMode.HighQuality;
            newGraphics.PixelOffsetMode = PixelOffsetMode.HighQuality;
            newGraphics.CompositingQuality = CompositingQuality.HighQuality;
            if (x == 0 && y == 0) // resize
            {
                newGraphics.DrawImage(img, x, y, width, height);
            }
            else // crop
            {
                newGraphics.DrawImage(img,
                                      new Rectangle(0, 0, width, height),
                                      new Rectangle(x, y, width, height),
                                      GraphicsUnit.Pixel);
            }
            newGraphics.Flush();
            return imgOutput;

        }

        public static byte[] GetAllowImageByte(Image img, int x, int y, int width, int height)
        {
            return GetAllowImageByte(img, x, y, width, height, false);
        }

        public static byte[] GetAllowImageByte(Image img, int x, int y, int width, int height, bool isMobile)
        {
            ImageFormat thisFormat = img.RawFormat;
            if (thisFormat.Guid == ImageFormat.Gif.Guid)
            {
                Image imgOut = GetAllowGifImage(img, x, y, width, height, isMobile);
                MemoryStream ms = new MemoryStream();
                imgOut.Save(ms, thisFormat);
                imgOut.Dispose();
                return ms.ToArray();
            }
            else
            {
                Image imgOut = GetAllowImage(img, x, y, width, height, isMobile);
                MemoryStream ms = new MemoryStream();
                imgOut.Save(ms, thisFormat);
                imgOut.Dispose();
                return ms.ToArray();
            }
        }

        public static MemoryStream ReturnValidGifImage(MemoryStream ms)
        {
            Gif.Components.AnimatedGifEncoder e = new AnimatedGifEncoder();
            MemoryStream OutMemory = new MemoryStream();
            e.Start(OutMemory);
            e.AddFrame(Image.FromStream(ms));
            Image OutImage = Image.FromStream(e.Finish());
            return OutMemory;
        }

        private static Image GetAllowGifImage(Image img, int x, int y, int width, int height)
        {
            return GetAllowGifImage(img, x, y, width, height, false);
        }

        private static Image GetAllowGifImage(Image img, int x, int y, int width, int height, bool isMobile)
        {

            Bitmap imgOutput = new Bitmap(width, height);
            imgOutput.MakeTransparent();
            imgOutput.MakeTransparent(Color.Black);

            Graphics newGraphics = Graphics.FromImage(imgOutput);
            newGraphics.Clear(Color.FromArgb(0, 255, 255, 255));
            newGraphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
            newGraphics.SmoothingMode = SmoothingMode.HighQuality;
            newGraphics.PixelOffsetMode = PixelOffsetMode.HighQuality;
            newGraphics.CompositingQuality = CompositingQuality.HighQuality;
            if (x == 0 && y == 0) // resize
            {
                newGraphics.DrawImage(img, x, y, width, height);
            }
            else // crop
            {
                newGraphics.DrawImage(img,
                                      new Rectangle(0, 0, width, height),
                                      new Rectangle(x, y, width, height),
                                      GraphicsUnit.Pixel);
            }
            newGraphics.Flush();
            MemoryStream ms = new MemoryStream();
            imgOutput.Save(ms, ImageFormat.Jpeg);
            Image im = Image.FromStream(ReturnValidGifImage(ms));
            return im;
        }

        public static void ImageComposite(string topImagePath, MemoryStream ms, string filePath)
        {
            ImageComposite(topImagePath, ms, filePath, enWaterMarkType.None);
        }

        public static void ImageComposite(string topImagePath, MemoryStream ms, string filePath, byte waterMartType)
        {
            enWaterMarkType type;
            switch(waterMartType)
            {
                case (byte)enWaterMarkType.LeftBottom:
                    type = enWaterMarkType.LeftBottom;
                    break;

                case (byte)enWaterMarkType.LeftTop:
                    type = enWaterMarkType.LeftTop;
                    break;

                case (byte)enWaterMarkType.RightBottom:
                    type = enWaterMarkType.RightBottom;
                    break;

                case (byte)enWaterMarkType.RightTop:
                    type = enWaterMarkType.RightTop;
                    break;

                default:
                    type = enWaterMarkType.None;
                    break;
            }

            ImageComposite(topImagePath, ms, filePath, type);
        }

        public static void ImageComposite(string topImagePath, MemoryStream ms, string filePath, enWaterMarkType waterMartType)
        {
            using (Bitmap image = new Bitmap(Image.FromStream(ms)))
            {
                if (!File.Exists(topImagePath) || image.Width < 150 || image.Height < 150)
                {
                    image.Save(filePath);
                    image.Dispose();
                }
                else
                {
                    using (Image imageTop = Image.FromFile(topImagePath))
                    {
                        using (Graphics newGraphics = Graphics.FromImage(image))
                        {
                            newGraphics.CompositingMode = CompositingMode.SourceOver;
                            newGraphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
                            newGraphics.SmoothingMode = SmoothingMode.HighQuality;
                            newGraphics.PixelOffsetMode = PixelOffsetMode.HighQuality;
                            newGraphics.CompositingQuality = CompositingQuality.HighQuality;

                            if (waterMartType == enWaterMarkType.LeftTop)
                            {
                                newGraphics.DrawImage(imageTop, new Rectangle(10, 10, imageTop.Width, imageTop.Height), new Rectangle(0, 0, imageTop.Width, imageTop.Height), GraphicsUnit.Pixel);
                            }
                            else
                                if (waterMartType == enWaterMarkType.LeftBottom)
                                {
                                    newGraphics.DrawImage(imageTop,
                                                          new Rectangle(10,
                                                            image.Height - (imageTop.Height + 10), imageTop.Width,
                                                            imageTop.Height),
                                                          new Rectangle(0, 0, imageTop.Width, imageTop.Height),
                                                          GraphicsUnit.Pixel);
                                }
                                else
                                    if (waterMartType == enWaterMarkType.RightTop)
                                    {
                                        newGraphics.DrawImage(imageTop, new Rectangle(image.Width - (imageTop.Width + 10), 10, imageTop.Width, imageTop.Height), new Rectangle(0, 0, imageTop.Width, imageTop.Height), GraphicsUnit.Pixel);
                                    }
                                    else
                                        if (waterMartType == enWaterMarkType.RightBottom)
                                        {
                                            newGraphics.DrawImage(imageTop,
                                                                  new Rectangle(image.Width - (imageTop.Width + 10),
                                                                    image.Height - (imageTop.Height + 10), imageTop.Width,
                                                                    imageTop.Height),
                                                                  new Rectangle(0, 0, imageTop.Width, imageTop.Height),
                                                                  GraphicsUnit.Pixel);
                                        }

                            newGraphics.Flush();
                            image.Save(filePath);
                            image.Dispose();
                            newGraphics.Dispose();
                            imageTop.Dispose();
                        }
                    }
                }
            }
        }
    }
}