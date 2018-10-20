using System;
using System.Collections.Generic;
using System.IO;

namespace Validators
{
    public class FileExistenceValidator: AbstractValidator
    {
        private string FilePath { get; set; }

        public FileExistenceValidator(List<string> args, ushort index, string message) : base(args, message)
        {
            FilePath = args[index];
        }

        public override bool Validate()
        {
            if (!File.Exists(FilePath))
            {
                Console.WriteLine(Message);
                return false;
            }

            return true;
        }
    }
}
