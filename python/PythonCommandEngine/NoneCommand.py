from .UsageCommand import *


class NoneCommand(AbstractCommand):
    def __init__(self, args):
        super().__init__(args)

    def execute(self):
        print("Command not found.\n\t", sep='', end='', flush=True)
        UsageCommand([]).execute()
