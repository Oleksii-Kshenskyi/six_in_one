using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace csharp_fileutil.CommandEngine
{
    public abstract class AbstractCommand
    {
        protected List<string> Arguments { get; private set; }
        private readonly IList<String> AvailableCommands = 
                                       new ReadOnlyCollection<string> (new List <string> { "test1", "test2", "usage", "exit" });

        public AbstractCommand(List<string> args)
        {
            Arguments = args;
        }

        protected string GetAvailableCommands()
        {
            return String.Join(", ", AvailableCommands);
        }

        public abstract void Execute();
    }

    public class Test1Command : AbstractCommand
    {
        public Test1Command(List<string> args): base(args)
        {
            
        }

        public override void Execute()
        {
            Console.WriteLine("Test 1: {0}.", String.Join(", ", Arguments));
        }
    }

    public class Test2Command : AbstractCommand
    {
        public Test2Command(List<string> args) : base(args)
        {

        }

        public override void Execute()
        {
            Console.WriteLine("Test 2: {0}.", String.Join(", ", Arguments));
        }
    }

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
