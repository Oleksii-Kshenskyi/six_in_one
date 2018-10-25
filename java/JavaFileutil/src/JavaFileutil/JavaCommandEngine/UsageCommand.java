package JavaFileutil.JavaCommandEngine;

import JavaFileutil.AbstractCommands.AbstractCommand;
import JavaFileutil.JavaFileCommands.CopyCommand;
import JavaFileutil.Validators.ArgumentLimitValidator;

import java.util.List;

public class UsageCommand extends AbstractCommand
{
    private static final String ArgumentLimitMessage = "The command takes strictly less than 2 arguments.";
    public static final String UsageString = "usage command displays available commands or the way to use the command in its argument.\n" +
                                             "Use it the following way:\n" +
                                             "\t'usage' - displays the list of available commands.\n" +
                                             "\t'usage <command>' - displays the description and way to use for <command>.\n" +
                                             "\t" + NotePreface + ArgumentLimitMessage;

    private final void SetupValidation()
    {
        Validation.AddValidator(new ArgumentLimitValidator(Arguments, (short)2, ArgumentLimitMessage));
    }

    public UsageCommand(List<String> args)
    {
        super(args);
        SetupValidation();
    }

    @Override
    public void Execute()
    {
        if(!Validation.Validate())
            return;

        if (Arguments == null || Arguments.size() == 0)
            System.out.println("Available commands: " + GetAvailableCommands() + ".");
        else
            switch (Arguments.get(0))
            {
                case "usage":
                    System.out.println(UsageCommand.UsageString);
                    break;
                case "exit":
                    System.out.println(ExitCommand.UsageString);
                    break;
                case "copy":
                    System.out.println(CopyCommand.UsageString);
                    break;
                default:
                    System.out.println("Usage doesn't know this command.");
                    System.out.println("Available commands: " + GetAvailableCommands() + ".");
                    break;
            }
    }
}
