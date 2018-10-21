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

        protected List<string> Files { get; private set; }
        protected List<string> Directories { get; private set; }

        protected override void SetupValidation()
        {
            Validation.AddValidator(new ArgumentCountValidator(Arguments, 1, ArgumentCountMismatchMessage));
            Validation.AddValidator(new DirectoryExistenceValidator(Arguments, 0, StickToSyntaxMessage));
        }

        public AbstractUnaryDirectoryCommand(List<string> args) : base(args)
        {
            SetupValidation();

            if (Arguments.Count == 1 && Directory.Exists(Arguments[0]))
            {
                Directories = new List<string>(Directory.GetDirectories(Arguments[0]));
                Files = new List<string>(Directory.GetFiles(Arguments[0]));
            }
            else
            {
                Directories = null;
                Files = null;
            }
        }
    }
}
