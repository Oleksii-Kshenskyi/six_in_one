from .FileExistenceValidator import *
import json


class JSONValidator(FileExistenceValidator):
    def __init__(self, validate_this_json, file_message, json_message):
        super().__init__(validate_this_json, file_message)
        self._json_message = json_message

    def validate(self):
        if not super().validate():
            return False
        try:
            with open(self._validate_this, "r") as json_file:
                json.load(json_file)
        except json.JSONDecodeError:
            if self._json_message:
                print(self._error_preface() + self._json_message)
            return False
        return True
