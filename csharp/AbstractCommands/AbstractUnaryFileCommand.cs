using System.Collections.Generic;

namespace CsharpCommandEngine
{
    public abstract class AbstractUnaryFileCommand: AbstractFileCommand
    {
        public AbstractUnaryFileCommand(List<string> args) : base(args, Arity.UNARY)
        {

        }
    }
}
