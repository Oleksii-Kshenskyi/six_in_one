from Abstractions.AbstractDirectoryTraversalCommand import *
from .Detail.CSVMapWriter import *
from .Detail.ConsoleMapWriter import *
import json
import re


class LookupCommand(AbstractDirectoryTraversalCommand):
    @classmethod
    def usage_string(cls):
        return "lookup command tries to find the list of your queries in a directory subtree.\n" + \
               "it returns a dictionary with the search results.\n" + \
               "use it the following way:\n" + \
               "\t'lookup <directory1> <config1>'\n" + \
               "\t" + cls._note_preface() + "WORK IN PROGRESS!"

    def _choose_writer(self, writer_type):
        return {
            "console": ConsoleMapWriter(),
            "csv": CSVMapWriter(self._csv_path)
        }.get(writer_type, ConsoleMapWriter())

    def __init__(self, args):
        super().__init__(args)
        self._queries = []
        self._results = {}
        self._masks = []
        try:
            if self.arguments.__len__() >= 2:
                with open(self.arguments[1], "r") as jfile:
                    config = json.load(jfile)
                    self._queries = config["queries"]
                    self._results = {query: [] for query in self._queries}
                    self._writer_type = config["writer_type"]
                    self._csv_path = config["csv_path"]
                    self._masks = config["masks"]
                    self._writer = self._choose_writer(self._writer_type)
        except Exception as err:
            print("Lookup exception while loading JSON: " + str(err.__class__) + " - " + err.__str__())

    @staticmethod
    def find_in_file(filename, query, start=0):
        with open(filename, 'rb') as file:
            filesize = os.path.getsize(filename)
            bsize = 4096 if query.__len__() < 4096 else int(query.__len__() * 1.2)
            if start > 0:
                file.seek(start)
            overlap = len(query) - 1
            while True:
                tellpoint = file.tell()
                if overlap <= tellpoint < filesize:
                    file.seek(tellpoint - overlap)

                buffer = file.read(bsize)
                if buffer != b'' or buffer:
                    pos = buffer.find(bytes(query, 'utf8'))
                    if pos >= 0:
                        return file.tell() - (len(buffer) - pos)
                else:
                    return -1

    def _match_masks(self, test_this):
        if len(self._masks) == 0:
            return True
        for mask in self._masks:
            if re.search(mask, test_this):
                return True
        return False

    def _traverse_single(self, rootname, dirs, files):
        for query in self._queries:
            for file in files:
                if self._match_masks(file):
                    try:
                        fullpath = os.path.join(rootname, file)
                        if self.find_in_file(fullpath, query) != -1:
                            self._results[query] += [fullpath]
                    except PermissionError:
                        print(self._note_preface() + "permission error for file '" + file + "', skipping.")

    def execute(self):
        self.traverse()
        self._writer.write(self._results)
