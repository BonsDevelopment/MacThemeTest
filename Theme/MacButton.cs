using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MacTheme.Theme
{
    [ToolboxItem(false)]
    class MacButton : Button
    {
        public string HoverChar { private get; set; }
        public Point BtnLocation { private get; set; }
        public Color BtnColor { private get; set; }

        private bool HoverTrigger = false;
        private Font drawFont = new Font("Arial", 6, FontStyle.Bold);

        public MacButton()
        {
            BackColor = Color.Transparent;
            FlatAppearance.BorderSize = 0;
            FlatAppearance.MouseOverBackColor = Color.Transparent;
            FlatAppearance.MouseDownBackColor = Color.Transparent;
            FlatStyle = FlatStyle.Flat;


            Size = new Size(12, 12);
            MouseEnter += MacButton_MouseEnter;
            MouseLeave += MacButton_MouseLeave;
            
        }

        private void MacButton_MouseLeave(object sender, EventArgs e)
        {
            HoverTrigger = false;
            Invalidate();
        }

        private void MacButton_MouseEnter(object sender, EventArgs e)
        {
            HoverTrigger = true;
            Cursor = Cursors.Hand;
            Invalidate();
        }

        /// <summary>
        /// Creates circle buttons and draws the character on hover
        /// </summary>
        /// <param name="pevent"></param>
        protected override void OnPaint(PaintEventArgs pevent)
        {
            base.OnPaint(pevent);
            using (GraphicsPath gPath = new GraphicsPath())
            {
                gPath.AddEllipse(0, 0, ClientSize.Width, ClientSize.Height);
                this.Region = new Region(gPath);
            }

            using (SolidBrush drawBrush = new SolidBrush(BtnColor))
            {
                if(HoverTrigger)
                  pevent.Graphics.DrawString(HoverChar, drawFont, drawBrush, BtnLocation.X, BtnLocation.Y);
            }

            Text = String.Empty;
        }
    }
}
