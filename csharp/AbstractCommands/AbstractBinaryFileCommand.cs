using System;
using System.Collections.Generic;
using System.IO;
using Validators;

namespace CsharpCommandEngine
{
    public abstract class AbstractBinaryFileCommand : AbstractFileCommand
    {
        private const string ArgumentCountMismatchMessage = "ERROR: the command takes EXACTLY 3 arguments, EXACTLY in the specified order!";
        private const string StickToSyntaxMessage = "Please follow the syntax: '<file_command> <file1> to <file2>'.";

        protected override void SetupValidation()
        {
            Validation.AddValidator(new ArgumentCountValidator(Arguments, 3, ArgumentCountMismatchMessage));
            Validation.AddValidator(new ArgumentValueValidator(Arguments, 1, "to", StickToSyntaxMessage));
        }

        public AbstractBinaryFileCommand(List<string> args): base(args)
        {
            SetupValidation();

            if (Arguments.Count >= 3 && Directory.Exists(Arguments[2]))
                Arguments[2] = Path.Combine(Arguments[2], Path.GetFileName(Arguments[0]));
        }
    }
}
