package general_service;


import general_service.interfaces.IAlias;
import general_service.interfaces.IValue;
import measurements.interfaces.IMeasurements;

public class AliasInitialValueCollection extends InitialValueCollection {
    public AliasInitialValueCollection(IAlias alias, IMeasurements measurements)
    {
        var n = measurements.getMeasurementsCount();
        for (var i = 0; i < n; i++) {
            var m = measurements.getMeasurement(i);
            var name = m.getMeasurementName();
            var iv = (IValue) m;
            var an = new AliasName(alias, name);
            var init = new AliasInitialValue(an, iv);
            this.addInitialValue(init);
        }

    }
}



