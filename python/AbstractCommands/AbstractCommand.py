from abc import ABC, abstractmethod


class AbstractCommand(ABC):
    def __init__(self, args):
        self.arguments = []
        self.arguments += args[1:]

    @classmethod
    def _note_preface(cls):
        return str("NOTE: ")

    @abstractmethod
    def execute(self):
        pass

