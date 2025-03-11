namespace FindHolger
{
	class Program
	{
		private static void Main()
		{
			FindHolger();
		}
		private static void FindHolger()
		{
			{
				Random rnd = new();
				List<char> alphabet = [];
				alphabet.AddRange(Enumerable.Range((int)'a', 26).Select(x => Convert.ToChar(x)));
				alphabet.AddRange(Enumerable.Range((int)'A', 26).Select(x => Convert.ToChar(x)));
				int size = 30;
				int holgerY = rnd.Next(1, size + 1);
				int holgerX = rnd.Next(1, size + 1);

				Console.Write("    ");

				for (int i = 1; i < size + 1; i++)
				{
					if (i < 10) Console.Write(i + "  ");
					else Console.Write(i + " ");
				}

				Console.WriteLine("\n\n");

				for (int i = 1; i < size + 1; i++)
				{
					Console.ResetColor();

					if (i < 10) Console.Write(i + "   ");
					else Console.Write(i + "  ");

					for (int j = 1; j < size + 1; j++)
					{
						Console.ForegroundColor = (ConsoleColor)rnd.Next(1, 16);

						if (i == holgerY && j == holgerX) Console.Write("@  ");
						else
						{
							char nextLetter = alphabet[rnd.Next(0, alphabet.Count)];
							Console.Write(nextLetter + "  ");
						}
					}
					Console.WriteLine();
				}
				Console.ResetColor();
				Console.WriteLine("\nFind Holger!");

				bool foundHolger = false;
				do
				{
					string inputY;
					int guessY;
					bool validInput;
					do
					{
						Console.Write("Indtast Holgers y-koordinat (række): ");
						inputY = Console.ReadLine() ?? "";

						validInput = int.TryParse(inputY, out guessY)
							&& guessY > 0
							&& guessY < size + 1;

					} while (!validInput);

					string inputX;
					int guessX;
					do
					{
						Console.Write("Indtast Holgers x-koordinat (række): ");
						inputX = Console.ReadLine() ?? "";

						validInput = int.TryParse(inputX, out guessX)
							&& guessX > 0
							&& guessX < size + 1;

					} while (!validInput);

					if (guessX == holgerX && guessY == holgerY)
					{
						Console.WriteLine("\nDu har fundet Holger!");
						foundHolger = true;
					}
					else
					{
						Console.WriteLine("\nDu har ikke fundet Holger :(\n");
					}
				} while (!foundHolger);
			}
		}
	}
}
