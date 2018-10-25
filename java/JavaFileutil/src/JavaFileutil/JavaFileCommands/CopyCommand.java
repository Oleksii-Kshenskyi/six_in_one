package JavaFileutil.JavaFileCommands;

import JavaFileutil.AbstractCommands.AbstractBinaryFileCommand;

import java.nio.file.Files;
import java.util.List;

public class CopyCommand extends AbstractBinaryFileCommand
{
    public static final String UsageString =
            "copy command copies <file1> to the location specified in <file2>.\n" +
            "Use it the following way:\n" +
            "\t'copy <file1> to <file2>'\n" +
            "\t" + NotePreface + ArgumentCountMismatchMessage;

    public CopyCommand(List<String> args)
    {
        super(args);
    }

    @Override
    public void Execute()
    {
        if(!Validation.Validate())
            return;

        try
        {
            Files.copy(Source.toPath(), Destination.toPath());
        }
        catch(Exception e)
        {
            System.out.format("Copy exception.\nError message: %s.", e.getMessage());
        }
    }
}
