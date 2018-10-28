from UsageCommand import *


class CommandFactory(object):
    def __init__(self, args):
        self.arguments = []
        self.arguments += args

    def choose_command(self, choice):
        return {
            "exit": ExitCommand(self.arguments),
            "usage": UsageCommand(self.arguments)
        }.get(choice, UsageCommand([]))

    def create(self):
        if self.arguments.__len__() > 0 and not self.arguments[0]:
            return self.choose_command(self.arguments[0])
        else:
            return self.choose_command("usage")
