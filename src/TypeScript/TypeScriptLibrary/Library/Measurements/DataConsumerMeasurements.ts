import { IAlias } from "../Interfaces/IAlias";
import { IDesktop } from "../Interfaces/IDesktop";
import { Performer } from "../Performer";
import { DataConsumer } from "./DataConsumer";
import { IMeasurement } from "./Interfaces/IMeasurement";
import { IMeasurements } from "./Interfaces/IMeasurements";

export class DataConsumerMeasurements extends DataConsumer implements IMeasurements, IAlias {
    constructor(desktop: IDesktop, name: string) {
        super(desktop, name);
        this.alias = this;
        this.typeName = "DataConsumerMeasurements";
        this.types.push("DataConsumerMeasurements");
        this.types.push("IMeasurements");
        this.types.push("IAlias");
    }

    getAliasValue(name: string)
    {
        return this.aliasValues.get(name);
    }
    protected output: IMeasurement[] = [];

    protected aliasTypes: Map<string, any> = new Map();

    protected aliasValues: Map<string, any> = new Map();

    protected aliasNames: string[] = [];

    protected performer: Performer = new Performer();

    protected variable: any;

    protected alias !: IAlias;


 
    getMeasurementsCount(): number {
        return this.output.length;
    }

    getMeasurement(i: number): IMeasurement {
        return this.output[i];
    }

    addMeasurement(measurement: IMeasurement): void {
        this.output.push(measurement);
    }


    updateMeasurements(): void {
    }

    getAliasType(name: string): any {
        return this.aliasTypes.get(name);
    }
    


    getAliasNames(): string[] {
        return this.aliasNames;
    }

    

    getAliasVаlue(name: string) {
        return this.aliasValues.get(name);
    }

    setAliasValue(name: string, value: any)
    {
        this.performer.setAliasType(name, value, this.aliasTypes, this.aliasNames);
        this.aliasValues.set(name, value);
    }

}
