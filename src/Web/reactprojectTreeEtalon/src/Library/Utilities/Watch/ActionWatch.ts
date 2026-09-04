import type { IAction } from "../../Interfaces/IAction"
import type { IActionAddRemove } from "../../Interfaces/IActionAddRemove"
import { AbstractEngine } from "./AbstracrtEngine"

export class ActionWatch extends AbstractEngine implements IAction {
	constructor(interval: number, external: IActionAddRemove) {
		super(interval)
		external.addAction(this)
	}

	action(): void {
		if (!this.enabled) return;
		let t = this.currentTime()
		if (t < this.last) {
			this.last = t;
			return
		}
		let d = t - this.last
		if (d < this.interval) return
		this.setTime(t - this.startTime)
		this.last = t
	}


	isEmptyAction(): boolean {
		return false
    }

	setEngineEnabled(enabled: boolean): boolean {
		if (this.enabled == enabled) return false
		this.enabled = enabled
		this.last = Number.MAX_VALUE
		this.startTime = this.currentTime()
		return true
	}

	protected last: number = Number.MAX_VALUE

	protected startTime: number = 0

}
