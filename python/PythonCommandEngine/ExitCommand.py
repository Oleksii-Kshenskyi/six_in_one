from AbstractCommands.AbstractCommand import *
from Validators.ArgumentCountValidator import *


class ExitCommand(AbstractCommand):
    def __init__(self, args):
        super().__init__(args)
        self._exit_validation()

    @classmethod
    def usage_string(cls):
        return "exit command exits the application.\n" + \
               "Use it the following way:\n" + \
               "\t'exit' - exits the application."

    @staticmethod
    def _no_arguments_needed_message():
        return "the exit command does not require any arguments."

    def _exit_validation(self):
        self._validation.add_validator(ArgumentCountValidator(self.arguments, 0, self._no_arguments_needed_message()))

    def execute(self):
        if not self._validation.validate():
            return
        exit(0)
