using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace csharp_fileutil.CommandEngine
{
    public class UsageCommand : AbstractCommand
    {
        public UsageCommand(List<string> args) : base(args)
        {

        }

        public override void Execute()
        {
            Console.WriteLine("Available commands: {0}.", GetAvailableCommands());
        }
    }

    public class ExitCommand : AbstractCommand
    {
        public ExitCommand(List<string> args) : base(args)
        {

        }

        public override void Execute()
        {
            Environment.Exit(0);
        }
    }
}
