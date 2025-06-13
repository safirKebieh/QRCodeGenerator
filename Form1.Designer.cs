namespace QRCodeApp
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            button1 = new Button();
            txtUrlTarget = new TextBox();
            txtQrTitle = new TextBox();
            txtFileName = new TextBox();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            txtSaveLocation = new TextBox();
            label4 = new Label();
            SuspendLayout();
            // 
            // button1
            // 
            button1.Location = new Point(12, 214);
            button1.Name = "button1";
            button1.Size = new Size(781, 66);
            button1.TabIndex = 0;
            button1.Text = "Generate the QR Code";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // txtUrlTarget
            // 
            txtUrlTarget.Location = new Point(176, 12);
            txtUrlTarget.Name = "txtUrlTarget";
            txtUrlTarget.Size = new Size(612, 23);
            txtUrlTarget.TabIndex = 1;
            // 
            // txtQrTitle
            // 
            txtQrTitle.Location = new Point(176, 41);
            txtQrTitle.Name = "txtQrTitle";
            txtQrTitle.Size = new Size(612, 23);
            txtQrTitle.TabIndex = 1;
            // 
            // txtFileName
            // 
            txtFileName.Location = new Point(176, 70);
            txtFileName.Name = "txtFileName";
            txtFileName.Size = new Size(612, 23);
            txtFileName.TabIndex = 1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(7, 15);
            label1.Name = "label1";
            label1.Size = new Size(117, 15);
            label1.TabIndex = 2;
            label1.Text = "QR Code Target URL:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(7, 44);
            label2.Name = "label2";
            label2.Size = new Size(166, 15);
            label2.TabIndex = 2;
            label2.Text = "Text in the Center of QR Code:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(7, 73);
            label3.Name = "label3";
            label3.Size = new Size(63, 15);
            label3.TabIndex = 2;
            label3.Text = "File Name:";
            // 
            // txtSaveLocation
            // 
            txtSaveLocation.Location = new Point(176, 99);
            txtSaveLocation.Name = "txtSaveLocation";
            txtSaveLocation.Size = new Size(612, 23);
            txtSaveLocation.TabIndex = 1;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(7, 102);
            label4.Name = "label4";
            label4.Size = new Size(83, 15);
            label4.TabIndex = 2;
            label4.Text = "Save Location:";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 292);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(txtSaveLocation);
            Controls.Add(txtFileName);
            Controls.Add(txtQrTitle);
            Controls.Add(txtUrlTarget);
            Controls.Add(button1);
            Name = "Form1";
            Text = "QR-Code Generator";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button button1;
        private TextBox txtUrlTarget;
        private TextBox txtQrTitle;
        private TextBox txtFileName;
        private Label label1;
        private Label label2;
        private Label label3;
        private TextBox txtSaveLocation;
        private Label label4;
    }
}
