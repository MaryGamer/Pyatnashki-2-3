using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pyatnashki
{
    class Game2 : Game
    {
        public Game2(int size)
        {
            int[,] mas = new int[size, size];

            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    mas[i, j] = i * size + j;
                }
            }

            for (int i = 0; i < 10; i++)
            {
                // составить массив соседей нуля
                List<Point> neighbours = new List<Point>();

                //Point Loc0 = GetLocation(0);
                //if (Loc0.row - 1 >= 0) neighbours.Add(new Point(Loc0.col, Loc0.row - 1));                 
                //if (Loc0.row + 1 <= size - 1) neighbours.Add(new Point(Loc0.col, Loc0.row + 1));
                //if (Loc0.col - 1 >= 0) neighbours.Add(new Point(Loc0.col - 1, Loc0.row));
                //if (Loc0.col + 1 <= size - 1) neighbours.Add(new Point(Loc0.col + 1, Loc0.row));

                //// выбрать из него случайное число

                //Random rnd = new Random(DateTime.Now.Millisecond);
                //Point LocS = neighbours[rnd.Next(neighbours.Count - 1)];

                //// поменять местами с нулем
                //swap(ref mas[LocS.row, LocS.col], ref mas[Loc0.row, Loc0.col]);
            }

            List<int> lst = new List<int>();
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    lst.Add(mas[i, j]);
                }
            }

            this.Inicialize(lst.ToArray());
        }

        public bool IsEndGame()
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
