from Abstractions.AbstractListValidator import *


class ArgumentCountValidator(AbstractListValidator):
    def __init__(self, validate_this_list, count, message):
        super().__init__(validate_this_list, count, message)

    def validate(self):
        if self._validate_this_list.__len__() != self._count:
            self._print_validation_error()
            return False
        else:
            return True
