using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace SnakeGame
{
    class Messages
    {
		public void WriteGameOver(string name, int score)
		{
			Console.Clear();
			int xOffset = 25;
			int yOffset = 8;
			Console.ForegroundColor = ConsoleColor.Red;
			Console.SetCursorPosition(xOffset, yOffset++);
			WriteText("============================", xOffset, yOffset++);
			WriteText("И Г Р А    О К О Н Ч Е Н А", xOffset + 1, yOffset++);
			WriteText("Для перезапуска нажмите Enter", xOffset, yOffset++);
			yOffset++;
			Console.ForegroundColor = ConsoleColor.Yellow;
			WriteText("Пытался: Nikolas Laus", xOffset + 2, yOffset++);
			WriteText("Группа: TARpv19", xOffset + 2, yOffset++);
			Console.ForegroundColor = ConsoleColor.White;
			WriteText(name + ", спасибо за игру!", xOffset++, yOffset++);
			WriteText("Ваш конечный счёт: " + score, xOffset + 2, yOffset++);
			Console.ForegroundColor = ConsoleColor.Red;
			WriteText("============================", xOffset, yOffset++);
			using (var file = new StreamWriter("score.txt", true))
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
