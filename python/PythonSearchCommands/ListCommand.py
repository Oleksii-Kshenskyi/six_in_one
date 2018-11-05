from Abstractions.AbstractDirectoryTraversalCommand import *


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

    def __init__(self, args):
        super().__init__(args)

    def _traverse_single(self, rootname, dirs, files):
        print("---" + rootname + "---:")
        print("DIRS: ", dirs)
        print("FILES: ", files)

    def execute(self):
        self.traverse(topdown=False)
