import type { IActionAddRemoveT } from "../../Interfaces/IActionAddRemoveT";
import type { IPlayEngine } from "../../Interfaces/IPlayEngine";
import { ActionArrayT } from "../Generic/ActionArrayT";

export class EngineWatch implements IPlayEngine {

    constructor(interval: number) {
        this.interval = interval
    }

    isEngineEnabled(): boolean {
        return this.enabled
    }
    setEngineEnabled(enabled: boolean): boolean {
        if (enabled == this.enabled) return false;
        this.enabled = enabled
        if (enabled) {
            const tick = () => {
                var t = this.currentTime() - this.start
                this.setTime(t);
            }
            this.start = this.currentTime()
            this.timerID = setInterval(() => tick(), this.interval);

        }
        else {
            clearInterval(this.timerID);

        }
        return true
    }
    getEngineAction(): IActionAddRemoveT<number> {
        return this.action;
    }


    public setTime(time: number): void {
        if (this.enabled) this.action.actionT(time)
    }

    currentTime(): number {
        const date = new Date()
        const t = date.getTime()
        return 0.001 * t

    }

    

    enabled: boolean = false

    action: IActionAddRemoveT<number> = new ActionArrayT()

    timerID: any = 0

    start: number = 0

    interval: number = 0;

}