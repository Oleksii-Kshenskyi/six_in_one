from .AbstractListValidator import *


class ArgumentLimitValidator(AbstractListValidator):
    def __init__(self, validate_this_list, count, message):
        super().__init__(validate_this_list, count, message)

    def validate(self):
        if self._validate_this_list.__len__() >= self._count:
            print(self._error_preface() + self._message)
            return False
        else:
            return True
