package generated;

import diagram.Desktop;

import diagram.interfaces.IDesktop;

import error_handler.interfaces.ICheck;

import error_handler.interfaces.IErrorHandler;

public class Random extends Desktop
{

	protected class CategoryObject0 extends measurements.RandomGenerator
	{
		public CategoryObject0(String name, IDesktop desktop) {
			super(name,  desktop);
			}
			}
	

	protected class CategoryObject1 extends measurements.DataConsumer
	{
		public CategoryObject1(String name, IDesktop desktop) {
			super(name,  desktop);
			}
			}
	

	protected class CategoryArrow0 extends measurements.arrows.DataLink
	{
		public CategoryArrow0(String name, IDesktop desktop) {
			super(name,  desktop);
			}
			}
	

	public Random() {
		super();
	}

	public Random(ICheck check, IErrorHandler errorHandler) {
		super(check, errorHandler);
	}


	@Override
	public void init()
	{
		new Random.CategoryObject0("Random", this);
		new Random.CategoryObject1("Chart", this);
		new Random.CategoryArrow0("", this);
		arrows.get(0).setSource(objects.get(1));
		arrows.get(0).setTarget(objects.get(0));
		postSet();
	}


}
