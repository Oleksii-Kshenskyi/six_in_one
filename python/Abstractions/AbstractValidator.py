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

    def _error_format(self, *args):
        if self._message:
            print(self._error_preface() + self._message.format(*args))

    @classmethod
    def _error_format_static(cls, error_string, *args):
        if error_string:
            print(cls._error_preface() + error_string.format(*args))

    @abstractmethod
    def validate(self):
        pass
