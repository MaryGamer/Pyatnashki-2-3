using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pyatnashki
{
    class Game3 : Game2
    {
        int num;

        FileWorker fwr;

        public Game3(int size) : base(size)
        {
            fwr = new FileWorker();
            num = 0;
            //    fsw = new System.IO.StreamWriter(filename); //не должно быть  в этом классе
        }

        void SaveLog(int num, Point A, Point B)
        {
            // сформировать строку
            string log = string.Empty;
            log = string.Format("{0};{1};{2};{3};{4}", num, A.Row, A.Column, B.Row, B.Column);
            // записать
            fwr.WriteToLog(log);
        }

        public void Reverse(int back)
        {
            var log = fwr.ReadLogs(num - back + 1);

            for (int i = log.Count - 1; i >= 0; i--)
            {
                var tmp = log[i].Split(';');
                Point A = new Point(int.Parse(tmp[1]), int.Parse(tmp[2]));
                Point B = new Point(int.Parse(tmp[3]), int.Parse(tmp[4]));
                base.swap(ref base.field[A.Row, A.Column], ref base.field[B.Row, B.Column]);
            }

            num = num - back + 1;
        }

        public override void Shift(int value) 
        {
            num++;
            SaveLog(num, base.GetLocation(0), base.GetLocation(value));
            base.Shift(value);
        }
    }
}
