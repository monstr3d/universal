package measurements.interfaces;

public interface IDataConsumer {

    IMeasurements[] getAllMeasurements();

    void addMeasurements(IMeasurements item);

}
