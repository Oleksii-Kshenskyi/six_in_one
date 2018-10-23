package JavaFileutil.JavaCommandEngine;

import JavaFileutil.AbstractCommands.AbstractCommand;
import JavaFileutil.Validators.ArgumentCountValidator;
import java.util.List;


public class ExitCommand extends AbstractCommand
{
    private final String NoArgumentsNeededMessage = "the exit command does not require any arguments.";
    public static final String UsageString = "exit command exits the application.\n" +
                                             "Use it the following way:\n" +
                                             "\t'exit' - exits the application.";

    @Override
    protected void SetupValidation()
    {
        Validation.AddValidator(new ArgumentCountValidator(Arguments, (short)0, NoArgumentsNeededMessage));
    }

    public ExitCommand(List<String> args)
    {
        super(args);
        SetupValidation();
    }

    @Override
    public void Execute()
    {
        if(!Validation.Validate())
            return;

        System.exit(0);
    }
}
