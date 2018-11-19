from .AbsolutePathValidator import *


class NonAbsolutePathValidator(AbsolutePathValidator):
    def __init__(self, validate_this_path, message):
        super().__init__(validate_this_path, message)

    def validate(self):
        if self._validate_this.is_absolute():
            self._print_validation_error()
            return False
        return True
