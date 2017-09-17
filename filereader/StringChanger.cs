using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Threading;

namespace Filereader
{
    public class StringChanger:IStringChanger
    {
        private string[] resultSubstringsArray;

        string IStringChanger.ChangeString(string stringToChange, int threadsNumber)
        {
            try
            {
                List<string> stringsListToChange = SplitStringToList(stringToChange, threadsNumber);
                resultSubstringsArray = new string[threadsNumber];
                List<StringChangerThread> threadsList = new List<StringChangerThread>();
                foreach (var stringFromList in stringsListToChange)
                {
                    StringChangerThread thread = new StringChangerThread(stringFromList);
                    threadsList.Add(thread);
                }
                foreach (var thread in threadsList)
                {
                    thread.ThreadRun();
                }
                foreach (var thread in threadsList)
                {
                    thread.ExThread.Join();
                }
                foreach (var thread in threadsList)
                {
                    resultSubstringsArray[thread.Index % threadsNumber] = thread.ChagedString;
                }
                return String.Concat(resultSubstringsArray);
            }
            catch (Exception)
            {
                return String.Empty;
            }
        }

        private List<string> SplitStringToList(string stringToSplit, int substringsNumber)
        {
            string _stringToSplit = (string)stringToSplit.Clone();
            List<string> substringsList = new List<string>();
            int substringLength = _stringToSplit.Length / substringsNumber;
            for (int i = 0; i < substringsNumber - 1; i++)
            {
                substringsList.Add(_stringToSplit.Substring(0, substringLength));
                _stringToSplit = _stringToSplit.Remove(0, substringLength);
            }
            substringsList.Add(_stringToSplit);
            return substringsList;
        }
    }
}

