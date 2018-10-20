using System;
using System.Collections.Generic;
using System.IO;
using Validators;

namespace CsharpCommandEngine
{
    public abstract class AbstractBinaryFileCommand : AbstractFileCommand
    {
        protected override void SetupValidation()
        {
            Validation.AddValidator(new ArgumentCountValidator(Arguments, 3));
            Validation.AddValidator(new ArgumentValueValidator(Arguments, 1, "to"));
        }

        public AbstractBinaryFileCommand(List<string> args): base(args)
        {
            SetupValidation();
            /*if (!AllowedToExecute)
                return;
            else
                AllowedToExecute = false;

            if (Arguments[1] != "to")
            {
                Console.WriteLine("Please follow the syntax: '<file_command> <file1> to <file2>'.");
                return;
            }*/

            if (Directory.Exists(Arguments[2]))
                Arguments[2] = Path.Combine(Arguments[2], Path.GetFileName(Arguments[0]));

            //AllowedToExecute = true;
        }
    }
}
