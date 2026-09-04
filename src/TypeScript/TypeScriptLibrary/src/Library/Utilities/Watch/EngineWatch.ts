import { AbstractEngine } from "./AbstracrtEngine";

export class EngineWatch extends AbstractEngine  {

	constructor(interval: number) {
		super(interval)
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


	protected timerID: any = 0


}
