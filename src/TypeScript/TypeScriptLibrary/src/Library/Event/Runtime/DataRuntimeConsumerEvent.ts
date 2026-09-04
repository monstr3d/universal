import type { IAction } from "../../Interfaces/IAction";
import type { IActionAddRemove } from "../../Interfaces/IActionAddRemove";
import type { ICategoryObject } from "../../Interfaces/ICategoryObject";
import type { IComponentCollection } from "../../Interfaces/IComponentCollection";
import type { IEvent } from "../../Interfaces/IEvent";
import type { IEventHandler } from "../../Interfaces/IEventHandler";
import type { IExternalUpdate } from "../../Interfaces/IExternalUpdate";
import type { IExternalUpdateClient } from "../../Interfaces/IExternalUpdateClient";
import type { IFactory } from "../../Interfaces/IFactory";
import type { IObject } from "../../Interfaces/IObject";
import type { IRealtimeCollection } from "../../Interfaces/IRealtimeCollection";
import type { ITimerFactory } from "../../Interfaces/ITimerFactory";
import type { IDataConsumer } from "../../Measurements/Interfaces/IDataConsumer";
import type { ITimeMeasurementProvider } from "../../Measurements/Interfaces/ITimeMeasurementProvider";
import { DataRuntimeConsumerODE } from "../../Runtime/DataRuntimeConsumerODE";
import { ActionArray } from "../../Utilities/Generic/ActionArray";
import { PerformerEvents } from "../PerformerEvents";

export class DataRuntimeConsumerEvent extends DataRuntimeConsumerODE implements IRealtimeCollection,
    IExternalUpdate
{

    protected ePerformer: PerformerEvents = new PerformerEvents()

    protected isEnabled: boolean = false

    constructor(dataConsumer: IDataConsumer, factory: IFactory) {
        super(dataConsumer, factory)
        this.typeName = "DataRuntimeConsumerEvent"
        this.types.push("IRealtimeCollection")
        this.types.push("IExternalUpdate")
        this.types.push("DataRuntimeConsumerEvent")
        var up = this.dataConsumer as unknown as IExternalUpdateClient
        var ob = this.dataConsumer as unknown as IObject;
        let a: IActionAddRemove = new ActionArray()
        this.getExternalUpdate(ob, this, a)
        up.setExternalUpdate(a)
    }

    getExternalUpdate(obj: IObject | undefined, realime: IRealtimeCollection, action: IActionAddRemove): void {
        this.mPerformer.createUpdateMeasurementsAction(this, action)
        this.act = action
        this.fo = obj
        this.fre = realime
    }

    act !: IAction
    fo !: IObject | undefined

    fre !: IRealtimeCollection

    protected prepare(dataConsumer: IDataConsumer) {
        super.prepare(dataConsumer)
        let x = this.performer.convertObject<IEventHandler, IDataConsumer>(dataConsumer, "IEventHandler")
        if (x.length == 0) return
        let evetns = x[0].getEventHandlerEvents()
        for (let event of evetns) {
            let y = this.performer.convertObject<ICategoryObject, IEvent>(event, "ICategoryObject")
            if (y.length > 0) {
                let z = y[0]
                if (!this.categoryObjects.includes(z)) {
                    this.categoryObjects.push(z)
                }
            }
        }

    }

    getComponentCollection(): IComponentCollection {
        return this
    }
    setComponentCollection(collection: IComponentCollection): void {
        this.fc = collection
    }

    protected fc !: IComponentCollection

    isComponentCollectionRunning(): boolean {
        return this.isEnabled
    }

    setComponentCollectionRunning(running: boolean): void {
        if (this.isEnabled == running) return
        this.isEnabled = running
        this.ePerformer.setComponentCollectionEnabled(this, running)
    }

    public setTimerFactory(timerFactory: ITimerFactory): void {
        this.ePerformer.setComponentCollectionTimer(this, timerFactory);
    }

    public setTimeProvider(timeProvider: ITimeMeasurementProvider): void {
        this.mPerformer.setTimeProviderCollection(this, timeProvider)
        this.processor.setDifferentialEquationsTimeProvider(timeProvider)
    }
}