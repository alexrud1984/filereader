using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Filereader
{
    public interface IStringChanger
    {
        string ChangeString(string stringToChange, int threadsNumber=3);
    }
}
