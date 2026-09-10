import { ActionWatch } from "./ActionWatch";
import type { IActionAddRemove } from "../../Interfaces/IActionAddRemove";
import type { IActionT } from "../../Interfaces/IActionT";
import type { IMeasurement } from "../../Measurements/Interfaces/IMeasurement";
import type { ITimeMeasurementProvider } from "../../Measurements/Interfaces/ITimeMeasurementProvider";

export class ExternalWatch extends ActionWatch implements IActionT<number>, IMeasurement, ITimeMeasurementProvider {

    constructor(interval: number, external: IActionAddRemove) {
        super(interval, external)
    }
    getTimeMeasurement(): IMeasurement {
        return this;
    }

    getTime(): number {
        return this.currentTime()
    }

    getStep(): number {
        return this.step
    }

    setStep(time: number): void {
        this.step = time;
    }

    getMeasurementName(): string {
        return "Time";
    }

    getMeasurementType() {
        return 0;
    }

    getMeasurementValue() {
        return this.currentTime
    }



    actionT(t: number): void {
        if (!this.enabled) return;
        this.ct = t
        if (this.last > t) {
            this.last = t;
            this.startTime = t;
            return
        }
        this.action();
    }

    isEmptyActionT(): boolean {
        return false;
    }


    public setEngineEnabled(enabled: boolean): boolean {
        if (this.enabled == enabled) return false
        this.enabled = enabled
        this.last = Number.MAX_VALUE
        return true
    }


    public currentTime(): number {
        return this.ct - this.startTime
    }


    protected ct: number = 0

    protected start: number = 0

    protected step: number = 0




}