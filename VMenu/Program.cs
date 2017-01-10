using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VMenu
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.CursorVisible = false;

            string[] items = {"Один", "Два", "Три"};

            int[] lengths = new int[items.Length];
            for(int i = 0; i < items.Length; i++)
                switch (i)
                {
                    case 0:
                        lengths[i] = 0;
                        break;

                    default:
                        lengths[i] = lengths[i - 1] + items[i - 1].Length + 1;
                        break;

                }

            int currentIndex = 0, previousIndex = 0;
            int positionX = 5, positionY = 2;
            bool itemSelected = false;
                       
            for (int i = 0; i < items.Length; i++)
            {
                Console.CursorLeft = positionX + lengths[i];
                Console.CursorTop = positionY;
                Console.ForegroundColor = ConsoleColor.Gray; Console.BackgroundColor = ConsoleColor.Black;
                Console.Write(items[i]);
            }

            do
            {
                Console.CursorLeft = positionX + lengths[previousIndex];
                Console.CursorTop = positionY;
                Console.ForegroundColor = ConsoleColor.Gray; Console.BackgroundColor = ConsoleColor.Black;
                Console.Write(items[previousIndex]);
                
                Console.CursorLeft = positionX + lengths[currentIndex];
                Console.CursorTop = positionY;
                Console.ForegroundColor = ConsoleColor.Black; Console.BackgroundColor = ConsoleColor.Gray;
                Console.Write(items[currentIndex]);           
                
                ConsoleKeyInfo keyInfo = Console.ReadKey(true);

                previousIndex = currentIndex;
                switch (keyInfo.Key)
                {
                    case ConsoleKey.RightArrow:
                        currentIndex++;
                        break;
                    case ConsoleKey.LeftArrow:
                        currentIndex--;
                        break;
                    case ConsoleKey.Enter:
                        itemSelected = true;
                        break;
                }

                if (currentIndex == items.Length)
                    currentIndex = items.Length - 1;
                else if (currentIndex < 0)
                    currentIndex = 0;
            }
            while (!itemSelected);

            Console.CursorLeft = positionX;
            Console.CursorTop = 10;

            Console.WriteLine("Выбран пункт: {0}.", currentIndex + 1);
            Console.ReadLine();
        }
    }
}
