namespace SimplePaint
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            lblAppName = new Label();
            groupBox1 = new GroupBox();
            btnCircle = new Button();
            btnRectangle = new Button();
            btnLine = new Button();
            groupBox2 = new GroupBox();
            cmbColor = new ComboBox();
            groupBox3 = new GroupBox();
            trbLine = new TrackBar();
            btnOpenFile = new Button();
            btnZoomIn = new Button();
            btnZoomOut = new Button();
            btnSaveFile = new Button();
            picCanvas = new PictureBox();
            pnlCanvas = new Panel();
            groupBox1.SuspendLayout();
            groupBox2.SuspendLayout();
            groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)trbLine).BeginInit();
            ((System.ComponentModel.ISupportInitialize)picCanvas).BeginInit();
            SuspendLayout();
            // 
            // lblAppName
            // 
            lblAppName.AutoSize = true;
            lblAppName.Font = new Font("맑은 고딕", 27.75F, FontStyle.Bold, GraphicsUnit.Point, 129);
            lblAppName.ForeColor = Color.Red;
            lblAppName.Location = new Point(22, 24);
            lblAppName.Name = "lblAppName";
            lblAppName.Size = new Size(243, 50);
            lblAppName.TabIndex = 0;
            lblAppName.Text = "Simple Paint";
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(btnCircle);
            groupBox1.Controls.Add(btnRectangle);
            groupBox1.Controls.Add(btnLine);
            groupBox1.Location = new Point(37, 121);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(209, 115);
            groupBox1.TabIndex = 1;
            groupBox1.TabStop = false;
            groupBox1.Text = "도형 선택";
            // 
            // btnCircle
            // 
            btnCircle.Image = (Image)resources.GetObject("btnCircle.Image");
            btnCircle.Location = new Point(140, 22);
            btnCircle.Name = "btnCircle";
            btnCircle.Size = new Size(61, 80);
            btnCircle.TabIndex = 4;
            btnCircle.Text = "원";
            btnCircle.TextAlign = ContentAlignment.BottomCenter;
            btnCircle.UseVisualStyleBackColor = true;
            // 
            // btnRectangle
            // 
            btnRectangle.Image = (Image)resources.GetObject("btnRectangle.Image");
            btnRectangle.Location = new Point(73, 22);
            btnRectangle.Name = "btnRectangle";
            btnRectangle.Size = new Size(61, 80);
            btnRectangle.TabIndex = 3;
            btnRectangle.Text = "사각형";
            btnRectangle.TextAlign = ContentAlignment.BottomCenter;
            btnRectangle.UseVisualStyleBackColor = true;
            // 
            // btnLine
            // 
            btnLine.Image = (Image)resources.GetObject("btnLine.Image");
            btnLine.Location = new Point(6, 22);
            btnLine.Name = "btnLine";
            btnLine.Size = new Size(61, 80);
            btnLine.TabIndex = 2;
            btnLine.Text = " 직선";
            btnLine.TextAlign = ContentAlignment.BottomCenter;
            btnLine.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(cmbColor);
            groupBox2.Location = new Point(264, 121);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(138, 115);
            groupBox2.TabIndex = 5;
            groupBox2.TabStop = false;
            groupBox2.Text = "색 선택";
            // 
            // cmbColor
            // 
            cmbColor.FormattingEnabled = true;
            cmbColor.Items.AddRange(new object[] { "Black 검정", "Red 빨강", "Blue 파랑", "Green 녹색" });
            cmbColor.Location = new Point(6, 51);
            cmbColor.Name = "cmbColor";
            cmbColor.Size = new Size(126, 23);
            cmbColor.TabIndex = 0;
            // 
            // groupBox3
            // 
            groupBox3.Controls.Add(trbLine);
            groupBox3.Location = new Point(421, 121);
            groupBox3.Name = "groupBox3";
            groupBox3.Size = new Size(138, 115);
            groupBox3.TabIndex = 6;
            groupBox3.TabStop = false;
            groupBox3.Text = "선 두께";
            // 
            // trbLine
            // 
            trbLine.Location = new Point(6, 51);
            trbLine.Name = "trbLine";
            trbLine.Size = new Size(126, 45);
            trbLine.TabIndex = 1;
            // 
            // btnOpenFile
            // 
            btnOpenFile.BackColor = SystemColors.GradientActiveCaption;
            btnOpenFile.Font = new Font("맑은 고딕", 18F, FontStyle.Bold, GraphicsUnit.Point, 129);
            btnOpenFile.ForeColor = SystemColors.ControlText;
            btnOpenFile.Location = new Point(577, 139);
            btnOpenFile.Name = "btnOpenFile";
            btnOpenFile.Size = new Size(83, 77);
            btnOpenFile.TabIndex = 7;
            btnOpenFile.Text = "열기";
            btnOpenFile.UseVisualStyleBackColor = false;
            // 
            // btnSaveFile
            // 
            btnSaveFile.BackColor = SystemColors.GradientActiveCaption;
            btnSaveFile.Font = new Font("맑은 고딕", 18F, FontStyle.Bold, GraphicsUnit.Point, 129);
            btnSaveFile.ForeColor = SystemColors.ControlText;
            btnSaveFile.Location = new Point(666, 139);
            btnSaveFile.Name = "btnSaveFile";
            btnSaveFile.Size = new Size(83, 77);
            btnSaveFile.TabIndex = 8;
            btnSaveFile.Text = "저장";
            btnSaveFile.UseVisualStyleBackColor = false;
            // 
            // pnlCanvas
            // 
            pnlCanvas.AutoScroll = true;
            pnlCanvas.Location = new Point(37, 259);
            pnlCanvas.Name = "pnlCanvas";
            pnlCanvas.Size = new Size(712, 421);
            pnlCanvas.TabIndex = 9;
            // 
            // picCanvas
            // 
            picCanvas.BackColor = SystemColors.ButtonHighlight;
            picCanvas.BorderStyle = BorderStyle.FixedSingle;
            picCanvas.Location = new Point(0, 0);
            picCanvas.Name = "picCanvas";
            picCanvas.SizeMode = PictureBoxSizeMode.AutoSize;
            picCanvas.TabIndex = 0;
            picCanvas.TabStop = false;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(805, 707);
            Controls.Add(pnlCanvas);
            Controls.Add(btnSaveFile);
            Controls.Add(btnOpenFile);
            Controls.Add(groupBox3);
            Controls.Add(groupBox2);
            Controls.Add(groupBox1);
            Controls.Add(lblAppName);
            Name = "Form1";
            Text = "Simple Paint v1.0";
            Load += Form1_Load;
            pnlCanvas.Controls.Add(picCanvas);
            // 
            // btnZoomIn
            // 
            btnZoomIn.Location = new Point(577, 222);
            btnZoomIn.Name = "btnZoomIn";
            btnZoomIn.Size = new Size(83, 30);
            btnZoomIn.TabIndex = 10;
            btnZoomIn.Text = "+";
            btnZoomIn.UseVisualStyleBackColor = true;
            // 
            // btnZoomOut
            // 
            btnZoomOut.Location = new Point(666, 222);
            btnZoomOut.Name = "btnZoomOut";
            btnZoomOut.Size = new Size(83, 30);
            btnZoomOut.TabIndex = 11;
            btnZoomOut.Text = "-";
            btnZoomOut.UseVisualStyleBackColor = true;
            Controls.Add(btnZoomIn);
            Controls.Add(btnZoomOut);
            groupBox1.ResumeLayout(false);
            groupBox2.ResumeLayout(false);
            groupBox3.ResumeLayout(false);
            groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)trbLine).EndInit();
            ((System.ComponentModel.ISupportInitialize)picCanvas).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblAppName;
        private GroupBox groupBox1;
        private Button btnCircle;
        private Button btnRectangle;
        private Button btnLine;
        private GroupBox groupBox2;
        private ComboBox cmbColor;
        private GroupBox groupBox3;
        private TrackBar trbLine;
        private Button btnOpenFile;
        private Button btnSaveFile;
        private Button btnZoomIn;
        private Button btnZoomOut;
        private Panel pnlCanvas;
        private PictureBox picCanvas;
    }
}
