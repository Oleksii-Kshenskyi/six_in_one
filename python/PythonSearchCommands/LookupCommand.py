from AbstractCommands.AbstractDirectoryTraversalCommand import *
import json


class LookupCommand(AbstractDirectoryTraversalCommand):
    @classmethod
    def usage_string(cls):
        return "lookup command tries to find the list of your queries in a directory subtree.\n" + \
               "it returns a dictionary with the search results.\n" + \
               "use it the following way:\n" + \
               "\t'lookup <directory1> <config1>'\n" + \
               "\t" + cls._note_preface() + "WORK IN PROGRESS!"

    def __init__(self, args):
        super().__init__(args)
        self._results = {}
        try:
            jfile = open(self.arguments[1], "r") if self.arguments.__len__() > 0 else None
            config = json.load(jfile) if jfile else None
            if jfile:
                jfile.close()
            self._queries = config["queries"] if config else []
            self._results = {query: [] for query in self._queries} if config else {}
        except Exception as err:
            print("Lookup exception while loading JSON: " + err.__str__())

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

    def _traverse_single(self, rootname, dirs, files):
        for query in self._queries:
            for file in files:
                fullpath = os.path.join(rootname, file)
                if self.find_in_file(fullpath, query) != -1:
                    self._results[query] += [fullpath]

    def execute(self):
        self.traverse()
        print("RESULTS: ", self._results)
