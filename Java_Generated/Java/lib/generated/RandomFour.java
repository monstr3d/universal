package generated;

import diagram.Desktop;

import diagram.interfaces.IDesktop;

import error_handler.interfaces.ICheck;

import error_handler.interfaces.IErrorHandler;

public class RandomFour extends Desktop
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
	

	protected class CategoryObject2 extends measurements.RandomGenerator
	{
		public CategoryObject2(String name, IDesktop desktop) {
			super(name,  desktop);
			}
	}
	

	protected class CategoryObject3 extends measurements.RandomGenerator
	{
		public CategoryObject3(String name, IDesktop desktop) {
			super(name,  desktop);
			}
	}
	

	protected class CategoryObject4 extends external.test.TestObjectTransformer
	{
		public CategoryObject4(String name, IDesktop desktop) {
			super(name,  desktop);
				coefficient = 7.4000000000000004;
			}
	}
	

	protected class CategoryObject5 extends measurements.ObjectTransformer
	{
		public CategoryObject5(String name, IDesktop desktop) {
			super(name,  desktop);
			int[] x = null;
			java.util.ArrayList<int[]> array = new java.util.ArrayList<>();
			x = new int[]{
			0,
			0
			};
			array.add(x);
			x = new int[]{
			1,
			0
			};
			array.add(x);
			x = new int[]{
			2,
			0
			};
			array.add(x);
			x = new int[]{
			3,
			0
			};
			array.add(x);
			this.array = array;
			}
	}
	

	protected class CategoryObject6 extends measurements.DataConsumer
	{
		public CategoryObject6(String name, IDesktop desktop) {
			super(name,  desktop);
			}
	}
	

	protected class CategoryArrow0 extends measurements.arrows.ObjectTransformerLink
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
	

	protected class CategoryArrow2 extends measurements.arrows.DataLink
	{
		public CategoryArrow2(String name, IDesktop desktop) {
			super(name,  desktop);
			}
	}
	

	protected class CategoryArrow3 extends measurements.arrows.DataLink
	{
		public CategoryArrow3(String name, IDesktop desktop) {
			super(name,  desktop);
			}
	}
	

	protected class CategoryArrow4 extends measurements.arrows.DataLink
	{
		public CategoryArrow4(String name, IDesktop desktop) {
			super(name,  desktop);
			}
	}
	

	protected class CategoryArrow5 extends measurements.arrows.DataLink
	{
		public CategoryArrow5(String name, IDesktop desktop) {
			super(name,  desktop);
			}
	}
	

	public RandomFour() {
		super();
	}

	public RandomFour(ICheck check, IErrorHandler errorHandler) {
		super(check, errorHandler);
	}


	@Override
	public void init()
	{
		new RandomFour.CategoryObject0("1", this);
		new RandomFour.CategoryObject1("2", this);
		new RandomFour.CategoryObject2("4", this);
		new RandomFour.CategoryObject3("3", this);
		new RandomFour.CategoryObject4("Test", this);
		new RandomFour.CategoryObject5("Consumer", this);
		new RandomFour.CategoryObject6("Chart", this);
		new RandomFour.CategoryArrow0("", this);
		new RandomFour.CategoryArrow1("", this);
		new RandomFour.CategoryArrow2("", this);
		new RandomFour.CategoryArrow3("", this);
		new RandomFour.CategoryArrow4("", this);
		new RandomFour.CategoryArrow5("", this);
		arrows.get(0).setSource(objects.get(5));
		arrows.get(0).setTarget(objects.get(4));
		arrows.get(1).setSource(objects.get(5));
		arrows.get(1).setTarget(objects.get(0));
		arrows.get(2).setSource(objects.get(5));
		arrows.get(2).setTarget(objects.get(1));
		arrows.get(3).setSource(objects.get(5));
		arrows.get(3).setTarget(objects.get(3));
		arrows.get(4).setSource(objects.get(5));
		arrows.get(4).setTarget(objects.get(2));
		arrows.get(5).setSource(objects.get(6));
		arrows.get(5).setTarget(objects.get(5));
		postSet();
	}


}
