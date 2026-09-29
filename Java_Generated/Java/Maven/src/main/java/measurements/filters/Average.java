package measurements.filters;

import java.util.concurrent.atomic.AtomicReference;

public class Average extends BasicFilter {

    @Override
    protected double[] calc(double[] a)
    {
        var c = super.calc(a);
        if (queue.size() > count)
        {
            queue.remove();
        }
        if (queue.size() == count) {
            result[0] = 0;
            var st = queue.stream();
            st.forEach(n -> result[0] += n[0]);
            result[0] /= count;
            return result;
        }
        return null;
    }
}
