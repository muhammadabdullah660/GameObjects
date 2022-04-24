using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameObjects.BL
{
    class GameObject
    {
        private char[,] shape;
        private Point startingPoint;
        private Boundary premises;
        private String direction;
        private int projectileSteps = 0;
        private string directionPatrol = "Right";
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
                if (projectileSteps <= 10)
                {
                    Console.WriteLine(projectileSteps);

                    bottomLeftDiagonal();
                    projectileSteps++;
                }
                else if (projectileSteps >= 10 && projectileSteps <= 20)
                {
                    Console.WriteLine(projectileSteps);

                    moveLeftToRight();
                    projectileSteps++;
                }
                else if (projectileSteps >= 20 && projectileSteps <= 30)
                {
                    Console.WriteLine(projectileSteps);

                    topLeftDiagonal();
                    projectileSteps++;
                }
            }
            else if (direction == "Patrol")
            {
                if (directionPatrol == "Right")
                {
                    moveLeftToRight();
                    if (startingPoint.getY() == premises.getTopRight().getY())
                    {
                        directionPatrol = "Left";
                    }
                }
                else if (directionPatrol == "Left")
                {
                    moveRightToLeft();
                    if (startingPoint.getY() == premises.getTopLeft().getY())
                    {
                        directionPatrol = "Right";
                    }
                }
            }
        }
        public void moveLeftToRight ()
        {
            if (startingPoint.getY() < premises.getTopRight().getY())
            {
                int y = startingPoint.getY();
                y++;
                startingPoint.setY(y);
            }
        }
        public void moveRightToLeft ()
        {
            if (startingPoint.getY() > premises.getTopLeft().getY())
            {
                int y = startingPoint.getY();
                y--;
                startingPoint.setY(y);
            }
        }
        public void topLeftDiagonal ()
        {
            if (startingPoint.getX() < premises.getBottomRight().getX() && startingPoint.getY() < premises.getBottomRight().getY())
            {
                int x = startingPoint.getX();
                int y = startingPoint.getY();
                x++;
                y++;
                startingPoint.setX(x);
                startingPoint.setY(y);
            }
        }
        public void topRightDiagonal ()
        {
            if (startingPoint.getX() < premises.getBottomLeft().getX() && startingPoint.getY() > premises.getBottomLeft().getY())
            {
                int x = startingPoint.getX();
                int y = startingPoint.getY();
                x++;
                y--;
                startingPoint.setX(x);
                startingPoint.setY(y);
            }
        }
        public void bottomRightDiagonal ()
        {
            if (startingPoint.getX() > premises.getTopLeft().getX() && startingPoint.getY() > premises.getTopLeft().getY())
            {
                int x = startingPoint.getX();
                int y = startingPoint.getY();
                x--;
                y--;
                startingPoint.setX(x);
                startingPoint.setY(y);
            }
        }
        public void bottomLeftDiagonal ()
        {
            if (startingPoint.getX() > premises.getTopRight().getX() && startingPoint.getY() < premises.getTopRight().getY())
            {
                int x = startingPoint.getX();
                int y = startingPoint.getY();
                x--;
                y++;
                startingPoint.setX(x);
                startingPoint.setY(y);
            }
        }

        public void draw ()
        {

            for (int i = 0 ; i < shape.GetLength(0) ; i++)
            {
                for (int j = 0 ; j < shape.GetLength(1) ; j++)
                {
                    Console.SetCursorPosition(startingPoint.getY() + j , startingPoint.getX() + i);
                    Console.Write(shape[i , j]);
                    /*     Console.Write(i);
                         Console.Write(j);*/

                }
            }
            // Console.Write(shape[0 , 0]);
        }
    }
}
