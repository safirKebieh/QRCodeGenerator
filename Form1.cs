using System.Drawing.Imaging;

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
                // Generate QR code as a byte array from the input URL
                byte[] qrBytes = QrCodeImageHelper.GenerateQrCodeBytes(txtUrlTarget.Text);

                // Convert the QR code byte array into a Bitmap image
                using var qrImage = QrCodeImageHelper.ConvertBytesToBitmap(qrBytes);

                // Draw optional overlay text (e.g., title) in the center of the QR code image
                QrCodeImageHelper.DrawOverlayText(qrImage, txtQrTitle.Text);


                // Save to file
                string filePath = Path.Combine(txtSaveLocation.Text, txtFileName.Text + ".png");
                QrCodeImageHelper.SaveToFile(qrImage, filePath);


                MessageBox.Show("QR Code saved successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                ResetForm();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void ResetForm()
        {
            txtUrlTarget.Clear();
            txtQrTitle.Clear();
            txtSaveLocation.Clear();
            txtFileName.Clear();

            txtUrlTarget.Focus();
        }
    }
}
