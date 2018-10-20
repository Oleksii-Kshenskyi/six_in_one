using System;
using System.Collections.Generic;
using System.IO;
using Validators;

namespace CsharpCommandEngine
{
    public abstract class AbstractFileCommand : AbstractCommand
    {
        private const string NoArgumentsMessage = "A file command requires arguments to be executed.\n" +
                                                  "Type 'usage <command>' to get help for the <command> of your choice.";
        private const string DirectoryInsteadOfFileMessage = "ERROR: Source file is a directory name.\n" +
                                                             "Please use the command for files instead of directories.";
        private const string FileDoesNotExistMessage = "The source file does not exist.";

        protected override void SetupValidation()
        {
            Validation.AddValidator(new ArgumentExistenceValidator(Arguments, 0, NoArgumentsMessage));
            Validation.AddValidator(new DirectoryNonExistenceValidator(Arguments, 0, DirectoryInsteadOfFileMessage));
            Validation.AddValidator(new FileExistenceValidator(Arguments, 0, FileDoesNotExistMessage));
        }

        public AbstractFileCommand(List<string> args) : base(args)
        {
            SetupValidation();
        }
    }
}
