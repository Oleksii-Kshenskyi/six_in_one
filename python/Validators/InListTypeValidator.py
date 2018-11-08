from Abstractions.AbstractListValidator import *


class InListTypeValidator(AbstractListValidator):
    def __init__(self, validate_this_list, list_type, message=None):
        super().__init__(validate_this_list, 0, message)
        self._list_type = list_type

    def validate(self):
        if not self._validate_this_list or not isinstance(self._list_type, type):
            self._print_validation_error()
            return False
        elif not all(isinstance(elem, str) for elem in self._validate_this_list):
            self._print_validation_error()
            return False
        else:
            return True
