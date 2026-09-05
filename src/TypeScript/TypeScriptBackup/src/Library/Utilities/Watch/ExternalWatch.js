"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
exports.ExternalWatch = void 0;
const ActionWatch_1 = require("./ActionWatch");
class ExternalWatch extends ActionWatch_1.ActionWatch {
    constructor(interval, external) {
        super(interval, external);
        this.ct = 0;
        this.start = 0;
    }
    actionT(t) {
        if (!this.enabled)
            return;
        this.ct = t;
        if (this.last > t) {
            this.last = t;
            this.startTime = t;
            this.setTime(t);
            return;
        }
        this.action();
    }
    isEmptyActionT() {
        return false;
    }
    setEngineEnabled(enabled) {
        if (this.enabled == enabled)
            return false;
        this.enabled = enabled;
        this.last = Number.MAX_VALUE;
        return true;
    }
    currentTime() {
        return this.ct - this.startTime;
    }
}
exports.ExternalWatch = ExternalWatch;
//# sourceMappingURL=ExternalWatch.js.map