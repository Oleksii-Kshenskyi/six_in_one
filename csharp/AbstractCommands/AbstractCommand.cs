using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;

namespace CsharpCommandEngine
{
    public enum Arity
    {
        NO_ARITY,
        UNARY,
        BINARY
    }

    public abstract class AbstractCommand
    {
        protected List<string> Arguments { get; private set; }
        private static readonly IList<String> AvailableCommands = 
                                       new ReadOnlyCollection<string> (new List <string> { "usage", "exit", "copy", "move", "rename", "delete" });
        public static readonly string UsageString = "placeholder";
        protected bool AllowedToExecute { get; set; } = true;
        protected Arity CommandArity { get; set; } = Arity.NO_ARITY;

        protected const string UnaryWarning = "NOTE: the command takes EXACTLY 1 argument!";
        protected const string BinaryWarning = "NOTE: the command takes EXACTLY 3 arguments, EXACTLY in the specified order!";

        public AbstractCommand(List<string> args)
        {
            Arguments = args;
        }

        public AbstractCommand(List<string> args, Arity arity)
        {
            Arguments = args;
            CommandArity = arity;

            if (arity == Arity.UNARY && args.Count != 1)
            {
                Console.WriteLine(UnaryWarning);
                AllowedToExecute = false;
            }

            if (arity == Arity.BINARY && args.Count != 3)
            {
                Console.WriteLine(BinaryWarning);
                AllowedToExecute = false;
            }
        }

        protected string GetAvailableCommands()
        {
            return String.Join(", ", AvailableCommands);
        }

        public abstract void Execute();
    }
}
