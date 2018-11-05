from abc import ABC, abstractmethod


class AbstractValidator(ABC):
    def __init__(self, message=None):
        self._message = message

    @staticmethod
    def _error_preface():
        return "ERROR: "

    def _print_validation_error(self):
        if self._message:
            print(self._error_preface() + self._message)

    def _error_string(self):
        return self._error_preface() + self._message

    @abstractmethod
    def validate(self):
        pass
