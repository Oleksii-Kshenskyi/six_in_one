package JavaFileutil.AbstractCommands;

import JavaFileutil.Validators.ArgumentExistenceValidator;
import JavaFileutil.Validators.DirectoryNonExistenceValidator;
import JavaFileutil.Validators.FileExistenceValidator;
import java.io.File;

import java.util.List;

public abstract class AbstractFileCommand extends AbstractCommand
{
    private final String NoArgumentsMessage = "A file command requires arguments to be executed.\n" +
                                              "Type 'usage <command>' to get help for the <command> of your choice.";
    private final String DirectoryInsteadOfFileMessage = "Source file is a directory name.\n" +
                                                         "Please use the command for files instead of directories.";
    private final String FileDoesNotExistMessage = "The source file does not exist.";

    @Override
    protected void SetupValidation()
    {
        Validation.AddValidator(new ArgumentExistenceValidator(Arguments, (short)0, NoArgumentsMessage));
        Validation.AddValidator(new DirectoryNonExistenceValidator(Arguments, (short)0, DirectoryInsteadOfFileMessage));
        Validation.AddValidator(new FileExistenceValidator(Arguments, (short)0, FileDoesNotExistMessage));
    }

    public AbstractFileCommand(List<String> args)
    {
        super(args);
    }
}
