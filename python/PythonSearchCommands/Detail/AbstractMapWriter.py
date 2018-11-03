from abc import ABC, abstractmethod


class AbstractMapWriter(ABC):
    def __init__(self, map_to_write):
        self._map_to_write = map_to_write

    @abstractmethod
    def write(self):
        pass
