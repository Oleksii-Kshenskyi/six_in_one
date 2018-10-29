from .AbstractValidator import *


class AbstractListValidator(AbstractValidator):
    def __init__(self, validate_this_list, count, message):
        super().__init__(message)
        self._validate_this_list = []
        self._validate_this_list += validate_this_list
        self._count = count

    @abstractmethod
    def validate(self):
        pass
