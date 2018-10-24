package JavaFileutil.JavaFileCommands;

import JavaFileutil.AbstractCommands.AbstractBinaryFileCommand;

import java.nio.file.Files;
import java.util.List;

public class CopyCommand extends AbstractBinaryFileCommand
{
    private static final String ArgumentLimitMessage = "the command takes EXACTLY 3 arguments, EXACTLY in the specified order!";
    public static final String UsageString = "usage command displays available commands or the way to use the command in its argument.\n" +
            "Use it the following way:\n" +
            "\t'usage' - displays the list of available commands.\n" +
            "\t'usage <command>' - displays the description and way to use for <command>.\n" +
            "\t" + NotePreface + ArgumentLimitMessage;

    public CopyCommand(List<String> args)
    {
        super(args);
        SetupValidation();
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
