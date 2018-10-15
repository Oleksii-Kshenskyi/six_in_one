using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace csharp_fileutil
{
    public class CommandInterpreter
    {
        private void RunEventLoop()
        {
            while (true)
            {
                Console.Write("===> ");
                string choice = Console.ReadLine();
                List<string> arguments = new List<string>(choice.Split(new char[] {' '}, StringSplitOptions.RemoveEmptyEntries));
                new CommandEngine.CommandFactory(arguments).Create().Execute();
            }
        }

        public CommandInterpreter()
        {
        }

        public void Run()
        {
            Console.WriteLine("Welcome to the in-progress implementation of this basic command interpreter!");
            Console.WriteLine("Author: Oleksii <DarkSpectre> Kshenskyi.");
            RunEventLoop();
        }
    }
}
