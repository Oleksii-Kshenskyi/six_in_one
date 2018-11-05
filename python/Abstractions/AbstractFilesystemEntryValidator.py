from Abstractions.AbstractValueValidator import *
from pathlib import Path


class AbstractFilesystemEntryValidator(AbstractValueValidator):
    def __init__(self, validate_this_file, message):
        super().__init__(validate_this_file, message)
        self._validate_this = Path(validate_this_file)

    @abstractmethod
    def validate(self):
        pass
