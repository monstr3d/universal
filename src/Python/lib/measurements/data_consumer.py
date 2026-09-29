from ..category_object import CategoryObject
from typing import List
from measurements import Measurements

class DataConsumer(CategoryObject): 

    def __init__(self, name, desktop):
        super().__init__(name, desktop)
        self._measurements : List[Measurements] = []
        self._dependent_measurements : List[Measurements] = []
        # self._objects : list = []

    @property
    def measurements(self) -> List[Measurements]:
        return self._measurements
    
    @property
    def dependent_measurements(self) -> List[Measurements]:
        return self._dependent_measurements
    
    def append(self, item: Measurements):
        self._measurements.append(item)
        # self._objects = []
        dependent_objects = []
        self._dependent_measurements = []
        for m in self._measurements:
            self._dependent_measurements = self._dependent_measurements.append(m)
            if issubclass(m, DataConsumer):
                dependent_objects = self.get_dependent_objects(dependent_objects)
                for dep_obj in dependent_objects:
                    if issubclass(dep_obj, Measurements) and dep_obj not in self.dependent_measurements:
                        self._dependent_measurements.append(dep_obj)
        

                
    def get_dependent_objects(self, objects_list: list = []) -> list:
        for m in self.measurements:
            if m not in objects_list:
                objects_list.append(m)
            if issubclass(m, DataConsumer):
                objects_list += m.get_dependent_objects(objects_list)
        return objects_list
             






    

