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
			WriteGameOver(name, snake.score);
			sound.Stop();
			pointsound.Play("lose");
			ConsoleKeyInfo _key = Console.ReadKey();
			if (_key.Key == ConsoleKey.Enter)
				Application.Restart();
		}


		static void WriteGameOver(string name, int score)
		{
			int xOffset = 25;
			int yOffset = 8;
			Console.ForegroundColor = ConsoleColor.Red;
			Console.SetCursorPosition(xOffset, yOffset++);
			WriteText("============================", xOffset, yOffset++);
			WriteText("И Г Р А    О К О Н Ч Е Н А", xOffset + 1, yOffset++);
			WriteText("Для перезапуска нажмите Enter", xOffset, yOffset++);
			yOffset++;
			Console.ForegroundColor = ConsoleColor.Yellow;
			WriteText("Пытался: Nikolas Laus", xOffset+2, yOffset++);
			WriteText("Группа: TARpv19", xOffset + 2, yOffset++);
			Console.ForegroundColor = ConsoleColor.White;
			WriteText(name + ", спасибо за игру!", xOffset++, yOffset++);
			WriteText("Ваш конечный счёт: " + score, xOffset + 2, yOffset++);
			Console.ForegroundColor = ConsoleColor.Red;
			WriteText("============================", xOffset, yOffset++);
			Console.WriteLine(score);
			using( var file = new StreamWriter("score.txt", true) )
			{
				file.WriteLine("Name: " + name + " | Score: " + score);
				file.Close();
			}
		}

		static void WriteText(String text, int xOffset, int yOffset)
		{
			Console.SetCursorPosition(xOffset, yOffset);
			Console.WriteLine(text);
		}

	}
}