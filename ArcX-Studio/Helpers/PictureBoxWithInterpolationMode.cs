using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using System.Windows.Forms;

namespace ArcX_Studio
{
    public class PictureBoxWithInterpolationMode : PictureBox
    {
        private float _opacity = 1f;
        private Image _nextImage;
        private Timer _fadeTimer;
        private bool _fadingOut;

        public InterpolationMode InterpolationMode { get; set; } = InterpolationMode.NearestNeighbor;
        public bool KeepAspectRatio { get; set; } = true;
        public bool DrawFrame { get; set; } = false;
        public Color FrameColor { get; set; } = Color.FromArgb(255, 200, 160, 30); 
        public int FrameThickness { get; set; } = 4;

        public PictureBoxWithInterpolationMode()
        {
            SetStyle(ControlStyles.OptimizedDoubleBuffer | ControlStyles.UserPaint | ControlStyles.AllPaintingInWmPaint, true); UpdateStyles();
            this.SizeMode = PictureBoxSizeMode.Zoom;
            this.DoubleBuffered = true;
        }

        public void SetImageWithFade(Image newImage, int durMs)
        {
            if (Image == null)
            {
                Image = new Bitmap(newImage);
                _opacity = 1f;
                Invalidate();
                return;
            }

            _nextImage = new Bitmap(newImage);
            _fadingOut = true;

            int interval = 30;
            int steps = Math.Max(1, durMs / interval);
            int step = 0;

            _fadeTimer?.Stop();
            _fadeTimer?.Dispose();

            _fadeTimer = new Timer { Interval = interval };
            _fadeTimer.Tick += (s, e) =>
            {
                step++;
                if (_fadingOut)
                {
                    _opacity = 1f - (float)step / steps;
                    if (_opacity < 0f)
                    {
                        Image?.Dispose();
                        Image = _nextImage;
                        _nextImage = null;

                        _fadingOut = false;
                        step = 0;
                        _opacity = 0f;
                    }
                }
                else
                {
                    _opacity = (float)step / steps;

                    if (_opacity >= 1f)
                    {
                        _opacity = 1f;
                        _fadeTimer.Stop();
                        _fadeTimer.Dispose();
                    }
                    Invalidate();
                }
            };
            _fadeTimer.Start();
        }

        protected override void OnPaintBackground(PaintEventArgs pevent)
        {
            using (var brush = new LinearGradientBrush(
                this.ClientRectangle,
                Color.FromArgb(32, 32, 30),
                Color.FromArgb(45, 45, 85),
                LinearGradientMode.Vertical))
            {
                pevent.Graphics.FillRectangle(brush, this.ClientRectangle);
            }
        }

        protected override void OnPaint(PaintEventArgs pe)
        {
            var g = pe.Graphics;
            g.Clear(this.BackColor);

            g.InterpolationMode = this.InterpolationMode;
            g.SmoothingMode = SmoothingMode.HighQuality;
            g.PixelOffsetMode = PixelOffsetMode.HighQuality;
            g.CompositingQuality = CompositingQuality.HighSpeed;

            if (this.Image != null)
            {
                Rectangle dest;
                if (!KeepAspectRatio)
                {
                    dest = new Rectangle(0, 0, this.ClientSize.Width, this.ClientSize.Height);
                }
                else
                {
                    int boxW = this.ClientSize.Width;
                    int boxH = this.ClientSize.Height;
                    float imgW = this.Image.Width;
                    float imgH = this.Image.Height;
                    float scale = Math.Min((float)boxW / imgW, (float)boxH / imgH);
                    int drawW = Math.Max(1, (int)(imgW * scale));
                    int drawH = Math.Max(1, (int)(imgH * scale));
                    int drawX = (boxW - drawW) / 2;
                    int drawY = (boxH - drawH) / 2;
                    dest = new Rectangle(drawX, drawY, drawW, drawH);
                }

                using (var ia = new ImageAttributes())
                {
                    g.DrawImage(this.Image, dest, 0, 0, this.Image.Width, this.Image.Height, GraphicsUnit.Pixel, ia);
                }

                // draw border/frame (inset so frame doesn't overlap image content)
                if (DrawFrame && FrameThickness > 0)
                {
                    int inset = FrameThickness / 2;
                    using (var pen = new Pen(FrameColor, FrameThickness))
                    {
                        pen.Alignment = PenAlignment.Center;
                        var r = new Rectangle(inset, inset, this.ClientSize.Width - FrameThickness, this.ClientSize.Height - FrameThickness);
                        g.DrawRectangle(pen, r);
                    }
                }
            }
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                this.Image?.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}

