from Validators.ValidatorStack import *
from Validators.JSONValidator import *


class JSONConfigLoader(object):
    @staticmethod
    def _file_existence_message():
        return "JSON file doesn't exist."

    @staticmethod
    def _json_invalid_message():
        return "JSON file is invalid."

    def __init__(self, json_file):
        self._json_file = json_file
        self._validators = ValidatorStack()
        self._config_validation_setup()

    def _config_validation_setup(self):
        self._validators.add_validator(JSONValidator(self._json_file,
                                                     self._file_existence_message(),
                                                     self._json_invalid_message()))
        try:
            with open(self._json_file, "r") as jfile:
                self._json_object = json.load(jfile)
        except Exception:
            self._json_object = None
