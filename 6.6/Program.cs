using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _6._6
{
    class Program
    {
        static void DrawField(int width, int height, int cellsize)
        {
            for (int y = 0; y <= height; y += cellsize)
            {
                for (int x = 0; x < width; x++)
                {
                    Console.SetCursorPosition(x, y);
                    Console.Write("█");
                }
            }

            for (int x = 0; x <= width; x += cellsize)
            {
                for (int y = 0; y <= height; y++)
                {
                    Console.SetCursorPosition(x, y);
                    Console.Write("█");
                }
            }

            for (int i = 1; i <= 9; i++)
            {
                int x = (i - 1) % 3 * 11 + 6;
                int y = (i - 1) / 3 * 11 + 1;
                Console.SetCursorPosition(x, y);
                Console.Write(i);
            }
        }

        static void DrawCross(int x, int y, int size)
        {
            for (int i = x; i <= x + size; i++)
            {
                for (int j = y; j <= y + size; j++)
                {
                    if (i - j == x - y || i + j == y + x + size)
                    {
                        Console.SetCursorPosition(i, j);
                        Console.Write("█");
                    }
                }
            }
        }

        static void DrawRectangle(int x, int y, int size)
        {
            for (int i = x; i <= x + size; i++)
            {
                for (int j = y; j <= y + size; j++)
                {
                    if (i == x || i == x + size || j == y || j == y + size)
                    {
                        Console.SetCursorPosition(i, j);
                        Console.Write("█");
                    }
                }
            }
        }

        static void Main(string[] args)
        {
            Console.SetWindowSize(90, 34);
            Console.SetBufferSize(90, 34);

            DrawField(33, 33, 11);

            int input;
            int win = 0;
            

            int c1, c2, c3, c4, c5, c6, c7, c8, c9;
            c1 = -1; c2 = -2; c3 = -3; c4 = -4; c5 = -5; c6 = -6; c7 = -7; c8 = -8; c9 = -9;

            

            for (int i = 1; i <= 9; i++)
            {
                Console.SetCursorPosition(35, 0 + i);
                Console.Write("                                 ");

                Console.SetCursorPosition(35, 0 + i);
                if (i % 2 == 0) Console.Write("Нолики ходят. Выберете номер клетки:");
                if (i % 2 != 0) Console.Write("Крестики ходят. Выберете номер клетки:");                              
                
                bool error = !int.TryParse(Console.ReadLine(), out input);

                int x = (input - 1) % 3 * 11 + 2;
                int y = (input - 1) / 3 * 11 + 2;

                if (input == 1 && c1 != -1) error = true;
                if (input == 2 && c2 != -2) error = true;
                if (input == 3 && c3 != -3) error = true;
                if (input == 4 && c4 != -4) error = true;
                if (input == 5 && c5 != -5) error = true;
                if (input == 6 && c6 != -6) error = true;
                if (input == 7 && c7 != -7) error = true;
                if (input == 8 && c8 != -8) error = true;
                if (input == 9 && c9 != -9) error = true;
                if (input < 1 || input > 9) error = true;

                if (error == true)
                {
                    Console.SetCursorPosition(35, 0 + i);                    
                    Console.Write("                                                     ");
                    Console.SetCursorPosition(35, 0 + i);
                    Console.Write("Ошибка ввода, попробуйте снова");
                    Console.ReadKey();
                    i--;
                    continue;
                }


                if (i % 2 == 0)
                {
                    DrawRectangle(x, y, 7);

                    if (input == 1) c1 = 1;
                    if (input == 2) c2 = 1;
                    if (input == 3) c3 = 1;
                    if (input == 4) c4 = 1;
                    if (input == 5) c5 = 1;
                    if (input == 6) c6 = 1;
                    if (input == 7) c7 = 1;
                    if (input == 8) c8 = 1;
                    if (input == 9) c9 = 1;

                }
                else
                {
                   DrawCross(x, y, 7);

                    if (input == 1) c1 = 2;
                    if (input == 2) c2 = 2;
                    if (input == 3) c3 = 2;
                    if (input == 4) c4 = 2;
                    if (input == 5) c5 = 2;
                    if (input == 6) c6 = 2;
                    if (input == 7) c7 = 2;
                    if (input == 8) c8 = 2;
                    if (input == 9) c9 = 2;
                }

                if (c1 == c2 && c2 == c3) win = c1;
                if (c4 == c5 && c5 == c6) win = c4;
                if (c7 == c8 && c8 == c9) win = c7;
                if (c1 == c4 && c4 == c7) win = c1;
                if (c2 == c5 && c5 == c8) win = c2;
                if (c3 == c6 && c6 == c9) win = c3;
                if (c1 == c5 && c5 == c9) win = c1;
                if (c3 == c5 && c5 == c7) win = c3;

                if (win == 2)
                {
                    Console.SetCursorPosition(50, 25);
                    Console.WriteLine("Крестики выиграли!");
                    Console.ReadLine();
                    break;
                }

                if (win == 1)
                {
                    Console.SetCursorPosition(50, 25);
                    Console.WriteLine("Нолики выиграли!");
                    Console.ReadLine();
                    break;
                }

                if (i == 9 && win == 0)
                {
                    Console.SetCursorPosition(50, 25);
                    Console.WriteLine("Ничья!");
                }
            }

           


            Console.ReadLine();
        }
    }
}
