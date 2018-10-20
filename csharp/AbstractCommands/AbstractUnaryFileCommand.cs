using System.Collections.Generic;
using Validators;

namespace CsharpCommandEngine
{
    public abstract class AbstractUnaryFileCommand: AbstractFileCommand
    {
        protected override void SetupValidation()
        {
            Validation.AddValidator(new ArgumentCountValidator(Arguments, 1));
        }

        public AbstractUnaryFileCommand(List<string> args) : base(args)
        {
            SetupValidation();
        }
    }
}
