package measurements.time.interfaces;

import measurements.interfaces.IMeasurement;

   public interface ITimeMeasurementProvider {
        IMeasurement getTimeMeasurement();

        double getTime();

        void setTime(double time);


    }