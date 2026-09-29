package general_service.compatators;

import java.util.Comparator;

public class DoubleComparator implements Comparator<double[]> {
    @Override
    public int compare(double[] o1, double[] o2) {
        var x = o1[0] - o2[0];
        return x == 0 ? 0 : ( (x > 0) ? 1 : -1);
    }
}
