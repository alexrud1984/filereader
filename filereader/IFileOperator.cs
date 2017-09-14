using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Filereader
{
    public delegate void FileOpenedEventHandler();
    public delegate void FlleChangedEventHandler();
    public delegate void FileSavedEventHandler();
    public interface IFileOperator
    {
        string FileName { get; set; }
        void ReadFile();
        void WriteFile();
        void ChangeFile();
    }
}
