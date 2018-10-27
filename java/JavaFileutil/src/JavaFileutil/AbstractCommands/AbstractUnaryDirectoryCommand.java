package JavaFileutil.AbstractCommands;

import JavaFileutil.Validators.ArgumentCountValidator;
import JavaFileutil.Validators.DirectoryExistenceValidator;

import java.io.File;
import java.util.ArrayList;
import java.util.List;

public abstract class AbstractUnaryDirectoryCommand extends AbstractCommand
{
    private static final String StickToSyntaxMessage = "the argument has to be the name of the directory.";

    protected static final String ArgumentCountMismatchMessage = "the command takes EXACTLY 1 argument!";
    protected List<String> files;
    protected List<String> directories;


    private final void SetupValidation()
    {
        Validation.AddValidator(new ArgumentCountValidator(Arguments, (short)1, ArgumentCountMismatchMessage));
        Validation.AddValidator(new DirectoryExistenceValidator(Arguments, (short)0, StickToSyntaxMessage));
    }

    public AbstractUnaryDirectoryCommand(List<String> args)
    {
        super(args);
        SetupValidation();

        File maybeDirectory = new File((Arguments.size() >= 1) ? Arguments.get(0) : "");
        files = new ArrayList<>();
        directories = new ArrayList<>();

        if (Arguments.size() == 1 && maybeDirectory.exists() && maybeDirectory.isDirectory())
        {
            for(var item : maybeDirectory.listFiles())
            {
                if(item.isFile())
                    files.add(item.getAbsolutePath());
                else if(item.isDirectory())
                    directories.add(item.getAbsolutePath());
            }
        }
        else
        {
            directories = null;
            files = null;
        }
    }
}