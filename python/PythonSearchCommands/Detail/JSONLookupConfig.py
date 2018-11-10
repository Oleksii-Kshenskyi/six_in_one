from Abstractions.JSONConfigLoader import *
from Validators.MapValueTypeValidator import *
from Validators.DirectoryExistenceValidator import *
from Validators.InListTypeValidator import *
from pathlib import Path


class JSONLookupConfig(JSONConfigLoader):
    @staticmethod
    def _value_existence_message():
        return "value at key <{}> doesn't exist."

    @staticmethod
    def _value_type_message():
        return "value at key <{}> has type <{}>, but should be <{}>!"

    @staticmethod
    def _csv_path_broken():
        return "impossible to create the output CSV file as the parent directory in the specified path does not exist."

    @staticmethod
    def _queries_type_incorrect_message():
        return "all elements in the <queries> list should be strings!"

    def __init__(self, json_file):
        super().__init__(json_file)
        self.is_valid = False
        self._lookup_config_validation()
        self._initialize_properties()

    def _lookup_config_validation(self):
        self._validators.add_validator(MapValueTypeValidator(self._json_object,
                                                             "queries",
                                                             list,
                                                             self._value_existence_message(),
                                                             self._value_type_message()))
        self._validators.add_validator(InListTypeValidator(self._json_object["queries"]
                                                           if self._json_object
                                                           and "queries" in self._json_object.keys()
                                                           else [],
                                                           str,
                                                           self._queries_type_incorrect_message()))

    def _initialize_properties(self):
        if not self._validators.validate():
            self.is_valid = False
        else:
            self.queries = self._json_object["queries"]
            self.writer_type = self._validate_type_or_default("writer_type", str, "console")
            self.masks = self._validate_type_or_default("masks", list, [])
            self._validate_mask_types()
            self.is_valid = True
            self.csv_path = self._validate_csv_path()

    def _validate_csv_path(self):
        if self.writer_type != "csv":
            return ""
        elif not MapValueTypeValidator(self._json_object,
                                       "csv_path",
                                       str,
                                       self._value_existence_message(),
                                       self._value_type_message()).validate() \
            or not DirectoryExistenceValidator(str(Path(self._json_object["csv_path"]).parent),
                                               self._csv_path_broken()).validate():
            self.is_valid = False
            return None
        else:
            return self._json_object["csv_path"]

    def _validate_type_or_default(self, value_name, value_type, default):
        if MapValueTypeValidator(self._json_object,
                                 value_name,
                                 value_type).validate():
            return self._json_object[value_name]
        else:
            self.masks = default

    def _validate_mask_types(self):
        if not self.masks:
            return
        if not InListTypeValidator(self.masks, str).validate():
            self.masks = []

    @property
    def is_valid(self):
        return self._is_valid

    @is_valid.setter
    def is_valid(self, new_valid):
        self._is_valid = new_valid
        if not new_valid:
            self._reset_all()

    def _reset_all(self):
        self.queries = None
        self.writer_type = None
        self.masks = None
        self.csv_path = None
