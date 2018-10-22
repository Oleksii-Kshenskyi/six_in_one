using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CsharpCommandEngine;

namespace CsharpFileutil
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
                new CommandFactory(arguments).Create().Execute();
            }
        }

        public CommandInterpreter()
        {
        }

        public void Run()
        {
            Console.WriteLine("Welcome to the file utility command interpreter!");
            Console.WriteLine("Author: Oleksii <DarkSpectre> Kshenskyi.");
            new CommandFactory(new List<string>(new []{"usage"})).Create().Execute();
            Console.WriteLine("Type 'usage <command>' to learn about the <command> you're interested in.");
            RunEventLoop();
        }
    }
}
