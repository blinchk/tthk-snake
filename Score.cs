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
        }

        public Score AddPoint(Score score)
        {
            this.score++;
            return score;
        }
    }
}
