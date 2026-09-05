"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
exports.AbstractEngine = void 0;
const EmptyObject_1 = require("../../EmptyObject");
const ActionArrayT_1 = require("../Generic/ActionArrayT");
class AbstractEngine extends EmptyObject_1.EmptyObject {
    constructor(interval) {
        super("");
        this.enabled = false;
        this.actionTime = new ActionArrayT_1.ActionArrayT();
        this.start = 0;
        this.interval = 0;
        this.interval = interval;
        this.typeName = "AbstractEngine";
        this.types.push("IPlayEngine");
        this.types.push("AbstractEngine");
    }
    isEngineEnabled() {
        return this.enabled;
    }
    getEngineAction() {
        return this.actionTime;
    }
    setTime(time) {
        if (this.enabled)
            this.actionTime.actionT(time);
    }
    currentTime() {
        const date = new Date();
        const t = date.getTime();
        return 0.001 * t;
    }
}
exports.AbstractEngine = AbstractEngine;
//# sourceMappingURL=AbstracrtEngine.js.map