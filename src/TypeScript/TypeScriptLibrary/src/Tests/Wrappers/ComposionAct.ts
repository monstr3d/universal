import type { IAction } from "../../Library/Interfaces/IAction";
import type { IDataRuntime } from "../../Library/Interfaces/IDataRuntime";
import { IFactory } from "../../Library/Interfaces/IFactory";
import type { IDataConsumer } from "../../Library/Measurements/Interfaces/IDataConsumer";
import { PerformerMeasuremets } from "../../Library/Measurements/PerformerMeasuremets";
import { Motion6DFactory } from "../../Library/Motion6D/Motion6DFactory";
import { DataRuntimeConsumer } from "../../Library/Runtime/DataRuntimeConsumer";
import { DataRuntimeConsumerODE } from "../../Library/Runtime/DataRuntimeConsumerODE";
import { Composition } from "../Composition";

export class CompositionAct extends Composition implements IAction {
    dc!: IDataConsumer;
    factory: IFactory = new Motion6DFactory

    constructor() {
        super();
        var co = this.getCategoryObject("Chart")
        this.dc = co as unknown as IDataConsumer;
    }

    action(): void {
        var k = this.dc.getAllMeasurements();
        var a = k[0].getMeasurement(0).getMeasurementValue();
        console.log(a);
    }

    isEmptyAction(): boolean {
        return false
    }

    func(): boolean {
        return false;
    }

    public test(): void {
        var runtime: IDataRuntime = new DataRuntimeConsumerODE(this.dc, this.factory);
        var p = new PerformerMeasuremets();
        p.performFixedStepCalculation(runtime, 0, 1, 1000, this, this);
    }
}

        /*

        import { AliasName } from "../Library/AliasName";
import { BelongsToCollection } from "../Library/Arrows/BelognsToCollection";
import { Desktop } from "../Library/Desktop";
import { EventLink } from "../Library/Event/Objects/EventLink";
import { TimerObject } from "../Library/Event/Objects/TimerObject";
import { DataLink } from "../Library/Measurements/Arrows/DataLink";
import { DataConsumer } from "../Library/Measurements/DataConsumer";
import { VectorFormulaConsumer } from "../Library/Measurements/VectorFormulaConsumer";
import { TimeSpan } from "../Library/Utilities/DateTime/TimeSpan";
import { IAliasName } from "../Library/Interfaces/IAliasName";
import { IDesktop } from "../Library/Interfaces/IDesktop";
import { IPostSetArrow } from "../Library/Interfaces/IPostSetArrow";
import { IMeasurement } from "../Library/Measurements/Interfaces/IMeasurement";
*/