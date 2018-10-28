from UsageCommand import *


class NoneCommand(AbstractCommand):
    def __init__(self):
        super().__init__([])

    def execute(self):
        print("Command not found.\n\t", sep='', end='', flush=True)
        UsageCommand([]).execute()
