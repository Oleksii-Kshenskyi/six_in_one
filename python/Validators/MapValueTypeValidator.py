from .MapValueExistenceValidator import *


class MapValueTypeValidator(MapValueExistenceValidator):
    def __init__(self, validate_this_map, key, value_type, existence_message=None, type_message=None):
        super().__init__(validate_this_map, key, existence_message)
        self._type_message = type_message
        self._value_type = value_type

    def validate(self):
        if not super().validate():
            return False
        if not isinstance(self._validate_this_map[self._key], self._value_type):
            if self._type_message:
                self._error_format_static(self._type_message,
                                          self._key,
                                          str(type(self._validate_this_map[self._key])),
                                          self._value_type)
            return False
        else:
            return True
