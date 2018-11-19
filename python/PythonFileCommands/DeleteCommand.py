from Abstractions.AbstractUnaryFileCommand import *
from Validators.FileExistenceValidator import *


class DeleteCommand(AbstractUnaryFileCommand):
    @staticmethod
    def _file_existence_message():
        return "the file doesn't exist."

    @classmethod
    def usage_string(cls):
        return "delete command deletes <file1>.\n" + \
               "Use it the following way:\n" + \
               "\t'delete <file1>'\n" + \
               "\t" + cls._note_preface() + cls._argument_count_mismatch_message()

    def __init__(self, args):
        super().__init__(args)
        self._delete_validation()

    def _delete_validation(self):
        self._validation.add_validator(FileExistenceValidator(self._file, self._file_existence_message()))

    def execute(self):
        if not self._validation.validate():
            return
        try:
            self._file.unlink()
        except Exception as err:
            print("Delete exception.\nError message: {0}".format(err))



