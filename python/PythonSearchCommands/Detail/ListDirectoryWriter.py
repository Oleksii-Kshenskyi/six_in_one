from Abstractions.AbstractMapWriter import *
import os


class ListDirectoryWriter(AbstractMapWriter):
    def __init__(self, target_dir):
        super().__init__()
        self._target_dir = target_dir

    @staticmethod
    def _get_size(filename):
        raw_size = os.path.getsize(filename)
        return format("%.3fB" % raw_size) if 0 <= raw_size < 1024 \
            else format("%.3fKB" % (raw_size / 1024)) if 1024 <= raw_size < 1024 * 1024 \
            else format("%.3fMB" % (raw_size / (1024*1024))) if raw_size >= 1024 * 1024 \
            else ""

    def write(self, map_to_write):
        print(">> {}:".format(self._target_dir))
        for key in map_to_write.keys():
            if key != str(self._target_dir):
                print("=D {}".format(key))
        if len(map_to_write[str(self._target_dir)]) != 0:
            for item in map_to_write[str(self._target_dir)]:
                print('=F {} ({})'.format(item, self._get_size(os.path.join(self._target_dir, item))))
        else:
            print("Nothing found.")
        print("======\n=TOTAL ITEMS: {}.".format(len(map_to_write[str(self._target_dir)]) + len(map_to_write.keys()) - 1))
