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
            Path = (Arguments.Count > index) ? args[index] : null;
        }

        public override bool Validate()
        {
            if (Path == null || System.IO.Path.IsPathRooted(Path))
            {
                Console.WriteLine(Message);
                return false;
            }

            return true;
        }
    }
}
