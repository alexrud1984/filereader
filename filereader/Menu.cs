using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Filereader
{
    class Menu
    {
        IStringChanger stringChanger;
        private string fileContent;
        private string changedFileContent;
        private string fileName = "D:\\test\\test.txt";
        
        public Menu()
        {
            stringChanger = new StringChanger();
            RunMenu();
        }

        private void RunMenu()
        {
            Console.WriteLine("To read file press 1 \nto change file press 2 \nTo write file press 3 \nTo exit press 4");
            while (true)
            {

                switch (Console.ReadKey().KeyChar)
                {
                    case '1':
                        ReadFile();
                        Console.WriteLine("\nFile was read");
                        break;
                    case '2':
                        changedFileContent=stringChanger.ChangeString(fileContent);
                        Console.WriteLine("\nFile is changed");
                        break;
                    case '3':
                        WriteFile();
                        Console.WriteLine("\nFile is saved");
                        break;
                    case '4':
                        return;
                    default:
                        Console.WriteLine("\nTo open file press 1 \nto change file press 2 \nTo write file press 3 \nTo exit press 4");
                        break;
                }
            }
        }
        void ReadFile()
        {
            fileContent = String.Empty;
            try
            {
                fileContent = File.ReadAllText(fileName);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception occurred: {0}", ex.Message);
                Console.ReadKey();
            }
        }

        void WriteFile()
        {
            try
            {
                File.WriteAllText(fileName.Substring(0, fileName.Length - 4) + "Changed.txt", changedFileContent);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception occurred: {0}", ex.Message);
                Console.ReadKey();
            }
        }
    }
}
