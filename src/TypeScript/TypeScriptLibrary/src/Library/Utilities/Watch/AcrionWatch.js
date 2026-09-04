"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
exports.ActionWatch = void 0;
const AbstracrtEngine_1 = require("./AbstracrtEngine");
class ActionWatch extends AbstracrtEngine_1.AbstractEngine {
    constructor(interval, external) {
        super(interval);
        external.addAction(this);
    }
    action() {
        if (!this.enabled)
            return;
        let t = this.currentTime();
        if ((t - this.last) < this.interval)
            return;
        this.setTime(t);
        this.last = t;
    }
    isEmptyAction() {
        return false;
    }
    setEngineEnabled(enabled) {
        if (this.enabled == enabled)
            return false;
        this.enabled = enabled;
        return true;
    }
    last = Number.MAX_VALUE;
}
exports.ActionWatch = ActionWatch;
