using System;
using System.Collections.Generic;
using System.Text;

namespace CsharpCommandEngine
{
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
