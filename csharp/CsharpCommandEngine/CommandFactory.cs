using System;
using System.Collections.Generic;
using System.Linq;
using CsharpFileCommands;

namespace CsharpCommandEngine
{
    public class CommandFactory
    {
        private List<String> Arguments { get; set; }

        public CommandFactory(List<string> args)
        {
            Arguments = args;
        }

        public AbstractCommand Create()
        {
            if (Arguments.Count > 0)
                switch (Arguments[0])
                {
                    case "exit":
                        return new ExitCommand(Arguments.Skip(1).ToList<string>());
                    case "usage":
                        return new UsageCommand(Arguments.Skip(1).ToList<string>());
                    case "copy":
                        return new CopyCommand(Arguments.Skip(1).ToList<string>());
                    default:
                        Console.Write("Command not found.\n\t");
                        return new UsageCommand(Arguments.Skip(1).ToList<string>());
                }
            else
                return new UsageCommand(new List<string>());
        }
    }
}
