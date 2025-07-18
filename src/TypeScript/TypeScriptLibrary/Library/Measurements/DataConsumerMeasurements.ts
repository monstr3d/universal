﻿import { IAlias } from "../IAlias";
import { IDesktop } from "../IDesktop";
import { Performer } from "../Performer";
import { DataConsumer } from "./DataConsumer";


export class DataConsumerMeasurements extends DataConsumer implements IMeasurements, IAlias {
    constructor(desktop: IDesktop, name: string) {
        super(desktop, name);

    }
    protected output: IMeasurement[] = [];

    protected aliasTypes: Map<string, any> = new Map();

    protected aliasValues: Map<string, any> = new Map();

    protected aliasNames: string[] = [];

    protected performer: Performer = new Performer();

    protected variable: any;

 
    getMeasurementsCount(): number {
        return this.output.length;
    }

    geMeasurement(i: number): IMeasurement {
        return this.output[i];
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

    setAliasValue(name: string, value: any) {
        this.performer.setAliasType(name, value, this.aliasTypes, this.aliasNames);
        this.aliasValues.set(name, value);
    }

}
