using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameObjects.BL
{
    class GameObject
    {
        public char[,] shape;
        public Point startingPoint;
        public Boundary premises;
        public String direction;
        public int projectileSteps = 0;
        public string directionPatrol = "Right";
        public GameObject ()
        {
            this.shape = new char[1 , 3] { { '-' , '-' , '-' } };
            this.startingPoint = new Point(0 , 0);
            this.premises = new Boundary();
            this.direction = "LeftToRight";
        }
        public GameObject (char[,] shape , Point startingPoint)
        {
            this.shape = shape;
            this.startingPoint = startingPoint;
            this.premises = new Boundary();
            this.direction = "LeftToRight";
        }
        public GameObject (char[,] shape , Point startingPoint , Boundary premises , String direction)
        {
            this.shape = shape;
            this.startingPoint = startingPoint;
            this.premises = premises;
            this.direction = direction;
        }
        public void move ()
        {
            if (direction == "LeftToRight")
            {
                moveLeftToRight();
            }
            else if (direction == "RightToLeft")
            {
                moveRightToLeft();
            }
            else if (direction == "Diagonal")
            {
                topLeftDiagonal();

            }
            else if (direction == "Projectile")
            {
                if (projectileSteps <= 5)
                {
                    bottomRightDiagonal();
                    projectileSteps++;
                }
                else if (projectileSteps >= 5 && projectileSteps <= 7)
                {
                    moveLeftToRight();
                    projectileSteps++;
                }
                else if (projectileSteps >= 7 && projectileSteps <= 11)
                {
                    topLeftDiagonal();
                    projectileSteps++;
                }
            }
            else if (direction == "Patrol")
            {
                if (directionPatrol == "Right")
                {
                    moveLeftToRight();
                    if (startingPoint.y == premises.topRight.y)
                    {
                        directionPatrol = "Left";
                    }
                }
                else if (directionPatrol == "Left")
                {
                    moveRightToLeft();
                    if (startingPoint.y == premises.topLeft.y)
                    {
                        directionPatrol = "Right";
                    }
                }
            }
        }
        public void moveLeftToRight ()
        {
            if (startingPoint.y < premises.topRight.y)
            {
                startingPoint.y++;
            }
        }
        public void moveRightToLeft ()
        {
            if (startingPoint.y > premises.topLeft.y)
            {
                startingPoint.y--;
            }
        }
        public void topLeftDiagonal ()
        {
            if (startingPoint.getX() < premises.bottomRight.x && startingPoint.getY() < premises.bottomRight.y)
            {
                startingPoint.x++;
                startingPoint.y++;
            }
        }
        public void topRightDiagonal ()
        {
            if (startingPoint.getX() < premises.bottomLeft.x && startingPoint.getY() > premises.bottomLeft.y)
            {
                startingPoint.x++;
                startingPoint.y--;
            }
        }
        public void bottomRightDiagonal ()
        {
            if (startingPoint.getX() > premises.topLeft.x && startingPoint.getY() > premises.topLeft.y)
            {
                startingPoint.x--;
                startingPoint.y--;
            }
        }
        public void bottomLeftDiagonal ()
        {
            if (startingPoint.getX() > premises.topRight.x && startingPoint.getY() < premises.topRight.y)
            {
                startingPoint.x--;
                startingPoint.y++;
            }
        }

        public void draw ()
        {

            for (int i = 0 ; i < shape.GetLength(0) ; i++)
            {
                Console.SetCursorPosition(startingPoint.y + i , startingPoint.x);
                for (int j = 0 ; j < shape.GetLength(1) ; j++)
                {
                    Console.Write(shape[i , j]);
                }
            }
        }
    }
}
