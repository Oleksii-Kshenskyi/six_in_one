using System;
using System.Collections.Generic;
using System.IO;
using Validators;

namespace CsharpCommandEngine
{
    public abstract class AbstractUnaryDirectoryCommand: AbstractCommand
    {
        private const string ArgumentCountMismatchMessage = "ERROR: the command takes EXACTLY 1 argument!";
        private const string StickToSyntaxMessage = "ERROR: The argument has to be the name of the directory.";

        protected override void SetupValidation()
        {
            Validation.AddValidator(new ArgumentCountValidator(Arguments, 1, ArgumentCountMismatchMessage));
            Validation.AddValidator(new DirectoryExistenceValidator(Arguments, 0, StickToSyntaxMessage));
        }

        public AbstractUnaryDirectoryCommand(List<string> args) : base(args)
        {
            SetupValidation();
        }
    }
}
