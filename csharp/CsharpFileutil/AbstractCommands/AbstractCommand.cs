using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;

namespace CsharpCommandEngine
{
    public abstract class AbstractCommand
    {
        protected List<string> Arguments { get; private set; }
        private static readonly IList<String> AvailableCommands = 
                                       new ReadOnlyCollection<string> (new List <string> { "usage", "exit", "copy" });
        public static readonly string UsageString = "placeholder";

        public AbstractCommand(List<string> args)
        {
            Arguments = args;
        }

        protected string GetAvailableCommands()
        {
            return String.Join(", ", AvailableCommands);
        }

        public abstract void Execute();
    }
}
