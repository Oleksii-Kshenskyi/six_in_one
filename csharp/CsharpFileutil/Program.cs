using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsharpFileutil
{
    class Program
    {
        static void Main(string[] args)
        {
            new CommandInterpreter().Run();
            Console.ReadKey();
        }
    }
}
