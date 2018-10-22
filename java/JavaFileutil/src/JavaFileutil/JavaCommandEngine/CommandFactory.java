package JavaFileutil.JavaCommandEngine;

import java.util.ArrayList;
import JavaFileutil.AbstractCommands.AbstractCommand;

public class CommandFactory
{
    private ArrayList<String> Arguments;

    public CommandFactory(ArrayList<String> args)
    {
        Arguments = args;
    }

    public AbstractCommand Create()
    {
        if (Arguments.size() > 0)
            switch (Arguments.get(0))
            {
                case "exit":
                    return new ExitCommand(new ArrayList(Arguments.subList(1, Arguments.size())));
                case "usage":
                    return new UsageCommand(new ArrayList(Arguments.subList(1, Arguments.size())));
                default:
                    System.out.print("Command not found.\n\t");
                    return new UsageCommand(new ArrayList(Arguments.subList(1, Arguments.size())));
            }
        else
            return new UsageCommand(new ArrayList());
    }
}
