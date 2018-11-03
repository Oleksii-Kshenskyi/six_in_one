import csv
from .AbstractMapWriter import *


class CSVMapWriter(AbstractMapWriter):
    def __init__(self, map_to_write, csv_path):
        super().__init__(map_to_write)
        self._csv_path = csv_path

    def write(self):
        list_writer = csv.DictWriter(open(self._csv_path, 'w', newline=''),
                                     fieldnames=self._map_to_write.keys(),
                                     delimiter=',',
                                     quotechar='|',
                                     dialect='excel',
                                     quoting=csv.QUOTE_MINIMAL)
        list_writer.writeheader()
        for row in self._create_dicts():
            list_writer.writerow(row)
        print("Writing to a CSV file succeeded!")

    def _max_of_lens(self):
        lens = []
        for key in self._map_to_write.keys():
            lens += [len(self._map_to_write[key])]
        return max(lens)

    def _create_dicts(self):
        result_dicts = []
        for index in range(0, self._max_of_lens()):
            result_dict = {}
            for key in self._map_to_write.keys():
                result_dict[key] = (self._map_to_write[key][index] if len(self._map_to_write[key]) > index else "")
            result_dicts += [result_dict]
        return result_dicts
