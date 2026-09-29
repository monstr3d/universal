from typing import Dict, List
from category_object import CategoryObject
from category_arrow import CategoryArrow


class Desktop: 
    def __init__(self):
        self._category_objects_arrows_dict: Dict[str, CategoryObject | CategoryArrow] = {}

    @property
    def category_objects(self):
        return [v for v in self._category_objects_arrows_dict.values() if issubclass(v, CategoryObject)]
    
    @property
    def category_arrows(self):
        return [v for v in self._category_objects_arrows_dict.values() if issubclass(v, CategoryArrow)]
    
    def __getitem__(self, key: str):
        return self._category_objects_arrows_dict[key]
    
    def __add__(self, obj_or_arr: CategoryObject | CategoryArrow | List[CategoryObject | CategoryArrow]):
        self.add(obj_or_arr)
        
    def add(self, obj_or_arr: CategoryObject | CategoryArrow | List[CategoryObject | CategoryArrow]):
        if issubclass(type(obj_or_arr), CategoryObject) or issubclass(type(obj_or_arr), CategoryArrow):
            self._category_objects_arrows_dict[obj_or_arr.name] = obj_or_arr
        elif issubclass(type(obj_or_arr), list):
            for item in obj_or_arr:
                self.add(item)
        else:
            raise TypeError("Item to be added is neither a CategoryObject nor a CategoryArrow")

    def post_set(self):
        for v in self._category_objects_arrows_dict.values():
            if callable(getattr(v, "post_set")):
                v.post_set()
    