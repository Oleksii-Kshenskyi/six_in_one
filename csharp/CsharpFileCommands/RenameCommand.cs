using System;
using System.IO;
using System.Collections.Generic;
using CsharpCommandEngine;

namespace CsharpFileCommands
{
    public class RenameCommand : MoveCommand
    {
        public new static readonly string UsageString =
            "rename command renames <file1> to the name specified in <name1>.\n" +
            "Use it the following way:\n" +
            "\t'rename <file1> to <name1>'\n" +
            "\t" + AbstractBinaryFileCommand.UsageString + "\n" +
            "\tNOTE: For the purpose of moving a file to another folder, please use the 'move' command instead.";

        public RenameCommand(List<string> args) : base(args)
        {

        }

        public override void Execute()
        {
            if (!AllowedToExecute)
                return;

            if (Path.IsPathRooted(Arguments[2]))
            {
                Console.WriteLine("NOTE: For the purpose of moving a file to another folder, please use the 'move' command instead.\n" + 
                                  "Please only use 'rename' to rename your files, not to move them.\n" + 
                                  "NOTE: The operation hasn't been completed. Please use move instead.");
                return;
            }

            Arguments[2] = Path.Combine(Path.GetDirectoryName(Arguments[0]), Arguments[2]);

            base.Execute();
        }
    }
}
