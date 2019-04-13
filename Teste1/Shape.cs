using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Teste1
{
    public class Shape
    {

        public PointF pt1;
        public PointF pt2;
        public Color color = Color.Black;

        public void Draw(Graphics g)
        {
            using (Pen p = new Pen(color, g.VisibleClipBounds.Width / 100))
            {
                g.DrawLine(p, pt1, pt2);
            }
        }
    }
}
