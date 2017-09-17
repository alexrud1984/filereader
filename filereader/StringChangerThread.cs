using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Filereader
{
    class StringChangerThread
    {
        static int threadsIndexer = 0;
        private Thread stringChangeThread;
        private string toOperate;
        private string changedString;
        private int threadIndex;

        public Thread ExThread
        {
            get
            {
                return stringChangeThread;
            }
        }
        public string ChagedString
        {
            get
            {
                return changedString;
            }
        }
        public int Index
        {
            get
            {
                return threadIndex;
            }
        }

        public StringChangerThread(string stringToChange)
        {
            this.toOperate = stringToChange;
            threadIndex = threadsIndexer;
            threadsIndexer++;
            if (threadsIndexer==int.MaxValue)
            {
                threadsIndexer = 0;
            }
        }

        public void ThreadRun()
        {
            stringChangeThread = new Thread(() =>
                {
                    changedString = CangeString(toOperate, threadIndex);
                    this.stringChangeThread.Name = threadIndex.ToString();
                });
            stringChangeThread.Start();
        }

        private static string CangeString(string fileText, int threadNumber)
        {
            Console.WriteLine("Convertation in Thread #{0} started", threadNumber);
            char[] CharsArrayToChange = fileText.ToCharArray();
            for (int i = 0; i < CharsArrayToChange.Length; i++)
            {
                if (Char.IsLower(CharsArrayToChange[i]))
                {
                    CharsArrayToChange[i] = Char.ToUpper(CharsArrayToChange[i]);
                }
                else
                {
                    CharsArrayToChange[i] = Char.ToLower(CharsArrayToChange[i]);
                }
            }
            Console.WriteLine("Convertation in Thread #{0} finished", threadNumber);
            return new string(CharsArrayToChange);
        }
    }
}
