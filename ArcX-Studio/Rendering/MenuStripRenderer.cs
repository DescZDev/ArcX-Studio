using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

public class MenuRenderer : ToolStripProfessionalRenderer
{

    // Background of dropdown
    protected override void OnRenderToolStripBackground(ToolStripRenderEventArgs e)
    {
        e.Graphics.Clear(Color.FromArgb(37, 37, 38));
    }

    // Menu item background (hover/selected)
    protected override void OnRenderMenuItemBackground(ToolStripItemRenderEventArgs e)
    {
        Rectangle rect = new Rectangle(Point.Empty, e.Item.Size);

        if (e.Item.Selected || e.Item.Pressed)
        {
            using (SolidBrush b = new SolidBrush(Color.FromArgb(62, 62, 64)))
            {
                e.Graphics.FillRectangle(b, rect);
            }
        }
        else
        {
            using (SolidBrush b = new SolidBrush(Color.FromArgb(37, 37, 38)))
            {
                e.Graphics.FillRectangle(b, rect);
            }
        }
    }

    // Text color
    protected override void OnRenderItemText(ToolStripItemTextRenderEventArgs e)
    {
        e.TextColor = e.Item.Enabled ? Color.White : Color.Gray;
        base.OnRenderItemText(e);
    }

    // Separator line
    protected override void OnRenderSeparator(ToolStripSeparatorRenderEventArgs e)
    {
        int y = e.Item.Height / 2;

        using (Pen p = new Pen(Color.FromArgb(70, 70, 70)))
        {
            e.Graphics.DrawLine(p, 30, y, e.Item.Width - 10, y);
        }
    }

    // Image margin (left side where icons go)
    protected override void OnRenderImageMargin(ToolStripRenderEventArgs e)
    {
        Rectangle rect = new Rectangle(0, 0, 30, e.ToolStrip.Height);

        using (SolidBrush b = new SolidBrush(Color.FromArgb(37, 37, 38)))
        {
            e.Graphics.FillRectangle(b, rect);
        }
    }

    // Border around dropdown
    protected override void OnRenderToolStripBorder(ToolStripRenderEventArgs e)
    {
        Rectangle rect = new Rectangle(0, 0, e.ToolStrip.Width - 1, e.ToolStrip.Height - 1);

        using (Pen p = new Pen(Color.FromArgb(60, 60, 60)))
        {
            e.Graphics.DrawRectangle(p, rect);
        }
    }

    // Submenu arrow color
    protected override void OnRenderArrow(ToolStripArrowRenderEventArgs e)
    {
        e.ArrowColor = Color.White;
        base.OnRenderArrow(e);
    }

    // Checkmark rendering (for checked items)
    protected override void OnRenderItemCheck(ToolStripItemImageRenderEventArgs e)
    {
        Rectangle rect = new Rectangle(5, 2, 20, 20);

        using (SolidBrush b = new SolidBrush(Color.FromArgb(62, 62, 64)))
        {
            e.Graphics.FillRectangle(b, rect);
        }

        using (Pen p = new Pen(Color.White, 2))
        {
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;

            e.Graphics.DrawLines(p, new Point[]
            {
                new Point(rect.Left + 4, rect.Top + 10),
                new Point(rect.Left + 8, rect.Bottom - 5),
                new Point(rect.Right - 4, rect.Top + 5)
            });
        }
    }
}