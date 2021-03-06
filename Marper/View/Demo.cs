using System;
using System.IO;
using Microsoft.Maui.Graphics;
using Microsoft.Maui.Graphics.Skia;


namespace Marper.View
{
    public class Demo
    {
        static void createDemoCanvas()
        {
            // Use Skia to create a Maui graphics context and canvas
            BitmapExportContext bmpContext = SkiaGraphicsService.Instance.CreateBitmapExportContext(600, 400);
            SizeF bmpSize = new SizeF(bmpContext.Width, bmpContext.Height);
            ICanvas canvas = bmpContext.Canvas;

            // Draw on the canvas with abstract methods that are agnostic to the renderer
            ClearBackground(canvas, bmpSize, Colors.Navy);
            DrawRandomLines(canvas, bmpSize, 1000);
            DrawBigTextWithShadow(canvas, "This is Maui.Graphics with Skia");
            SaveFig(bmpContext, Path.GetFullPath("quickstart.jpg"));
        }


        static void ClearBackground(ICanvas canvas, SizeF bmpSize, Color bgColor)
        {
            canvas.FillColor = Colors.Navy;
            canvas.FillRectangle(0, 0, bmpSize.Width, bmpSize.Height);
        }

        static void DrawRandomLines(ICanvas canvas, SizeF bmpSize, int count = 1000)
        {
            Random rand = new();
            for (int i = 0; i < count; i++)
            {
                canvas.StrokeSize = (float)rand.NextDouble() * 10;

                canvas.StrokeColor = new Color(
                    red: (float)rand.NextDouble(),
                    green: (float)rand.NextDouble(),
                    blue: (float)rand.NextDouble(),
                    alpha: .2f);

                canvas.DrawLine(
                    x1: (float)rand.NextDouble() * bmpSize.Width,
                    y1: (float)rand.NextDouble() * bmpSize.Height,
                    x2: (float)rand.NextDouble() * bmpSize.Width,
                    y2: (float)rand.NextDouble() * bmpSize.Height);
            }
        }

        static void DrawBigTextWithShadow(ICanvas canvas, string text)
        {
            canvas.FontSize = 36;
            canvas.FontColor = Colors.White;
            canvas.SetShadow(offset: new SizeF(2, 2), blur: 1, color: Colors.Black);
            canvas.DrawString(text, 20, 50, HorizontalAlignment.Left);
        }

        static void SaveFig(BitmapExportContext bmp, string filePath)
        {
            bmp.WriteToFile(filePath);
            Console.WriteLine($"WROTE: {filePath}");
        }
    }
}
