from Abstractions.AbstractValueValidator import *


class ArgumentValueValidator(AbstractValueValidator):
    def __init__(self, validate_this, equals_to, message):
        super().__init__(validate_this, message)
        self._equals_to = equals_to

    def validate(self):
        if self._validate_this != self._equals_to:
            self._print_validation_error()
            return False
        return True
