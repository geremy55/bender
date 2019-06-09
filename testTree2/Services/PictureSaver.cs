using NLog;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using testTree2.Interfaces;

namespace testTree2.Services
{
    public class PictureSaver : IFileService<Visual>
    {
        private static readonly Logger Log = LogManager.GetCurrentClassLogger();
        public Visual Open(string filename)
        {
            throw new NotImplementedException();
        }

        public void Save(string filename, Visual myCanvas)
        {
            SaveControlImage(myCanvas, 1024, 768, filename);
        }

        private void SaveControlImage(Visual baseElement, int imageWidth, int imageHeight, string pathToOutputFile)
        {
            try
            {
                var pSource = PresentationSource.FromVisual(Application.Current.MainWindow);
                Matrix m = pSource.CompositionTarget.TransformToDevice;
                double dpiX = m.M11 * 96;
                double dpiY = m.M22 * 96;

                var elementBitmap = new RenderTargetBitmap(imageWidth, imageHeight, dpiX, dpiY, PixelFormats.Default);

                var drawingVisual = new DrawingVisual();
                using (DrawingContext drawingContext = drawingVisual.RenderOpen())
                {
                    var visualBrush = new VisualBrush(baseElement);
                    drawingContext.DrawRectangle(
                        visualBrush,
                        null,
                        new Rect(new Point(0, 0), new Size(imageWidth / m.M11, imageHeight / m.M22)));
                }

                elementBitmap.Render(drawingVisual);
                var encoder = new JpegBitmapEncoder();
                encoder.Frames.Add(BitmapFrame.Create(elementBitmap));

                using (var imageFile = new FileStream(pathToOutputFile, FileMode.Create, FileAccess.Write))
                {
                    encoder.Save(imageFile);
                    imageFile.Flush();
                    imageFile.Close();
                }
            }
            catch(Exception ex)
            {
                Log.Error(ex.Message);
            }
        }
    }
}
