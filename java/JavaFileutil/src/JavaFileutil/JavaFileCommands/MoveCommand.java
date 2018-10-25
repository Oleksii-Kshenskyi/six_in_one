package JavaFileutil.JavaFileCommands;

import JavaFileutil.AbstractCommands.AbstractBinaryFileCommand;

import java.nio.file.Files;
import java.util.List;

public class MoveCommand extends AbstractBinaryFileCommand
{
    public static final String UsageString =
        "move command moves <file1> to the location specified in <file2>.\n" +
        "Use it the following way:\n" +
        "\t'move <file1> to <file2>'\n" +
        "\t" + NotePreface + ArgumentCountMismatchMessage;

    public MoveCommand(List<String> args)
    {
        super(args);
    }

    @Override
    public void Execute()
    {
        if (!Validation.Validate())
            return;

        try
        {
            Files.move(Source.toPath(), Destination.toPath());
        }
        catch (Exception e)
        {
            System.out.format("Move exception.\nError message: %s.", e.getMessage());
        }
    }
}