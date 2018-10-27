package JavaFileutil.Validators;

import java.util.List;

public class DirectoryExistenceValidator extends AbstractFilesystemEntryValidator
{
    public DirectoryExistenceValidator(List<String> args, short index, String message)
    {
        super(args, index, message);
    }

    @Override
    public boolean Validate()
    {
        if (!file.exists() || !file.isDirectory())
        {
            System.out.println(ErrorPreface + Message);
            return false;
        }

        return true;
    }
}
