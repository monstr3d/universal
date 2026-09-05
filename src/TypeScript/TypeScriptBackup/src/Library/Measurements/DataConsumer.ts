import { CategoryObject } from "../CategoryObject";
import { ActionArray } from "../Utilities/Generic/ActionArray";
import { PerformerMeasuremets } from "./PerformerMeasuremets";
import type { IAction } from "../Interfaces/IAction";
import type { IActionAddRemove } from "../Interfaces/IActionAddRemove";
import type { IAddRemove } from "../Interfaces/IAddRemove";
import type { ICategoryObject } from "../Interfaces/ICategoryObject";
import type { ICheck } from "../Interfaces/ICheck";
import type { ICheckHolder } from "../Interfaces/ICheckHolder";
import type { IDesktop } from "../Interfaces/IDesktop";
import type { IEvent } from "../Interfaces/IEvent";
import type { IEventHandler } from "../Interfaces/IEventHandler";
import type { IPostSetArrow } from "../Interfaces/IPostSetArrow";
import type { IPrintedObject } from "../Interfaces/IPrintedObject";
import type { IPrinter } from "../Interfaces/IPrinter";
import type { IDataConsumer } from "./Interfaces/IDataConsumer";
import type { IIterator } from "./Interfaces/IIterator";
import type { IIteratorConsumer } from "./Interfaces/IIteratorConsumer";
import type { IMeasurements } from "./Interfaces/IMeasurements";
import type { ITimeMeasurementConsumer } from "./Interfaces/ITimeMeasurementConsumer";
import type { ITimeMeasurementProvider } from "./Interfaces/ITimeMeasurementProvider";
import type { IEventStart } from "../Interfaces/IEventStart";
import type { IExternalUpdateClient } from "../Interfaces/IExternalUpdateClient";
import type { IMeasurement } from "./Interfaces/IMeasurement";
import type { IShowObject } from "../Show/Interfaces/IShowObject";

export class DataConsumer extends CategoryObject implements IDataConsumer, IPostSetArrow,
    ITimeMeasurementConsumer, IPrintedObject, ICheckHolder, IIteratorConsumer, IEventHandler, IAddRemove, IAction,
    IEventStart, IExternalUpdateClient
{
    constructor(desktop: IDesktop, name: string) {
        super(desktop, name)
        this.typeName = "DataConsumer";
        this.types.push("DataConsumer");
        this.types.push("IDataConsumer");
        this.types.push("IPostSetArrow");
        this.types.push("ITimeMeasurementConsumer");
        this.types.push("IPrintedObject");
        this.types.push("ICheckHolder");
        this.types.push("IIteratorConsumer");
        this.types.push("IEventHandler");
        this.types.push("IEventStart");
        this.types.push("IAddRemove");
        this.tms = this;
        this.dataConsumer = this;
        this.currentAction = this.fictiveAvtion;
        let f = this.detectFactory();
        if (f === undefined)
            this.pMeasurements = new PerformerMeasuremets()
        else {
            this.pMeasurements = new PerformerMeasuremets(f)
            let s = f.getFactory<IShowObject>("IShowObject")
            if (s !== undefined) this.show = s;
        }
    }
 
    setExternalUpdate(action: IActionAddRemove | undefined): void {
        this.eventAction.clearActions();
        if (action === undefined) {
            return;
        }
        this.eventAction.addAction(action)
    }

    isEventEnabled(): boolean {
        return this.isEvEnabled
    }

    isEmptyAction(): boolean { return false }

    setEventEnabled(enabled: boolean): void {
        if (enabled == this.isEvEnabled) return
        this.isEvEnabled = enabled
       if (enabled) {
            this.currentAction = this.eventAction
            return
        }
        this.currentAction = this.fictiveAvtion
    }

    action(): void {
        this.currentAction.action();
  }

    getAddRemoveType(): string {
        return ""
    }

    getEventHandlerEvents(): IEvent[] {
        return this.externalEvents
    }

    addChildT(child: IEvent): void
    {
        this.fchild = child
    }

    fchild !: IEvent


    addEventToHandler(event: IEvent): void {
        var ev = this.performer.convertObject(event, "IEvent")
        if (ev.length == 0) return
        this.performer.addUnique(this.externalEvents, event)
    }


    resetDataConsumer(): void {
    }

    addIterator(iterator: IIterator): void {
        this.iterator = iterator;
    }
    removeIterator(iterator: IIterator): void {
        this.fi = iterator
    }

    fi !: IIterator

    getCheck(): ICheck {
        return this.checker;
    }
    setCheck(check: ICheck): void {
        this.checker = check;
    }

    print(printer: IPrinter): void {
        for (var m of this.measurements) {
            let co = m as unknown as ICategoryObject;
            let s = co.getCategoryObjectName() + "\t";
            let n = m.getMeasurementsCount();
            for (let i = 0; i < n; i++) {
                var mm = m.getMeasurement(i);
                var v = mm.getMeasurementValue();
                s += v + "\t";
            }
            printer.print(s);
        }
    }

    getInternalTime(): number
    {
        var tm = this.timeMeasurement;
        return tm.getTime();
    }

    
    getTimeMeasurement(): ITimeMeasurementProvider {
        return this.timeMeasurement;
    }

    setTimeMeasurement(measurement: ITimeMeasurementProvider): void {
        this.timeMeasurement = measurement;            ;
    }

    postSetArrow(): void {
        for (let event of this.externalEvents) {
            let ea = event.eventAction();
            ea.addAction(this)
        }
    }
   
    getAllMeasurements(): IMeasurements[] {
        return this.measurements;
    }

    addMeasurements(item: IMeasurements): void {
        this.measurements.push(item);
    }

    addRemoveObject(object: ICategoryObject, add: boolean): boolean {
        if (add) this.addRemoveobjects.push(object)
        return true
    }
    getAddRemoveObjects(): ICategoryObject[] {
        return this.addRemoveobjects;
    }

    public toNullabe(m: IMeasurement): number | undefined {
        return this.pMeasurements.toNullabeMeasurement(m)
    }

    addRemoveobjects: ICategoryObject[] = []


    private measurements: IMeasurements[] = [];


    isEvEnabled: boolean = false;

    show !: IShowObject

    tms!: ITimeMeasurementConsumer;

    timeMeasurement !: ITimeMeasurementProvider;

    success: boolean = true;

    protected dataConsumer !: IDataConsumer;

    protected iterator !: IIterator;

    protected eventAction: IActionAddRemove = new ActionArray()

    protected basicAction: IActionAddRemove = new ActionArray()

    protected fictiveAvtion: IActionAddRemove = new ActionArray()

    protected currentAction: IActionAddRemove = new ActionArray()

    protected externalEvents: IEvent[] = []

    protected pMeasurements !: PerformerMeasuremets


}

