using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakeGame
{
    class Program
    {
        static void Main(string[] args)
        {
            int x1 = 1;
            int y1 = 1;
            char sym1 = '*';

            Console.SetCursorPosition(x1, y1);
            Console.Write(sym1);

            int x2 = 4;
            int y2 = 5;
            char sym2 = '#';

            Console.SetCursorPosition(x2, y2);
            Console.Write(sym2);

            Console.ReadLine();
        }
    }
}
