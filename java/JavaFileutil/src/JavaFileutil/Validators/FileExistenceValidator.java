package JavaFileutil.Validators;

import java.util.List;

public class FileExistenceValidator extends AbstractFilesystemEntryValidator
{
    public FileExistenceValidator(List<String> args, short index, String message)
    {
        super(args, index, message);
    }

    @Override
    public boolean Validate()
    {
        if (file == null || !file.exists() || !file.isFile())
        {
            System.out.println(ErrorPreface + Message);
            return false;
        }

        return true;
    }
}
