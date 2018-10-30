from .AbstractCommand import *
from Validators.ArgumentCountValidator import *
from pathlib import Path


class AbstractUnaryFileCommand(AbstractCommand):
    @staticmethod
    def _argument_count_mismatch_message():
        return "the command takes EXACTLY 1 argument!"

    def _setup_validation(self):
        self._validation.add_validator(ArgumentCountValidator(self.arguments, 1, self._argument_count_mismatch_message()))

    def __init__(self, args):
        super().__init__(args)
        self._setup_validation()
        self._file = Path(self.arguments[0]) if self.arguments.__len__() > 0 else Path("")

    @abstractmethod
    def execute(self):
        pass

