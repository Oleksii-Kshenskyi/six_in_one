using System;
using System.Collections.Generic;
using System.Text;

namespace Validators
{
    public class ArgumentLimitValidator: ArgumentCountValidator
    {
        public ArgumentLimitValidator(List<string> args, ushort count, string message): base(args, count, message)
        {
        }

        public override bool Validate()
        {
            if (Arguments.Count >= Count)
            {
                Console.WriteLine("ERROR: " + Message);
                return false;
            }

            return true;
        }
    }
}
