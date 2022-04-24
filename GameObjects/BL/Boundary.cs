using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameObjects.BL
{
    class Boundary
    {
        private Point topLeft;
        private Point topRight;
        private Point bottomLeft;
        private Point bottomRight;
        public Boundary ()
        {
            this.topLeft = new Point(0 , 0);
            this.topRight = new Point(0 , 90);
            this.bottomLeft = new Point(90 , 0);
            this.bottomRight = new Point(90 , 90);
        }
        public Boundary (Point topLeft , Point topRight , Point bottomLeft , Point bottomRight)
        {
            this.topLeft = topLeft;
            this.topRight = topRight;
            this.bottomLeft = bottomLeft;
            this.bottomRight = bottomRight;
        }
        public Point getTopLeft ()
        {
            return topLeft;
        }
        public Point getBottomLeft ()
        {
            return bottomLeft;
        }
        public Point getTopRight ()
        {
            return topRight;
        }
        public Point getBottomRight ()
        {
            return bottomRight;
        }

    }
}
