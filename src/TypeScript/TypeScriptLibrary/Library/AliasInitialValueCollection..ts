import { AliasInitialValue } from "./AliasInitialValue";
import { AliasName } from "./AliasName";
import { InitialValueCollection } from "./InitialValueCollection";
import { IAlias } from "./Interfaces/IAlias";
import { IValue } from "./Interfaces/IValue";
import { IMeasurement } from "./Measurements/Interfaces/IMeasurement";
import { IMeasurements } from "./Measurements/Interfaces/IMeasurements";
import { Performer } from "./Performer";

export class AliasInitialValueCollection extends InitialValueCollection
{
    performer : Performer = new Performer();
    constructor(alias: IAlias, measurements: IMeasurements)
    {
        super();
        var n = measurements.getMeasurementsCount();
        for (let i = 0; i < n; i++)
        {
            var m = measurements.getMeasurement(i);
            var name = m.getMeasurementName();
            var iv = this.performer.convertObject<IValue, IMeasurement>(m, "IValue");
            var an = new AliasName(alias, name);
            if (iv.length == 1)
            {
                var init = new AliasInitialValue(an, iv[0]);
                this.addInitialValue(init);
            }
        }

    }
}
