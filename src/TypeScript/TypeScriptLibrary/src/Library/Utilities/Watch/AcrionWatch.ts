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
		if ((t - this.last) < this.interval) return
		this.setTime(t)
		this.last = t
    }
	isEmptyAction(): boolean {
		return false
    }

	setEngineEnabled(enabled: boolean): boolean {
		if (this.enabled == enabled) return false
		this.enabled = enabled
		return true
	}

	protected last: number = Number.MAX_VALUE

}
