using System;
using System.Collections.Generic;
using CsharpCommandEngine;
using System.IO;

namespace CsharpFileCommands
{
    public class ListDirectoryCommand: AbstractUnaryDirectoryCommand
    {
        public new static string UsageString = "list command lists all the contents of <directory1>.\n" +
                                               "Use it the following way:\n" +
                                               "\t'list <directory1>'\n" +
                                               "\tOutput is of the following format:" +
                                               "\t'=[F|D] <[file|directory]_name> [(<file_size>)]'" +
                                               "\twhere [F|D] shows if it is a file or a directory." +
                                               "\tNOTE: the command takes EXACTLY 1 argument.";

        public ListDirectoryCommand(List<string> args) : base(args)
        {
        }

        public override void Execute()
        {
            if (!Validation.Validate())
                return;

            var dirs = Directory.GetDirectories(Arguments[0]);
            var files = Directory.GetFiles(Arguments[0]);

            if(dirs != null)
                foreach (var item in dirs)
                    Console.WriteLine("=D {0}", item);

            if(files != null)
                foreach (var item in files)
                    Console.WriteLine("-F {0} ({1})", item, GetSize(item));

            var dircount = dirs != null ? dirs.Length : 0;
            var filescount = files != null ? files.Length : 0;
            Console.WriteLine("======\n=TOTAL ITEMS: {0}.", dircount + filescount);
        }

        private string GetSize(string filename)
        {
            double rawSize = new FileInfo(filename).Length;

            return (rawSize >= 0 && rawSize < 1024) ? string.Format("{0}B", rawSize) :
                   (rawSize >= 1024 && rawSize < 1024 * 1024) ? string.Format("{0}KB", rawSize / 1024) :
                   (rawSize >= 1024 * 1024) ? string.Format("{0}MB", rawSize / (1024 * 1024)) : "";
        }

    }
}
