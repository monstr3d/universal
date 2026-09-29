from typing import Any


class Measurement:
    
    def __init__(self, name: str, measurement_type: Any, value: Any):
        self._name = name
        self._measurement_type = measurement_type
        self._measurement_value = value

    @property
    def measurement_name(self):
        return self._name
    
    @property
    def measurement_type(self):
        return self._measurement_type
    
    @property
    def measurement_value(self):
        return self._measurement_value
    