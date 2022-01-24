using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleMenu
{
    class Program
    {

        static void Main(string[] args)
        {
            Menu m = new Menu();
            m.shouldRun = true;
            m.Run();

            Console.WriteLine("End of program reached");
            //Console.ReadLine();
        }

    }

}


