using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakeGame
{
    class Level
    {
        public int level;

        public Level(int x)
        {
            level = x;
            Console.SetCursorPosition(12, 25);
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("Level: " + level);
            Console.ForegroundColor = ConsoleColor.White;
        }

        public Level AddLevel(Level level)
        {
            this.level++;
            Console.SetCursorPosition(19, 25);
            if (this.level == 2)
            {
                Console.ForegroundColor = ConsoleColor.Blue;
            }
            else if (this.level == 3)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Cyan;
            }
            Console.Write(this.level);
            Console.ForegroundColor = ConsoleColor.White;
            return level;
        }
    }
}
