using System.Collections.Generic;
using Validators;

namespace CsharpCommandEngine
{
    public abstract class AbstractUnaryFileCommand: AbstractFileCommand
    {
        private const string ArgumentCountMismatchMessage = "ERROR: the command takes EXACTLY 1 argument!";

        protected new void SetupValidation()
        {
            Validation.AddValidator(new ArgumentCountValidator(Arguments, 1, ArgumentCountMismatchMessage));
        }

        public AbstractUnaryFileCommand(List<string> args) : base(args)
        {
            SetupValidation();
        }
    }
}
