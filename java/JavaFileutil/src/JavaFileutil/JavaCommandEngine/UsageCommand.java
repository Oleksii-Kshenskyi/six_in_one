package JavaFileutil.JavaCommandEngine;

import JavaFileutil.AbstractCommands.AbstractCommand;
import java.util.List;

public class UsageCommand extends AbstractCommand
{
    public static final String UsageString = "usage command displays available commands or the way to use the command in its argument.\n" +
                                             "Use it the following way:\n" +
                                             "\t'usage' - displays the list of available commands.\n" +
                                             "\t'usage <command>' - displays the description and way to use for <command>.";

    @Override
    protected void SetupValidation()
    {
    }

    public UsageCommand(List<String> args)
    {
        super(args);
    }

    @Override
    public void Execute()
    {
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
                default:
                    System.out.println("Usage doesn't know this command.");
                    System.out.println("Available commands: " + GetAvailableCommands() + ".");
                    break;
            }
    }
}
