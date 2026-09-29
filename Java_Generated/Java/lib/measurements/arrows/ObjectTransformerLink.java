package measurements.arrows;

import category_theory.CategoryArrow;
import category_theory.interfaces.ICategoryObject;
import diagram.interfaces.IDesktop;
import measurements.interfaces.IObjectTransformer;
import measurements.interfaces.IObjectTransformerConsumer;

import java.util.Map;

public class ObjectTransformerLink extends CategoryArrow {
    public ObjectTransformerLink(String name, IDesktop desktop) {
        super(name, desktop);
    }

    /**
     * @param source
     */
    @Override
    public void setSource(ICategoryObject source) {
        super.setSource(source);
        consumer = (IObjectTransformerConsumer) source;
    }


    /**
     * @param target
     */
    @Override
    public void setTarget(ICategoryObject target) {
        super.setTarget(target);
        transformer = (IObjectTransformer) target;
        consumer.addTransfotmer(transformer);
    }

    IObjectTransformerConsumer consumer;

    IObjectTransformer transformer;
}
