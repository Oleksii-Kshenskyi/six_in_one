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
            FilePath = (Arguments.Count > index) ? Arguments[index] : null;
        }

        public override bool Validate()
        {
            if (FilePath == null || !File.Exists(FilePath))
            {
                Console.WriteLine(Message);
                return false;
            }

            return true;
        }
    }
}
