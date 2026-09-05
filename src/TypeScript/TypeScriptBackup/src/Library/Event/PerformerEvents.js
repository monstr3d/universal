"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
exports.PerformerEvents = void 0;
const Performer_1 = require("../Performer");
class PerformerEvents {
    constructor() {
        this.isEnabled = false;
        this.performer = new Performer_1.Performer();
        this.timerAction = new TimerAction();
    }
    actionT(t) {
        t.setEventEnabled(this.isEnabled);
    }
    static getTimeScale() {
        return this.timeScale;
    }
    static setTimeScale(timeScale) {
        this.timeScale = timeScale;
    }
    setComponentCollectionEnabled(collection, enabled) {
        if (this.isEnabled == enabled)
            return;
        this.isEnabled = enabled;
        this.performer.forEach(collection, this, "IEventStart");
    }
    setComponentCollectionTimer(collection, factory) {
        if (factory === undefined)
            return;
        this.timerAction.set(factory);
        this.performer.forEach(collection, this.timerAction, "ITimerConsumer");
    }
    isEmptyActionT() { return false; }
}
exports.PerformerEvents = PerformerEvents;
PerformerEvents.timeScale = 1;
class TimerAction {
    actionT(t) {
        t.setTimer(this.factory);
    }
    isEmptyActionT() { return false; }
    set(factory) {
        this.factory = factory;
    }
}
//# sourceMappingURL=PerformerEvents.js.map