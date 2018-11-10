from PythonCommandEngine.CommandFactory import *


class CommandInterpreter(object):
    @classmethod
    def run_event_loop(cls):
        while True:
            choice = input("===> ")
            arguments = list(filter(None, choice.split(" ")))
            CommandFactory(arguments).create()(arguments).execute()

    @classmethod
    def run(cls):
        print("Welcome to the file utility command interpreter!")
        print("Author: Oleksii <DarkSpectre> Kshenskyi.")
        CommandFactory(["usage"]).create()(["usage"]).execute()
        print("Type 'usage <command>' to learn about the <command> you're interested in.")
        cls.run_event_loop()
