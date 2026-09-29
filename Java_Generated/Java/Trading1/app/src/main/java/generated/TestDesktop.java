package generated;

import diagram.Desktop;
import diagram.interfaces.IDesktop;

public class TestDesktop extends Desktop {

    protected class CategoryObject0  extends measurements.DataConsumer
    {

        public CategoryObject0(String name, IDesktop desktop) {
            super(name, desktop);
        }
    }

    protected class CategoryObject1  extends measurements.Measurements
    {

        public CategoryObject1(String name, IDesktop desktop) {
            super(name, desktop);
        }
    }

    protected class CategoryArrow0 extends measurements.arrows.DataLink
    {

        public CategoryArrow0(String name, IDesktop desktop) {
            super(name, desktop);
        }
    }

    public TestDesktop()
    {
        new TestDesktop.CategoryObject0("uuu", this);
        new TestDesktop.CategoryObject1("uuuiii", this);
        new TestDesktop.CategoryArrow0("uuiiiuiii", this);
        arrows.get(0).setSource(objects.get(0));
        arrows.get(0).setTarget(objects.get(1));

        postSet();
    }



}
