from AbstractCommand import *


class ExitCommand(AbstractCommand):
    def __init__(self, args):
        super().__init__(args)

    @classmethod
    def usage_string(cls):
        return "exit command exits the application.\n" + \
               "Use it the following way:\n" + \
               "\t'exit' - exits the application."

    def execute(self):
        exit(0)
