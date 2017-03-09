using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Pyatnashki
{
    class Program
    {
        static public void Print(Game gmb)
        {
            for (int i = 0; i < gmb.Length; i++)
            {
                for (int j = 0; j < gmb.Length; j++)
                {
                    Console.Write(string.Format("{0}\t", gmb[i, j]));
                }
                Console.WriteLine();
            }
        }

        static void Main(string[] args)
        {
            try
            {
                //Game2 gmb2 = new Game2(3);

                //Console.WriteLine("Введите имя файла для чтения данных: ");
                //string filename = Console.ReadLine();
                //if (!File.Exists(filename)) throw new Exception("Нет такого файла");

                //Game gmb = Game.ReadCSV(filename);

                Game3 gmb = new Game3(3);

                Print(gmb);

                int n = 0;

                while (!gmb.IsEndGame())
                {
                    Console.Write("Какое значение двигаем? ");
                    int val = int.Parse(Console.ReadLine());

                    try
                    {
                        if (val < 0)
                        {
                            gmb.Reverse(val * -1);
                        }
                        else
                        {
                            gmb.Shift(val);
                            n++;
                        }

                    }
                    catch (Exception ex)  // возможные ошибки в ходе игры
                    {
                        Console.WriteLine(string.Format("Неправильный ход! {0}", ex.Message));
                    }
                    Print(gmb);
                }
                Console.WriteLine("Поздравляем! Игра завершена за {0} ходов!", n);
            }
            catch (Exception ex) //возможные ошибки при создании игры
            {
                Console.WriteLine(string.Format("Критическая ошибка! {0}", ex.Message));
            }
            Console.ReadKey();
        }
    }
}

