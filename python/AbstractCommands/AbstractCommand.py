from abc import ABC, abstractmethod
from Validators.ValidatorStack import *


class AbstractCommand(ABC):
    def __init__(self, args):
        self.arguments = []
        self.arguments += args[1:]
        self._validation = ValidatorStack()

    @classmethod
    def _note_preface(cls):
        return str("NOTE: ")

    @abstractmethod
    def execute(self):
        pass

