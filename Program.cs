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
			Params settings = new Params();
			Sounds sound = new Sounds(settings.GetResourceFolder());
			sound.Play();

			Sounds pointsound = new Sounds(settings.GetResourceFolder());
			Sounds losesound = new Sounds(settings.GetResourceFolder());

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

			Console.SetWindowSize(80, 26);

			Walls walls = new Walls(80, 25);
			walls.Draw();
			
			Point p = new Point(4, 5, '*');
			Snake snake = new Snake(p, 4, Direction.RIGHT);
			snake.Draw();

			FoodCreator foodCreator = new FoodCreator(80, 25, '$');
			Point food = foodCreator.CreateFood();
			food.Draw();

			while (true)
			{
				if (walls.IsHit(snake) || snake.IsHitTail())
				{
					break;
				}
				if (snake.Eat(food))
				{
					pointsound.Play("point");
					food = foodCreator.CreateFood();
					food.Draw();
				}
				else
				{
					snake.Move();
				}

				Thread.Sleep(100);
				if (Console.KeyAvailable)
				{
					ConsoleKeyInfo key = Console.ReadKey();
					snake.HandleKey(key.Key);
				}
			}
			Messages gameover = new Messages();
			gameover.WriteGameOver(name, snake.score);
			sound.Stop();
			pointsound.Play("lose");
			ConsoleKeyInfo _key = Console.ReadKey();
			if (_key.Key == ConsoleKey.Enter)
				Application.Restart();
		}

	}
}