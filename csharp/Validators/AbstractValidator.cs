using System;
using System.Collections.Generic;

namespace Validators
{
    public abstract class AbstractValidator
    {
        protected List<string> Arguments { get; set; }
        public string Message { get; protected set; }

        public AbstractValidator(List<string> args, string message)
        {
            Arguments = args;
            Message = message;
        }

        public abstract bool Validate();
    }
}
