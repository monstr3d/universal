import { IAction } from "../../Library/Interfaces/IAction";
import { IDataRuntime } from "../../Library/Interfaces/IDataRuntime";
import { IFunc } from "../../Library/Interfaces/IFunc";
import { IDataConsumer } from "../../Library/Measurements/Interfaces/IDataConsumer";
import { PerformerMeasuremets } from "../../Library/Measurements/PerformerMeasuremets";
import { Performer } from "../../Library/Performer";
import { DataRuntimeConsumer } from "../../Library/Runtime/DataRuntimeConsumer";
import { DonchianDesktop } from "../DonchianDesktop";

export class DonchianDesktopAct extends DonchianDesktop implements IAction, IFunc<boolean> {
    dc!: IDataConsumer;


    constructor() {
        super();
        this.dc = this.performer.getByType(this, "DataConsumer")[0] as unknown as IDataConsumer;
    }
    isEmptyAction(): boolean {
        return false
    }
    func(): boolean {
        return false;
    }

    action(): void {

        this.performer.print(this.dc);
    }

    performer: Performer = new Performer();

    public test(): void {
        var runtime: IDataRuntime = new DataRuntimeConsumer(this.dc, this.factory);
        var p: PerformerMeasuremets = new PerformerMeasuremets();
        p.performFixedStepCalculation(runtime, 0, 0.1, 5, this, this);
    }
}
