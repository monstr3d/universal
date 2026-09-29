import type { IAction } from "../Interfaces/IAction";
import type { IMeasurements } from "./Interfaces/IMeasurements";

export class UpdateMeasurementsAction implements IAction {
    action(): void {
       this.m.updateMeasurements()
    }

    isEmptyAction(): boolean { return false }

    constructor(m: IMeasurements) {
        this.m = m;
    }

    m !: IMeasurements

}