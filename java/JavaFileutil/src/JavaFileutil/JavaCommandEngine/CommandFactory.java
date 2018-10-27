package JavaFileutil.JavaCommandEngine;

import java.util.List;
import java.util.ArrayList;
import JavaFileutil.AbstractCommands.AbstractCommand;
import JavaFileutil.JavaFileCommands.*;

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
                    return new ExitCommand(Arguments);
                case "usage":
                    return new UsageCommand(Arguments);
                case "copy":
                    return new CopyCommand(Arguments);
                case "move":
                    return new MoveCommand(Arguments);
                case "rename":
                    return new RenameCommand(Arguments);
                case "delete":
                    return new DeleteCommand(Arguments);
                case "list":
                    return new ListDirectoryCommand(Arguments);
                default:
                    System.out.print("Command not found.\n\t");
                    return new UsageCommand(Arguments);
            }
        }
        else
            return new UsageCommand(new ArrayList<>());
    }
}
