package measurements.service;

import measurements.interfaces.IDataConsumer;
import measurements.interfaces.IMeasurements;

import java.util.Comparator;

public class MeasurementsComparator implements Comparator<IMeasurements> {
    @Override
    public int compare(IMeasurements x, IMeasurements y) {
        if (x == y) {
            return 0;
        }
        if (x instanceof IDataConsumer) {
            if (isSource((IDataConsumer) x, y)) {
                return 1;
            }
        }
        if (y instanceof IDataConsumer) {
            if (isSource((IDataConsumer) y, x)) {
                return -1;
            }
        }
        return 0;
    }

    /// <summary>
    /// The "is source" detector
    /// </summary>
    /// <param name="dc">Data consumer</param>
    /// <param name="m">Measurements</param>
    /// <returns>True is "measurements" is source of "data consumer"</returns>
    protected  boolean isSource(IDataConsumer dc, IMeasurements m)
    {
        var measurements = dc.getAllMeasurements();
        int count = measurements.length;
        for (int i = 0; i < count; i++)
        {
            var x = measurements[i];
            if (m == x)
            {
                return true;
            }
            if (x instanceof IDataConsumer)
            {
                if (isSource((IDataConsumer) x, m))
                {
                    return true;
                }
            }
        }
        return false;
    }
}