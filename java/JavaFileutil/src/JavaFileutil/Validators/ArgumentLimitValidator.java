package JavaFileutil.Validators;

import java.util.List;

public class ArgumentLimitValidator extends ArgumentCountValidator
{
    public ArgumentLimitValidator(List<String> args, short count, String message)
    {
        super(args, count, message);
    }

    @Override
    public boolean Validate()
    {
        if(Arguments.size() >= Count)
        {
            System.out.format(ErrorPreface + Message + "\n", Count);
            return false;
        }

        return true;
    }
}
