package measurements.interfaces;

import category_theory.interfaces.ICategoryObject;

public interface IMeasurements {
   int  getMeasurementsCount();
   IMeasurement  getMeasurement(int i);
   void   updateMeasurements();
   void  addMeasurement(IMeasurement measurement);
}
