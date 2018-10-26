package JavaFileutil.AbstractCommands;

import JavaFileutil.Validators.ArgumentCountValidator;

import java.io.File;
import java.util.List;

public abstract class AbstractUnaryFileCommand extends AbstractFileCommand
{
    protected static final String ArgumentCountMismatchMessage = "the command takes EXACTLY 1 argument!";

    protected File file;

    private final void SetupValidation()
    {
        Validation.AddValidator(new ArgumentCountValidator(Arguments, (short)1, ArgumentCountMismatchMessage));
    }

    public AbstractUnaryFileCommand(List<String> args)
    {
        super(args);
        SetupValidation();

        file = (Arguments.size() >= 1 && !Arguments.get(0).isEmpty()) ? new File(Arguments.get(0)) : null;
    }
}
