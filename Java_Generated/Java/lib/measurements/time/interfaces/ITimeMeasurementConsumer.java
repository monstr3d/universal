package measurements.time.interfaces;

public interface ITimeMeasurementConsumer {
   ITimeMeasurementProvider getTimeMeasutement();

   void  setTimeMeasurement(ITimeMeasurementProvider provider);

    double getInternalTime();

}
