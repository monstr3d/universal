package measurements.filters;

import general_service.compatators.DoubleComparator;

import java.util.Comparator;

public class Donchian extends  BasicFilter{
    @Override
    protected double[] calc(double[] a)
    {
        var c = super.calc(a);
        if (a == null)
        {
            return null;
        }
        if (count == queue.size()) {
            var y =  max ? queue.stream().max(comparator) : queue.stream().min(comparator);
            result[0] = y.get()[0];

        }
        while (count > queue.size())
        {
            queue.remove();
        }
        return result;
    }

    protected Comparator<double[]> comparator = new DoubleComparator();

    protected boolean max;

    public  boolean getMax()
    {
        return  max;
    }

    public  void setMax(boolean max)
    {
        this.max = max;
    }

}
