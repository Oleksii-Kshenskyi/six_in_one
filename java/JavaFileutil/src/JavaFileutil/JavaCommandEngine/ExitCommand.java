package JavaFileutil.JavaCommandEngine;

import JavaFileutil.AbstractCommands.AbstractCommand;
import java.util.ArrayList;

public class ExitCommand extends AbstractCommand
{
    //private final String NoArgumentsNeededMessage = "ERROR: the exit command does not require any arguments.";
    public static final String UsageString = "exit command exits the application.\n" +
                                             "Use it the following way:\n" +
                                             "\t'exit' - exits the application.";

    @Override
    protected void SetupValidation()
    {
        //Validation.AddValidator(new ArgumentCountValidator(Arguments, 0, NoArgumentsNeededMessage));
    }

    public ExitCommand(ArrayList<String> args)
    {
        super(args);

    }

    @Override
    public void Execute()
    {
        System.exit(0);
    }
}
