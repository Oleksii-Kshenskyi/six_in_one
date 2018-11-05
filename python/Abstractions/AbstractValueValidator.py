from Abstractions.AbstractValidator import *


class AbstractValueValidator(AbstractValidator):
    def __init__(self, validate_this, message):
        super().__init__(message)
        self._validate_this = validate_this

    @abstractmethod
    def validate(self):
        pass
