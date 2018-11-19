from Abstractions.AbstractBinaryFileCommand import *
from shutil import copy
from Validators.AbsolutePathValidator import *
from Validators.DirectoryExistenceValidator import *


class CopyCommand(AbstractBinaryFileCommand):
    @staticmethod
    def _destination_must_be_absolute_message():
        return "the path of the destination file has to be absolute (either a file or a directory)"

    @staticmethod
    def _dest_parent_doesnt_exist():
        return "the destination file has to be located in a valid directory!"

    @classmethod
    def usage_string(cls):
        return "copy command copies <file1> to the location specified in <file2>.\n" + \
               "Use it the following way:\n" + \
               "\t'copy <file1> to <file_or_dir2>'\n" + \
               "\t" + cls._note_preface() + cls._argument_count_mismatch_message()

    def _copy_validation(self):
        self._validation.add_validator(AbsolutePathValidator(self.arguments[2]
                                                             if len(self.arguments) >= 3
                                                             else "",
                                                             self._destination_must_be_absolute_message()))
        self._validation.add_validator(DirectoryExistenceValidator(Path(self.arguments[2]).parent
                                                                   if len(self.arguments) >= 3
                                                                   else "",
                                                                   self._dest_parent_doesnt_exist()))

    def __init__(self, args):
        super().__init__(args)
        self._copy_validation()

    def execute(self):
        if not self._validation.validate():
            return
        try:
            copy(self._source, self._destination)
        except IOError as ioe:
            print("Copy exception.\nError: {}".format(ioe))

