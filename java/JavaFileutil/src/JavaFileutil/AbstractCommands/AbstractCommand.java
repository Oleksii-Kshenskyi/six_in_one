package JavaFileutil.AbstractCommands;

import java.util.List;
import JavaFileutil.Validators.ValidationStack;

public abstract class AbstractCommand
{
    protected List<String> Arguments;
    protected ValidationStack Validation;
    private static final String[] AvailableCommands = { "usage", "exit" };
    public static final String UsageString = "placeholder";

    public AbstractCommand(List<String> args)
    {
        Arguments = args;
        Validation = new ValidationStack();
    }

    protected String GetAvailableCommands()
    {
        return String.join(", ", AvailableCommands);
    }

    public abstract void Execute();
    protected abstract void SetupValidation();
}
