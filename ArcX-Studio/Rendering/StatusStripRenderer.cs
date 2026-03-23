using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

public class StatusStripRenderer : ToolStripProfessionalRenderer
{
    protected override void OnRenderToolStripBackground(ToolStripRenderEventArgs e)
    {
        Rectangle rect = e.AffectedBounds;

        using (LinearGradientBrush brush = new LinearGradientBrush(
            rect,
            Color.FromArgb(30, 30, 30),   // top
            Color.FromArgb(45, 45, 45),   // bottom
            LinearGradientMode.Vertical))
        {
            e.Graphics.FillRectangle(brush, rect);
        }
    }

    protected override void OnRenderToolStripBorder(ToolStripRenderEventArgs e)
    {
        using (Pen pen = new Pen(Color.FromArgb(51, 51, 55)))
        {
            e.Graphics.DrawRectangle(
                pen,
                0,
                0,
                e.ToolStrip.Width - 1,
                e.ToolStrip.Height - 1);
        }
    }
}
