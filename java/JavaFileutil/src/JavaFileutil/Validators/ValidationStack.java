package JavaFileutil.Validators;

import java.util.ArrayList;
import java.util.List;

public class ValidationStack
{
    private List<AbstractValidator> ValidatorStack;

    public ValidationStack()
    {
        ValidatorStack = new ArrayList<>();
    }

    public ValidationStack(List<AbstractValidator> newValidators)
    {
        ValidatorStack = newValidators;
    }

    public void AddValidator(AbstractValidator newValidator)
    {
        if (newValidator != null)
            ValidatorStack.add(newValidator);
    }

    public boolean Validate()
    {
        var TempStack = ValidatorStack;

        for(var validator : TempStack)
        {
            if (!validator.Validate())
                return false;
        }

        return true;
    }
}
