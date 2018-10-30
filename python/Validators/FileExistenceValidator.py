from .AbstractFilesystemEntryValidator import *


class FileExistenceValidator(AbstractFilesystemEntryValidator):
    def __init__(self, validate_this_file, message):
        super().__init__(validate_this_file, message)

    def validate(self):
        if not self._validate_this.exists() or not self._validate_this.is_file():
            print(self._error_preface() + self._message)
            return False
        return True
