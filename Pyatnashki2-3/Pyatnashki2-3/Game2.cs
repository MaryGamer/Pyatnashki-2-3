using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pyatnaski23
{
    class Game2 : Game
    {
        public Game2(params int[] val) : base(val)
        {
        }

        public Game2(int size)
        {
            int[] mas = new int[size * size];

            for (int i = 1; i < mas.Length; i++)
            {
                Random rnd = new Random(DateTime.Now.Millisecond);

                while (true)
                {
                    int pos = rnd.Next(0, mas.Length);
                    if (mas[pos] == 0)
                    {
                        mas[pos] = i;
                        break;
                    }
                }
            }
            // вызов конструктора базового класса и передача ему полученный случайный mas  
        }

        public bool EndGame()
        {
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    if (field[i, j] != (i * size + j + 1) && (i != size - 1 || j != size - 1))
                        return false;
                    if (field[i, j] != 0 && i == size - 1 && j == size - 1)
                        return false;
                }
            }
            return true;
        }


    }
}
