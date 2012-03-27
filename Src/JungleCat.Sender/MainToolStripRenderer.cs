using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Windows.Forms;

namespace JungleCat.Common
{
    public class MainToolStripRenderer : ToolStripProfessionalRenderer 
    {
        private readonly Color foreground = Color.FromArgb(17, 17, 17);
        private readonly Color background = Color.FromArgb(192, 192, 0);

        protected override void OnRenderMenuItemBackground(ToolStripItemRenderEventArgs e)
        {
            Rectangle rc = new Rectangle(Point.Empty, e.Item.Size);
            Color bg = (e.Item.Selected ? background : foreground);
            using (SolidBrush brush = new SolidBrush(bg))
            {
                e.Graphics.FillRectangle(brush, rc);
            }
            e.ToolStrip.ForeColor = (e.Item.Selected ? background : foreground);
            e.Item.ForeColor = (e.Item.Selected ? foreground : background);

        }
    }
}
