"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
exports.ActionWatch = void 0;
const AbstracrtEngine_1 = require("./AbstracrtEngine");
class ActionWatch extends AbstracrtEngine_1.AbstractEngine {
    constructor(interval, external) {
        super(interval);
        this.last = Number.MAX_VALUE;
        this.startTime = 0;
        external.addAction(this);
        this.typeName = "ActionWatch";
        this.types.push("ActionWatch");
    }
    action() {
        if (!this.enabled)
            return;
        let t = this.currentTime();
        if (t < this.last) {
            this.last = t;
            return;
        }
        let d = t - this.last;
        if (d < this.interval)
            return;
        this.setTime(t - this.startTime);
        this.last = t;
    }
    isEmptyAction() {
        return false;
    }
    setEngineEnabled(enabled) {
        if (this.enabled == enabled)
            return false;
        this.enabled = enabled;
        this.last = Number.MAX_VALUE;
        this.startTime = this.currentTime();
        return true;
    }
}
exports.ActionWatch = ActionWatch;
//# sourceMappingURL=ActionWatch.js.map