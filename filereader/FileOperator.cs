using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Threading;

namespace Filereader
{
    public class FileOperator:IFileOperator
    {
        private string fileBody;
        private string[] resultFrames;
        public string FileName { get; set; }

        public FileOperator (string fileName)
        {
            FileName = fileName;
        }
       
        void IFileOperator.ChangeFile()
        {
            try
            {
                fileBody = ConvertInThread(fileBody);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception occurred: {0}", ex.Message);
                Console.ReadKey();
            }
        }

        void IFileOperator.ReadFile()
        {
            fileBody = String.Empty;
            try
            {
                fileBody = File.ReadAllText(FileName);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception occurred: {0}", ex.Message);
                Console.ReadKey();
            }
        }

        void IFileOperator.WriteFile()
        {
            try
            {
                File.WriteAllText(FileName.Substring(0,FileName.Length-4) + "Changed.txt", fileBody);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception occurred: {0}", ex.Message);
                Console.ReadKey();
            }
        }

        private string ConvertInThread(string fileText, int threadsNumber = 3)
        {
            List<string> stringListToConvert = SplitStringToList(fileText, threadsNumber);
            resultFrames = new string[threadsNumber]; 
            List<TextOperatorThread> threadsList = new List<TextOperatorThread>();
            foreach (var item in stringListToConvert)
            {
                TextOperatorThread thread = new TextOperatorThread(item);
                threadsList.Add(thread);
            }
            foreach (var item in threadsList)
            {
                item.ThreadRun();
            }
            foreach (var item in threadsList)
            {
                item.ExThread.Join();
            }
            foreach (var item in threadsList)
            {
                resultFrames[item.Index%threadsNumber] = item.Result;
            }
            return String.Concat(resultFrames);
        }

        private List<string> SplitStringToList(string toSplit, int framesNumber)
        {
            List<string> stringsList = new List<string>();
            int frameLength = toSplit.Length / framesNumber;
            for (int i = 0; i < framesNumber - 1; i++)
            {
                stringsList.Add(toSplit.Substring(0, frameLength));
                toSplit = toSplit.Remove(0, frameLength);
            }
            stringsList.Add(toSplit);
            return stringsList;
        }
    }
}

