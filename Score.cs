using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakeGame
{
    class Score
    {
        public int score;
        
        public Score(int x)
        {
            score = x;
            Console.SetCursorPosition(0, 25);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("Score: " + score);
            Console.ForegroundColor = ConsoleColor.White;
        }

        public ConsoleColor RandomColor()
        { 
            Array values = Enum.GetValues(typeof(ConsoleColor));
            Random random = new Random();
            ConsoleColor randomColor = (ConsoleColor)values.GetValue(random.Next(1, values.Length));
            return randomColor;
        }

        public Score AddPoint(Score score, Level level, Sounds sound, bool soundSwitch)
        {
            this.score++;
            if (this.score == 10 || this.score == 20 || this.score == 30 || this.score == 40)
            {
                if (soundSwitch == true)
                {
                    sound.Stop(level.level);
                    level.AddLevel(level);
                    sound.Play(level.level);
                }
                else
                    level.AddLevel(level);
            }
            Console.SetCursorPosition(7, 25);
            ConsoleColor color = RandomColor();
            Console.ForegroundColor = color;
            Console.Write(this.score);
            Console.ForegroundColor = ConsoleColor.White;
            return score;
        }
    }
}
