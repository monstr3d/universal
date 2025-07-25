"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
exports.DetaRuntimeConsumer = void 0;
const OwnNotImplemented_1 = require("../ErrorHandler/OwnNotImplemented");
const Performer_1 = require("../Performer");
class DetaRuntimeConsumer {
    constructor(dataConsumer) {
        this.performer = new Performer_1.Performer();
        this.measurements = [];
        this.categoryObjects = [];
        this.cotegoryArrows = [];
        this.started = [];
        let nm = [];
        this.add(dataConsumer, nm);
        for (let i = nm.length - 1; i >= 0; i--) {
            var n = nm[i];
            this.measurements.push(nm[i]);
            if (this.performer.implementsType(n, "ICategoryObject")) {
                this.categoryObjects.push(n);
            }
            if (this.performer.implementsType(n, "IStarted")) {
                this.started.push(n);
            }
        }
        if (this.performer.implementsType(dataConsumer, "IMeasurements")) {
            this.measurements.push(dataConsumer);
        }
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
    refreshRuntime() {
        throw new OwnNotImplemented_1.OwnNotImplemented();
    }
    startRuntime(time) {
        for (let st of this.started) {
            st.startedStart(time);
        }
    }
    setTimeProvider(timeProvider) {
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
    getRumtimeObjects() {
        return this.categoryObjects;
        ;
    }
    getRunimeArrows() {
        return this.cotegoryArrows;
    }
    add(dc, measurements) {
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
                this.add(c, measurements);
            }
        }
        else {
        }
    }
}
exports.DetaRuntimeConsumer = DetaRuntimeConsumer;
//# sourceMappingURL=DetaRuntimeConsumer.js.map