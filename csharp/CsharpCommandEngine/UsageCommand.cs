using System;
using System.Collections.Generic;
using CsharpFileCommands;
using Validators;

namespace CsharpCommandEngine
{
    public class UsageCommand : AbstractCommand
    {
        private static readonly string ArgumentLimitMessage = "The command takes strictly less than 2 arguments.";

        public new static readonly string UsageString =
                   "usage command displays available commands or the way to use the command in its argument.\n" +
                   "Use it the following way:\n" +
                   "\t'usage' - displays the list of available commands.\n" +
                   "\t'usage <command>' - displays the description and way to use for <command>.\n" +
                   "\tNOTE: " + ArgumentLimitMessage;

        protected override void SetupValidation()
        {
            Validation.AddValidator(new ArgumentLimitValidator(Arguments, 2, ArgumentLimitMessage));
        }

        public UsageCommand(List<string> args) : base(args)
        {
            SetupValidation();
        }

        public override void Execute()
        {
            if (!Validation.Validate())
                return;

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
                    case "list":
                        Console.WriteLine(ListDirectoryCommand.UsageString);
                        break;
                    default:
                        Console.WriteLine("Usage doesn't know this command.");
                        Console.WriteLine("Available commands: {0}.", GetAvailableCommands());
                        break;
                }
        }
    }
}
