using QRCoder;
using System;
using System.Collections.Generic;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QRCodeApp
{
    /// <summary>
    /// Provides helper methods for generating and manipulating QR code images.
    /// </summary>
    public class QrCodeImageHelper
    {

        /// <summary>
        /// Generates a QR code as a byte array from the specified URL.
        /// </summary>
        /// <param name="url">The public URL to encode in the QR code.</param>
        /// <returns>A byte array representing the QR code image.</returns>
        public static byte[] GenerateQrCodeBytes(string url)
        {
            using var qrGen = new QRCoder.QRCodeGenerator();
            using var data = qrGen.CreateQrCode(url, QRCoder.QRCodeGenerator.ECCLevel.Q);
            using var qrRenderer = new BitmapByteQRCode(data);
            return qrRenderer.GetGraphic(20);
        }

        /// <summary>
        /// Converts a QR code byte array to a Bitmap object.
        /// </summary>
        /// <param name="qrBytes">The byte array representing the QR code image.</param>
        /// <returns>A Bitmap object of the QR code.</returns>
        public static Bitmap ConvertBytesToBitmap(byte[] qrBytes)
        {
            using var ms = new MemoryStream(qrBytes);
            return new Bitmap(ms);
        }

        /// <summary>
        /// Draws overlay text at the center of the specified bitmap image.
        /// </summary>
        /// <param name="bitmap">The bitmap to draw on.</param>
        /// <param name="text">The text to draw in the center of the image.</param>
        public static void DrawOverlayText(Bitmap bitmap, string text)
        {
            using Graphics g = Graphics.FromImage(bitmap);
            using Font font = new Font("Arial", 24, FontStyle.Bold);

            SizeF sz = g.MeasureString(text, font);
            float x = (bitmap.Width - sz.Width) / 2;
            float y = (bitmap.Height - sz.Height) / 2;

            g.FillRectangle(Brushes.White, x - 10, y - 5, sz.Width + 20, sz.Height + 10);
            g.DrawString(text, font, Brushes.Black, x, y);
        }

        public static void SaveToFile(Bitmap bitmap, string filePath)
        {
            if (!Directory.Exists(Path.GetDirectoryName(filePath)))
                Directory.CreateDirectory(Path.GetDirectoryName(filePath));

            bitmap.Save(filePath, ImageFormat.Png);
        }

    }
}
