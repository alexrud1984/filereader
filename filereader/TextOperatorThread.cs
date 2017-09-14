using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Filereader
{
    class TextOperatorThread
    {
        static int indexer = 0;
        private Thread exThread;
        private string toOperate;
        private string result;
        private int index;

        public Thread ExThread
        {
            get
            {
                return exThread;
            }
        }
        public string Result
        {
            get
            {
                return result;
            }
        }
        public int Index
        {
            get
            {
                return index;
            }
        }

        public TextOperatorThread(string toOperate)
        {
            this.toOperate = toOperate;
            index = indexer;
            indexer++;
            if (indexer==int.MaxValue)
            {
                indexer = 0;
            }
        }

        public void ThreadRun()
        {
            exThread = new Thread(() =>
                {
                    result = ConvertTextFrame(toOperate, index);
                    this.exThread.Name = index.ToString();
                });
            exThread.Start();
        }

        private static string ConvertTextFrame(string fileText, int threadNumber)
        {
            Console.WriteLine("Convertation in Thread #{0} started", threadNumber);
            char[] toConvert = fileText.ToCharArray();
            for (int i = 0; i < toConvert.Length; i++)
            {
                if (Char.IsLower(toConvert[i]))
                {
                    toConvert[i] = Char.ToUpper(toConvert[i]);
                }
                else
                {
                    toConvert[i] = Char.ToLower(toConvert[i]);
                }
            }
            Console.WriteLine("Convertation in Thread #{0} finished", threadNumber);
            return new string(toConvert);
        }
    }
}
