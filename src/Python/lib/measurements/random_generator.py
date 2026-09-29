import random
from ..measurements.measurements import Measurements
from measurement import Measurement
from ..desktop import Desktop

class RandomGenerator(Measurements, Measurement):
    def __init__(self, name: str, desktop: Desktop, seed=-1):
        Measurements.__init__(self, name=name, desktop=desktop)
        Measurement.__init__(self, name=self.name, type=float)
        self.append(self)
        random.seed(seed)
        self.random = random.random
        
        self.value = 0
    
    def measurement_name(self):
        return "Random"
    
    def measurement_type(self):
        return float
    
    def measurement_value(self):
        return self.measurement_type()
    
    def __str__(self):
        return self.value
    
    def update(self):
        self.value = self.random()
