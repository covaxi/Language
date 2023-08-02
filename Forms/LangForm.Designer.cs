namespace WinFormsApp1
{
    partial class LangForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LangForm));
            langLabel = new Label();
            pictureBox1 = new PictureBox();
            timeLabel = new Label();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // langLabel
            // 
            langLabel.Font = new Font("Consolas", 26.25F, FontStyle.Regular, GraphicsUnit.Point);
            langLabel.ForeColor = Color.White;
            langLabel.Location = new Point(160, 416);
            langLabel.Name = "langLabel";
            langLabel.Size = new Size(480, 54);
            langLabel.TabIndex = 0;
            langLabel.Text = "Put your country name hare!!11oneone";
            langLabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // pictureBox1
            // 
            pictureBox1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            pictureBox1.BackgroundImageLayout = ImageLayout.None;
            pictureBox1.InitialImage = (Image)resources.GetObject("pictureBox1.InitialImage");
            pictureBox1.Location = new Point(160, 53);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(480, 360);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 1;
            pictureBox1.TabStop = false;
            // 
            // timeLabel
            // 
            timeLabel.Font = new Font("Consolas", 26.25F, FontStyle.Regular, GraphicsUnit.Point);
            timeLabel.ForeColor = Color.White;
            timeLabel.Location = new Point(160, 9);
            timeLabel.Name = "timeLabel";
            timeLabel.Size = new Size(480, 41);
            timeLabel.TabIndex = 2;
            timeLabel.Text = "99:99:99.999";
            timeLabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // LangForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.DimGray;
            ClientSize = new Size(800, 469);
            Controls.Add(timeLabel);
            Controls.Add(pictureBox1);
            Controls.Add(langLabel);
            FormBorderStyle = FormBorderStyle.None;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "LangForm";
            Opacity = 0.75D;
            ShowIcon = false;
            ShowInTaskbar = false;
            SizeGripStyle = SizeGripStyle.Hide;
            TopMost = true;
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        public Label langLabel;
        private PictureBox pictureBox1;
        private Label timeLabel;
    }
}