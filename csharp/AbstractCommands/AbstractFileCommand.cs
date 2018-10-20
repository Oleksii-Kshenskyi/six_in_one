using System;
using System.Collections.Generic;
using System.IO;
using Validators;

namespace CsharpCommandEngine
{
    public abstract class AbstractFileCommand : AbstractCommand
    {
        public new static readonly string UsageString =
            "placeholder";

        protected override void SetupValidation()
        {
            Validation.AddValidator(new ArgumentCountValidator(Arguments, 0));
            Validation.AddValidator(new DirectoryNonExistenceValidator(Arguments, 0));
            Validation.AddValidator(new FileExistenceValidator(Arguments, 0));
        }

        public AbstractFileCommand(List<string> args) : base(args)
        {
            SetupValidation();

            /*if (!AllowedToExecute)
                return;
            else
                AllowedToExecute = false;

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

            AllowedToExecute = true;*/
        }
    }
}
