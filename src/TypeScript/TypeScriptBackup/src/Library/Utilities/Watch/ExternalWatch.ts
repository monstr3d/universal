import { ActionWatch } from "./ActionWatch";
import { IActionAddRemove } from "../../Interfaces/IActionAddRemove";
import { IActionT } from "../../Interfaces/IActionT";

export class ExternalWatch extends ActionWatch implements IActionT<number> {

    constructor(interval: number, external: IActionAddRemove) {
        super(interval, external)
    }

    actionT(t: number): void {
        if (!this.enabled) return;
        this.ct = t
        if (this.last > t) {
            this.last = t;
            this.startTime = t;
            this.setTime(t)
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


}