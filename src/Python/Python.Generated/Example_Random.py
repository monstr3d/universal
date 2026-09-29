from lib.desktop import Desktop

from lib.measurements.random_generator import RandomGenerator
class Example_RandomCategoryObject0(RandomGenerator):
	def __init__(self, name: str, desktop: Desktop):
		super().__init__(name, desktop)


from lib.measurements.data_consumer import DataConsumer
class Example_RandomCategoryObject1(DataConsumer):
	def __init__(self, name: str, desktop: Desktop):
		super().__init__(name, desktop)


from lib.measurements.data_link import DataLink
class Example_RandomCategoryArrow0(DataLink):
	def __init__(self, name: str, desktop: Desktop):
		super().__init__(name, desktop)



class Example_Random(Desktop):
	def __init__(self):
		super().__init__()

		self.name = "Example_Random"

		Example_RandomCategoryObject0("Random", self)
		Example_RandomCategoryObject1("Chart", self)
		Example_RandomCategoryArrow0("", self)

		objects = self.category_objects
		arrows = self.category_arrows

		arrows[0].source = objects[1]
		arrows[0].target = objects[0]

