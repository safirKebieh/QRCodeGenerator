using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QRCodeApp
{
    public class ToolTipHelper
    {
        public static void SetToolTips(ToolTip toolTip, TextBox txtUrl, TextBox txtTitle, TextBox txtFileName, TextBox txtSavePath)
        {
            toolTip.SetToolTip(txtUrl, "Enter the full URL to be encoded into a QR Code (e.g. https://example.com)");
            toolTip.SetToolTip(txtTitle, "Optional: This text will appear in the center of the QR Code.");
            toolTip.SetToolTip(txtFileName, "Name the output file (without extension). A .png file will be created.");
            toolTip.SetToolTip(txtSavePath, "Specify the full path where the QR code image will be saved.");
        }
    }
}
