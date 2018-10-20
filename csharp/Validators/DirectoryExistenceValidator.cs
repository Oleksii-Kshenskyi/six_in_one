using System;
using System.Collections.Generic;
using System.IO;

namespace Validators
{
    public class DirectoryExistenceValidator: AbstractValidator
    {
        protected new static readonly string ValidationFailureMessage = "NOTE: directory {0} does not exist!";
        private string DirectoryPath { get; set; }

        public DirectoryExistenceValidator(List<string> args, ushort index) : base(args)
        {
            DirectoryPath = args[index];
        }

        public override bool Validate()
        {
            if (!Directory.Exists(DirectoryPath))
            {
                Console.WriteLine(string.Format(ValidationFailureMessage, DirectoryPath));
                return false;
            }

            return true;
        }
    }

    public class DirectoryNonExistenceValidator : DirectoryExistenceValidator
    {
        protected new static readonly string ValidationFailureMessage = "NOTE: directory {0} exists!";
        public DirectoryNonExistenceValidator(List<string> args, ushort index) : base(args, index)
        {
        }

        public override bool Validate()
        {
            return !base.Validate();
        }
    }
}
