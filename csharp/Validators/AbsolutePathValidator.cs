using System;
using System.Collections.Generic;
using System.IO;

namespace Validators
{
    class AbsolutePathValidator: AbstractValidator
    {
        protected new static readonly string ValidationFailureMessage = "NOTE: path {0} is absolute [should be relative]!";
        private string Path { get; set; }

        public AbsolutePathValidator(List<string> args, ushort index) : base(args)
        {
            Path = args[index];
        }

        public override bool Validate()
        {
            if (System.IO.Path.IsPathRooted(Path))
            {
                Console.WriteLine(string.Format(ValidationFailureMessage, Path));
                return false;
            }

            return true;
        }
    }
}
