package JavaFileutil.Validators;

import java.util.List;

public class ArgumentValueValidator extends AbstractValidator
{
    private short Index;
    private String Value;

    public ArgumentValueValidator(List<String> args, short index, String value, String message)
    {
        super(args, message);
        Index = index;
        Value = value;
    }

    @Override
    public boolean Validate()
    {
        if(Arguments.size() <= Index || !Arguments.get(Index).equals(Value))
        {
            System.out.println(ErrorPreface + Message);
            return false;
        }

        return true;
    }
}
