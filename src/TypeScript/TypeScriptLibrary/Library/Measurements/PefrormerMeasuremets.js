"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
exports.PefrormerMeasuremets = void 0;
const Performer_1 = require("../Performer");
const DataConsumerBoolFunc_1 = require("./DataConsumerBoolFunc");
const TimeMeasurementProvider_1 = require("./TimeMeasurementProvider");
class PefrormerMeasuremets {
    constructor() {
        this.performer = new Performer_1.Performer();
    }
    getArrayMeasurements(array) {
        var n = array.getMeasurementNames().length;
        var mea = [];
        for (var i = 0; i < n; i++) {
            //  mea.push(new ArrayMeasurement(array, i));
        }
        return mea;
    }
    initStart(array, x) {
        var n = x.length;
        var y = array.getMeasurementValues();
        for (var i = 0; i < n; i++) {
            y[i] = x[i];
        }
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
    peformCondDCFixedStepCalculation(runtime, dataConsumer, conditionName, stop, start, step, steps, act) {
        var cond = new DataConsumerBoolFunc_1.DataConsumerBoolFunc(dataConsumer, conditionName);
        this.peformCondFixedStepCalculation(runtime, cond, stop, start, step, steps, act);
    }
    peformCondFixedStepCalculation(runtime, condition, stop, start, step, steps, act) {
        var tm = new TimeMeasurementProvider_1.TimeMeasurementProvider();
        runtime.setTimeProvider(tm);
        runtime.startRuntime(start);
        var st = start;
        for (var i = 0; i < steps; i++) {
            if (stop.func())
                return;
            tm.setTime(st);
            runtime.updateRuntime();
            if (condition.func()) {
                act.action();
            }
            let s = st + step;
            if (i > 0) {
                runtime.stepRuntime(st, s);
            }
            st = s;
        }
    }
    performFixedStepCalculation(runtime, start, step, steps, stop, act) {
        let tm = new TimeMeasurementProvider_1.TimeMeasurementProvider();
        runtime.setTimeProvider(tm);
        runtime.startRuntime(start);
        var st = start;
        var curr = start;
        for (var i = 0; i < steps; i++) {
            if (stop.func())
                return;
            tm.setTime(st);
            if (i > 0) {
                runtime.stepRuntime(curr, st);
                curr = st;
            }
            runtime.updateRuntime();
            act.action();
            st += step;
        }
    }
}
exports.PefrormerMeasuremets = PefrormerMeasuremets;
//# sourceMappingURL=PefrormerMeasuremets.js.map