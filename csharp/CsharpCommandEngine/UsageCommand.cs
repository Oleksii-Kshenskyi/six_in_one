using System;
using System.Collections.Generic;
using CsharpFileCommands;

namespace CsharpCommandEngine
{
    public class UsageCommand : AbstractCommand
    {
        public new static readonly string UsageString =
                   "usage command displays available commands or the way to use the command in its argument.\n" +
                   "Use it the following way:\n" +
                   "\t'usage' - displays the list of available commands.\n" +
                   "\t'usage <command>' - displays the description and way to use for <command>.";

        protected override void SetupValidation()
        {
        }

        public UsageCommand(List<string> args) : base(args)
        {

        }

        public override void Execute()
        {
            if (Arguments.Count == 0)
                Console.WriteLine("Available commands: {0}.", GetAvailableCommands());
            else
                switch (Arguments[0])
                {
                    case "usage":
                        Console.WriteLine(UsageString);
                        break;
                    case "exit":
                        Console.WriteLine(ExitCommand.UsageString);
                        break;
                    case "copy":
                        Console.WriteLine(CopyCommand.UsageString);
                        break;
                    case "move":
                        Console.WriteLine(MoveCommand.UsageString);
                        break;
                    case "rename":
                        Console.WriteLine(RenameCommand.UsageString);
                        break;
                    case "delete":
                        Console.WriteLine(DeleteCommand.UsageString);
                        break;
                    default:
                        Console.WriteLine("Usage doesn't know this command.");
                        Console.WriteLine("Available commands: {0}.", GetAvailableCommands());
                        break;
                }
        }
    }
}
