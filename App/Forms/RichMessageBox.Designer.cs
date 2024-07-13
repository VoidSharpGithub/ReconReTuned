namespace App.Forms
{
    partial class RichMessageBox
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            OKButton = new Button();
            ContentsTextbox = new RichTextBox();
            CaptionLabel = new Label();
            SuspendLayout();
            // 
            // OKButton
            // 
            OKButton.Location = new Point(347, 301);
            OKButton.Name = "OKButton";
            OKButton.Size = new Size(75, 23);
            OKButton.TabIndex = 0;
            OKButton.Text = "OK";
            OKButton.UseVisualStyleBackColor = true;
            OKButton.Click += OKButton_Click;
            // 
            // ContentsTextbox
            // 
            ContentsTextbox.BackColor = SystemColors.ControlLight;
            ContentsTextbox.Location = new Point(12, 38);
            ContentsTextbox.Name = "ContentsTextbox";
            ContentsTextbox.Size = new Size(410, 257);
            ContentsTextbox.TabIndex = 1;
            ContentsTextbox.Text = "";
            // 
            // CaptionLabel
            // 
            CaptionLabel.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            CaptionLabel.Location = new Point(12, 9);
            CaptionLabel.Name = "CaptionLabel";
            CaptionLabel.Size = new Size(410, 26);
            CaptionLabel.TabIndex = 2;
            CaptionLabel.Text = "Caption Label";
            CaptionLabel.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // RichMessageBox
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(434, 336);
            Controls.Add(CaptionLabel);
            Controls.Add(ContentsTextbox);
            Controls.Add(OKButton);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "RichMessageBox";
            ShowIcon = false;
            ShowInTaskbar = false;
            StartPosition = FormStartPosition.CenterParent;
            Text = "RichMessageBox Title";
            ResumeLayout(false);
        }

        #endregion

        private Button OKButton;
        private RichTextBox ContentsTextbox;
        private Label CaptionLabel;
    }
}