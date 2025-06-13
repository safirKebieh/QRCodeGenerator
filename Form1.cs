using System.Drawing.Imaging;
using QRCoder;

namespace QRCodeApp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            ToolTipHelper.SetToolTips(toolTip1, txtUrlTarget, txtQrTitle, txtFileName, txtSaveLocation);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtUrlTarget.Text) ||
                string.IsNullOrWhiteSpace(txtSaveLocation.Text) ||
                string.IsNullOrWhiteSpace(txtFileName.Text))
            {
                MessageBox.Show("Please fill in all fields.", "Missing Input", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                // Generate QR Code
                using var qrGen = new QRCodeGenerator();
                using var data = qrGen.CreateQrCode(txtUrlTarget.Text, QRCodeGenerator.ECCLevel.Q);
                using var qrRenderer = new BitmapByteQRCode(data);
                byte[] qrBytes = qrRenderer.GetGraphic(20);

                // Convert to Bitmap
                using var ms = new MemoryStream(qrBytes);
                using var qrImage = new Bitmap(ms);

                // Draw overlay text
                DrawOverlayText(qrImage, txtQrTitle.Text);

                // Save to file
                string filePath = Path.Combine(txtSaveLocation.Text, txtFileName.Text + ".png");
                qrImage.Save(filePath, ImageFormat.Png);

                MessageBox.Show("QR Code saved successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                ResetForm();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void DrawOverlayText(Bitmap bitmap, string text)
        {
            using Graphics g = Graphics.FromImage(bitmap);
            using Font font = new Font("Arial", 24, FontStyle.Bold);

            SizeF sz = g.MeasureString(text, font);
            float x = (bitmap.Width - sz.Width) / 2;
            float y = (bitmap.Height - sz.Height) / 2;

            g.FillRectangle(Brushes.White, x - 10, y - 5, sz.Width + 20, sz.Height + 10);
            g.DrawString(text, font, Brushes.Black, x, y);
        }

        private void ResetForm()
        {
            txtUrlTarget.Clear();
            txtQrTitle.Clear();
            txtSaveLocation.Clear();
            txtFileName.Clear();
        }
    }
}
