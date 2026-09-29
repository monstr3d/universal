from typing import List
from measurement import Measurement
from lib.desktop import Desktop
from lib.category_object import CategoryObject


class Measurements(CategoryObject):
    def __init__(self, name, desktop):
        super().__init__(name, desktop)
        self._measurements: List[Measurement] = []

    def __len__(self):
        return len(self._measurements)
    
    def __getitem__(self, i: int):
        return self._measurements[i]
    
    def update(self):
        pass

    def append(self, measurement: Measurement):
        self._measurements.append(measurement)

    def __add__(self, measurement: Measurement):
        self.append(measurement)
