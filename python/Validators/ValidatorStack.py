class ValidatorStack(object):
    def __init__(self):
        self._stack = []

    def add_validator(self, validator):
        self._stack += [validator]

    def validate(self):
        for validator in self._stack:
            if not validator.validate():
                return False
        return True
