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
                                               "\tOutput is of the following format:\n" +
                                               "\t'=[F|D] <[file|directory]_name> [(<file_size>)]'\n" +
                                               "\twhere [F|D] shows if it is a file or a directory.\n" +
                                               "\tNOTE: the command takes EXACTLY 1 argument.";

        public ListDirectoryCommand(List<string> args) : base(args)
        {
        }

        private string GetSize(string filename)
        {
            double rawSize = new FileInfo(filename).Length;

            return (rawSize >= 0 && rawSize < 1024) ? string.Format("{0}B", rawSize) :
                   (rawSize >= 1024 && rawSize < 1024 * 1024) ? string.Format("{0}KB", rawSize / 1024) :
                   (rawSize >= 1024 * 1024) ? string.Format("{0}MB", rawSize / (1024 * 1024)) : "";
        }

        private void ListDirectories()
        {
            if (Directories != null)
                foreach (var item in Directories)
                    Console.WriteLine("=D {0}", item);
        }

        private void ListFiles()
        {
            if (Files != null)
                foreach (var item in Files)
                    Console.WriteLine("-F {0} ({1})", item, GetSize(item));
        }

        private void CountEntities()
        {
            var dircount = Directories != null ? Directories.Count : 0;
            var filescount = Files != null ? Files.Count : 0;
            Console.WriteLine("======\n=TOTAL ITEMS: {0}.", dircount + filescount);
        }

        public override void Execute()
        {
            if (!Validation.Validate())
                return;

            ListDirectories();
            ListFiles();

            CountEntities();
        }
    }
}
