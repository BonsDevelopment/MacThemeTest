using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MacTheme.Theme
{
    
    public class Container : ContainerControl
    {


        MacPanel TitleBar = new MacPanel();

        MacButton Maximize = new MacButton() { HoverChar = "➕", BtnLocation = new Point(1, 2), BtnColor = Color.FromArgb(21, 122, 30) };
        MacButton Minimize = new MacButton() { HoverChar = "▬", BtnLocation = new Point(1, 1), BtnColor = Color.FromArgb(147, 76, 37) };
        MacButton Exit = new MacButton() { HoverChar = "❌", BtnLocation = new Point(1,3), BtnColor = Color.FromArgb(135, 8, 7) };

        private Form pForm;
       
        public Container()
        {
            this.BackColor = Color.White;

            TitleBar.Dock = DockStyle.Top;
            TitleBar.Size = new System.Drawing.Size(this.Bounds.X, 30);
            TitleBar.BackColor = Color.FromArgb(255, 240, 240, 240);
            this.Controls.Add(TitleBar);


            Exit.Location = new Point(11,8);
            TitleBar.Controls.Add(Exit);

            Minimize.Location = new Point(36, 8);
            TitleBar.Controls.Add(Minimize);

            Maximize.Location = new Point(61, 8);
            TitleBar.Controls.Add(Maximize);


            EventSubscriptions();
        }


        private bool mouseDown = false;
        private Point lastLocation;

        private void EventSubscriptions()
        {
            Exit.Click += Exit_Click;
            Minimize.Click += Minimize_Click;
            Maximize.Click += Maximize_Click;

            TitleBar.MouseDown += (sender, e) => {mouseDown = true; lastLocation = e.Location; };
            TitleBar.MouseUp += (sender, e) => { mouseDown = false; };
            TitleBar.MouseMove += Title_MouseMove;
        }

        private void Title_MouseMove(object sender, MouseEventArgs e)
        {
            if (mouseDown)
            {
                if (Parent is Form)
                {
                    Parent.Location = new Point(
                        (Parent.Location.X - lastLocation.X) + e.X, (Parent.Location.Y - lastLocation.Y) + e.Y);
                }
                
            }
        }


        private void Maximize_Click(object sender, EventArgs e)
        {
            if(pForm.WindowState != FormWindowState.Maximized)
              pForm.WindowState = FormWindowState.Maximized;
            else
            {
                pForm.WindowState = FormWindowState.Normal;
            }
        }

        private void Minimize_Click(object sender, EventArgs e)
        {
            pForm.WindowState = FormWindowState.Minimized;
        }

        private void Exit_Click(object sender, EventArgs e)
        {
            pForm.Close();
        }

        /// <summary>
        /// Create everything with a drag and drop control, encapsulates the main form.
        /// </summary>
        /// <param name="e"></param>
        protected override void OnHandleCreated(EventArgs e)
        {
            Dock = DockStyle.Fill;
            if (Parent is Form)
            {
                Form parentForm = Parent as Form;
                pForm = parentForm;

                parentForm.FormBorderStyle = FormBorderStyle.None;

                base.OnHandleCreated(e);
            }
        }
    }
}
