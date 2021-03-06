package JavaFileutil.Validators;

import java.util.List;

public class ArgumentCountValidator extends AbstractValidator
{
    protected short Count;

    public ArgumentCountValidator(List<String> args, short count, String message)
    {
        super(args, message);
        Count = count;
    }

    @Override
    public boolean Validate()
    {
        if (Arguments.size() != Count)
        {
            System.out.println(ErrorPreface + Message);
            return false;
        }

        return true;
    }
}
