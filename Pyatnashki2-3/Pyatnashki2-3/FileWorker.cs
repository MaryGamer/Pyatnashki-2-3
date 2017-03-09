using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pyatnashki
{
    class FileWorker
    {
        string filename;
        System.IO.StreamWriter fsw;
        System.IO.StreamReader fsr;

        public FileWorker()
        {
            filename = Environment.CurrentDirectory + @"\logfile.txt";
            fsw = new System.IO.StreamWriter(filename);
        }

        ~FileWorker()
        {
            fsw.Close();
        }

        public void WriteToLog(string logstr)
        {
            fsw.WriteLine(logstr);
            fsw.Flush();
        }

        public List<string> ReadLogs(int startNum)
        {
            fsw.Close();

            List<string> rez = new List<string>();
            string line;
            fsr = new System.IO.StreamReader(filename);

            while ((line = fsr.ReadLine()) != null)
            {
                var tmp = line.Split(';');
                if (int.Parse(tmp[0]) >= startNum)
                {
                    rez.Add(line);
                }
            }
            fsr.Close();
            return rez;
        }

    }
}
