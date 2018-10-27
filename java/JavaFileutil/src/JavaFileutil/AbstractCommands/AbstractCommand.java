package JavaFileutil.AbstractCommands;

import java.util.ArrayList;
import java.util.List;
import JavaFileutil.Validators.ValidationStack;

public abstract class AbstractCommand
{
    protected List<String> Arguments;
    protected ValidationStack Validation;
    protected static final String NotePreface = "NOTE: ";
    private static final String[] AvailableCommands = { "usage", "exit", "copy", "move", "rename", "delete", "list" };

    public AbstractCommand(List<String> args)
    {
        Arguments = (args.size() >= 1) ? args.subList(1, args.size()) : new ArrayList<>();
        Validation = new ValidationStack();
    }

    protected String GetAvailableCommands()
    {
        return String.join(", ", AvailableCommands);
    }

    public abstract void Execute();
}
