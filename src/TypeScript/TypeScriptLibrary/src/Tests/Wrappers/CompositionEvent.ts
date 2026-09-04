import { DataRuntimeConsumerEvent } from "../../Library/Event/Runtime/DataRuntimeConsumerEvent";
import { Composition } from "../Composition";
import type { IDataConsumer } from "../../Library/Measurements/Interfaces/IDataConsumer";
import { IEvent } from "../../Library/Interfaces/IEvent";
import { IAction } from "../../Library/Interfaces/IAction";
import { IFunc } from "../../Library/Interfaces/IFunc";
import { IPlayEngine } from "../../Library/Interfaces/IPlayEngine";


export class CompositionEvent extends Composition {
    dc!: IDataConsumer;

    eve !: DataRuntimeConsumerEvent

    engine !: IPlayEngine;

    ev !: IEvent

    stop !: IFunc<boolean>

    constructor(engine: IPlayEngine) {
        super()
        var co = this.getCategoryObject("Chart")
        this.ev = this.getCategoryObject("Timer") as unknown as IEvent;
        this.dc = co as unknown as IDataConsumer
 /*       let eev = new DataRuntimeConsumerEvent(this.dc);
        eev.setTimeProvider(new EngineTimerProvider(engine))
        eev.setTimerFactory(new TimerPlayEngineFactory(engine))
        this.engine = engine;
        this.eve = eev*/
    }

    public test(): void {
        new Action(this.dc, this.ev)
        this.eve.startRuntime(0)
        this.eve.setComponentCollectionRunning(true)
  //      this.engine.setEngineEnabled(true)
    }
}

class Action implements IAction {
    action(): void {
        var m = this.dc.getAllMeasurements();
        var x = m[0]
        var y = [x.getMeasurement(0).getMeasurementValue(), x.getMeasurement(1).getMeasurementValue()]
        console.log(y)
    }
isEmptyAction(): boolean {
    return false
}

    dc!: IDataConsumer;

    constructor(dc: IDataConsumer, event: IEvent) {
        this.dc = dc;
        event.eventAction().addAction(this)
    }


}