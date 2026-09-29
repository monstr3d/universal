from typing import Any
from desktop import Desktop


class CategoryObject:
    def __init__(self, name: str, desktop: Desktop):
        self._name = name
        self._desktop = desktop
        if self._desktop is not None:
            self._desktop += self
            # TODO add checker and error handler
        raise NotImplemented()

    @property
    def name(self):
        return self._name
    
    @property
    def desktop(self):
        return self._desktop
    
    def _check(self, obj: Any) -> bool:
        raise NotImplemented()
    
    def _show(self, message: str) -> None:
        raise NotImplemented()
    
    def _handle(self, exception: Exception) -> None:
        raise NotImplemented


    