from .ExitCommand import *


class UsageCommand(AbstractCommand):
    def __init__(self, args):
        super().__init__(args)

    @classmethod
    def argument_limit_message(cls):
        return "The command takes strictly less than 2 arguments."

    @classmethod
    def usage_string(cls):
        return "usage command displays available commands or the way to use the command in its argument.\n" + \
               "Use it the following way:\n" + \
               "\t'usage' - displays the list of available commands.\n" + \
               "\t'usage <command>' - displays the description and way to use for <command>.\n" + \
               "\t" + cls._note_preface() + cls.argument_limit_message()

    @staticmethod
    def _available_commands():
        return "Available commands: " + ', '.join(["usage", "exit"]) + "."

    @staticmethod
    def _command_unknown_preface():
        return "Usage doesn't know this command."

    @staticmethod
    def _choose_usage(choice):
        return {
            "usage": UsageCommand.usage_string(),
            "exit": ExitCommand.usage_string(),
            "": UsageCommand._available_commands()
        }.get(choice, UsageCommand._command_unknown_preface() + "\n\t" + UsageCommand._available_commands())

    def execute(self):
        print(self._choose_usage(self.arguments[0] if self.arguments.__len__() > 0 else ""))


