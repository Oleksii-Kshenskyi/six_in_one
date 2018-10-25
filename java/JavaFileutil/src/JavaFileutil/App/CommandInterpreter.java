package JavaFileutil.App;

import java.util.Arrays;
import java.util.Scanner;
import java.util.ArrayList;
import java.util.List;
import JavaFileutil.JavaCommandEngine.CommandFactory;

public class CommandInterpreter
{
    private void runEventLoop()
    {
        while (true)
        {
            System.out.print("===> ");
            Scanner scanner = new Scanner(System.in);
            String choice = scanner.nextLine();
            List<String> arguments = new ArrayList<>(Arrays.asList(choice.split("\\s+")));
            arguments.remove("");
            new CommandFactory(arguments).Create().Execute();
        }
    }

    public CommandInterpreter()
    {
    }

    public void run()
    {
        System.out.println("Welcome to the file utility command interpreter!");
        System.out.println("Author: Oleksii <DarkSpectre> Kshenskyi.");
        new CommandFactory(new ArrayList<>(Arrays.asList("usage"))).Create().Execute();
        System.out.println("Type 'usage <command>' to learn about the <command> you're interested in.");
        runEventLoop();
    }
}
