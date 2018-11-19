from .AbstractCommand import *
from Validators.DirectoryNonExistenceValidator import *
from Validators.FileExistenceValidator import *
from Validators.ArgumentCountValidator import *
from Validators.ArgumentValueValidator import *
import os


class AbstractBinaryFileCommand(AbstractCommand):
    @staticmethod
    def _argument_count_mismatch_message():
        return "the command takes EXACTLY 3 arguments in the order specified in its 'usage'!"

    @staticmethod
    def _first_arg_is_dir_message():
        return "first argument has to be a valid file name, not a directory name!"

    @staticmethod
    def _first_arg_doesnt_exist():
        return "the file at the first argument doesn't exist!"

    @staticmethod
    def _stick_to_syntax_message():
        return "please use this specific syntax: <file_command> <file1> to <file_or_dir2>"

    def __init__(self, args):
        super().__init__(args)
        self._binary_validation()
        self._source = Path(self.arguments[0]
                            if len(self.arguments) > 0
                            else "")
        self._destination = Path(self.arguments[2]
                                 if len(self.arguments) >= 3
                                 else "")
        # if self._destination.exists() and self._destination.is_dir():
        #     print("SOURCE NAME: {}".format(self._source.name))
        #     self._destination = Path(os.path.join(self._destination, self._source.name))

    def _binary_validation(self):
        self._validation.add_validator(ArgumentCountValidator(self.arguments,
                                                              3,
                                                              self._argument_count_mismatch_message()))
        self._validation.add_validator(DirectoryNonExistenceValidator(self.arguments[0]
                                                                      if len(self.arguments) > 0
                                                                      else "",
                                                                      self._first_arg_is_dir_message()))
        self._validation.add_validator(FileExistenceValidator(self.arguments[0]
                                                              if len(self.arguments) > 0
                                                              else "",
                                                              self._first_arg_doesnt_exist()))
        self._validation.add_validator(ArgumentValueValidator(self.arguments[1]
                                                              if len(self.arguments) >= 1
                                                              else "",
                                                              "to",
                                                              self._stick_to_syntax_message()))

    @abstractmethod
    def execute(self):
        pass
