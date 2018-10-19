using System;
using System.Collections.Generic;

namespace Validators
{
    public abstract class AbstractValidator
    {
        protected List<string> Arguments { get; set; }
        protected static readonly string ValidationFailureMessage = "placeholder";

        public AbstractValidator(List<string> args)
        {
            Arguments = args;
        }

        public abstract bool Validate();
    }
}
