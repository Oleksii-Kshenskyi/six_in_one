using System;
using System.Collections.Generic;
using System.Text;

namespace Validators
{
    public class ValidationStack
    {
        private List<AbstractValidator> ValidatorStack { get; set; }

        public ValidationStack()
        {
            ValidatorStack = new List<AbstractValidator>();
        }

        public ValidationStack(List<AbstractValidator> newValidators)
        {
            ValidatorStack = newValidators;
        }

        public void AddValidator(AbstractValidator newValidator)
        {
            if (newValidator != null)
                ValidatorStack.Add(newValidator);
        }

        public bool Validate()
        {
            var TempStack = ValidatorStack;

            foreach(var validator in TempStack)
            {
                if (!validator.Validate())
                    return false;
            }

            return true;
        }
    }
}
