"use strict";
/* eslint-disable no-var */
/* eslint-disable @typescript-eslint/no-unused-vars */
/* eslint-disable @typescript-eslint/no-explicit-any */
Object.defineProperty(exports, "__esModule", { value: true });
exports.DataRuntimeConsumer = void 0;
const OwnNotImplemented_1 = require("../ErrorHandler/OwnNotImplemented");
const Performer_1 = require("../Performer");
class DataRuntimeConsumer {
    constructor(dataConsumer) {
        this.performer = new Performer_1.Performer();
        this.measurements = [];
        this.categoryObjects = [];
        this.categoryObjectsMap = new Map();
        this.categoryArrows = [];
        this.started = [];
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
        throw new OwnNotImplemented_1.OwnNotImplemented();
    }
    startRuntime(time) {
        for (let st of this.started) {
            st.startedStart(time);
        }
    }
    setTimeProvider(timeProvider) {
        this.timeProvider = timeProvider;
        for (let m of this.measurements) {
            if (this.performer.implementsType(m, "ITimeMeasurementConsumer")) {
                let tm = m;
                tm.setTimeMeasurement(timeProvider);
            }
        }
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
//# sourceMappingURL=DataRuntimeConsumer.js.map