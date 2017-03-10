using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pyatnashki
{
    class Game2 : Game
    {
        public Game2(params int[] val)
        {
            const int rndIter = 11;

            base.CheckIt(val);

            int size = (int)Math.Sqrt(val.Length);
            int[,] mas = new int[size, size];

            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    mas[i, j] = val[i * size + j];
                }
            }

            for (int k = 0; k < rndIter; k++)
            {
                List<Point> neigbours = new List<Point>();  
                Point ZeroPos = new Point(-1, -1);
                Point SwapPoz = new Point(-1, -1);

                for (int i = 0; i < size; i++)
                {
                    for (int j = 0; j < size; j++)
                    {
                        if (mas[i, j] == 0)
                        {
                            ZeroPos = new Point(j, i);
                            if (i - 1 >= 0) neigbours.Add(new Point(j, i - 1));
                            if (i + 1 <= size - 1) neigbours.Add(new Point(j, i + 1));
                            if (j - 1 >= 0) neigbours.Add(new Point(j - 1, i));
                            if (j + 1 <= size - 1) neigbours.Add(new Point(j + 1, i));
                        }
                    }
                }

                if (neigbours.Count > 0)
                {
                    Random rnd = new Random(DateTime.Now.Millisecond); 
                    SwapPoz = neigbours[rnd.Next(neigbours.Count - 1)];
                    swap(ref mas[ZeroPos.Row, ZeroPos.Column], ref mas[SwapPoz.Row, SwapPoz.Column]);
                }
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
                    if ((field[i, j] != (i * size + j + 1) && (i != size - 1 || j != size - 1)) ||
                        (field[i, j] != 0 && i == size - 1 && j == size - 1)) return false;
                }
            }
            return true;
        }

    }
}
