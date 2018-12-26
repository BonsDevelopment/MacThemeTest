using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MacTheme.Theme
{
    [ToolboxItem(false)]
    public class MacPanel : Panel
    {

        internal int CircleSize = 14;

        protected override void OnPaint(PaintEventArgs e)
        {
            SolidBrush exitBtnBrush = new SolidBrush(Color.FromArgb(255, 85, 81));
            SolidBrush minimizeBtnBrush = new SolidBrush(Color.FromArgb(255, 189, 0));
            SolidBrush maximizeBtnBrush = new SolidBrush(Color.FromArgb(0, 207, 39));

            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
            e.Graphics.TextRenderingHint = TextRenderingHint.AntiAliasGridFit;
            e.Graphics.InterpolationMode = InterpolationMode.High;


            e.Graphics.FillEllipse(exitBtnBrush,     10, Bounds.Y /2 + (CircleSize / 2), CircleSize, CircleSize);
            e.Graphics.FillEllipse(minimizeBtnBrush, 35, Bounds.Y / 2 + (CircleSize / 2), CircleSize, CircleSize);
            e.Graphics.FillEllipse(maximizeBtnBrush, 60, Bounds.Y / 2 + (CircleSize / 2), CircleSize, CircleSize);


            exitBtnBrush.Dispose();
            minimizeBtnBrush.Dispose();
            maximizeBtnBrush.Dispose();

            base.OnPaint(e);
        }
    }
}
