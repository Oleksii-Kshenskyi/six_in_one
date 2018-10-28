from abc import ABC, abstractmethod


class AbstractCommand(ABC):
    def __init__(self, args):
        self.arguments = []
        self.arguments += args[1:]

    @classmethod
    def _note_preface(cls):
        return str("NOTE: ")

    @property
    def _available_commands(self):
        return ["usage", "exit"]

    @abstractmethod
    def execute(self):
        pass

