from .ExitCommand import *
from Validators.ArgumentLimitValidator import *


class UsageCommand(AbstractCommand):
    def __init__(self, args):
        super().__init__(args)
        self._setup_validation()

    @classmethod
    def _argument_limit_message(cls):
        return "The command takes strictly less than 2 arguments."

    @classmethod
    def usage_string(cls):
        return "usage command displays available commands or the way to use the command in its argument.\n" + \
               "Use it the following way:\n" + \
               "\t'usage' - displays the list of available commands.\n" + \
               "\t'usage <command>' - displays the description and way to use for <command>.\n" + \
               "\t" + cls._note_preface() + cls._argument_limit_message()

    @staticmethod
    def _available_commands():
        return "Available commands: " + ', '.join(["usage", "exit", "delete"]) + "."

    @staticmethod
    def _command_unknown_preface():
        return "Usage doesn't know this command."

    def _setup_validation(self):
        self._validation.add_validator(ArgumentLimitValidator(self.arguments, 2, self._argument_limit_message()))

    @staticmethod
    def _choose_usage(choice):
        return {
            "usage": UsageCommand.usage_string(),
            "exit": ExitCommand.usage_string(),
            "": UsageCommand._available_commands()
        }.get(choice, UsageCommand._command_unknown_preface() + "\n\t" + UsageCommand._available_commands())

    def execute(self):
        if not self._validation.validate():
            return
        print(self._choose_usage(self.arguments[0] if self.arguments.__len__() > 0 else ""))


