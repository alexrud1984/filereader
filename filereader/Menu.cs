using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Filereader
{
    class Menu
    {
        IFileOperator fileOperator;
        public Menu(string fileName)
        {
            fileOperator = new FileOperator(fileName);
            exeMenu();
        }

        private void exeMenu()
        {
            Console.WriteLine("To read file press 1 \nto change file press 2 \nTo wright file press 3 \nTo exit press 4");
            while (true)
            {

                switch (Console.ReadKey().KeyChar)
                {
                    case '1':
                        fileOperator.ReadFile();
                        Console.WriteLine("\nFile was readed");
                        break;
                    case '2':
                        fileOperator.ChangeFile();
                        Console.WriteLine("\nFile changed");
                        break;
                    case '3':
                        fileOperator.WriteFile();
                        Console.WriteLine("\nFile saved");
                        break;
                    case '4':
                        return;
                    default:
                        Console.WriteLine("\nTo open file press 1 \nto change file press 2 \nTo wright file press 3 \nTo exit press 4");
                        break;
                }
            }
        }
    }
}
