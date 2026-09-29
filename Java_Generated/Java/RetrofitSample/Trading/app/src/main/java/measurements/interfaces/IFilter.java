package measurements.interfaces;

public interface IFilter {

    int getFilterCount();

    void setFilterCount(int count);

    double[] getFilterValue(double[] a);

    void resetFilter();
}
