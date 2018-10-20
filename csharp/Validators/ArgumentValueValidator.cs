using System;
using System.Collections.Generic;
using System.Text;

namespace Validators
{
    public class ArgumentValueValidator: AbstractValidator
    {
        private ushort Index { get; set; }
        private string Value { get; set; }

        public ArgumentValueValidator(List<string> args, ushort index, string value, string message) : base(args, message)
        {
            Index = index;
            Value = value;
        }

        public override bool Validate()
        {
            if (Arguments[Index] != Value)
            {
                Console.WriteLine(Message);
                return false;
            }

            return true;
        }
    }
}
