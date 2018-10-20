using System;
using System.Collections.Generic;
using System.Text;

namespace Validators
{
    public class ArgumentValueValidator: AbstractValidator
    {
        protected new static readonly string ValidationFailureMessage = "NOTE: the value of argument {0} should be {1}!";
        private ushort Index { get; set; }
        private string Value { get; set; }

        public ArgumentValueValidator(List<string> args, ushort index, string value) : base(args)
        {
            Index = index;
            Value = value;
        }

        public override bool Validate()
        {
            if (Arguments[Index] != Value)
            {
                Console.WriteLine(string.Format(ValidationFailureMessage, Index, Value));
                return false;
            }

            return true;
        }
    }
}
