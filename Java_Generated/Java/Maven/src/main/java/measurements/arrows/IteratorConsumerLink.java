package measurements.arrows;

import category_theory.CategoryArrow;
import category_theory.interfaces.ICategoryObject;
import diagram.interfaces.IDesktop;
import measurements.interfaces.IIterator;
import measurements.interfaces.IIteratorConsumer;


public class IteratorConsumerLink extends CategoryArrow {
    public IteratorConsumerLink(String name, IDesktop desktop) {
        super(name, desktop);
    }

    IIterator iterator;

    IIteratorConsumer consumer;

    @Override
    public void setSource(ICategoryObject source) {
        super.setSource(source);
        consumer = (IIteratorConsumer) source;
    }

    /**
     * @param target
     */
    @Override
    public void setTarget(ICategoryObject target) {
        super.setTarget(target);
        iterator = (IIterator) target;
        consumer.addIterator(iterator);
    }
}
