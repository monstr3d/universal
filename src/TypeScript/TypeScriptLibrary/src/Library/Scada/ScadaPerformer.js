"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
exports.ScadaPerformer = void 0;
const Performer_1 = require("../Performer");
const ScadaDesktopEngine_1 = require("./ScadaDesktopEngine");
const ActionWatch_1 = require("../Utilities/Watch/ActionWatch");
class ScadaPerformer extends Performer_1.Performer {
    setScada(collection, scada) {
        this.scada = scada;
        this.forEach(collection, this, "IScadaConsumer");
    }
    actionT(t) {
        t.setConsumerScada(this.scada);
    }
    isEmptyActionT() { return false; }
    createScadaDesktopEngine(componentCollection, engine, factory, chart) {
        return new ScadaDesktopEngine_1.ScadaDesktopEngine(componentCollection, engine, factory, chart);
    }
    createScadaDesktopAction(componentCollection, action, interval, factory, chart) {
        let engine = new ActionWatch_1.ActionWatch(interval, action);
        return new ScadaDesktopEngine_1.ScadaDesktopEngine(componentCollection, engine, factory, chart);
    }
    scada;
}
exports.ScadaPerformer = ScadaPerformer;
