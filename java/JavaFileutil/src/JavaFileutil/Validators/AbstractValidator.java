package JavaFileutil.Validators;

import java.util.List;

public abstract class AbstractValidator
{
    protected List<String> Arguments;
    protected String Message;

    public AbstractValidator(List<String> args, String message)
    {
        Arguments = args;
        Message = message;
    }

    public abstract boolean Validate();
}
