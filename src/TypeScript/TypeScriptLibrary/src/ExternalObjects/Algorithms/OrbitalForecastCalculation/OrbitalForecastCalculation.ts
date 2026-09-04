/* eslint-disable no-var */
/* eslint-disable @typescript-eslint/no-unused-vars */
/* eslint-disable no-var */
/* eslint-disable @typescript-eslint/no-unused-vars */
import type { IAction } from "../../../Library/Interfaces/IAction";
import type { IAlias } from "../../../Library/Interfaces/IAlias";
import type { ICheck } from "../../../Library/Interfaces/ICheck";
import type { IFunc } from "../../../Library/Interfaces/IFunc";
import { RungeProcessor } from "../../../Library/Measurements/DifferentialEquations/Processors/RungeProcessor";
import type { IDataConsumer } from "../../../Library/Measurements/Interfaces/IDataConsumer";
import type { IMeasurement } from "../../../Library/Measurements/Interfaces/IMeasurement";
import type { IMeasurements } from "../../../Library/Measurements/Interfaces/IMeasurements";
import { PerformerMeasuremets } from "../../../Library/Measurements/PerformerMeasuremets";
import { Performer } from "../../../Library/Performer";
import { DataRuntimeConsumerODE } from "../../../Library/Runtime/DataRuntimeConsumerODE";
import type { OrbitalForecastConditionNumber, OrbitalForecastItemNumber } from "./OrbitalData";
import { OrbitalForecast } from "./OrbitalForecast";
import { StopWatch } from "../../../Library/Utilities/DateTime/StopWatch";
import { IDataRuntime } from "../../../Library/Interfaces/IDataRuntime";
import { Motion6DFactory } from "../../../Library/Motion6D/Motion6DFactory";
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

    isEmptyAction(): boolean {
        return false
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
    isEmptyAction(): boolean {
        return false
    }

    func(): boolean {
        return this.contoller.signal.aborted;
    }



    action(): void {
        // eslint-disable-next-line no-var
        let rt = this.runtime.getTimeProvider();
        let t = rt.getTime();
        this.stopWatch.stop();
        const item = {
            orbitalTime: t,
           x: this.get("x"),
            y: this.get("y"),
            z: this.get("z"),
            vx: this.get("u"),
            vy: this.get("v"),
            vz: this.get("w"),
            duration: this.stopWatch.getTotalTime()
        };
        this.stopWatch.start();
        this.list.push(item);

    }

    public getResult(): OrbitalForecastItemNumber[] {
        return this.list;
    }


    public set(condition: OrbitalForecastConditionNumber): void {
        this.condition = condition;
        this.alias.setAliasValue("x", condition.x);
        this.alias.setAliasValue("y", condition.y);
        this.alias.setAliasValue("z", condition.z);
        this.alias.setAliasValue("u", condition.vx);
        this.alias.setAliasValue("v", condition.vy);
        this.alias.setAliasValue("w", condition.vz);
        this.list = [];
        let processor = new RungeProcessor();
        this.runtime = new DataRuntimeConsumerODE(this.dc, new Motion6DFactory())
    }

    public calculate = async (condition: OrbitalForecastConditionNumber, controller: AbortController): Promise<OrbitalForecastItemNumber[]> => {
        this.contoller = controller;
        this.set(condition);
        let p = new PerformerMeasuremets();
        this.stopWatch = new StopWatch();
        this.stopWatch.start();
        var count = Math.floor(condition.end - condition.begin);
        p.peformCondDCFixedStepCalculation(this.runtime, this.dc, "Recursive.y", this, condition.begin, 1, count, this);
        this.stopWatch.stop();
        return this.list;
    }

    public performFixedStepCalculation(): void {
        this.stopWatch = new StopWatch();
        this.stopWatch.start();
        let p = new PerformerMeasuremets();
        p.performFixedStepCalculation(this.runtime, this.condition.begin, 1,
            this.condition.end, this, this.act);
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

    stopWatch !: StopWatch;
};

    


