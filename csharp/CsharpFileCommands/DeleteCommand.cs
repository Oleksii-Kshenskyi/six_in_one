using System;
using System.IO;
using System.Collections.Generic;
using CsharpCommandEngine;

namespace CsharpFileCommands
{
    public class DeleteCommand: AbstractUnaryFileCommand
    {
        public new static readonly string UsageString =
            "delete command deletes <file1>.\n" +
            "Use it the following way:\n" +
            "\t'delete <file1>'\n" +
            "\t" + UnaryWarning;

        public DeleteCommand(List<string> args) : base(args)
        {

        }

        public override void Execute()
        {
            if (!AllowedToExecute)
                return;

            try
            {
                File.Delete(Arguments[0]);
            }
            catch (Exception e)
            {
                if (e.Source != null && e.Source != "" && e.Message != null && e.Message != "")
                {
                    Console.WriteLine("Delete exception.\nSource: {0};\nError message: {1}", e.Source, e.Message);
                    if (e.Message.Contains("A required privilege is not held by the client"))
                        Console.WriteLine("Try running the application as administrator.");
                }
                else
                    Console.WriteLine("An unrecognized delete exception has occured.");
            }
        }
    }
}
