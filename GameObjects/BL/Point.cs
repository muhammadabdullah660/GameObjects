using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameObjects.BL
{
    class Point
    {
        private int x;
        private int y;
        public Point ()
        {
            x = 0;
            y = 0;
        }
        public Point (int x , int y)
        {
            this.x = x;
            this.y = y;
        }
        public int getX ()
        {
            return this.x;
        }
        public int getY ()
        {
            return this.y;
        }
        public void setX (int x)
        {
            this.x = x;
        }
        public void setY (int y)
        {
            this.y = y;
        }
        public void setXY (int x , int y)
        {
            this.x = x;
            this.y = y;
        }

    }
}
