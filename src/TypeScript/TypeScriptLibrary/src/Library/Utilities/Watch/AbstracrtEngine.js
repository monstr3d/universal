"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
exports.AbstractEngine = void 0;
const ActionArrayT_1 = require("../Generic/ActionArrayT");
class AbstractEngine {
    constructor(interval) {
        this.interval = interval;
    }
    isEngineEnabled() {
        return this.enabled;
    }
    getEngineAction() {
        return this.actionT;
    }
    setTime(time) {
        if (this.enabled)
            this.actionT.actionT(time);
    }
    currentTime() {
        const date = new Date();
        const t = date.getTime();
        return 0.001 * t;
    }
    enabled = false;
    actionT = new ActionArrayT_1.ActionArrayT();
    start = 0;
    interval = 0;
}
exports.AbstractEngine = AbstractEngine;
