package JavaFileutil.Validators;

import java.util.List;

public class NonAbsolutePathValidator extends AbstractFilesystemEntryValidator
{
    public NonAbsolutePathValidator(List<String> args, short index, String message)
    {
        super(args, index, message);
    }

    @Override
    public boolean Validate()
    {
        if(file == null || file.isAbsolute())
        {
            System.out.println(ErrorPreface + Message);
            return false;
        }

        return true;
    }
}
