package JavaFileutil.JavaCommandEngine;

import java.util.List;
import java.util.ArrayList;
import JavaFileutil.AbstractCommands.AbstractCommand;
import JavaFileutil.JavaFileCommands.CopyCommand;
import JavaFileutil.JavaFileCommands.MoveCommand;
import JavaFileutil.JavaFileCommands.RenameCommand;

public class CommandFactory
{
    private List<String> Arguments;

    public CommandFactory(List<String> args)
    {
        Arguments = args;
    }

    public AbstractCommand Create()
    {
        if (Arguments.size() > 0 && !Arguments.get(0).isEmpty())
        {
            switch (Arguments.get(0))
            {
                case "exit":
                    return new ExitCommand(Arguments.subList(1, Arguments.size()));
                case "usage":
                    return new UsageCommand(Arguments.subList(1, Arguments.size()));
                case "copy":
                    return new CopyCommand(Arguments.subList(1, Arguments.size()));
                case "move":
                    return new MoveCommand(Arguments.subList(1, Arguments.size()));
                case "rename":
                    return new RenameCommand(Arguments.subList(1, Arguments.size()));
                default:
                    System.out.print("Command not found.\n\t");
                    return new UsageCommand(Arguments.subList(1, Arguments.size()));
            }
        }
        else
            return new UsageCommand(new ArrayList());
    }
}
