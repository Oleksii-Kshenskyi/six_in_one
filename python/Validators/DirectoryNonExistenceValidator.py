from Abstractions.AbstractFilesystemEntryValidator import *


class DirectoryNonExistenceValidator(AbstractFilesystemEntryValidator):
    def __init__(self, validate_this_dir, message):
        super().__init__(validate_this_dir, message)

    def validate(self):
        if self._validate_this.exists() and self._validate_this.is_dir():
            self._print_validation_error()
            return False
        return True
