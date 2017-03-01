using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pyatnaski23
{
    class Game3 : Game2
    {
        string filename = @"D:\logFile.txt";
        int num;
        System.IO.StreamWriter fsw;

        public Game3(params int[] val) : base(val)
        {
            num = 0;
            fsw = new System.IO.StreamWriter(filename);
        }

        public ~Game3() //??
        {
            fsw.Close();
        }

        public override void Shift(int value) //??
        {
            num++;
            fsw.WriteLine(string.Format("Ход: {0}, передвинули число {1}", num, value));
            this.Shift(value);
        }

    }
}
