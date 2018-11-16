from Abstractions.AbstractDirectoryTraversalCommand import *
from .Detail.CSVMapWriter import *
from .Detail.ConsoleMapWriter import *
import re
from .Detail.JSONLookupConfig import *
from Validators.ArgumentCountValidator import *


class LookupCommand(AbstractDirectoryTraversalCommand):
    @classmethod
    def usage_string(cls):
        return "lookup command tries to find the list of your queries in a directory subtree.\n" + \
               "it returns a list of files where the query was found for each of them.\n" + \
               "use it the following way:\n" + \
               "\t'lookup <config1.json>'\n" + \
               "\t" + cls._note_preface() + cls._argument_count_mismatch_message() + "\n" + \
               "\t<config1.json> is a full path to a JSON file that has to contain the following fields:\n" + \
               "\t>> 'directory_path' is a full path to a directory you'd like to search in;\n" + \
               "\t>> 'queries' has to be a list of strings which contains all the queries you'd like to find in\n" + \
               "\t\tthe directory;\n" + \
               "\t>> 'writer_type' is a string which contains one of those two values: 'csv' or 'console'.\n" + \
               "\t\t>>> 'csv' prints out the search results to a csv file;\n" + \
               "\t\t>>> 'console' prints out the search results to console.\n" + \
               "\t>> 'csv_path' has to be a full path to the csv file if 'writer_type' is 'csv'.\n" + \
               "\t\tIf 'writer_type' is 'console', this value is ignored.\n" + \
               "\t>> 'masks' is a list of strings with all the Python regex masks you'd like to apply to the file\n" \
               "\t\tnames you're searching in. Can be left empty or unspecified if you don't want to use regex\n" + \
               "\t\tfor your search.\n"

    @staticmethod
    def _argument_count_mismatch_message():
        return "the command takes EXACTLY 1 argument!"

    def _lookup_validation(self):
        self._validation.add_validator(ArgumentCountValidator(self.arguments,
                                                              1,
                                                              self._argument_count_mismatch_message()))

    def _choose_writer(self, writer_type):
        return {
            "console": ConsoleMapWriter(),
            "csv": CSVMapWriter(self._config.csv_path)
        }.get(writer_type, ConsoleMapWriter())

    def _get_directory(self):
        return self._directory

    def __init__(self, args):
        super().__init__(args)
        self._config = JSONLookupConfig(self.arguments[0] if self.arguments.__len__() >= 1 else "")
        if self._config.is_valid:
            self._results = {query: [] for query in self._config.queries}
            self._writer = self._choose_writer(self._config.writer_type)
            self._directory = self._config.directory_path
            self._lookup_validation()

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
        if not self._config.masks or len(self._config.masks) == 0:
            return True
        for mask in self._config.masks:
            if re.search(mask, test_this):
                return True
        return False

    def _traverse_single(self, rootname, dirs, files):
        for query in self._config.queries:
            for file in files:
                if self._match_masks(file):
                    try:
                        fullpath = os.path.join(rootname, file)
                        if self.find_in_file(fullpath, query) != -1:
                            self._results[query] += [fullpath]
                    except PermissionError:
                        print(self._note_preface() + "permission error for file '" + file + "', skipping.")

    def execute(self):
        if not self._validation.validate() or not self._config.is_valid:
            return
        self.traverse()
        self._writer.write(self._results)
