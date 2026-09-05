"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
exports.ScadaDesktopEngine = void 0;
const EngineTimerProvider_1 = require("../Event/Objects/EngineTimerProvider");
const TimerPlayEngineFactory_1 = require("../Event/TimerPlayEngineFactory");
const ScadaDesktop_1 = require("./ScadaDesktop");
const ActionArray_1 = require("../Utilities/Generic/ActionArray");
class ScadaDesktopEngine extends ScadaDesktop_1.ScadaDesktop {
    constructor(componentCollection, engine, factory, chart) {
        super(componentCollection);
        this.actionr = new ActionArray_1.ActionArray;
        this.chart = "";
        this.engine = engine;
        this.chart = chart;
        var f = factory.getFactory("IRealtimeCollectionFactory");
        if (f === undefined) {
            return;
        }
        this.factory = f;
        this.uFactory = factory;
        this.createRuntime();
        engine.getEngineAction().addActionT(this);
    }
    createRuntime() {
        let co = this.componentCollection.getCategoryObject(this.chart);
        let dc = co;
        let eev = this.factory.createRealtimeFromDataConsumer(dc, this.uFactory);
        let tp = new EngineTimerProvider_1.EngineTimerProvider(this.engine);
        eev.setTimeProvider(tp);
        eev.setTimerFactory(new TimerPlayEngineFactory_1.TimerPlayEngineFactory(this.engine));
        this.runtime = eev;
    }
    addAction(action) {
        this.actionr.addAction(action);
    }
    removeAction(action) {
        this.actionr.removeAction(action);
    }
    clearActions() {
        this.actionr.clearActions();
    }
    action() {
        this.actionr.action();
    }
    isEmptyAction() {
        return this.actionr.isEmptyAction();
    }
    setScadaEnabled(enabled) {
        super.setScadaEnabled(enabled);
        this.engine.setEngineEnabled(enabled);
    }
}
exports.ScadaDesktopEngine = ScadaDesktopEngine;
//# sourceMappingURL=ScadaDesktopEngine.js.map