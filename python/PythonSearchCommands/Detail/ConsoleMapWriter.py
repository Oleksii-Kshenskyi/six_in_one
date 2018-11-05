from Abstractions.AbstractMapWriter import *


class ConsoleMapWriter(AbstractMapWriter):
    def __init__(self):
        super().__init__()

    def write(self, map_to_write):
        for key in map_to_write.keys():
            print(">> Results for query '", key, "':", sep='')
            if len(map_to_write[key]) != 0:
                for item in map_to_write[key]:
                    print('\t', item, sep='')
            else:
                print("Nothing found.")
            print()
