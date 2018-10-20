using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Validators;

namespace CsharpCommandEngine
{

    public abstract class AbstractCommand
    {
        protected List<string> Arguments { get; private set; }
        private static readonly IList<String> AvailableCommands =
                                       new ReadOnlyCollection<string>(new List<string> { "usage", "exit", "copy", "move", "rename", "delete" });
        public static readonly string UsageString = "placeholder";
        protected ValidationStack Validation {get; set;}

        protected const string UnaryWarning = "NOTE: the command takes EXACTLY 1 argument!";
        protected const string BinaryWarning = "NOTE: the command takes EXACTLY 3 arguments, EXACTLY in the specified order!";

        public AbstractCommand(List<string> args)
        {
            Arguments = args;
            Validation = new ValidationStack();
        }

        protected string GetAvailableCommands()
        {
            return string.Join(", ", AvailableCommands);
        }

        public abstract void Execute();
        protected abstract void SetupValidation();
    }
}
