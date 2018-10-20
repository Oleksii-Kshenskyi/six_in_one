using System;
using System.Collections.Generic;
using System.Text;

namespace Validators
{
    public class ArgumentExistenceValidator : AbstractValidator
    {
        private ushort Index { get; set; }

        public ArgumentExistenceValidator(List<string> args, ushort index, string message) : base(args, message)
        {
            Index = index;
        }

        public override bool Validate()
        {
            if (Arguments.Count > Index && Arguments[Index] != null)
                return true;

            Console.WriteLine(Message);
            return false;
        }
    }
}
