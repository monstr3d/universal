import type { IAction } from "../../Library/Interfaces/IAction";
import type { IFunc } from "../../Library/Interfaces/IFunc";
import type { IDataConsumer } from "../../Library/Measurements/Interfaces/IDataConsumer";
import { PefrormerMeasuremets } from "../../Library/Measurements/PefrormerMeasuremets";
import { Performer } from "../../Library/Performer";
import { DataRuntimeConsumer } from "../../Library/Runtime/DataRuntimeConsumer";
import type { IDataRuntime } from "../../Library/Runtime/Interfaces/IDataRuntime";
import { RecursiveFeedback } from "../RecursiveFeedback";


export class RecursvieFeedbackAct extends RecursiveFeedback implements IAction, IFunc<boolean> {
    dc !: IDataConsumer;
    constructor() {
        super();
        this.dc = this.performer.getByType(this, "DataConsumer")[0] as unknown as IDataConsumer;
    }
    func(): boolean {
        return false;
    }

    action(): void {

        this.performer.print(this.dc);
    }

    performer: Performer = new Performer();

    public test(): void {
        var runtime: IDataRuntime = new DataRuntimeConsumer(this.dc);
        var p: PefrormerMeasuremets = new PefrormerMeasuremets();
        p.performFixedStepCalculation(runtime, 0, 0.1, 30, this, this);
    }
}