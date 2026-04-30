namespace SimplePaint
{
    using System;
    using System.Drawing;
    using System.Drawing.Drawing2D;
    using System.Drawing.Imaging;
    using System.IO;
    using System.Drawing.Printing;
    using System.Windows.Forms;

    public partial class Form1 : Form
    {
        enum ToolType{ Line, Rectangle, Circle }  // 사용할도형타입
            
        private Bitmap canvasBitmap;          // 실제그림이저장되는비트맵
        private Graphics canvasGraphics;      // 비트맵위에그리기위한객체

        private bool isDrawing = false;       // 현재드래그중인지여부
        private Point startPoint;             // 드래그시작점
        private Point endPoint;               // 드래그끝점

        private ToolType currentTool= ToolType.Line;  // 현재선택된도형
        private Color currentColor = Color.Black;      // 현재색상
        private int currentLineWidth = 2;              // 현재선두께
        private float zoom = 1.0f;

        public Form1()
        {
            InitializeComponent();

            // Create an initially large canvas (use panel size or fallback to original 712x421)
            int initWidth = Math.Max(712, pnlCanvas.ClientSize.Width);
            int initHeight = Math.Max(421, pnlCanvas.ClientSize.Height);
            canvasBitmap = new Bitmap(initWidth, initHeight);
            canvasGraphics = Graphics.FromImage(canvasBitmap);
            canvasGraphics.Clear(Color.White);   // 캔버스를흰색으로초기화

            // ensure zoom default and update displayed preview
            zoom = 1.0f;
            UpdatePreviewImage();

            // 마우스이벤트연결
            picCanvas.MouseDown += PicCanvas_MouseDown;
            picCanvas.MouseMove += PicCanvas_MouseMove;
            picCanvas.MouseUp += PicCanvas_MouseUp;

            // picCanvas가 다시 그려질 때 PicCanvas_Paint 함수를 실행하도록 연결
            picCanvas.Paint += PicCanvas_Paint; 

            // 도형 선택 버튼 이벤트 연결
            btnLine.Click += btnLine_Click;
            btnRectangle.Click += btnRectangle_Click;
            btnCircle.Click += btnCircle_Click;

            // 색상 콤보박스 이벤트 연결
            cmbColor.SelectedIndexChanged += cmbColor_SelectedIndexChanged;
            cmbColor.SelectedIndex = 0;

            // 선 두께 트랙바 이벤트연결
            trbLine.Minimum = 1;    // 최소값
            trbLine.Maximum = 10;   // 최대값
            trbLine.Value = 2;
            trbLine.ValueChanged += trbLine_ValueChanged;
            // 파일 저장 버튼 이벤트 연결
            btnSaveFile.Click += btnSaveFile_Click;
            // 파일 열기 버튼 이벤트 연결
            btnOpenFile.Click += btnOpenFile_Click;
            // 줌 버튼 이벤트 연결
            btnZoomIn.Click += BtnZoomIn_Click;
            btnZoomOut.Click += BtnZoomOut_Click;
        }

        private void BtnZoomOut_Click(object sender, EventArgs e)
        {
            SetZoom(zoom / 1.2f);
        }

        private void BtnZoomIn_Click(object sender, EventArgs e)
        {
            SetZoom(zoom * 1.2f);
        }

        private void SetZoom(float newZoom)
        {
            zoom = Math.Max(0.1f, Math.Min(10f, newZoom));
            if (picCanvas.Image != null)
            {
                picCanvas.Width = (int)(canvasBitmap.Width * zoom);
                picCanvas.Height = (int)(canvasBitmap.Height * zoom);
                // When using AutoSize, need to change SizeMode to Normal to reflect set size
                picCanvas.SizeMode = PictureBoxSizeMode.Normal;
                // Create a scaled copy for display
                UpdatePreviewImage();
            }
        }

        private void UpdatePreviewImage()
        {
            if (canvasBitmap == null) return;
            // Dispose previous displayed image if it's not the backing bitmap
            if (picCanvas.Image != null && !ReferenceEquals(picCanvas.Image, canvasBitmap))
            {
                var old = picCanvas.Image;
                picCanvas.Image = null;
                old.Dispose();
            }

            // create scaled image for display
            Bitmap display = new Bitmap((int)(canvasBitmap.Width * zoom), (int)(canvasBitmap.Height * zoom));
            using (Graphics g = Graphics.FromImage(display))
            {
                g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
                g.Clear(Color.White);
                g.DrawImage(canvasBitmap, new Rectangle(0, 0, display.Width, display.Height), new Rectangle(0, 0, canvasBitmap.Width, canvasBitmap.Height), GraphicsUnit.Pixel);
            }
            picCanvas.Image = display;
            picCanvas.Width = display.Width;
            picCanvas.Height = display.Height;
        }

        private void btnOpenFile_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog dlg = new OpenFileDialog())
            {
                dlg.Title = "이미지 열기";
                dlg.Filter = "Image Files|*.png;*.jpg;*.jpeg;*.bmp;*.gif|All Files|*.*";
                if (dlg.ShowDialog() != DialogResult.OK) return;

                // Load image from file
                Image img;
                using (var fs = File.OpenRead(dlg.FileName))
                {
                    img = Image.FromStream(fs);
                }

                // Dispose previous canvas resources
                canvasGraphics?.Dispose();
                canvasBitmap?.Dispose();

                // Create new backing bitmap sized to the loaded image
                canvasBitmap = new Bitmap(img.Width, img.Height);
                canvasGraphics = Graphics.FromImage(canvasBitmap);
                canvasGraphics.Clear(Color.White);
                canvasGraphics.DrawImage(img, 0, 0, img.Width, img.Height);
                img.Dispose();

                // set initial zoom to fit panel if image larger than panel
                float zoomX = (float)pnlCanvas.ClientSize.Width / canvasBitmap.Width;
                float zoomY = (float)pnlCanvas.ClientSize.Height / canvasBitmap.Height;
                zoom = Math.Min(1.0f, Math.Min(zoomX, zoomY));

                UpdatePreviewImage();
            }
        }

        private void PicCanvas_MouseDown(object sender, MouseEventArgs e)
        {
            isDrawing = true;             // 드래그 시작
            startPoint = e.Location;      // 시작점 저장
        }

        private void PicCanvas_MouseMove(object sender, MouseEventArgs e)
        {
            if (!isDrawing) return;       // 그림 그리기와 상관없는 마우스 움직임은 무시

            endPoint = e.Location;        // 현재 위치 갱신

            // picCanvas를 다시 그려라 (Paint 이벤트를 발생시킨다)
            picCanvas.Invalidate();       // 화면 다시 그리기 (미리보기)
        }

        private void PicCanvas_MouseUp(object sender, MouseEventArgs e)
        {
            if (!isDrawing) return;     // 그림그리기와상관없는마우스움직임은무시

            isDrawing = false;
            endPoint = e.Location;

            if (canvasGraphics != null && canvasBitmap != null)
            {
                // Map control (picturebox) coordinates to bitmap coordinates according to current zoom
                Point p1 = new Point((int)(startPoint.X / zoom), (int)(startPoint.Y / zoom));
                Point p2 = new Point((int)(endPoint.X / zoom), (int)(endPoint.Y / zoom));

                using (Pen pen = new Pen(currentColor, Math.Max(1, (int)(currentLineWidth / zoom))))
                {
                    // When drawing to the bitmap, use bitmap coordinates
                    DrawShape(canvasGraphics, pen, p1, p2);
                }

                // Update displayed (possibly scaled) preview image so the drawn shape is visible on top
                UpdatePreviewImage();
            }
            else
            {
                picCanvas.Invalidate();
            }
        }

        private void PicCanvas_Paint(object sender, PaintEventArgs e)
        {
            if (!isDrawing) return;

            using (Pen previewPen = new Pen(currentColor, Math.Max(1, (int)(currentLineWidth / zoom))))
            {
                previewPen.DashStyle = DashStyle.Dash;

                // Draw preview scaled to match the displayed image
                // Map points from control (display) coordinates to bitmap coordinates then back scaled for display
                Point p1 = new Point((int)(startPoint.X / zoom), (int)(startPoint.Y / zoom));
                Point p2 = new Point((int)(endPoint.X / zoom), (int)(endPoint.Y / zoom));

                // Now scale back to display coordinates so preview draws on top of displayed image correctly
                Point dp1 = new Point((int)(p1.X * zoom), (int)(p1.Y * zoom));
                Point dp2 = new Point((int)(p2.X * zoom), (int)(p2.Y * zoom));

                DrawShape(e.Graphics, previewPen, dp1, dp2);
            }
        }

        private void DrawShape(Graphics g, Pen pen, Point p1, Point p2)
        {
            Rectangle rect = GetRectangle(p1, p2);
            switch (currentTool)
            {
                case ToolType.Line:
                    g.DrawLine(pen, p1, p2);
                    break;
                case ToolType.Rectangle:
                    g.DrawRectangle(pen, rect);
                    break;
                case ToolType.Circle:
                    g.DrawEllipse(pen, rect);
                    break;
            }
        }

        private void btnLine_Click(object sender, EventArgs e)
        {
            currentTool = ToolType.Line;
        }

        private void btnRectangle_Click(object sender, EventArgs e)
        {
            currentTool = ToolType.Rectangle;
        }

        private void btnCircle_Click(object sender, EventArgs e)
        {
            currentTool = ToolType.Circle;
        }

        private void cmbColor_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (cmbColor.SelectedIndex)
            {
                case 0: // Black 검정
                    currentColor = Color.Black;
                    break;
                case 1: // Red 빨강
                    currentColor = Color.Red;
                    break;
                case 2: // Blue 파랑
                    currentColor = Color.Blue;
                    break;
                case 3: // Green 녹색
                    currentColor = Color.Green;
                    break;
                default:
                    currentColor = Color.Black;
                    break;
            }
        }

        private void trbLine_ValueChanged(object sender, EventArgs e)
        {
            currentLineWidth = trbLine.Value;
        }

        private void btnSaveFile_Click(object sender, EventArgs e)
        {
            using (SaveFileDialog dlg = new SaveFileDialog())
            {
                dlg.Title = "이미지로 저장";
                dlg.Filter = "PNG Image|*.png|JPEG Image|*.jpg;*.jpeg|Bitmap Image|*.bmp";
                dlg.DefaultExt = "png";
                dlg.AddExtension = true;
                dlg.OverwritePrompt = true;

                if (dlg.ShowDialog() != DialogResult.OK) return;

                string path = dlg.FileName;
                string ext = Path.GetExtension(path).ToLowerInvariant();
                ImageFormat fmt = ImageFormat.Png;
                switch (ext)
                {
                    case ".png":
                        fmt = ImageFormat.Png;
                        break;
                    case ".jpg":
                    case ".jpeg":
                        fmt = ImageFormat.Jpeg;
                        break;
                    case ".bmp":
                        fmt = ImageFormat.Bmp;
                        break;
                    default:
                        // if unknown extension, default to png and append extension
                        path = path + ".png";
                        fmt = ImageFormat.Png;
                        break;
                }

                // Save the current canvas bitmap to file
                canvasBitmap.Save(path, fmt);
            }
        }
        private Rectangle GetRectangle(Point p1, Point p2)
        {
            return new Rectangle(
                Math.Min(p1.X, p2.X),
                Math.Min(p1.Y, p2.Y),
                Math.Abs(p1.X - p2.X),
                Math.Abs(p1.Y - p2.Y)
             );
        }
        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }   
}

