/* eslint-disable no-var */
/* eslint-disable @typescript-eslint/no-unused-vars */
/* eslint-disable no-var */
/* eslint-disable @typescript-eslint/no-unused-vars */
import type { IAction } from "../../Library/Interfaces/IAction";
import type { IAlias } from "../../Library/Interfaces/IAlias";
import { ICheck } from "../../Library/Interfaces/ICheck";
import type { IFunc } from "../../Library/Interfaces/IFunc";
import { RungeProcessor } from "../../Library/Measurements/DifferentialEquations/Processors/RungeProcessor";
import type { IDataConsumer } from "../../Library/Measurements/Interfaces/IDataConsumer";
import type { IMeasurement } from "../../Library/Measurements/Interfaces/IMeasurement";
import type { IMeasurements } from "../../Library/Measurements/Interfaces/IMeasurements";
import { PefrormerMeasuremets } from "../../Library/Measurements/PefrormerMeasuremets";
import { Performer } from "../../Library/Performer";
import { DataRuntimeConsumerODE } from "../../Library/Runtime/DataRuntimeConsumerODE";
import type { IDataRuntime } from "../../Library/Runtime/Interfaces/IDataRuntime";
import type { OrbitalForecastConditionNumber, OrbitalForecastItemNumber } from "./OrbitalData";
import { OrbitalForecast } from "./OrbitalForecast";
class Check implements ICheck {
    check(o: any): boolean {
        var s = `${o}`;
        var b = s.includes("NaN");
        if (b)
        {
            var i = 0;
        }
        return b;
    }

}

class Action implements IAction {
    constructor(dc: IDataConsumer, p: Performer) {
        this.dc = dc;
        this.p = p;

    }
    action(): void {
        this.p.print(this.dc);
    }

    dc !: IDataConsumer;
    p !: Performer;
}

export class OrbitalForecastCalculation extends OrbitalForecast implements IAction, IFunc<boolean> {

    condition !: OrbitalForecastConditionNumber;
    act !: Action;
    constructor() {
        super();
        this.dc = this.getCategoryObject("Chart") as unknown as IDataConsumer;
        this.alias = this.getCategoryObject("Motion equations") as unknown as IAlias;
        this.measurements = this.alias as unknown as IMeasurements;
        this.performer.getMeasurementsMMap(this.measurements, this.map);
        let check = new Check();
        this.setCheck(check);
        this.performer.setCheker(this, check);
        this.act = new Action(this.dc, this.performer);

    }

    func(): boolean {
        return this.contoller.signal.aborted;
    }



    action(): void {
        // eslint-disable-next-line no-var
        let rt = this.runtime.getTimeProvider();
        let t = rt.getTime();
        const item = {
            OrbitalTime: t,
            X: this.get("x"),
            Y: this.get("y"),
            Z: this.get("z"),
            Vx: this.get("u"),
            Vy: this.get("v"),
            Vz: this.get("w")
        };
        this.list.push(item);

    }

    public getResult(): OrbitalForecastItemNumber[] {
        return this.list;
    }


    public set(condition: OrbitalForecastConditionNumber): void {
        this.condition = condition;
        this.alias.setAliasValue("x", condition.X);
        this.alias.setAliasValue("y", condition.Y);
        this.alias.setAliasValue("z", condition.Z);
        this.alias.setAliasValue("v", condition.Vx);
        this.alias.setAliasValue("u", condition.Vy);
        this.alias.setAliasValue("w", condition.Vz);
        this.list = [];
        let processor = new RungeProcessor();
        this.runtime = new DataRuntimeConsumerODE(this.dc, processor);
    }

    public calculate = async (condition: OrbitalForecastConditionNumber, controller: AbortController): Promise<OrbitalForecastItemNumber[]> => {
        this.contoller = controller;
        this.set(condition);
        let p = new PefrormerMeasuremets();
        p.peformCondDCFixedStepCalculation(this.runtime, this.dc, "Recursive.y", this, condition.Begin, 1, condition.End, this);
        return this.list;
    }

    public performFixedStepCalculation(): void {
        let p = new PefrormerMeasuremets();
        p.performFixedStepCalculation(this.runtime, this.condition.Begin, 1, this.condition.End, this, this.act);
    }


    get(i: string): number {
        let variable = this.map.get(i);
        return this.performer.convertFromAny<number>(variable?.getMeasurementValue());


    }

    list: OrbitalForecastItemNumber[] = [];

    contoller: AbortController = new AbortController();

    alias !: IAlias;

    measurements !: IMeasurements;

    dc! : IDataConsumer;

    runtime !: IDataRuntime;

    performer: Performer = new Performer();

    map: Map<string, IMeasurement> = new Map();
};

    


