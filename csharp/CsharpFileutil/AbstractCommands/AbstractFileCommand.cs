using System;
using System.Collections.Generic;
using System.IO;

namespace CsharpCommandEngine
{
    public abstract class AbstractFileCommand : AbstractCommand
    {
        public new static readonly string UsageString =
            "NOTE: the command takes EXACTLY 4 arguments, EXACTLY in the specified order.";
        protected bool AllowedToExecute { get; private set; } = false;

        private void PerformPreChecks()
        {
            if (Arguments.Count != 3)
            {
                Console.WriteLine(UsageString);
                return;
            }

            if (!File.Exists(Arguments[0]))
            {
                Console.WriteLine("The source file {0} does not exist.", Arguments[0]);
                return;
            }

            if (Arguments[1] != "to")
            {
                Console.WriteLine("Please follow the syntax: '<file_command> <file1> to <file2>'.");
                return;
            }

            AllowedToExecute = true;
        }

        public AbstractFileCommand(List<string> args) : base(args)
        {
            PerformPreChecks();
        }
    }
}
