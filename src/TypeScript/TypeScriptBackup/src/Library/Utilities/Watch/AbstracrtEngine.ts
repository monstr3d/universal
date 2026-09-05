import { EmptyObject } from "../../EmptyObject";
import type { IActionAddRemoveT } from "../../Interfaces/IActionAddRemoveT";
import type { IPlayEngine } from "../../Interfaces/IPlayEngine";
import { ActionArrayT } from "../Generic/ActionArrayT";

export abstract class AbstractEngine extends EmptyObject implements IPlayEngine {
	constructor(interval: number) {
		super("")
		this.interval = interval
		this.typeName = "AbstractEngine"
		this.types.push("IPlayEngine")
		this.types.push("AbstractEngine")
	}

	isEngineEnabled(): boolean {
		return this.enabled
	}

	abstract setEngineEnabled(enabled: boolean): boolean

	getEngineAction(): IActionAddRemoveT<number> {
		return this.actionTime;
	}

	public setTime(time: number): void {
		if (this.enabled) this.actionTime.actionT(time)
	}

	currentTime(): number {
		const date = new Date()
		const t = date.getTime()
		return 0.001 * t
	}



	protected enabled: boolean = false

	protected actionTime: IActionAddRemoveT<number> = new ActionArrayT()

	protected start: number = 0

	protected interval: number = 0;

}

