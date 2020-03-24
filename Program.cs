using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace SnakeGame
{
	class Program
	{
		static void Main(string[] args)
		{
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
			WriteGameOver(snake.score);
			ConsoleKeyInfo _key = Console.ReadKey();
			if (_key.Key == ConsoleKey.Enter)
				Application.Restart();
		}


		static void WriteGameOver(int score)
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
			WriteText("Ваш конечный счёт: " + score, xOffset + 2, yOffset++);
			Console.ForegroundColor = ConsoleColor.Red;
			WriteText("============================", xOffset, yOffset++);
		}

		static void WriteText(String text, int xOffset, int yOffset)
		{
			Console.SetCursorPosition(xOffset, yOffset);
			Console.WriteLine(text);
		}

	}
}