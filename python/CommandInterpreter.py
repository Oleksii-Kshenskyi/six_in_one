from CommandFactory import *


class CommandInterpreter(object):

    # def __init__(self):
    #    pass

    @classmethod
    def run_event_loop(cls):
        while True:
            choice = input("===> ")
            arguments = choice.splitlines(False)
            CommandFactory(arguments).create().execute()

    @classmethod
    def run(cls):
        print("Welcome to the file utility command interpreter!")
        print("Author: Oleksii <DarkSpectre> Kshenskyi.")
        CommandFactory(["usage"]).create().execute()
        print("Type 'usage <command>' to learn about the <command> you're interested in.");
        cls.run_event_loop()
