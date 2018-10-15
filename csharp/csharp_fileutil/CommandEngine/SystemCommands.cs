using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsharpFileutil.CommandEngine
{
    public class UsageCommand : AbstractCommand
    {
        public new static readonly string UsageString =
                   "usage command displays available commands or the way to use the command in its argument.\n" +
                   "Use it the following way:\n" +
                   "\t'usage' - displays the list of available commands.\n" +
                   "\t'usage <command>' - displays the description and way to use for <command>.";

        public UsageCommand(List<string> args) : base(args)
        {

        }

        public override void Execute()
        {
            if(Arguments.Count == 0)
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
                    default:
                        Console.WriteLine("Usage doesn't know this command.");
                        Console.WriteLine("Available commands: {0}.", GetAvailableCommands());
                        break;
                }
        }
    }

    public class ExitCommand : AbstractCommand
    {
        public new static readonly string UsageString = 
                   "exit command exits the application.\n" +
                   "Use it the following way:\n" +
                   "\t'exit' - exits the application.";

        public ExitCommand(List<string> args) : base(args)
        {

        }

        public override void Execute()
        {
            Environment.Exit(0);
        }
    }
}
