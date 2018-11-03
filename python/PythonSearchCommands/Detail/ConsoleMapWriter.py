from .AbstractMapWriter import *


class ConsoleMapWriter(AbstractMapWriter):
    def __init__(self, map_to_write):
        super().__init__(map_to_write)

    def write(self):
        for key in self._map_to_write.keys():
            print(">> Results for query '", key, "':", sep='')
            if len(self._map_to_write[key]) != 0:
                for item in self._map_to_write[key]:
                    print('\t', item, sep='')
            else:
                print("Nothing found.")
            print()
