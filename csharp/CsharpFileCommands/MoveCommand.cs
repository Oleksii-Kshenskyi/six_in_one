using System;
using System.Collections.Generic;
using System.IO;
using CsharpCommandEngine;

namespace CsharpFileCommands
{
    public class MoveCommand : AbstractBinaryFileCommand
    {
        public new static readonly string UsageString =
           "move command moves <file1> to the location specified in <file2>.\n" +
           "Use it the following way:\n" +
           "\t'move <file1> to <file2>'\n" +
           "\tNOTE: the command takes EXACTLY 3 arguments, EXACTLY in the specified order!";

        public MoveCommand(List<string> args) : base(args)
        {

        }

        public override void Execute()
        {
            if (!Validation.Validate())
                return;

            try
            {
                File.Move(Arguments[0], Arguments[2]);
            }
            catch (Exception e)
            {
                if (e.Source != null && e.Source != "" && e.Message != null && e.Message != "")
                {
                    Console.WriteLine("Move exception.\nSource: {0};\nError message: {1}", e.Source, e.Message);
                    if (e.Message.Contains("A required privilege is not held by the client"))
                        Console.WriteLine("Try running the application as administrator.");
                }
                else
                    Console.WriteLine("An unrecognized move exception has occured.");
            }
        }
    }
}
