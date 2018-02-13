using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Array_Training
{
	class Program
	{
		public const int tabsize = 7;
		static void Main(string[] args)
		{
			int width = widtha();
			int height = heighta();
			int[,] a = GetNumbers(width, height);
			DisplayNumbers(a, width, height);
			DisplayColoredNumbers(a, width, height);
		}

		static int[,] GetNumbers(int width, int height)
		{
			int[,] numbers = new int[width, height];
			Random number = new Random();
			for (int i = 0; i <= width - 1; i++)
			{
				for (int j = 0; j <= height - 1; j++)
				{
					numbers[i, j] = number.Next(1, 20);
				}
			}
			return numbers;
		}

		static int heighta()
		{
			Console.WriteLine("Enter height of array");
			string height = Console.ReadLine();
			Int32.TryParse(height, out int he);
			return he;
		}
		static int widtha()
		{
			Console.WriteLine("Enter width of array");
			string width = Console.ReadLine();
			Int32.TryParse(width, out int wi);
			return wi;
		}

		static int divideby()
		{
			Console.WriteLine("Enter the number to divide groups");
			string div = Console.ReadLine();
			Int32.TryParse(div, out int divi);
			return divi;
		}

		static void DisplayNumbers(int[,] a, int width, int height)
		{
			int windowidth = ((Console.WindowWidth - 1) / 2) - ((width * tabsize) / 2);
			int windowheight = ((Console.WindowHeight - 1) / 2) - (height / 2);
			Console.Clear();


			for (int i = 0; i <= height - 1; i++)
			{
				Console.SetCursorPosition(windowidth, windowheight + i);

				for (int j = 0; j <= width - 1; j++)
				{
					//Debug.WriteLine($"[{j},{i}]={Console.CursorLeft},{Console.CursorTop}");
					Console.Write(a[j, i] + "\t");
				}
				Console.WriteLine();
			}
		}
		static void DisplayColoredNumbers(int[,] a, int width, int height)
		{
			Console.SetCursorPosition(0, Console.WindowHeight-1);
			string[] colors = ConsoleColor.GetNames(typeof(ConsoleColor));
			int div = divideby();
			int stat = 0;
			int col = 0;
			for (int k = 0; k <= 20; k++)
			{
				stat++;
				if(stat == div)
				{
					stat = 0;
					col++;
				}
				else if(col == colors.Length-1)
				{
					col = 0;
				}
				if(col == 0)
				{
					Console.BackgroundColor = ConsoleColor.White;
				}
				else
				{
					Console.BackgroundColor = ConsoleColor.Black;
				}
				for (int i = 0; i <= height - 1; i++)
				{
					for (int j = 0; j <= width - 1; j++)
					{
						if(a[j,i]==k)
						{
							Console.ForegroundColor = (ConsoleColor)Enum.Parse(typeof(ConsoleColor), colors[col]);
							Console.Write(k + ", ");
						}
					}
				}
			}
			Console.ReadLine();
		}
	}
}
