package external.trading.library.objects;

import category_theory.CategoryObject;
import diagram.interfaces.IDesktop;
import general_service.interfaces.IPostSetArrow;
import measurements.interfaces.IIterator;
import measurements.interfaces.IIteratorConsumer;
import measurements.interfaces.IMeasurement;
import measurements.interfaces.IMeasurements;

public class Order  extends CategoryObject implements IPostSetArrow, IMeasurements,
        IIteratorConsumer
{

    protected String buyPrice = "";

    protected String sellPrice = "";

    protected String position = "";




    public  Order(String name, IDesktop desktop)
    {
        super(name, desktop);
    }

    @Override
    public void postSetArrow() {

    }

    @Override
    public int getMeasurementsCount() {
        return 0;
    }

    @Override
    public IMeasurement getMeasurement(int i) {
        return null;
    }

    @Override
    public void updateMeasurements() {

    }

    @Override
    public void addMeasurement(IMeasurement measurement) {

    }

    @Override
    public void addIterator(IIterator iterator) {

    }

    @Override
    public void removeIterator(IIterator iterator) {

    }
}
