from .NoneCommand import *
from PythonFileCommands.DeleteCommand import *
from PythonSearchCommands.ListCommand import *
from PythonSearchCommands.LookupCommand import *


class CommandFactory(object):
    def __init__(self, args):
        self.arguments = []
        self.arguments += args

    @staticmethod
    def choose_command(choice):
        return {
            "exit": ExitCommand,
            "usage": UsageCommand,
            "delete": DeleteCommand,
            "list": ListCommand,
            "lookup": LookupCommand
        }.get(choice, NoneCommand)

    def create(self):
        if self.arguments.__len__() > 0:
            return self.choose_command(self.arguments[0])
        else:
            return UsageCommand
