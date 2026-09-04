"use strict";
/* eslint-disable no-var */
/* eslint-disable @typescript-eslint/no-unused-vars */
/* eslint-disable @typescript-eslint/no-explicit-any */
Object.defineProperty(exports, "__esModule", { value: true });
exports.DataRuntimeConsumer = void 0;
const Performer_1 = require("../Performer");
const PerformerMeasuremets_1 = require("../Measurements/PerformerMeasuremets");
const EmptyObject_1 = require("../EmptyObject");
class DataRuntimeConsumer extends EmptyObject_1.EmptyObject {
    name = "";
    addRemove = [];
    performer = new Performer_1.Performer();
    mPerformer = new PerformerMeasuremets_1.PerformerMeasuremets();
    timeProvider;
    measurements = [];
    categoryObjects = [];
    categoryObjectsMap = new Map();
    categoryArrows = [];
    started = [];
    objects = [];
    dataConsumer;
    factory;
    /*
        protected typeName: string = "CategoryArrow";

    protected types: string[] = ["IObject", "IComponentCollection", "IDataRuntime",
        "DataRuntimeConsumer", "IFactoryConsumer"];
*/
    constructor(dataConsumer, factory) {
        super("");
        this.typeName = "DataRuntimeConsumer";
        let tt = ["IComponentCollection", "IDataRuntime",
            "DataRuntimeConsumer", "IFactoryConsumer"];
        for (let x of tt) {
            this.types.push(x);
        }
        this.factory = factory;
        this.dataConsumer = dataConsumer;
        this.prepare(dataConsumer);
        this.objects = [];
        this.performer.getAllIObjects(this.categoryObjects, this.categoryArrows, this.objects);
    }
    setConsumerFactory(factory) {
        this.factory = factory;
    }
    getConsumerFactory() {
        return this.factory;
    }
    prepare(dataConsumer) {
        let arem = this.performer.convertObject(dataConsumer, "IAddRemove");
        if (arem.length > 0) {
            this.addRemove = arem[0].getAddRemoveObjects();
        }
        let nm = [];
        this.addDataConsumer(dataConsumer, nm);
        for (let i = nm.length - 1; i >= 0; i--) {
            var n = nm[i];
            this.measurements.push(nm[i]);
            if (this.performer.implementsType(n, "ICategoryObject")) {
                this.addCategoryObjectToRuntime(n);
            }
            if (this.performer.implementsType(n, "IStarted")) {
                this.started.push(n);
            }
        }
        if (this.performer.implementsType(dataConsumer, "IMeasurements")) {
            this.measurements.push(dataConsumer);
        }
        this.measurements = this.performer.sortMeasurements(this.measurements);
        var ehc = dataConsumer;
        if (ehc != undefined) {
            var evs = ehc.getEventHandlerEvents();
            for (let evt of evs) {
                var cov = evt;
                if (cov != undefined) {
                    if (!this.categoryObjects.includes(cov)) {
                        this.categoryObjects.push(cov);
                    }
                }
            }
        }
        this.performer.addUnique(this.categoryObjects, dataConsumer);
    }
    getCategoryObjects() {
        return this.categoryObjects;
    }
    getCategoryArrows() {
        return this.categoryArrows;
    }
    getObjectCollection() {
        return this.objects;
    }
    getCategoryObject(name) {
        let a = this.categoryObjectsMap.get(name);
        if (a != undefined)
            return a;
        return undefined;
    }
    addCategoryObjectToRuntime(object) {
        this.categoryObjects.push(object);
        var n = object.getCategoryObjectName();
        this.categoryObjectsMap.set(n, object);
    }
    getRuntimeObject(name) {
        return this.categoryObjectsMap.get(name);
    }
    getStarted() {
        return this.started;
    }
    updateRuntime() {
        let n = this.measurements.length;
        for (let i = 0; i < n; i++) {
            this.measurements[i].updateMeasurements();
        }
    }
    stepRuntime(begin, end) {
    }
    refreshRuntime() {
    }
    startRuntime(time) {
        for (let st of this.started) {
            st.startedStart(time);
        }
    }
    setTimeProvider(timeProvider) {
        this.timeProvider = timeProvider;
        this.mPerformer.setTimeProvider(timeProvider, this.measurements);
    }
    getTimeProvider() {
        return this.timeProvider;
    }
    getRuntimeObjects() {
        return this.categoryObjects;
    }
    getRuntimeArrows() {
        return this.categoryArrows;
    }
    addDataConsumer(dc, measurements) {
        var m = dc.getAllMeasurements();
        var n = m.length;
        if (n != 0) {
            for (let i = 0; i < n; i++) {
                let mea = m[i];
                if (measurements.indexOf(mea) >= 0) {
                    continue;
                }
                measurements.push(mea);
                if (!this.performer.implementsType(mea, "IDataConsumer")) {
                    continue;
                }
                let c = mea;
                this.addDataConsumer(c, measurements);
            }
        }
        else {
        }
    }
}
exports.DataRuntimeConsumer = DataRuntimeConsumer;
