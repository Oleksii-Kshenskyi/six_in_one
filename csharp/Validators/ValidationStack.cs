using System;
using System.Collections.Generic;
using System.Text;

namespace Validators
{
    class ValidationStack
    {
        private Stack<AbstractValidator> ValidatorStack { get; set; }

        public ValidationStack()
        {
            ValidatorStack = new Stack<AbstractValidator>();
        }

        public ValidationStack(Stack<AbstractValidator> newValidators)
        {
            ValidatorStack = newValidators;
        }

        public void AddValidator(AbstractValidator newValidator)
        {
            if (newValidator != null)
                ValidatorStack.Push(newValidator);
        }

        public bool Validate()
        {
            var TempStack = ValidatorStack;

            while (TempStack.Count != 0)
            {
                if (!TempStack.Pop().Validate())
                    return false;
            }

            return true;
        }
    }
}
