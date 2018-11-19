from .AbstractCommand import *
from Validators.ArgumentCountValidator import *
from Validators.DirectoryNonExistenceValidator import *
from pathlib import Path


class AbstractUnaryFileCommand(AbstractCommand):
    @staticmethod
    def _argument_count_mismatch_message():
        return "the command takes EXACTLY 1 argument!"

    @staticmethod
    def _argument_is_folder_message():
        return "this is a file command, the argument can't be a folder!"

    def _unary_validation(self):
        self._validation.add_validator(DirectoryNonExistenceValidator(self._file, self._argument_is_folder_message()))
        self._validation.add_validator(ArgumentCountValidator(self.arguments, 1, self._argument_count_mismatch_message()))

    def __init__(self, args):
        super().__init__(args)
        self._file = Path(self.arguments[0]) if self.arguments.__len__() > 0 else Path("")
        self._unary_validation()

    @abstractmethod
    def execute(self):
        pass

