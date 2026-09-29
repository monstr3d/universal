/* eslint-disable no-var */
/* eslint-disable @typescript-eslint/no-unused-vars */
/* eslint-disable @typescript-eslint/no-explicit-any */
import type { IAlias } from "../Interfaces/IAlias";
import type { IDesktop } from "../Interfaces/IDesktop";
import { DataConsumer } from "./DataConsumer";
import type { IMeasurement } from "./Interfaces/IMeasurement";
import type { IMeasurements } from "./Interfaces/IMeasurements";
import { PerformerMeasuremets } from "./PerformerMeasuremets";
import { Variable } from "./Variables/Variable";


export class DataConsumerVariableMeasurements extends DataConsumer implements
    IMeasurements, IAlias
{
    constructor(desktop: IDesktop, name: string)
    {
        super(desktop, name);
        this.alias = this;
        this.typeName = "DataConsumerVariadbleMeasurements";
        this.types.push("DataConsumerVariadbleMeasurements");
        this.types.push("IMeasurements");
        this.types.push("IAlias");
        this.types.push("ISetFeedback");
    }
    
  
    protected output: Variable[] = [];

    protected variables: Map<string, Variable> = new Map();

    protected aliasTypes: Map<string, any> = new Map();

    protected aliasValues: Map<string, any> = new Map();

    protected aliasNames: string[] = [];

    protected dataVariable: any;

    protected alias !: IAlias;

    protected pMeasurements: PerformerMeasuremets = new PerformerMeasuremets();


    getMeasurementsCount(): number
    {
        return this.output.length;
    }

    getMeasurement(i: number): IMeasurement {
        return this.output[i];
    }

  fict !: IMeasurement
    

    addMeasurement(measurement: IMeasurement): void {
        this.fict = measurement
    }


    updateMeasurements(): void {
    }

    getAliasType(name: string): any {
        return this.aliasTypes.get(name);
    }



    getAliasNames(): string[] {
        return this.aliasNames;
    }


    getAliasValue(name: string) {
        return this.aliasValues.get(name);
    }

    setAliasValue(name: string, value: any)
    {
        if (!this.aliasTypes.has(name))
        {
            this.performer.setAliasType(name, value, this.aliasTypes, this.aliasNames);
        }
        this.aliasValues.set(name, value);
    }

    protected addVariableValue(name: string, type: any, value: any): void
    {
        let variable = new Variable(name, type, value, this);
        this.addVariable(variable);
    }

    protected addVariable(variable: Variable): void
    {
        this.output.push(variable);
        this.variables.set(variable.getMeasurementName(), variable);
    }

}
