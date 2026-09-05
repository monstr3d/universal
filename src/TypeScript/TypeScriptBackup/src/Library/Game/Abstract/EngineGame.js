"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
exports.EngineGame = void 0;
const ActionArrayT_1 = require("../../Utilities/Generic/ActionArrayT");
const AbstractGame_1 = require("./AbstractGame");
class EngineGame extends AbstractGame_1.AbstractGame {
    constructor(name, factory, engine, useLoader) {
        super(name, factory, useLoader);
        this.engineIsRunning = false;
        this.engineAction = new ActionArrayT_1.ActionArrayT();
        this.types.push("IPlayEngine");
        this.types.push("EngineGame");
        this.typeName = "EngineGame";
        this.engine = engine;
        engine.getEngineAction().addActionT(this);
    }
    cycle(time) {
        if (!this.isStarted)
            return;
        super.cycle(time);
        this.engineAction.actionT(time);
    }
    actionT(t) {
        this.cycle(t);
    }
    isEmptyActionT() {
        return false;
    }
    getGameEngine() {
        return this.engine;
    }
    startItself(start) {
        if (!super.startItself(start))
            return false;
        this.engine.setEngineEnabled(start);
        if (start) {
            this.run();
        }
        return true;
    }
    run() {
        this.startItself(true);
    }
    isEngineEnabled() {
        return this.engineIsRunning;
    }
    setEngineEnabled(enabled) {
        if (enabled == this.engineIsRunning)
            return false;
        this.engineIsRunning = enabled;
        this.engine.setEngineEnabled(enabled);
        return true;
    }
    getEngineAction() {
        return this.engineAction;
    }
}
exports.EngineGame = EngineGame;
//# sourceMappingURL=EngineGame.js.map