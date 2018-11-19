from Abstractions.AbstractBinaryFileCommand import *
from shutil import copy


class CopyCommand(AbstractBinaryFileCommand):
    @classmethod
    def usage_string(cls):
        return "copy command copies <file1> to the location specified in <file2>.\n" + \
               "Use it the following way:\n" + \
               "\t'copy <file1> to <file2>'\n" + \
               "\t" + cls._note_preface() + cls._argument_count_mismatch_message()

    def __init__(self, args):
        super().__init__(args)

    def execute(self):
        if not self._validation.validate():
            return
        try:
            copy(self._source, self._destination)
        except IOError as ioe:
            print("Copy exception.\nError: {}".format(ioe))

