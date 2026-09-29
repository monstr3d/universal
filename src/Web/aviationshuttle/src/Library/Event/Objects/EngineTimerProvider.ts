import { OwnNotImplemented } from "../../ErrorHandler/OwnNotImplemented";
import { PerformerEvents } from "../PerformerEvents";
import type { IActionT } from "../../Interfaces/IActionT";
import type { IPlayEngine } from "../../Interfaces/IPlayEngine";
import type { IMeasurement } from "../../Measurements/Interfaces/IMeasurement";
import type { ITimeMeasurementProvider } from "../../Measurements/Interfaces/ITimeMeasurementProvider";

export class EngineTimerProvider implements IMeasurement, ITimeMeasurementProvider,
    IActionT<number> {

    timeScale: number = 1;
    constructor(playEngine: IPlayEngine) {
        this.playEngine = playEngine
        playEngine.getEngineAction().addActionT(this)
        this.timeScale = PerformerEvents.getTimeScale()
    }

    actionT(t: number): void {
        this.currentTime = t * this.timeScale
    }

    isEmptyActionT(): boolean { return false }


    getTimeMeasurement(): IMeasurement {
        return this
    }

    getTime(): number {
        return this.currentTime
    }

    setTime(time: number): void {
        this.currentTime = time
    }

    getStep(): number {
        throw new OwnNotImplemented("getStep ENGINE");
    }
    setStep(time: number): void {
        this.currentTime = time
    }


    getMeasurementName(): string {
        return "Time"
    }

    getMeasurementType() {
        return 0
    }

    getMeasurementValue() {
        return this.currentTime
    }

    currentTime: number = 0

    playEngine !: IPlayEngine;

}