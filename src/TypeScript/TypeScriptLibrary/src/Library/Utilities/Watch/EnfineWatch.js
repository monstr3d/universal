"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
exports.EngineWatch = void 0;
const ActionArrayT_1 = require("../Generic/ActionArrayT");
class EngineWatch {
    constructor(interval) {
        this.interval = interval;
    }
    isEngineEnabled() {
        return this.enabled;
    }
    setEngineEnabled(enabled) {
        if (enabled == this.enabled)
            return false;
        this.enabled = enabled;
        if (enabled) {
            const tick = () => {
                var t = this.currentTime() - this.start;
                this.setTime(t);
            };
            this.start = this.currentTime();
            this.timerID = setInterval(() => tick(), this.interval);
        }
        else {
            clearInterval(this.timerID);
        }
        return true;
    }
    getEngineAction() {
        return this.action;
    }
    setTime(time) {
        if (this.enabled)
            this.action.actionT(time);
    }
    currentTime() {
        const date = new Date();
        const t = date.getTime();
        return 0.001 * t;
    }
    enabled = false;
    action = new ActionArrayT_1.ActionArrayT();
    timerID = 0;
    start = 0;
    interval = 0;
}
exports.EngineWatch = EngineWatch;
