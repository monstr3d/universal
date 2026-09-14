"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
exports.PerformerRealtime = void 0;
const EngineGame_1 = require("../../Game/Abstract/EngineGame");
const ScadaScene_1 = require("../../Game/Scenes/ScadaScene");
const PerformerMeasuremets_1 = require("../../Measurements/PerformerMeasuremets");
const ActionArray_1 = require("../../Utilities/Generic/ActionArray");
const ExternalWatch_1 = require("../../Utilities/Watch/ExternalWatch");
class PerformerRealtime extends PerformerMeasuremets_1.PerformerMeasuremets {
    constructor(factory, desktop, interval, chart) {
        super(factory);
        this.inputs = [];
        this.types.push("PerformerRealtime");
        this.typeName = "PerformerRealtime";
        this.engine = new ExternalWatch_1.ExternalWatch(interval, new ActionArray_1.ActionArray);
        let ic = desktop;
        // this.setTimeProviderCollection(ic, this.engine)
        this.game = new EngineGame_1.EngineGame("", this.factory, this.engine, false);
        this.scene = new ScadaScene_1.ScadaScene(this.game, ic, chart, this.engine);
        let sc = this.scene.getConsumerScada();
        this.scada = sc;
        let ii = sc.getScadaInputs();
        for (var i of ii)
            this.inputs.push(i);
        this.dataConsumer = this.scada.getScadaObject(chart, "IDataConsumer")[0];
        this.setTimeProviderCollection(ic, this.engine);
    }
    actionT(t) {
        this.engine.actionT(t);
    }
    isEmptyActionT() {
        return false;
    }
    action() {
        this.engine.action();
    }
    isEmptyAction() {
        return false;
    }
    loadGame() {
        this.game.loadItself(true);
        this.game.startItself(true);
    }
}
exports.PerformerRealtime = PerformerRealtime;
//# sourceMappingURL=PerformerRealtime.js.map