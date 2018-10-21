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
                        return new ExitCommand(Arguments.Skip(1).ToList());
                    case "usage":
                        return new UsageCommand(Arguments.Skip(1).ToList());
                    case "copy":
                        return new CopyCommand(Arguments.Skip(1).ToList());
                    case "move":
                        return new MoveCommand(Arguments.Skip(1).ToList());
                    case "rename":
                        return new RenameCommand(Arguments.Skip(1).ToList());
                    case "delete":
                        return new DeleteCommand(Arguments.Skip(1).ToList());
                    case "list":
                        return new ListDirectoryCommand(Arguments.Skip(1).ToList());
                    default:
                        Console.Write("Command not found.\n\t");
                        return new UsageCommand(Arguments.Skip(1).ToList());
                }
            else
                return new UsageCommand(new List<string>());
        }
    }
}
