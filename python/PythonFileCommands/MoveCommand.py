from .CopyCommand import *
from shutil import move


class MoveCommand(CopyCommand):
    @classmethod
    def usage_string(cls):
        return "move command moves <file1> to the location specified in <file2>.\n" + \
               "Use it the following way:\n" + \
               "\t'move <file1> to <file2>'\n" + \
               "\t" + cls._note_preface() + cls._argument_count_mismatch_message()

    def __init__(self, args):
        super().__init__(args)

    def execute(self):
        if not self._validation.validate():
            return
        try:
            move(str(self._source), str(self._destination))
        except IOError as ioe:
            print("Move exception.\nError: {}".format(ioe))
