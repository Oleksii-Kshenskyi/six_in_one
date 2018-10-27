package JavaFileutil.JavaFileCommands;

import JavaFileutil.AbstractCommands.AbstractUnaryDirectoryCommand;

import java.io.File;
import java.util.List;

public class ListDirectoryCommand extends AbstractUnaryDirectoryCommand
{
    public static final String UsageString = "list command lists all the contents of <directory1>.\n" +
        "Use it the following way:\n" +
        "\t'list <directory1>'\n" +
        "\tOutput is of the following format:\n" +
        "\t'=[F|D] <[file|directory]_name> [(<file_size>)]'\n" +
        "\twhere [F|D] shows if it is a file or a directory.\n" +
        "\t" + NotePreface + ArgumentCountMismatchMessage;

    public ListDirectoryCommand(List<String> args)
    {
        super(args);
    }

    private String GetSize(String filename)
    {
        double rawSize = new File(filename).length();

        return (rawSize >= 0 && rawSize < 1024) ? String.format("%.3fB", rawSize) :
               (rawSize >= 1024 && rawSize < 1024 * 1024) ? String.format("%.3fKB", rawSize / 1024) :
               (rawSize >= 1024 * 1024) ? String.format("%.3fMB", rawSize / (1024 * 1024)) : "";
    }

    private void ListDirectories()
    {
        if (directories != null)
            for (var item : directories)
                System.out.format("=D %s\n", item);
    }

    private void ListFiles()
    {
        if (files != null)
            for (var item : files)
                System.out.format("-F %s (%s)\n", item, GetSize(item));
    }

    private void CountEntities()
    {
        var dircount = directories != null ? directories.size() : 0;
        var filescount = files != null ? files.size() : 0;
        System.out.format("======\n=TOTAL ITEMS: %d.\n", dircount + filescount);
    }

    @Override
    public void Execute()
    {
        if(!Validation.Validate())
            return;

        ListDirectories();
        ListFiles();

        CountEntities();
    }
}
