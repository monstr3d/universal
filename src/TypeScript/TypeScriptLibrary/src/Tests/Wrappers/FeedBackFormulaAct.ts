// FeedBackFormulaAct.ts
// Wrapper for FeedBackFormulaAct logic

import { IAction } from "../../Library/Interfaces/IAction";
import { IDataRuntime } from "../../Library/Interfaces/IDataRuntime";
import { IFactory } from "../../Library/Interfaces/IFactory";
import { IFunc } from "../../Library/Interfaces/IFunc";
import { IDataConsumer } from "../../Library/Measurements/Interfaces/IDataConsumer";
import { PerformerMeasuremets } from "../../Library/Measurements/PerformerMeasuremets";
import { Motion6DFactory } from "../../Library/Motion6D/Motion6DFactory";
import { Performer } from "../../Library/Performer";
import { DataRuntimeConsumer } from "../../Library/Runtime/DataRuntimeConsumer";
import { DataRuntimeConsumerODE } from "../../Library/Runtime/DataRuntimeConsumerODE";
import { FeedBackFormula } from "../FeedBackFormula";


export class FeedBackFormulaAct extends FeedBackFormula implements IAction, IFunc<boolean> {
    dc !: IDataConsumer;
    factory: IFactory = new Motion6DFactory

    constructor() {
        super();
        this.dc = this.performer.getByType(this, "DataConsumer")[0] as unknown as IDataConsumer;
    }
    isEmptyAction(): boolean {
        return false;
    }
    func(): boolean {
        return false;
    }

    action(): void {

        this.performer.print(this.dc);
      }

    performer: Performer = new Performer();

    public test(): void {
        var runtime: IDataRuntime = new DataRuntimeConsumerODE(this.dc, this.factory);
        var p: PerformerMeasuremets = new PerformerMeasuremets();
        p.performFixedStepCalculation(runtime, 0, 0.1, 30, this, this);
    }
}