package JavaFileutil.Validators;

import java.util.List;

public class DirectoryNonExistenceValidator extends AbstractFilesystemEntryValidator
{
    public DirectoryNonExistenceValidator(List<String> args, short index, String message)
    {
        super(args, index, message);
    }

    @Override
    public boolean Validate()
    {
        if (file.exists() && file.isDirectory())
        {
            System.out.println(ErrorPreface + Message);
            return false;
        }

        return true;
    }
}
