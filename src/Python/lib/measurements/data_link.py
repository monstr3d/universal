from ..category_object import CategoryObject
from ..category_arrow import CategoryArrow
from ..desktop import Desktop
from ..measurements.measurements import Measurements
from ..measurements.measurement import Measurement
from data_consumer import DataConsumer


class DataLink(CategoryArrow):

    def __init__(self, name, desktop):
        super().__init__(name, desktop)
        self._data_consumer: DataConsumer = None
        self._measurements: Measurements = None
    
    @property
    def name(self):
        return self._name
    
    @property
    def source(self):
        return self._source
    
    @source.setter
    def source(self, source: CategoryObject):
        super().source = source
        self.target = source

    @property
    def target(self):
        return self._target
    
    @target.setter
    def target(self, target: CategoryObject):
        super().target = target
        self._measurements = target
        self._data_consumer.append(self._measurements)
        
