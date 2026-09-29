package generated;

import diagram.Desktop;

import diagram.interfaces.IDesktop;

import error_handler.interfaces.ICheck;

import error_handler.interfaces.IErrorHandler;

public class RandomTwo extends Desktop
{

	protected class CategoryObject0 extends measurements.RandomGenerator
	{
		public CategoryObject0(String name, IDesktop desktop) {
			super(name,  desktop);
			}
	}
	

	protected class CategoryObject1 extends measurements.RandomGenerator
	{
		public CategoryObject1(String name, IDesktop desktop) {
			super(name,  desktop);
			}
	}
	

	protected class CategoryObject2 extends measurements.DataConsumer
	{
		public CategoryObject2(String name, IDesktop desktop) {
			super(name,  desktop);
			}
	}
	

	protected class CategoryArrow0 extends measurements.arrows.DataLink
	{
		public CategoryArrow0(String name, IDesktop desktop) {
			super(name,  desktop);
			}
	}
	

	protected class CategoryArrow1 extends measurements.arrows.DataLink
	{
		public CategoryArrow1(String name, IDesktop desktop) {
			super(name,  desktop);
			}
	}
	

	public RandomTwo() {
		super();
	}

	public RandomTwo(ICheck check, IErrorHandler errorHandler) {
		super(check, errorHandler);
	}


	@Override
	public void init()
	{
		new RandomTwo.CategoryObject0("Random", this);
		new RandomTwo.CategoryObject1("2", this);
		new RandomTwo.CategoryObject2("Chart", this);
		new RandomTwo.CategoryArrow0("", this);
		new RandomTwo.CategoryArrow1("", this);
		arrows.get(0).setSource(objects.get(2));
		arrows.get(0).setTarget(objects.get(0));
		arrows.get(1).setSource(objects.get(2));
		arrows.get(1).setTarget(objects.get(1));
		postSet();
	}


}
