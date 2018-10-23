package JavaFileutil.Validators;

import java.io.File;
import java.util.List;

public abstract class AbstractFilesystemEntryValidator extends AbstractValidator
{
    protected File file;

    public AbstractFilesystemEntryValidator(List<String> args, short index, String message)
    {
        super(args, message);
        file = (Arguments.size() > index) ? new File(Arguments.get(index)) : null;
    }

    @Override
    public abstract boolean Validate();
}
