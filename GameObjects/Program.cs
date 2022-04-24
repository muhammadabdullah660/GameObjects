using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Threading;
using GameObjects.BL;
namespace GameObjects
{
    class Program
    {
        //static List<GameObject> st = new List<GameObject>();

        static void Main ()
        {
            char[,] shape = new char[5 , 5] {
                { '!' , ' ' , ' ','|','>' } ,
                { '!' , '@' , ' ','|','>' } ,
                { '!' , '@' , '>','|','>' } ,
                { '!' , '@' , ' ','|','>' } ,
                { '!' , ' ' , ' ','|','>' } };
            Boundary premises = new Boundary();
            GameObject g1 = new GameObject(shape , new Point(16 , 0) , premises , "Patrol");
            // GameObject g2 = new GameObject(shape , new Point(0 , 0) , premises , "Diagonal");
            while (true)
            {
                Thread.Sleep(100);
                Console.Clear();
                g1.move();
                g1.draw();
                // g2.move();
                //g2.draw();
            }
        }
    }
}
