from .AbstractCommand import *
from pathlib import Path
import os


class AbstractDirectoryTraversalCommand(AbstractCommand):
    def __init__(self, args):
        super().__init__(args)
        self._directory = Path(self.arguments[0]) if self.arguments.__len__() > 0 else Path("")

    def traverse(self, topdown=True):
        for (rootname, dirs, files) in os.walk(self._directory, topdown=topdown):
            self._traverse_single(rootname, dirs, files)

    @abstractmethod
    def _traverse_single(self, rootname, dirs, files):
        pass

    @abstractmethod
    def execute(self):
        pass
