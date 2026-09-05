"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
exports.PerformerMeasuremets = void 0;
const DataConsumerBoolFunc_1 = require("./DataConsumerBoolFunc");
const Performer_1 = require("../Performer");
const TimeMeasurementProvider_1 = require("./TimeMeasurementProvider");
const UpdateMeasurementsAction_1 = require("./UpdateMeasurementsAction");
const EmptyExceptionHandler_1 = require("../ErrorHandler/EmptyExceptionHandler");
class PerformerMeasuremets extends Performer_1.Performer {
    constructor(factory) {
        super();
        this.errorHandler = new EmptyExceptionHandler_1.EmptyExceptionHandler();
        if (factory === undefined)
            return;
        var p = factory.getFactory("IDifferentialEquationProcessor");
        if (p !== undefined)
            this.processor = p;
        var rt = factory.getFactory("IRealtimeCollectionFactory");
        if (rt !== undefined)
            this.realtimeEventFactory = rt;
        var e = factory.getFactory("IExceptionHandler");
        if (e !== undefined)
            this.errorHandler = e;
    }
    toNullabeMeasurement(m) {
        let x = m.getMeasurementValue();
        if (x === undefined)
            return undefined;
        return this.convert(x);
    }
    getDifferentialEquationProcessor() {
        return this.processor;
    }
    setDifferentialEquationProcessor(p) {
        this.processor = p;
    }
    getRealtimeEventFactory() {
        return this.realtimeEventFactory;
    }
    setRealtimeEventFactory(f) {
        this.realtimeEventFactory = f;
    }
    createUpdateMeasurementsAction(collection, act) {
        let mea = this.getAll(collection, "IMeasurements");
        let mm = this.sortMeasurements(mea);
        for (let m of mm) {
            act.addAction(new UpdateMeasurementsAction_1.UpdateMeasurementsAction(m));
        }
    }
    setTimeProvider(timeProvider, measurements) {
        for (let m of measurements) {
            let tm = this.convertObject(m, "ITimeMeasurementConsumer");
            if (tm.length > 0) {
                tm[0].setTimeMeasurement(timeProvider);
            }
        }
    }
    setTimeProviderCollection(objects, timeProvider) {
        let objs = objects.getObjectCollection();
        for (let o of objs) {
            let tm = this.convertObject(o, "ITimeMeasurementConsumer");
            if (tm.length > 0) {
                tm[0].setTimeMeasurement(timeProvider);
            }
        }
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
            measurements.push(mea);
            // let dc = mea as unknown as IDataConsumer;
            //     if (dc instanceof IDataConsumer)
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
    getMeasurementWrite(dataConsumer, meaurements, list) {
        let map = new Map();
        for (var [key, value] of meaurements) {
            map.set(key, this.getMeasurementDC(dataConsumer, value));
        }
        let action = new MeasurementWrite(map, list);
        return action;
    }
    async performIteratorDataConsumerFullAsync(dataConsumer, iterator, runtime, abort, preparation) {
        let map = new Map();
        let mm = dataConsumer.getAllMeasurements();
        for (let m of mm) {
            let o = m;
            let name = o.getName() + ".";
            let c = m.getMeasurementsCount();
            for (var i = 0; i < c; i++) {
                let ns = name + m.getMeasurement(i).getMeasurementName();
                map.set(ns, ns);
            }
        }
        let data = await this.performIteratorDataConsumerMapAsync(dataConsumer, iterator, runtime, abort, map, preparation);
        return data;
    }
    async performIteratorDataConsumerMapAsync(dataConsumer, iterator, runtime, abort, meaurements, preparation, errorHandler) {
        let list = [];
        let action = this.getMeasurementWrite(dataConsumer, meaurements, list);
        await this.performIteratorDataConsumerAsync(dataConsumer, iterator, runtime, abort, action, preparation, errorHandler);
        let data = list;
        return data;
    }
    async performIteratorDataConsumerAsync(dataConsumer, iterator, runtime, abort, action, preparation, errorHandler) {
        let desktop = undefined;
        try {
            if (preparation !== undefined)
                preparation.action();
            var co = dataConsumer;
            var d = co.getDesktop();
            desktop = d;
            await this.startAsync(d, abort);
            if (abort.signal.aborted) {
                if (errorHandler === undefined)
                    return;
                errorHandler.log("Start aborted");
                return;
            }
            this.setRunning(d, true);
            iterator.resetIterator();
            this.fullReset(dataConsumer);
            while (true) {
                if (abort.signal.aborted) {
                    if (errorHandler === undefined)
                        return;
                    errorHandler.log("Iteration aborted");
                    break;
                }
                if (!iterator.nextIterator()) {
                    break;
                }
                runtime.updateRuntime();
                action.action();
            }
        }
        catch (error) {
            this.errorHandler.handleException(error);
        }
        if (desktop != undefined)
            this.setRunning(desktop, false);
    }
    fullReset(consumer) {
        let meas = consumer.getAllMeasurements();
        for (let m of meas) {
            let c = this.convertObject(m, "IDataConsumer");
            if (c.length > 0) {
                c[0].resetDataConsumer();
                this.fullReset(c[0]);
            }
        }
    }
    printDataPerformerMeasurements(dataConsumer, printer) {
        let x = this.getMeasurementsDCMap(dataConsumer);
        for (var [key, value] of x) {
            printer.print(key);
            printer.print(value.getMeasurementValue());
            printer.print("\n");
        }
    }
}
exports.PerformerMeasuremets = PerformerMeasuremets;
class MeasurementWrite {
    constructor(map, list) {
        this.map = map;
        this.list = list;
    }
    action() {
        let m = new Map();
        for (var [key, value] of this.map.entries()) {
            let v = value.getMeasurementValue();
            m.set(key, v);
        }
        this.list.push(m);
    }
    isEmptyAction() {
        return false;
    }
}
//# sourceMappingURL=PerformerMeasuremets.js.map