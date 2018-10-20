using System;
using System.Collections.Generic;
using System.Text;

namespace Validators
{
    public class ArgumentCountValidator: AbstractValidator
    {
        private ushort Count { get; set; }

        public ArgumentCountValidator(List<string> args, ushort count, string message) : base(args, message)
        {
            Count = count;
        }

        public override bool Validate()
        {
            if (Arguments.Count != Count)
            {
                Console.WriteLine(Message);
                return false;
            }

            return true;
        }
    }
}
