from Abstractions.AbstractFilesystemEntryValidator import *


class AbsolutePathValidator(AbstractFilesystemEntryValidator):
    def __init__(self, validate_this_path, message):
        super().__init__(validate_this_path, message)

    def validate(self):
        if not self._validate_this.is_absolute():
            self._print_validation_error()
            return False
        return True
