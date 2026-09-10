"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
exports.ScadaScene = void 0;
const ScadaDesktop_1 = require("../../Scada/ScadaDesktop");
const ScadaDesktopEngine_1 = require("../../Scada/ScadaDesktopEngine");
const AbstractScene_1 = require("../../Game/Abstract/AbstractScene");
class ScadaScene extends AbstractScene_1.AbstractScene {
    constructor(game, collection, chart, engine) {
        super(game, chart);
        this.types.push("IScadaConsumer");
        this.collection = collection;
        if (engine !== undefined) {
            this.scada = new ScadaDesktopEngine_1.ScadaDesktopEngine(collection, engine, this.factory, this.name);
        }
        else {
            var eng = this.performer.convertObject(game, "IPlayEngine");
            if (eng.length > 0)
                this.scada = new ScadaDesktopEngine_1.ScadaDesktopEngine(collection, eng[0], this.factory, this.name);
            else
                this.scada = new ScadaDesktop_1.ScadaDesktop(collection);
        }
        var lc = this.factory.getFactory("IGameLoaderFactory");
        var loader = lc?.getLoader(this);
        if (loader != undefined) {
            this.performer.loadChildren(this, this.scada, loader, true);
        }
        this.setFactoryToChildren();
        let sa = this.getStepAction();
        if (sa != undefined) {
            this.stepAction = sa;
        }
    }
    getStepAction() {
        let sh = this.scada;
        if (sh === undefined)
            return undefined;
        return sh.getStepAction();
    }
    getConsumerScada() {
        return this.scada;
    }
    setConsumerScada(scada) {
        this.scada = scada;
        return false;
    }
    loadItself(load) {
        if (!super.loadItself(load))
            return false;
        if (load)
            this.performer.createSceneAction();
        else
            this.internalAction.clearActions();
        return true;
    }
    startItself(start) {
        if (this.isStarted == start)
            return false;
        this.isStarted = start;
        this.scada.setScadaEnabled(start);
        this.performer.startCollecion(start, this);
        this.currentTime = Number.MAX_VALUE;
        return true;
    }
}
exports.ScadaScene = ScadaScene;
//# sourceMappingURL=ScadaScene.js.map