using System;
using System.IO;
using System.Collections.Generic;
using CsharpCommandEngine;

namespace CsharpFileCommands
{
    public class CopyCommand: AbstractBinaryFileCommand
    {
        public new static readonly string UsageString =
           "copy command copies <file1> to the location specified in <file2>.\n" +
           "Use it the following way:\n" +
           "\t'copy <file1> to <file2>'\n" +
           "\t" + AbstractBinaryFileCommand.UsageString;

        public CopyCommand(List<string> args) : base(args)
        {

        }

        public override void Execute()
        {
            if (!AllowedToExecute)
                return;

            try
            {
                File.Copy(Arguments[0], Arguments[2]);
            }
            catch (Exception e)
            {
                if (e.Source != null && e.Source != "" && e.Message != null && e.Message != "")
                {
                    Console.WriteLine("Copy exception.\nSource: {0};\nError message: {1}", e.Source, e.Message);
                    if (e.Message.Contains("A required privilege is not held by the client"))
                        Console.WriteLine("Try running the application as administrator.");
                }
                else
                    Console.WriteLine("An unrecognized copy exception has occured.");
            }
        }
    }
}
