package general_service.setters;

import general_service.interfaces.IValueSetter;

public class BooleanSetter extends AbstractSetter {
    public BooleanSetter() {
        value = array;
        def = new boolean[]{true};
        type = new boolean[0];
    }


    @Override
    public void setValue(Object o)
    {
        if (o == null) {
            value = null;
            return;
        }
        var d = (boolean[]) o;
        array[0] = d[0];
        value = array;
    }

    @Override
    public  String toString()
    {
        return  value == null ? "null" : array[0] + "";
    }

    private final boolean[] array = new boolean[]{true};


}