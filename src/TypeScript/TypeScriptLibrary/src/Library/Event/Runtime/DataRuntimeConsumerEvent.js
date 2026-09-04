"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
exports.DataRuntimeConsumerEvent = void 0;
const DataRuntimeConsumerODE_1 = require("../../Runtime/DataRuntimeConsumerODE");
const ActionArray_1 = require("../../Utilities/Generic/ActionArray");
const PerformerEvents_1 = require("../PerformerEvents");
class DataRuntimeConsumerEvent extends DataRuntimeConsumerODE_1.DataRuntimeConsumerODE {
    ePerformer = new PerformerEvents_1.PerformerEvents();
    isEnabled = false;
    constructor(dataConsumer, factory) {
        super(dataConsumer, factory);
        this.typeName = "DataRuntimeConsumerEvent";
        this.types.push("IRealtimeCollection");
        this.types.push("IExternalUpdate");
        this.types.push("DataRuntimeConsumerEvent");
        var up = this.dataConsumer;
        var ob = this.dataConsumer;
        let a = new ActionArray_1.ActionArray();
        this.getExternalUpdate(ob, this, a);
        up.setExternalUpdate(a);
    }
    getExternalUpdate(obj, realime, action) {
        this.mPerformer.createUpdateMeasurementsAction(this, action);
        this.act = action;
        this.fo = obj;
        this.fre = realime;
    }
    act;
    fo;
    fre;
    prepare(dataConsumer) {
        super.prepare(dataConsumer);
        let x = this.performer.convertObject(dataConsumer, "IEventHandler");
        if (x.length == 0)
            return;
        let evetns = x[0].getEventHandlerEvents();
        for (let event of evetns) {
            let y = this.performer.convertObject(event, "ICategoryObject");
            if (y.length > 0) {
                let z = y[0];
                if (!this.categoryObjects.includes(z)) {
                    this.categoryObjects.push(z);
                }
            }
        }
    }
    getComponentCollection() {
        return this;
    }
    setComponentCollection(collection) {
        this.fc = collection;
    }
    fc;
    isComponentCollectionRunning() {
        return this.isEnabled;
    }
    setComponentCollectionRunning(running) {
        if (this.isEnabled == running)
            return;
        this.isEnabled = running;
        this.ePerformer.setComponentCollectionEnabled(this, running);
    }
    setTimerFactory(timerFactory) {
        this.ePerformer.setComponentCollectionTimer(this, timerFactory);
    }
    setTimeProvider(timeProvider) {
        this.mPerformer.setTimeProviderCollection(this, timeProvider);
        this.processor.setDifferentialEquationsTimeProvider(timeProvider);
    }
}
exports.DataRuntimeConsumerEvent = DataRuntimeConsumerEvent;
