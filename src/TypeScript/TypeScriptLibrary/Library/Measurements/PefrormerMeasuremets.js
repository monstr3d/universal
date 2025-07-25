"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
exports.PefrormerMeasuremets = void 0;
const TimeMeasurementProvider_1 = require("./TimeMeasurementProvider");
const Performer_1 = require("../Performer");
class PefrormerMeasuremets {
    constructor() {
        this.performer = new Performer_1.Performer();
    }
    getDependentPrivate(dataConsumer, measurements) {
        let m = dataConsumer.getAllMeasurements();
        for (let i = 0; i < m.length; i++) {
            let mea = m[i];
            if (measurements.find(mea => true) === undefined) {
            }
            else {
                measurements.push(mea);
                let dc = mea;
                //     if (dc instanceof IDataConsumer)
            }
        }
    }
    peformFixedStepCalculation(runtime, start, step, steps, act) {
        var tm = new TimeMeasurementProvider_1.TimeMeasurementProvider();
        runtime.setTimeProvider(tm);
        var st = start;
        for (var i = 0; i < steps; i++) {
            tm.setTime(st);
            runtime.updateRuntime();
            act.action();
            st += step;
        }
    }
}
exports.PefrormerMeasuremets = PefrormerMeasuremets;
//# sourceMappingURL=PefrormerMeasuremets.js.map