using System;

namespace chess
{
    class Program
    {
        const char one = 'x';
        const char spaces = ' ';
        const char zero = 'o';
        const int size = 4;
        public static char[,] mass = new char[size,size];

        static void Main(string[] args)
        {
            space();
            choice_game();
        }
        static void choice_game()
        {
            bool p=true;
            while (p)
            {
                Console.Write("За кого играете (1 крестики , 2 нолики): ");
                int.TryParse(Console.ReadLine(), out var qw);
                if (qw == 1) { p = false;massiv(); input_x(); }
                else if (qw == 2) { p = false; massiv(); input_y(); }
                Console.WriteLine("Такого числа нет в списке!\n");
            }
        }
        static void input_x()
        {
            Console.WriteLine("Введите координаты x: ");
            Console.Write("Строка: ");
            int.TryParse(Console.ReadLine(), out var x1);
            Console.Write("Столбец: ");
            int.TryParse(Console.ReadLine(), out var x2);
            choos(x1, one, x2);
            input_y();
        }
        static void input_y()
        {
            Console.WriteLine("Введите координаты o: ");
            Console.Write("Строка: ");
            int.TryParse(Console.ReadLine(), out var y1);
            Console.Write("Cтолбец: ");
            int.TryParse(Console.ReadLine(), out var y2);
            choos(y1, zero, y2);
            input_x();
        }

        static void space()
        {
            for (int i = 0; i < mass.GetLength(0); i++)
            {
                for (int j = 0; j < mass.GetLength(1); j++)
                {
                    mass[i, j] = spaces;
                }
            }
        }

        static void choos(int x1,char c,int x2)
        {
            var move = c;
            if (x1 > 3 || x2 > 3 || x1 <= 0 || x2 <= 0)
            {
                if (c == zero) input_y();
                else if (c == one) input_x();
            }
            if (mass[x1,x2] == spaces)
            {
                mass[x1, x2] = c;
            }
            else if (mass[x1, x2] == zero)
            {
                Console.WriteLine("Вы накрываете другого игрока перевведите число!");
                massiv();
                input_x();
            }
            else if (mass[x1, x2] == one)
            {
                Console.WriteLine("Вы накрываете другого игрока перевведите число!");
                massiv();
                input_y();
            }
            check(move);
            massiv();
        }

        static void check(char move)
        {
            if (mass[1, 1] == move && mass[1, 2] == move && mass[1, 3] == move ||
                mass[2, 1] == move && mass[2, 2] == move && mass[2, 3] == move ||
                mass[3, 1] == move && mass[3, 2] == move && mass[3, 3] == move ||

                mass[1, 1] == move && mass[2, 1] == move && mass[3, 1] == move ||
                mass[1, 2] == move && mass[2, 2] == move && mass[3, 2] == move ||
                mass[1, 3] == move && mass[2, 3] == move && mass[3, 3] == move ||

                mass[1, 1] == move && mass[2, 2] == move && mass[3, 3] == move ||
                mass[3, 3] == move && mass[2, 2] == move && mass[1, 3] == move) end(move); 
            Console.Clear();
        }
        static void end(int win)
        {
            Console.Clear();
            if (win == zero) Console.WriteLine("Победа ноликов!"); else if (win==one) Console.WriteLine("Победа крестиков!");
            restart();
        }

        static void restart()
        {
            Console.WriteLine("Повторить игру?(Да,Нет): ");
            var q = Console.ReadLine();

            if (q == "Да" || q == "да")
            {
                space();
                choice_game();
            }
            else if (q == "Нет" || q == "нет") Environment.Exit(0);
            else restart();
        }

        static void massiv()
        {
            for (int i = 1; i < mass.GetLength(0); i++)
            {
                for (int j = 1; j < mass.GetLength(1); j++)
                {
                    Console.Write("["+mass[i, j] +"]");
                }
                Console.WriteLine();
            }
        }
    }
}
