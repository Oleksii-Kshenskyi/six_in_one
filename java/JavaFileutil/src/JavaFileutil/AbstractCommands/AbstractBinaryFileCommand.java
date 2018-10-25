package JavaFileutil.AbstractCommands;

import JavaFileutil.Validators.ArgumentCountValidator;
import JavaFileutil.Validators.ArgumentValueValidator;

import java.io.File;
import java.util.List;
import java.nio.file.Paths;

public abstract class AbstractBinaryFileCommand extends AbstractFileCommand
{
    private final String ArgumentCountMismatchMessage = "the command takes EXACTLY 3 arguments, EXACTLY in the specified order!";
    private final String StickToSyntaxMessage = "Please follow the syntax: '<file_command> <file1> to <file2>'.";

    protected File Source;
    protected File Destination;

    private final void SetupValidation()
    {
        Validation.AddValidator(new ArgumentCountValidator(Arguments, (short)3, ArgumentCountMismatchMessage));
        Validation.AddValidator(new ArgumentValueValidator(Arguments, (short)1, "to", StickToSyntaxMessage));
    }

    public AbstractBinaryFileCommand(List<String> args)
    {
        super(args);
        SetupValidation();

        Source = (Arguments.size() >= 1 && !Arguments.get(2).isEmpty())? new File(Arguments.get(0)) : null;
        Destination = (Arguments.size() >= 3 && !Arguments.get(2).isEmpty()) ? new File(Arguments.get(2)) : null;

        if (Destination != null && Destination.exists() && Destination.isDirectory())
            Destination = new File(Paths.get(Destination.getAbsolutePath(), Source.getPath()).toString());
    }
}
