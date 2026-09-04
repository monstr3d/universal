import type { IActionAddRemoveT } from "../../Interfaces/IActionAddRemoveT";
import type { IPlayEngine } from "../../Interfaces/IPlayEngine";
import { ActionArrayT } from "../Generic/ActionArrayT";

export abstract class AbstractEngine implements IPlayEngine {
	constructor(interval: number) {
		this.interval = interval
	}

	isEngineEnabled(): boolean {
		return this.enabled
	}

	abstract setEngineEnabled(enabled: boolean): boolean

	getEngineAction(): IActionAddRemoveT<number> {
		return this.actionT;
	}

	public setTime(time: number): void {
		if (this.enabled) this.actionT.actionT(time)
	}

	currentTime(): number {
		const date = new Date()
		const t = date.getTime()
		return 0.001 * t
	}



	protected enabled: boolean = false

	protected actionT: IActionAddRemoveT<number> = new ActionArrayT()

	protected start: number = 0

	protected interval: number = 0;

}

