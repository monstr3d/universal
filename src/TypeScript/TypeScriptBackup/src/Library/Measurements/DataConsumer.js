"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
exports.DataConsumer = void 0;
const CategoryObject_1 = require("../CategoryObject");
const ActionArray_1 = require("../Utilities/Generic/ActionArray");
const PerformerMeasuremets_1 = require("./PerformerMeasuremets");
class DataConsumer extends CategoryObject_1.CategoryObject {
    constructor(desktop, name) {
        super(desktop, name);
        this.addRemoveobjects = [];
        this.measurements = [];
        this.isEvEnabled = false;
        this.success = true;
        this.eventAction = new ActionArray_1.ActionArray();
        this.basicAction = new ActionArray_1.ActionArray();
        this.fictiveAvtion = new ActionArray_1.ActionArray();
        this.currentAction = new ActionArray_1.ActionArray();
        this.externalEvents = [];
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
            this.pMeasurements = new PerformerMeasuremets_1.PerformerMeasuremets();
        else {
            this.pMeasurements = new PerformerMeasuremets_1.PerformerMeasuremets(f);
            let s = f.getFactory("IShowObject");
            if (s !== undefined)
                this.show = s;
        }
    }
    setExternalUpdate(action) {
        this.eventAction.clearActions();
        if (action === undefined) {
            return;
        }
        this.eventAction.addAction(action);
    }
    isEventEnabled() {
        return this.isEvEnabled;
    }
    isEmptyAction() { return false; }
    setEventEnabled(enabled) {
        if (enabled == this.isEvEnabled)
            return;
        this.isEvEnabled = enabled;
        if (enabled) {
            this.currentAction = this.eventAction;
            return;
        }
        this.currentAction = this.fictiveAvtion;
    }
    action() {
        this.currentAction.action();
    }
    getAddRemoveType() {
        return "";
    }
    getEventHandlerEvents() {
        return this.externalEvents;
    }
    addChildT(child) {
        this.fchild = child;
    }
    addEventToHandler(event) {
        var ev = this.performer.convertObject(event, "IEvent");
        if (ev.length == 0)
            return;
        this.performer.addUnique(this.externalEvents, event);
    }
    resetDataConsumer() {
    }
    addIterator(iterator) {
        this.iterator = iterator;
    }
    removeIterator(iterator) {
        this.fi = iterator;
    }
    getCheck() {
        return this.checker;
    }
    setCheck(check) {
        this.checker = check;
    }
    print(printer) {
        for (var m of this.measurements) {
            let co = m;
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
    getInternalTime() {
        var tm = this.timeMeasurement;
        return tm.getTime();
    }
    getTimeMeasurement() {
        return this.timeMeasurement;
    }
    setTimeMeasurement(measurement) {
        this.timeMeasurement = measurement;
        ;
    }
    postSetArrow() {
        for (let event of this.externalEvents) {
            let ea = event.eventAction();
            ea.addAction(this);
        }
    }
    getAllMeasurements() {
        return this.measurements;
    }
    addMeasurements(item) {
        this.measurements.push(item);
    }
    addRemoveObject(object, add) {
        if (add)
            this.addRemoveobjects.push(object);
        return true;
    }
    getAddRemoveObjects() {
        return this.addRemoveobjects;
    }
    toNullabe(m) {
        return this.pMeasurements.toNullabeMeasurement(m);
    }
}
exports.DataConsumer = DataConsumer;
//# sourceMappingURL=DataConsumer.js.map