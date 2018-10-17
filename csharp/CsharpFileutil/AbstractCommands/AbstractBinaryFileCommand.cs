using System;
using System.Collections.Generic;
using System.IO;

namespace CsharpCommandEngine
{
    public abstract class AbstractBinaryFileCommand : AbstractFileCommand
    {
        public new static readonly string UsageString =
            "NOTE: the command takes EXACTLY 3 arguments, EXACTLY in the specified order.";

        public AbstractBinaryFileCommand(List<string> args): base(args)
        {
            if (!AllowedToExecute)
                return;
            else
                AllowedToExecute = false;

            if (Arguments.Count != 3)
            {
                Console.WriteLine(UsageString);
                return;
            }

            if (Arguments[1] != "to")
            {
                Console.WriteLine("Please follow the syntax: '<file_command> <file1> to <file2>'.");
                return;
            }

            if (Directory.Exists(Arguments[2]))
            {
                Arguments[2] = Path.Combine(Arguments[2], Path.GetFileName(Arguments[0]));
            }

            AllowedToExecute = true;
        }
    }
}
