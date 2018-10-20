using System;
using System.Collections.Generic;
using System.Text;

namespace Validators
{
    public class ArgumentCountValidator: AbstractValidator
    {
        protected new static readonly string ValidationFailureMessage = "NOTE: the command takes EXACTLY {0} argument(s), EXACTLY in the specified order!";
        private ushort Count { get; set; }

        public ArgumentCountValidator(List<string> args, ushort count) : base(args)
        {
            Count = count;
        }

        public override bool Validate()
        {
            if (Arguments.Count != Count)
            {
                Console.WriteLine(string.Format(ValidationFailureMessage, Count));
                return false;
            }

            return true;
        }
    }
}
