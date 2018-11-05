from abc import ABC, abstractmethod


class AbstractMapWriter(ABC):
    def __init__(self):
        pass

    @abstractmethod
    def write(self, map_to_write):
        pass
