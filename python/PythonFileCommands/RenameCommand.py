from Abstractions.AbstractBinaryFileCommand import *
from Validators.NonAbsolutePathValidator import *
from shutil import move


class RenameCommand(AbstractBinaryFileCommand):
    @classmethod
    def _absolute_path_message(cls):
        return "For the purpose of moving a file to another folder, please use the 'move' command instead.\n" + \
            "Please only use 'rename' to rename your files, not to move them.\n" + \
            cls._note_preface() + "The path of a destination file can't be absolute. Should be name only.\n" + \
            cls._note_preface() + "The operation hasn't been completed. Please use move instead."

    @classmethod
    def usage_string(cls):
        return "rename command renames <file1> to the name specified in <name1>.\n" + \
               "Use it the following way:\n" + \
               "\t'rename <file1> to <name1>'\n" + \
               "\t" + cls._note_preface() + cls._argument_count_mismatch_message() + "\n" + \
               "\t" + cls._note_preface() + "for the purpose of moving a file to another folder, " + \
                                            "please use the 'move' command instead."

    def __init__(self, args):
        super().__init__(args)
        self._rename_validation()

    def _rename_validation(self):
        self._validation.add_validator(NonAbsolutePathValidator(self.arguments[2]
                                                                if len(self.arguments) >= 3
                                                                else "",
                                                                self._absolute_path_message()))

    def execute(self):
        if not self._validation.validate():
            return
        self._destination = os.path.join(self._source.parent, self._destination)
        try:
            move(str(self._source), str(self._destination))
        except IOError as ioe:
            print("Rename exception.\nError: {}".format(ioe))
