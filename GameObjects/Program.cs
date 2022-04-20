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

        static void Main ()
        {
            char[,] triangle = new char[5 , 3] {
                { '@' , ' ' , ' ' } ,
                { '@' , '@' , ' ' } ,
                { '@' , '@' , '@' } ,
                { '@' , '@' , ' ' } ,
                { '@' , ' ' , ' ' } };
            Boundary b = new Boundary();
            GameObject g1 = new GameObject(triangle , new Point(0 , 0) , b , "Patrol");
            while (true)
            {
                Thread.Sleep(10);
                Console.Clear();
                g1.move();
                g1.draw();
            }
        }
    }
}
