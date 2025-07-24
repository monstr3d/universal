"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
exports.DetaRuntimeConsumer = void 0;
const OwnNotImplemented_1 = require("../ErrorHandler/OwnNotImplemented");
const Performer_1 = require("../Performer");
class DetaRuntimeConsumer {
    constructor(dataConsumer) {
        this.performer = new Performer_1.Performer();
        this.measurements = [];
        let nm = [];
        this.add(dataConsumer, nm);
        for (let i = nm.length - 1; i >= 0; i--) {
            this.measurements.push(nm[i]);
        }
        if (this.performer.implementsType(dataConsumer, "IMeasurements")) {
            this.measurements.push(dataConsumer);
        }
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
        throw new OwnNotImplemented_1.OwnNotImplemented();
    }
    setTimeProvider(timeProvider) {
        let n = this.measurements.length;
        for (let i = 0; i < n; i++) {
            let m = this.measurements[i];
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
        throw new OwnNotImplemented_1.OwnNotImplemented();
    }
    getRunimeArrows() {
        throw new OwnNotImplemented_1.OwnNotImplemented();
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