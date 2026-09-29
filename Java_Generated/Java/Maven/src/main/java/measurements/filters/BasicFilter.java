package measurements.filters;

import measurements.interfaces.IFilter;

import java.util.LinkedList;
import java.util.Queue;

public class BasicFilter implements IFilter {

    protected Queue<double[]> queue = new LinkedList<>();

    protected double[] result = {0};

    protected int count = 2;

    @Override
    public int getFilterCount() {
        return count;
    }

    @Override
    public void setFilterCount(int count)
    {
        this.count = count;
    }

    @Override
    public double[] getFilterValue(double[] a) {
        return calc(a);
    }

    @Override
    public void resetFilter() {
        queue.clear();
    }

    protected double[] calc(double[] a)
    {
        if (a != null)
        {
            queue.add(a);
        }
        return a;
    }
}
