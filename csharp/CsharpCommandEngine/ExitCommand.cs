using System;
using System.Collections.Generic;
using Validators;

namespace CsharpCommandEngine
{
    public class ExitCommand : AbstractCommand
    {
        public new static readonly string UsageString =
                   "exit command exits the application.\n" +
                   "Use it the following way:\n" +
                   "\t'exit' - exits the application.";

        protected override void SetupValidation()
        {
            Validation.AddValidator(new ArgumentCountValidator(Arguments, 1));
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
