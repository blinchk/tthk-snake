using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading;
using System.Windows.Forms;
using System.Media;

namespace SnakeGame
{
	class Program
	{
		static void Main(string[] args)
		{
			string name;

			while (true)
			{
				Console.Write("Type your name: ");
				name = Console.ReadLine();
				if (name.Length < 3)
				{
					Console.Clear();
					Console.WriteLine("Name will be longer than 3 symbols.");
					continue;
				}
				else
				{
					Console.Clear();
					break;
				}
			}

			bool soundSwitch;

			while (true)
			{
				Console.Write("Do you want to turn on sounds? (Y/N): ");
				ConsoleKeyInfo answerkey = Console.ReadKey();
				if (answerkey.Key == ConsoleKey.Y)
				{
					Console.Clear();
					soundSwitch = true;
					break;
				}
				else if (answerkey.Key == ConsoleKey.N)
				{
					Console.Clear();
					soundSwitch = false;
					break;
				}
				else
				{
					Console.WriteLine("\nPress \'Y\' or \'N\' key.");
					continue;
				}
			}

			Score score = new Score(9);
			Level level = new Level(1);
			
			Params settings = new Params();
			Sounds sound = new Sounds(settings.GetResourceFolder());
			Sounds pointsound = new Sounds(settings.GetResourceFolder());
			Sounds losesound = new Sounds(settings.GetResourceFolder());

			if (soundSwitch == true)
			{
				sound.Play(level.level);
			}

			Console.SetWindowSize(80, 26);

			Walls walls = new Walls(80, 25);
			walls.Draw();
			
			Point p = new Point(4, 5, '*');
			Snake snake = new Snake(p, 4, Direction.RIGHT);
			Console.ForegroundColor = ConsoleColor.Red;
			snake.Draw();
			Console.ForegroundColor = ConsoleColor.White;

			FoodCreator foodCreator = new FoodCreator(80, 25, '$');
			Point food = foodCreator.CreateFood();
			Console.ForegroundColor = ConsoleColor.Yellow;
			food.Draw();
			Console.ForegroundColor = ConsoleColor.White;

			while (true)
			{
				if (walls.IsHit(snake) || snake.IsHitTail())
				{
					break;
				}
				if (snake.Eat(food, score, level, sound))
				{
					if (soundSwitch == true)
					{
						pointsound.Play("point");
					}
					food = foodCreator.CreateFood();
					Console.ForegroundColor = ConsoleColor.Yellow;
					food.Draw();
					Console.ForegroundColor = ConsoleColor.White;
				}
				else
				{
					Console.ForegroundColor = ConsoleColor.Red;
					snake.Move();
					Console.ForegroundColor = ConsoleColor.Yellow;
				}

				if (level.level == 1)
					Thread.Sleep(100);
				else if (level.level == 2)
					Thread.Sleep(75);
				else if (level.level == 3)
					Thread.Sleep(50);
				else
					Thread.Sleep(40);

				if (Console.KeyAvailable)
				{
					ConsoleKeyInfo key = Console.ReadKey();
					snake.HandleKey(key.Key);
				}
			}
			Messages gameover = new Messages();
			gameover.WriteGameOver(name, score.score);
			if (soundSwitch == true)
			{
				sound.Stop(level.level);
				pointsound.Play("lose");
			}
			ConsoleKeyInfo _key = Console.ReadKey();
			if (_key.Key == ConsoleKey.Enter)
				Application.Restart();
		}

	}
}