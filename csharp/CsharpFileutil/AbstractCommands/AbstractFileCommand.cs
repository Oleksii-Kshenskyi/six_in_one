using System;
using System.Collections.Generic;
using System.IO;

namespace CsharpCommandEngine
{
    public abstract class AbstractFileCommand : AbstractCommand
    {
        public new static readonly string UsageString =
            "placeholder";
        protected bool AllowedToExecute { get; set; } = false;

        public AbstractFileCommand(List<string> args) : base(args)
        {
            if (Arguments.Count == 0)
            {
                Console.WriteLine("A file command requires arguments to be executed.\n" +
                                  "Type 'usage <command>' to get help for the <command> of your choice.");
                return;
            }

            if (Directory.Exists(Arguments[0]))
            {
                Console.WriteLine("ERROR: {0} is a directory name.\n" + 
                                  "Please use the command for files instead of directories.", Arguments[0]);
                return;
            }

            if (!File.Exists(Arguments[0]))
            {
                Console.WriteLine("The source file {0} does not exist.", Arguments[0]);
                return;
            }

            AllowedToExecute = true;
        }
    }
}
