from Abstractions.AbstractValidator import *


class MapValueExistenceValidator(AbstractValidator):
    def __init__(self, validate_this_map, key, message):
        super().__init__(message)
        self._validate_this_map = validate_this_map
        self._key = key

    def validate(self):
        if self._key not in self._validate_this_map.keys():
            if self._message:
                print(self._error_string().format(self._key))
            return False
        return True
