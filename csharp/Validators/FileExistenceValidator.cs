using System;
using System.Collections.Generic;
using System.IO;

namespace Validators
{
    class FileExistenceValidator: AbstractValidator
    {
        protected new static readonly string ValidationFailureMessage = "NOTE: file {0} does not exist!";
        private string FilePath { get; set; }

        public FileExistenceValidator(List<string> args, ushort index) : base(args)
        {
            FilePath = args[index];
        }

        public override bool Validate()
        {
            if (!File.Exists(FilePath))
            {
                Console.WriteLine(string.Format(ValidationFailureMessage, FilePath));
                return false;
            }

            return true;
        }
    }
}
