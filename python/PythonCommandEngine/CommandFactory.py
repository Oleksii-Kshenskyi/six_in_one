from .NoneCommand import *
from PythonFileCommands.DeleteCommand import *
from PythonSearchCommands.ListCommand import *
from PythonSearchCommands.LookupCommand import *


class CommandFactory(object):
    def __init__(self, args):
        self.arguments = []
        self.arguments += args

    def choose_command(self, choice):
        return {
            "exit": ExitCommand(self.arguments),
            "usage": UsageCommand(self.arguments),
            "delete": DeleteCommand(self.arguments),
            "list": ListCommand(self.arguments),
            "lookup": LookupCommand(self.arguments)
        }.get(choice, NoneCommand())

    def create(self):
        if self.arguments.__len__() > 0:
            return self.choose_command(self.arguments[0])
        else:
            return UsageCommand([])
