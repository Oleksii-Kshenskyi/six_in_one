using System;
using System.IO;
using System.Collections.Generic;
using Validators;

namespace CsharpFileCommands
{
    public class RenameCommand : MoveCommand
    {
        private const string AbsolutePathMessage = "NOTE: For the purpose of moving a file to another folder, please use the 'move' command instead.\n" +
                                                   "Please only use 'rename' to rename your files, not to move them.\n" +
                                                   "ERROR: The operation hasn't been completed. Please use move instead.";

        public new static readonly string UsageString =
            "rename command renames <file1> to the name specified in <name1>.\n" +
            "Use it the following way:\n" +
            "\t'rename <file1> to <name1>'\n" +
            "\tNOTE: the command takes EXACTLY 3 arguments, EXACTLY in the specified order!\n" +
            "\tNOTE: For the purpose of moving a file to another folder, please use the 'move' command instead.";

        protected override void SetupValidation()
        {
            Validation.AddValidator(new AbsolutePathValidator(Arguments, 2, AbsolutePathMessage));
        }

        public RenameCommand(List<string> args) : base(args)
        {
            SetupValidation();
        }

        public override void Execute()
        {
            if (!Validation.Validate())
                return;

            Arguments[2] = Path.Combine(Path.GetDirectoryName(Arguments[0]), Arguments[2]);

            base.Execute();
        }
    }
}
