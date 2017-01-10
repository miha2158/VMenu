using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMenu
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.CursorVisible = false;

            string[,] items = new string[,] { { "Один", "Два", "Три" }, { "Четыре", "Пять", "Шесть" }, { "Семь", "Восемь", "Девять" } };

            int currentIndexX = 0, previousIndexX = 0;
            int currentIndexY = 0, previousIndexY = 0;
            int positionX = 5, positionY = 2;
            bool itemSelected = false;

            for (int i = 0; i < 3; i++)
                for (int j = 0; j < 3; j++)
                {
                    Console.CursorTop = positionY + i;
                    Console.CursorLeft = positionX + j * 10;
                    Console.ForegroundColor = ConsoleColor.Gray; Console.BackgroundColor = ConsoleColor.Black;
                    Console.Write(items[i , j]);
                }

            do
            {
                Console.CursorLeft = positionX + previousIndexX * 10;
                Console.CursorTop = positionY + previousIndexY;
                Console.ForegroundColor = ConsoleColor.Gray; Console.BackgroundColor = ConsoleColor.Black;
                Console.Write(items[previousIndexY , previousIndexX]);


                Console.CursorLeft = positionX + currentIndexX * 10;
                Console.CursorTop = positionY + currentIndexY;
                Console.ForegroundColor = ConsoleColor.Black; Console.BackgroundColor = ConsoleColor.Gray;
                Console.Write(items[currentIndexY , currentIndexX]);

                ConsoleKeyInfo keyInfo = Console.ReadKey(true);

                previousIndexX = currentIndexX;
                previousIndexY = currentIndexY;
                switch (keyInfo.Key)
                {
                    case ConsoleKey.RightArrow:
                        currentIndexX++;
                        break;

                    case ConsoleKey.LeftArrow:
                        currentIndexX--;
                        break;

                    case ConsoleKey.UpArrow:
                        currentIndexY--;
                        break;

                    case ConsoleKey.DownArrow:
                        currentIndexY++;
                        break;

                    case ConsoleKey.Enter:
                        itemSelected = true;
                        break;
                }

                if (currentIndexX == 3)
                {
                    currentIndexX = 0;
                    currentIndexY++;
                }
                else if (currentIndexX < 0)
                {
                    currentIndexX = 2;
                    currentIndexY--;
                }

                if (currentIndexY == 3)
                    currentIndexY = 0;
                else if (currentIndexY < 0)
                    currentIndexY = 2;

            }
            while (!itemSelected);

            Console.CursorLeft = positionX;
            Console.CursorTop = 15;

            Console.WriteLine("Выбран пункт: {0}.", currentIndexY * 3 + currentIndexX + 1);
            Console.ReadKey(true);
        }
    }
}
