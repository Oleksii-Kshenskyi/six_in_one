using System;
using System.Collections.Generic;
using System.IO;

namespace Validators
{
    public class AbsolutePathValidator: AbstractValidator
    {
        private string Path { get; set; }

        public AbsolutePathValidator(List<string> args, ushort index, string message) : base(args, message)
        {
            Path = args[index];
        }

        public override bool Validate()
        {
            if (System.IO.Path.IsPathRooted(Path))
            {
                Console.WriteLine(Message);
                return false;
            }

            return true;
        }
    }
}
