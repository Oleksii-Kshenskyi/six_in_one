using System;
using System.Collections.Generic;
using Validators;

namespace CsharpCommandEngine
{
    public class ExitCommand : AbstractCommand
    {
        private const string NoArgumentsNeededMessage = "ERROR: the exit command does not require any arguments.";

        public new static readonly string UsageString =
                   "exit command exits the application.\n" +
                   "Use it the following way:\n" +
                   "\t'exit' - exits the application.";

        protected override void SetupValidation()
        {
            Validation.AddValidator(new ArgumentCountValidator(Arguments, 0, NoArgumentsNeededMessage));
        }

        public ExitCommand(List<string> args) : base(args)
        {
            SetupValidation();
        }

        public override void Execute()
        {
            if (!Validation.Validate())
                return;

            Environment.Exit(0);
        }
    }
}
