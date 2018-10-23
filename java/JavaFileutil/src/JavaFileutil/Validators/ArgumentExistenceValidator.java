package JavaFileutil.Validators;

import java.util.List;

public class ArgumentExistenceValidator extends AbstractValidator
{
    private short Index;

    public ArgumentExistenceValidator(List<String> args, short index, String message)
    {
        super(args, message);
        Index = index;
    }

    @Override
    public boolean Validate()
    {
        if (Arguments.size() <= Index || Arguments.get(Index) == null)
        {
            System.out.println(ErrorPreface + Message);
            return false;
        }

        return true;
    }
}
