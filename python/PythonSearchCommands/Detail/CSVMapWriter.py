import csv
from .AbstractMapWriter import *


class CSVMapWriter(AbstractMapWriter):
    def __init__(self, csv_path):
        super().__init__()
        self._csv_path = csv_path

    def write(self, map_to_write):
        list_writer = csv.DictWriter(open(self._csv_path, 'w', newline=''),
                                     fieldnames=map_to_write.keys(),
                                     delimiter=',',
                                     quotechar='|',
                                     dialect='excel',
                                     quoting=csv.QUOTE_MINIMAL)
        list_writer.writeheader()
        for row in self._create_dicts(map_to_write):
            list_writer.writerow(row)
        print("Writing to a CSV file succeeded!")

    @staticmethod
    def _max_of_lens(map_to_write):
        lens = []
        for key in map_to_write.keys():
            lens += [len(map_to_write[key])]
        return max(lens)

    def _create_dicts(self, map_to_write):
        result_dicts = []
        for index in range(0, self._max_of_lens(map_to_write)):
            result_dict = {}
            for key in map_to_write.keys():
                result_dict[key] = (map_to_write[key][index] if len(map_to_write[key]) > index else "")
            result_dicts += [result_dict]
        return result_dicts
