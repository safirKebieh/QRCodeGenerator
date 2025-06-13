using System;
using System.Drawing;
using System.Drawing.Imaging;
using QRCoder;

namespace QRCodeApp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using var qrGen = new QRCodeGenerator();
            using QRCodeData data = qrGen.CreateQrCode(txtUrlTarget.Text, QRCodeGenerator.ECCLevel.Q);

            // Use BitmapByteQRCode to generate a bitmap
            using var qrRenderer = new BitmapByteQRCode(data);
            byte[] qrBytes = qrRenderer.GetGraphic(20);

            // Convert to Bitmap
            using var ms = new System.IO.MemoryStream(qrBytes);
            using Bitmap qrImage = new Bitmap(ms);

            // Draw overlay
            using Graphics g = Graphics.FromImage(qrImage);
            string overlayText = txtQrTitle.Text;
            using Font font = new Font("Arial", 24, FontStyle.Bold);
            SizeF sz = g.MeasureString(overlayText, font);

            float x = (qrImage.Width - sz.Width) / 2;
            float y = (qrImage.Height - sz.Height) / 2;

            g.FillRectangle(Brushes.White, x - 10, y - 5, sz.Width + 20, sz.Height + 10);
            g.DrawString(overlayText, font, Brushes.Black, x, y);

            // Save
            qrImage.Save(Path.Combine(txtSaveLocation.Text, txtFileName.Text + ".png"), ImageFormat.Png);
        }
    }
}
