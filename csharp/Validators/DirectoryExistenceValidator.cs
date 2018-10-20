using System;
using System.Collections.Generic;
using System.IO;

namespace Validators
{
    public class DirectoryExistenceValidator: AbstractValidator
    {
        protected string DirectoryPath { get; set; }

        public DirectoryExistenceValidator(List<string> args, ushort index, string message) : base(args, message)
        {
            DirectoryPath = args[index];
        }

        public override bool Validate()
        {
            if (!Directory.Exists(DirectoryPath))
            {
                Console.WriteLine(Message);
                return false;
            }

            return true;
        }
    }

    public class DirectoryNonExistenceValidator : DirectoryExistenceValidator
    {
        public DirectoryNonExistenceValidator(List<string> args, ushort index, string message) : base(args, index, message)
        {
        }

        public override bool Validate()
        {
            if (Directory.Exists(DirectoryPath))
            {
                Console.WriteLine(Message);
                return false;
            }

            return true;
        }
    }
}
