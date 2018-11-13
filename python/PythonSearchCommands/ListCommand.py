from Abstractions.AbstractDirectoryTraversalCommand import *
from .Detail.ConsoleMapWriter import *


class ListCommand(AbstractDirectoryTraversalCommand):
    @staticmethod
    def _argument_count_mismatch_message():
        return "the command takes EXACTLY 1 argument!"

    @classmethod
    def usage_string(cls):
        return "list command lists all the contents of <directory1>.\n" + \
               "Use it the following way:\n" + \
               "\t'list <directory1>'\n" + \
               "\tOutput is of the following format:\n" + \
               "\t'=[F|D] <[file|directory]_name> [(<file_size>)]'\n" + \
               "\twhere [F|D] shows if it is a file or a directory.\n" + \
               "\t" + cls._note_preface() + cls._argument_count_mismatch_message()

    def _get_directory(self):
        return self._directory

    def __init__(self, args):
        super().__init__(args)
        self._writer = ConsoleMapWriter()
        self._results = {}
        self._directory = Path(self.arguments[0]) if self.arguments.__len__() > 0 else Path("")
        self._dir_traversal_validation()

    def _traverse_single(self, rootname, dirs, files):
        self._results[rootname] = files

    def execute(self):
        if not self._validation.validate():
            return

        self.traverse(topdown=True)
        self._writer.write(self._results)
