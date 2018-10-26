package JavaFileutil.JavaFileCommands;

import JavaFileutil.AbstractCommands.AbstractUnaryFileCommand;
import JavaFileutil.Validators.FileExistenceValidator;

import java.util.List;

public class DeleteCommand extends AbstractUnaryFileCommand
{
    private static final String FileExistenceMessage = "cannot delete the file that doesn't exist.";
    public static final String UsageString =
        "delete command deletes <file1>.\n" +
        "Use it the following way:\n" +
        "\t'delete <file1>'\n" +
        "\t" + NotePreface + ArgumentCountMismatchMessage;

    private final void SetupValidation()
    {
        Validation.AddValidator(new FileExistenceValidator(Arguments, (short)0, FileExistenceMessage));
    }

    public DeleteCommand(List<String> args)
    {
        super(args);
        SetupValidation();
    }

    @Override
    public void Execute()
    {
        if (!Validation.Validate())
            return;

        try
        {
            file.delete();
        }
        catch (Exception e)
        {
            System.out.format("Delete exception.\nError message: %s.", e.getMessage());
        }
    }
}
