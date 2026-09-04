/* eslint-disable no-var */
/* eslint-disable @typescript-eslint/no-unused-vars */
/* eslint-disable @typescript-eslint/no-explicit-any */

import { Performer } from "../Performer";
import { PerformerMeasuremets } from "../Measurements/PerformerMeasuremets"
import type { IDataConsumer } from "../Measurements/Interfaces/IDataConsumer";
import type { IMeasurements } from "../Measurements/Interfaces/IMeasurements";
import type { ITimeMeasurementProvider } from "../Measurements/Interfaces/ITimeMeasurementProvider";
import type { IStarted } from "../Measurements/Interfaces/IStarted";
import type { IAddRemove } from "../Interfaces/IAddRemove";
import type { ICategoryArrow } from "../Interfaces/ICategoryArrow";
import type { ICategoryObject } from "../Interfaces/ICategoryObject";
import type { IComponentCollection } from "../Interfaces/IComponentCollection";
import type { IDataRuntime } from "../Interfaces/IDataRuntime";
import type { IEventHandler } from "../Interfaces/IEventHandler";
import type { IObject } from "../Interfaces/IObject";
import type { IFactory } from "../Interfaces/IFactory";
import type { IFactoryConsumer } from "../Interfaces/IFactoryConsumer";
import { EmptyObject } from "../EmptyObject";

export  class DataRuntimeConsumer extends EmptyObject implements IDataRuntime, IComponentCollection,  IFactoryConsumer
{

    protected name: string = "";

    protected addRemove: ICategoryObject[] = []

    protected performer: Performer = new Performer();


    protected mPerformer: PerformerMeasuremets = new PerformerMeasuremets()

    protected timeProvider !: ITimeMeasurementProvider;

    protected measurements: IMeasurements[] = [];

    protected categoryObjects: ICategoryObject[] = [];

    protected categoryObjectsMap: Map<string, ICategoryObject> = new Map();


    protected categoryArrows: ICategoryArrow[] = [];

    protected started: IStarted[] = [];

    protected objects: IObject[] = []

    protected dataConsumer: IDataConsumer

    protected factory !: IFactory
    constructor(dataConsumer: IDataConsumer, factory: IFactory)
    {
        super("")
        this.typeName = "DataRuntimeConsumer"
        let tt  : string[] = [ "IComponentCollection", "IDataRuntime",
            "DataRuntimeConsumer", "IFactoryConsumer"];
        for (let x of tt) {
            this.types.push(x)
        }
        this.factory = factory
        this.dataConsumer = dataConsumer;
        this.prepare(dataConsumer)
        this.objects = []
        this.performer.getAllIObjects(this.categoryObjects, this.categoryArrows, this.objects)
    }

 
    setConsumerFactory(factory: IFactory): void {
        this.factory = factory
    }
    getConsumerFactory(): IFactory {
        return this.factory
    }

    protected prepare(dataConsumer: IDataConsumer): void {
        let arem = this.performer.convertObject<IAddRemove, IDataConsumer>(dataConsumer, "IAddRemove");
        if (arem.length > 0) {
            this.addRemove = arem[0].getAddRemoveObjects()
        }
        let nm: IMeasurements[] = [];
        this.addDataConsumer(dataConsumer, nm);
        for (let i = nm.length - 1; i >= 0; i--) {
            var n = nm[i];
            this.measurements.push(nm[i]);
            if (this.performer.implementsType(n, "ICategoryObject")) {
                this.addCategoryObjectToRuntime(n as unknown as ICategoryObject);
            }
            if (this.performer.implementsType(n, "IStarted")) {
                this.started.push(n as unknown as IStarted);
            }

        }
        if (this.performer.implementsType(dataConsumer, "IMeasurements")) {
            this.measurements.push(dataConsumer as unknown as IMeasurements);
        }

        this.measurements = this.performer.sortMeasurements(this.measurements);
        var ehc = dataConsumer as unknown as IEventHandler
        if (ehc != undefined) {
            var evs = ehc.getEventHandlerEvents()
            for (let evt of evs) {
                var cov = evt as unknown as ICategoryObject
                if (cov != undefined) {
                    if (!this.categoryObjects.includes(cov)) {
                        this.categoryObjects.push(cov)
                    }
                }
            }
        }
        this.performer.addUnique(this.categoryObjects, dataConsumer as unknown as ICategoryObject)
    }

    getCategoryObjects(): ICategoryObject[] {
        return this.categoryObjects
    }

    getCategoryArrows(): ICategoryArrow[] {
        return this.categoryArrows;
    }

    getObjectCollection(): IObject[] {
        return this.objects;
    }

    getCategoryObject(name: string): ICategoryObject | undefined{
        let a = this.categoryObjectsMap.get(name)
        if (a != undefined) return a;
        return undefined
    }

    addCategoryObjectToRuntime(object: ICategoryObject): void {
        this.categoryObjects.push(object);
        var n = object.getCategoryObjectName();
        this.categoryObjectsMap.set(n, object);
    }


    getRuntimeObject(name: string): ICategoryObject
    {
        return this.categoryObjectsMap.get(name) as ICategoryObject;
    }

    getStarted(): IStarted[]
    {
        return this.started;
    }

    updateRuntime(): void
    {
        let n = this.measurements.length;
        for (let i = 0; i < n; i++)
        {
            this.measurements[i].updateMeasurements();
        }
    }

    stepRuntime(begin: number, end: number): void {
        this.any = begin
        this.any = end
    }

    refreshRuntime(): void {
    }

    startRuntime(time: number): void
    {
        for (let st of this.started)
        {
            st.startedStart(time);
        }
    }

    setTimeProvider(timeProvider: ITimeMeasurementProvider): void
    {
        this.timeProvider = timeProvider;
        this.mPerformer.setTimeProvider(timeProvider, this.measurements)
    }


    getTimeProvider(): ITimeMeasurementProvider
    {
        return this.timeProvider;
    }

    getRuntimeObjects(): ICategoryObject[]
    {
        return this.categoryObjects;
    }

    getRuntimeArrows(): ICategoryArrow[]
    {
        return this.categoryArrows;
    }

    any : any
 
    addDataConsumer(dc: IDataConsumer, measurements: IMeasurements[]): void
    {
        var m = dc.getAllMeasurements();
        var n = m.length;
        if (n != 0)
        {
            for (let i = 0; i < n; i++)
            {
                let mea = m[i];
                if (measurements.indexOf(mea) >= 0) {
                    continue;
                }
                measurements.push(mea);
                if (!this.performer.implementsType(mea, "IDataConsumer")) {
                    continue;
                }
                let c: IDataConsumer = mea as unknown as IDataConsumer;
                this.addDataConsumer(c, measurements);

            }
        }
        else
        {

        }
    }
}


