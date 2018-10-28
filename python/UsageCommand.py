from ExitCommand import *


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
    def choose_usage(choice):
        return {
            "usage": UsageCommand.usage_string(),
            "exit": ExitCommand.usage_string()
        }.get(choice, UsageCommand.usage_string())

    def execute(self):
        print(self.choose_usage(self.arguments[0]))


