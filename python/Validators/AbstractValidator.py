from abc import ABC, abstractmethod


class AbstractValidator(ABC):
    def __init__(self, message):
        self._message = message

    @staticmethod
    def _error_preface():
        return "ERROR: "

    @abstractmethod
    def validate(self):
        pass
