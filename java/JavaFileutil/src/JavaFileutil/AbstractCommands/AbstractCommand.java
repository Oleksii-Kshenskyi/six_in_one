package JavaFileutil.AbstractCommands;

import java.util.ArrayList;
import java.util.List;

public abstract class AbstractCommand
{
    protected ArrayList<String> Arguments;
    private static final String[] AvailableCommands = { "usage", "exit" };
    public static final String UsageString = "placeholder";

    public AbstractCommand(ArrayList<String> args)
    {
        Arguments = args;
    }

    protected String GetAvailableCommands()
    {
        return String.join(", ", AvailableCommands);
    }

    public abstract void Execute();
    protected abstract void SetupValidation();
}
