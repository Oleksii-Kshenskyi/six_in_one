package JavaFileutil.JavaFileCommands;

import JavaFileutil.Validators.NonAbsolutePathValidator;

import java.io.File;
import java.nio.file.Paths;
import java.util.List;

public class RenameCommand extends MoveCommand
{
    private static final String AbsolutePathMessage =
            "For the purpose of moving a file to another folder, please use the 'move' command instead.\n" +
            "Please only use 'rename' to rename your files, not to move them.\n" +
            NotePreface + "The path of destination file can't be absolute. Should be name only.\n" +
            NotePreface + "The operation hasn't been completed. Please use move instead.";

    private static final String UseMoveInsteadNote = "For the purpose of moving a file to another folder, please use the 'move' command instead.";

    public static final String UsageString =
        "rename command renames <file1> to the name specified in <name1>.\n" +
        "Use it the following way:\n" +
        "\t'rename <file1> to <name1>'\n" +
        "\t" + NotePreface + ArgumentCountMismatchMessage + "\n" +
        "\t" + NotePreface + UseMoveInsteadNote;

    private final void SetupValidation()
    {
        Validation.AddValidator(new NonAbsolutePathValidator(Arguments, (short)2, AbsolutePathMessage));
    }

    public RenameCommand(List<String> args)
    {
        super(args);
        SetupValidation();
    }

    @Override
    public void Execute()
    {
        if (!Validation.Validate())
            return;

        Destination = new File(Paths.get(Source.getParentFile().getAbsolutePath(), Destination.getName()).toString());

        super.Execute();
    }
}
