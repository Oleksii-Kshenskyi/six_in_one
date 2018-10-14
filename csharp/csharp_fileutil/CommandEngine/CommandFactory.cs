using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace csharp_fileutil.CommandEngine
{
    class CommandFactory
    {
        private List<String> Arguments { get; set; }

        public CommandFactory(List<string> args)
        {
            Arguments = args;
        }

        public AbstractCommand Create()
        {
            switch (Arguments[0])
            {
                case "test1":
                    return new Test1Command(Arguments.Skip(1).ToList<string>());
                case "test2":
                    return new Test2Command(Arguments.Skip(1).ToList<string>());
                case "exit":
                    return new ExitCommand(Arguments.Skip(1).ToList<string>());
                case "usage":
                    return new UsageCommand(Arguments.Skip(1).ToList<string>());
                default:
                    Console.Write("Command not found.\n\t");
                    return new UsageCommand(Arguments.Skip(1).ToList<string>());
            }
        }
    }
}
