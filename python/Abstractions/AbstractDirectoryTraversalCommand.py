from .AbstractCommand import *
import os
from Validators.DirectoryExistenceValidator import *


class AbstractDirectoryTraversalCommand(AbstractCommand):
    @staticmethod
    def _dir_doesnt_exist():
        return "directory doesn't exist."

    def __init__(self, args):
        super().__init__(args)
        # self._directory = Path(self.arguments[0]) if self.arguments.__len__() > 0 else Path("")
        # self._dir_traversal_validation()

    def _dir_traversal_validation(self):
        self._validation.add_validator(DirectoryExistenceValidator(str(self._get_directory()), self._dir_doesnt_exist()))

    def traverse(self, topdown=True):
        for (rootname, dirs, files) in os.walk(self._get_directory(), topdown=topdown):
            self._traverse_single(rootname, dirs, files)

    @abstractmethod
    def _traverse_single(self, rootname, dirs, files):
        pass

    @abstractmethod
    def execute(self):
        pass

    @abstractmethod
    def _get_directory(self):
        pass
