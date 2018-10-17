using System;
using System.Collections.Generic;
using System.Text;

namespace CsharpCommandEngine
{
    public abstract class AbstractUnaryFileCommand: AbstractFileCommand
    {
        public new static readonly string UsageString =
            "NOTE: the command takes EXACTLY 1 argument, a file name.";

        public AbstractUnaryFileCommand(List<string> args) : base(args)
        {
            if (!AllowedToExecute)
                return;
            else
                AllowedToExecute = false;

            if (Arguments.Count != 1)
            {
                Console.WriteLine(UsageString);
                return;
            }

            AllowedToExecute = true;
        }
    }
}
