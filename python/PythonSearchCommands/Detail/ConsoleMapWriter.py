from .AbstractMapWriter import *


class ConsoleMapWriter(AbstractMapWriter):
    def __init__(self, map_to_write):
        super().__init__(map_to_write)

    def write(self):
        print(self._map_to_write)
